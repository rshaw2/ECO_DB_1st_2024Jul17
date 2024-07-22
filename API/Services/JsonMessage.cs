using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace VPC.WebApi.Utility
{
    public interface IJsonMessage
    {
        JsonResult IgnoreNullableObject(Object result);
    }
    public class JsonMessage : IJsonMessage
    {
        public JsonResult IgnoreNullableObject(object result)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            settings.Converters.Add(new StringEnumConverter { NamingStrategy = new DefaultNamingStrategy() });

            var jsonResult = new JsonResult(result, settings)
            {
                ContentType = "application/json"
            };
            return jsonResult;
        }
    }
}
