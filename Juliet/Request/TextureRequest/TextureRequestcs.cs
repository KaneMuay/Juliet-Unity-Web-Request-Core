using JulietUtil.Abstract;
using JulietUtil.API;
using System;
using UnityEngine;

namespace JulietUtil.Request
{
    public class TextureRequest : ITextureRequest
    {
        private string TAG = "TEXTURE REQUEST";

        private string url;

        public override ITextureRequest SetURL(string url)
        {
            this.url = url;

            JulietLogger.Info(TAG, "Url " + this.url);

            return this;
        }

        public override void Send(Action<Texture> success, Action<string> fail)
        {
            JulietLogger.Info(TAG, "Send");
            
            MethodForm form = new MethodForm()
            {
                URL = this.url
            };

            JulietAPI.Instance.Request(form, success, fail);
        }
    }
}