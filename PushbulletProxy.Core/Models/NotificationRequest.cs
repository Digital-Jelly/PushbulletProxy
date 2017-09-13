using Newtonsoft.Json;

namespace PushbulletProxy.Core.Models
{
    public class NotificationRequest
    {
        [JsonProperty(Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Body { get; set; }
    }
}