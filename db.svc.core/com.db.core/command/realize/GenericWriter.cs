/***********************************************
* 版权声明：2017-2020 
* 编写作者：技术总监CTO == 吴文吉
* 功能描述：数据库写操作通用接口基础实现
* 创建时间：2017年12月19日 16点26分
* 更新历史：日期 - 姓名 - 功能（日期倒序）    
 * GOTO：2017-08-07 15:27:38 == wuwenji == 创建 == 
* *********************************************/

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Dapper;
using Newtonsoft.Json;

namespace com.xbao.db.core
{
    /// <summary>
    /// 数据库写操作 通用接口基础实现（扩展）
    /// </summary>
    internal class GenericWriter : GenericDbContext, IWriter
    {
        /// <summary>
        /// 初始化数据写操作
        /// </summary>
        /// <param name="name">数据库类型</param>
        internal GenericWriter(string dbName) : base(dbName, "Writer")
        {
        }

        /// <summary>
        /// 执行SQL语句并返回所执行的行数
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        public int ExecuteNonQuery(string commandText, object paramaters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                if (base.Connection == null)
                {
                    helper.Logger.Instance.Error("DbWriter.ExecuteNonQuery error ---- Connection is null");
                }
                else
                {
                    using (DbConnection connection = base.Connection)
                    {
                        helper.Logger.Instance.Info("DbWriter.ExecuteNonQuery.SqlCmd ---- {0}", commandText);
                        if (paramaters != null)
                        {
                            helper.Logger.Instance.Info("DbWriter.ExecuteNonQuery.SqlParams ---- {0}", JsonConvert.SerializeObject(paramaters));
                        }

                        DynamicParameters dynamicParams = base.ConvertParameter(paramaters);

                        int result = connection.Execute(commandText, dynamicParams, commandType: commandType);

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Logger.Instance.Error("DbWriter.ExecuteNonQuery error", ex);
            }
            return 0;
        }
        /// <summary>
        /// 执行SQL语句并返回所执行返回结果
        /// </summary>
        /// <param name="commandText">SQL执行语句，支持存储过程</param>
        /// <param name="paramaters">筛选条件（JSON格式:new{ a=b,b=12 }）</param>
        /// <param name="commandType">SQL执行语句类型</param>
        public object ExecuteScalar(string commandText, object paramaters = null, CommandType commandType = CommandType.Text)
        {
            try
            {
                if (base.Connection == null)
                {
                    helper.Logger.Instance.Error("DbWriter.ExecuteScalar error ---- Connection is null");
                }
                else
                {
                    using (DbConnection connection = base.Connection)
                    {
                        helper.Logger.Instance.Info("DbWriter.ExecuteScalar.SqlCmd ---- {0}", commandText);
                        if (paramaters != null)
                        {
                            helper.Logger.Instance.Info("DbWriter.ExecuteScalar.SqlParams ---- {0}", JsonConvert.SerializeObject(paramaters));
                        }
                        DynamicParameters dynamicParams = base.ConvertParameter(paramaters);

                        //if (commandType == CommandType.Text && commandText.StartsWith("INSERT INTO"))
                        //{
                        //    commandText = commandText.TrimEnd(';') + "; SELECT SCOPE_IDENTITY();";
                        //}

                        object result = connection.ExecuteScalar(commandText, dynamicParams, commandType: commandType);

                        return commandType == CommandType.StoredProcedure ? 1 : result;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Logger.Instance.Error("DbWriter.ExecuteScalar error", ex);
            }
            return null;
        }
        /// <summary>
        /// 批量操作数据
        /// </summary>
        /// <param name="dataSource">数据源</param>
        /// <param name="targetTable">目标数据表名</param>
        public bool BulkCopy(DataTable dataSource, string targetTable)
        {
            try
            {
                if (base.Connection == null)
                {
                    helper.Logger.Instance.Error("DbWriter.BulkCopy error ---- Connection is null");
                }
                else if (base.DbSetting.ProviderName != "System.Data.SqlClient")
                {
                    helper.Logger.Instance.Error("DbWriter.BulkCopy error ---- Connection of ProviderName is not System.Data.SqlClient");
                }
                else
                {
                    using (System.Data.SqlClient.SqlConnection connection = (System.Data.SqlClient.SqlConnection)base.Connection)
                    {
                        if (connection.State == ConnectionState.Closed) { connection.Open(); }

                        System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(connection);
                        foreach (DataColumn item in dataSource.Columns)
                        {
                            bulkCopy.ColumnMappings.Add(item.ColumnName, item.ColumnName);
                        }
                        bulkCopy.DestinationTableName = targetTable;
                        bulkCopy.BulkCopyTimeout = 1000;
                        bulkCopy.WriteToServer(dataSource);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                helper.Logger.Instance.Error("DbWriter.BulkCopy error", ex);
            }
            return false;
        }

        public void Dispose()
        {
            GC.Collect();
            base.Connection.Dispose();
        }
    }
}
