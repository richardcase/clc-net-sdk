﻿using CenturyLinkCloudSDK.ServiceModels;
using CenturyLinkCloudSDK.ServiceModels.Requests.Authentication;
using CenturyLinkCloudSDK.ServiceModels.Responses.Authentication;
using CenturyLinkCloudSDK.Services.Runtime;
using System.Net.Http;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Services
{
    /// <summary>
    /// This class contains operations associated with user authentication.
    /// </summary>
    public class AuthenticationService : ServiceBase
    {

        internal AuthenticationService(){ }

        /// <summary>
        /// Use this operation before you call any other API operation. It authenticates a user and  
        /// returns the account alias a user's roles, the primary data center, and a valid bearer token.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>An asynchronous Task of UserInfo object.</returns>
        public async Task<UserInfo> Login(string username, string password)
        {
            var requestModel = new LoginRequest(){ UserName = username, Password = password };

            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = Constants.ServiceUris.Authentication.Login,
                RequestModel = requestModel,
                HttpMethod = HttpMethod.Post
            };

            var result = await Invoke<ServiceRequest, LoginResponse>(serviceRequest).ConfigureAwait(false);

            if (result == null)
            {
                return null;
            }

            var response = result.Response;

            if (response == null)
            {
                return null;
            }

            return response;
        }
    }
}
