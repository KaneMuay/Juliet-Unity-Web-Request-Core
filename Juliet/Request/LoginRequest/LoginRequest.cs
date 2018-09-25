using JulietUtil.Abstract;
using JulietUtil.API;
using System;
using System.Collections.Generic;

namespace JulietUtil.Request
{
    public class LoginRequest : ILoginRequest
    {
        private string TAG = "LOGIN REQUEST";
        
        private Dictionary<string, object> attributes = new Dictionary<string, object>();

        private MethodType methodType = MethodType.POST;

        private string url;

        private string usernameKey;
        private string usernameValue;

        private string passwordKey;
        private string passwordValue;

        public override ILoginRequest SetURL(string url, MethodType methodType = MethodType.POST)
        {
            this.url = url;
            this.methodType = methodType;

            JulietLogger.Info(TAG, "Url " + this.url);
            JulietLogger.Info(TAG, "MethodType " + this.methodType);

            return this;
        }

        public override ILoginRequest SetUsername(string key, string value)
        {
            this.usernameKey = key;
            this.usernameValue = value;

            JulietLogger.Info(TAG, "SetUsername " + this.usernameKey + ", " + this.usernameValue);

            return this;
        }

        public override ILoginRequest SetPassword(string key, string value)
        {
            this.passwordKey = key;
            this.passwordValue = value;

            JulietLogger.Info(TAG, "SetPassword " + this.passwordKey + ", " + this.passwordValue);

            return this;
        }

        public override ILoginRequest SetEventAttribute(string key, object value)
        {
            this.attributes.Add(key, value);

            JulietLogger.Info(TAG, "Key " + key + ", Value " + value);

            return this;
        }

        public override void Send(Action<string> success, Action<string> fail)
        {
            JulietLogger.Info(TAG, "Send");

            Dictionary<string, string> content = new Dictionary<string, string>
            {
                { this.usernameKey, this.usernameValue },
                { this.passwordKey, this.passwordValue }
            };

            foreach (var attribute in attributes)
            {
                string key = attribute.Key;
                string value = (string)attribute.Value;

                content.Add(key, value);
            }

            MethodForm form = new MethodForm()
            {
                Method = this.methodType,
                URL = this.url,
                POSTLOGIN = content
            };
            
            JulietAPI.Instance.Request(form, success, fail);
        }
    }
}