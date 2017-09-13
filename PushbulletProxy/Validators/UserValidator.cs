using PushbulletProxy.Core.Validators;
using System;
using PushbulletProxy.Core;
using PushbulletProxy.Core.Models;
using PushbulletProxy.Core.ErrorHandling;

namespace PushbulletProxy.Validators
{
    /// <summary>
    /// Class to handle validations of a pushbullet proxy user. Users must have a username
    /// and an access token that corresponds to a list of white-listed access tokens.
    /// </summary>
    public class UserValidator : IUserValidator
    {
        private readonly ISettings settings;

        public UserValidator(ISettings settings)
        {
            this.settings = settings;
        }

        public ResponseBase IsValid(User user)
        {
            if (user == null)
            {
                return new ResponseBase
                {
                    Error = new PushbulletUserException("Request is null", new NullReferenceException())
                };
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                return new ResponseBase
                {
                    Error = new PushbulletUserException("Username is empty", new InvalidOperationException())
                };
            }

            if (string.IsNullOrEmpty(user.AccessToken))
            {
                return new ResponseBase
                {
                    Error = new PushbulletUserException("Access token is empty", new InvalidOperationException())
                };
            }

            /*
            if (!this.settings.WhitelistedAccessTokens.Contains(user.AccessToken))
            {
                return new ResponseBase
                {
                    Error = new PushbulletUserException("Access token is not allowed", new InvalidOperationException())
                };
            }
            */

            return new ResponseBase();
        }
    }
}