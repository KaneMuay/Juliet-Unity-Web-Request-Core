using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using JulietUtil.API;

namespace JulietUtil.API
{
    public class MethodForm
    {
        private const string TAG = "Method Form";

        private string url;
        private MethodType methodType;
        private Dictionary<string, string> post;
        private string get;
        private string delete;
        private byte[] put;
        private UnityWebRequest request;
        private UserAction action = UserAction.Common;
        private WWWForm patch;

        #region Getter Setter

        public string URL
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public MethodType Method
        {
            get
            {
                return methodType;
            }

            set
            {
                methodType = value;
            }
        }

        public UserAction Action
        {
            get
            {
                return action;
            }

            set
            {
                action = value;
            }
        }

        public Dictionary<string, string> Post
        {
            get
            {
                return post;
            }

            set
            {
                JulietLogger.Info(TAG, "Action " + Action);
                JulietLogger.Info(TAG, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key + 
                    ", " + JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);


                post = value;

                request = UnityWebRequest.Post(url, post);

                request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                if (Action == UserAction.Login)
                {
                    foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.LoginHeaderConfig.Headers)
                    {
                        request.SetRequestHeader(header.Key, header.Value);

                        JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                    }
                }
                else
                {
                    foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                    {
                        request.SetRequestHeader(header.Key, header.Value);

                        JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                    }
                }
            }
        }

        public string Get
        {
            get
            {
                return get;
            }

            set
            {
                JulietLogger.Info(TAG, "GET " + value);

                get = value;

                request = UnityWebRequest.Get(get);
                request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                {
                    request.SetRequestHeader(header.Key, header.Value);

                    JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                }
            }
        }

        public byte[] Put
        {
            get
            {
                return put;
            }

            set
            {
                JulietLogger.Info(TAG, "PUT " + value);

                put = value;

                request = UnityWebRequest.Put(url, put);
                request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                {
                    request.SetRequestHeader(header.Key, header.Value);

                    JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                }
            }
        }

        public WWWForm Patch
        {
            get
            {
                return patch;
            }

            set
            {
                JulietLogger.Info(TAG, "PATCH " + value.ToString());

                patch = value;
                request = new UnityWebRequest(url);
                request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                {
                    request.SetRequestHeader(header.Key, header.Value);

                    JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                }

            }
        }

        public string Delete
        {
            get
            {
                return delete;
            }

            set
            {
                JulietLogger.Info(TAG, "PATCH " + value);

                delete = value;

                request = UnityWebRequest.Delete(delete);
                request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                {
                    request.SetRequestHeader(header.Key, header.Value);

                    JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                }
            }
        }

        public UnityWebRequest WebRequest
        {
            get
            {
                return request;
            }

            set
            {
                request = value;
            }
        }

        #endregion
    }
}