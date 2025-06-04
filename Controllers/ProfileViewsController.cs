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
    public class ProfileViewsController : ControllerBase
    {
        private readonly APContext _context;

        public ProfileViewsController(APContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Log a profile view (daily unique + session-based)
        /// </summary>
        [HttpPost("")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        public IActionResult LogProfileView([FromBody] LogProfileViewRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.ProfileUsername))
                {
                    return BadRequest("ProfileUsername is required");
                }

                // Get visitor info
                var ipAddress = GetClientIpAddress();
                var sessionId = request.SessionId ?? GenerateSessionId();
                var today = DateTime.UtcNow.Date;

                // Check if this session already viewed this profile today
                var existingView = _context.ProfileViews
                    .Where(pv => pv.ProfileUsername == request.ProfileUsername &&
                                 pv.SessionId == sessionId &&
                                 pv.ViewDate == today)
                    .FirstOrDefault();

                if (existingView != null)
                {
                    // Already viewed today - don't log again
                    return Ok(new { message = "Already counted today", counted = false });
                }

                // Log new unique daily view
                var profileView = new ProfileView
                {
                    ProfileUsername = request.ProfileUsername,
                    ViewedAt = DateTime.UtcNow,
                    SessionId = sessionId,
                    IpAddress = ipAddress,
                    ViewDate = today
                };

                _context.ProfileViews.Add(profileView);
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
        /// Get analytics stats for a profile
        /// </summary>
        [HttpGet("{username}/stats")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(ProfileAnalyticsResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public IActionResult GetProfileAnalytics(string username)
        {
            try
            {
                var now = DateTime.UtcNow;
                var today = now.Date;
                var thisWeekStart = today.AddDays(-(int)today.DayOfWeek); // Start of week (Sunday)
                var thisMonthStart = new DateTime(today.Year, today.Month, 1);

                // Get all views for this profile
                var allViews = _context.ProfileViews
                    .Where(pv => pv.ProfileUsername == username)
                    .ToList();

                if (!allViews.Any())
                {
                    return Ok(new ProfileAnalyticsResponse
                    {
                        Username = username,
                        TotalViews = 0,
                        UniqueViewsToday = 0,
                        UniqueViewsThisWeek = 0,
                        UniqueViewsThisMonth = 0,
                        RecentActivity = new List<DailyActivity>()
                    });
                }

                // Calculate metrics
                var totalViews = allViews.Count;
                
                var uniqueViewsToday = allViews
                    .Where(pv => pv.ViewDate == today)
                    .Count();

                var uniqueViewsThisWeek = allViews
                    .Where(pv => pv.ViewDate >= thisWeekStart)
                    .Count();

                var uniqueViewsThisMonth = allViews
                    .Where(pv => pv.ViewDate >= thisMonthStart)
                    .Count();

                // Get daily activity for last 7 days
                var recentActivity = Enumerable.Range(0, 7)
                    .Select(i => today.AddDays(-i))
                    .Select(date => new DailyActivity
                    {
                        Date = date.ToString("yyyy-MM-dd"),
                        Views = allViews.Count(pv => pv.ViewDate == date)
                    })
                    .OrderBy(da => da.Date)
                    .ToList();

                // Find best day
                var bestDay = allViews
                    .GroupBy(pv => pv.ViewDate)
                    .OrderByDescending(g => g.Count())
                    .FirstOrDefault();

                var response = new ProfileAnalyticsResponse
                {
                    Username = username,
                    TotalViews = totalViews,
                    UniqueViewsToday = uniqueViewsToday,
                    UniqueViewsThisWeek = uniqueViewsThisWeek,
                    UniqueViewsThisMonth = uniqueViewsThisMonth,
                    BestDay = bestDay != null ? new BestDayInfo
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

    public class LogProfileViewRequest
    {
        public string ProfileUsername { get; set; }
        public string SessionId { get; set; } // Optional - will generate if not provided
    }

    public class ProfileAnalyticsResponse
    {
        public string Username { get; set; }
        public int TotalViews { get; set; }
        public int UniqueViewsToday { get; set; }
        public int UniqueViewsThisWeek { get; set; }
        public int UniqueViewsThisMonth { get; set; }
        public BestDayInfo BestDay { get; set; }
        public List<DailyActivity> RecentActivity { get; set; }
    }

    public class BestDayInfo
    {
        public string Date { get; set; }
        public int Views { get; set; }
    }

    public class DailyActivity
    {
        public string Date { get; set; }
        public int Views { get; set; }
    }
} 