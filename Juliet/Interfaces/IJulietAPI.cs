using System;
using System.Collections;
using JulietUtil.API;

namespace JulietUtil.Interface
{
    interface IJulietAPI
    {
        void Request(MethodForm methodForm, Action<string> success, Action<string> fail);
        IEnumerator Connecting(MethodForm methodForm, Action<string> success, Action<string> fail);
    }
}
