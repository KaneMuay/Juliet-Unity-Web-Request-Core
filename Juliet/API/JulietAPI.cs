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
        #region Singleton

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

        public void Request(MethodForm methodForm, Action<Texture> successCallback, Action<string> failCallback)
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

                try
                {
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
                                string errorFormat = "{ \"Status\":" + code + ", \"Message\": \"" + www.error + " \"}";

                                JulietLogger.Info(TAG, "Failed Responsed  ... " + errorFormat);

                                failCallback(errorFormat);

                                break;
                        }
                    }
                    else
                    {
                        string errorFormat = "{ \"Status\":" + 500 + ", \"Message\": \"" + www.error + " \"}";

                        JulietLogger.Info(TAG, "Internal Server Failed Responsed  ... " + errorFormat);

                        failCallback(errorFormat);
                    }
                }
                catch (WebException ex)
                {
                    JulietLogger.Info(TAG, "Error Web Exception " + ex.Message);

                    string errorFormat = "";

                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        if (ex.Response is HttpWebResponse response)
                        {
                            errorFormat = "{ \"Status\":" + (int)response.StatusCode + ", \"Message\": \"" + www.error + " \"}";

                            failCallback(errorFormat);
                        }
                        else
                        {
                            errorFormat = "{ \"Status\":" + 400 + ", \"Message\": \"" + www.error + " \"}";
                        }
                    }
                    else
                    {
                        errorFormat = "{ \"Status\":" + 400 + ", \"Message\": \"" + www.error + " \"}";
                    }

                    failCallback(errorFormat);
                }
                catch (Exception ex)
                {
                    JulietLogger.Info(TAG, "Error Web Exception " + ex.Message);

                    string  errorFormat = "{ \"Status\":" + 400 + ", \"Message\": \"" + www.error + " \"}";

                    failCallback(errorFormat);
                }
            }
        }

        public IEnumerator Connecting(MethodForm methodForm, Action<Texture> successCallback, Action<string> failCallback)
        {
            JulietLogger.Info(TAG, "Connecting to ... " + methodForm.URL);

            Uri uri = new Uri(methodForm.URL);
            UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);

            yield return www.SendWebRequest();
            
            try
            {
                if (www.isNetworkError || www.isHttpError)
                {
                    string errorFormat = string.Format(JulietShareVariable.FORMAT_ERROR, www.responseCode, www.error);

                    JulietLogger.Info(TAG, "Failed Responsed  ... " + errorFormat);

                    failCallback(errorFormat);
                }
                else
                {
                    JulietLogger.Info(TAG, "Successed Responsed");

                    Texture texture = ((DownloadHandlerTexture)www.downloadHandler).texture;

                    successCallback(texture);
                }
            }
            catch (WebException ex)
            {
                JulietLogger.Info(TAG, "Error Web Exception " + ex.Message);

                string errorFormat = "";

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    if (ex.Response is HttpWebResponse response)
                    {
                        errorFormat = "{ \"Status\":" + (int)response.StatusCode + ", \"Message\": \"" + www.error + " \"}";

                        failCallback(errorFormat);
                    }
                    else
                    {
                        errorFormat = "{ \"Status\":" + 400 + ", \"Message\": \"" + www.error + " \"}";
                    }
                }
                else
                {
                    errorFormat = "{ \"Status\":" + 400 + ", \"Message\": \"" + www.error + " \"}";
                }

                failCallback(errorFormat);
            }
            catch (Exception ex)
            {
                JulietLogger.Info(TAG, "Error Web Exception " + ex.Message);

                string errorFormat = "{ \"Status\":" + 400 + ", \"Message\": \"" + www.error + " \"}";

                failCallback(errorFormat);
            }
        }
        
    }
}