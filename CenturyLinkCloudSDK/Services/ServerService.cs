﻿using CenturyLinkCloudSDK.Services.Runtime;
using CenturyLinkCloudSDK.ServiceModels.Common;
using CenturyLinkCloudSDK.ServiceModels.Servers.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.Services
{
    /// <summary>
    /// This class contains operations associated with servers.
    /// </summary>
    public class ServerService: ServiceBase
    {
        private AuthenticationInfo userAuthentication;
        public ServerService(AuthenticationInfo userAuthentication)
        {
            this.userAuthentication = userAuthentication;
        }

        /// <summary>
        /// Gets the details for a individual server.
        /// Use this operation when you want to find out all the details for a server. 
        /// It can be used to look for changes, its status, or to retrieve links to associated resources.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverId"></param>
        /// <returns>An asynchronous Task of Server.</returns>
        public async Task<Server> GetServer(string serverId)
        {
            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = string.Format("https://api.tier3.com/v2/servers/{0}/{1}", userAuthentication.AccountAlias, serverId),
                BearerToken = userAuthentication.BearerToken,
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await Invoke<ServiceRequest, GetServerResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as Server;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Gets the details for a individual server by hypermedia link.
        /// Use this operation when you want to find out all the details for a server. 
        /// It can be used to look for changes, its status, or to retrieve links to associated resources. 
        /// </summary>
        /// <param name="hypermediaLink"></param>
        /// <returns>An asynchronous Task of Server.</returns>
        public async Task<Server> GetServerByHypermediaLink(string hypermediaLink)
        {
            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = Constants.ApiBaseAddress + hypermediaLink,
                BearerToken = userAuthentication.BearerToken,
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await Invoke<ServiceRequest, GetServerResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as Server;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the pause operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to pause a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the pause command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns>An asynchronous Task of IEnumerable of ServerOperation.</returns>
        public async Task<IEnumerable<ServerOperation>> PauseServer(List<string> serverIds)
        {
            var requestModel = new ServiceRequestModel() { UnNamedArray = serverIds.ToArray() };

            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/servers/pause", userAuthentication.AccountAlias),
                BearerToken = userAuthentication.BearerToken,
                RequestModel = requestModel,
                HttpMethod = HttpMethod.Post
            };

            var result = await Invoke<ServiceRequest, ServerPowerOpsResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as IEnumerable<ServerOperation>;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the power on operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to power on a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the power on command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns>An asynchronous Task of IEnumerable of ServerOperation.</returns>
        public async Task<IEnumerable<ServerOperation>> PowerOnServer(List<string> serverIds)
        {
            var requestModel = new ServiceRequestModel() { UnNamedArray = serverIds.ToArray() };

            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/servers/powerOn", userAuthentication.AccountAlias),
                BearerToken = userAuthentication.BearerToken,
                RequestModel = requestModel,
                HttpMethod = HttpMethod.Post
            };

            var result = await Invoke<ServiceRequest, ServerPowerOpsResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as IEnumerable<ServerOperation>;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the power off operation to a list of servers and adds operation to queue. 
        /// Use this operation when you want to power off a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the power off command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns>An asynchronous Task of IEnumerable of ServerOperation.</returns>
        public async Task<IEnumerable<ServerOperation>> PowerOffServer(List<string> serverIds)
        {
            var requestModel = new ServiceRequestModel() { UnNamedArray = serverIds.ToArray() };

            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/servers/powerOff", userAuthentication.AccountAlias),
                BearerToken = userAuthentication.BearerToken,
                RequestModel = requestModel,
                HttpMethod = HttpMethod.Post
            };

            var result = await Invoke<ServiceRequest, ServerPowerOpsResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as IEnumerable<ServerOperation>;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the reboot operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to reboot a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the reboot command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns>An asynchronous Task of IEnumerable of ServerOperation.</returns>
        public async Task<IEnumerable<ServerOperation>> RebootServer(List<string> serverIds)
        {
            var requestModel = new ServiceRequestModel() { UnNamedArray = serverIds.ToArray() };

            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/servers/reboot", userAuthentication.AccountAlias),
                BearerToken = userAuthentication.BearerToken,
                RequestModel = requestModel,
                HttpMethod = HttpMethod.Post
            };

            var result = await Invoke<ServiceRequest, ServerPowerOpsResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as IEnumerable<ServerOperation>;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the shut down operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to shut down a single server or group of servers. 
        /// It should be used in conjunction with the Queue GetStatus operation to check the result of the shut down command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns>An asynchronous Task of IEnumerable of ServerOperation.</returns>
        public async Task<IEnumerable<ServerOperation>> ShutDownServer(List<string> serverIds)
        {
            var requestModel = new ServiceRequestModel() { UnNamedArray = serverIds.ToArray() };

            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/servers/shutDown", userAuthentication.AccountAlias),
                BearerToken = userAuthentication.BearerToken,
                RequestModel = requestModel,
                HttpMethod = HttpMethod.Post
            };

            var result = await Invoke<ServiceRequest, ServerPowerOpsResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as IEnumerable<ServerOperation>;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Sends the reset operation to a list of servers and adds operation to queue.
        /// Use this operation when you want to reset a single server or group of servers. 
        /// It should be used in conjunction with the  Queue GetStatus operation to check the result of the reset command.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="serverIds"></param>
        /// <returns>An asynchronous Task of IEnumerable of ServerOperation.</returns>
        public async Task<IEnumerable<ServerOperation>> ResetServer(List<string> serverIds)
        {
            var requestModel = new ServiceRequestModel() { UnNamedArray = serverIds.ToArray() };

            var serviceRequest = new ServiceRequest()
            {
                ServiceUri = string.Format("https://api.tier3.com/v2/operations/{0}/servers/reset", userAuthentication.AccountAlias),
                BearerToken = userAuthentication.BearerToken,
                RequestModel = requestModel,
                HttpMethod = HttpMethod.Post
            };

            var result = await Invoke<ServiceRequest, ServerPowerOpsResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as IEnumerable<ServerOperation>;
                return response;
            }

            return null;
        }
    }
}