using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Dapper;
using Newtonsoft.Json;

namespace com.xbao.db.core
{
    /// <summary>
    /// 数据库读操作 通用接口基础实现（扩展）
    /// </summary>
    internal class GenericReader : GenericDbContext, IReader
    {
        /// <summary>
        /// 初始化数据读操作
        /// </summary>
        /// <param name="name">数据库类型</param>
        internal GenericReader(string dbName) : base(dbName, "Reader")
        {
        }

        /// <summary>
        /// 执行SQL语句并返回执行结果的数据行数
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（支持JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        public long Count(string commandText, object paramaters = null, CommandType commandType = CommandType.Text)
        {
            if (base.Connection == null)
            {
                helper.Logger.Instance.Error("DbReader.Count error ---- Connection is null");
                return 0;
            }
            try
            {
                using (DbConnection connection = base.Connection)
                {
                    helper.Logger.Instance.Info("DbReader.Count.SqlCmd ---- {0}", commandText);
                    if (paramaters != null)
                    {
                        helper.Logger.Instance.Info("DbReader.Count.SqlParams ---- {0}", JsonConvert.SerializeObject(paramaters));
                    }

                    DynamicParameters dynamicParams = base.ConvertParameter(paramaters);

                    dynamic result = connection.QueryFirstOrDefault(commandText, dynamicParams, commandType: commandType);

                    string count = result.TCOUNT.ToString();

                    return Convert.ToInt64(count);
                }
            }
            catch (Exception exception)
            {
                helper.Logger.Instance.Error("DbReader.Find error", exception);
                return 0;
            }
        }
        /// <summary>
        /// 执行SQL语句并返回执行结果
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        public T Find<T>(string commandText, object paramaters = null, CommandType commandType = CommandType.Text)
        {
            if (base.Connection == null)
            {
                helper.Logger.Instance.Error("DbReader.Find error ---- Connection is null");
                return default(T);
            }
            try
            {
                using (DbConnection connection = base.Connection)
                {
                    helper.Logger.Instance.Info("DbReader.Find.SqlCmd ---- {0}", commandText);
                    if (paramaters != null)
                    {
                        helper.Logger.Instance.Info("DbReader.Find.SqlParams ---- {0}", JsonConvert.SerializeObject(paramaters));
                    }

                    DynamicParameters dynamicParams = base.ConvertParameter(paramaters);

                    T result = connection.QueryFirstOrDefault<T>(commandText, dynamicParams, commandType: commandType);

                    return result;
                }
            }
            catch (Exception exception)
            {
                helper.Logger.Instance.Error("DbReader.Find error", exception);
                return default(T);
            }
        }
        /// <summary>
        /// 执行SQL语句并返回执行结果的数据集合
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        public IEnumerable<T> Filter<T>(string commandText, object paramaters = null, CommandType commandType = CommandType.Text)
        {
            if (base.Connection == null)
            {
                helper.Logger.Instance.Error("DbReader.Filter error ---- Connection is null");
                return new List<T>();
            }
            try
            {
                using (DbConnection connection = base.Connection)
                {
                    helper.Logger.Instance.Info("DbReader.Filter.SqlCmd ---- {0}", commandText);
                    if (paramaters != null)
                    {
                        helper.Logger.Instance.Info("DbReader.Filter.SqlParams ---- {0}", JsonConvert.SerializeObject(paramaters));
                    }

                    DynamicParameters dynamicParams = base.ConvertParameter(paramaters);

                    IEnumerable<T> result = connection.Query<T>(commandText, dynamicParams, commandType: commandType);

                    return result;
                }
            }
            catch (Exception exception)
            {
                helper.Logger.Instance.Error("DbReader.Filter error", exception);
                return new List<T>();
            }
        }
        /// <summary>
        /// 执行SQL语句并返回执行结果的数据集合
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        public DataTable ExecuteToDataTable(string commandText, object parameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable dataTable = new DataTable();
            if (base.Connection == null)
            {
                helper.Logger.Instance.Error("DbReader.ExecuteToDataTable error ---- Connection is null");
                return dataTable;
            }

            try
            {
                using (DbConnection connection = base.Connection)
                {
                    helper.Logger.Instance.Info("DbReader.ExecuteToDataTable.SqlCmd ---- {0}", commandText);
                    if (parameters != null)
                    {
                        helper.Logger.Instance.Info("DbReader.ExecuteToDataTable.SqlParams ---- {0}", JsonConvert.SerializeObject(parameters));
                    }

                    DbDataAdapter dbDataAdapter = null;
                    switch (base.DbSetting.ProviderName)
                    {
                        case "System.Data.SqlClient": dbDataAdapter = new System.Data.SqlClient.SqlDataAdapter(); break;
                        case "MySql.Data.MySqlClient": dbDataAdapter = new MySql.Data.MySqlClient.MySqlDataAdapter(); break;
                    }

                    if (dbDataAdapter != null)
                    {
                        if (connection.State != ConnectionState.Open) { connection.Open(); }
                        using (DbCommand command = connection.CreateCommand())
                        {
                            command.Connection = connection;
                            command.CommandType = commandType;
                            command.CommandText = commandText;
                            if (parameters != null) { base.ConvertParameter(command, parameters); }
                            dbDataAdapter.SelectCommand = command;
                        }
                        dbDataAdapter.Fill(dataTable);
                        dbDataAdapter.Dispose();
                    }
                    return dataTable;
                }
            }
            catch (Exception exception)
            {
                helper.Logger.Instance.Error("DbReader.ExecuteToDataTable error", exception);
                return dataTable;
            }
        }

        public void Dispose()
        {
            GC.Collect();
            base.Connection.Dispose();
        }
        
    }
}
