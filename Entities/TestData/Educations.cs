using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Education[] Educations
    {
      get =>
        new Education[]
        {
          new Education
          {
            Id = 1,
            Name = "Penslar 101 vid Konsthögskolan i Wien",
            From = 2001,
            To = 2003,
            UserProfileId = 1
          },
          new Education
          {
            Id = 2,
            Name = "Färg och form vid Universitetet i Milano",
            From = 2020,
            To = 2021,
            UserProfileId = 2
          },
          new Education
          {
            Id = 3,
            Name = "Formgivning vid Helsingfors Universitet",
            From = 1990,
            To = 1994,
            UserProfileId = 13
          },
          new Education
          {
            Id = 4,
            Name = "Grundkurs i akvarellmålning",
            From = 2008,
            To = 2009,
            UserProfileId = 5
          },
          new Education
          {
            Id = 5,
            Name = "Målarkurs på Pernbys målarskola",
            From = 2009,
            To = 2009,
            UserProfileId = 2
          },
          new Education
          {
            Id = 6,
            Name = "Konstfack",
            From = 2010,
            To = 2012,
            UserProfileId = 1
          },
          new Education
          {
            Id = 7,
            Name = "Le faque de qounste",
            From = 2012,
            To = 2014,
            UserProfileId = 17
          },
          new Education
          {
            Id = 8,
            Name = "Da Vinci-universitetet",
            From = 1987,
            To = 1990,
            UserProfileId = 15
          },
          new Education
          {
            Id = 9,
            Name = "Konstutbildning, Louvren",
            From = 1997,
            To = 2001,
            UserProfileId = 15
          },
          new Education
          {
            Id = 10,
            Name = "Onlinekurs i penselteknik vid Konstskolan i Stockholm",
            From = 2009,
            To = 2012,
            UserProfileId = 7
          },
          new Education
          {
            Id = 11,
            Name = "Färg och form vid Livets hårda konstskola",
            From = 2017,
            To = 2022,
            UserProfileId = 6
          },
          new Education
          {
            Id = 12,
            Name = "Grafisk formgivning och illustration vid Konstskolan i Stockholm",
            From = 2003,
            To = 2003,
            UserProfileId = 13
          },
          new Education
          {
            Id = 13,
            Name = "Industridesign på Konstskolan Linnea",
            From = 2021,
            To = 2021,
            UserProfileId = 1
          },
          new Education
          {
            Id = 14,
            Name = "Inredningsarkitektur och möbeldesign vid Göteborgs konstskola",
            From = 2020,
            To = 2020,
            UserProfileId = 11
          },
          new Education
          {
            Id = 15,
            Name = "Keramik och glas vid Konstskolan i Stockholm",
            From = 2018,
            To = 2019,
            UserProfileId = 11
          },
          new Education
          {
            Id = 16,
            Name = "Grafisk industridesign vid Sigtuna Folkhögskola",
            From = 1996,
            To = 1996,
            UserProfileId = 13
          },
          new Education
          {
            Id = 17,
            Name = "Konstnärlig grundutbildning vid Göteborgs konstskola",
            From = 2005,
            To = 2008,
            UserProfileId = 4
          },
          new Education
          {
            Id = 18,
            Name = "Projektkonst vid Konstskolan i Stockholm",
            From = 2011,
            To = 2012,
            UserProfileId = 10
          },
          new Education
          {
            Id = 19,
            Name = "Informativ illustration, Society of Botanical Artists UK Diploma Course",
            From = 2011,
            To = 2012,
            UserProfileId = 27
          }
        };
    }
  }
}
