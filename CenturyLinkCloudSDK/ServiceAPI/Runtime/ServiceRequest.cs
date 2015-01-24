﻿using System.Net.Http;

namespace CenturyLinkCloudSDK.ServiceAPI.Runtime
{
    /// <summary>
    /// This is the base class all service requests must inherit from.
    /// </summary>
    public class ServiceRequest
    {
        public string BaseAddress { get; set; }

        public string  ServiceUri { get; set; }

        public string MediaType { get; set; }

        public ServiceRequestModel RequestModel { get; set; }

        public HttpMethod HttpMethod { get; set; }
    }
}
