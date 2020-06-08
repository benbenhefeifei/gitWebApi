/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述：提现卡号配置表 - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:52
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:52 == wuwenji == 创建 == 提现卡号配置表 - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// T_BankCard --- 提现卡号配置表 - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("T_BankCard")]
    public partial class BankCard // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _id;
        /// <summary>
        /// 真实姓名
        /// </summary>
        private string _realname = "";
        /// <summary>
        /// 银行名称
        /// </summary>
        private string _bankname = "";
        /// <summary>
        /// 银行卡号
        /// </summary>
        private string _bankno = "";
        /// <summary>
        /// 所在市
        /// </summary>
        private string _bankcity = "";
        /// <summary>
        /// 开户行
        /// </summary>
        private string _bankaddress = "";
        /// <summary>
        /// 状态 0 可用 1禁用
        /// </summary>
        private byte _nullity = 0;
        /// <summary>
        /// 银行代号
        /// </summary>
        private string _bankcode = "";
        /// <summary>
        /// 
        /// </summary>
        private string _province = "";
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
        /// 获取或设置 真实姓名
        /// </summary>
        [Column("RealName")]
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        
        /// <summary>
        /// 获取或设置 银行名称
        /// </summary>
        [Column("BankName")]
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        
        /// <summary>
        /// 获取或设置 银行卡号
        /// </summary>
        [Column("BankNo")]
        public string BankNo
        {
            set { _bankno = value; }
            get { return _bankno; }
        }
        
        /// <summary>
        /// 获取或设置 所在市
        /// </summary>
        [Column("BankCity")]
        public string BankCity
        {
            set { _bankcity = value; }
            get { return _bankcity; }
        }
        
        /// <summary>
        /// 获取或设置 开户行
        /// </summary>
        [Column("BankAddress")]
        public string BankAddress
        {
            set { _bankaddress = value; }
            get { return _bankaddress; }
        }
        
        /// <summary>
        /// 获取或设置 状态 0 可用 1禁用
        /// </summary>
        [Column("Nullity")]
        public byte Nullity
        {
            set { _nullity = value; }
            get { return _nullity; }
        }
        
        /// <summary>
        /// 获取或设置 银行代号
        /// </summary>
        [Column("BankCode")]
        public string BankCode
        {
            set { _bankcode = value; }
            get { return _bankcode; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("Province")]
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        #endregion
    }
}
