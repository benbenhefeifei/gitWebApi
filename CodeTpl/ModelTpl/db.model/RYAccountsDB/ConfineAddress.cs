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
    /// ConfineAddress ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("ConfineAddress")]
    public partial class ConfineAddress // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 地址字符
        /// </summary>
        private string _addrstring;
        /// <summary>
        /// 限制登录
        /// </summary>
        private bool _enjoinlogon = false;
        /// <summary>
        /// 限制注册
        /// </summary>
        private bool _enjoinregister = false;
        /// <summary>
        /// 过期时间
        /// </summary>
        private DateTime? _enjoinoverdate = 0;
        /// <summary>
        /// 收集日期
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        /// <summary>
        /// 输入备注
        /// </summary>
        private string _collectnote = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 地址字符
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("AddrString")]
        public string AddrString
        {
            set { _addrstring = value; }
            get { return _addrstring; }
        }
        
        /// <summary>
        /// 获取或设置 限制登录
        /// </summary>
        [Column("EnjoinLogon")]
        public bool EnjoinLogon
        {
            set { _enjoinlogon = value; }
            get { return _enjoinlogon; }
        }
        
        /// <summary>
        /// 获取或设置 限制注册
        /// </summary>
        [Column("EnjoinRegister")]
        public bool EnjoinRegister
        {
            set { _enjoinregister = value; }
            get { return _enjoinregister; }
        }
        
        /// <summary>
        /// 获取或设置 过期时间
        /// </summary>
        [Column("EnjoinOverDate")]
        public DateTime? EnjoinOverDate
        {
            set { _enjoinoverdate = value; }
            get { return _enjoinoverdate; }
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
        /// 获取或设置 输入备注
        /// </summary>
        [Column("CollectNote")]
        public string CollectNote
        {
            set { _collectnote = value; }
            get { return _collectnote; }
        }
        #endregion
    }
}
