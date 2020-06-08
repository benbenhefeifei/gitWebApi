/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:52
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:52 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// T_UserFill ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("T_UserFill")]
    public partial class UserFill // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _userid;
        /// <summary>
        /// 官充累计总额
        /// </summary>
        private decimal _amount = 0M;
        /// <summary>
        /// 
        /// </summary>
        private DateTime _firstfilldate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        private DateTime _lastfilldate = DateTime.Now;
        /// <summary>
        /// 线下充值次数
        /// </summary>
        private short _offlinecnt = 0;
        /// <summary>
        /// 线下充值总额
        /// </summary>
        private decimal _offlineamt = 0M;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 官充累计总额
        /// </summary>
        [Column("Amount")]
        public decimal Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("FirstFillDate")]
        public DateTime FirstFillDate
        {
            set { _firstfilldate = value; }
            get { return _firstfilldate; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("LastFillDate")]
        public DateTime LastFillDate
        {
            set { _lastfilldate = value; }
            get { return _lastfilldate; }
        }
        
        /// <summary>
        /// 获取或设置 线下充值次数
        /// </summary>
        [Column("OffLineCnt")]
        public short OffLineCnt
        {
            set { _offlinecnt = value; }
            get { return _offlinecnt; }
        }
        
        /// <summary>
        /// 获取或设置 线下充值总额
        /// </summary>
        [Column("OffLineAmt")]
        public decimal OffLineAmt
        {
            set { _offlineamt = value; }
            get { return _offlineamt; }
        }
        #endregion
    }
}
