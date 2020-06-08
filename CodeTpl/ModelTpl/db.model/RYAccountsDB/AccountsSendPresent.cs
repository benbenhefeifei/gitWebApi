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
    /// AccountsSendPresent ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsSendPresent")]
    public partial class AccountsSendPresent // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 赠送ID
        /// </summary>
        private int _id;
        /// <summary>
        /// 赠送者用户ID
        /// </summary>
        private int _userid = 0;
        /// <summary>
        /// 接收者 用户ID
        /// </summary>
        private int _receiveruserid = 0;
        /// <summary>
        /// 赠送的道具ID
        /// </summary>
        private int _propid = 0;
        /// <summary>
        /// 赠送的道具数量
        /// </summary>
        private int _propcount = 0;
        /// <summary>
        /// 赠送的时间
        /// </summary>
        private DateTime _sendtime = new DateTime(1900, 1, 1);
        /// <summary>
        /// 0:已经赠送,等待接收者接收   1:已经被接收
        /// </summary>
        private short _propstatus = 0;
        /// <summary>
        /// 赠送者的 客户端IP
        /// </summary>
        private string _clientip = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 赠送ID
        /// </summary>
        [Key][Column("ID")]
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        
        /// <summary>
        /// 获取或设置 赠送者用户ID
        /// </summary>
        [Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 接收者 用户ID
        /// </summary>
        [Column("ReceiverUserID")]
        public int ReceiverUserID
        {
            set { _receiveruserid = value; }
            get { return _receiveruserid; }
        }
        
        /// <summary>
        /// 获取或设置 赠送的道具ID
        /// </summary>
        [Column("PropID")]
        public int PropID
        {
            set { _propid = value; }
            get { return _propid; }
        }
        
        /// <summary>
        /// 获取或设置 赠送的道具数量
        /// </summary>
        [Column("PropCount")]
        public int PropCount
        {
            set { _propcount = value; }
            get { return _propcount; }
        }
        
        /// <summary>
        /// 获取或设置 赠送的时间
        /// </summary>
        [Column("SendTime")]
        public DateTime SendTime
        {
            set { _sendtime = value; }
            get { return _sendtime; }
        }
        
        /// <summary>
        /// 获取或设置 0:已经赠送,等待接收者接收   1:已经被接收
        /// </summary>
        [Column("PropStatus")]
        public short PropStatus
        {
            set { _propstatus = value; }
            get { return _propstatus; }
        }
        
        /// <summary>
        /// 获取或设置 赠送者的 客户端IP
        /// </summary>
        [Column("ClientIP")]
        public string ClientIP
        {
            set { _clientip = value; }
            get { return _clientip; }
        }
        #endregion
    }
}
