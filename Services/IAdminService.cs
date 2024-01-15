using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Enums;

namespace Artportable.API.Services
{
    public interface IAdminService
    {
        AdminStatisticsDTO GetStatistics();

         List<ProductStatisticsDTO> GetProductStatistics();
         
           public List<UserDTO> GetUsersByProduct(int productId);
           public List<UserWithSubscriptionDTO> GetUsersByProductSubscription(int productId);

          public string GetCustomerJson(string customerId);
    }
}