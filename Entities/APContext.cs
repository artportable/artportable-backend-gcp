using System;
using Artportable.API.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Entities
{
  public class APContext : DbContext
  {
    public APContext(DbContextOptions<APContext> options)
      : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Connection> Connections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Tables with multiple references to one table
      // must be configured in Fluent
      modelBuilder.Entity<Artwork>()
        .HasOne(a => a.PrimaryFile)
        .WithOne(f => f.PrimaryFileRef)
        .HasForeignKey<Artwork>(a => a.PrimaryFileId);
      modelBuilder.Entity<Artwork>()
        .HasOne(a => a.SecondaryFile)
        .WithOne(f => f.SecondaryFileRef)
        .HasForeignKey<Artwork>(a => a.SecondaryFileId);
      modelBuilder.Entity<Artwork>()
        .HasOne(a => a.TertiaryFile)
        .WithOne(f => f.TertiaryFileRef)
        .HasForeignKey<Artwork>(a => a.TertiaryFileId);

      modelBuilder.Entity<Connection>()
        .HasOne(c => c.Follower)
        .WithMany(u => u.FollowerRef)
        .HasForeignKey(c => c.FollowerId);
      modelBuilder.Entity<Connection>()
        .HasOne(c => c.Followee)
        .WithMany(u => u.FolloweeRef)
        .HasForeignKey(c => c.FolloweeId);

      // Seed the database with test data
      if (true) {
        modelBuilder.Entity<File>().HasData(
          new File()
          {
            Id = 1,
            Name = "3fbe2aea-2257-44f2-b3b1-3d8bacade89c.jpg",
          },
          new File()
          {
            Id = 2,
            Name = "43de8b65-8b19-4b87-ae3c-df97e18bd461.jpg",
          },
          new File()
          {
            Id = 3,
            Name = "46194927-ccda-432f-bc95-4820318c08c7.jpg",
          },
          new File()
          {
            Id = 4,
            Name = "4cdd494c-e6e1-4af1-9e54-24a8e80ea2b4.jpg",
          },
          new File()
          {
            Id = 5,
            Name = "5c20ca95-bb00-4ef1-8b85-c4b11e66eb54.jpg",
          },
          new File()
          {
            Id = 6,
            Name = "6b33c074-65cf-4f2b-913a-1b2d4deb7050.jpg",
          },
          new File()
          {
            Id = 7,
            Name = "7e80a4c8-0a8a-4593-a16f-2e257294a1f9.jpg",
          },
          new File()
          {
            Id = 8,
            Name = "8d351bbb-f760-4b56-9d4e-e8d61619bf70.jpg",
          },
          new File()
          {
            Id = 9,
            Name = "b2894002-0b7c-4f05-896a-856283012c87.jpg",
          },
          new File()
          {
            Id = 10,
            Name = "cc412f08-2a7b-4225-b659-07fdb168302d.jpg",
          },
          new File()
          {
            Id = 11,
            Name = "cd139111-c82e-4bc8-9f7d-43a1059bfe73.jpg",
          },
          new File()
          {
            Id = 12,
            Name = "dc3f39bf-d1da-465d-9ea4-935902c2e3d2.jpg",
          },
          new File()
          {
            Id = 13,
            Name = "e0e32179-109c-4a8a-bf91-3d65ff83ca29.jpg",
          },
          new File()
          {
            Id = 14,
            Name = "fdfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
          },
          new File()
          {
            Id = 94,
            Name = "1dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
          },
          new File()
          {
            Id = 95,
            Name = "2dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
          },
          new File()
          {
            Id = 96,
            Name = "3dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
          },
          new File()
          {
            Id = 97,
            Name = "4dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
          },
          new File()
          {
            Id = 98,
            Name = "5dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
          },
          new File()
          {
            Id = 99,
            Name = "6dfe7329-e05c-41fb-a7c7-4f3226d28c49.jpg",
          }
        );


        modelBuilder.Entity<User>().HasData(
          new User
          {
            Id = 1,
            PublicId = new Guid("b2ca9be2-f852-4d65-9498-c43366996352"),
            SubscriptionId = 1,
            FileId = 94,
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
            FileId = 95,
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
            FileId = 96,
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
            FileId = 97,
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
            FileId = 98,
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
            FileId = 99,
            Username = "kallebanan",
            Email = "kalle@banan.se",
            Created = DateTime.Now,
            Language = "sv"
          }
        );

        modelBuilder.Entity<UserProfile>().HasData(
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
        );

        modelBuilder.Entity<Product>().HasData(
          new Product
          {
            Id = 1,
            Name = "Bas"
          },
          new Product
          {
            Id = 2,
            Name = "Portfolio"
          },
          new Product
          {
            Id = 3,
            Name = "Portfolio Premium"
          }
        );

        modelBuilder.Entity<Subscription>().HasData(
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
        );

        modelBuilder.Entity<Artwork>().HasData(
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
        );

        modelBuilder.Entity<Tag>().HasData(
          new Tag
          {
            Id = 1,
            Title = "oil"
          },
          new Tag
          {
            Id = 2,
            Title = "acrylic"
          },
          new Tag
          {
            Id = 3,
            Title = "forest"
          },
          new Tag
          {
            Id = 4,
            Title = "self-portrait"
          },
          new Tag
          {
            Id = 5,
            Title = "sea"
          },
          new Tag
          {
            Id = 6,
            Title = "fruit"
          }
        );

        modelBuilder.Entity<Connection>().HasData(
          new Connection
          {
            Id = 1,
            FollowerId = 1,
            FolloweeId = 2
          },
          new Connection
          {
            Id = 2,
            FollowerId = 2,
            FolloweeId = 1
          },
          new Connection
          {
            Id = 3,
            FollowerId = 1,
            FolloweeId = 3
          },
          new Connection
          {
            Id = 4,
            FollowerId = 3,
            FolloweeId = 6
          },
          new Connection
          {
            Id = 5,
            FollowerId = 3,
            FolloweeId = 4
          },
          new Connection
          {
            Id = 6,
            FollowerId = 2,
            FolloweeId = 4
          }
        );
      }
    }
  }
}
