using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Security
{
    public class SecurityFactory
    {
        #region QQTools QQ消息加密工具
        static ISecurity _qqtools = null;
        static readonly object _qqtoolsLock = new object();
        /// <summary>
        /// QQTools QQ消息加密工具
        /// </summary>
        public static ISecurity QQTools
        {
            get
            {
                if (_qqtools == null)
                {
                    lock (_qqtoolsLock)
                    {
                        if (_qqtools == null)
                        {
                            _qqtools = new QQTools();
                        }
                    }
                }
                return _qqtools;
            }
        }
        #endregion

        #region BASE64 数据加密
        static ISecurity _base64 = null;
        static readonly object _base64Lock = new object();
        /// <summary>
        /// BASE64 数据加密
        /// </summary>
        public static ISecurity Base64
        {
            get
            {
                if (_base64 == null)
                {
                    lock (_base64Lock)
                    {
                        if (_base64 == null)
                        {
                            _base64 = new Base64();
                        }
                    }
                }
                return _base64;
            }
        }
        #endregion

        #region DES 对称加密解密
        static ISecurity _des = null;
        static readonly object _desLock = new object();
        /// <summary>
        /// DES 对称加密解密
        /// </summary>
        public static ISecurity DES
        {
            get
            {
                if (_des == null)
                {
                    lock (_desLock)
                    {
                        if (_des == null)
                        {
                            _des = new DES();
                        }
                    }
                }
                return _des;
            }
        }
        #endregion
        #region AES 对称加密解密
        static ISecurity _aes = null;
        static readonly object _aesLock = new object();
        /// <summary>
        /// AES 对称加密解密
        /// </summary>
        public static ISecurity AES
        {
            get
            {
                if (_aes == null)
                {
                    lock (_aesLock)
                    {
                        if (_aes == null)
                        {
                            _aes = new AES();
                        }
                    }
                }
                return _aes;
            }
        }
        #endregion
        #region RSA 对称加密解密
        static ISecurity _rsa = null;
        static readonly object _rsaLock = new object();
        /// <summary>
        /// RSA 对称加密解密
        /// </summary>
        public static ISecurity RSA
        {
            get
            {
                if (_rsa == null)
                {
                    lock (_rsaLock)
                    {
                        if (_rsa == null)
                        {
                            _rsa = new RSA();
                        }
                    }
                }
                return _rsa;
            }
        }
        #endregion

        #region MD516 数据加密
        static ISecurity _md516 = null;
        static readonly object _md516Lock = new object();
        /// <summary>
        /// MD516 数据加密
        /// </summary>
        public static ISecurity MD516
        {
            get
            {
                if (_md516 == null)
                {
                    lock (_md516Lock)
                    {
                        if (_md516 == null)
                        {
                            _md516 = new MD516();
                        }
                    }
                }
                return _md516;
            }
        }
        #endregion
        #region MD532 数据加密
        static ISecurity _md532 = null;
        static readonly object _md532Lock = new object();
        /// <summary>
        /// MD532 数据加密
        /// </summary>
        public static ISecurity MD532
        {
            get
            {
                if (_md532 == null)
                {
                    lock (_md532Lock)
                    {
                        if (_md532 == null)
                        {
                            _md532 = new MD532();
                        }
                    }
                }
                return _md532;
            }
        }
        #endregion
        #region HMAC_MD5 数据加密
        static ISecurity _hmacmd5 = null;
        static readonly object _hmacmd5Lock = new object();
        /// <summary>
        /// HMAC-MD5 数据加密
        /// </summary>
        public static ISecurity HMAC_MD5
        {
            get
            {
                if (_hmacmd5 == null)
                {
                    lock (_hmacmd5Lock)
                    {
                        if (_hmacmd5 == null)
                        {
                            _hmacmd5 = new HmacMD5();
                        }
                    }
                }
                return _hmacmd5;
            }
        }
        #endregion

        #region SHA1 数据加密
        static ISecurity _SHA1 = null;
        static readonly object _SHA1Lock = new object();
        /// <summary>
        /// SHA1 数据加密
        /// </summary>
        public static ISecurity SHA1
        {
            get
            {
                if (_SHA1 == null)
                {
                    lock (_SHA1Lock)
                    {
                        if (_SHA1 == null)
                        {
                            _SHA1 = new Sha1();
                        }
                    }
                }
                return _SHA1;
            }
        }
        #endregion
        #region SHA256 数据加密
        static ISecurity _SHA256 = null;
        static readonly object _SHA256Lock = new object();
        /// <summary>
        /// SHA256 数据加密
        /// </summary>
        public static ISecurity SHA256
        {
            get
            {
                if (_SHA256 == null)
                {
                    lock (_SHA256Lock)
                    {
                        if (_SHA256 == null)
                        {
                            _SHA256 = new Sha256();
                        }
                    }
                }
                return _SHA256;
            }
        }
        #endregion
        #region SHA512 数据加密
        static ISecurity _SHA512 = null;
        static readonly object _SHA512Lock = new object();
        /// <summary>
        /// SHA512 数据加密
        /// </summary>
        public static ISecurity SHA512
        {
            get
            {
                if (_SHA512 == null)
                {
                    lock (_SHA512Lock)
                    {
                        if (_SHA512 == null)
                        {
                            _SHA512 = new Sha512();
                        }
                    }
                }
                return _SHA512;
            }
        }
        #endregion

        #region HMAC-SHA1 数据加密
        static ISecurity _HMACSHA1 = null;
        static readonly object _HMACSHA1Lock = new object();
        /// <summary>
        /// HMAC-SHA1 数据加密
        /// </summary>
        public static ISecurity HMAC_SHA1
        {
            get
            {
                if (_HMACSHA1 == null)
                {
                    lock (_HMACSHA1Lock)
                    {
                        if (_HMACSHA1 == null)
                        {
                            _HMACSHA1 = new HmacSHA1();
                        }
                    }
                }
                return _HMACSHA1;
            }
        }
        #endregion
        #region HMAC-SHA256 数据加密
        static ISecurity _HMACSHA256 = null;
        static readonly object _HMACSHA256Lock = new object();
        /// <summary>
        /// HMAC-SHA256 数据加密
        /// </summary>
        public static ISecurity HMAC_SHA256
        {
            get
            {
                if (_HMACSHA256 == null)
                {
                    lock (_HMACSHA256Lock)
                    {
                        if (_HMACSHA256 == null)
                        {
                            _HMACSHA256 = new HmacSHA256();
                        }
                    }
                }
                return _HMACSHA256;
            }
        }
        #endregion
        #region HMAC-SHA512 数据加密
        static ISecurity _HMACSHA512 = null;
        static readonly object _HMACSHA512Lock = new object();
        /// <summary>
        /// HMAC-SHA512 数据加密
        /// </summary>
        public static ISecurity HMAC_SHA512
        {
            get
            {
                if (_HMACSHA512 == null)
                {
                    lock (_HMACSHA512Lock)
                    {
                        if (_HMACSHA512 == null)
                        {
                            _HMACSHA512 = new HmacSHA512();
                        }
                    }
                }
                return _HMACSHA512;
            }
        }
        #endregion
    }

}
