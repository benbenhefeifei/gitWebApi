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
    /// T_UserSetIP ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("T_UserSetIP")]
    public partial class UserSetIP // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _userid;
        /// <summary>
        /// 
        /// </summary>
        private string _setip = "";
        /// <summary>
        /// 
        /// </summary>
        private DateTime _updatetime = DateTime.Now;
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
        [Column("SetIP")]
        public string SetIP
        {
            set { _setip = value; }
            get { return _setip; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("UpdateTime")]
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        #endregion
    }
}
