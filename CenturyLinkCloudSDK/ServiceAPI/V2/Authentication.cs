﻿using CenturyLinkCloudSDK.ServiceAPI.Runtime;
using CenturyLinkCloudSDK.ServiceModels.V2.Authentication.Requests;
using CenturyLinkCloudSDK.ServiceModels.V2.Authentication.Responses;
using CenturyLinkCloudSDK.ServiceModels.V2.Common;
using System.Net.Http;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.ServiceAPI.V2
{
    public class Authentication : ServiceAPIBase
    {
        public async Task<UserInfo> Login(string username, string password)
        {
            var requestModel = new LoginRequest(){ UserName = username, Password = password };

            var serviceRequest = new ServiceRequest()
            {
                BaseAddress = "https://api.tier3.com/",
                ServiceUri = "https://api.tier3.com/v2/authentication/login",
                MediaType = "application/json",
                RequestModel = requestModel,
                HttpMethod = HttpMethod.Post
            };

            var result = await Invoke<ServiceRequest, LoginResponse>(serviceRequest).ConfigureAwait(false);

            if (result == null)
            {
                Persistence.UserInfo = null;
                return null;
            }

            var response = result.Response as UserInfo;

            if (response.BearerToken == null)
            {
                Persistence.UserInfo = null;
                return null;
            }

            Persistence.UserInfo = new UserInfo();
            Persistence.UserInfo.BearerToken = response.BearerToken;
            Persistence.UserInfo.AccountAlias = response.AccountAlias;
            Persistence.UserInfo.Roles = response.Roles;

            return response;
        }
    }
}
