/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述：超权玩家跟踪表 - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:52
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:52 == wuwenji == 创建 == 超权玩家跟踪表 - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// T_SuperUser --- 超权玩家跟踪表 - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("T_SuperUser")]
    public partial class SuperUser // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _userid;
        /// <summary>
        /// 超权玩家跟踪的玩家的GameID
        /// </summary>
        private int _followgameid = 0;
        /// <summary>
        /// 
        /// </summary>
        private string _operator = "";
        /// <summary>
        /// 
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
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
        /// 获取或设置 超权玩家跟踪的玩家的GameID
        /// </summary>
        [Column("FollowGameID")]
        public int FollowGameID
        {
            set { _followgameid = value; }
            get { return _followgameid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("Operator")]
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        
        /// <summary>
        /// 获取或设置 
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
