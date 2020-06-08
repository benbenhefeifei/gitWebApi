/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:48
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:48 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AccountsAgent ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsAgent")]
    public partial class AccountsAgent // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 代理标识
        /// </summary>
        private int _agentid;
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid = 0;
        /// <summary>
        /// 代理姓名
        /// </summary>
        private string _compellation = "";
        /// <summary>
        /// 代理域名
        /// </summary>
        private string _domain = "";
        /// <summary>
        /// 分成类型(1:充值分成，2:税收分成)
        /// </summary>
        private int _agenttype = 0;
        /// <summary>
        /// 分成比例
        /// </summary>
        private decimal _agentscale = 0m;
        /// <summary>
        /// 日累计充值返现
        /// </summary>
        private long _paybackscore = 0;
        /// <summary>
        /// 返现比例
        /// </summary>
        private decimal _paybackscale = 0m;
        /// <summary>
        /// 电话
        /// </summary>
        private string _mobilephone = "";
        /// <summary>
        /// 邮箱
        /// </summary>
        private string _email = "";
        /// <summary>
        /// 详细地址
        /// </summary>
        private string _dwellingplace = "";
        /// <summary>
        /// 禁用标识
        /// </summary>
        private byte _nullity = 0;
        /// <summary>
        /// 备注
        /// </summary>
        private string _agentnote = "";
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        private string _wechat = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 代理标识
        /// </summary>
        [Key][Column("AgentID")]
        public int AgentID
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        
        /// <summary>
        /// 获取或设置 用户标识
        /// </summary>
        [Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 代理姓名
        /// </summary>
        [Column("Compellation")]
        public string Compellation
        {
            set { _compellation = value; }
            get { return _compellation; }
        }
        
        /// <summary>
        /// 获取或设置 代理域名
        /// </summary>
        [Column("Domain")]
        public string Domain
        {
            set { _domain = value; }
            get { return _domain; }
        }
        
        /// <summary>
        /// 获取或设置 分成类型(1:充值分成，2:税收分成)
        /// </summary>
        [Column("AgentType")]
        public int AgentType
        {
            set { _agenttype = value; }
            get { return _agenttype; }
        }
        
        /// <summary>
        /// 获取或设置 分成比例
        /// </summary>
        [Column("AgentScale")]
        public decimal AgentScale
        {
            set { _agentscale = value; }
            get { return _agentscale; }
        }
        
        /// <summary>
        /// 获取或设置 日累计充值返现
        /// </summary>
        [Column("PayBackScore")]
        public long PayBackScore
        {
            set { _paybackscore = value; }
            get { return _paybackscore; }
        }
        
        /// <summary>
        /// 获取或设置 返现比例
        /// </summary>
        [Column("PayBackScale")]
        public decimal PayBackScale
        {
            set { _paybackscale = value; }
            get { return _paybackscale; }
        }
        
        /// <summary>
        /// 获取或设置 电话
        /// </summary>
        [Column("MobilePhone")]
        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }
        
        /// <summary>
        /// 获取或设置 邮箱
        /// </summary>
        [Column("EMail")]
        public string EMail
        {
            set { _email = value; }
            get { return _email; }
        }
        
        /// <summary>
        /// 获取或设置 详细地址
        /// </summary>
        [Column("DwellingPlace")]
        public string DwellingPlace
        {
            set { _dwellingplace = value; }
            get { return _dwellingplace; }
        }
        
        /// <summary>
        /// 获取或设置 禁用标识
        /// </summary>
        [Column("Nullity")]
        public byte Nullity
        {
            set { _nullity = value; }
            get { return _nullity; }
        }
        
        /// <summary>
        /// 获取或设置 备注
        /// </summary>
        [Column("AgentNote")]
        public string AgentNote
        {
            set { _agentnote = value; }
            get { return _agentnote; }
        }
        
        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [Column("CollectDate")]
        public DateTime CollectDate
        {
            set { _collectdate = value; }
            get { return _collectdate; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("WeChat")]
        public string WeChat
        {
            set { _wechat = value; }
            get { return _wechat; }
        }
        #endregion
    }
}
