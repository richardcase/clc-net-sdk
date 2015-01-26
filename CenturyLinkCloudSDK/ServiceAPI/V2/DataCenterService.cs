﻿using CenturyLinkCloudSDK.ServiceAPI.Runtime;
using CenturyLinkCloudSDK.ServiceModels.V2.Common;
using CenturyLinkCloudSDK.ServiceModels.V2.DataCenters.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.ServiceAPI.V2
{
    /// <summary>
    /// This class contains operations associated with data centers.
    /// </summary>
    public class DataCenterService: ServiceBase
    {
        /// <summary>
        /// Gets the list of data centers that a given account has access to. 
        /// Use this operation when you need the list of data center names and codes that you have access to. 
        /// Using that list of data centers, you can then query for the root group, and all the child groups in an entire data center.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <returns>An asynchronous Task of IEnumerable of DataCenter.</returns>
        public async Task<IEnumerable<DataCenter>> GetDataCenters(string accountAlias)
        {
            var serviceRequest = new ServiceRequest()
            {
                BaseAddress = Constants.API_BASE_ADDRESS,
                ServiceUri = string.Format("https://api.tier3.com/v2/datacenters/{0}", accountAlias),
                MediaType = "application/json",
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await Invoke<ServiceRequest, GetDataCentersResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as IEnumerable<DataCenter>;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Gets the information for a particular data center by accepting an account alias and data center id.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="dataCenter"></param>
        /// <returns>An asynchronous Task of DataCenter.</returns>
        public async Task<DataCenter> GetDataCenter(string accountAlias, string dataCenter)
        {
            var serviceRequest = new ServiceRequest()
            {
                BaseAddress = Constants.API_BASE_ADDRESS,
                ServiceUri = string.Format("https://api.tier3.com/v2/datacenters/{0}/{1}", accountAlias, dataCenter),
                MediaType = "application/json",
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await Invoke<ServiceRequest, GetDataCenterResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as DataCenter;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Gets the information for a particular data center by accepting a hypermedia link.
        /// </summary>
        /// <param name="hypermediaLink"></param>
        /// <returns>An asynchronous Task of DataCenter.</returns>
        public async Task<DataCenter> GetDataCenter(string hypermediaLink)
        {
            var serviceRequest = new ServiceRequest()
            {
                BaseAddress = Constants.API_BASE_ADDRESS,
                ServiceUri = Constants.API_BASE_ADDRESS + hypermediaLink,
                MediaType = "application/json",
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await Invoke<ServiceRequest, GetDataCenterResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as DataCenter;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Gets the full hierarchy of groups that exist within a particular account and data center. 
        /// Use this operation when you want to discover the name of the root hardware group for a data center. 
        /// Once you have that group alias, you can issue a secondary query to retrieve the entire group hierarchy for a given data center.
        /// </summary>
        /// <param name="accountAlias"></param>
        /// <param name="dataCenter"></param>
        /// <returns>An asynchronous Task of DataCenterGroup</returns>
        public async Task<DataCenterGroup> GetDataCenterGroup(string accountAlias, string dataCenter)
        {
            var serviceRequest = new ServiceRequest()
            {
                BaseAddress = Constants.API_BASE_ADDRESS,
                ServiceUri = string.Format("https://api.tier3.com/v2/datacenters/{0}/{1}?groupLinks=true", accountAlias, dataCenter),
                MediaType = "application/json",
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await Invoke<ServiceRequest, GetDataCenterGroupsResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as DataCenterGroup;
                return response;
            }

            return null;
        }

        /// <summary>
        /// Gets the full hierarchy of groups that exist within a particular account and data center by a hypermedia link. 
        /// Use this operation when you want to discover the name of the root hardware group for a data center. 
        /// Once you have that group alias, you can issue a secondary query to retrieve the entire group hierarchy for a given data center.
        /// </summary>
        /// <param name="hypermediaLink"></param>
        /// <returns>An asynchronous Task of DataCenterGroup</returns>
        public async Task<DataCenterGroup> GetDataCenterGroup(string hypermediaLink)
        {
            var serviceRequest = new ServiceRequest()
            {
                BaseAddress = Constants.API_BASE_ADDRESS,
                ServiceUri = Constants.API_BASE_ADDRESS + hypermediaLink + "?groupLinks=true",
                MediaType = "application/json",
                RequestModel = null,
                HttpMethod = HttpMethod.Get
            };

            var result = await Invoke<ServiceRequest, GetDataCenterGroupsResponse>(serviceRequest).ConfigureAwait(false);

            if (result != null)
            {
                var response = result.Response as DataCenterGroup;
                return response;
            }

            return null;
        }
    }
}