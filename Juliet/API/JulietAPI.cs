using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Net;

using JulietUtil.Interface;

namespace JulietUtil.API
{
    public class JulietAPI : MonoBehaviour, IJulietAPI
    {
        #region Instance

        private static JulietAPI _instance;

        public static JulietAPI Instance
        {
            get
            {
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;
        }

        #endregion

        private const string TAG = "API";

        public void Request(MethodForm methodForm, Action<string> successCallback, Action<string> failCallback)
        {
            StartCoroutine(Connecting(methodForm, successCallback, failCallback));
        }

        public IEnumerator Connecting(MethodForm methodForm, Action<string> successCallback, Action<string> failCallback)
        {
            JulietLogger.Info(TAG, "Connecting to ... " + methodForm.WebRequest.url);

            using (UnityWebRequest www = methodForm.WebRequest)
            {
                JulietLogger.Info(TAG, "Wating for Response ... ");

                yield return www.SendWebRequest();

                JulietLogger.Info(TAG, "Responsed from Server ... ");

                if (!www.isNetworkError)
                {
                    long code = www.responseCode;
                    JulietLogger.Info(TAG, "Http Status Code " + code);

                    switch (code)
                    {
                        case 200:

                            JulietLogger.Info(TAG, "Successed Responsed ... " + www.downloadHandler.text);

                            successCallback(www.downloadHandler.text);
                            break;

                        default:
                            string jsonFormat = "{ \"Status\":" + code + ", \"Message\": \"" + www.error + " \"}";

                            JulietLogger.Info(TAG, "Failed Responsed  ... " + jsonFormat);

                            failCallback(jsonFormat);

                            break;
                    }
                }
                else
                {
                    string jsonFormat = "{ \"Status\": \"" + 500 + " \", \"Message\": \"" + www.error + " \"}";

                    JulietLogger.Info(TAG, "Internal Server Failed Responsed  ... " + jsonFormat);

                    failCallback(jsonFormat);
                }
            }
        }
    }
}