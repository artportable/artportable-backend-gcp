using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artportable.API.Enums;

namespace Artportable.API.Options
{
    public class UpsalesOptions
    {
        public string ApiKey { get; set; }
        public string BaseUrl { get; set; }
        public int UserId { get; set; }
        public List<UpsalesOptionsProduct> Products { get; set; }
    }

    public class UpsalesOptionsProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PaymentIntervalEnum Interval { get; set; }
        public ProductEnum InternalId { get; set; }
    }
}
