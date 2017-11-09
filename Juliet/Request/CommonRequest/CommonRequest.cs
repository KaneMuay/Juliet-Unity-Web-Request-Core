
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JulietUtil.Abstract;
using JulietUtil.API;

namespace JulietUtil.Request
{
    public class CommonRequest : ICommonRequest
    {
        private const string TAG = "COMMON REQUEST";

        private MethodType methodType = MethodType.POST;
        private string url;
        private Dictionary<string, object> attributes = new Dictionary<string, object>();
        
        public override ICommonRequest SetURL(string url, MethodType methodType = MethodType.GET)
        {
            this.url = url;
            this.methodType = methodType;

            JulietLogger.Info(TAG, "Url " + this.url);
            JulietLogger.Info(TAG, "MethodType " + this.methodType);

            return this;
        }

        public override ICommonRequest SetURL(string url, MethodType methodType = MethodType.GET, params object[] param)
        {
            this.url = url;

            JulietLogger.Info(TAG, "Url " + this.url);

            this.url = SetURLFormat(url, param);
            this.methodType = methodType;

            JulietLogger.Info(TAG, "Url format " + this.url);
            JulietLogger.Info(TAG, "MethodType " + this.methodType);

            return this;
        }

        public override ICommonRequest SetEventAttribute(string key, object value)
        {
            this.attributes.Add(key, value);

            JulietLogger.Info(TAG, "Key " + key + ", Value " + value);

            return this;
        }

        public override void Send(Action<string> success, Action<string> fail)
        {
            JulietLogger.Info(TAG, "Send ");

            MethodForm form = new MethodForm()
            {
                Method = this.methodType,
                URL = this.url
            };

            switch (this.methodType)
            {
                case MethodType.POST:

                    Dictionary<string, string> contentPost = new Dictionary<string, string>();
                    
                    foreach (var attribute in attributes)
                    {
                        string key = attribute.Key;
                        string value = (string)attribute.Value;

                        contentPost.Add(key, value);
                    }

                    form.POST = contentPost;

                    break;
                case MethodType.GET:
                    
                    form.GET = this.url;

                    break;
                case MethodType.PUT:

                    Dictionary<string, string> contentPut = new Dictionary<string, string>();

                    foreach (var attribute in attributes)
                    {
                        string key = attribute.Key;
                        string value = (string)attribute.Value;

                        contentPut.Add(key, value);
                    }

                    string jsonPut = JsonUtility.ToJson(contentPut);

                    form.PUT = System.Text.Encoding.UTF8.GetBytes(jsonPut);

                    break;
                case MethodType.DELETE:
                    
                    form.DELETE = this.url;

                    break;
            }

            JulietAPI.Instance.Request(form, success, fail);
        }
    }
}