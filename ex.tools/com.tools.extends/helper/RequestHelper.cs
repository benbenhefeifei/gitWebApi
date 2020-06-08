using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections.Generic;

namespace com.xbao.tools.helper
{
    public class HttpClient
    {
        public HttpClient()
        {
            Charset = "UTF-8";
            AcceptType = "text/html";
            ContentType = "text/html";
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:60.0) Gecko/20100101 WebClient/10.0";
            Headers = new Dictionary<string, string>();
        }

        #region 请求扩展参数
        /// <summary>
        /// 获取或设置 请求字符集
        /// </summary>
        public string Charset { get; set; }
        /// <summary>
        /// 获取或设置 请求用户代理
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// 获取或设置 请求Accept类型
        /// </summary>
        public string AcceptType { get; set; }
        /// <summary>
        /// 获取或设置 请求内容类型
        /// </summary>
        public string ContentType { get; set; }
        /// <summary>
        /// 获取或设置 自定义请求授权
        /// </summary>
        public string Authorization { get; set; }
        /// <summary>
        /// 获取或设置 请求安全证书
        /// </summary>
        public string CertPath { get; set; }
        /// <summary>
        /// 获取或设置 请求安全KEY证书
        /// </summary>
        public string CertKeyPath { get; set; }
        /// <summary>
        /// 获取或设置 请求header
        /// </summary>
        public IDictionary<string, string> Headers { get; set; }
        #endregion

        /// <summary>
        /// 用于验证服务器安全信息的回调
        /// </summary>
        private bool RemoteCertificateValidate(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors error)
        {
            // cert.Import("", "", X509KeyStorageFlags.UserKeySet);
            Console.WriteLine("Warning, trust any certificate");
            return true;
        }
        /// <summary>
        /// 自定义HTTP请求（扩展）
        /// </summary>
        /// <param name="method">请求方式：POST|GET</param>
        /// <param name="url">请求地址，全路径地址</param>
        /// <param name="data">请求数据，可以为空</param>
        /// <param name="timeOut">请求超时时长：默认 10000 毫秒</param>
        public string Request(string method, string url, string data, int timeOut = 10000)
        {
            long timestamp = Convert.ToInt64((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalMilliseconds);
            Encoding encoding = Encoding.GetEncoding(Charset);

            if (!url.ToUpper().StartsWith("HTTP://") && url.ToUpper().StartsWith("HTTPS://")) { url = "http://" + url; }

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = method.ToUpper();
            request.Timeout = timeOut;
            request.Accept = AcceptType;
            request.ContentLength = (data ?? "").ToString().Length;
            request.ContentType = ContentType + ";charset=" + encoding.BodyName;
            if (!string.IsNullOrEmpty(UserAgent)) { request.UserAgent = UserAgent; }
            if (!string.IsNullOrEmpty(Authorization)) { request.Headers.Add("Authorization", Authorization); }
            if (!string.IsNullOrEmpty(CertPath)) { request.ClientCertificates.Add(new X509Certificate(CertPath)); }
            if (!string.IsNullOrEmpty(CertKeyPath)) { request.ClientCertificates.Add(new X509Certificate(CertKeyPath)); }

            //设置请求header
            if (Headers != null && Headers.Count > 0)
            {
                foreach (KeyValuePair<string, string> item in Headers)
                {
                    request.Headers.Add(item.Key, item.Value);
                }
            }
            //设置https验证方式
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(RemoteCertificateValidate);
            }
            //设置请求内容
            if (!string.IsNullOrWhiteSpace(data))
            {
                byte[] dataBuffer = encoding.GetBytes(data.ToString());
                request.ContentLength = dataBuffer.Length;
                using (Stream requestWriter = request.GetRequestStream())
                {
                    requestWriter.Write(dataBuffer, 0, dataBuffer.Length);
                }
            }

            string returnString = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response != null)
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream, encoding);
                        returnString = reader.ReadToEnd();
                        reader.Close();
                        stream.Close();
                    }
                }
            }
            return returnString;
        }

        /// <summary>
        /// 自定义HTTP GET请求（扩展）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="timeOut">请求超时时长</param>
        public static string Get(string url, int timeOut = 10000)
        {
            HttpClient client = new HttpClient();
            return client.Request("GET", url, null, timeOut);
        }
        /// <summary>
        /// 自定义HTTP POST请求（扩展）
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="data">请求传递数据</param>
        /// <param name="timeOut">请求超时时长</param>
        public static string Post(string url, string data, int timeOut = 10000)
        {
            HttpClient client = new HttpClient();
            return client.Request("POST", url, data, timeOut);
        }
    }


}
