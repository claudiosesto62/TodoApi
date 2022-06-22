﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi
{
    public class XsfrHeaderSW : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "X-XSRF-TOKEN",
                In = ParameterLocation.Header,
                Required = true,
 
                Schema = new OpenApiSchema
                {
                    Type = "string"
                } // set to false if this is optional
            });
        }


    }
}
