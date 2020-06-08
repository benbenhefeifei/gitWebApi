/***********************************************
 * 版权声明：2020-2222 
 * 编写作者：吴文吉
 * 功能描述：数据库连接字符串配置管理
 * 创建时间：2017年12月19日 16点26分
 * 更新历史：日期 - 姓名 - 功能（日期倒序）
 * GOTO：2018年6月22日 15点11分 == wuwenji == 创建 == 
 * *********************************************/

using System;
using System.IO;
using System.Text;
using System.Configuration;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace com.xbao.db.core.helper
{
    /// <summary>
    /// 数据库连接字符串配置管理
    /// </summary>
    internal class ConfigManager
    {
        private static string xmlPath = ConfigurationManager.AppSettings["MyDb.Config.Path"];

        /// <summary>
        /// 数据库配置信息
        /// </summary>
        internal static List<DbConfItem> DbSettings { get; private set; }

        /// <summary>
        /// 是否加密（默认：true）
        /// </summary>
        internal static bool Encrypt { get; private set; }

        /// <summary>
        /// 静态初始化函数，初始化数据库配置
        /// </summary>
        static ConfigManager()
        {
            try
            {
                Encrypt = false;
                DbSettings = new List<DbConfItem>();

                if (string.IsNullOrEmpty(xmlPath)) { xmlPath = "C:\\DbConfig\\MyDb.config"; }
                if (xmlPath.Contains("AppStartup"))
                {
                    string _basePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin/Debug/netcoreapp3.1/", "");
                    xmlPath = xmlPath.Replace("AppStartup/", _basePath);
                }
                string xmlString = new StreamReader(xmlPath).ReadToEnd();

                // XML序列化对象
                if (!string.IsNullOrEmpty(xmlString))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DbConfRoot));

                    using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
                    {
                        DbConfRoot result = (DbConfRoot)serializer.Deserialize(stream);

                        if (result != null)
                        {
                            Encrypt = result.Encrypt;

                            DbSettings = result.Settings;
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                Logger.Instance.Error("DbConfigManager.Serializer is error", exception);
            }
        }
    }
}
