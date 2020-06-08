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
    /// ReserveIdentifier ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("ReserveIdentifier")]
    public partial class ReserveIdentifier // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 游戏标识
        /// </summary>
        private int _gameid;
        /// <summary>
        /// 标识等级
        /// </summary>
        private int _idlevel = 0;
        /// <summary>
        /// 分配标志
        /// </summary>
        private bool _distribute = false;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 游戏标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("GameID")]
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
        /// 获取或设置 分配标志
        /// </summary>
        [Column("Distribute")]
        public bool Distribute
        {
            set { _distribute = value; }
            get { return _distribute; }
        }
        #endregion
    }
}
