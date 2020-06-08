/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:50
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:50 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AndroidLockInfo ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AndroidLockInfo")]
    public partial class AndroidLockInfo // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 机器标识
        /// </summary>
        private int _userid;
        /// <summary>
        /// 机器密码
        /// </summary>
        private string _logonpass = "n";
        /// <summary>
        /// 
        /// </summary>
        private byte _androidstatus = 0;
        /// <summary>
        /// 房间标识
        /// </summary>
        private int _serverid = 0;
        /// <summary>
        /// 批次标识
        /// </summary>
        private int _batchid = 0;
        /// <summary>
        /// 插入日期
        /// </summary>
        private DateTime _lockdatetime = DateTime.Now;
        /// <summary>
        /// 会员等级
        /// </summary>
        private byte _memberorder = 0;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 机器标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 机器密码
        /// </summary>
        [Column("LogonPass")]
        public string LogonPass
        {
            set { _logonpass = value; }
            get { return _logonpass; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("AndroidStatus")]
        public byte AndroidStatus
        {
            set { _androidstatus = value; }
            get { return _androidstatus; }
        }
        
        /// <summary>
        /// 获取或设置 房间标识
        /// </summary>
        [Column("ServerID")]
        public int ServerID
        {
            set { _serverid = value; }
            get { return _serverid; }
        }
        
        /// <summary>
        /// 获取或设置 批次标识
        /// </summary>
        [Column("BatchID")]
        public int BatchID
        {
            set { _batchid = value; }
            get { return _batchid; }
        }
        
        /// <summary>
        /// 获取或设置 插入日期
        /// </summary>
        [Column("LockDateTime")]
        public DateTime LockDateTime
        {
            set { _lockdatetime = value; }
            get { return _lockdatetime; }
        }
        
        /// <summary>
        /// 获取或设置 会员等级
        /// </summary>
        [Column("MemberOrder")]
        public byte MemberOrder
        {
            set { _memberorder = value; }
            get { return _memberorder; }
        }
        #endregion
    }
}
