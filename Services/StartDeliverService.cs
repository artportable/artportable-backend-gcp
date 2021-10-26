using Artportable.API.DTOs;
using Artportable.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artportable.API.Services
{
  public class StartDeliverService : IStartDeliverService
  {
    private APContext _context;

    public StartDeliverService(APContext apContext)
    {
      _context = apContext ??
        throw new ArgumentNullException(nameof(apContext));
    }

    public List<StartDeliverUserSyncDTO> GetUsersToSync(int limit, int offset)
    {
      var users = _context.Users
        .Skip(offset)
        .Take(limit)
        .Select(u => new StartDeliverUserSyncDTO() 
        {
          email = u.Email,
          username = u.Username,
          active = true
        });

      return users.ToList();
    }
  }
}
