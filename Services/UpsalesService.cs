using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Artportable.API.DTOs.Upsales;
using Artportable.API.Interfaces.Services;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Artportable.API.Entities;
using Artportable.API.Enums;
using System.Collections.Immutable;
using Artportable.API.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Artportable.API.Options;
using System.Text;
using ContextUser = Artportable.API.Entities.Models.User;
using System;
using User = Artportable.API.DTOs.Upsales.User;
using Product = Artportable.API.DTOs.Upsales.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Artportable.API.Services
{
  public class UpsalesService : ICrmService
  {
    private readonly HttpClient _httpClient;
    ImmutableDictionary<string, ProductEnum> _products;
    private readonly ILogger<UpsalesService> _logger;
    private readonly UpsalesOptions _config;
    private APContext _context;
    public UpsalesService(HttpClient httpClient, ILogger<UpsalesService> logger, IOptions<UpsalesOptions> options, IServiceProvider serviceProvider)
    {
      _httpClient = httpClient;
      _logger = logger;
      _context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<APContext>();
      _config = options.Value;
    }
    public async Task RegisterPurchase(string subscriptionCustomerId, ProductEnum product, decimal price, string currency, PaymentIntervalEnum intervalEnum)
    {
      var user = await GetUserBySubscriptionCustomerId(subscriptionCustomerId);
      if (user != null)
      {
        var contact = await FindContact(user.Email);
        if (contact == null)
        {
          var company = await CreateCompany($"{user.UserProfile.Name} {user.UserProfile.Surname}");
          if (company == null)
            return;
          contact = await CreateContact(user.UserProfile.Name, user.UserProfile.Surname, user.Email, company.Id);
          if (contact == null)
            return;
        }
        var upsalesProduct = _config.Products.FirstOrDefault(p => p.InternalId == product && p.Interval == intervalEnum);
        if (upsalesProduct == null)
          return; //unknown product

        await CreateOrder(contact.Client.Id, $"{contact.Client.Name} {product.ToString()} {intervalEnum.ToString()}", upsalesProduct.Id, price, currency);
      }
    }

    private async Task<ContextUser> GetUserBySubscriptionCustomerId(string subscriptionCustomerId)
    {
      try
      {
        return await _context.Subscriptions
        .Include(s => s.User)
        .ThenInclude(u => u.UserProfile)
        .Where(s => s.CustomerId == subscriptionCustomerId)
        .Select(s => s.User)
        .FirstOrDefaultAsync();
      }
      catch (System.Exception e)
      {

        throw;
      }
    }

    private async Task<Contact> FindContact(string email)
    {
      try
      {
        var response = await _httpClient.GetAsync($"/api/v2/contacts/?email=eq:{email}");
        var responseString = await response.Content.ReadAsStringAsync();
        var responseBase = JsonSerializer.Deserialize<ResponseBase<List<Contact>>>(responseString);
        return responseBase.Data.FirstOrDefault(x => x.Email == email);
      }
      catch (System.Exception e)
      {
        _logger.LogError("Failed to get contacts from upsales");
        return null;
      }
    }
    private async Task<Contact> CreateContact(string firstName, string lastName, string email, int companyId)
    {
      try
      {
        var contact = new Contact()
        {
          Name = $"{firstName} {lastName}",
          FirstName = firstName,
          LastName = lastName,
          Email = email,
          Client = new Company
          {
            Id = companyId
          }
        };
        var json = JsonSerializer.Serialize(contact);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"/api/v2/contacts/", content);
        var responseString = await response.Content.ReadAsStringAsync();
        var responseBase = JsonSerializer.Deserialize<ResponseBase<Contact>>(responseString);
        return responseBase.Data;
      }
      catch (System.Exception e)
      {
        _logger.LogError("Failed to create contact in upsales");
        return null;
      }
    }

    private async Task<Company> CreateCompany(string companyName)
    {
      try
      {
        var company = new Company()
        {
          Name = companyName
        };
        var json = JsonSerializer.Serialize(company);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"/api/v2/accounts/", content);
        var responseString = await response.Content.ReadAsStringAsync();
        var responseBase = JsonSerializer.Deserialize<ResponseBase<Company>>(responseString);
        return responseBase.Data;
      }
      catch (System.Exception e)
      {
        _logger.LogError("Failed to create company in upsales");
        return null;
      }
    }

    private async Task<Order> CreateOrder(int companyId, string description, int productId, decimal price, string currency)
    {
      try
      {
        var order = new Order()
        {
          Description = description,
          Date = DateTimeOffset.Now,
          User = new User
          {
            Id = _config.UserId
          },
          Client = new Company
          {
            Id = companyId
          },
          Stage = new Stage
          {
            Id = 12
          },
          Probability = 100,
          OrderRow = new List<OrderRow>(){
            new OrderRow{
              Quantity = 1,
              Price = price,
              Product = new Product
              {
                Id = productId
              }
            }
          }
        };
        var json = JsonSerializer.Serialize(order);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"/api/v2/orders/", content);
        var responseString = await response.Content.ReadAsStringAsync();
        var responseBase = JsonSerializer.Deserialize<ResponseBase<Order>>(responseString);
        return responseBase.Data;
      }
      catch (System.Exception e)
      {
        _logger.LogError("Failed to get contacts from upsales");
        return null;
      }
    }
  }
}