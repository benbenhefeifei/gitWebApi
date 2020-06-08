
namespace System.Security
{
    public class Base64 : ISecurity
    {
        /// <summary>
        /// 获取或设置 字符集编码 （选填，默认ASCII）
        /// </summary>
        public System.Text.Encoding DefCoding { get; set; }
        /// <summary>
        /// DES加密并返回加密密钥盐
        /// </summary>
        /// <param name="text">加密字符（必填）</param>
        /// <param name="salt">密钥盐（输出随机密钥）</param>
        /// <param name="slen">密钥长度</param>
        /// <returns>返回加密后的密文</returns>
        public string Encrypt(string text, out string salt, int slen = 8)
        {
            int sindex = new Random().Next(0, 32 - slen);
            salt = Guid.NewGuid().ToString().Replace("-", "").Substring(sindex, slen);
            return Encrypt(text, salt);
        }
        /// <summary>
        /// 字符串转Base64字符码
        /// </summary>
        /// <param name="text">加密字符（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <returns>返回加密后的密文</returns>
        public string Encrypt(string text, string key = "")
        {
            if (DefCoding == null) { DefCoding = Text.Encoding.UTF8; }
            if (string.IsNullOrWhiteSpace(text)) { return string.Empty; }
            if (!string.IsNullOrWhiteSpace(key)) { text = text + "$" + key; }

            return Convert.ToBase64String(DefCoding.GetBytes(text));
        }
        /// <summary>
        /// Base64字符串解码
        /// </summary>
        /// <param name="originalText">加密后的密文</param>
        /// <param name="secretKey">解密密钥</param>
        /// <returns>返回解密后的原文</returns>
        public string Decrypt(string text, string key = "")
        {
            if (DefCoding == null) { DefCoding = Text.Encoding.UTF8; }
            if (string.IsNullOrWhiteSpace(text)) { return string.Empty; }

            byte[] bpath = Convert.FromBase64String(text + key);
            return DefCoding.GetString(bpath);
        }
        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="text">验证字符（必填）</param>
        /// <param name="otext">加密密文（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <returns>验证结果 true成功，false失败</returns>
        public bool Validate(string text, string otext, string key)
        {
            string newpass = Encrypt(text, key);
            return (otext.ToUpper() == newpass.ToUpper());
        }


        public void Dispose()
        {
            this.Dispose();
        }

    }
}
