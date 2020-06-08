using System;
using System.Security;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using System.Linq;

namespace com.xbao.db.core
{
    internal class GenericDbContext
    {
        /// <summary>
        /// 数据库配置链接对象
        /// </summary>
        internal DbConfItem DbSetting { get; private set; }

        internal GenericDbContext(string dbName, string dbMode)
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                helper.Logger.Instance.Error("GenericDbContext parameter dbName is NULL");
            }
            else
            {
                string connectionName = string.Format("ConnectionString_{0}_{1}", dbName, dbMode);
                // 默认先从项目Web|App.Config获取链接字符串
                ConnectionStringSettings dbSettings = ConfigurationManager.ConnectionStrings[connectionName];
                if (dbSettings != null && !string.IsNullOrWhiteSpace(dbSettings.ConnectionString))
                {
                    DbSetting = new DbConfItem()
                    {
                        Name = connectionName,
                        ProviderName = dbSettings.ProviderName,
                        ConnectionString = dbSettings.ConnectionString
                    };
                }
                // 从自定配置获取数据库配置信息
                if (!(DbSetting != null && !string.IsNullOrWhiteSpace(DbSetting.Name)))
                {
                    DbSetting = helper.ConfigManager.DbSettings.Find(item => item.Name == connectionName);
                }
                if (!(DbSetting != null && !string.IsNullOrWhiteSpace(DbSetting.ConnectionString)))
                {
                    helper.Logger.Instance.Error("Database connection configuration does not exist or is empty");
                }
                else if (helper.ConfigManager.Encrypt)
                {
                    DbSetting.ConnectionString = QQTools.Decrypt(DbSetting.ConnectionString, DbSetting.Name);
                }
            }
        }

        /// <summary>
        /// 获取或设置 DataBase 的 链接对象
        /// </summary>
        internal DbConnection Connection
        {
            get
            {
                if (!(DbSetting != null && !string.IsNullOrWhiteSpace(DbSetting.Name)))
                {
                    helper.Logger.Instance.Fatal("DbConnection Settings is null");
                    return null;
                }
                DbConnection _Connection = null;
                switch (DbSetting.ProviderName)
                {
                    case "System.Data.SqlClient":
                        _Connection = new System.Data.SqlClient.SqlConnection(DbSetting.ConnectionString);
                        break;
                    case "MySql.Data.MySqlClient":
                        _Connection = new MySql.Data.MySqlClient.MySqlConnection(DbSetting.ConnectionString);
                        break;
                }
                if (_Connection != null)
                {
                    switch (_Connection.State)
                    {
                        case System.Data.ConnectionState.Broken:
                            _Connection.Close();
                            _Connection.Open();
                            break;
                        case System.Data.ConnectionState.Closed:
                            _Connection.Open();
                            break;
                    }
                }
                else
                {
                    helper.Logger.Instance.Fatal("DbConnection to server failed -- please confirm whether the server allows connections?");
                }
                return _Connection;
            }
        }
        /// <summary>
        /// 格式化执行参数
        /// </summary>
        /// <param name="paramaters">条件参数，支持JSON格式和MyParameter集合</param>
        /// <returns> return Dapper.DynamicParameters </returns>
        internal Dapper.DynamicParameters ConvertParameter(object paramaters)
        {
            try
            {
                Dapper.DynamicParameters dynamicParams = new Dapper.DynamicParameters();
                if (paramaters != null && paramaters.GetType() == typeof(Newtonsoft.Json.Linq.JObject))
                {
                    IDictionary<string, object> pargs = JsonConvert.DeserializeObject<IDictionary<string, object>>(JsonConvert.SerializeObject(paramaters));
                    foreach (string item in pargs.Keys)
                    {
                        MyParameter parameter = new MyParameter(item, pargs[item]);
                        string name = parameter.ParameterName.Replace("@", "");
                        dynamicParams.Add("@" + name, parameter.Value, parameter.DbType, parameter.Direction, parameter.Size);
                    }
                    return dynamicParams;
                }
                else
                {
                    switch (paramaters.GetType().ToString())
                    {
                        case "System.Collections.Generic.List`1[com.xbao.db.core.MyParameter]":
                        case "System.Collections.Generic.IList`1[com.xbao.db.core.MyParameter]":
                        case "System.Collections.Generic.IEnumerable`1[com.xbao.db.core.MyParameter]":
                            foreach (MyParameter item in (IEnumerable<MyParameter>)paramaters)
                            {
                                string name = item.ParameterName.Replace("@", "");
                                dynamicParams.Add("@" + name, item.Value, item.DbType, item.Direction, item.Size);
                            }
                            return dynamicParams;
                        case "System.Collections.Generic.Dictionary`2[System.String,System.Object]":
                        case "System.Collections.Generic.IDictionary`2[System.String,System.Object]":
                            foreach (KeyValuePair<string, object> item in (Dictionary<string, object>)paramaters)
                            {
                                MyParameter parameter = new MyParameter(item.Key, item.Value);
                                string name = parameter.ParameterName.Replace("@", "");
                                dynamicParams.Add("@" + name, parameter.Value, parameter.DbType, parameter.Direction, parameter.Size);
                            }
                            return dynamicParams;
                        case "System.Collections.Generic.List`1[System.Collections.Generic.KeyValuePair`2[System.String,System.Object]]":
                        case "System.Collections.Generic.IList`1[System.Collections.Generic.KeyValuePair`2[System.String,System.Object]]":
                        case "System.Collections.Generic.IEnumerable`1[System.Collections.Generic.KeyValuePair`2[System.String,System.Object]]":
                            foreach (KeyValuePair<string, object> item in (IEnumerable<KeyValuePair<string, object>>)paramaters)
                            {
                                MyParameter parameter = new MyParameter(item.Key, item.Value);
                                string name = parameter.ParameterName.Replace("@", "");
                                dynamicParams.Add("@" + name, parameter.Value, parameter.DbType, parameter.Direction, parameter.Size);
                            }
                            return dynamicParams;
                    }
                }
            }
            catch (Exception exception)
            {
                helper.Logger.Instance.Error("DbContext.ConvertParameter error", exception);
            }
            return null;
        }
        /// <summary>
        /// 格式化执行参数 至 DbCommand
        /// </summary>
        /// <param name="command">执行命令DbCommand</param>
        /// <param name="parameters">条件参数，支持JSON格式和MyParameter集合</param>
        internal void ConvertParameter(DbCommand command, object parameters)
        {
            try
            {
                List<MyParameter> myParams = new List<MyParameter>();
                if (parameters != null && parameters.GetType() == typeof(Newtonsoft.Json.Linq.JObject))
                {
                    IDictionary<string, object> pargs = JsonConvert.DeserializeObject<Dictionary<string, object>>(JsonConvert.SerializeObject(parameters));
                    foreach (KeyValuePair<string, object> item in pargs)
                    {
                        myParams.Add(new MyParameter(item.Key, item.Value));
                    }
                }
                else
                {
                    switch (parameters.GetType().ToString())
                    {
                        case "System.Collections.Generic.List`1[com.xbao.db.core.MyParameter]":
                        case "System.Collections.Generic.IList`1[com.xbao.db.core.MyParameter]":
                        case "System.Collections.Generic.IEnumerable`1[com.xbao.db.core.MyParameter]":
                            myParams = (List<MyParameter>)parameters;
                            break;
                        case "System.Collections.Generic.Dictionary`2[System.String,System.Object]":
                        case "System.Collections.Generic.IDictionary`2[System.String,System.Object]":
                            foreach (KeyValuePair<string, object> item in (IDictionary<string, object>)parameters)
                            {
                                myParams.Add(new MyParameter(item.Key, item.Value));
                            }
                            break;
                        case "System.Collections.Generic.List`1[System.Collections.Generic.KeyValuePair`2[System.String,System.Object]]":
                        case "System.Collections.Generic.IList`1[System.Collections.Generic.KeyValuePair`2[System.String,System.Object]]":
                        case "System.Collections.Generic.IEnumerable`1[System.Collections.Generic.KeyValuePair`2[System.String,System.Object]]":
                            foreach (KeyValuePair<string, object> item in (IEnumerable<KeyValuePair<string, object>>)parameters)
                            {
                                myParams.Add(new MyParameter(item.Key, item.Value));
                            }
                            break;
                    }
                }

                if (myParams.Count > 0)
                {
                    List<DbParameter> result = new List<DbParameter>();
                    foreach (MyParameter pitem in myParams)
                    {
                        string name = pitem.ParameterName.Replace("@", "");
                        DbParameter parameter = command.CreateParameter();
                        parameter.Size = pitem.Size;
                        parameter.Value = pitem.Value;
                        parameter.DbType = pitem.DbType;
                        parameter.Direction = pitem.Direction;
                        parameter.ParameterName = "@" + name;
                        result.Add(parameter);
                    }
                    command.Parameters.AddRange(result.ToArray());
                }
            }
            catch (Exception exception)
            {
                helper.Logger.Instance.Error("DbContext.DbCommand.ConvertParameter error", exception);
            }
        }
    }
}
