using System;
using System.Collections.Generic;

namespace Artportable.API.DTOs
{
    public class AdminProfileViewAnalyticsDTO
    {
        public int TotalViews { get; set; }
        public int UniqueViewsToday { get; set; }
        public int UniqueViewsThisWeek { get; set; }
        public int UniqueViewsThisMonth { get; set; }
        public int TotalSessions { get; set; }
        public int ActiveArtists { get; set; } // Artists with at least 1 view
        public decimal AverageViewsPerArtist { get; set; }
        public List<TopArtistDTO> TopArtists { get; set; }
        public List<DailyActivityDTO> DailyActivity { get; set; }
        public List<HourlyActivityDTO> HourlyActivity { get; set; }
        public TrafficTrendsDTO TrafficTrends { get; set; }
        public UserBehaviorDTO UserBehavior { get; set; }
    }

    public class TopArtistDTO
    {
        public string Username { get; set; }
        public int TotalViews { get; set; }
        public int UniqueViewsToday { get; set; }
        public int UniqueViewsThisWeek { get; set; }
        public int UniqueViewsThisMonth { get; set; }
        public decimal GrowthRate { get; set; } // Week over week growth
        public string TrendDirection { get; set; } // "up", "down", "stable"
    }

    public class DailyActivityDTO
    {
        public string Date { get; set; }
        public int Views { get; set; }
        public int UniqueSessions { get; set; }
        public int ActiveArtists { get; set; }
    }

    public class HourlyActivityDTO
    {
        public int Hour { get; set; }
        public int Views { get; set; }
        public int UniqueSessions { get; set; }
    }

    public class TrafficTrendsDTO
    {
        public decimal WeekOverWeekGrowth { get; set; }
        public decimal MonthOverMonthGrowth { get; set; }
        public List<WeeklyTrendDTO> WeeklyTrends { get; set; }
        public List<MonthlyTrendDTO> MonthlyTrends { get; set; }
        public BestPerformanceDTO BestDay { get; set; }
        public BestPerformanceDTO BestWeek { get; set; }
        public BestPerformanceDTO BestMonth { get; set; }
    }

    public class WeeklyTrendDTO
    {
        public string WeekStart { get; set; }
        public string WeekEnd { get; set; }
        public int Views { get; set; }
        public int UniqueSessions { get; set; }
        public int ActiveArtists { get; set; }
    }

    public class MonthlyTrendDTO
    {
        public string Month { get; set; }
        public int Year { get; set; }
        public int Views { get; set; }
        public int UniqueSessions { get; set; }
        public int ActiveArtists { get; set; }
    }

    public class BestPerformanceDTO
    {
        public string Period { get; set; }
        public int Views { get; set; }
        public int UniqueSessions { get; set; }
        public int ActiveArtists { get; set; }
    }

    public class UserBehaviorDTO
    {
        public decimal SessionsPerUser { get; set; }
        public decimal ViewsPerSession { get; set; }
        public int ReturnVisitors { get; set; }
        public int NewVisitors { get; set; }
        public decimal ReturnVisitorRate { get; set; }
        public List<SessionDepthDTO> SessionDepths { get; set; }
        public List<GeographicDataDTO> TopCountries { get; set; }
    }

    public class SessionDepthDTO
    {
        public int ViewsCount { get; set; }
        public int SessionsCount { get; set; }
        public decimal Percentage { get; set; }
    }

    public class GeographicDataDTO
    {
        public string Country { get; set; }
        public int Views { get; set; }
        public int UniqueSessions { get; set; }
        public decimal Percentage { get; set; }
    }

    public class ArtistPerformanceDTO
    {
        public string Username { get; set; }
        public int TotalViews { get; set; }
        public int ViewsToday { get; set; }
        public int ViewsThisWeek { get; set; }
        public int ViewsThisMonth { get; set; }
        public decimal WeekOverWeekGrowth { get; set; }
        public decimal MonthOverMonthGrowth { get; set; }
        public string TrendDirection { get; set; }
        public int Rank { get; set; }
        public List<DailyActivityDTO> RecentActivity { get; set; }
    }

    public class PlatformInsightsDTO
    {
        public DiscoveryPatternsDTO DiscoveryPatterns { get; set; }
        public EngagementMetricsDTO EngagementMetrics { get; set; }
        public ArtistGrowthDTO ArtistGrowth { get; set; }
        public ContentPerformanceDTO ContentPerformance { get; set; }
    }

    public class DiscoveryPatternsDTO
    {
        public int ArtistsDiscoveredToday { get; set; }
        public int ArtistsDiscoveredThisWeek { get; set; }
        public decimal AverageDiscoveryRate { get; set; }
        public List<DiscoverySourceDTO> TopDiscoverySources { get; set; }
    }

    public class DiscoverySourceDTO
    {
        public string Source { get; set; }
        public int Count { get; set; }
        public decimal Percentage { get; set; }
    }

    public class EngagementMetricsDTO
    {
        public decimal AverageTimeOnProfile { get; set; }
        public decimal BounceRate { get; set; }
        public int DeepEngagementSessions { get; set; } // 3+ profile views
        public decimal EngagementScore { get; set; }
    }

    public class ArtistGrowthDTO
    {
        public int NewArtistsWithViews { get; set; }
        public int RisingStars { get; set; } // Artists with 100%+ growth
        public decimal AverageGrowthRate { get; set; }
        public List<string> FastestGrowingArtists { get; set; }
    }

    public class ContentPerformanceDTO
    {
        public string BestPerformingCategory { get; set; }
        public decimal CategoryEngagementRate { get; set; }
        public List<CategoryPerformanceDTO> CategoryBreakdown { get; set; }
    }

    public class CategoryPerformanceDTO
    {
        public string Category { get; set; }
        public int Views { get; set; }
        public int Artists { get; set; }
        public decimal AverageViewsPerArtist { get; set; }
    }
} 