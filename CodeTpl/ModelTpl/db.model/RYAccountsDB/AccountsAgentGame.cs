/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:48
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:48 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AccountsAgentGame ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsAgentGame")]
    public partial class AccountsAgentGame // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _id;
        /// <summary>
        /// 代理标识
        /// </summary>
        private int _agentid = 0;
        /// <summary>
        /// 游戏标识
        /// </summary>
        private int _kindid = 0;
        /// <summary>
        /// 设备标识(1:大厅,2:手机)
        /// </summary>
        private int _deviceid = 0;
        /// <summary>
        /// 排序
        /// </summary>
        private int _sortid = 0;
        /// <summary>
        /// 创建日期
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Key][Column("ID")]
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        
        /// <summary>
        /// 获取或设置 代理标识
        /// </summary>
        [Column("AgentID")]
        public int AgentID
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        
        /// <summary>
        /// 获取或设置 游戏标识
        /// </summary>
        [Column("KindID")]
        public int KindID
        {
            set { _kindid = value; }
            get { return _kindid; }
        }
        
        /// <summary>
        /// 获取或设置 设备标识(1:大厅,2:手机)
        /// </summary>
        [Column("DeviceID")]
        public int DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
        
        /// <summary>
        /// 获取或设置 排序
        /// </summary>
        [Column("SortID")]
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        
        /// <summary>
        /// 获取或设置 创建日期
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
