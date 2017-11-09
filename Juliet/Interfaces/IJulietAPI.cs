using System;
using System.Collections;
using JulietUtil.API;
using UnityEngine;

namespace JulietUtil.Interface
{
    interface IJulietAPI
    {
        /// <summary>
        /// Request for Text Type
        /// </summary>
        /// <param name="methodForm"></param>
        /// <param name="success"></param>
        /// <param name="fail"></param>
        void Request(MethodForm methodForm, Action<string> success, Action<string> fail);
        IEnumerator Connecting(MethodForm methodForm, Action<string> success, Action<string> fail);
        
        /// <summary>
        /// Request for Texture Type
        /// </summary>
        /// <param name="methodForm"></param>
        /// <param name="success"></param>
        /// <param name="fail"></param>
        void Request(MethodForm methodForm, Action<Texture> success, Action<string> fail);
        IEnumerator Connecting(MethodForm methodForm, Action<Texture> success, Action<string> fail);
    }
}
