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
    /// ApplyOrder ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("ApplyOrder")]
    public partial class ApplyOrder // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _id;
        /// <summary>
        /// 
        /// </summary>
        private string _orderid = "";
        /// <summary>
        /// 提现玩家UserID
        /// </summary>
        private int _applicantid = 0;
        /// <summary>
        /// 提现扣除的Score数
        /// </summary>
        private decimal _sellscore = 0m;
        /// <summary>
        /// 提现所得RMB数
        /// </summary>
        private decimal _sellmoney = 0M;
        /// <summary>
        /// 提现所扣手续费
        /// </summary>
        private decimal _revenue = 0m;
        /// <summary>
        /// 玩家申请提现时间
        /// </summary>
        private DateTime _applydate = DateTime.Now;
        /// <summary>
        /// 银行名
        /// </summary>
        private string _bankname = "";
        /// <summary>
        /// 开户行地址
        /// </summary>
        private string _bankdetail = "";
        /// <summary>
        /// 银行卡号
        /// </summary>
        private string _banknum = "";
        /// <summary>
        /// 开户人姓名
        /// </summary>
        private string _realname = "";
        /// <summary>
        /// 管理员处理提现申请时间
        /// </summary>
        private DateTime? _operatedate = 0;
        /// <summary>
        /// 订单状态 1申请提现 2管理员同意提现 3管理员拒绝提现 4等待付款状态
        /// </summary>
        private byte _status = 1;
        /// <summary>
        /// 
        /// </summary>
        private string _rejectreason = "";
        /// <summary>
        /// 提现方式 0银行卡,1支付宝
        /// </summary>
        private byte _btype = 0;
        /// <summary>
        /// 
        /// </summary>
        private string _operator = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Key][Column("ID")]
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("OrderID")]
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        
        /// <summary>
        /// 获取或设置 提现玩家UserID
        /// </summary>
        [Column("ApplicantID")]
        public int ApplicantID
        {
            set { _applicantid = value; }
            get { return _applicantid; }
        }
        
        /// <summary>
        /// 获取或设置 提现扣除的Score数
        /// </summary>
        [Column("SellScore")]
        public decimal SellScore
        {
            set { _sellscore = value; }
            get { return _sellscore; }
        }
        
        /// <summary>
        /// 获取或设置 提现所得RMB数
        /// </summary>
        [Column("SellMoney")]
        public decimal SellMoney
        {
            set { _sellmoney = value; }
            get { return _sellmoney; }
        }
        
        /// <summary>
        /// 获取或设置 提现所扣手续费
        /// </summary>
        [Column("Revenue")]
        public decimal Revenue
        {
            set { _revenue = value; }
            get { return _revenue; }
        }
        
        /// <summary>
        /// 获取或设置 玩家申请提现时间
        /// </summary>
        [Column("ApplyDate")]
        public DateTime ApplyDate
        {
            set { _applydate = value; }
            get { return _applydate; }
        }
        
        /// <summary>
        /// 获取或设置 银行名
        /// </summary>
        [Column("BankName")]
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        
        /// <summary>
        /// 获取或设置 开户行地址
        /// </summary>
        [Column("BankDetail")]
        public string BankDetail
        {
            set { _bankdetail = value; }
            get { return _bankdetail; }
        }
        
        /// <summary>
        /// 获取或设置 银行卡号
        /// </summary>
        [Column("BankNum")]
        public string BankNum
        {
            set { _banknum = value; }
            get { return _banknum; }
        }
        
        /// <summary>
        /// 获取或设置 开户人姓名
        /// </summary>
        [Column("RealName")]
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        
        /// <summary>
        /// 获取或设置 管理员处理提现申请时间
        /// </summary>
        [Column("OperateDate")]
        public DateTime? OperateDate
        {
            set { _operatedate = value; }
            get { return _operatedate; }
        }
        
        /// <summary>
        /// 获取或设置 订单状态 1申请提现 2管理员同意提现 3管理员拒绝提现 4等待付款状态
        /// </summary>
        [Column("Status")]
        public byte Status
        {
            set { _status = value; }
            get { return _status; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("RejectReason")]
        public string RejectReason
        {
            set { _rejectreason = value; }
            get { return _rejectreason; }
        }
        
        /// <summary>
        /// 获取或设置 提现方式 0银行卡,1支付宝
        /// </summary>
        [Column("bType")]
        public byte BType
        {
            set { _btype = value; }
            get { return _btype; }
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
        #endregion
    }
}
