
namespace System.Security
{
    using Cryptography;

    public class AES : ISecurity
    {
        /// <summary>
        /// AES加密工厂
        /// </summary>
        private Rijndael aesHasher = null;
        //AES默认密钥
        private static readonly string _secretkeys = "abcdefghijklmnopqrstuvwxyz123456";
        //AES密钥向量
        private static readonly byte[] _aesivs = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x22, 0x45, 0x66, 0x70, 0x99, 0xBA, 0xDC, 0xFE };

        /// <summary>
        /// 获取或设置 字符集编码 （选填，默认ASCII）
        /// </summary>
        public System.Text.Encoding DefCoding { get; set; }
        /// <summary>
        /// AES加密并返回加密密钥盐
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
        /// AES加密
        /// </summary>
        /// <param name="text">加密字符（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <returns>返回加密后的密文</returns>
        public string Encrypt(string text, string key = "")
        {
            if (DefCoding == null) { DefCoding = Text.Encoding.UTF8; }
            if (string.IsNullOrWhiteSpace(text)) { return string.Empty; }

            //创建加密算法 并设置密钥及密钥向量
            aesHasher = Rijndael.Create();
            aesHasher.IV = _aesivs;
            aesHasher.Key = DefCoding.GetBytes((key + _secretkeys).Substring(0, 32));

            byte[] resultBytes = null;
            byte[] inputBytes = DefCoding.GetBytes(text);

            using (IO.MemoryStream mStream = new IO.MemoryStream())
            {
                CryptoStream cStream = new CryptoStream(mStream, aesHasher.CreateEncryptor(), CryptoStreamMode.Write);
                cStream.Write(inputBytes, 0, inputBytes.Length);
                cStream.FlushFinalBlock();
                resultBytes = mStream.ToArray();
                cStream.Close();
                mStream.Close();
            }

            Text.StringBuilder result = new Text.StringBuilder();
            foreach (byte bitem in resultBytes) { result.AppendFormat("{0:X2}", bitem); }
            return result.ToString();
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="originalText">加密后的密文</param>
        /// <param name="secretKey">解密密钥</param>
        /// <returns>返回解密后的原文</returns>
        public string Decrypt(string text, string key = "")
        {
            if (DefCoding == null) { DefCoding = Text.Encoding.UTF8; }
            if (string.IsNullOrWhiteSpace(text)) { return string.Empty; }

            //创建加密算法 并设置密钥及密钥向量
            aesHasher = Rijndael.Create();
            aesHasher.IV = _aesivs;
            aesHasher.Key = DefCoding.GetBytes((key + _secretkeys).Substring(0, 32));

            byte[] resultBytes = null;
            byte[] inputBytes = new byte[text.Length / 2];
            for (int x = 0; x < text.Length / 2; x++)
            {
                inputBytes[x] = (byte)(Convert.ToInt32(text.Substring(x * 2, 2), 16));
            }

            using (IO.MemoryStream mStream = new IO.MemoryStream())
            {
                CryptoStream cStream = new CryptoStream(mStream, aesHasher.CreateDecryptor(), CryptoStreamMode.Write);
                cStream.Write(inputBytes, 0, inputBytes.Length);
                cStream.FlushFinalBlock();
                resultBytes = mStream.ToArray();
                cStream.Close();
                mStream.Close();
            }

            return DefCoding.GetString(resultBytes);
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
            string npass = Encrypt(text, key);
            string ntext = Decrypt(otext, key);

            return (text.ToUpper() == ntext.ToUpper() && otext.ToUpper() == npass.ToUpper());
        }


        public void Dispose()
        {
            if (aesHasher != null)
            {
                aesHasher.Dispose();
            }
            this.Dispose();
        }
    }
}
