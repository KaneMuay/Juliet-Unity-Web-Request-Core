using JulietUtil.API;
using JulietUtil.Interface;
using JulietUtil.Request;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace JulietUtil.Master
{
    public class Juliet
    {
        private string TAG = "JULIET";
        public const string API_JULIET = "JulietAPI";

        public Juliet()
        {
            JulietLogger.Info(TAG, "Create Juliet API");

            // Create instance to use API
            GameObject api = new GameObject(API_JULIET);
            api.AddComponent<JulietAPI>();
            api.name = API_JULIET;
        }

        public Juliet(DebugMode mode)
        {
            JulietLogger.DebugMode = mode;

            JulietLogger.Info(TAG, "Create Juliet API");

            // Create instance to use API
            GameObject api = new GameObject(API_JULIET);
            api.AddComponent<JulietAPI>();
            api.name = API_JULIET;
        }

        public IMasterRequest Request
        {
            get
            {
                return new MasterRequest();
            }
        }
    }
}