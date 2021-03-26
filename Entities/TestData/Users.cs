using System;
using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public User[] Users
    {
      get =>
        new User[]
        {
          new User
          {
            Id = 1,
            PublicId = new Guid("b2ca9be2-f852-4d65-9498-c43366996352"),
            SubscriptionId = 1,
            FileId = 15,
            Username = "lordtep",
            Email = "lord@tep.com",
            Created = DateTime.Now,
            Language = "sv"
          },
          new User
          {
            Id = 2,
            PublicId = new Guid("39d044e3-6936-4c18-85d0-9d0b1ed5164e"),
            SubscriptionId = 2,
            FileId = 16,
            Username = "andersand",
            Email = "anders@anders.and",
            Created = DateTime.Now,
            Language = "sv"
          },
          new User
          {
            Id = 3,
            PublicId = new Guid("6b4282b6-3014-40cd-9de3-a3f29f10bb31"),
            SubscriptionId = 3,
            FileId = 17,
            Username = "ludde",
            Email = "lud@wig.se",
            Created = DateTime.Now,
            Language = "sv"
          },
          new User
          {
            Id = 4,
            PublicId = new Guid("857ce515-b7dd-4eae-991b-20468cf33ec3"),
            SubscriptionId = 4,
            FileId = 18,
            Username = "sillynilly",
            Email = "niclas@hej.hopp",
            Created = DateTime.Now,
            Language = "sv"
          },
          new User
          {
            Id = 5,
            PublicId = new Guid("820d9ee1-573e-4c4b-aeec-b077a793e26f"),
            SubscriptionId = 5,
            FileId = 19,
            Username = "linkanboy",
            Email = "li@n.us",
            Created = DateTime.Now,
            Language = "sv"
          },
          new User
          {
            Id = 6,
            PublicId = new Guid("939dbb39-9250-43c7-b1d5-fe879ccf4167"),
            SubscriptionId = 6,
            FileId = 20,
            Username = "kallebanan",
            Email = "kalle@banan.se",
            Created = DateTime.Now,
            Language = "sv"
          }
        };
    }
  }
}
