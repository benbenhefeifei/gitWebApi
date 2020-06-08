/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:49
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:49 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AccountsProperty ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsProperty")]
    public partial class AccountsProperty // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid;
        /// <summary>
        /// 道具标识
        /// </summary>
        private int _propid;
        /// <summary>
        /// 房间标识
        /// </summary>
        private int _serverid;
        /// <summary>
        /// 道具数量
        /// </summary>
        private int _propcount = 0;
        /// <summary>
        /// 游戏标识
        /// </summary>
        private int _kindid = 0;
        /// <summary>
        /// 购买时间
        /// </summary>
        private DateTime _sendtime = DateTime.Now;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 用户标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 道具标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("PropID")]
        public int PropID
        {
            set { _propid = value; }
            get { return _propid; }
        }
        
        /// <summary>
        /// 获取或设置 房间标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("ServerID")]
        public int ServerID
        {
            set { _serverid = value; }
            get { return _serverid; }
        }
        
        /// <summary>
        /// 获取或设置 道具数量
        /// </summary>
        [Column("PropCount")]
        public int PropCount
        {
            set { _propcount = value; }
            get { return _propcount; }
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
        /// 获取或设置 购买时间
        /// </summary>
        [Column("SendTime")]
        public DateTime SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        #endregion
    }
}
