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
    /// PersonalRoomScoreInfo ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("PersonalRoomScoreInfo")]
    public partial class PersonalRoomScoreInfo // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 用户 ID
        /// </summary>
        private int _userid;
        /// <summary>
        /// 房间 ID
        /// </summary>
        private string _roomid = "";
        /// <summary>
        /// 用户积分（货币）
        /// </summary>
        private decimal _score = 0M;
        /// <summary>
        /// 胜局数目
        /// </summary>
        private int _wincount = 0;
        /// <summary>
        /// 输局数目
        /// </summary>
        private int _lostcount = 0;
        /// <summary>
        /// 和局数目
        /// </summary>
        private int _drawcount = 0;
        /// <summary>
        /// 逃局数目
        /// </summary>
        private int _fleecount = 0;
        /// <summary>
        /// 
        /// </summary>
        private DateTime _writetime = new DateTime(1900, 1, 1);
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 用户 ID
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 房间 ID
        /// </summary>
        [Column("RoomID")]
        public string RoomID
        {
            set { _roomid = value; }
            get { return _roomid; }
        }
        
        /// <summary>
        /// 获取或设置 用户积分（货币）
        /// </summary>
        [Column("Score")]
        public decimal Score
        {
            set { _score = value; }
            get { return _score; }
        }
        
        /// <summary>
        /// 获取或设置 胜局数目
        /// </summary>
        [Column("WinCount")]
        public int WinCount
        {
            set { _wincount = value; }
            get { return _wincount; }
        }
        
        /// <summary>
        /// 获取或设置 输局数目
        /// </summary>
        [Column("LostCount")]
        public int LostCount
        {
            set { _lostcount = value; }
            get { return _lostcount; }
        }
        
        /// <summary>
        /// 获取或设置 和局数目
        /// </summary>
        [Column("DrawCount")]
        public int DrawCount
        {
            set { _drawcount = value; }
            get { return _drawcount; }
        }
        
        /// <summary>
        /// 获取或设置 逃局数目
        /// </summary>
        [Column("FleeCount")]
        public int FleeCount
        {
            set { _fleecount = value; }
            get { return _fleecount; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("WriteTime")]
        public DateTime WriteTime
        {
            set { _writetime = value; }
            get { return _writetime; }
        }
        #endregion
    }
}
