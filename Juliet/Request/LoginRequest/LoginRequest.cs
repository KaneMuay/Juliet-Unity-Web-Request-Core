using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JulietUtil.Abstract;
using JulietUtil.API;

namespace JulietUtil.Request
{
    public class LoginRequest : ILoginRequest
    {
        private string TAG = "Login";

        private const string USERNAME = "username";
        private const string PASSWORD = "password";
        private const string REFRESH_TOKEN = "refreshToken";

        private MethodType methodType = MethodType.POST;
        private string url;
        private string username;
        private string password;
        private string refreshToken;

        public override ILoginRequest SetURL(string url, MethodType methodType = MethodType.POST)
        {
            this.url = url;
            this.methodType = methodType;

            JulietLogger.Info(TAG, "Url " + this.url);
            JulietLogger.Info(TAG, "MethodType " + this.methodType);

            return this;
        }

        public override ILoginRequest SetUsername(string username)
        {
            this.username = username;

            JulietLogger.Info(TAG, "SetUsername " + this.username);

            return this;
        }

        public override ILoginRequest SetPassword(string password)
        {
            this.password = password;

            JulietLogger.Info(TAG, "SetPassword " + this.password);

            return this;
        }

        public override ILoginRequest SetRefreshToken(string refreshToken)
        {
            this.refreshToken = refreshToken;

            JulietLogger.Info(TAG, "SetRefreshToken " + this.refreshToken);

            return this;
        }

        public override void Send(Action<string> success, Action<string> fail)
        {
            JulietLogger.Info(TAG, "Send");

            Dictionary<string, string> content = new Dictionary<string, string>
            {
                { USERNAME, this.username },
                { PASSWORD, this.password },
                { REFRESH_TOKEN, this.refreshToken}
            };

            MethodForm form = new MethodForm()
            {
                Method = this.methodType,
                URL = this.url,
                Action = UserAction.Login,
                Post = content
            };
            
            JulietAPI.Instance.Request(form, success, fail);
        }
    }
}