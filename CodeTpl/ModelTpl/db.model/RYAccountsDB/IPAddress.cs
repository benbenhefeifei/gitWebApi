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
    /// IPAddress ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("IPAddress")]
    public partial class IPAddress // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _id;
        /// <summary>
        /// 
        /// </summary>
        private decimal _startipnum = 0m;
        /// <summary>
        /// 
        /// </summary>
        private string _startiptext = "";
        /// <summary>
        /// 
        /// </summary>
        private decimal _endipnum = 0m;
        /// <summary>
        /// 
        /// </summary>
        private string _endiptext = "";
        /// <summary>
        /// 
        /// </summary>
        private string _country = "";
        /// <summary>
        /// 
        /// </summary>
        private string _local = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("ID")]
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("StartIPNum")]
        public decimal StartIPNum
        {
            set { _startipnum = value; }
            get { return _startipnum; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("StartIPText")]
        public string StartIPText
        {
            set { _startiptext = value; }
            get { return _startiptext; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("EndIPNum")]
        public decimal EndIPNum
        {
            set { _endipnum = value; }
            get { return _endipnum; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("EndIPText")]
        public string EndIPText
        {
            set { _endiptext = value; }
            get { return _endiptext; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("Country")]
        public string Country
        {
            set { _country = value; }
            get { return _country; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("Local")]
        public string Local
        {
            set { _local = value; }
            get { return _local; }
        }
        #endregion
    }
}
