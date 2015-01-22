﻿using System.Collections.Generic;

namespace CenturyLinkCloudSDK.ServiceModels.V2.Common
{
    public class ServerGroup
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Link> Links { get; set; }
    }
}