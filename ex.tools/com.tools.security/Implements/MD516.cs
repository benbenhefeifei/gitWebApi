
namespace System.Security
{
    public class MD516 : ISecurity
    {
        /// <summary>
        /// MD5加密工厂
        /// </summary>
        private Cryptography.MD5CryptoServiceProvider md5Hasher = null;

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
        /// MD5加密
        /// </summary>
        /// <param name="pass">加密字符（必填）</param>
        /// <param name="key">转换大写</param>
        /// <param name="coding">字符集编码，默认UTF-8</param>
        public string Encrypt(string pass, string key = "")
        {
            if (DefCoding == null) { DefCoding = System.Text.Encoding.UTF8; }
            if (string.IsNullOrWhiteSpace(pass)) { return string.Empty; }
            if (!string.IsNullOrWhiteSpace(key)) { pass = pass + "$" + key; }
            md5Hasher = new Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes = md5Hasher.ComputeHash(DefCoding.GetBytes(pass));
            return BitConverter.ToString(hashedBytes, 4, 8).Replace("-", "");
        }
        /// <summary>
        /// 解密
        /// <param name="text">解密密文（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <param name="coding">所需字符集（选填，默认ASCII）</param>
        /// <returns>返回解密后的原文</returns>
        public string Decrypt(string text, string key = "")
        {
            throw new NotImplementedException("MD5暂不支持解密功能.");
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
            string newpass = Encrypt(text, key);
            return (otext.ToUpper() == newpass.ToUpper());
        }
        
        public void Dispose()
        {
            if (md5Hasher != null)
            {
                md5Hasher.Dispose();
            }
            this.Dispose();
        }
    }
}
