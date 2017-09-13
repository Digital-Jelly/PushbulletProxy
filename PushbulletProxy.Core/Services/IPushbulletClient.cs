using PushbulletProxy.Core.Models;
using System.Threading.Tasks;

namespace PushbulletProxy.Core.Services
{
    /// <summary>
    /// Client for managing communications between the pushbullet proxy and the pushbullet service.
    /// </summary>
    public interface IPushbulletClient
    {
        Task<ResponseBase> SendNotificationAsync(User user, string message, string title = "");
    }
}
