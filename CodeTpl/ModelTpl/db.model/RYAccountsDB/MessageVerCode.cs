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
    /// MessageVerCode ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("MessageVerCode")]
    public partial class MessageVerCode // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private string _vercode;
        /// <summary>
        /// 
        /// </summary>
        private string _mobile = "";
        /// <summary>
        /// 
        /// </summary>
        private DateTime _inserttime = new DateTime(1900, 1, 1);
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("VerCode")]
        public string VerCode
        {
            set { _vercode = value; }
            get { return _vercode; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("Mobile")]
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("InsertTime")]
        public DateTime InsertTime
        {
            set { _inserttime = value; }
            get { return _inserttime; }
        }
        #endregion
    }
}
