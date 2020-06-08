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
    /// RecordMedalChange ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("RecordMedalChange")]
    public partial class RecordMedalChange // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _recordid;
        /// <summary>
        /// 
        /// </summary>
        private int _userid = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _srcmedal = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _trademedal = 0;
        /// <summary>
        /// 1.获取元宝,2:大厅消耗元宝,3:网站元宝,4:退还元宝
        /// </summary>
        private int _typeid = 0;
        /// <summary>
        /// 
        /// </summary>
        private string _clientip = "";
        /// <summary>
        /// 
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        /// <summary>
        /// 
        /// </summary>
        private string _collectnote = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Key][Column("RecordID")]
        public int RecordID
        {
            set { _recordid = value; }
            get { return _recordid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("UserID")]
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("SrcMedal")]
        public int SrcMedal
        {
            set { _srcmedal = value; }
            get { return _srcmedal; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("TradeMedal")]
        public int TradeMedal
        {
            set { _trademedal = value; }
            get { return _trademedal; }
        }
        
        /// <summary>
        /// 获取或设置 1.获取元宝,2:大厅消耗元宝,3:网站元宝,4:退还元宝
        /// </summary>
        [Column("TypeID")]
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("ClientIP")]
        public string ClientIP
        {
            set { _clientip = value; }
            get { return _clientip; }
        }
        
        /// <summary>
        /// 获取或设置 
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
        [Column("CollectNote")]
        public string CollectNote
        {
            set { _collectnote = value; }
            get { return _collectnote; }
        }
        #endregion
    }
}
