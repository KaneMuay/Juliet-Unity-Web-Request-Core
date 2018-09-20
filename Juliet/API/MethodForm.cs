using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using JulietUtil.API;

namespace JulietUtil.API
{
    public class MethodForm
    {
        private const string TAG = "METFORM FORM";

        private string _url;
        private MethodType _methodType;
        private Dictionary<string, string> _post;
        private Dictionary<string, string> _postLogin;
        private string _get;
        private string _delete;
        private byte[] _put;
        private UnityWebRequest _request;
        private WWWForm patch;

        #region Getter Setter

        public string URL
        {
            get
            {
                return _url;
            }

            set
            {
                _url = value;
            }
        }

        public MethodType Method
        {
            get
            {
                return _methodType;
            }

            set
            {
                _methodType = value;
            }
        }
                
        public Dictionary<string, string> POSTLOGIN
        {
            get
            {
                return _postLogin;
            }

            set
            {
                _postLogin = value;

                _request = UnityWebRequest.Post(_url, _postLogin);

                if (JulietConfigure.Instance != null)
                {
                    if (JulietConfigure.Instance.isSupportOAuthBasic)
                        _request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                    foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.LoginHeaderConfig.Headers)
                    {
                        _request.SetRequestHeader(header.Key, header.Value);

                        JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                    }
                }
            }
        }

        public Dictionary<string, string> POST
        {
            get
            {
                return _post;
            }

            set
            {
                _post = value;

                _request = UnityWebRequest.Post(_url, _post);

                if (JulietConfigure.Instance != null)
                {
                    if (JulietConfigure.Instance.isSupportOAuthBasic)
                        _request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                    foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                    {
                        _request.SetRequestHeader(header.Key, header.Value);

                        JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                    }
                }
            }
        }

        public string GET
        {
            get
            {
                return _get;
            }

            set
            {
                _get = value;

                _request = UnityWebRequest.Get(_get);

                if (JulietConfigure.Instance != null)
                {
                    if (JulietConfigure.Instance.isSupportOAuthBasic)
                        _request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                    foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                    {
                        _request.SetRequestHeader(header.Key, header.Value);

                        JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                    }
                }
            }
        }

        public byte[] PUT
        {
            get
            {
                return _put;
            }

            set
            {
                _put = value;

                _request = UnityWebRequest.Put(_url, _put);

                if (JulietConfigure.Instance != null)
                {
                    if (JulietConfigure.Instance.isSupportOAuthBasic)
                        _request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                    foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                    {
                        _request.SetRequestHeader(header.Key, header.Value);

                        JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                    }
                }
            }
        }

        public WWWForm PATCH
        {
            get
            {
                return patch;
            }

            set
            {
                patch = value;
                _request = new UnityWebRequest(_url);

                if (JulietConfigure.Instance != null)
                {
                    if (JulietConfigure.Instance.isSupportOAuthBasic)
                        _request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                    foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                    {
                        _request.SetRequestHeader(header.Key, header.Value);

                        JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                    }
                }
            }
        }

        public string DELETE
        {
            get
            {
                return _delete;
            }

            set
            {
                _delete = value;

                _request = UnityWebRequest.Delete(_delete);

                if (JulietConfigure.Instance != null)
                {
                    if (JulietConfigure.Instance.isSupportOAuthBasic)
                        _request.SetRequestHeader(JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Key, JulietConfigure.Instance.JulietHeaderConfig.AuthorizationConfig.Value);

                    foreach (var header in JulietConfigure.Instance.JulietHeaderConfig.CommonHeaderConfig.Headers)
                    {
                        _request.SetRequestHeader(header.Key, header.Value);

                        JulietLogger.Info(TAG, header.Key + ", " + header.Value);
                    }
                }
            }
        }

        public UnityWebRequest WebRequest
        {
            get
            {
                return _request;
            }

            set
            {
                _request = value;
            }
        }

        #endregion
    }
}