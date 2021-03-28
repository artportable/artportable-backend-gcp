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
            FileId = 124,
            Username = "jimpa",
            Email = "jimmy@boulder.se",
            Created = new DateTime(2021, 02, 22, 09, 00, 12),
            Language = "sv"
          },
          new User
          {
            Id = 2,
            PublicId = new Guid("39d044e3-6936-4c18-85d0-9d0b1ed5164e"),
            SubscriptionId = 2,
            FileId = 144,
            Username = "andersand",
            Email = "anders@boulder.se",
            Created = new DateTime(2021, 02, 22, 13, 07, 48),
            Language = "sv"
          },
          new User
          {
            Id = 3,
            PublicId = new Guid("6b4282b6-3014-40cd-9de3-a3f29f10bb31"),
            SubscriptionId = 3,
            FileId = 40,
            Username = "ludde",
            Email = "ludwig@boulder.se",
            Created = new DateTime(2020, 04, 17, 17, 15, 15),
            Language = "sv"
          },
          new User
          {
            Id = 4,
            PublicId = new Guid("857ce515-b7dd-4eae-991b-20468cf33ec3"),
            SubscriptionId = 4,
            FileId = 34,
            Username = "sillynilly",
            Email = "niclas@boulder.se",
            Created = new DateTime(2020, 05, 28, 20, 32, 10),
            Language = "sv"
          },
          new User
          {
            Id = 5,
            PublicId = new Guid("820d9ee1-573e-4c4b-aeec-b077a793e26f"),
            SubscriptionId = 5,
            FileId = 139,
            Username = "linus",
            Email = "linus@boulder.se",
            Created = new DateTime(2020, 09, 12, 23, 55, 48),
            Language = "sv"
          },
          new User
          {
            Id = 6,
            PublicId = new Guid("939dbb39-9250-43c7-b1d5-fe879ccf4167"),
            SubscriptionId = 6,
            FileId = 63,
            Username = "svennebanan",
            Email = "svenne@engammalteliamejl.se",
            Created = new DateTime(2021, 03, 26, 11, 00, 51),
            Language = "sv"
          },
          new User
          {
            Id = 7,
            PublicId = new Guid("0dfa4504-7369-4669-ba26-aa390161d573"),
            SubscriptionId = 7,
            FileId = 149,
            Username = "lenagranris",
            Email = "lena@granris.se",
            Created = new DateTime(2021, 02, 21, 01, 00, 49),
            Language = "sv"
          },
          new User
          {
            Id = 8,
            PublicId = new Guid("e35a7bc6-3d87-4fd4-a954-d6aa7cd4f33e"),
            SubscriptionId = 8,
            FileId = 39,
            Username = "leonardo",
            Email = "leonardo.da.vinci@louvre.fr",
            Created = new DateTime(2021, 01, 18, 17, 05, 42),
            Language = "sv"
          },
          new User
          {
            Id = 9,
            PublicId = new Guid("6c8f43b4-bd72-40f5-a0cd-0b2c386f02d0"),
            SubscriptionId = 9,
            FileId = 98,
            Username = "vangogh",
            Email = "vincent@vangogh.nl",
            Created = new DateTime(2021, 03, 20, 10, 01, 22),
            Language = "sv"
          },
          new User
          {
            Id = 10,
            PublicId = new Guid("7594fde4-2e74-4d4f-a60a-548be2d09460"),
            SubscriptionId = 10,
            FileId = 49,
            Username = "konstnarssjal",
            Email = "alva@konstnarerna.no",
            Created = new DateTime(2021, 01, 30, 07, 21, 09),
            Language = "sv"
          },
          new User
          {
            Id = 11,
            PublicId = new Guid("60f8ba1d-7468-45f3-876e-add0809fc760"),
            SubscriptionId = 11,
            FileId = 64,
            Username = "glenna",
            Email = "glennaeilidh@gemajl.com",
            Created = new DateTime(2021, 01, 07, 18, 22, 03),
            Language = "sv"
          },
          new User
          {
            Id = 12,
            PublicId = new Guid("eef3bbe3-5b1d-4c03-88a2-1b1c42acaf5d"),
            SubscriptionId = 12,
            FileId = 33,
            Username = "maggan",
            Email = "maggan827@hawtmajl.com",
            Created = new DateTime(2021, 01, 20, 18, 01, 48),
            Language = "sv"
          },
          new User
          {
            Id = 13,
            PublicId = new Guid("fb54dbb3-c885-4fbb-9f78-77cdfe89855e"),
            SubscriptionId = 13,
            FileId = 82,
            Username = "vilhelminah",
            Email = "vhenrika@växjsöskola.se",
            Created = new DateTime(2021, 02, 27, 23, 05, 28),
            Language = "sv"
          },
          new User
          {
            Id = 14,
            PublicId = new Guid("80a2bdc3-ba99-4f1c-a6bd-8c31ea1f02c9"),
            SubscriptionId = 14,
            FileId = 55,
            Username = "kaja",
            Email = "kaja@juditskonst.se",
            Created = new DateTime(2021, 03, 05, 14, 37, 21),
            Language = "sv"
          },
          new User
          {
            Id = 15,
            PublicId = new Guid("c29ebbf0-ebdd-4f96-952c-6ab96e888f1e"),
            SubscriptionId = 15,
            FileId = 120,
            Username = "elenafromstpete",
            Email = "elena@paint.ru",
            Created = new DateTime(2021, 01, 13, 15, 35, 19),
            Language = "sv"
          },
          new User
          {
            Id = 16,
            PublicId = new Guid("182fa258-53c2-4000-8f6e-581c69caf561"),
            SubscriptionId = 16,
            FileId = 140,
            Username = "cartoonguy",
            Email = "hello@cartoonguy.com",
            Created = new DateTime(2021, 02, 18, 16, 45, 55),
            Language = "sv"
          },
          new User
          {
            Id = 17,
            PublicId = new Guid("3df14e7f-7e10-4bb3-b8b4-095cac8ec778"),
            SubscriptionId = 17,
            FileId = 106,
            Username = "picasso",
            Email = "pablo.r.picasso@vetintevadenmejlar.com",
            Created = new DateTime(2021, 02, 18, 16, 45, 55),
            Language = "sv"
          },
          new User
          {
            Id = 18,
            PublicId = new Guid("906a84cf-6b4e-43e9-ab10-fdc6c2d63c7a"),
            SubscriptionId = 18,
            FileId = 37,
            Username = "photographer22",
            Email = "uloui@geemaiiil.com",
            Created = new DateTime(2021, 01, 01, 12, 51, 05),
            Language = "sv"
          }
        };
    }
  }
}
