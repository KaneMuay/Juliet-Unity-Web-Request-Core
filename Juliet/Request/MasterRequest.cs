using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JulietUtil.Interface;
using JulietUtil.Abstract;

namespace JulietUtil.Request
{
    public class MasterRequest : IMasterRequest
    {
        private string TAG = "Request";

        public ILoginRequest LoginRequest()
        {
            JulietLogger.Info(TAG, "Initial Login");

            return new LoginRequest();
        }

        public ICommonRequest CommonRequest()
        {
            JulietLogger.Info(TAG, "Initial Common");

            return new CommonRequest();
        }
    }
}