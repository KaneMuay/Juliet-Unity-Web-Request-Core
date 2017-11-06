﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JulietUtil.Abstract;

namespace JulietUtil.Interface
{
    public interface IMasterRequest
    {
        ILoginRequest LoginRequest();
        ICommonRequest CommonRequest();
    }
}