
namespace System
{
    using Text.RegularExpressions;

    public static class ConvertExtensions
    {
        #region 转DateTime类型
        /// <summary>
        /// 转DateTime类型，值可为空
        /// 支持格式：1900年01月01日 00时00分00秒，1900-1-1 00:00:00，1900/1/1 00:00:00，19000101000000
        /// </summary>
        public static DateTime ToDateTime(this string original)
        {
            string value = original.Trim();
            Regex RDate = new Regex(@"(年)|(月)");
            Regex RTime = new Regex(@"(时)|(分)");
            Regex RDays = new Regex(@"(T)|(日)|(秒)");
            DateTime reftime = DateTime.Parse("1900/01/01 00:00:00");
            if (value.Length < 10) { value = "1900-01-01"; }
            if (value.Substring(0, 10) == "0001-01-01") { value = "1900-01-01"; }
            string newtimestr = RDate.Replace(RTime.Replace(RDays.Replace(value, " "), ":"), "-").Replace("  ", " ").Trim();
            DateTime.TryParse(newtimestr, out reftime);
            return reftime;
        }
        #endregion

        #region 转Object对象
        /// <summary>
        /// 字符串 转换指定类型值
        /// </summary>
        public static object ToObject(this string original, Type valType)
        {
            if (string.IsNullOrWhiteSpace((original ?? "").ToString())) { return original; }
            //type = string
            if (valType == typeof(string) || valType == typeof(String)) { return original; }
            //type = DateTime
            if (valType == typeof(DateTime?) || valType == typeof(DateTime)) { return original.ToDateTime(); }
            //type = byte
            if (valType == typeof(byte?) || valType == typeof(byte))
            {
                byte refval = 0;
                if (!byte.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = TimeSpan
            if (valType == typeof(TimeSpan?) || valType == typeof(TimeSpan))
            {
                TimeSpan outval = TimeSpan.Parse("00:00:00");
                if (!TimeSpan.TryParse(original, out outval)) { return null; }
                return outval;
            }
            //type = int
            if (valType == typeof(int?) || valType == typeof(Int32?) || valType == typeof(int) || valType == typeof(Int32))
            {
                int refval = 0;
                if (!int.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = uint
            if (valType == typeof(uint?) || valType == typeof(UInt32?) || valType == typeof(uint) || valType == typeof(UInt32))
            {
                uint refval = 0;
                if (!uint.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = short
            if (valType == typeof(short?) || valType == typeof(Int16?) || valType == typeof(short) || valType == typeof(Int16))
            {
                short refval = 0;
                if (!short.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = ushort
            if (valType == typeof(ushort?) || valType == typeof(UInt16?) || valType == typeof(ushort) || valType == typeof(UInt16))
            {
                ushort refval = 0;
                if (!ushort.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = long
            if (valType == typeof(long?) || valType == typeof(Int64?) || valType == typeof(long) || valType == typeof(Int64))
            {
                long refval = 0;
                if (!long.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = ulong
            if (valType == typeof(ulong?) || valType == typeof(UInt64?) || valType == typeof(ulong) || valType == typeof(UInt64))
            {
                ulong refval = 0;
                if (!ulong.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = float
            if (valType == typeof(float?) || valType == typeof(Single?) || valType == typeof(float) || valType == typeof(Single))
            {
                float refval = 0;
                if (!float.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = double
            if (valType == typeof(double?) || valType == typeof(Double?) || valType == typeof(double) || valType == typeof(Double))
            {
                double refval = 0;
                if (!double.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = decimal
            if (valType == typeof(decimal?) || valType == typeof(Decimal?) || valType == typeof(decimal) || valType == typeof(Decimal))
            {
                decimal refval = 0;
                if (!decimal.TryParse(original, out refval)) { return null; }
                return refval;
            }
            //type = bool
            if (valType == typeof(bool?) || valType == typeof(Boolean?) || valType == typeof(bool) || valType == typeof(Boolean))
            {
                if (string.IsNullOrWhiteSpace(original)) { return null; }
                original = original.Trim().Split(',')[0];
                return original == "1" || original == "true" || original == "on";
            }
            return original;
        }
        #endregion

        #region 过滤字符串中注入SQL脚本的方法
        public static string SqlFilters(this string source, string extRule = "")
        {
            //去除 执行SQL语句的命令关键字 或 执行存储过程的命令关键字 
            string rules = @"(select)|(insert)|(update)|(delete)|(drop)|(truncate)|(xp_cmdshell)|(/add)|(net use)|(exec)";
            if (!string.IsNullOrEmpty(extRule)) { rules = rules + "|" + extRule; }

            source = System.Web.HttpUtility.UrlDecode(source);
            //半角括号替换为全角括号
            source = source.Replace("\"", "");
            //执行规则过滤
            source = new Regex(rules, RegexOptions.IgnoreCase).Replace(source, "");
            //防止16进制注入
            source = Regex.Replace(source, "0x", "0 x", RegexOptions.IgnoreCase);
            return source.Trim();
        }
        #endregion
    }
}
