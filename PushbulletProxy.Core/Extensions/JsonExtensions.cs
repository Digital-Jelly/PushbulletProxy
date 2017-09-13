using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
                return JsonConvert.SerializeObject(data, settings);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
