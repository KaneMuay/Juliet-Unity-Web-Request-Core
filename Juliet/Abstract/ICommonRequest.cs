using System;
using UnityEngine;
using JulietUtil.Request;

namespace JulietUtil.Abstract
{
    public abstract class ICommonRequest : BaseRequest
    {
        public abstract ICommonRequest SetURL(string url, MethodType methodType = MethodType.GET);
        public abstract ICommonRequest SetURL(string url, MethodType methodType = MethodType.GET, params object[] param);
        public abstract ICommonRequest SetEventAttribute(string key, object value);
    }
}