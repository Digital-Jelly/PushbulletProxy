using PushbulletProxy.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using PushbulletProxy.Core;
using PushbulletProxy.Core.Models;
using PushbulletProxy.Core.Validators;
using PushbulletProxy.Core.ErrorHandling;

namespace PushbulletProxy.Services
{
    /// <summary>
    /// Manager for handling all user related operations, including the maintenence of the in-memory user collection.
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly IUserValidator userValidator;
        private List<User> registeredUsers;

        public UserManager(IUserValidator userValidator)
        {
            this.userValidator = userValidator;
            this.registeredUsers = new List<User>();
        }

        public List<User> GetAllUsers()
        {
            return this.registeredUsers;
        }
        
        public ResponseBase<User> Get(string username)
        {
            if (!this.IsUserRegistered(username))
            {
                return new ResponseBase<User>
                {
                    Error = new PushbulletUserException("User is not registered")
                };
            }

            var user = this.registeredUsers.Single(x => x.Username == username);

            return new ResponseBase<User>()
            {
                Result = user
            };
        }

        public ResponseBase<User> Add(string username, string accessToken)
        {
            // Do not register two users with the same username
            if (this.IsUserRegistered(username))
            {
                return new ResponseBase<User>
                {
                    Error = new PushbulletUserException("User is already registered")
                };
            }

            var user = new User(username, accessToken);

            var validationResult = this.userValidator.IsValid(user);
            
            if (!validationResult.IsSuccess)
            {
                return new ResponseBase<User>
                {
                    Error = validationResult.Error
                };
            }

            // Add the new user to the in-memory collection
            this.registeredUsers.Add(user);

            return new ResponseBase<User> { Result = user };
        }

        public ResponseBase RegisterPush(string username)
        {
            if (!this.IsUserRegistered(username))
            {
                return new ResponseBase
                {
                    Error = new InvalidOperationException("User is not registered")
                };
            }

            var user = this.registeredUsers.Single(x => x.Username == username);
            user.NumberOfNotificationsPushed += 1;

            return new ResponseBase();
        }

        public ResponseBase Delete(string username)
        {
            if (!this.IsUserRegistered(username))
            {
                return new ResponseBase
                {
                    Error = new InvalidOperationException("User cannot be deleted as they are not registered")
                };
            }

            var user = this.registeredUsers.Single(x => x.Username == username);

            this.registeredUsers.Remove(user);

            return new ResponseBase();
        }

        private bool IsUserRegistered(string username)
        {
            return this.registeredUsers.Any(x => x.Username == username);
        }
    }
}
