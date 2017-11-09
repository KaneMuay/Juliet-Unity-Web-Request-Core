using System;
using UnityEngine;
using JulietUtil.Request;

namespace JulietUtil.Abstract
{
    public abstract class ILoginRequest : BaseRequest
    {
        public abstract ILoginRequest SetURL(string url, MethodType methodType = MethodType.POST);
        public abstract ILoginRequest SetUsername(string key, string value);
        public abstract ILoginRequest SetPassword(string key, string value);
        public abstract ILoginRequest SetEventAttribute(string key, object value);
    }
}