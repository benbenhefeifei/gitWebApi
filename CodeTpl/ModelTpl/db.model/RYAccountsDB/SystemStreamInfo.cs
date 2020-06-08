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
    /// SystemStreamInfo ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("SystemStreamInfo")]
    public partial class SystemStreamInfo // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 日期标识
        /// </summary>
        private int _dateid;
        /// <summary>
        /// 登录成功
        /// </summary>
        private int _weblogonsuccess = 0;
        /// <summary>
        /// 注册成功
        /// </summary>
        private int _webregistersuccess = 0;
        /// <summary>
        /// 登录成功
        /// </summary>
        private int _gamelogonsuccess = 0;
        /// <summary>
        /// 注册成功
        /// </summary>
        private int _gameregistersuccess = 0;
        /// <summary>
        /// 录入时间
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 日期标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("DateID")]
        public int DateID
        {
            set { _dateid = value; }
            get { return _dateid; }
        }
        
        /// <summary>
        /// 获取或设置 登录成功
        /// </summary>
        [Column("WebLogonSuccess")]
        public int WebLogonSuccess
        {
            set { _weblogonsuccess = value; }
            get { return _weblogonsuccess; }
        }
        
        /// <summary>
        /// 获取或设置 注册成功
        /// </summary>
        [Column("WebRegisterSuccess")]
        public int WebRegisterSuccess
        {
            set { _webregistersuccess = value; }
            get { return _webregistersuccess; }
        }
        
        /// <summary>
        /// 获取或设置 登录成功
        /// </summary>
        [Column("GameLogonSuccess")]
        public int GameLogonSuccess
        {
            set { _gamelogonsuccess = value; }
            get { return _gamelogonsuccess; }
        }
        
        /// <summary>
        /// 获取或设置 注册成功
        /// </summary>
        [Column("GameRegisterSuccess")]
        public int GameRegisterSuccess
        {
            set { _gameregistersuccess = value; }
            get { return _gameregistersuccess; }
        }
        
        /// <summary>
        /// 获取或设置 录入时间
        /// </summary>
        [Column("CollectDate")]
        public DateTime CollectDate
        {
            set { _collectdate = value; }
            get { return _collectdate; }
        }
        #endregion
    }
}
