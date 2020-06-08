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
    /// GameIdentifier ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("GameIdentifier")]
    public partial class GameIdentifier // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid;
        /// <summary>
        /// 游戏标识
        /// </summary>
        private int _gameid = 0;
        /// <summary>
        /// 标识等级
        /// </summary>
        private int _idlevel = 0;
        /// <summary>
        /// 
        /// </summary>
        private int? _rn = 0;
        /// <summary>
        /// 
        /// </summary>
        private int? _isandroid = 0;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 用户标识
        /// </summary>
        [Key][Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 游戏标识
        /// </summary>
        [Column("GameID")]
        public int GameID
        {
            set { _gameid = value; }
            get { return _gameid; }
        }
        
        /// <summary>
        /// 获取或设置 标识等级
        /// </summary>
        [Column("IDLevel")]
        public int IDLevel
        {
            set { _idlevel = value; }
            get { return _idlevel; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("rn")]
        public int? Rn
        {
            set { _rn = value; }
            get { return _rn; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("isandroid")]
        public int? Isandroid
        {
            set { _isandroid = value; }
            get { return _isandroid; }
        }
        #endregion
    }
}
