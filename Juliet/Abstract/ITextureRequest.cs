using System;
using UnityEngine;
using JulietUtil.Request;

namespace JulietUtil.Abstract
{
    public abstract class ITextureRequest : BaseRequest
    {
        public abstract ITextureRequest SetURL(string url);
    }
}