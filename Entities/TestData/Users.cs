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
            SubscriptionId = 1,
            FileId = 124,
            CoverPhotoFileId = 62,
            Username = "jimpa",
            Email = "jimmy@boulder.se",
            Created = new DateTime(2021, 02, 22, 09, 00, 12),
            Language = "sv"
          },
          new User
          {
            Id = 2,
            SubscriptionId = 2,
            FileId = 144,
            CoverPhotoFileId = 6,
            Username = "andersand",
            Email = "anders@boulder.se",
            Created = new DateTime(2021, 02, 22, 13, 07, 48),
            Language = "sv"
          },
          new User
          {
            Id = 3,
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
            SubscriptionId = 4,
            FileId = 34,
            CoverPhotoFileId = 91,
            Username = "sillynilly",
            Email = "niclas@boulder.se",
            Created = new DateTime(2020, 05, 28, 20, 32, 10),
            Language = "sv"
          },
          new User
          {
            Id = 5,
            SubscriptionId = 5,
            FileId = 139,
            CoverPhotoFileId = 116,
            Username = "linus",
            Email = "linus@boulder.se",
            Created = new DateTime(2020, 09, 12, 23, 55, 48),
            Language = "sv"
          },
          new User
          {
            Id = 6,
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
            SubscriptionId = 7,
            FileId = 149,
            CoverPhotoFileId = 28,
            Username = "lenagranris",
            Email = "lena@granris.se",
            Created = new DateTime(2021, 02, 21, 01, 00, 49),
            Language = "sv"
          },
          new User
          {
            Id = 8,
            SubscriptionId = 8,
            FileId = 39,
            CoverPhotoFileId = 94,
            Username = "leonardo",
            Email = "leonardo.da.vinci@louvre.fr",
            Created = new DateTime(2021, 01, 18, 17, 05, 42),
            Language = "sv"
          },
          new User
          {
            Id = 9,
            SubscriptionId = 9,
            FileId = 98,
            CoverPhotoFileId = 9,
            Username = "vangogh",
            Email = "vincent@vangogh.nl",
            Created = new DateTime(2021, 03, 20, 10, 01, 22),
            Language = "sv"
          },
          new User
          {
            Id = 10,
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
            SubscriptionId = 11,
            FileId = 64,
            CoverPhotoFileId = 25,
            Username = "glenna",
            Email = "glennaeilidh@gemajl.com",
            Created = new DateTime(2021, 01, 07, 18, 22, 03),
            Language = "sv"
          },
          new User
          {
            Id = 12,
            SubscriptionId = 12,
            FileId = 33,
            CoverPhotoFileId = 58,
            Username = "maggan",
            Email = "maggan827@hawtmajl.com",
            Created = new DateTime(2021, 01, 20, 18, 01, 48),
            Language = "sv"
          },
          new User
          {
            Id = 13,
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
            SubscriptionId = 15,
            FileId = 120,
            CoverPhotoFileId = 78,
            Username = "elenafromstpete",
            Email = "elena@paint.ru",
            Created = new DateTime(2021, 01, 13, 15, 35, 19),
            Language = "sv"
          },
          new User
          {
            Id = 16,
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
            SubscriptionId = 17,
            FileId = 15,
            Username = "picasso",
            Email = "pablo.r.picasso@vetintevadenmejlar.com",
            Created = new DateTime(2021, 02, 18, 16, 45, 55),
            Language = "sv"
          },
          new User
          {
            Id = 18,
            SubscriptionId = 18,
            FileId = 37,
            Username = "photographer22",
            Email = "uloui@geemaiiil.com",
            Created = new DateTime(2021, 01, 01, 12, 51, 05),
            Language = "sv"
          },
          new User
          {
            Id = 19,
            SubscriptionId = 19,
            FileId = 158,
            Username = "therealmonet",
            Email = "claude@monet.com",
            Created = new DateTime(2021, 05, 01, 18, 01, 05),
            Language = "sv"
          },
          new User
          {
            Id = 20,
            SubscriptionId = 20,
            FileId = 157,
            Username = "henrimatisse",
            Email = "henrimatisse@mail.com",
            Created = new DateTime(2021, 04, 28, 06, 40, 25),
            Language = "sv"
          },
          new User
          {
            Id = 21,
            SubscriptionId = 21,
            FileId = 153,
            Username = "salvadordali",
            Email = "salvadordali@geemaiiil.com",
            Created = new DateTime(2021, 04, 27, 18, 01, 51),
            Language = "sv"
          },
          new User
          {
            Id = 22,
            SubscriptionId = 22,
            FileId = 160,
            Username = "michelangelo",
            Email = "michelangelo@mejl.com",
            Created = new DateTime(2021, 04, 08, 14, 21, 46),
            Language = "sv"
          },
          new User
          {
            Id = 23,
            SubscriptionId = 23,
            FileId = 154,
            Username = "rembrandt",
            Email = "rembrandt@rembrandt.com",
            Created = new DateTime(2021, 05, 02, 08, 11, 11),
            Language = "sv"
          },
          new User
          {
            Id = 24,
            SubscriptionId = 24,
            FileId = 155,
            Username = "munch",
            Email = "edvard@munch.com",
            Created = new DateTime(2021, 03, 30, 14, 47, 14),
            Language = "sv"
          },
          new User
          {
            Id = 25,
            SubscriptionId = 25,
            FileId = 156,
            Username = "carllarsson",
            Email = "kontakt@carllarsson.se",
            Created = new DateTime(2021, 04, 18, 19, 12, 25),
            Language = "sv"
          },
          new User
          {
            Id = 26,
            SubscriptionId = 26,
            FileId = 159,
            Username = "anderszorn",
            Email = "anders@zorn.se",
            Created = new DateTime(2021, 04, 19, 17, 00, 01),
            Language = "sv"
          },
          new User
          {
            Id = 27,
            SubscriptionId = 27,
            Username = "anneli",
            Email = "annelifrisk@artportable.com",
            Created = new DateTime(2021, 06, 02, 11, 50, 01),
            Language = "sv"
          },
          new User
          {
            Id = 28,
            SubscriptionId = 28,
            Username = "michael",
            Email = "michaelnilssonstrom@artportable.com",
            Created = new DateTime(2021, 06, 02, 11, 50, 01),
            Language = "sv"
          },
          new User
          {
            Id = 29,
            SubscriptionId = 29,
            Username = "khrystyna",
            Email = "khrystynabarabanova@artportable.com",
            Created = new DateTime(2021, 06, 02, 11, 50, 01),
            Language = "sv"
          },
          new User
          {
            Id = 30,
            SubscriptionId = 30,
            Username = "maria",
            Email = "mariasegerstrom@artportable.com",
            Created = new DateTime(2021, 06, 02, 11, 50, 01),
            Language = "sv"
          },
          new User
          {
            Id = 31,
            SubscriptionId = 31,
            Username = "rene",
            Email = "renejacobsen@artportable.com",
            Created = new DateTime(2021, 06, 02, 11, 50, 01),
            Language = "sv"
          },
          new User
          {
            Id = 32,
            SubscriptionId = 32,
            Username = "malin",
            Email = "malinlofberg@lofberg.com",
            Created = new DateTime(2021, 06, 02, 11, 50, 01),
            Language = "sv"
          },
          new User
          {
            Id = 33,
            SubscriptionId = 33,
            Username = "hasse",
            Email = "hansmolndahl@lofberg.com",
            Created = new DateTime(2021, 06, 02, 11, 50, 01),
            Language = "sv"
          },
          new User
          {
            Id = 34,
            SubscriptionId = 34,
            FileId = 724,
            Username = "natalia",
            Email = "nataliajoannabieganska@artportable.com",
            Created = new DateTime(2021, 06, 02, 11, 50, 01),
            Language = "sv"
          }
        };
    }
  }
}
