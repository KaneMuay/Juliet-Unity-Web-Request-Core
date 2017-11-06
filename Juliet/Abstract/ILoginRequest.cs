using System;
using UnityEngine;
using JulietUtil.Request;

namespace JulietUtil.Abstract
{
    public abstract class ILoginRequest : BaseRequest
    {
        public abstract ILoginRequest SetURL(string url, MethodType methodType = MethodType.POST);
        public abstract ILoginRequest SetUsername(string username);
        public abstract ILoginRequest SetPassword(string password);
        public abstract ILoginRequest SetRefreshToken(string refreshToken);
    }
}