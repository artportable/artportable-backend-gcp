using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Artportable.API.Handlers
{
  public class UpsalesMessageHandler : DelegatingHandler
  {
    private readonly string _token;
    public UpsalesMessageHandler(string token)
    {
      _token = token;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      var query = HttpUtility.ParseQueryString(request.RequestUri.Query);
      if(string.IsNullOrWhiteSpace(query.Get(_token))){
        query.Add("token", _token);
        var builder = new UriBuilder(request.RequestUri);
        builder.Query = query.ToString();
        request.RequestUri = builder.Uri;
      }
      return await base.SendAsync(request, cancellationToken);
    }
  }
}