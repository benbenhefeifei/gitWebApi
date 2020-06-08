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
    /// AccountsPackage ---  - 据实体模型（可扩展）
    /// </summary>
    [Serializable]
    [Table("AccountsPackage")]
    public partial class AccountsPackage // : IAggregateRoot
    {
        #region 私有变量
        /// <summary>
        /// 
        /// </summary>
        private int _userid;
        /// <summary>
        /// 物品标识
        /// </summary>
        private int _goodsid;
        /// <summary>
        /// 背包归类类型
        /// </summary>
        private int _goodshowid = 0;
        /// <summary>
        /// 背包内物品排序
        /// </summary>
        private int _goodssortid = 0;
        /// <summary>
        /// 物品数量
        /// </summary>
        private int _goodscount = 0;
        /// <summary>
        /// 增加时间
        /// </summary>
        private DateTime _pushtime = new DateTime(1900, 1, 1);
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
        /// 获取或设置 物品标识
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)][Key][Column("GoodsID")]
        public int GoodsID
        {
            set { _goodsid = value; }
            get { return _goodsid; }
        }
        
        /// <summary>
        /// 获取或设置 背包归类类型
        /// </summary>
        [Column("GoodShowID")]
        public int GoodShowID
        {
            set { _goodshowid = value; }
            get { return _goodshowid; }
        }
        
        /// <summary>
        /// 获取或设置 背包内物品排序
        /// </summary>
        [Column("GoodsSortID")]
        public int GoodsSortID
        {
            set { _goodssortid = value; }
            get { return _goodssortid; }
        }
        
        /// <summary>
        /// 获取或设置 物品数量
        /// </summary>
        [Column("GoodsCount")]
        public int GoodsCount
        {
            set { _goodscount = value; }
            get { return _goodscount; }
        }
        
        /// <summary>
        /// 获取或设置 增加时间
        /// </summary>
        [Column("PushTime")]
        public DateTime PushTime
        {
            set { _pushtime = value; }
            get { return _pushtime; }
        }
        #endregion
    }
}
