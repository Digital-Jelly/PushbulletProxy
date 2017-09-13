using PushbulletProxy.Core.Models;

namespace PushbulletProxy.Core.Validators
{
    /// <summary>
    /// Class for validator a user object.
    /// </summary>
    public interface IUserValidator
    {
        ResponseBase IsValid(User user);
    }
}
