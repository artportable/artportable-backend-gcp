using System;
using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public UserProfile[] UserProfiles
    {
      get =>
        new UserProfile[]
        {
          new UserProfile
          {
            Id = 1,
            UserId = 1,
            Name = "Jimmy",
            Surname = "Lord",
            DateOfBirth = new DateTime(2002, 01, 11),
            Location = "Vallentuna",
            Title = "Konstnär",
            Headline = "Inspirerad av naturens krafter, målar gärna skog",
            InspiredBy = "Långa månskenspromenader",
            Website = "jimmylord.com",
            InstagramUrl = "www.instagram.com/jimmy",
            FacebookUrl = "www.facebook.com/jimmy",
            BehanceUrl = "www.behance.net/jimmy",
            DribbleUrl = "www.dribble.com/jimmy",
            LinkedInUrl = "www.linkedin.com/jimmy"
          },
          new UserProfile
          {
            Id = 2,
            UserId = 2,
            Name = "Anders",
            Surname = "Rosen",
            DateOfBirth = new DateTime(1990, 02, 12),
            Location = "Bromölla",
            Title = "Konstintresserad",
            Headline = "Intresserad av historiska personer och fruktskålar",
            InspiredBy = "Frukt, historiska personer och god mat",
            Website = "www.andersmålarstudio.se"
          },
          new UserProfile
          {
            Id = 3,
            UserId = 3,
            Name = "Ludwig",
            Surname = "Slotte",
            DateOfBirth = new DateTime(1964, 03, 23),
            Location = "Vemdalen",
            Title = "Konstintresserad",
            Headline = "Ny i konstens värld och nyfiken på utbudet"
          },
          new UserProfile
          {
            Id = 4,
            UserId = 4,
            Name = "Niclas",
            Surname = "Kamlind",
            DateOfBirth = new DateTime(1989, 05, 09),
            Location = "Sollentuna",
            Title = "Konstnär",
            Headline = "Ambitös och kreativ konstnär som målar på heltid",
            InspiredBy = "Världen runt omkring mig",
            Website = "niclasbod.se"
          },
          new UserProfile
          {
            Id = 5,
            UserId = 5,
            Name = "Linus",
            Surname = "Linus",
            DateOfBirth = new DateTime(1972, 11, 06),
            Location = "Stockholm",
            Title = "Konstintresserad",
            Headline = "Jag har kollat på tavlor sen -92"
          },
          new UserProfile
          {
            Id = 6,
            UserId = 6,
            Name = "Svenne",
            Surname = "Banan",
            DateOfBirth = new DateTime(1981, 09, 15),
            Location = "Västerås",
            Title = "Hobbykonstnär",
            Headline = "Kan allt om konst",
            InspiredBy = "Allt och inget"
          },
          new UserProfile
          {
            Id = 7,
            UserId = 7,
            Name = "Lena",
            Surname = "Granris",
            DateOfBirth = new DateTime(1953, 06, 20),
            Location = "Öland",
            Title = "Konstköpare",
            Headline = "Älskar allt som har med konst att göra",
            InspiredBy = "Historisk ariktektur"
          },
          new UserProfile
          {
            Id = 8,
            UserId = 8,
            Name = "Leonardo",
            Surname = "da Vinci",
            DateOfBirth = new DateTime(1452, 04, 15),
            Location = "Florens",
            Title = "Konstnär",
            Headline = "Målar porträtt av människor med dubbel-namn och sånt",
            InspiredBy = "Människor",
            InstagramUrl = "www.instagram.com/leonardo_vinci",
            FacebookUrl = "www.facebook.com/leonardo.da.vinci"
          },
          new UserProfile
          {
            Id = 9,
            UserId = 9,
            Name = "Vincent",
            Surname = "van Gogh",
            DateOfBirth = new DateTime(1853, 03, 10),
            Location = "Holland",
            Title = "Konstnär",
            Headline = "Gillar långa månskenspromenader, oljemålning och absinth",
            InspiredBy = "Tulpaner, träskor och målarfärg"
          },
          new UserProfile
          {
            Id = 10,
            UserId = 10,
            Name = "Alva",
            Surname = "Arnbjørg",
            DateOfBirth = new DateTime(1993, 04, 02),
            Location = "Oslo",
            Headline = "Kreativ konstnärssjäl med sinne för färg och form",
            BehanceUrl = "www.behance.net/alva"
          },
          new UserProfile
          {
            Id = 11,
            UserId = 11,
            Name = "Glenna",
            Surname = "Eilidh",
            DateOfBirth = new DateTime(1994, 12, 06),
            Location = "Kramfors",
            Title = "Målare & kock",
            Headline = "Matglad tjej som gärna målar djur",
            InspiredBy = "Alla sorters mat men främst italiensk"
          },
          new UserProfile
          {
            Id = 12,
            UserId = 12,
            Name = "Maggan",
            Surname = "Karlsson",
            DateOfBirth = new DateTime(1959, 12, 19),
            Location = "Malmö",
            Title = "Intresserad",
            Headline = "Målar lite själv men mest intresserad av andras skapelser",
            InspiredBy = "Hav och klippor",
            Website = "magganmedpenseln.com"
          },
          new UserProfile
          {
            Id = 13,
            UserId = 13,
            Name = "Vilhelmina",
            Surname = "Henrika",
            DateOfBirth = new DateTime(1948, 10, 15),
            Location = "Växjö",
            Title = "Lärare",
            Headline = "Kollar runt lite bara"
          },
          new UserProfile
          {
            Id = 14,
            UserId = 14,
            Name = "Kaja",
            Surname = "Judit",
            DateOfBirth = new DateTime(1986, 08, 29),
            Location = "Göteborg",
            Title = "Konstnär",
            Headline = "Målar portträtt med akvarell och blyerts",
            InspiredBy = "Staden och människorna i rörelse"
          },
          new UserProfile
          {
            Id = 15,
            UserId = 15,
            Name = "Elena",
            Surname = "Yaroslava",
            DateOfBirth = new DateTime(1979, 06, 20),
            Location = "St Petersburg",
            Title = "Konstnär",
            Headline = "Passionerad artist med huvudet mellan himmel och jord",
            DribbleUrl = "www.dribble.com/yaroslava"
          },
          new UserProfile
          {
            Id = 16,
            UserId = 16,
            Name = "Tom-Lennart",
            Surname = "Bernt",
            DateOfBirth = new DateTime(1984, 07, 31),
            Location = "Nacka",
            Title = "Serietecknare",
            Headline = "Tecknar serier",
            Website = "www.tomlennartsserier.se"
          },
          new UserProfile
          {
            Id = 17,
            UserId = 17,
            Name = "Pablo",
            Surname = "Picasso",
            DateOfBirth = new DateTime(1881, 10, 25),
            Location = "Mougins",
            Title = "Konstnär",
            Headline = "Målar rätt mycket"
          },
          new UserProfile
          {
            Id = 18,
            UserId = 18,
            Name = "Urban",
            Surname = "Loui",
            DateOfBirth = new DateTime(1990, 07, 12),
            Location = "Mariestad",
            Title = "Fotograf",
            Headline = "Åker runt i världen och knäpper bilder",
            LinkedInUrl = "linkedin.com/urban.loui861"
          }
        };
    }
  }
}
