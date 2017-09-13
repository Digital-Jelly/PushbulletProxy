using Newtonsoft.Json;

namespace PushbulletProxy.Core.Models
{
    public class BaseUserNotification
    {
        [JsonProperty(Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string AccessToken { get; set; }
    }
}