using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Extentions
{
  public static class UrlHelperExtentions
  {
    private static string linkHeaderTemplate = "<{0}>; rel=\"{1}\"";
    public static List<string> ToPageLinks(this IUrlHelper urlHelper, string routeName, object routeValues, int pageNo, int pageSize, int currentCount)
    {
      var links = new List<string>();
      // Create first page link 
      var firstPage = new Uri(urlHelper.Link(routeName, new RouteValueDictionary(routeValues)
        {
            {"page", 1},
            {"pageSize", pageSize}
        }));
      links.Add(string.Format(linkHeaderTemplate, firstPage, "first"));

      if (pageNo > 1)
      {
      // Create previous page link 
        var previousPage = new Uri(urlHelper.Link(routeName, new RouteValueDictionary(routeValues)
            {
                {"page", pageNo - 1},
                {"pageSize", pageSize}
            }));
        links.Add(string.Format(linkHeaderTemplate, previousPage, "previous"));

      }
      if (pageSize == currentCount)
      {
        // Create next page link 
        var nextPage = new Uri(urlHelper.Link(routeName, new RouteValueDictionary(routeValues)
            {
                {"page", pageNo + 1},
                {"pageSize", pageSize}
            }));
        links.Add(string.Format(linkHeaderTemplate, nextPage, "next"));
      }
      return links;
    }
  }
}