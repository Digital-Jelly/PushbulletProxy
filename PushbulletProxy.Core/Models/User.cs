using System;

namespace PushbulletProxy.Core.Models
{
    /// <summary>
    /// User entity that is used internally.
    /// </summary>
    public class User
    {
        public string Username { get; set; }

        public string AccessToken { get; set; }

        public DateTime Created { get; }

        public int NumberOfNotificationsPushed { get; set; }

        public User(string username, string accessToken)
        {
            this.Username = username;
            this.AccessToken = accessToken;
            this.Created = DateTime.UtcNow;
            this.NumberOfNotificationsPushed = 0;
        }
    }
}