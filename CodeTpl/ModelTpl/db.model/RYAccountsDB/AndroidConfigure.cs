/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:50
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:50 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AndroidConfigure ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AndroidConfigure")]
    public partial class AndroidConfigure // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 批次标识
        /// </summary>
        private int _batchid;
        /// <summary>
        /// 房间标识
        /// </summary>
        private int _serverid = 0;
        /// <summary>
        /// 服务模式
        /// </summary>
        private int _servicemode = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _androidcount = 0;
        /// <summary>
        /// 进入时间
        /// </summary>
        private int _entertime = 0;
        /// <summary>
        /// 离开时间
        /// </summary>
        private int _leavetime = 0;
        /// <summary>
        /// 进入最小间隔
        /// </summary>
        private int _entermininterval = 0;
        /// <summary>
        /// 进入最大间隔
        /// </summary>
        private int _entermaxinterval = 0;
        /// <summary>
        /// 离开最小间隔
        /// </summary>
        private int _leavemininterval = 0;
        /// <summary>
        /// 离开最大间隔
        /// </summary>
        private int _leavemaxinterval = 0;
        /// <summary>
        /// 最少携带分数
        /// </summary>
        private long _takeminscore = 0;
        /// <summary>
        /// 最大携带分数
        /// </summary>
        private long _takemaxscore = 0;
        /// <summary>
        /// 最少换桌局数
        /// </summary>
        private int _switchmininnings = 0;
        /// <summary>
        /// 最大换桌局数
        /// </summary>
        private int _switchmaxinnings = 0;
        /// <summary>
        /// 普通会员
        /// </summary>
        private int? _androidcountmember0 = 0;
        /// <summary>
        /// 一级会员
        /// </summary>
        private int? _androidcountmember1 = 0;
        /// <summary>
        /// 二级会员
        /// </summary>
        private int? _androidcountmember2 = 0;
        /// <summary>
        /// 三级会员
        /// </summary>
        private int? _androidcountmember3 = 0;
        /// <summary>
        /// 四级会员
        /// </summary>
        private int? _androidcountmember4 = 0;
        /// <summary>
        /// 五级会员
        /// </summary>
        private int? _androidcountmember5 = 0;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 批次标识
        /// </summary>
        [Key][Column("BatchID")]
        public int BatchID
        {
            set { _batchid = value; }
            get { return _batchid; }
        }
        
        /// <summary>
        /// 获取或设置 房间标识
        /// </summary>
        [Column("ServerID")]
        public int ServerID
        {
            set { _serverid = value; }
            get { return _serverid; }
        }
        
        /// <summary>
        /// 获取或设置 服务模式
        /// </summary>
        [Column("ServiceMode")]
        public int ServiceMode
        {
            set { _servicemode = value; }
            get { return _servicemode; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("AndroidCount")]
        public int AndroidCount
        {
            set { _androidcount = value; }
            get { return _androidcount; }
        }
        
        /// <summary>
        /// 获取或设置 进入时间
        /// </summary>
        [Column("EnterTime")]
        public int EnterTime
        {
            set { _entertime = value; }
            get { return _entertime; }
        }
        
        /// <summary>
        /// 获取或设置 离开时间
        /// </summary>
        [Column("LeaveTime")]
        public int LeaveTime
        {
            set { _leavetime = value; }
            get { return _leavetime; }
        }
        
        /// <summary>
        /// 获取或设置 进入最小间隔
        /// </summary>
        [Column("EnterMinInterval")]
        public int EnterMinInterval
        {
            set { _entermininterval = value; }
            get { return _entermininterval; }
        }
        
        /// <summary>
        /// 获取或设置 进入最大间隔
        /// </summary>
        [Column("EnterMaxInterval")]
        public int EnterMaxInterval
        {
            set { _entermaxinterval = value; }
            get { return _entermaxinterval; }
        }
        
        /// <summary>
        /// 获取或设置 离开最小间隔
        /// </summary>
        [Column("LeaveMinInterval")]
        public int LeaveMinInterval
        {
            set { _leavemininterval = value; }
            get { return _leavemininterval; }
        }
        
        /// <summary>
        /// 获取或设置 离开最大间隔
        /// </summary>
        [Column("LeaveMaxInterval")]
        public int LeaveMaxInterval
        {
            set { _leavemaxinterval = value; }
            get { return _leavemaxinterval; }
        }
        
        /// <summary>
        /// 获取或设置 最少携带分数
        /// </summary>
        [Column("TakeMinScore")]
        public long TakeMinScore
        {
            set { _takeminscore = value; }
            get { return _takeminscore; }
        }
        
        /// <summary>
        /// 获取或设置 最大携带分数
        /// </summary>
        [Column("TakeMaxScore")]
        public long TakeMaxScore
        {
            set { _takemaxscore = value; }
            get { return _takemaxscore; }
        }
        
        /// <summary>
        /// 获取或设置 最少换桌局数
        /// </summary>
        [Column("SwitchMinInnings")]
        public int SwitchMinInnings
        {
            set { _switchmininnings = value; }
            get { return _switchmininnings; }
        }
        
        /// <summary>
        /// 获取或设置 最大换桌局数
        /// </summary>
        [Column("SwitchMaxInnings")]
        public int SwitchMaxInnings
        {
            set { _switchmaxinnings = value; }
            get { return _switchmaxinnings; }
        }
        
        /// <summary>
        /// 获取或设置 普通会员
        /// </summary>
        [Column("AndroidCountMember0")]
        public int? AndroidCountMember0
        {
            set { _androidcountmember0 = value; }
            get { return _androidcountmember0; }
        }
        
        /// <summary>
        /// 获取或设置 一级会员
        /// </summary>
        [Column("AndroidCountMember1")]
        public int? AndroidCountMember1
        {
            set { _androidcountmember1 = value; }
            get { return _androidcountmember1; }
        }
        
        /// <summary>
        /// 获取或设置 二级会员
        /// </summary>
        [Column("AndroidCountMember2")]
        public int? AndroidCountMember2
        {
            set { _androidcountmember2 = value; }
            get { return _androidcountmember2; }
        }
        
        /// <summary>
        /// 获取或设置 三级会员
        /// </summary>
        [Column("AndroidCountMember3")]
        public int? AndroidCountMember3
        {
            set { _androidcountmember3 = value; }
            get { return _androidcountmember3; }
        }
        
        /// <summary>
        /// 获取或设置 四级会员
        /// </summary>
        [Column("AndroidCountMember4")]
        public int? AndroidCountMember4
        {
            set { _androidcountmember4 = value; }
            get { return _androidcountmember4; }
        }
        
        /// <summary>
        /// 获取或设置 五级会员
        /// </summary>
        [Column("AndroidCountMember5")]
        public int? AndroidCountMember5
        {
            set { _androidcountmember5 = value; }
            get { return _androidcountmember5; }
        }
        #endregion
    }
}
