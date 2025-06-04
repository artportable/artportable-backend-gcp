using System;
using System.Linq;
using System.Collections.Generic;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Artportable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtworkViewsController : ControllerBase
    {
        private readonly APContext _context;

        public ArtworkViewsController(APContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Log an artwork view (daily unique + session-based)
        /// </summary>
        [HttpPost("")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public IActionResult LogArtworkView([FromBody] LogArtworkViewRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.ArtworkId))
                {
                    return BadRequest("ArtworkId is required");
                }

                // Get visitor info
                var ipAddress = GetClientIpAddress();
                var sessionId = request.SessionId ?? GenerateSessionId();
                var today = DateTime.UtcNow.Date;

                // Check if this session already viewed this artwork today
                var existingView = _context.ArtworkViews
                    .Where(av => av.ArtworkId == request.ArtworkId &&
                                 av.SessionId == sessionId &&
                                 av.ViewDate == today)
                    .FirstOrDefault();

                if (existingView != null)
                {
                    // Already viewed today - don't log again
                    return Ok(new { message = "Already counted today", counted = false });
                }

                // Log new unique daily view
                var artworkView = new ArtworkView
                {
                    ArtworkId = request.ArtworkId,
                    ViewedAt = DateTime.UtcNow,
                    SessionId = sessionId,
                    IpAddress = ipAddress,
                    ViewDate = today
                };

                _context.ArtworkViews.Add(artworkView);
                _context.SaveChanges();

                return Ok(new { message = "View logged", counted = true, sessionId = sessionId });
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Get analytics stats for an artwork
        /// </summary>
        [HttpGet("{artworkId}/stats")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ArtworkAnalyticsResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public IActionResult GetArtworkAnalytics(string artworkId)
        {
            try
            {
                var now = DateTime.UtcNow;
                var today = now.Date;
                var thisWeekStart = today.AddDays(-(int)today.DayOfWeek); // Start of week (Sunday)
                var thisMonthStart = new DateTime(today.Year, today.Month, 1);

                // Get all views for this artwork
                var allViews = _context.ArtworkViews
                    .Where(av => av.ArtworkId == artworkId)
                    .ToList();

                if (!allViews.Any())
                {
                    return Ok(new ArtworkAnalyticsResponse
                    {
                        ArtworkId = artworkId,
                        TotalViews = 0,
                        UniqueViewsToday = 0,
                        UniqueViewsThisWeek = 0,
                        UniqueViewsThisMonth = 0,
                        RecentActivity = new List<DailyArtworkActivity>()
                    });
                }

                // Calculate metrics
                var totalViews = allViews.Count;
                
                var uniqueViewsToday = allViews
                    .Where(av => av.ViewDate == today)
                    .Count();

                var uniqueViewsThisWeek = allViews
                    .Where(av => av.ViewDate >= thisWeekStart)
                    .Count();

                var uniqueViewsThisMonth = allViews
                    .Where(av => av.ViewDate >= thisMonthStart)
                    .Count();

                // Get daily activity for last 7 days
                var recentActivity = Enumerable.Range(0, 7)
                    .Select(i => today.AddDays(-i))
                    .Select(date => new DailyArtworkActivity
                    {
                        Date = date.ToString("yyyy-MM-dd"),
                        Views = allViews.Count(av => av.ViewDate == date)
                    })
                    .OrderBy(da => da.Date)
                    .ToList();

                // Find best day
                var bestDay = allViews
                    .GroupBy(av => av.ViewDate)
                    .OrderByDescending(g => g.Count())
                    .FirstOrDefault();

                var response = new ArtworkAnalyticsResponse
                {
                    ArtworkId = artworkId,
                    TotalViews = totalViews,
                    UniqueViewsToday = uniqueViewsToday,
                    UniqueViewsThisWeek = uniqueViewsThisWeek,
                    UniqueViewsThisMonth = uniqueViewsThisMonth,
                    BestDay = bestDay != null ? new ArtworkBestDayInfo
                    {
                        Date = bestDay.Key.ToString("yyyy-MM-dd"),
                        Views = bestDay.Count()
                    } : null,
                    RecentActivity = recentActivity
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, {0}", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        private string GetClientIpAddress()
        {
            // Get real client IP (handling proxies)
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            
            // Check for forwarded headers (common in production)
            if (HttpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                ipAddress = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            }
            else if (HttpContext.Request.Headers.ContainsKey("X-Real-IP"))
            {
                ipAddress = HttpContext.Request.Headers["X-Real-IP"].FirstOrDefault();
            }

            return ipAddress?.Substring(0, Math.Min(ipAddress.Length, 50)) ?? "unknown";
        }

        private string GenerateSessionId()
        {
            return Guid.NewGuid().ToString();
        }
    }

    public class LogArtworkViewRequest
    {
        public string ArtworkId { get; set; }
        public string SessionId { get; set; } // Optional - will generate if not provided
    }

    public class ArtworkAnalyticsResponse
    {
        public string ArtworkId { get; set; }
        public int TotalViews { get; set; }
        public int UniqueViewsToday { get; set; }
        public int UniqueViewsThisWeek { get; set; }
        public int UniqueViewsThisMonth { get; set; }
        public ArtworkBestDayInfo BestDay { get; set; }
        public List<DailyArtworkActivity> RecentActivity { get; set; }
    }

    public class ArtworkBestDayInfo
    {
        public string Date { get; set; }
        public int Views { get; set; }
    }

    public class DailyArtworkActivity
    {
        public string Date { get; set; }
        public int Views { get; set; }
    }
} 