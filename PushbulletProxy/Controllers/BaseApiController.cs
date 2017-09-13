using PushbulletProxy.Core;
using PushbulletProxy.Core.ErrorHandling;
using System;
using System.Web.Http;

namespace PushbulletProxy.Controllers
{
    /// <summary>
    /// Base class for api controllers
    /// </summary>
    public class BaseApiController : ApiController
    {
        private readonly ISettings settings;

        public BaseApiController(ISettings settings) : base()
        {
            this.settings = settings;
        }

        /// <summary>
        /// Detect error type and return result accordingly. All non-pushbullet related exceptions
        /// are handled as internal server errors.
        /// </summary>
        /// <param name="error">The error that occurred</param>
        /// <returns>IHttpActionResult</returns>
        protected IHttpActionResult HandleError(Exception error)
        {
            if (error is PushbulletUserException)
            {
                return BadRequest(error.Message);
            }
            else if (error is PushbulletMessageException)
            {
                return BadRequest(error.Message);
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}