using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Artportable.API.Entities;
using Artportable.API.Entities.Models;

namespace Artportable.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PlatformVisitsController : ControllerBase
    {
        private readonly APContext _context;

        public PlatformVisitsController(APContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Log a platform visit (homepage, main pages)
        /// Only counts once per session per day for uniqueness
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> LogVisit([FromBody] LogPlatformVisitRequest request)
        {
            try
            {
                var today = DateTime.UtcNow.Date;
                var clientIp = GetClientIpAddress();

                // Check if this session already visited today
                var existingVisit = await _context.PlatformVisits
                    .FirstOrDefaultAsync(v => v.SessionId == request.SessionId && v.VisitDate == today);

                if (existingVisit != null)
                {
                    // Already counted today
                    return Ok(new { counted = false, message = "Already counted today" });
                }

                // Create new visit record
                var visit = new PlatformVisit
                {
                    SessionId = request.SessionId,
                    IpAddress = clientIp,
                    VisitDate = today,
                    VisitedAt = DateTime.UtcNow,
                    PageUrl = request.PageUrl ?? "/",
                    UserAgent = Request.Headers["User-Agent"].FirstOrDefault()
                };

                _context.PlatformVisits.Add(visit);
                await _context.SaveChangesAsync();

                return Ok(new { counted = true, message = "Visit logged successfully" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging platform visit: {ex.Message}");
                return StatusCode(500, new { counted = false, message = "Failed to log visit" });
            }
        }

        /// <summary>
        /// Get platform visit statistics
        /// </summary>
        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            try
            {
                var now = DateTime.UtcNow;
                var today = now.Date;
                var thisWeekStart = today.AddDays(-(int)today.DayOfWeek);
                var thisMonthStart = new DateTime(today.Year, today.Month, 1);

                var allVisits = await _context.PlatformVisits.ToListAsync();

                var stats = new
                {
                    totalVisits = allVisits.Count,
                    uniqueVisitsToday = allVisits.Count(v => v.VisitDate == today),
                    uniqueVisitsThisWeek = allVisits.Count(v => v.VisitDate >= thisWeekStart),
                    uniqueVisitsThisMonth = allVisits.Count(v => v.VisitDate >= thisMonthStart),
                    totalUniqueSessions = allVisits.Select(v => v.SessionId).Distinct().Count(),
                    recentActivity = allVisits
                        .Where(v => v.VisitDate >= today.AddDays(-30))
                        .GroupBy(v => v.VisitDate)
                        .Select(g => new
                        {
                            date = g.Key.ToString("yyyy-MM-dd"),
                            visits = g.Count(),
                            uniqueSessions = g.Select(v => v.SessionId).Distinct().Count()
                        })
                        .OrderBy(x => x.date)
                        .ToList()
                };

                return Ok(stats);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting platform stats: {ex.Message}");
                return StatusCode(500, "Failed to get statistics");
            }
        }

        private string GetClientIpAddress()
        {
            try
            {
                // Check for forwarded IP first (for load balancers/proxies)
                var forwardedFor = Request.Headers["X-Forwarded-For"].FirstOrDefault();
                if (!string.IsNullOrEmpty(forwardedFor))
                {
                    return forwardedFor.Split(',')[0].Trim();
                }

                var realIp = Request.Headers["X-Real-IP"].FirstOrDefault();
                if (!string.IsNullOrEmpty(realIp))
                {
                    return realIp;
                }

                // Fall back to connection remote IP
                return Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";
            }
            catch
            {
                return "Unknown";
            }
        }
    }

    public class LogPlatformVisitRequest
    {
        public string SessionId { get; set; }
        public string PageUrl { get; set; }
    }
} 