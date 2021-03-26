using System;
using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Subscription[] Subscriptions
    {
      get =>
        new Subscription[]
        {
          new Subscription
          {
            Id = 1,
            ProductId = 1,
            ExpirationDate = null,
            CustomerId = null
          },
          new Subscription
          {
            Id = 2,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(21),
            CustomerId = "testcujlkd13543a"
          },
          new Subscription
          {
            Id = 3,
            ProductId = 3,
            ExpirationDate = DateTime.Now.AddDays(25),
            CustomerId = "testcujlkd32132dsa"
          },
          new Subscription
          {
            Id = 4,
            ProductId = 1,
            ExpirationDate = null,
            CustomerId = null
          },
          new Subscription
          {
            Id = 5,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(6),
            CustomerId = "testcsasaSAdsa"
          },
          new Subscription
          {
            Id = 6,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(46),
            CustomerId = "testcdsdsalkdsa"
          }
        };
    }
  }
}
