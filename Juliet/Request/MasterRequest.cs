
using JulietUtil.Abstract;
using JulietUtil.Interface;

namespace JulietUtil.Request
{
    public class MasterRequest : IMasterRequest
    {
        private string TAG = "Request";

        public ILoginRequest Login()
        {
            JulietLogger.Info(TAG, "Initial Login");

            return new LoginRequest();
        }

        public ICommonRequest Common()
        {
            JulietLogger.Info(TAG, "Initial Common");

            return new CommonRequest();
        }

        public ITextureRequest Texture()
        {
            JulietLogger.Info(TAG, "Initial Texture");

            return new TextureRequest();
        }
    }
}