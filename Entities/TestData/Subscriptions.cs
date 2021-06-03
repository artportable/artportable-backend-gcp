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
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(21),
            CustomerId = "cus_J6O5PTOI0UfdjD"
          },
          new Subscription
          {
            Id = 2,
            ProductId = 1,
            ExpirationDate = null,
            CustomerId = null
          },
          new Subscription
          {
            Id = 3,
            ProductId = 1,
            ExpirationDate = null,
            CustomerId = null
          },
          new Subscription
          {
            Id = 4,
            ProductId = 3,
            ExpirationDate = DateTime.Now.AddDays(25),
            CustomerId = "cus_J6O5PTOewXfdjD"
          },
          new Subscription
          {
            Id = 5,
            ProductId = 1,
            ExpirationDate = null,
            CustomerId = null
          },
          new Subscription
          {
            Id = 6,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(46),
            CustomerId = "cus_J6O521fI1XfdjD"
          },
          new Subscription
          {
            Id = 7,
            ProductId = 1,
            ExpirationDate = null,
            CustomerId = null
          },
          new Subscription
          {
            Id = 8,
            ProductId = 3,
            ExpirationDate = DateTime.Now.AddDays(132),
            CustomerId = "cus_J6O5PTOI1XfdjW"
          },
          new Subscription
          {
            Id = 9,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(15),
            CustomerId = "cus_J6O5PTOI6XfdjD"
          },
          new Subscription
          {
            Id = 10,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(30),
            CustomerId = "cus_J6O5PTOI2XfdjD"
          },
          new Subscription
          {
            Id = 11,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(29),
            CustomerId = "cus_J6O5JKOI1XfdjD"
          },
          new Subscription
          {
            Id = 12,
            ProductId = 1,
            ExpirationDate = null,
            CustomerId = null
          },
          new Subscription
          {
            Id = 13,
            ProductId = 1,
            ExpirationDate = null,
            CustomerId = null
          },
          new Subscription
          {
            Id = 14,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(86),
            CustomerId = "cus_J6O5PTOIdXfdjD"
          },
          new Subscription
          {
            Id = 15,
            ProductId = 3,
            ExpirationDate = DateTime.Now.AddDays(12),
            CustomerId = "cus_J6OsPTOI1XfdjD"
          },
          new Subscription
          {
            Id = 16,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(26),
            CustomerId = "cus_J6O5PTdI1XfdjD"
          },
          new Subscription
          {
            Id = 17,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(29),
            CustomerId = "cus_J6O5PTdI1wfdjD"
          },
          new Subscription
          {
            Id = 18,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(92),
            CustomerId = "cus_J6O5Pddd1XfdjD"
          },
          new Subscription
          {
            Id = 19,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(192),
            CustomerId = "cus_J6sa41XfdjD"
          },
          new Subscription
          {
            Id = 20,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(74),
            CustomerId = "cus_J6O5PddhfXfdjD"
          },
          new Subscription
          {
            Id = 21,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(39),
            CustomerId = "cus_J6O5Ps65d1XdjD"
          },
          new Subscription
          {
            Id = 22,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(29),
            CustomerId = "cus_J6O5Pdfd1XfdjD"
          },
          new Subscription
          {
            Id = 23,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(94),
            CustomerId = "cus_J6O5P634XfdjD"
          },
          new Subscription
          {
            Id = 24,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(16),
            CustomerId = "cus_J6Oas4dd1XfdjD"
          },
          new Subscription
          {
            Id = 25,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(47),
            CustomerId = "cus_J6O5sddd1XfdjD"
          },
          new Subscription
          {
            Id = 26,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(93),
            CustomerId = "cus_J6O5PddfddfdjD"
          },
          new Subscription
          {
            Id = 27,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(193),
            CustomerId = "cus_J6O5PddsuifdjD"
          },
          new Subscription
          {
            Id = 28,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(193),
            CustomerId = "cus_J6O5PdasuifdjD"
          },
          new Subscription
          {
            Id = 29,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(193),
            CustomerId = "cus_JaO5PdaauifdjD"
          },
          new Subscription
          {
            Id = 30,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(193),
            CustomerId = "cus_JaO5P90auifdjD"
          },
          new Subscription
          {
            Id = 31,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(193),
            CustomerId = "cus_JaO5P90au8fdjD"
          },
          new Subscription
          {
            Id = 32,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(193),
            CustomerId = "cus_JaOds90au8fdjD"
          },
          new Subscription
          {
            Id = 33,
            ProductId = 2,
            ExpirationDate = DateTime.Now.AddDays(193),
            CustomerId = "cus_JaOds90ad8fdjD"
          }
        };
    }
  }
}
