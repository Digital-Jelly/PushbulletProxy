using Newtonsoft.Json;

namespace PushbulletProxy.Core.Models
{
    public class SendPushbulletNotificationRequest
    {
        [JsonProperty(Required = Required.Always)]
        public string Type { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Title { get; set; }

        [JsonProperty(Required = Required.Always)]
        public string Body { get; set; }
    }
}
