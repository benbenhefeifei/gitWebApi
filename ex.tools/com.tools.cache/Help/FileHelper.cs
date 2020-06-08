using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace com.xbao.tools.cache.Help
{
    public class FileHelper : IDisposable
    {
        static readonly object _lock = new object();
        static string _conf { get { return ConfigurationManager.AppSettings["FileDb:Server.Cache"]; } }

        private bool scase = false;
        private string basePath = "";

        public FileHelper()
        {
            if (!string.IsNullOrEmpty(_conf) && _conf.Contains("|"))
            {
                string[] setting = _conf.Split('|');
                if (_conf.Contains("Switch=")) { scase = setting.First(s => s.StartsWith("Switch=")).ToLower() == "switch=true"; }
                if (_conf.Contains("Path=")) { basePath = setting.First(s => s.StartsWith("Path=")).Replace("Path=", ""); }

                basePath = basePath.Replace("AppStartup/", AppDomain.CurrentDomain.BaseDirectory).Trim('/');
            }
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
        }

        public bool Remove(string key)
        {
            try
            {
                File.Delete(basePath + "/" + key);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Writer(string key, object value, bool append = true)
        {
            try
            {
                JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                {
                    //这句是解决问题的关键,也就是json.net官方给出的解决配置选项.
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                };

                if (append)
                {
                    File.AppendAllText(basePath + "/" + key, JsonConvert.SerializeObject(value, jsonSettings));
                }
                else
                {
                    File.WriteAllText(basePath + "/" + key, JsonConvert.SerializeObject(value, jsonSettings));
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T Reader<T>(string key)
        {
            try
            {
                string text = File.ReadAllText(basePath + "/" + key);
                if (!string.IsNullOrEmpty(text))
                {
                    return JsonConvert.DeserializeObject<T>(text);
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
