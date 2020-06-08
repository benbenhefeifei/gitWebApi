/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述：网站用户（会员）信息 - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:48
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:48 == wuwenji == 创建 == 网站用户（会员）信息 - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AccountsBankBind --- 网站用户（会员）信息 - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsBankBind")]
    public partial class AccountsBankBind // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _userid;
        /// <summary>
        /// 是否锁定收款账号信息：0-不锁定，1-锁定
        /// </summary>
        private int _islockbank = 0;
        /// <summary>
        /// 开户名
        /// </summary>
        private string _truename = "";
        /// <summary>
        /// 开户行
        /// </summary>
        private string _bankname = "";
        /// <summary>
        /// 银行账号
        /// </summary>
        private string _bankaccount = "";
        /// <summary>
        /// 银行地址
        /// </summary>
        private string _bankaddress = "";
        /// <summary>
        /// 支付宝姓名
        /// </summary>
        private string _alipayname = "";
        /// <summary>
        /// 支付宝账号
        /// </summary>
        private string _alipayaccount = "";
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
        /// 获取或设置 是否锁定收款账号信息：0-不锁定，1-锁定
        /// </summary>
        [Column("IsLockBank")]
        public int IsLockBank
        {
            set { _islockbank = value; }
            get { return _islockbank; }
        }
        
        /// <summary>
        /// 获取或设置 开户名
        /// </summary>
        [Column("TrueName")]
        public string TrueName
        {
            set { _truename = value; }
            get { return _truename; }
        }
        
        /// <summary>
        /// 获取或设置 开户行
        /// </summary>
        [Column("BankName")]
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        
        /// <summary>
        /// 获取或设置 银行账号
        /// </summary>
        [Column("BankAccount")]
        public string BankAccount
        {
            set { _bankaccount = value; }
            get { return _bankaccount; }
        }
        
        /// <summary>
        /// 获取或设置 银行地址
        /// </summary>
        [Column("BankAddress")]
        public string BankAddress
        {
            set { _bankaddress = value; }
            get { return _bankaddress; }
        }
        
        /// <summary>
        /// 获取或设置 支付宝姓名
        /// </summary>
        [Column("AlipayName")]
        public string AlipayName
        {
            set { _alipayname = value; }
            get { return _alipayname; }
        }
        
        /// <summary>
        /// 获取或设置 支付宝账号
        /// </summary>
        [Column("AlipayAccount")]
        public string AlipayAccount
        {
            set { _alipayaccount = value; }
            get { return _alipayaccount; }
        }
        #endregion
    }
}
