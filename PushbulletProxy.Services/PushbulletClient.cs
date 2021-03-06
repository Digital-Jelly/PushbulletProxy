﻿using PushbulletProxy.Core;
using PushbulletProxy.Core.ErrorHandling;
using PushbulletProxy.Core.Extensions;
using PushbulletProxy.Core.Http;
using PushbulletProxy.Core.Models;
using PushbulletProxy.Core.Services;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PushbulletProxy.Services
{
    /// <summary>
    /// Client for managing communications between the pushbullet proxy and the pushbullet service.
    /// </summary>
    public class PushbulletClient : IPushbulletClient
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ISettings settings;
        private readonly IUserManager userManager;

        public PushbulletClient(IHttpClientFactory httpClientFactory, ISettings settings, IUserManager userManager)
        {
            this.settings = settings;
            this.httpClientFactory = httpClientFactory;
            this.userManager = userManager;
        }

        public async Task<ResponseBase> SendNotificationAsync(User user, string message, string title = "")
        {
            var result = new ResponseBase();

            HttpClient client = null;

            // Send the notification
            try
            {
                client = this.httpClientFactory.Create(user.AccessToken);

                var payload = this.GetPayload(user, message, title);
                var response = await client.PostAsync(settings.PushbulletApiUrl, payload);

                // Increment the push counter
                this.userManager.RegisterPush(user.Username);
            }
            catch (HttpRequestException hre)
            {
                result.Error = new PushbulletMessageException("Failed to send notification (HTTP)", hre);
            }
            catch (TaskCanceledException tce)
            {
                result.Error = new PushbulletMessageException("Task was cancelled", tce);
            }
            catch (Exception ex)
            {
                result.Error = new PushbulletMessageException("Failed to send notification", ex);
            }
            finally
            {
                if (client != null)
                {
                    client.Dispose();
                    client = null;
                }
            }

            return new ResponseBase();
        }

        private StringContent GetPayload(User user, string message, string title = "")
        {
            var request = new SendPushbulletNotificationRequest
            {
                Type = "note",
                Title = title,
                Body = message
            };

            string payload = request.Serialize();

            return new StringContent(payload, Encoding.UTF8, "application/json");
        }
    }
}
