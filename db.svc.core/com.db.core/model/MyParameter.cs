using System;
using System.Data;

namespace com.xbao.db.core
{
    
    /// <summary>
    /// 继承与 DbParameter 的自定义 数据操作参数
    /// </summary>
    internal class MyParameter
    {
        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="direction">是否输入参数（Input = 1, Output = 2, InputOutput = 3, ReturnValue = 6）</param>
        public MyParameter(string name, object value, int? direction)
        {
            this.Value = value;
            this.ParameterName = name;
            if (direction.HasValue) { direction = (int)ParameterDirection.Input; }
            this.Direction = (ParameterDirection)direction.Value;
            this.ResetDbType();
        }
        /// <summary>
        /// 初始化参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="type">参数类型</param>
        /// <param name="direction">是否输入参数（Input = 1, Output = 2, InputOutput = 3, ReturnValue = 6）</param>
        /// <param name="size">参数长度</param>
        public MyParameter(string name, object value, DbType? type = null, int? direction = null, int? size = null)
        {
            this.Value = value;
            this.ParameterName = name;
            if (size.HasValue) { this.Size = size.Value; }
            if (type.HasValue) { this.DbType = type.Value; }
            if (direction.HasValue) { this.Direction = (ParameterDirection)direction.Value; }
        }

        /// <summary>
        /// 获取或设置 参数名称
        /// </summary>
        public string ParameterName { get; set; }
        /// <summary>
        /// 获取或设置 参数类型，参考 System.Data.DbType
        /// </summary>
        public DbType DbType { get; set; }
        /// <summary>
        /// 获取或设置 参数值
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 获取或设置 参数长度
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        /// 获取或设置 是否允许NULL
        /// </summary>
        public bool IsNullable { get; set; }
        /// <summary>
        /// 获取或设置 是否输出参数
        /// </summary>
        public ParameterDirection Direction { get; set; }

        /// <summary>
        /// 根据键值返回自定义参数
        /// </summary>
        public void ResetDbType()
        {
            Boolean outBoolean = false;
            UInt16 outUInt16 = 0;
            Int16 outInt16 = 0;
            UInt32 outUInt32 = 0;
            Int32 outInt32 = 0;
            Int64 outInt64 = 0;
            Decimal outDecimal = 0;
            DateTime outDateTime = DateTime.Now;
            string tmpValue = this.Value.ToString();
            if (Boolean.TryParse(tmpValue, out outBoolean))
            {
                this.Size = 2;
                this.Value = outBoolean;
                this.DbType = DbType.Boolean;
            }
            else if (UInt16.TryParse(tmpValue, out outUInt16))
            {
                this.Size = 5;
                this.Value = outUInt16;
                this.DbType = DbType.UInt16;
            }
            else if (Int16.TryParse(tmpValue, out outInt16))
            {
                this.Size = 5;
                this.Value = outInt16;
                this.DbType = DbType.Int16;
            }
            else if (UInt32.TryParse(tmpValue, out outUInt32))
            {
                this.Size = 10;
                this.Value = outUInt32;
                this.DbType = DbType.UInt32;
            }
            else if (Int32.TryParse(tmpValue, out outInt32))
            {
                this.Size = 10;
                this.Value = outInt32;
                this.DbType = DbType.Int32;
            }
            else if (Int64.TryParse(tmpValue, out outInt64))
            {
                this.Size = 20;
                this.Value = outInt64;
                this.DbType = DbType.Int64;
            }
            else if (Decimal.TryParse(tmpValue, out outDecimal))
            {
                this.Size = 20;
                this.Value = outDecimal;
                this.DbType = DbType.Decimal;
            }
            else if (DateTime.TryParse(tmpValue, out outDateTime))
            {
                this.Size = tmpValue.Length;
                this.Value = outDateTime;
                this.DbType = DbType.DateTime;
            }
            else
            {
                this.Size = tmpValue.Length;
                this.DbType = DbType.String;
            }
        }
    }
}
