﻿using CenturyLinkCloudSDK.ServiceModels.V2.Common;
using System;

namespace CenturyLinkCloudSDK.ServiceAPI.Runtime
{
    public static class Persistence
    {
        private static Lazy<bool> isUserAuthenticated = new Lazy<bool>(() => false);
        private static Lazy<UserInfo> userInfo = null;

        public static UserInfo UserInfo 
        {
            get { return userInfo.Value; }

            set 
            {
                userInfo = new Lazy<UserInfo>(() => value);

                if (value != null)
                {
                    isUserAuthenticated = new Lazy<bool>(() => true);
                }
                else
                {
                    isUserAuthenticated = new Lazy<bool>(() => false);                    
                }
            }
        }

        public static bool IsUserAuthenticated
        {
            get { return isUserAuthenticated.Value; }
        }
    }
}
