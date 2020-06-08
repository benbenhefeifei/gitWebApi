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
    /// rds168411 ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("rds168411")]
    public partial class Rds168411 // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _drawid;
        /// <summary>
        /// 
        /// </summary>
        private int _userid = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _chairid = 0;
        /// <summary>
        /// 
        /// </summary>
        private decimal _score = 0m;
        /// <summary>
        /// 
        /// </summary>
        private long _grade = 0;
        /// <summary>
        /// 
        /// </summary>
        private decimal _revenue = 0m;
        /// <summary>
        /// 
        /// </summary>
        private int _usermedal = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _playtimecount = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _dbquestid = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _inoutindex = 0;
        /// <summary>
        /// 
        /// </summary>
        private DateTime _inserttime = new DateTime(1900, 1, 1);
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("DrawID")]
        public int DrawID
        {
            set { _drawid = value; }
            get { return _drawid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("ChairID")]
        public int ChairID
        {
            set { _chairid = value; }
            get { return _chairid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("Score")]
        public decimal Score
        {
            set { _score = value; }
            get { return _score; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("Grade")]
        public long Grade
        {
            set { _grade = value; }
            get { return _grade; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("Revenue")]
        public decimal Revenue
        {
            set { _revenue = value; }
            get { return _revenue; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("UserMedal")]
        public int UserMedal
        {
            set { _usermedal = value; }
            get { return _usermedal; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("PlayTimeCount")]
        public int PlayTimeCount
        {
            set { _playtimecount = value; }
            get { return _playtimecount; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("DBQuestID")]
        public int DBQuestID
        {
            set { _dbquestid = value; }
            get { return _dbquestid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("InoutIndex")]
        public int InoutIndex
        {
            set { _inoutindex = value; }
            get { return _inoutindex; }
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
