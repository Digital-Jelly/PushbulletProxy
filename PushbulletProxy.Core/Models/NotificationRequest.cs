using Newtonsoft.Json;

namespace PushbulletProxy.Core.Models
{
    public class NotificationRequest
    {
        [JsonProperty(Required = Required.Always)]
        public string Username { get; set; }
    }
}