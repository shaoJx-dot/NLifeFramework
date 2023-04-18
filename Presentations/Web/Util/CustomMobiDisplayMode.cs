using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.WebPages;

namespace DeviceAdapter.Util
{
    public class CustomMobileDisplayMode : DefaultDisplayMode
    {
        private static readonly List<string> _excludedDevices = new List<string> { "Opera Mobi", "Mobile" };
        public CustomMobileDisplayMode()
            : base("Mobile")
        {
            ContextCondition = (context => IsMobile(context.GetOverriddenUserAgent()));
        }
        public static bool IsMobile(string useragentString)
        {
            return _excludedDevices.Select(excluded => useragentString.IndexOf(excluded, StringComparison.InvariantCultureIgnoreCase)).Any(index => index >= 0);
        }
    }
}