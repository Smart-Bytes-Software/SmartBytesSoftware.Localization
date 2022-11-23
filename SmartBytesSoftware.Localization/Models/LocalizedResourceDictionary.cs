using System.Collections.Generic;

namespace SmartBytesSoftware.Localization.Models
{
    public class LocalizedResourceDictionary : Dictionary<string, string>
    {
        public new string this[string key]
        {
            get => ContainsKey(key) ? base[key] : key;
            set => base[key] = value;
        }
    }
}
