/***********************************************
* 版权声明：2017-2020 
* 作    者：技术总监CTO => 吴文吉
* 功能描述： - 数据实体模型（可扩展）
* 创建时间：2020-06-08 13:44:52
* 更新历史：日期 - 姓名 - 功能（日期倒序）
* GOTO：2020-06-08 13:44:52 == wuwenji == 创建 ==  - 数据实体模型
* *********************************************/

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hh.model.RYAccountsDB
{
    /// <summary>
    /// UserBrowerInfoLock ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("UserBrowerInfoLock")]
    public partial class UserBrowerInfoLock // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _spreaderid;
        /// <summary>
        /// 
        /// </summary>
        private int _userid = 0;
        /// <summary>
        /// 
        /// </summary>
        private int _channelid = 0;
        /// <summary>
        /// 
        /// </summary>
        private string _clientip = "";
        /// <summary>
        /// 
        /// </summary>
        private string _clientmac = "";
        /// <summary>
        /// 
        /// </summary>
        private int _devicetype = 0;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("SpreaderID")]
        public int SpreaderID
        {
            set { _spreaderid = value; }
            get { return _spreaderid; }
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
        [Column("ChannelID")]
        public int ChannelID
        {
            set { _channelid = value; }
            get { return _channelid; }
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
        [Column("ClientMac")]
        public string ClientMac
        {
            set { _clientmac = value; }
            get { return _clientmac; }
        }
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [Column("DeviceType")]
        public int DeviceType
        {
            set { _devicetype = value; }
            get { return _devicetype; }
        }
        #endregion
    }
}
