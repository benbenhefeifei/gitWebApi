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
    /// AccountsSignin ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsSignin")]
    public partial class AccountsSignin // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _userid;
        /// <summary>
        /// 
        /// </summary>
        private DateTime _startdatetime = new DateTime(1900, 1, 1);
        /// <summary>
        /// 
        /// </summary>
        private DateTime _lastdatetime = new DateTime(1900, 1, 1);
        /// <summary>
        /// 连续签到天数
        /// </summary>
        private short _seriesdate = 0;
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
        /// 获取或设置 
        /// </summary>
        [Column("StartDateTime")]
        public DateTime StartDateTime
        {
            set { _startdatetime = value; }
            get { return _startdatetime; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("LastDateTime")]
        public DateTime LastDateTime
        {
            set { _lastdatetime = value; }
            get { return _lastdatetime; }
        }
        
        /// <summary>
        /// 获取或设置 连续签到天数
        /// </summary>
        [Column("SeriesDate")]
        public short SeriesDate
        {
            set { _seriesdate = value; }
            get { return _seriesdate; }
        }
        #endregion
    }
}
