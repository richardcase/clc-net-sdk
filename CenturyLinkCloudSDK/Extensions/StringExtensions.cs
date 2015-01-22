﻿using System;

namespace CenturyLinkCloudSDK.Extensions
{
    public static class StringExtensions
    {
        public static string CreateDeserializableJsonString(this String jsonString)
        {
            var result = string.Format("{0}" + jsonString.Replace("{", "{{").Replace("}", "}}") + "{1}", "{ \"Response\":", "}");
            return result;
        }
    }
}
