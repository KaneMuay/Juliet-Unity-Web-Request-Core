using UnityEngine;
using System.Collections.Generic;

namespace JulietUtil.API
{
    public class JulietConfigure : MonoBehaviour
    {
        #region Singleton

        private static JulietConfigure _instance;

        public static JulietConfigure Instance
        {
            get
            {
                return _instance;
            }
        }

        private void Awake()
        {
            _instance = this;

            UpdateHeader();
        }

        #endregion
        
        [Header("Configure")]
        public bool isSupportOAuthBasic = false;

        [Header("Optional")]
        public List<string> optinalKeys = new List<string>();
        public List<string> optionalValues = new List<string>();

        [Header("Header Configure")]
        public JulietHeaderConfig JulietHeaderConfig;
        
        
        public void SetOptionalKeyHeader(params string[] optionals)
        {
            optinalKeys.Clear();

            foreach (var key in optionals)
            {
                optinalKeys.Add(key);
            }
        }

        public void SetOptionalValueHeader(params string[] optionals)
        {
            optionalValues.Clear();

            foreach (var value in optionals)
            {
                optionalValues.Add(value);
            }
        }

        public void UpdateHeader()
        {
            for (int i = 0; i < optinalKeys.Count; i++)
            {
                string key = optinalKeys[i];
                string value = optionalValues[i];

                Header header = new Header()
                {
                    Key = key,
                    Value = value
                };
                
                Header dupplicateHeader = JulietHeaderConfig.CommonHeaderConfig.Headers.Find(x => x.Key == header.Key);

                if(dupplicateHeader != null)
                    JulietHeaderConfig.CommonHeaderConfig.Headers.Remove(dupplicateHeader);

                JulietHeaderConfig.CommonHeaderConfig.Headers.Add(header);
            }
        }
    }
}