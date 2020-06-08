using System;
namespace com.xbao.db.core
{
    public class BasePage : BaseQuery
    {
        /// <summary>
        /// 获取或设置 分页当前页码
        /// </summary>
        public int Index { get; set; }
        /// <summary>
        /// 获取或设置 分页排序后要获取的数据行数,即每页行数
        /// </summary>
        public int Limit { get; set; }
    }
}
