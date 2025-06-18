using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Stripe;
using Stripe.BillingPortal;

namespace Artportable.API.Services
{
    public class PaymentService : IPaymentService
    {
        private APContext _context;

        public PaymentService(APContext apContext)
        {
            _context = apContext ?? throw new ArgumentNullException(nameof(apContext));
        }

        public List<StripePriceDTO> GetPrices()
        {
            var pricesOptions = new PriceListOptions { Active = true };
            pricesOptions.AddExpand("data.product");
            var pricesService = new PriceService();
            var prices = pricesService.List(pricesOptions);

            var res = prices
                .Data.Where(p =>
                    p != null
                    && p.Active
                    && p.Deleted != true
                    && p?.Recurring?.Interval != null
                    && p.Product.Active
                    && p.Product.Metadata.ContainsKey("productkey")
                )
                .Select(p => new StripePriceDTO()
                {
                    Id = p.Id,
                    Amount = (decimal)p.UnitAmount / 100,
                    Currency = p.Currency,
                    RecurringInterval = p.Recurring.Interval,
                    Product = p.Product.Name,
                    ProductKey = p.Product.Metadata.GetValueOrDefault("productkey"),
                })
                .ToList();

            return res;
        }

        public string CreateCustomer(string email, string fullName, string phoneNumber)
        {
            var subscription = _context
                .Subscriptions.Where(s => s.User.Email == email)
                .SingleOrDefault();
            if (string.IsNullOrWhiteSpace(subscription?.CustomerId))
            {
                var customerService = new CustomerService();
                var customers = customerService.List(new CustomerListOptions() { Email = email });
                var customer = customers.FirstOrDefault();
                if (customer == null)
                {
                    var options = new CustomerCreateOptions
                    {
                        Email = email,
                        Name = fullName,
                        Phone = phoneNumber,
                    };
                    customer = customerService.Create(options);
                    if (subscription! != null)
                    {
                        subscription.CustomerId = customer.Id;
                        _context.SaveChanges();
                    }
                }
                return customer.Id;
            }
            return subscription.CustomerId;
        }

        public Subscription CreateSubscription(
            string paymentMethodId,
            string customerId,
            string priceId,
            string? promotionCode
        )
        {
            try
            {
                var paymentMethodService = new PaymentMethodService();
                var paymentMethod = paymentMethodService.Attach(
                    paymentMethodId,
                    new PaymentMethodAttachOptions { Customer = customerId }
                );

                var customerService = new CustomerService();
                customerService.Update(
                    customerId,
                    new CustomerUpdateOptions
                    {
                        InvoiceSettings = new CustomerInvoiceSettingsOptions
                        {
                            DefaultPaymentMethod = paymentMethod.Id,
                        },
                    }
                );

                string promotionCodeId = null;
                if (!string.IsNullOrEmpty(promotionCode))
                {
                    var promotionCodeService = new PromotionCodeService();
                    var promotionCodeOptions = new PromotionCodeListOptions
                    {
                        Code = promotionCode.Trim().ToUpper(),
                        Active = true,
                    };

                    var promotionCodes = promotionCodeService.List(promotionCodeOptions);
                    var validPromoCode = promotionCodes.FirstOrDefault();

                    if (validPromoCode == null)
                    {
                        throw new StripeException
                        {
                            StripeError = new StripeError
                            {
                                Message = "Invalid or expired promotion code",
                                Code = "invalid_promotion_code",
                            },
                        };
                    }

                    if (
                        validPromoCode.Coupon != null
                        && validPromoCode.Coupon.AppliesTo != null
                        && validPromoCode.Coupon.AppliesTo.Products != null
                        && validPromoCode.Coupon.AppliesTo.Products.Count > 0
                    )
                    {
                        if (!validPromoCode.Coupon.AppliesTo.Products.Contains(priceId))
                        {
                            throw new StripeException
                            {
                                StripeError = new StripeError
                                {
                                    Message = "Promotion code not valid for this product",
                                    Code = "invalid_promotion_product",
                                },
                            };
                        }
                    }

                    promotionCodeId = validPromoCode.Id;
                }

                var subscriptionOptions = new SubscriptionCreateOptions
                {
                    Customer = customerId,
                    Items = new List<SubscriptionItemOptions>
                    {
                        new SubscriptionItemOptions { Price = priceId },
                    },
                };

                if (!string.IsNullOrEmpty(promotionCodeId))
                {
                    subscriptionOptions.PromotionCode = promotionCodeId;
                }

                var trialEligiblePriceIds = new HashSet<string>
                {
                    "price_1RZVMFJgjKIYr4gqnoGM7HT1",
                    "price_1RZVLbJgjKIYr4gqfAQRnxsg",
                    "price_1RZVOLJgjKIYr4gq93amGib7",
                    "price_1RZVPDJgjKIYr4gqqj8etjGd",
                    "price_1RYOxmJgjKIYr4gq9rEQ3v1e",
                    "price_1RYP3BJgjKIYr4gq07cNnCb7",
                    "price_1RYRCcA3UXZjjLWx9eZ0PniP",
                    "price_1Raz0EJgjKIYr4gqkcn4xDC9",
                    "price_1RayzgJgjKIYr4gqLnlgrQt3",
                    "price_1RbJN8JgjKIYr4gqKZE8Jq1E",
                    "price_1RbJNsJgjKIYr4gqOSjR7sb2",
                    "price_1RbJOzJgjKIYr4gqExMaRnbh",
                    "price_1RbJPeJgjKIYr4gqr7M8kY0J"
               
                
                };

                if (trialEligiblePriceIds.Contains(priceId))
                {
                    subscriptionOptions.TrialEnd = DateTime.UtcNow.AddDays(10);
                }

                subscriptionOptions.AddExpand("latest_invoice.payment_intent");

                var subscriptionService = new SubscriptionService();
                Subscription subscription = subscriptionService.Create(subscriptionOptions);

                // Extract the client secret for 3D Secure authentication
                var clientSecret = subscription.LatestInvoice?.PaymentIntent?.ClientSecret;

                // Handle the 3D Secure Flow if needed
                if (clientSecret != null && subscription.Status == "requires_action")
                {
                    return new Subscription
                    {
                        Id = subscription.Id,
                        CustomerId = subscription.CustomerId,
                        Status = subscription.Status,
                        LatestInvoice = subscription.LatestInvoice,
                        // you can add more if needed
                        Metadata = new Dictionary<string, string>
                        {
                            { "requires_action", "true" },
                            { "client_secret", clientSecret },
                        },
                    };
                }

                // Return the subscription object (you can include status here as well)
                // --- Artportable: Persist subscription details immediately so that the user tier is reflected without waiting for the Stripe webhook ---
                try
                {
                    var subscriptionDb = _context.Subscriptions.SingleOrDefault(s => s.CustomerId == subscription.CustomerId);

                    if (subscriptionDb != null)
                    {
                        // Determine which internal product this Stripe subscription corresponds to.
                        string productKey = null;

                        try
                        {
                            // Retrieve the price, expanding its product to access metadata.
                            var priceService = new PriceService();
                            var priceOptions = new PriceGetOptions { Expand = new List<string> { "product" } };
                            var price = priceService.Get(priceId, priceOptions);

                            if (
                                price?.Product != null
                                && price.Product.Metadata != null
                                && price.Product.Metadata.ContainsKey("productkey")
                            )
                            {
                                productKey = price.Product.Metadata["productkey"];
                            }
                        }
                        catch (Exception) { /* ignore */ }

                        // Fallback – try to grab metadata directly from subscription if expanded (rare).
                        if (string.IsNullOrWhiteSpace(productKey))
                        {
                            productKey = subscription.Items?.Data?[0]?.Price?.Product?.Metadata?.ContainsKey("productkey") == true
                                ? subscription.Items.Data[0].Price.Product.Metadata["productkey"]
                                : null;
                        }

                        if (!string.IsNullOrWhiteSpace(productKey))
                        {
                            switch (productKey.Trim().ToLowerInvariant())
                            {
                                case "portfoliomini":
                                case "mini":
                                    subscriptionDb.ProductId = (int)ProductEnum.PortfolioMini;
                                    break;
                                case "portfolio":
                                case "basic":
                                case "bas":
                                    subscriptionDb.ProductId = (int)ProductEnum.Portfolio;
                                    break;
                                case "portfoliopremium":
                                case "premium":
                                    subscriptionDb.ProductId = (int)ProductEnum.PortfolioPremium;
                                    break;
                                case "portfoliopremiumplus":
                                case "premiumplus":
                                    subscriptionDb.ProductId = (int)ProductEnum.PortfolioPremiumPlus;
                                    break;
                            }
                        }

                        // Always update expiration date if Stripe provided it
                        subscriptionDb.ExpirationDate = subscription.CurrentPeriodEnd;

                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    // We swallow the exception to avoid breaking the main flow, but we log to console for diagnostics.
                    Console.WriteLine($"[PaymentService] Failed to persist subscription data: {ex.Message}");
                }

                return subscription;
            }
            catch (StripeException ex)
            {
                Console.WriteLine($"Stripe error: {ex.StripeError?.Message ?? ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating subscription: {ex.Message}");
                throw;
            }
        }

        public Session CreateCustomerPortalSession(string customerId)
        {
            var service = new SessionService();

            var options = new SessionCreateOptions
            {
                Customer = customerId,
                ReturnUrl = "https://artportable.com",
            };

            try
            {
                var session = service.Create(options);
                return session;
            }
            catch (StripeException ex)
            {
                // Handle the exception appropriately
                Console.WriteLine($"Stripe exception occurred: {ex.Message}");
                throw;
            }
        }

        public Subscription UpgradeSubscription(
            string paymentMethodId,
            string customerId,
            string newPriceId,
            string promotionCodeId
        )
        {
            var subscriptionService = new SubscriptionService();
            Subscription newSubscription = null;
            string oldSubscriptionId = null;

            try
            {
                // First, create the new subscription
                Console.WriteLine($"Creating new subscription for customer: {customerId}");
                newSubscription = CreateSubscription(
                    paymentMethodId,
                    customerId,
                    newPriceId,
                    promotionCodeId
                );

                if (newSubscription == null)
                {
                    throw new InvalidOperationException("Failed to create new subscription");
                }

                Console.WriteLine($"New subscription created successfully: {newSubscription.Id}");

                // Now find and cancel any existing active subscriptions
                var subscriptions = subscriptionService.List(
                    new SubscriptionListOptions { 
                        Customer = customerId, 
                        Status = "active",
                        Limit = 10 // Get multiple in case there are several
                    }
                );

                foreach (var existingSubscription in subscriptions.Data)
                {
                    // Don't cancel the subscription we just created
                    if (existingSubscription.Id == newSubscription.Id)
                        continue;

                    try
                    {
                        oldSubscriptionId = existingSubscription.Id;
                        Console.WriteLine($"Canceling old subscription: {oldSubscriptionId}");
                        
                        var canceledSubscription = subscriptionService.Cancel(
                            oldSubscriptionId,
                            new SubscriptionCancelOptions { InvoiceNow = false }
                        );

                        Console.WriteLine($"Successfully canceled old subscription: {oldSubscriptionId}, Status: {canceledSubscription.Status}");
                    }
                    catch (StripeException ex)
                    {
                        Console.WriteLine($"Warning: Failed to cancel old subscription {oldSubscriptionId}: {ex.StripeError?.Message ?? ex.Message}");
                        // Don't throw here - the new subscription was created successfully
                    }
                }

                return newSubscription;
            }
            catch (StripeException ex)
            {
                Console.WriteLine($"Stripe error during upgrade: {ex.StripeError?.Message ?? ex.Message}");
                
                // If we created a new subscription but then failed, try to clean it up
                if (newSubscription != null)
                {
                    try
                    {
                        Console.WriteLine($"Attempting to cancel newly created subscription due to upgrade failure: {newSubscription.Id}");
                        subscriptionService.Cancel(newSubscription.Id, null);
                    }
                    catch (Exception cleanupEx)
                    {
                        Console.WriteLine($"Failed to cleanup new subscription {newSubscription.Id}: {cleanupEx.Message}");
                    }
                }
                
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General error during upgrade: {ex.Message}");
                
                // If we created a new subscription but then failed, try to clean it up
                if (newSubscription != null)
                {
                    try
                    {
                        Console.WriteLine($"Attempting to cancel newly created subscription due to upgrade failure: {newSubscription.Id}");
                        subscriptionService.Cancel(newSubscription.Id, null);
                    }
                    catch (Exception cleanupEx)
                    {
                        Console.WriteLine($"Failed to cleanup new subscription {newSubscription.Id}: {cleanupEx.Message}");
                    }
                }
                
                throw;
            }
        }

        public void CancelSubscription(string subscriptionId)
        {
            var service = new SubscriptionService();
            var subscription = service.Cancel(subscriptionId, null);
        }

        public void UpdateSubscription(string subscriptionId, string priceId)
        {
            var service = new SubscriptionService();
            var currentSubscription = service.Get(subscriptionId);
            var items = new List<SubscriptionItemOptions>
            {
                new SubscriptionItemOptions
                {
                    Id = currentSubscription.Items.Data[0].Id,
                    Price = priceId,
                },
            };

            var options = new SubscriptionUpdateOptions
            {
                CancelAtPeriodEnd = false,
                ProrationBehavior = "create_prorations",
                Items = items,
            };

            service.Update(subscriptionId, options);
        }

        public PromotionDTO GetPromotion(string promotionCode)
        {
            var promotionCodeService = new PromotionCodeService();
            var options = new PromotionCodeListOptions() { Code = promotionCode };
            var promotion = promotionCodeService
                .List(options)
                .Where(x => x.Active == true)
                .FirstOrDefault();

            if (promotion == null)
            {
                return null;
            }

            var discountInPercent = promotion.Coupon.PercentOff != null;

            return new PromotionDTO
            {
                Name = promotion.Coupon.Name,
                DiscountInPercent = discountInPercent,
                AmountOff =
                    (
                        discountInPercent
                            ? promotion.Coupon.PercentOff
                            : promotion.Coupon.AmountOff / 100
                    ) ?? 0,
                Currency = promotion.Coupon.Currency,
            };
        }

        public async Task<bool> ValidatePaymentMethod(string paymentMethodId)
        {
            var paymentMethodService = new PaymentMethodService();
            try
            {
                var paymentMethod = await paymentMethodService.GetAsync(paymentMethodId);
                return true;
            }
            catch (System.Exception)
            {
                //throws exception if paymentmethod doesnt exist
                return false;
            }
        }

        public async Task<Invoice> CreateInvoice(
            string paymentMethodId,
            string customerId,
            List<string> products
        )
        {
            var paymentMethodOptions = new PaymentMethodAttachOptions { Customer = customerId };
            var service = new PaymentMethodService();
            var paymentMethod = service.Attach(paymentMethodId, paymentMethodOptions);
            var invoiceItemService = new InvoiceItemService();
            foreach (var product in products)
            {
                var options = new InvoiceItemCreateOptions
                {
                    Customer = customerId,
                    Price = product,
                };
                var invoiceItem = await invoiceItemService.CreateAsync(options);
            }

            var invoiceService = new InvoiceService();
            var invoiceOptions = new InvoiceCreateOptions()
            {
                DefaultPaymentMethod = paymentMethodId,
                Customer = customerId,
                CollectionMethod = "charge_automatically",
                AutoAdvance = true,
            };
            var invoice = await invoiceService.CreateAsync(invoiceOptions);
            invoice = await invoiceService.FinalizeInvoiceAsync(
                invoice.Id,
                new InvoiceFinalizeOptions { Expand = new List<string> { "payment_intent" } }
            );
            return invoice;
        }

        public async Task<bool> ValidateProducts(List<string> prices)
        {
            var priceService = new PriceService();
            var pricesObjects = await priceService.ListAsync();
            var pricesIds = pricesObjects.Select(x => x.Id);
            return prices.All(x => pricesIds.Contains(x));
        }

        public async Task<bool> BoostArtwork(
            string paymentMethodId,
            string customerId,
            string artworkId
        )
        {
            try
            {
                var artwork = _context.Artworks.FirstOrDefault(a =>
                    a.PublicId.ToString() == artworkId
                );
                if (artwork == null)
                {
                    Console.WriteLine("Artwork not found.");
                    return false;
                }

                var isPaymentMethodValid = await ValidatePaymentMethod(paymentMethodId);
                if (!isPaymentMethodValid)
                {
                    Console.WriteLine("Invalid payment method.");
                    return false;
                }

                if (artwork.IsBoosted)
                {
                    Console.WriteLine("Artwork is already boosted.");
                    return false;
                }

                var invoice = await CreateBoostPayment(paymentMethodId, customerId);
                if (invoice == null)
                {
                    Console.WriteLine("Failed to create boost invoice.");
                    return false;
                }
                artwork.IsBoosted = true;
                artwork.BoostedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error boosting artwork: {ex.Message}");
                return false;
            }
        }

        private static async Task<PaymentIntent> CreateBoostPayment(
            string paymentMethodId,
            string customerId
        )
        {
            try
            {
                var paymentMethodService = new PaymentMethodService();
                var options = new PaymentMethodAttachOptions { Customer = customerId };
                var paymentMethod = await paymentMethodService.AttachAsync(
                    paymentMethodId,
                    options
                );

                var paymentIntentService = new PaymentIntentService();
                var paymentIntentOptions = new PaymentIntentCreateOptions
                {
                    Amount = 19500,
                    Currency = "sek",
                    Customer = customerId,
                    PaymentMethod = paymentMethodId,
                    Confirm = true,
                    ConfirmationMethod = "manual",
                    Description = "Portfolio Boost",
                };
                var paymentIntent = await paymentIntentService.CreateAsync(paymentIntentOptions);

                return paymentIntent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating boost payment: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> BoostStory(
            string paymentMethodId,
            string customerId,
            string storyId
        )
        {
            try
            {
                var story = _context.Stories.FirstOrDefault(a => a.PublicId.ToString() == storyId);
                if (story == null)
                {
                    Console.WriteLine("Story not found.");
                    return false;
                }

                var isPaymentMethodValid = await ValidatePaymentMethod(paymentMethodId);
                if (!isPaymentMethodValid)
                {
                    Console.WriteLine("Invalid payment method.");
                    return false;
                }

                if (story.IsBoosted)
                {
                    Console.WriteLine("Story is already boosted.");
                    return false;
                }

                var invoice = await CreateBoostStoryPayment(paymentMethodId, customerId);
                if (invoice == null)
                {
                    Console.WriteLine("Failed to create boost invoice.");
                    return false;
                }
                story.IsBoosted = true;
                story.BoostedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error boosting story: {ex.Message}");
                return false;
            }
        }

        private static async Task<PaymentIntent> CreateBoostStoryPayment(
            string paymentMethodId,
            string customerId
        )
        {
            try
            {
                var paymentMethodService = new PaymentMethodService();
                var options = new PaymentMethodAttachOptions { Customer = customerId };
                var paymentMethod = await paymentMethodService.AttachAsync(
                    paymentMethodId,
                    options
                );

                var paymentIntentService = new PaymentIntentService();
                var paymentIntentOptions = new PaymentIntentCreateOptions
                {
                    Amount = 99500,
                    Currency = "sek",
                    Customer = customerId,
                    PaymentMethod = paymentMethodId,
                    Confirm = true,
                    ConfirmationMethod = "manual",
                    Description = "Exhibition Boost",
                };
                var paymentIntent = await paymentIntentService.CreateAsync(paymentIntentOptions);

                return paymentIntent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating boost payment: {ex.Message}");
                return null;
            }
        }
    }
}
