using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artportable.API.Enums;

namespace Artportable.API.Interfaces.Services
{
    public interface ICrmService
    {
        Task RegisterPurchase(string subscriptionCustomerId, ProductEnum product, decimal price, string currency, PaymentIntervalEnum intervalEnum);
    }
}