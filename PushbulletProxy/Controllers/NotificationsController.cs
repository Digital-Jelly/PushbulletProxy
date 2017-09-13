using PushbulletProxy.Core;
using PushbulletProxy.Core.Models;
using PushbulletProxy.Core.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace PushbulletProxy.Controllers
{
    /// <summary>
    /// Controller for managing operations related to Task 3, in the coding test.
    /// </summary>
    public class NotificationsController : BaseApiController
    {
        private readonly IUserManager userManager;
        private readonly IPushbulletClient pushbulletClient;

        public NotificationsController(ISettings settings, IUserManager userManager, IPushbulletClient pushbulletClient) : base(settings)
        {
            this.userManager = userManager;
            this.pushbulletClient = pushbulletClient;
        }

        // POST: api/pushbulletproxy/send
        public async Task<IHttpActionResult> Post([FromBody]NotificationRequest request)
        {
            var userResult = this.userManager.Get(request.Username);

            // User may not exist
            if (!userResult.IsSuccess)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(request.Title))
            {
                request.Title = "Title";
            }

            if (string.IsNullOrEmpty(request.Body))
            {
                request.Body = "This is a test";
            }

            // Construct request to push bullet
            var user = userResult.Result;
            var result = await this.pushbulletClient.SendNotificationAsync(user, request.Body, request.Title);

            if (result.IsSuccess)
            {
                return Ok(user);
            }
            else
            {
                // See base class
                return this.HandleError(result.Error);
            }
        }
    }
}
