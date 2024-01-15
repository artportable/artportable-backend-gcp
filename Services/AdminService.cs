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
                var usersWithProduct = _context.Users
                    .Join(_context.Subscriptions, u => u.SubscriptionId, s => s.Id, (u, s) => new { u, s })
                    .GroupJoin(_context.Products, us => us.s.ProductId, p => p.Id, (us, products) => new { us, products })
                    .SelectMany(x => x.products.DefaultIfEmpty(), (x, p) => new { x.us, p })
                    .Where(x => x.p != null && x.p.Id == productId)
                    .Select(x => new UserDTO
                    {
                        Username = x.us.u.Username,
                        Email = x.us.u.Email,
                        Created = x.us.u.Created,
                        Name = x.us.u.UserProfile.Name,
                
                    })
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
                    Surname = u.UserProfile.Surname
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
        var stripeCustomer = service.Get(customerId);

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





        

    }
}
