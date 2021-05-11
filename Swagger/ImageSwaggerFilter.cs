using System.Collections.Generic;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Swagger
{
  /// <summary>
  /// Filter to enable handling file upload in swagger
  /// </summary>
  public class ImageSwaggerFilter : IOperationFilter
  {
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
      if (operation.OperationId == "Images_Upload")
      {
        operation.RequestBody = new OpenApiRequestBody()
        {
          Content = new Dictionary<string, OpenApiMediaType>()
                    {
                        {
                            "image/jpeg",
                            new OpenApiMediaType(){
                                Schema = new OpenApiSchema {
                                    Type = "string",
                                    Format = "binary"
                                }
                        }}

                    }
        };
      }
    }
  }
}