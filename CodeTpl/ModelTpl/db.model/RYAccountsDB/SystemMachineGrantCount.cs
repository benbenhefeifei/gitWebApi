/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:51
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:51 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// SystemMachineGrantCount ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("SystemMachineGrantCount")]
    public partial class SystemMachineGrantCount // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _dateid;
        /// <summary>
        /// 注册机器
        /// </summary>
        private string _registermachine;
        /// <summary>
        /// 注册地址
        /// </summary>
        private string _registerip = "";
        /// <summary>
        /// 赠送金币
        /// </summary>
        private decimal _grantscore = 0m;
        /// <summary>
        /// 赠送次数
        /// </summary>
        private long _grantcount = 0;
        /// <summary>
        /// 收集时间
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("DateID")]
        public int DateID
        {
            set { _dateid = value; }
            get { return _dateid; }
        }
        
        /// <summary>
        /// 获取或设置 注册机器
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("RegisterMachine")]
        public string RegisterMachine
        {
            set { _registermachine = value; }
            get { return _registermachine; }
        }
        
        /// <summary>
        /// 获取或设置 注册地址
        /// </summary>
        [Column("RegisterIP")]
        public string RegisterIP
        {
            set { _registerip = value; }
            get { return _registerip; }
        }
        
        /// <summary>
        /// 获取或设置 赠送金币
        /// </summary>
        [Column("GrantScore")]
        public decimal GrantScore
        {
            set { _grantscore = value; }
            get { return _grantscore; }
        }
        
        /// <summary>
        /// 获取或设置 赠送次数
        /// </summary>
        [Column("GrantCount")]
        public long GrantCount
        {
            set { _grantcount = value; }
            get { return _grantcount; }
        }
        
        /// <summary>
        /// 获取或设置 收集时间
        /// </summary>
        [Column("CollectDate")]
        public DateTime CollectDate
        {
            set { _collectdate = value; }
            get { return _collectdate; }
        }
        #endregion
    }
}
