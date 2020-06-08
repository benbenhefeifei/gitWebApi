/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述：玩家提款全局配置表New - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:52
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:52 == wuwenji == 创建 == 玩家提款全局配置表New - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// T_Acc_DealSet --- 玩家提款全局配置表New - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("T_Acc_DealSet")]
    public partial class AccDealSet // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private byte _id;
        /// <summary>
        /// 全局禁止玩家提款0
        /// </summary>
        private bool _isopen = true;
        /// <summary>
        /// 锁定金币可兑换1
        /// </summary>
        private bool _issale = false;
        /// <summary>
        /// 游戏满多少局可提款
        /// </summary>
        private int _gamecnt = 0;
        /// <summary>
        /// 每周工作日 &
        /// </summary>
        private int _weekopenday = 0;
        /// <summary>
        /// 每日工作时间点 起
        /// </summary>
        private byte _shour = 0;
        /// <summary>
        /// 每日工作时间点 止
        /// </summary>
        private byte _ehour = 0;
        /// <summary>
        /// 每日提款次数限制
        /// </summary>
        private int _dailyapplytimes = 0;
        /// <summary>
        /// 出售比例?金币=RMB
        /// </summary>
        private float _balanceprice = 1f;
        /// <summary>
        /// 最低出售数额
        /// </summary>
        private float _minbalance = 0f;
        /// <summary>
        /// 手续费率 0不收
        /// </summary>
        private float _counterfee = 0f;
        /// <summary>
        /// 最低手续费
        /// </summary>
        private float _mincounterfee = 0f;
        /// <summary>
        /// 玩家可兑换的最低携款额
        /// </summary>
        private decimal _minplayerscore = 0M;
        /// <summary>
        /// 提现金额倍数要求
        /// </summary>
        private short _drawmultiple = 1;
        /// <summary>
        /// 手机赠送是否锁定 1锁定
        /// </summary>
        private bool _ismobilesale = false;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Key][Column("ID")]
        public byte ID
        {
            set { _id = value; }
            get { return _id; }
        }
        
        /// <summary>
        /// 获取或设置 全局禁止玩家提款0
        /// </summary>
        [Column("IsOpen")]
        public bool IsOpen
        {
            set { _isopen = value; }
            get { return _isopen; }
        }
        
        /// <summary>
        /// 获取或设置 锁定金币可兑换1
        /// </summary>
        [Column("IsSale")]
        public bool IsSale
        {
            set { _issale = value; }
            get { return _issale; }
        }
        
        /// <summary>
        /// 获取或设置 游戏满多少局可提款
        /// </summary>
        [Column("GameCnt")]
        public int GameCnt
        {
            set { _gamecnt = value; }
            get { return _gamecnt; }
        }
        
        /// <summary>
        /// 获取或设置 每周工作日 &
        /// </summary>
        [Column("WeekOpenDay")]
        public int WeekOpenDay
        {
            set { _weekopenday = value; }
            get { return _weekopenday; }
        }
        
        /// <summary>
        /// 获取或设置 每日工作时间点 起
        /// </summary>
        [Column("Shour")]
        public byte Shour
        {
            set { _shour = value; }
            get { return _shour; }
        }
        
        /// <summary>
        /// 获取或设置 每日工作时间点 止
        /// </summary>
        [Column("Ehour")]
        public byte Ehour
        {
            set { _ehour = value; }
            get { return _ehour; }
        }
        
        /// <summary>
        /// 获取或设置 每日提款次数限制
        /// </summary>
        [Column("DailyApplyTimes")]
        public int DailyApplyTimes
        {
            set { _dailyapplytimes = value; }
            get { return _dailyapplytimes; }
        }
        
        /// <summary>
        /// 获取或设置 出售比例?金币=RMB
        /// </summary>
        [Column("BalancePrice")]
        public float BalancePrice
        {
            set { _balanceprice = value; }
            get { return _balanceprice; }
        }
        
        /// <summary>
        /// 获取或设置 最低出售数额
        /// </summary>
        [Column("MinBalance")]
        public float MinBalance
        {
            set { _minbalance = value; }
            get { return _minbalance; }
        }
        
        /// <summary>
        /// 获取或设置 手续费率 0不收
        /// </summary>
        [Column("CounterFee")]
        public float CounterFee
        {
            set { _counterfee = value; }
            get { return _counterfee; }
        }
        
        /// <summary>
        /// 获取或设置 最低手续费
        /// </summary>
        [Column("MinCounterFee")]
        public float MinCounterFee
        {
            set { _mincounterfee = value; }
            get { return _mincounterfee; }
        }
        
        /// <summary>
        /// 获取或设置 玩家可兑换的最低携款额
        /// </summary>
        [Column("MinPlayerScore")]
        public decimal MinPlayerScore
        {
            set { _minplayerscore = value; }
            get { return _minplayerscore; }
        }
        
        /// <summary>
        /// 获取或设置 提现金额倍数要求
        /// </summary>
        [Column("DrawMultiple")]
        public short DrawMultiple
        {
            set { _drawmultiple = value; }
            get { return _drawmultiple; }
        }
        
        /// <summary>
        /// 获取或设置 手机赠送是否锁定 1锁定
        /// </summary>
        [Column("IsMobileSale")]
        public bool IsMobileSale
        {
            set { _ismobilesale = value; }
            get { return _ismobilesale; }
        }
        #endregion
    }
}
