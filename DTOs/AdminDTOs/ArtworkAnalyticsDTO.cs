using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
    public class AdminArtworkAnalyticsDTO
    {
        public int TotalArtworkViews { get; set; }
        public int ArtworkViewsToday { get; set; }
        public int ArtworkViewsThisWeek { get; set; }
        public int ArtworkViewsThisMonth { get; set; }
        public int TotalArtworks { get; set; }
        public int TotalArtworksWithViews { get; set; }
        public decimal AverageViewsPerArtwork { get; set; }
        public List<TopArtworkDTO> TopArtworks { get; set; }
        public List<DailyArtworkActivityDTO> DailyArtworkActivity { get; set; }
        public List<ArtworkCategoryDTO> ArtworkCategories { get; set; }
    }

    public class TopArtworkDTO
    {
        public string ArtworkId { get; set; }
        public string ArtworkTitle { get; set; }
        public string ArtistUsername { get; set; }
        public int TotalViews { get; set; }
        public int ViewsToday { get; set; }
        public int ViewsThisWeek { get; set; }
        public int ViewsThisMonth { get; set; }
        public decimal GrowthRate { get; set; } // Week over week growth
        public string TrendDirection { get; set; } // "up", "down", "stable", "new"
    }

    public class DailyArtworkActivityDTO
    {
        public string Date { get; set; }
        public int Views { get; set; }
        public int UniqueArtworks { get; set; }
        public int UniqueSessions { get; set; }
    }

    public class ArtworkCategoryDTO
    {
        public string Category { get; set; }
        public int ArtworkCount { get; set; }
        public int Views { get; set; }
        public decimal AverageViewsPerArtwork { get; set; }
    }
} 