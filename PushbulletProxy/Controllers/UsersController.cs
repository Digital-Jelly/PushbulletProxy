using PushbulletProxy.Core;
using PushbulletProxy.Core.Models;
using PushbulletProxy.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PushbulletProxy.Controllers
{
    /// <summary>
    /// Controller for managing operations related to Task 1 and Task 2, in the coding test.
    /// </summary>
    public class UsersController : BaseApiController
    {
        private readonly IUserManager userManager;

        public UsersController(ISettings settings, IUserManager userManager) : base(settings)
        {
            this.userManager = userManager;
        }

        // GET: api/pushbulletproxy/users
        public IEnumerable<UserResponse> Get()
        {
            return this.userManager.GetAllUsers().Select(x => new UserResponse
            {
                Username = x.Username,
                AccessToken = x.AccessToken,
                CreationTime = x.Created,
                NumOfNotificationsPushed = x.NumberOfNotificationsPushed
            });
        }

        // POST: api/pushbulletproxy/users
        public IHttpActionResult Post([FromBody]UserRequest request)
        {
            // Add the user - validation takes place within the UserManager object 
            var result = this.userManager.Add(request.Username, request.AccessToken);

            if (result.IsSuccess)
            {
                return Ok();
            }
            else
            {
                // See base class
                return this.HandleError(result.Error);
            }
        }

        // Could implement PUT method, to update the user's access token and DELETE method to remove the user
    }
}
