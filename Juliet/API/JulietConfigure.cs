﻿using UnityEngine;
using System.Collections.Generic;

namespace JulietUtil.API
{
    public class JulietConfigure : MonoBehaviour
    {
        #region Instance

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
        }

        #endregion

        public bool isSupportOAuthBasic = false;
        public List<string> optinalKeys = new List<string>();
        public List<string> optionalValues = new List<string>();
        
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

                Header dupplicateHeader = null;

                foreach (var item in JulietHeaderConfig.CommonHeaderConfig.Headers)
                {
                    if(item.Key.Equals(header.Key))
                    {
                        dupplicateHeader = item;
                        break;
                    }
                }

                if(dupplicateHeader != null)
                {
                    JulietHeaderConfig.CommonHeaderConfig.Headers.Remove(dupplicateHeader);
                }

                JulietHeaderConfig.CommonHeaderConfig.Headers.Add(header);
            }
        }
    }
}