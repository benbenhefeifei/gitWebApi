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
    /// MemberProperty ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("MemberProperty")]
    public partial class MemberProperty // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _memberorder;
        /// <summary>
        /// 会员名称
        /// </summary>
        private string _membername = "";
        /// <summary>
        /// 会员权限
        /// </summary>
        private int _userright = 0;
        /// <summary>
        /// 任务奖励
        /// </summary>
        private int _taskrate = 0;
        /// <summary>
        /// 商城折扣
        /// </summary>
        private int _shoprate = 0;
        /// <summary>
        /// 银行优惠
        /// </summary>
        private int _insurerate = 0;
        /// <summary>
        /// 每日赠送
        /// </summary>
        private int _daypresent = 0;
        /// <summary>
        /// 每日登录礼包
        /// </summary>
        private int _daygiftid = 0;
        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _collectdate = DateTime.Now;
        /// <summary>
        /// 备注
        /// </summary>
        private string _collectnote = "";
        #endregion
        
        #region 数据库model
        
        /// <summary>
        /// 获取或设置 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("MemberOrder")]
        public int MemberOrder
        {
            set { _memberorder = value; }
            get { return _memberorder; }
        }
        
        /// <summary>
        /// 获取或设置 会员名称
        /// </summary>
        [Column("MemberName")]
        public string MemberName
        {
            set { _membername = value; }
            get { return _membername; }
        }
        
        /// <summary>
        /// 获取或设置 会员权限
        /// </summary>
        [Column("UserRight")]
        public int UserRight
        {
            set { _userright = value; }
            get { return _userright; }
        }
        
        /// <summary>
        /// 获取或设置 任务奖励
        /// </summary>
        [Column("TaskRate")]
        public int TaskRate
        {
            set { _taskrate = value; }
            get { return _taskrate; }
        }
        
        /// <summary>
        /// 获取或设置 商城折扣
        /// </summary>
        [Column("ShopRate")]
        public int ShopRate
        {
            set { _shoprate = value; }
            get { return _shoprate; }
        }
        
        /// <summary>
        /// 获取或设置 银行优惠
        /// </summary>
        [Column("InsureRate")]
        public int InsureRate
        {
            set { _insurerate = value; }
            get { return _insurerate; }
        }
        
        /// <summary>
        /// 获取或设置 每日赠送
        /// </summary>
        [Column("DayPresent")]
        public int DayPresent
        {
            set { _daypresent = value; }
            get { return _daypresent; }
        }
        
        /// <summary>
        /// 获取或设置 每日登录礼包
        /// </summary>
        [Column("DayGiftID")]
        public int DayGiftID
        {
            set { _daygiftid = value; }
            get { return _daygiftid; }
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
        /// 获取或设置 备注
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
