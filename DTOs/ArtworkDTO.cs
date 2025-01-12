using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
    public class ArtworkDTO
    {
        public Guid Id { get; set; }
        public OwnerDTO Owner { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Published { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public bool SoldOut { get; set; }
        public bool MultipleSizes { get; set; }
        public bool CuratedImage { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? Depth { get; set; }
        public FileDTO PrimaryFile { get; set; }
        public FileDTO SecondaryFile { get; set; }
        public FileDTO TertiaryFile { get; set; }
        public List<string> Tags { get; set; }
        public int Likes { get; set; }
        public bool LikedByMe { get; set; }

        public int? OrderIndex { get; set; }
        public bool? Promoted { get; set; }

        public DateTime? PromotedAt { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public bool? FrameIncluded { get; set; }
        public string SignedByArtist { get; set; }
        public bool? IsBoosted { get; set; }
        public DateTime? BoostedAt { get; set; }
        public bool? isAaf { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
    }
}
