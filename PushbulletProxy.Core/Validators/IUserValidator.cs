using PushbulletProxy.Core.Models;

namespace PushbulletProxy.Core.Validators
{
    public interface IUserValidator
    {
        ResponseBase IsValid(User user);
    }
}
