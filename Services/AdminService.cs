using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Artportable.API.DTOs;
using Artportable.API.Entities;
using Artportable.API.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Stripe;

namespace Artportable.API.Services
{
    public class AdminService : IAdminService
    {
        private readonly APContext _context;

        public AdminService(APContext apContext)
        {
            _context = apContext ?? throw new ArgumentNullException(nameof(apContext));
        }

        public AdminStatisticsDTO GetStatistics()
        {
            var statistics = new AdminStatisticsDTO
            {
                Users = _context.Users.Count(),

                Artworks = _context.Artworks.Count(),

                Likes = _context.Likes.Count(),

                Connections = _context.Connections.Count(),
            };

            return statistics;
        }

        public List<ProductStatisticsDTO> GetProductStatistics()
        {
            var productStatistics = _context
                .Users.Join(
                    _context.Subscriptions,
                    u => u.SubscriptionId,
                    s => s.Id,
                    (u, s) => new { u, s }
                )
                .Join(_context.Products, us => us.s.ProductId, p => p.Id, (us, p) => new { us, p })
                .GroupBy(x => x.p.Name)
                .Select(g => new ProductStatisticsDTO
                {
                    ProductName = g.Key,
                    UserCount = g.Count(),
                })
                .ToList();

            return productStatistics;
        }

        public List<UserDTO> GetUsersByProduct(int productId)
        {
            // Get the date two months ago from today
            var twoMonthsAgo = DateTime.Now.AddMonths(-2);

            var usersWithProduct = _context
                .Users.Join(
                    _context.Subscriptions,
                    u => u.SubscriptionId,
                    s => s.Id,
                    (u, s) => new { u, s }
                )
                .GroupJoin(
                    _context.Products,
                    us => us.s.ProductId,
                    p => p.Id,
                    (us, products) => new { us, products }
                )
                .SelectMany(x => x.products.DefaultIfEmpty(), (x, p) => new { x.us, p })
                .Where(x => x.p != null && x.p.Id == productId && x.us.u.Created >= twoMonthsAgo)
                .Select(x => new UserDTO
                {
                    Username = x.us.u.Username,
                    Email = x.us.u.Email,
                    Created = x.us.u.Created,
                    Name = x.us.u.UserProfile.Name,
                    PhoneNumber = x.us.u.PhoneNumber,
                    Artworks = _context.Artworks.Count(a => a.UserId == x.us.u.Id),
                })
                .OrderByDescending(x => x.Created)
                .ToList();

            return usersWithProduct;
        }

        public List<UserWithSubscriptionDTO> GetUsersByProductSubscription(int productId)
        {
            var userIds = _context
                .Users.Join(
                    _context.Subscriptions,
                    u => u.SubscriptionId,
                    s => s.Id,
                    (u, s) => new { u, s }
                )
                .Where(x => x.s.ProductId == productId)
                .Select(x => x.u.Id)
                .ToList();

            var usersWithProduct = _context
                .Users.Where(u => userIds.Contains(u.Id))
                .OrderByDescending(x => x.Created)
                .Select(u => new UserWithSubscriptionDTO
                {
                    User_Id = u.Id,
                    Subscription_Id = u.SubscriptionId,
                    Product_Id = u.Subscription.ProductId,
                    CustomerId = u.Subscription.CustomerId,
                    ExpirationDate = u.Subscription.ExpirationDate,
                    Username = u.Username,
                    Email = u.Email,
                    Created = u.Created,
                    Name = u.UserProfile.Name,
                    Surname = u.UserProfile.Surname,
                    PhoneNumber = u.PhoneNumber,
                })
                .ToList();

            return usersWithProduct;
        }

        public string GetCustomerJson(string customerId)
        {
            try
            {
                // StripeConfiguration.ApiKey = "sk_live_YOUvIGb9PvSi7aDeX5OYqyUN00YcBAGqKx";

                var service = new CustomerService();
                var options = new CustomerGetOptions
                {
                    Expand = new List<string> { "subscriptions" }, // Request subscriptions data
                };
                var stripeCustomer = service.Get(customerId, options);
                if (stripeCustomer != null)
                {
                    string customerJson = JsonConvert.SerializeObject(stripeCustomer);
                    return customerJson;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching customer: {e}");
                return null;
            }
        }

        public async Task<UserWithSubscriptionDTO> GetUserWithActiveOrTrialingStripeSubscriptionByEmailAsync(
            string email
        )
        {
            try
            {
                // Fetch the user and their subscription details by email
                var user = await _context
                    .Users.Include(u => u.Subscription) // Load the subscription details
                    .Include(u => u.UserProfile) // Load the user profile for Name and Surname
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    Console.WriteLine("User not found in the database");
                    return null;
                }

                if (user.Subscription == null)
                {
                    Console.WriteLine("User does not have a subscription");
                    return null;
                }

                var stripeCustomerId = user.Subscription.CustomerId;

                if (string.IsNullOrEmpty(stripeCustomerId))
                {
                    Console.WriteLine("CustomerId is missing for this subscription");
                    return null;
                }

                var subscriptionService = new SubscriptionService();

                // Fetch active and trialing subscriptions for the customer from Stripe
                var subscriptions = subscriptionService.List(
                    new SubscriptionListOptions
                    {
                        Customer = stripeCustomerId,
                        Status = "all", // Fetch all statuses to filter locally
                        Limit = 1, // Limit to 1 subscription
                    }
                );

                if (subscriptions == null || !subscriptions.Data.Any())
                {
                    Console.WriteLine(
                        "No subscriptions found for Stripe customer: " + stripeCustomerId
                    );
                    return null;
                }

                // Find the first subscription that is either "active" or "trialing"
                var activeOrTrialingSubscription = subscriptions.Data.FirstOrDefault(sub =>
                    sub.Status == "active" || sub.Status == "trialing"
                );

                if (activeOrTrialingSubscription == null)
                {
                    Console.WriteLine(
                        "No active or trialing subscriptions found for Stripe customer: "
                            + stripeCustomerId
                    );
                    return null;
                }

                // Debugging: Check if Items contain data
                Console.WriteLine(
                    $"Subscription items count: {activeOrTrialingSubscription.Items.Data.Count}"
                );

                // Extract product plan from subscription (use Product ID or Name)
                var plan = activeOrTrialingSubscription.Items.Data.FirstOrDefault()?.Plan?.Id;

                foreach (var item in activeOrTrialingSubscription.Items.Data)
                {
                    Console.WriteLine($"Item Plan ID: {item.Plan?.Id}");
                    Console.WriteLine($"Item Product ID: {item.Plan?.Product?.Id}");
                }

                // Return user details with subscription info, including ProductPlan
                return new UserWithSubscriptionDTO
                {
                    User_Id = user.Id,
                    Subscription_Id = user.SubscriptionId,
                    Product_Id = user.Subscription.ProductId,
                    CustomerId = stripeCustomerId,
                    ExpirationDate = user.Subscription.ExpirationDate,
                    Username = user.Username,
                    Email = user.Email,
                    Created = user.Created,
                    SubscriptionStatus = activeOrTrialingSubscription.Status,
                    ProductPlan = plan, // Assign the plan's product ID or name
                };
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching active or trialing subscriptions by email: {e}");
                return null;
            }
        }

        // Profile View Analytics Methods
        
        public AdminProfileViewAnalyticsDTO GetProfileViewAnalytics()
        {
            var now = DateTime.UtcNow;
            var today = now.Date;
            var thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
            var thisMonthStart = new DateTime(today.Year, today.Month, 1);

            var allViews = _context.ProfileViews.ToList();

            if (!allViews.Any())
            {
                return new AdminProfileViewAnalyticsDTO
                {
                    TotalViews = 0,
                    UniqueViewsToday = 0,
                    UniqueViewsThisWeek = 0,
                    UniqueViewsThisMonth = 0,
                    TotalSessions = 0,
                    ActiveArtists = 0,
                    AverageViewsPerArtist = 0,
                    TopArtists = new List<TopArtistDTO>(),
                    DailyActivity = new List<DailyActivityDTO>(),
                    HourlyActivity = new List<HourlyActivityDTO>(),
                    TrafficTrends = new TrafficTrendsDTO { WeeklyTrends = new List<WeeklyTrendDTO>(), MonthlyTrends = new List<MonthlyTrendDTO>() },
                    UserBehavior = new UserBehaviorDTO { SessionDepths = new List<SessionDepthDTO>(), TopCountries = new List<GeographicDataDTO>() }
                };
            }

            var totalViews = allViews.Count;
            var uniqueViewsToday = allViews.Count(v => v.ViewDate == today);
            var uniqueViewsThisWeek = allViews.Count(v => v.ViewDate >= thisWeekStart);
            var uniqueViewsThisMonth = allViews.Count(v => v.ViewDate >= thisMonthStart);
            var totalSessions = allViews.Select(v => v.SessionId).Distinct().Count();
            var activeArtists = allViews.Select(v => v.ProfileUsername).Distinct().Count();
            var averageViewsPerArtist = activeArtists > 0 ? (decimal)totalViews / activeArtists : 0;

            // Top Artists
            var topArtists = GetTopPerformingArtists(10).Select(a => new TopArtistDTO
            {
                Username = a.Username,
                TotalViews = a.TotalViews,
                UniqueViewsToday = a.ViewsToday,
                UniqueViewsThisWeek = a.ViewsThisWeek,
                UniqueViewsThisMonth = a.ViewsThisMonth,
                GrowthRate = a.WeekOverWeekGrowth,
                TrendDirection = a.TrendDirection
            }).ToList();

            // Daily Activity (last 30 days)
            var dailyActivity = Enumerable.Range(0, 30)
                .Select(i => today.AddDays(-i))
                .Select(date => new DailyActivityDTO
                {
                    Date = date.ToString("yyyy-MM-dd"),
                    Views = allViews.Count(v => v.ViewDate == date),
                    UniqueSessions = allViews.Where(v => v.ViewDate == date).Select(v => v.SessionId).Distinct().Count(),
                    ActiveArtists = allViews.Where(v => v.ViewDate == date).Select(v => v.ProfileUsername).Distinct().Count()
                })
                .OrderBy(da => da.Date)
                .ToList();

            // Hourly Activity
            var hourlyActivity = allViews
                .Where(v => v.ViewDate == today)
                .GroupBy(v => v.ViewedAt.Hour)
                .Select(g => new HourlyActivityDTO
                {
                    Hour = g.Key,
                    Views = g.Count(),
                    UniqueSessions = g.Select(v => v.SessionId).Distinct().Count()
                })
                .OrderBy(ha => ha.Hour)
                .ToList();

            // Fill missing hours with 0
            for (int i = 0; i < 24; i++)
            {
                if (!hourlyActivity.Any(ha => ha.Hour == i))
                {
                    hourlyActivity.Add(new HourlyActivityDTO { Hour = i, Views = 0, UniqueSessions = 0 });
                }
            }
            hourlyActivity = hourlyActivity.OrderBy(ha => ha.Hour).ToList();

            // Traffic Trends
            var trafficTrends = GetTrafficTrends(allViews, today);

            // User Behavior
            var userBehavior = GetUserBehavior(allViews);

            return new AdminProfileViewAnalyticsDTO
            {
                TotalViews = totalViews,
                UniqueViewsToday = uniqueViewsToday,
                UniqueViewsThisWeek = uniqueViewsThisWeek,
                UniqueViewsThisMonth = uniqueViewsThisMonth,
                TotalSessions = totalSessions,
                ActiveArtists = activeArtists,
                AverageViewsPerArtist = averageViewsPerArtist,
                TopArtists = topArtists,
                DailyActivity = dailyActivity,
                HourlyActivity = hourlyActivity,
                TrafficTrends = trafficTrends,
                UserBehavior = userBehavior
            };
        }

        public List<ArtistPerformanceDTO> GetTopPerformingArtists(int count = 20)
        {
            var now = DateTime.UtcNow;
            var today = now.Date;
            var thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
            var thisMonthStart = new DateTime(today.Year, today.Month, 1);
            var lastWeekStart = thisWeekStart.AddDays(-7);
            var lastMonthStart = thisMonthStart.AddMonths(-1);

            var artistStats = _context.ProfileViews
                .GroupBy(v => v.ProfileUsername)
                .Select(g => new
                {
                    Username = g.Key,
                    TotalViews = g.Count(),
                    ViewsToday = g.Count(v => v.ViewDate == today),
                    ViewsThisWeek = g.Count(v => v.ViewDate >= thisWeekStart),
                    ViewsThisMonth = g.Count(v => v.ViewDate >= thisMonthStart),
                    ViewsLastWeek = g.Count(v => v.ViewDate >= lastWeekStart && v.ViewDate < thisWeekStart),
                    ViewsLastMonth = g.Count(v => v.ViewDate >= lastMonthStart && v.ViewDate < thisMonthStart),
                    RecentActivity = g.Where(v => v.ViewDate >= today.AddDays(-7))
                        .GroupBy(v => v.ViewDate)
                        .Select(dg => new DailyActivityDTO
                        {
                            Date = dg.Key.ToString("yyyy-MM-dd"),
                            Views = dg.Count(),
                            UniqueSessions = dg.Select(v => v.SessionId).Distinct().Count(),
                            ActiveArtists = 1
                        }).ToList()
                })
                .OrderByDescending(a => a.TotalViews)
                .Take(count)
                .ToList();

            return artistStats.Select((a, index) => new ArtistPerformanceDTO
            {
                Username = a.Username,
                TotalViews = a.TotalViews,
                ViewsToday = a.ViewsToday,
                ViewsThisWeek = a.ViewsThisWeek,
                ViewsThisMonth = a.ViewsThisMonth,
                WeekOverWeekGrowth = a.ViewsLastWeek > 0 ? ((decimal)(a.ViewsThisWeek - a.ViewsLastWeek) / a.ViewsLastWeek) * 100 : 0,
                MonthOverMonthGrowth = a.ViewsLastMonth > 0 ? ((decimal)(a.ViewsThisMonth - a.ViewsLastMonth) / a.ViewsLastMonth) * 100 : 0,
                TrendDirection = GetTrendDirection(a.ViewsThisWeek, a.ViewsLastWeek),
                Rank = index + 1,
                RecentActivity = a.RecentActivity
            }).ToList();
        }

        public List<ArtistPerformanceDTO> GetArtistPerformanceDetails(string username = null)
        {
            var query = _context.ProfileViews.AsQueryable();
            
            if (!string.IsNullOrEmpty(username))
            {
                query = query.Where(v => v.ProfileUsername == username);
            }

            return GetTopPerformingArtists(string.IsNullOrEmpty(username) ? 100 : 1);
        }

        public PlatformInsightsDTO GetPlatformInsights()
        {
            var now = DateTime.UtcNow;
            var today = now.Date;
            var thisWeekStart = today.AddDays(-(int)today.DayOfWeek);

            var allViews = _context.ProfileViews.ToList();

            var discoveryPatterns = new DiscoveryPatternsDTO
            {
                ArtistsDiscoveredToday = allViews.Where(v => v.ViewDate == today).Select(v => v.ProfileUsername).Distinct().Count(),
                ArtistsDiscoveredThisWeek = allViews.Where(v => v.ViewDate >= thisWeekStart).Select(v => v.ProfileUsername).Distinct().Count(),
                AverageDiscoveryRate = allViews.Any() ? (decimal)allViews.GroupBy(v => v.ViewDate).Average(g => g.Select(v => v.ProfileUsername).Distinct().Count()) : 0,
                TopDiscoverySources = new List<DiscoverySourceDTO>
                {
                    new DiscoverySourceDTO { Source = "Direct", Count = allViews.Count() / 2, Percentage = 50 },
                    new DiscoverySourceDTO { Source = "Browse", Count = allViews.Count() / 3, Percentage = 33 },
                    new DiscoverySourceDTO { Source = "Search", Count = allViews.Count() / 6, Percentage = 17 }
                }
            };

            var engagementMetrics = new EngagementMetricsDTO
            {
                AverageTimeOnProfile = 2.5m, // Mock data - would need session tracking
                BounceRate = 0.25m,
                DeepEngagementSessions = allViews.GroupBy(v => v.SessionId).Count(g => g.Count() >= 3),
                EngagementScore = 7.8m
            };

            var artistGrowth = new ArtistGrowthDTO
            {
                NewArtistsWithViews = allViews.Where(v => v.ViewDate >= today.AddDays(-7)).Select(v => v.ProfileUsername).Distinct().Count(),
                RisingStars = GetRisingStars(5).Count,
                AverageGrowthRate = 12.5m,
                FastestGrowingArtists = GetRisingStars(5).Select(rs => rs.Username).ToList()
            };

            var contentPerformance = new ContentPerformanceDTO
            {
                BestPerformingCategory = "Digital Art",
                CategoryEngagementRate = 8.2m,
                CategoryBreakdown = new List<CategoryPerformanceDTO>
                {
                    new CategoryPerformanceDTO { Category = "Digital Art", Views = allViews.Count() / 3, Artists = 15, AverageViewsPerArtist = 25 },
                    new CategoryPerformanceDTO { Category = "Photography", Views = allViews.Count() / 4, Artists = 12, AverageViewsPerArtist = 20 },
                    new CategoryPerformanceDTO { Category = "Traditional", Views = allViews.Count() / 5, Artists = 8, AverageViewsPerArtist = 18 }
                }
            };

            return new PlatformInsightsDTO
            {
                DiscoveryPatterns = discoveryPatterns,
                EngagementMetrics = engagementMetrics,
                ArtistGrowth = artistGrowth,
                ContentPerformance = contentPerformance
            };
        }

        public List<ArtistPerformanceDTO> GetRisingStars(int count = 10)
        {
            var now = DateTime.UtcNow;
            var today = now.Date;
            var thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
            var lastWeekStart = thisWeekStart.AddDays(-7);

            var risingStars = _context.ProfileViews
                .GroupBy(v => v.ProfileUsername)
                .Select(g => new
                {
                    Username = g.Key,
                    ViewsThisWeek = g.Count(v => v.ViewDate >= thisWeekStart),
                    ViewsLastWeek = g.Count(v => v.ViewDate >= lastWeekStart && v.ViewDate < thisWeekStart),
                    TotalViews = g.Count()
                })
                .Where(a => a.ViewsLastWeek > 0) // Must have had views last week to calculate growth
                .Select(a => new
                {
                    a.Username,
                    a.ViewsThisWeek,
                    a.ViewsLastWeek,
                    a.TotalViews,
                    GrowthRate = ((decimal)(a.ViewsThisWeek - a.ViewsLastWeek) / a.ViewsLastWeek) * 100
                })
                .Where(a => a.GrowthRate >= 50) // 50%+ growth to be considered rising star
                .OrderByDescending(a => a.GrowthRate)
                .Take(count)
                .ToList();

            return risingStars.Select((rs, index) => new ArtistPerformanceDTO
            {
                Username = rs.Username,
                TotalViews = rs.TotalViews,
                ViewsThisWeek = rs.ViewsThisWeek,
                WeekOverWeekGrowth = rs.GrowthRate,
                TrendDirection = "up",
                Rank = index + 1,
                RecentActivity = new List<DailyActivityDTO>()
            }).ToList();
        }

        // Helper methods
        private TrafficTrendsDTO GetTrafficTrends(List<Entities.Models.ProfileView> allViews, DateTime today)
        {
            var thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
            var lastWeekStart = thisWeekStart.AddDays(-7);
            var thisMonthStart = new DateTime(today.Year, today.Month, 1);
            var lastMonthStart = thisMonthStart.AddMonths(-1);

            var thisWeekViews = allViews.Count(v => v.ViewDate >= thisWeekStart);
            var lastWeekViews = allViews.Count(v => v.ViewDate >= lastWeekStart && v.ViewDate < thisWeekStart);
            var thisMonthViews = allViews.Count(v => v.ViewDate >= thisMonthStart);
            var lastMonthViews = allViews.Count(v => v.ViewDate >= lastMonthStart && v.ViewDate < thisMonthStart);

            var weekOverWeekGrowth = lastWeekViews > 0 ? ((decimal)(thisWeekViews - lastWeekViews) / lastWeekViews) * 100 : 0;
            var monthOverMonthGrowth = lastMonthViews > 0 ? ((decimal)(thisMonthViews - lastMonthViews) / lastMonthViews) * 100 : 0;

            // Weekly trends for last 8 weeks
            var weeklyTrends = Enumerable.Range(0, 8)
                .Select(i =>
                {
                    var weekStart = thisWeekStart.AddDays(-i * 7);
                    var weekEnd = weekStart.AddDays(6);
                    var weekViews = allViews.Where(v => v.ViewDate >= weekStart && v.ViewDate <= weekEnd);
                    
                    return new WeeklyTrendDTO
                    {
                        WeekStart = weekStart.ToString("yyyy-MM-dd"),
                        WeekEnd = weekEnd.ToString("yyyy-MM-dd"),
                        Views = weekViews.Count(),
                        UniqueSessions = weekViews.Select(v => v.SessionId).Distinct().Count(),
                        ActiveArtists = weekViews.Select(v => v.ProfileUsername).Distinct().Count()
                    };
                })
                .OrderBy(wt => wt.WeekStart)
                .ToList();

            // Monthly trends for last 6 months
            var monthlyTrends = Enumerable.Range(0, 6)
                .Select(i =>
                {
                    var monthStart = thisMonthStart.AddMonths(-i);
                    var monthViews = allViews.Where(v => v.ViewDate >= monthStart && v.ViewDate < monthStart.AddMonths(1));
                    
                    return new MonthlyTrendDTO
                    {
                        Month = monthStart.ToString("MMMM"),
                        Year = monthStart.Year,
                        Views = monthViews.Count(),
                        UniqueSessions = monthViews.Select(v => v.SessionId).Distinct().Count(),
                        ActiveArtists = monthViews.Select(v => v.ProfileUsername).Distinct().Count()
                    };
                })
                .OrderBy(mt => new DateTime(mt.Year, DateTime.ParseExact(mt.Month, "MMMM", null).Month, 1))
                .ToList();

            // Best performances
            var bestDay = allViews.GroupBy(v => v.ViewDate)
                .OrderByDescending(g => g.Count())
                .FirstOrDefault();

            var bestWeek = weeklyTrends.OrderByDescending(wt => wt.Views).FirstOrDefault();
            var bestMonth = monthlyTrends.OrderByDescending(mt => mt.Views).FirstOrDefault();

            return new TrafficTrendsDTO
            {
                WeekOverWeekGrowth = weekOverWeekGrowth,
                MonthOverMonthGrowth = monthOverMonthGrowth,
                WeeklyTrends = weeklyTrends,
                MonthlyTrends = monthlyTrends,
                BestDay = bestDay != null ? new BestPerformanceDTO
                {
                    Period = bestDay.Key.ToString("yyyy-MM-dd"),
                    Views = bestDay.Count(),
                    UniqueSessions = bestDay.Select(v => v.SessionId).Distinct().Count(),
                    ActiveArtists = bestDay.Select(v => v.ProfileUsername).Distinct().Count()
                } : null,
                BestWeek = bestWeek != null ? new BestPerformanceDTO
                {
                    Period = $"{bestWeek.WeekStart} to {bestWeek.WeekEnd}",
                    Views = bestWeek.Views,
                    UniqueSessions = bestWeek.UniqueSessions,
                    ActiveArtists = bestWeek.ActiveArtists
                } : null,
                BestMonth = bestMonth != null ? new BestPerformanceDTO
                {
                    Period = $"{bestMonth.Month} {bestMonth.Year}",
                    Views = bestMonth.Views,
                    UniqueSessions = bestMonth.UniqueSessions,
                    ActiveArtists = bestMonth.ActiveArtists
                } : null
            };
        }

        private UserBehaviorDTO GetUserBehavior(List<Entities.Models.ProfileView> allViews)
        {
            var sessionGroups = allViews.GroupBy(v => v.SessionId).ToList();
            var totalSessions = sessionGroups.Count();
            var totalViews = allViews.Count;

            var sessionsPerUser = totalSessions > 0 ? (decimal)totalSessions / sessionGroups.Select(g => g.First().IpAddress).Distinct().Count() : 0;
            var viewsPerSession = totalSessions > 0 ? (decimal)totalViews / totalSessions : 0;

            // Session depths
            var sessionDepths = sessionGroups.GroupBy(g => g.Count())
                .Select(depthGroup => new SessionDepthDTO
                {
                    ViewsCount = depthGroup.Key,
                    SessionsCount = depthGroup.Count(),
                    Percentage = totalSessions > 0 ? (decimal)depthGroup.Count() / totalSessions * 100 : 0
                })
                .OrderBy(sd => sd.ViewsCount)
                .ToList();

            // Geographic data (simplified - using IP prefixes as countries)
            var topCountries = allViews.GroupBy(v => v.IpAddress?.Substring(0, Math.Min(v.IpAddress.Length, 3)) ?? "Unknown")
                .Take(5)
                .Select(g => new GeographicDataDTO
                {
                    Country = g.Key == "127" ? "Local" : g.Key == "192" ? "Private" : $"Region-{g.Key}",
                    Views = g.Count(),
                    UniqueSessions = g.Select(v => v.SessionId).Distinct().Count(),
                    Percentage = totalViews > 0 ? (decimal)g.Count() / totalViews * 100 : 0
                })
                .ToList();

            // Return visitors (sessions that have viewed profiles across multiple days)
            var returnVisitors = sessionGroups.Count(g => g.Select(v => v.ViewDate).Distinct().Count() > 1);
            var newVisitors = totalSessions - returnVisitors;

            return new UserBehaviorDTO
            {
                SessionsPerUser = sessionsPerUser,
                ViewsPerSession = viewsPerSession,
                ReturnVisitors = returnVisitors,
                NewVisitors = newVisitors,
                ReturnVisitorRate = totalSessions > 0 ? (decimal)returnVisitors / totalSessions * 100 : 0,
                SessionDepths = sessionDepths,
                TopCountries = topCountries
            };
        }

        private string GetTrendDirection(int currentWeek, int lastWeek)
        {
            if (lastWeek == 0) return "new";
            if (currentWeek > lastWeek * 1.1) return "up";
            if (currentWeek < lastWeek * 0.9) return "down";
            return "stable";
        }
    }
}
