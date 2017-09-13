using System.Collections.Generic;

namespace PushbulletProxy.Core
{
    /// <summary>
    /// Class for storing global settings relating to the pushbullet proxy system.
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// The allowed access tokens for pushbullet, and for registering users. DEPRECATED
        /// </summary>
        List<string> WhitelistedAccessTokens { get; }

        /// <summary>
        /// Where to attempt to send pushbullet requests to.
        /// </summary>
        string PushbulletApiUrl { get; }
    }
}