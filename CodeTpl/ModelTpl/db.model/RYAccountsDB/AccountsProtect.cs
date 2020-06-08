/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:49
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:49 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// AccountsProtect ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsProtect")]
    public partial class AccountsProtect // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 密保标识
        /// </summary>
        private int _protectid;
        /// <summary>
        /// 用户标识
        /// </summary>
        private int _userid = 0;
        /// <summary>
        /// 问题一
        /// </summary>
        private string _question1 = "";
        /// <summary>
        /// 答案一
        /// </summary>
        private string _response1 = "";
        /// <summary>
        /// 问题二
        /// </summary>
        private string _question2 = "";
        /// <summary>
        /// 答案二
        /// </summary>
        private string _response2 = "";
        /// <summary>
        /// 问题三
        /// </summary>
        private string _question3 = "";
        /// <summary>
        /// 答案三
        /// </summary>
        private string _response3 = "";
        /// <summary>
        /// 证件号码
        /// </summary>
        private string _passportid = "";
        /// <summary>
        /// 证件类型
        /// </summary>
        private byte _passporttype = 0;
        /// <summary>
        /// 安全邮箱
        /// </summary>
        private string _safeemail = "";
        /// <summary>
        /// 创建地址
        /// </summary>
        private string _createip = "";
        /// <summary>
        /// 修改地址
        /// </summary>
        private string _modifyip = "";
        /// <summary>
        /// 创建日期
        /// </summary>
        private DateTime _createdate = DateTime.Now;
        /// <summary>
        /// 修改日期
        /// </summary>
        private DateTime _modifydate = DateTime.Now;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 密保标识
        /// </summary>
        [Key][Column("ProtectID")]
        public int ProtectID
        {
            set { _protectid = value; }
            get { return _protectid; }
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
        /// 获取或设置 问题一
        /// </summary>
        [Column("Question1")]
        public string Question1
        {
            set { _question1 = value; }
            get { return _question1; }
        }
        
        /// <summary>
        /// 获取或设置 答案一
        /// </summary>
        [Column("Response1")]
        public string Response1
        {
            set { _response1 = value; }
            get { return _response1; }
        }
        
        /// <summary>
        /// 获取或设置 问题二
        /// </summary>
        [Column("Question2")]
        public string Question2
        {
            set { _question2 = value; }
            get { return _question2; }
        }
        
        /// <summary>
        /// 获取或设置 答案二
        /// </summary>
        [Column("Response2")]
        public string Response2
        {
            set { _response2 = value; }
            get { return _response2; }
        }
        
        /// <summary>
        /// 获取或设置 问题三
        /// </summary>
        [Column("Question3")]
        public string Question3
        {
            set { _question3 = value; }
            get { return _question3; }
        }
        
        /// <summary>
        /// 获取或设置 答案三
        /// </summary>
        [Column("Response3")]
        public string Response3
        {
            set { _response3 = value; }
            get { return _response3; }
        }
        
        /// <summary>
        /// 获取或设置 证件号码
        /// </summary>
        [Column("PassportID")]
        public string PassportID
        {
            set { _passportid = value; }
            get { return _passportid; }
        }
        
        /// <summary>
        /// 获取或设置 证件类型
        /// </summary>
        [Column("PassportType")]
        public byte PassportType
        {
            set { _passporttype = value; }
            get { return _passporttype; }
        }
        
        /// <summary>
        /// 获取或设置 安全邮箱
        /// </summary>
        [Column("SafeEmail")]
        public string SafeEmail
        {
            set { _safeemail = value; }
            get { return _safeemail; }
        }
        
        /// <summary>
        /// 获取或设置 创建地址
        /// </summary>
        [Column("CreateIP")]
        public string CreateIP
        {
            set { _createip = value; }
            get { return _createip; }
        }
        
        /// <summary>
        /// 获取或设置 修改地址
        /// </summary>
        [Column("ModifyIP")]
        public string ModifyIP
        {
            set { _modifyip = value; }
            get { return _modifyip; }
        }
        
        /// <summary>
        /// 获取或设置 创建日期
        /// </summary>
        [Column("CreateDate")]
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        
        /// <summary>
        /// 获取或设置 修改日期
        /// </summary>
        [Column("ModifyDate")]
        public DateTime ModifyDate
        {
            set { _modifydate = value; }
            get { return _modifydate; }
        }
        #endregion
    }
}
