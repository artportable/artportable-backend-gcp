using System;
using Artportable.API.Entities.Models;

namespace Artportable.API.Testing
{
  public partial class Data
  {
    public Artwork[] Artworks
    {
      get =>
        new Artwork[]
        {
          new Artwork()
          {
            Id = 1,
            PublicId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
            UserId = 2,
            PrimaryFileId = 1,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 2,
            PublicId = new Guid("1efe7a31-8dcc-4ff0-9b2d-5f148e2989cc"),
            UserId = 2,
            PrimaryFileId = 2,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 3,
            PublicId = new Guid("b24e3df5-0394-468d-9c1d-db1252fea920"),
            UserId = 2,
            PrimaryFileId = 3,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 4,
            PublicId = new Guid("9f35e705-637a-4bbe-8c35-402b2ecf7128"),
            UserId = 3,
            PrimaryFileId = 4,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 5,
            PublicId = new Guid("939df3fd-de57-4caf-96dc-c5e110322a96"),
            UserId = 3,
            PrimaryFileId = 5,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 6,
            PublicId = new Guid("d70f656d-75a7-45fc-b385-e4daa834e6a8"),
            UserId = 3,
            PrimaryFileId = 6,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 7,
            PublicId = new Guid("ce1d2b1c-7869-4df5-9a32-2cbaca8c3234"),
            UserId = 3,
            PrimaryFileId = 7,
            Title = "An Artwork by Frank",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 8,
            PublicId = new Guid("2645bd94-3624-43fc-b21f-1209d730fc71"),
            UserId = 6,
            PrimaryFileId = 8,
            Title = "An Artwork by Claire",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 9,
            PublicId = new Guid("3f41dc87-e8de-42ee-ac8d-355e4d3e1a2d"),
            UserId = 2,
            PrimaryFileId = 9,
            Title = "An Artwork by Claire",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 10,
            PublicId = new Guid("d3118665-43e3-4905-8848-5e335a428dd5"),
            UserId = 3,
            PrimaryFileId = 10,
            SecondaryFileId = 11,
            Title = "An Artwork by Claire",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          },
          new Artwork()
          {
            Id = 11,
            PublicId = new Guid("136f358d-98fb-4961-855c-59d5a6d1fa19"),
            UserId = 6,
            PrimaryFileId = 12,
            SecondaryFileId = 13,
            TertiaryFileId = 14,
            Title = "An Artwork by Claire",
            Description = "A delicious piece of art",
            Published = DateTime.Now
          }
        };
    }
  }
}
