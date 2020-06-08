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
    /// AccountsVisitor ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsVisitor")]
    public partial class AccountsVisitor // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 游客ID
        /// </summary>
        private int _visitoruserid;
        /// <summary>
        /// 游客机器
        /// </summary>
        private string _visitormachine = "";
        /// <summary>
        /// 绑定标识
        /// </summary>
        private int _binduserid = 0;
        /// <summary>
        /// 绑定帐号
        /// </summary>
        private string _bindaccounts = "";
        /// <summary>
        /// 绑定类型(0新帐号，1旧帐号)
        /// </summary>
        private int _bindtype = 0;
        /// <summary>
        /// 插入日期
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 游客ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("VisitorUserID")]
        public int VisitorUserID
        {
            set { _visitoruserid = value; }
            get { return _visitoruserid; }
        }
        
        /// <summary>
        /// 获取或设置 游客机器
        /// </summary>
        [Column("VisitorMachine")]
        public string VisitorMachine
        {
            set { _visitormachine = value; }
            get { return _visitormachine; }
        }
        
        /// <summary>
        /// 获取或设置 绑定标识
        /// </summary>
        [Column("BindUserID")]
        public int BindUserID
        {
            set { _binduserid = value; }
            get { return _binduserid; }
        }
        
        /// <summary>
        /// 获取或设置 绑定帐号
        /// </summary>
        [Column("BindAccounts")]
        public string BindAccounts
        {
            set { _bindaccounts = value; }
            get { return _bindaccounts; }
        }
        
        /// <summary>
        /// 获取或设置 绑定类型(0新帐号，1旧帐号)
        /// </summary>
        [Column("BindType")]
        public int BindType
        {
            set { _bindtype = value; }
            get { return _bindtype; }
        }
        
        /// <summary>
        /// 获取或设置 插入日期
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
