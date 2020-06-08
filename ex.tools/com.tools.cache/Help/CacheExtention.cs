

namespace System
{
    using Collections.Generic;
    using Text.RegularExpressions;

    /// <summary>
    /// 
    /// </summary>
    public static class CacheExtention
    {
        static string _Prefix = "EHP1";

        /// <summary>
        /// 缓存键处理 增加前缀
        /// </summary>
        public static string Prefix(this string key, string prefix = "")
        {
            if (string.IsNullOrEmpty(prefix)) { prefix = _Prefix; }
            Regex regex = new Regex("^(" + prefix + "_)");
            return string.Concat(prefix, "_", regex.Replace(key, ""));
        }
        /// <summary>
        /// 处理所有缓存键 增加前缀
        /// </summary>
        public static List<string> Prefix(this List<string> keys, string prefix = "")
        {
            List<string> mykeys = new List<string>();
            keys.ForEach(key => { mykeys.Add(key.Prefix(prefix)); });
            return keys;
        }
    }
}
