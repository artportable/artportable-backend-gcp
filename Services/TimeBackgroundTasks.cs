using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Artportable.API.Entities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace Artportable.API.Services
{
 public class TimedHostedService : IHostedService, IDisposable
{
    private int executionCount = 0;
    private readonly ILogger<TimedHostedService> _logger;
    private readonly APContext _context;
      private readonly IServiceScopeFactory _serviceScopeFactory;
    private Timer? _timer = null;

    public TimedHostedService(ILogger<TimedHostedService> logger,  IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero,
            TimeSpan.FromDays(1));

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<APContext>();

           var artworks = context.Artworks.Where(a => a.Promoted == true && a.PromotionEndDate.HasValue).ToList();


            foreach (var artwork in artworks)
            {
                if (DateTime.UtcNow >= artwork.PromotionEndDate.Value)
                {
                    artwork.Promoted = false;
                    context.Update(artwork);
                }
            }

            context.SaveChanges();
        }

        var count = Interlocked.Increment(ref executionCount);
        _logger.LogInformation($"Timed Hosted Service is working. Count: {count}");
    }



    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
}
