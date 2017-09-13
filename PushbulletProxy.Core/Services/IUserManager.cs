using PushbulletProxy.Core.Models;
using System.Collections.Generic;

namespace PushbulletProxy.Core.Services
{
    /// <summary>
    /// Manager for handling all user related operations, including the maintenence of the in-memory user collection.
    /// </summary>
    public interface IUserManager
    {
        List<User> GetAllUsers();

        ResponseBase<User> Get(string username);

        ResponseBase<User> Add(string username, string accessToken);

        ResponseBase RegisterPush(string username);

        ResponseBase Delete(string username);
    }
}
