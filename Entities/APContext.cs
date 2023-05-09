using System;
using System.Diagnostics.CodeAnalysis;
using Artportable.API.Entities.Models;
using Artportable.API.SeedData;
using Artportable.API.Testing;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Entities
{
  [ExcludeFromCodeCoverage]
  public class APContext : DbContext
  {
    TagData _tagData;
    ProductData _productData;
    Data _testData;

    public APContext(DbContextOptions<APContext> options)
      : base(options)
    {
      _tagData = new TagData();
      _productData = new ProductData();
      _testData = new Data();
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserProfile> UserProfiles { get; set; }
    public virtual DbSet<Subscription> Subscriptions { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<File> Files { get; set; }
    public virtual DbSet<Artwork> Artworks { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Connection> Connections { get; set; }
    public virtual DbSet<Like> Likes { get; set; }
    public virtual DbSet<Education> Educations { get; set; }
    public virtual DbSet<Exhibition> Exhibitions { get; set; }
    public virtual DbSet<Post> Posts { get; set; }

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

      modelBuilder.Entity<Like>()
        .HasOne(l => l.Artwork)
        .WithMany(a => a.Likes)
        .HasForeignKey(l => l.ArtworkId);
      
      modelBuilder.Entity<Like>()
        .HasOne(l => l.User)
        .WithMany(u => u.Likes)
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.ClientCascade);

      modelBuilder.Entity<Connection>()
        .HasOne(c => c.Follower)
        .WithMany(u => u.FollowerRef)
        .HasForeignKey(c => c.FollowerId)
        .OnDelete(DeleteBehavior.ClientCascade)
        .IsRequired();
      modelBuilder.Entity<Connection>()
        .HasOne(c => c.Followee)
        .WithMany(u => u.FolloweeRef)
        .HasForeignKey(c => c.FolloweeId)
        .OnDelete(DeleteBehavior.ClientCascade)
        .IsRequired();

      // Seed database
      modelBuilder.Entity<Tag>().HasData(_tagData.Tags);
      modelBuilder.Entity<Product>().HasData(_productData.Products);


      // Seed the database with test data
      if (false)
      {
        modelBuilder.Entity<File>().HasData(_testData.Files);
        modelBuilder.Entity<User>().HasData(_testData.Users);
        modelBuilder.Entity<UserProfile>().HasData(_testData.UserProfiles);
        modelBuilder.Entity<Subscription>().HasData(_testData.Subscriptions);
        modelBuilder.Entity<Artwork>().HasData(_testData.Artworks);
        modelBuilder.Entity<Connection>().HasData(_testData.Connections);
        modelBuilder.Entity<Like>().HasData(_testData.Likes);
        modelBuilder.Entity<Education>().HasData(_testData.Educations);
        modelBuilder.Entity<Exhibition>().HasData(_testData.Exhibitions);

        // Seed Artwork-Tag associative entity
        modelBuilder.Entity<Artwork>()
          .HasMany(a => a.Tags)
          .WithMany(t => t.Artworks)
          .UsingEntity(j => j.HasData(_testData.ArtworksTags));
      }
    }
  }
}
