using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace PushbulletProxy.Core.Extensions
{
    public static class JsonExtensions
    {
        public static string Serialize<TObject>(this TObject data) where TObject : class
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.Indented
            };

            try
            {
                return JsonConvert.SerializeObject(data);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
