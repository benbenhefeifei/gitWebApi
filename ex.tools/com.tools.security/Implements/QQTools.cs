using System.Web;

namespace System.Security
{
    /// <summary>
    /// QQ消息加密工具
    /// </summary>
    public class QQTools : ISecurity
    {
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

            text = HttpUtility.UrlEncode(text, System.Text.Encoding.UTF8);
            int[] oldstr_byte = bytesToInt(DefCoding.GetBytes(text));
            int[] Key_byte = bytesToInt(DefCoding.GetBytes(key));
            int[] newstr_byte = Encrypt(oldstr_byte, 0, oldstr_byte.Length, Key_byte);
            System.Text.StringBuilder newstr = new System.Text.StringBuilder();
            for (int i = 0; i < newstr_byte.Length; i++)
            {
                newstr.Append(string.Format("{0:X2}", newstr_byte[i]));
            }
            return newstr.ToString().Trim();
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
            if (DefCoding == null) { DefCoding = Text.Encoding.ASCII; }
            if (string.IsNullOrWhiteSpace(text)) { return string.Empty; }

            int[] Cipher_byte = rebyte(text);
            int[] Key_byte = bytesToInt(DefCoding.GetBytes(key));
            int[] g = Decrypt(Cipher_byte, 0, Cipher_byte.Length, Key_byte);
            string result = DefCoding.GetString(IntTobytes(g));
            result = HttpUtility.UrlDecode(result, System.Text.Encoding.UTF8).Replace("&quot;", "\"");
            return result;
        }
        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="pass">验证字符（必填）</param>
        /// <param name="otext">加密密文（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <param name="coding">所需字符集（选填，默认ASCII）</param>
        /// <returns>验证结果 true成功，false失败</returns>
        public bool Validate(string text, string otext, string key)
        {
            string newpass = Decrypt(otext, key);
            return (text.ToUpper() == newpass.ToUpper());
        }

        public void Dispose()
        {
            this.Dispose();
        }

        #region 加密使用函数

        private static int[] Encrypt(int[] In, int offset, int len, int[] key)
        {
            // 计算头部填充字节数
            int pos = (len + 10) % 8;
            if (pos != 0)
            {
                pos = 8 - pos;
            }
            int[] plain = new int[len + pos + 10];
            Random Rnd = new Random(Guid.NewGuid().GetHashCode());
            plain[0] = (int)((Rnd.Next() & 248) | pos);
            for (int i = 1; i < pos + 3; i++)
            {
                plain[i] = (int)(Rnd.Next() & 255);
            }
            Array.Copy(In, 0, plain, pos + 3, len);
            for (int i = pos + 3 + len; i < plain.Length; i++)
            {
                plain[i] = 0;
            }
            // 定义输出流
            int[] outer = new int[len + pos + 10];
            for (int i = 0; i < outer.Length; i += 8)
            {
                EncryptCode(plain, 0, i, outer, 0, i, key);
            }
            return outer;
        }

        private static void EncryptCode(int[] In, int inOffset, int inPos, int[] Out, int outOffset, int outPos, int[] key)
        {
            if (outPos > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    In[outOffset + outPos + i] = (int)(In[inOffset + inPos + i] ^ Out[outOffset + outPos + i - 8]);
                }
            }
            int[] formattedKey = FormatKey(key);
            int y = ConvertByteArrayToUInt(In, outOffset + outPos);
            int z = ConvertByteArrayToUInt(In, outOffset + outPos + 4);
            int sum = 0;
            int delta = 9999;
            int n = 16;

            while (n-- > 0)
            {
                sum += delta;
                y += ((z << 4) + formattedKey[0]) ^ (z + sum) ^ ((z >> 5) + formattedKey[1]);
                z += ((y << 4) + formattedKey[2]) ^ (y + sum) ^ ((y >> 5) + formattedKey[3]);
            }
            int a = sum;
            Array.Copy(ConvertUIntToByteArray(y), 0, Out, outOffset + outPos, 4);
            Array.Copy(ConvertUIntToByteArray(z), 0, Out, outOffset + outPos + 4, 4);
            if (inPos > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Out[outOffset + outPos + i] = (int)(Out[outOffset + outPos + i] ^ In[inOffset + inPos + i - 8]);
                }
            }
        }

        #endregion

        #region 解码使用函数

        private static int[] Decrypt(int[] In, int offset, int len, int[] key)
        {
            // 因为QQ消息加密之后至少是16字节，并且肯定是8的倍数，这里检查这种情况
            if ((len % 8 != 0) || (len < 16))
            {
                return null;
            }
            int[] Out = new int[len];
            for (int i = 0; i < len; i += 8)
            {
                DecryptCode(In, offset, i, Out, 0, i, key);
            }
            for (int i = 8; i < len; i++)
            {
                Out[i] = (int)(Out[i] ^ In[offset + i - 8]);
            }
            int pos = Out[0] & 7;
            len = len - pos - 10;
            int[] res = new int[len];
            Array.Copy(Out, pos + 3, res, 0, len);
            return res;
        }

        private static void DecryptCode(int[] In, int inOffset, int inPos, int[] Out, int outOffset, int outPos, int[] key)
        {
            if (outPos > 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    Out[outOffset + outPos + i] = (int)(In[inOffset + inPos + i] ^ Out[outOffset + outPos + i - 8]);
                }
            }
            else
            {
                Array.Copy(In, inOffset, Out, outOffset, 8);
            }
            int[] formattedKey = FormatKey(key);
            int y = ConvertByteArrayToUInt(Out, outOffset + outPos);
            int z = ConvertByteArrayToUInt(Out, outOffset + outPos + 4);
            int sum = 159984;
            int delta = 9999;
            int n = 16;

            while (n-- > 0)
            {
                z -= ((y << 4) + formattedKey[2]) ^ (y + sum) ^ ((y >> 5) + formattedKey[3]);
                y -= ((z << 4) + formattedKey[0]) ^ (z + sum) ^ ((z >> 5) + formattedKey[1]);
                sum -= delta;
            }
            Array.Copy(ConvertUIntToByteArray(y), 0, Out, outOffset + outPos, 4);
            Array.Copy(ConvertUIntToByteArray(z), 0, Out, outOffset + outPos + 4, 4);
        }
        /// <summary>
        /// 将字符串格式化为整型数组
        /// </summary>
        private static int[] rebyte(string bytestr)
        {
            int y = bytestr.Length % 2;
            if (y == 0)
            {
                int l = bytestr.Length / 2;
                int[] strar = new int[l];
                int s = 0;
                for (int i = 0; i < strar.Length; i++)
                {
                    s = i * 2;
                    strar[i] = Convert.ToInt32(bytestr.Substring(s, 2), 16);
                }
                return strar;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 将整型数组转换为字节数组
        /// </summary>
        private static byte[] IntTobytes(int[] data)
        {
            byte[] arr = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                arr[i] = Convert.ToByte(data[i]);
            }
            return arr;
        }
        #endregion

        #region 加、解密通用函数
        /// <summary>
        /// 字节数组转整型数组
        /// </summary>
        private static int[] bytesToInt(byte[] data)
        {
            int[] arr = new int[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                arr[i] = data[i];
            }
            return arr;
        }
        /// <summary>
        /// 密钥KEY格式化（整型数组格式化）
        /// </summary>
        private static int[] FormatKey(int[] key)
        {
            if (key.Length == 0)
            {
                throw new ArgumentException("Key must be between 1 and 16 characters in length");
            }
            int[] refineKey = new int[16];
            if (key.Length < 16)
            {
                Array.Copy(key, 0, refineKey, 0, key.Length);
                for (int k = key.Length; k < 16; k++)
                {
                    refineKey[k] = 32;
                }
            }
            else
            {
                Array.Copy(key, 0, refineKey, 0, 16);
            }
            int[] formattedKey = new int[4];
            int j = 0;
            for (int i = 0; i < refineKey.Length; i += 4)
            {
                formattedKey[j++] = ConvertByteArrayToUInt(refineKey, i);
            }
            return formattedKey;
        }
        /// <summary>
        /// 将 整型数值 转换 整型数组
        /// </summary>
        private static int[] ConvertUIntToByteArray(int v)
        {
            int[] result = new int[4];
            result[0] = (int)((v >> 24) & 255);
            result[1] = (int)((v >> 16) & 255);
            result[2] = (int)((v >> 8) & 255);
            result[3] = (int)((v >> 0) & 255);
            return result;
        }
        /// <summary>
        /// 使用偏移量 将 整型数值 转换 整型数组
        /// </summary>
        private static int ConvertByteArrayToUInt(int[] v, int offset)
        {
            if (offset + 4 > v.Length)
            {
                return 0;
            }
            int output;
            output = (int)(v[offset] << 24);
            output |= (int)(v[offset + 1] << 16);
            output |= (int)(v[offset + 2] << 8);
            output |= (int)(v[offset + 3] << 0);
            return output;
        }
        #endregion
    }
}
