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
    /// ConfineContent ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("ConfineContent")]
    public partial class ConfineContent // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _contentid;
        /// <summary>
        /// 保留字符
        /// </summary>
        private string _string = "";
        /// <summary>
        /// 有效时间
        /// </summary>
        private DateTime? _enjoinoverdate = 0;
        /// <summary>
        /// 录入日期
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Key][Column("ContentID")]
        public int ContentID
        {
            set { _contentid = value; }
            get { return _contentid; }
        }
        
        /// <summary>
        /// 获取或设置 保留字符
        /// </summary>
        [Column("String")]
        public string String
        {
            set { _string = value; }
            get { return _string; }
        }
        
        /// <summary>
        /// 获取或设置 有效时间
        /// </summary>
        [Column("EnjoinOverDate")]
        public DateTime? EnjoinOverDate
        {
            set { _enjoinoverdate = value; }
            get { return _enjoinoverdate; }
        }
        
        /// <summary>
        /// 获取或设置 录入日期
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
