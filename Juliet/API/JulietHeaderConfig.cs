using System.Collections.Generic;
using UnityEngine;

namespace JulietUtil.API
{
    [System.Serializable]
    public class JulietHeaderConfig
    {
        public Header AuthorizationConfig;
        public HeaderConfig LoginHeaderConfig;
        public HeaderConfig CommonHeaderConfig;
    }

    [System.Serializable]
    public class HeaderConfig
    {
        public List<Header> Headers = new List<Header>();
    }

    [System.Serializable]
    public class Header
    {
        public string Key;
        public string Value;
    }
}