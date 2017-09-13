using Newtonsoft.Json;
using System;

namespace PushbulletProxy.Core.Models
{
    public class UserResponse : BaseUserNotification
    {
        [JsonProperty(Required = Required.Always)]
        public DateTime CreationTime { get; set; }

        [JsonProperty(Required = Required.Always, DefaultValueHandling = DefaultValueHandling.Populate)]
        public int NumOfNotificationsPushed { get; set; }
    }
}