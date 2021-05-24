using System;
using Artportable.API.Entities.Models;
using Artportable.API.Testing;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Entities
{
  public class APContext : DbContext
  {
    Data _testData;

    public APContext(DbContextOptions<APContext> options)
      : base(options)
    {
      _testData = new Data();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Connection> Connections { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }

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
        .HasForeignKey(l => l.ArtworkId)
        .OnDelete(DeleteBehavior.Restrict);
      
      modelBuilder.Entity<Like>()
        .HasOne(l => l.User)
        .WithMany(u => u.Likes)
        .HasForeignKey(l => l.UserId)
        .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<Connection>()
        .HasOne(c => c.Follower)
        .WithMany(u => u.FollowerRef)
        .HasForeignKey(c => c.FollowerId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Restrict);
      modelBuilder.Entity<Connection>()
        .HasOne(c => c.Followee)
        .WithMany(u => u.FolloweeRef)
        .HasForeignKey(c => c.FolloweeId)
        .IsRequired()
        .OnDelete(DeleteBehavior.Restrict);

      // Seed the database with test data
      if (true)
      {
        modelBuilder.Entity<File>().HasData(_testData.Files);
        modelBuilder.Entity<User>().HasData(_testData.Users);
        modelBuilder.Entity<UserProfile>().HasData(_testData.UserProfiles);
        modelBuilder.Entity<Product>().HasData(_testData.Products);
        modelBuilder.Entity<Subscription>().HasData(_testData.Subscriptions);
        modelBuilder.Entity<Artwork>().HasData(_testData.Artworks);
        modelBuilder.Entity<Tag>().HasData(_testData.Tags);
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
