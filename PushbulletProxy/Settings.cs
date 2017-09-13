using PushbulletProxy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PushbulletProxy
{
    /// <summary>
    /// Class for storing global settings relating to the pushbullet proxy system.
    /// </summary>
    public class Settings : ISettings
    {
        /// <summary>
        /// The allowed access tokens for pushbullet, and for registering users.
        /// </summary>
        public List<string> WhitelistedAccessTokens
        {
            get
            {
                return new List<string>
                {
                    "o.XDZj4UlX4UaZMgOeL0AOOqWS0TELMKUZ"
                };
            }
        }

        /// <summary>
        /// Where to attempt to send pushbullet requests to.
        /// </summary>
        public string PushbulletApiUrl
        {
            get
            {
                return "https://api.pushbullet.com/v2/pushes";
            }
        }
    }
}