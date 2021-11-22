using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Artportable.API.Interfaces.Services;

namespace Artportable.API.Services
{
  public class UpsalesService : ICrmService
  {
    private readonly HttpClient _httpClient;
    public UpsalesService(HttpClient httpClient){
      _httpClient = httpClient;
    }
    public async Task RegisterPurchase()
    {

    }
  }
}