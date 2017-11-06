﻿using UnityEngine;
using System.Collections;
using System;
using JulietUtil.API;

namespace JulietUtil.Request
{
    public abstract class BaseRequest
    {
        public abstract void Send(Action<string> success, Action<string> fail);

        protected virtual string SetURLFormat(string url, object[] param)
        {
            int length = param.Length;
            string formatURL = "";

            // Hard code and wait for best solution to fix it
            switch (length)
            {
                case 1: formatURL = string.Format(url, param[0]); break;
                case 2: formatURL = string.Format(url, param[0], param[1]); break;
                case 3: formatURL = string.Format(url, param[0], param[1], param[2]); break;
                case 4: formatURL = string.Format(url, param[0], param[1], param[2], param[3]); break;
                case 5: formatURL = string.Format(url, param[0], param[1], param[2], param[3], param[4]); break;
                case 6: formatURL = string.Format(url, param[0], param[1], param[2], param[3], param[4], param[5]); break;
                case 7: formatURL = string.Format(url, param[0], param[1], param[2], param[3], param[4], param[5], param[6]); break;
                case 8: formatURL = string.Format(url, param[0], param[1], param[2], param[3], param[4], param[5], param[6], param[7]); break;
                case 9: formatURL = string.Format(url, param[0], param[1], param[2], param[3], param[4], param[5], param[6], param[7], param[8]); break;
            }

            return formatURL;
        }
    }
}