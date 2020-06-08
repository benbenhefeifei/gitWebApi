/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:51
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:51 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// SystemStatusInfo ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("SystemStatusInfo")]
    public partial class SystemStatusInfo // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 状态名字
        /// </summary>
        private string _statusname;
        /// <summary>
        /// 状态数值
        /// </summary>
        private decimal _statusvalue = 0M;
        /// <summary>
        /// 状态字符
        /// </summary>
        private string _statusstring = "";
        /// <summary>
        /// 状态显示名称
        /// </summary>
        private string _statustip = "";
        /// <summary>
        /// 字符的描述
        /// </summary>
        private string _statusdescription = "";
        /// <summary>
        /// 
        /// </summary>
        private int _sortid = 0;
        /// <summary>
        /// 0 显示
        /// </summary>
        private bool _isshow = true;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 状态名字
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("StatusName")]
        public string StatusName
        {
            set { _statusname = value; }
            get { return _statusname; }
        }
        
        /// <summary>
        /// 获取或设置 状态数值
        /// </summary>
        [Column("StatusValue")]
        public decimal StatusValue
        {
            set { _statusvalue = value; }
            get { return _statusvalue; }
        }
        
        /// <summary>
        /// 获取或设置 状态字符
        /// </summary>
        [Column("StatusString")]
        public string StatusString
        {
            set { _statusstring = value; }
            get { return _statusstring; }
        }
        
        /// <summary>
        /// 获取或设置 状态显示名称
        /// </summary>
        [Column("StatusTip")]
        public string StatusTip
        {
            set { _statustip = value; }
            get { return _statustip; }
        }
        
        /// <summary>
        /// 获取或设置 字符的描述
        /// </summary>
        [Column("StatusDescription")]
        public string StatusDescription
        {
            set { _statusdescription = value; }
            get { return _statusdescription; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("SortID")]
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        
        /// <summary>
        /// 获取或设置 0 显示
        /// </summary>
        [Column("IsShow")]
        public bool IsShow
        {
            set { _isshow = value; }
            get { return _isshow; }
        }
        #endregion
    }
}
