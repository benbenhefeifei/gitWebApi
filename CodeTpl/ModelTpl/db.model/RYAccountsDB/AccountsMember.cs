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
    /// AccountsMember ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsMember")]
    public partial class AccountsMember // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid;
        /// <summary>
        /// 会员标识
        /// </summary>
        private byte _memberorder;
        /// <summary>
        /// 用户权限
        /// </summary>
        private int _userright = 0;
        /// <summary>
        /// 会员期限
        /// </summary>
        private DateTime _memberoverdate = DateTime.Now;
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
        /// 获取或设置 会员标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("MemberOrder")]
        public byte MemberOrder
        {
            set { _memberorder = value; }
            get { return _memberorder; }
        }
        
        /// <summary>
        /// 获取或设置 用户权限
        /// </summary>
        [Column("UserRight")]
        public int UserRight
        {
            set { _userright = value; }
            get { return _userright; }
        }
        
        /// <summary>
        /// 获取或设置 会员期限
        /// </summary>
        [Column("MemberOverDate")]
        public DateTime MemberOverDate
        {
            set { _memberoverdate = value; }
            get { return _memberoverdate; }
        }
        #endregion
    }
}
