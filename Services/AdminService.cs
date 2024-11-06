using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Stripe;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using Microsoft.EntityFrameworkCore;



namespace Artportable.API.Services
{
    public class AdminService : IAdminService
    {
        private readonly APContext _context;

        public AdminService(APContext apContext)
        {
            _context = apContext ?? throw new ArgumentNullException(nameof(apContext));
        }

        public AdminStatisticsDTO GetStatistics()
        {
            var statistics = new AdminStatisticsDTO
            {
                Users = _context.Users.Count(),

                Artworks = _context.Artworks.Count(),

                Likes = _context.Likes.Count(),

                Connections = _context.Connections.Count()

                
            };

            return statistics;
        }

       public List<ProductStatisticsDTO> GetProductStatistics()
            {
                var productStatistics = _context.Users
                    .Join(_context.Subscriptions, u => u.SubscriptionId, s => s.Id, (u, s) => new { u, s })
                    .Join(_context.Products, us => us.s.ProductId, p => p.Id, (us, p) => new { us, p })
                    .GroupBy(x => x.p.Name)
                    .Select(g => new ProductStatisticsDTO
                    {
                        ProductName = g.Key,
                        UserCount = g.Count()
                    })
                    .ToList();

                return productStatistics;
            }

        public List<UserDTO> GetUsersByProduct(int productId)
            {
                // Get the date two months ago from today
                var twoMonthsAgo = DateTime.Now.AddMonths(-2);

                var usersWithProduct = _context.Users
                    .Join(_context.Subscriptions, u => u.SubscriptionId, s => s.Id, (u, s) => new { u, s })
                    .GroupJoin(_context.Products, us => us.s.ProductId, p => p.Id, (us, products) => new { us, products })
                    .SelectMany(x => x.products.DefaultIfEmpty(), (x, p) => new { x.us, p })
                    .Where(x => x.p != null && x.p.Id == productId && x.us.u.Created >= twoMonthsAgo)
                    .Select(x => new UserDTO
                    {
                        Username = x.us.u.Username,
                        Email = x.us.u.Email,
                        Created = x.us.u.Created,
                        Name = x.us.u.UserProfile.Name,
                        PhoneNumber = x.us.u.PhoneNumber
                    })
                    .OrderByDescending(x => x.Created) 
                    .ToList();

                return usersWithProduct;
            }

        public List<UserWithSubscriptionDTO> GetUsersByProductSubscription(int productId)
        {
            var userIds = _context.Users
                .Join(_context.Subscriptions, u => u.SubscriptionId, s => s.Id, (u, s) => new { u, s })
                .Where(x => x.s.ProductId == productId)
                .Select(x => x.u.Id)
                .ToList();

            var usersWithProduct = _context.Users
                .Where(u => userIds.Contains(u.Id))
                .OrderByDescending(x => x.Created)
                .Select(u => new UserWithSubscriptionDTO
                {
                    User_Id = u.Id,
                    Subscription_Id = u.SubscriptionId,
                    Product_Id = u.Subscription.ProductId,
                    CustomerId = u.Subscription.CustomerId,
                    ExpirationDate = u.Subscription.ExpirationDate,
                    Username = u.Username,
                    Email = u.Email,
                    Created = u.Created,
                    Name = u.UserProfile.Name,
                    Surname = u.UserProfile.Surname,
                    PhoneNumber = u.PhoneNumber
                })
                .ToList();

            return usersWithProduct;
        }   
        public string GetCustomerJson(string customerId)
        {
            try
            {
                StripeConfiguration.ApiKey = "sk_live_YOUvIGb9PvSi7aDeX5OYqyUN00YcBAGqKx";

                var service = new CustomerService();
                var options = new CustomerGetOptions
                {
                    Expand = new List<string> { "subscriptions" }  // Request subscriptions data
                };

                var stripeCustomer = service.Get(customerId, options);

                if (stripeCustomer != null)
                {
                    string customerJson = JsonConvert.SerializeObject(stripeCustomer);
                    return customerJson;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching customer: {e}");
                return null;
            }
        }

                    public async Task<UserWithSubscriptionDTO> GetUserWithActiveOrTrialingStripeSubscriptionByEmailAsync(string email)
{
    try
    {
        // Fetch the user and their subscription details by email
        var user = await _context.Users
            .Include(u => u.Subscription) // Load the subscription details
            .Include(u => u.UserProfile)  // Load the user profile for Name and Surname
            .FirstOrDefaultAsync(u => u.Email == email);

        if (user == null)
        {
            Console.WriteLine("User not found in the database");
            return null;
        }

        if (user.Subscription == null)
        {
            Console.WriteLine("User does not have a subscription");
            return null;
        }

        var stripeCustomerId = user.Subscription.CustomerId;

        if (string.IsNullOrEmpty(stripeCustomerId))
        {
            Console.WriteLine("CustomerId is missing for this subscription");
            return null;
        }

        var subscriptionService = new SubscriptionService();

        // Fetch active and trialing subscriptions for the customer from Stripe
        var subscriptions = subscriptionService.List(new SubscriptionListOptions
        {
            Customer = stripeCustomerId,
            Status = "all",  // Fetch all statuses to filter locally
            Limit = 1        // Limit to 1 subscription
        });

        if (subscriptions == null || !subscriptions.Data.Any())
        {
            Console.WriteLine("No subscriptions found for Stripe customer: " + stripeCustomerId);
            return null;
        }

        // Find the first subscription that is either "active" or "trialing"
        var activeOrTrialingSubscription = subscriptions.Data
            .FirstOrDefault(sub => sub.Status == "active" || sub.Status == "trialing");

        if (activeOrTrialingSubscription == null)
        {
            Console.WriteLine("No active or trialing subscriptions found for Stripe customer: " + stripeCustomerId);
            return null;
        }

        // Debugging: Check if Items contain data
        Console.WriteLine($"Subscription items count: {activeOrTrialingSubscription.Items.Data.Count}");

        // Extract product plan from subscription (use Product ID or Name)
        var plan = activeOrTrialingSubscription.Items.Data.FirstOrDefault()?.Plan?.Id;

        foreach (var item in activeOrTrialingSubscription.Items.Data)
        {
            Console.WriteLine($"Item Plan ID: {item.Plan?.Id}");
            Console.WriteLine($"Item Product ID: {item.Plan?.Product?.Id}");
       
        }

        // Return user details with subscription info, including ProductPlan
        return new UserWithSubscriptionDTO
        {
            User_Id = user.Id,
            Subscription_Id = user.SubscriptionId,
            Product_Id = user.Subscription.ProductId,
            CustomerId = stripeCustomerId,
            ExpirationDate = user.Subscription.ExpirationDate,
            Username = user.Username,
            Email = user.Email,
            Created = user.Created,
            SubscriptionStatus = activeOrTrialingSubscription.Status,
            ProductPlan = plan  // Assign the plan's product ID or name
        };
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error fetching active or trialing subscriptions by email: {e}");
        return null;
    }
}

    }
}
