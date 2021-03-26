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
            DateOfBirth = new DateTime(1999, 01, 01),
            Location = "Cyber space",
            Title = "Artist",
            Headline = "Ambitious artist inspired by the flow of the nature"
          },
          new UserProfile
          {
            Id = 2,
            UserId = 2,
            Name = "Anders",
            Surname = "Rose",
            DateOfBirth = new DateTime(1999, 01, 01),
            Location = "Stockholm, Sweden",
            Title = "Artist",
            Headline = "Ambitious artist inspired by the flow of the nature"
          },
          new UserProfile
          {
            Id = 3,
            UserId = 3,
            Name = "Ludwig",
            Surname = "Slotte",
            DateOfBirth = new DateTime(1999, 01, 01),
            Location = "Vemdalen, Sweden",
            Title = "Artist",
            Headline = "Ambitious artist inspired by the flow of the nature"
          },
          new UserProfile
          {
            Id = 4,
            UserId = 4,
            Name = "Niclas",
            Surname = "Kamlind",
            DateOfBirth = new DateTime(1999, 01, 01),
            Location = "Stockholm, Sweden",
            Title = "Head of Gitslack",
            Headline = "Ambitious artist inspired by Gitting and slacking"
          },
          new UserProfile
          {
            Id = 5,
            UserId = 5,
            Name = "Linus",
            Surname = "Linus",
            DateOfBirth = new DateTime(1999, 01, 01),
            Location = "Stockholm, Sweden",
            Title = "Artist",
            Headline = "Ambitious artist inspired by the flow of the nature"
          },
          new UserProfile
          {
            Id = 6,
            UserId = 6,
            Name = "Kalle",
            Surname = "Banan",
            DateOfBirth = new DateTime(1999, 01, 01),
            Location = "Kalleland",
            Title = "Artist",
            Headline = "Ambitious artist inspired by the flow of the nature"
          }
        };
    }
  }
}
