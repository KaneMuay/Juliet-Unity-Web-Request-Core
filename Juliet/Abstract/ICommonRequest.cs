using JulietUtil.Request;
using System;

namespace JulietUtil.Abstract
{
    public abstract class ICommonRequest : BaseRequest
    {
        public abstract ICommonRequest SetURL(string url, MethodType methodType = MethodType.GET);
        public abstract ICommonRequest SetURL(string url, MethodType methodType = MethodType.GET, params object[] param);
        public abstract ICommonRequest SetEventAttribute(string key, object value);
        public abstract ICommonRequest SetEventImageAttribute(string key, ImageType values);
        public abstract void SendWithImage(Action<string> success, Action<string> fail);
    }
}