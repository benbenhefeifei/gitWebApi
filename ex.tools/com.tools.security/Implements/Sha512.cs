namespace System.Security
{
    using Cryptography;
    public class Sha512 : ISecurity
    {
        private SHA512 sha512Header = null;

        /// <summary>
        /// 获取或设置 字符集编码 （选填，默认ASCII）
        /// </summary>
        public System.Text.Encoding DefCoding { get; set; }
        /// <summary>
        /// 加密并输入密钥盐
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
        /// 加密
        /// </summary>
        /// <param name="text">加密字符（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <param name="coding">所需字符集（选填，默认ASCII）</param>
        /// <returns>返回加密后的密文</returns>
        public string Encrypt(string text, string key = "")
        {
            if (DefCoding == null) { DefCoding = System.Text.Encoding.ASCII; }
            if (string.IsNullOrWhiteSpace(text)) { return string.Empty; }
            if (!string.IsNullOrWhiteSpace(key)) { text = text + "$" + key; }
            sha512Header = new SHA512CryptoServiceProvider();
            byte[] tmpByte = sha512Header.ComputeHash(DefCoding.GetBytes(text));
            Text.StringBuilder result = new Text.StringBuilder();
            for (int i = 0; i < tmpByte.Length; i++) { result.Append(tmpByte[i].ToString("x2")); }
            sha512Header.Clear();
            return result.ToString();
            //return Convert.ToBase64String(tmpByte);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="originalText">加密后的密文</param>
        /// <param name="secretKey">解密密钥</param>
        /// <param name="coding">所需字符集（选填，默认ASCII）</param>
        /// <returns>返回解密后的原文</returns>
        public string Decrypt(string text, string key = "")
        {
            throw new NotImplementedException("SHA512暂不支持解密功能.");
        }
        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="text">验证字符（必填）</param>
        /// <param name="otext">加密密文（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <param name="coding">所需字符集（选填，默认ASCII）</param>
        /// <returns>验证结果 true成功，false失败</returns>
        public bool Validate(string text, string otext, string key)
        {
            string npass = Encrypt(text, key);
            return (otext.ToUpper() == npass.ToUpper());
        }

        public void Dispose()
        {
            if (sha512Header != null)
            {
                sha512Header.Dispose();
            }
            this.Dispose();
        }
    }
}
