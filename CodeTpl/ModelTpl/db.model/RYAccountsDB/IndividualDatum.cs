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
    /// IndividualDatum ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("IndividualDatum")]
    public partial class IndividualDatum // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid;
        /// <summary>
        /// QQ 号码
        /// </summary>
        private string _qq = "";
        /// <summary>
        /// 电子邮件
        /// </summary>
        private string _email = "";
        /// <summary>
        /// 固定电话
        /// </summary>
        private string _seatphone = "";
        /// <summary>
        /// 手机号码
        /// </summary>
        private string _mobilephone = "";
        /// <summary>
        /// 详细住址
        /// </summary>
        private string _dwellingplace = "";
        /// <summary>
        /// 邮政编码
        /// </summary>
        private string _postalcode = "";
        /// <summary>
        /// 收集日期
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        /// <summary>
        /// 用户备注
        /// </summary>
        private string _usernote = "";
        /// <summary>
        /// 用户实名 - 银行户主名
        /// </summary>
        private string _compellation = "";
        /// <summary>
        /// 银行卡号
        /// </summary>
        private string _bankno = "";
        /// <summary>
        /// 银行名
        /// </summary>
        private string _bankname = "";
        /// <summary>
        /// 开户行地址
        /// </summary>
        private string _bankaddress = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 用户标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 QQ 号码
        /// </summary>
        [Column("QQ")]
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        
        /// <summary>
        /// 获取或设置 电子邮件
        /// </summary>
        [Column("EMail")]
        public string EMail
        {
            set { _email = value; }
            get { return _email; }
        }
        
        /// <summary>
        /// 获取或设置 固定电话
        /// </summary>
        [Column("SeatPhone")]
        public string SeatPhone
        {
            set { _seatphone = value; }
            get { return _seatphone; }
        }
        
        /// <summary>
        /// 获取或设置 手机号码
        /// </summary>
        [Column("MobilePhone")]
        public string MobilePhone
        {
            set { _mobilephone = value; }
            get { return _mobilephone; }
        }
        
        /// <summary>
        /// 获取或设置 详细住址
        /// </summary>
        [Column("DwellingPlace")]
        public string DwellingPlace
        {
            set { _dwellingplace = value; }
            get { return _dwellingplace; }
        }
        
        /// <summary>
        /// 获取或设置 邮政编码
        /// </summary>
        [Column("PostalCode")]
        public string PostalCode
        {
            set { _postalcode = value; }
            get { return _postalcode; }
        }
        
        /// <summary>
        /// 获取或设置 收集日期
        /// </summary>
        [Column("CollectDate")]
        public DateTime CollectDate
        {
            set { _collectdate = value; }
            get { return _collectdate; }
        }
        
        /// <summary>
        /// 获取或设置 用户备注
        /// </summary>
        [Column("UserNote")]
        public string UserNote
        {
            set { _usernote = value; }
            get { return _usernote; }
        }
        
        /// <summary>
        /// 获取或设置 用户实名 - 银行户主名
        /// </summary>
        [Column("Compellation")]
        public string Compellation
        {
            set { _compellation = value; }
            get { return _compellation; }
        }
        
        /// <summary>
        /// 获取或设置 银行卡号
        /// </summary>
        [Column("BankNO")]
        public string BankNO
        {
            set { _bankno = value; }
            get { return _bankno; }
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
        [Column("BankAddress")]
        public string BankAddress
        {
            set { _bankaddress = value; }
            get { return _bankaddress; }
        }
        #endregion
    }
}
