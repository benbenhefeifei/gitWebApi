using System;

namespace System.Security
{
    public interface ISecurity : IDisposable
    {
        /// <summary>
        /// 获取或设置 字符集编码 （选填，默认ASCII）
        /// </summary>
        System.Text.Encoding DefCoding { get; set; }
        /// <summary>
        /// 加密并返回加密密钥盐
        /// </summary>
        /// <param name="text">加密字符（必填）</param>
        /// <param name="salt">密钥盐（输出随机密钥）</param>
        /// <param name="slen">密钥长度</param>
        /// <returns>返回加密后的密文</returns>
        string Encrypt(string text, out string salt, int slen = 8);
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="text">加密字符（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <returns>返回加密后的密文</returns>
        string Encrypt(string text, string key = "");
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="text">解密密文（必填）</param>
        /// <param name="key">密钥盐（必填）</param>
        /// <returns>返回解密后的原文</returns>
        string Decrypt(string text, string key = "");
        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="ortext">验证未加密字符（必填）</param>
        /// <param name="entext">加密密文（必填）</param>
        /// <param name="saltkey">密钥盐（必填）</param>
        /// <returns>验证结果 true成功，false失败</returns>
        bool Validate(string ortext, string entext, string key);
    }
}
