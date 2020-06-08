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
    /// AccountsBaseEnsure ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsBaseEnsure")]
    public partial class AccountsBaseEnsure // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid;
        /// <summary>
        /// 领取日期
        /// </summary>
        private int _takedateid;
        /// <summary>
        /// 领取次数
        /// </summary>
        private short _taketimes = 0;
        /// <summary>
        /// 累计领取的金币
        /// </summary>
        private long _takegold = 0;
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
        /// 获取或设置 领取日期
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("TakeDateID")]
        public int TakeDateID
        {
            set { _takedateid = value; }
            get { return _takedateid; }
        }
        
        /// <summary>
        /// 获取或设置 领取次数
        /// </summary>
        [Column("TakeTimes")]
        public short TakeTimes
        {
            set { _taketimes = value; }
            get { return _taketimes; }
        }
        
        /// <summary>
        /// 获取或设置 累计领取的金币
        /// </summary>
        [Column("TakeGold")]
        public long TakeGold
        {
            set { _takegold = value; }
            get { return _takegold; }
        }
        #endregion
    }
}
