using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Artportable.API.Entities.Models
{
  [Index(nameof(Username), IsUnique = true)]
  public class User
  {
    [Key]
    public int Id { get; set; }

    public int SubscriptionId { get; set; }
    public int? FileId { get; set; }
    public int? CoverPhotoFileId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid SocialId { get; set; }
    
    public bool MonthlyUser { get; set; }

    [Required]
    [MaxLength(254)]
    public string Email { get; set; }

    [Required]
    public DateTime Created { get; set; }

    [Required]
    [MaxLength(2)]
    [Comment("According to the ISO 639-1 standard")]
    public string Language { get; set; }

    public UserProfile UserProfile {get; set; }
    public Subscription Subscription { get; set; }
    public File File { get; set; }
    public File CoverPhotoFile { get; set; }
    public ICollection<Artwork> Artworks { get; set; }
    public ICollection<Post> Posts { get; set; } 
    [InverseProperty("Follower")]
    public ICollection<Connection> FollowerRef { get; set; }
    [InverseProperty("Followee")]
    public ICollection<Connection> FolloweeRef { get; set; }
    [InverseProperty("User")]
    public ICollection<Like> Likes { get; set; }
  }
}
