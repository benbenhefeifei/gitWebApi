/***********************************************
 * 版权声明：2017-2020 
 * 作    者：吴文吉
 * 功能描述：自定义字符串追加操作 （扩展）
 * 创建时间：2017-07-27
 * 更新历史：（日期倒序）
 * *********************************************/

namespace System
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// 自定义字符串操作 （扩展）
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 字符串增加前缀
        /// </summary>
        /// <param name="prefix">前缀</param>
        /// <param name="isRefEmpty">原字符串为空时是否返回空</param>
        public static string AddPrefix(this string original, string prefix, bool isRefEmpty = true)
        {
            if (string.IsNullOrWhiteSpace(original) && isRefEmpty) { return ""; }
            return string.Concat(prefix, original);
        }
        /// <summary>
        /// 字符串增加后缀
        /// </summary>
        /// <param name="suffix">后缀</param>
        /// <param name="isRefEmpty">源字符串为空时是否返回空</param>
        public static string AddSuffix(this string original, string suffix, bool isRefEmpty = true)
        {
            if (string.IsNullOrWhiteSpace(original) && isRefEmpty) { return ""; }
            return string.Concat(original, suffix);
        }
        /// <summary>
        /// 剔除字符串指定前缀
        /// </summary>
        public static string DelPrefix(this string original, string prefix)
        {   
            if (original.StartsWith(prefix)) { return original.Replace(prefix, ""); }
            else { return Text.RegularExpressions.Regex.Replace(original, "[a-zA-Z]+", ""); }
        }
        /// <summary>
        /// 号码部分隐藏
        /// </summary>
        /// <param name="original">原号码</param>
        /// <param name="hval">隐藏部分字符</param>
        /// <param name="hlen">隐藏长度</param>
        public static string MobileHide(this string original, string hval = "*", int hlen = 4)
        {
            string temp = hval;
            if (string.IsNullOrWhiteSpace(original)) { return string.Empty; }
            for (int i = 1; i < hlen; i++) { temp = string.Concat(temp, hval); }
            return string.Concat(original.Substring(0, 3), temp, original.Substring(3 + hlen, original.Length - 3 - hlen));
        }
        /// <summary>
        /// 字符串Unicode编码
        /// </summary>
        public static string ToUnicode(this string original)
        {
            char[] charbuffers = original.ToCharArray();
            byte[] buffer;
            Text.StringBuilder sb = new Text.StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }

        #region XML文件与对象 序列反序列
        /// <summary>
        /// 将指定对象序列化为XML格式
        /// </summary>
        /// <typeparam name="T">序列化对象类型</typeparam>
        /// <param name="xmlEntitiy">序列化对象</param>
        /// <param name="encoding">指定XML文件编码格式</param>
        /// <returns>XML格式字符串</returns>
        public static string XmlSerialize<T>(this T xmlEntitiy, Encoding encoding) where T : class
        {
            string xmlResult = string.Empty;
            //
            //定义指定类型(T)的 XML序列化对象
            //
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            //
            //定义XML文档实例生成的命名空间
            //
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            //
            //去除命名空间
            //
            namespaces.Add("", "");

            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter writer = new XmlTextWriter(stream, encoding))
                {
                    //
                    //序列化指定文件并将其XML文档写入文件
                    //
                    serializer.Serialize(writer, xmlEntitiy, namespaces);
                    //
                    //重置文件到开始部分
                    //
                    stream.Seek(0L, SeekOrigin.Begin);

                    using (StreamReader reader = new StreamReader(stream))
                    {
                        xmlResult = reader.ReadToEnd();
                    }
                }
            }
            return xmlResult;
        }
        /// <summary>
        /// 将XML格式字符串反序列化到指定对象
        /// </summary>
        /// <typeparam name="T">反序列化对象类型</typeparam>
        /// <param name="xmlString">XML格式字符串</param>
        /// <param name="encoding">XML文件编码格式</param>
        /// <returns>序列化对象</returns>
        public static T XmlDeserialize<T>(this string xmlString, Encoding encoding) where T : class
        {
            T result = default(T);
            //
            //定义指定类型(T)的 XML序列化对象
            //
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(encoding.GetBytes(xmlString)))
            {
                result = (T)serializer.Deserialize(stream);
            }
            return result;
        }
        #endregion
    }
}
