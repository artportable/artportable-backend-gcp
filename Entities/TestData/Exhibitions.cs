using System;
using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Exhibition[] Exhibitions
    {
      get =>
        new Exhibition[]
        {
          new Exhibition
          {
            Id = 1,
            Name = "Skogens konung",
            Place = "Ovalvägen 32, Göteborg",
            From = new DateTime(2021, 01, 28),
            To = new DateTime(2021, 01, 30),
            UserProfileId = 1
          },
          new Exhibition
          {
            Id = 2,
            Name = "Utställning",
            Place = "Valhallavägen 171, Stockholm",
            From = new DateTime(2021, 06, 20),
            To = new DateTime(2021, 06, 25),
            UserProfileId = 2
          },
          new Exhibition
          {
            Id = 3,
            Name = "Växjös historia",
            Place = "Växjö Bibliotek, Storgatan 8, Växjö",
            From = new DateTime(2021, 05, 01),
            To = new DateTime(2021, 05, 30),
            UserProfileId = 13
          },
          new Exhibition
          {
            Id = 4,
            Name = "Skrattande hästen",
            Place = "S:t Eriksplan 89, Stockholm",
            From = new DateTime(2021, 04, 01),
            To = new DateTime(2021, 06, 18),
            UserProfileId = 1
          },
          new Exhibition
          {
            Id = 5,
            Name = "Mina livsverk",
            Place = "Picassomuséet, Av Jules Grec 201, Antibes France",
            From = new DateTime(2021, 01, 01),
            To = new DateTime(2021, 12, 31),
            UserProfileId = 17
          },
          new Exhibition
          {
            Id = 6,
            Name = "Fårahage",
            Place = "Folketshusgatan 12, Östersund",
            From = new DateTime(2021, 03, 02),
            To = new DateTime(2021, 06, 08),
            UserProfileId = 7
          },
          new Exhibition
          {
            Id = 7,
            Name = "Exotiska djur",
            Place = "Min ataljé på Bagaregatan 20, Nynäshamn",
            From = new DateTime(2021, 04, 01),
            To = new DateTime(2021, 04, 30),
            UserProfileId = 4
          },
          new Exhibition
          {
            Id = 8,
            Name = "Garageutställning",
            Place = "Hemma hos mig i Kramfors",
            From = new DateTime(2021, 07, 04),
            To = new DateTime(2021, 08, 15),
            UserProfileId = 11
          },
          new Exhibition
          {
            Id = 9,
            Name = "Utställning av mina porträtt",
            Place = "Lysekilsv. 8, Göteborg",
            From = new DateTime(2021, 08, 01),
            To = new DateTime(2021, 10, 12),
            UserProfileId = 14
          },
          new Exhibition
          {
            Id = 10,
            Name = "Utställning",
            Place = "Källaren på Skillingagatan 8",
            From = new DateTime(2021, 04, 19),
            To = new DateTime(2021, 06, 02),
            UserProfileId = 16
          },
          new Exhibition
          {
            Id = 11,
            Name = "Bourbon i highball",
            Place = "S:t Eriksplan 89, Stockholm",
            From = new DateTime(2021, 09, 02),
            To = new DateTime(2021, 11, 21),
            UserProfileId = 1
          },
          new Exhibition
          {
            Id = 12,
            Name = "Utställning",
            Place = "Folketshusgatan 12, Östersund",
            From = new DateTime(2021, 06, 08),
            To = new DateTime(2021, 08, 16),
            UserProfileId = 7
          },
          new Exhibition
          {
            Id = 13,
            Name = "Fotoutställning",
            Place = "Äppleknyckarvägen 46, Mariestad",
            From = new DateTime(2021, 06, 08),
            To = new DateTime(2021, 08, 16),
            UserProfileId = 18
          },
          new Exhibition
          {
            Id = 14,
            Name = "Utställning",
            Place = "Amsterdam, Nederländerna",
            From = new DateTime(2021, 05, 08),
            To = new DateTime(2021, 10, 22),
            UserProfileId = 9
          },
          new Exhibition
          {
            Id = 15,
            Name = "Skördefesten på Öland",
            Place = "Galleri Lilla Eden i Eriksöre",
            From = new DateTime(2021, 08, 08),
            To = new DateTime(2021, 08, 16),
            UserProfileId = 27
          },
          new Exhibition
          {
            Id = 16,
            Name = "Society of Botanical Artists årliga utställning",
            Place = "SBA Plantae 2021",
            From = new DateTime(2021, 09, 03),
            To = new DateTime(2021, 09, 22),
            UserProfileId = 27
          }
        };
    }
  }
}
