/***********************************************
 * 版权声明：2020-2222 
 * 编写作者：吴文吉
 * 功能描述：数据库链接字符串模型
 * 创建时间：2017年12月19日 16点26分
 * 更新历史：日期 - 姓名 - 功能（日期倒序）
 * GOTO：2018年6月22日 15点11分 == wuwenji == 创建 == 
 * *********************************************/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace com.xbao.db.core
{
    /// <summary>
    /// 数据库链接字符串模型
    /// </summary>
    [Serializable]
    [XmlRoot("connectionStrings")]
    public class DbConfRoot
    {
        /// <summary>
        /// 获取或设置 是否加密（默认：true）
        /// </summary>
        [XmlAttribute("encrypt")]
        public bool Encrypt { get; set; }

        /// <summary>
        /// 获取或设置 链接串配置
        /// </summary>
        [XmlElement("add")]
        public List<DbConfItem> Settings { get; set; }
    }

    /// <summary>
    /// 数据库链接字符串模型
    /// </summary>
    [Serializable]
    public class DbConfItem
    {
        /// <summary>
        /// 获取或设置 DataBase 的 链接串名称
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置 DataBase 的 提供者，如：System.Data.SqlClient
        /// </summary>
        [XmlAttribute("providerName")]
        public string ProviderName { get; set; }
        /// <summary>
        /// 获取或设置 DataBase 的 链接字符串
        /// </summary>
        [XmlAttribute("connectionString")]
        public string ConnectionString { get; set; }
    }
}
