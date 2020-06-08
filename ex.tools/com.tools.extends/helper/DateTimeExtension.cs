/***********************************************
 * 版权声明：2017-2020 
 * 作    者：吴文吉
 * 功能描述：自定义日期格式处理 （扩展）
 * 创建时间：2017-07-27
 * 更新历史：（日期倒序）
 * *********************************************/

using System.Globalization;

namespace System
{
    /// <summary>
    /// 自定义日期格式处理 （扩展）
    /// </summary>
    public static class DateTimeExtension
    {
        ///<summary>
        /// 返回格式化的星期显示
        /// (如:星期日)
        ///</summary>
        public static string ToWeek(this DateTime date)
        {
            if (date == DateTime.Parse("0001-01-01 00:00:00")) { return string.Empty; }
            if (date == DateTime.Parse("1900-01-01 00:00:00")) { return string.Empty; }
            return "星期" + "日一二三四五六".Substring(Convert.ToInt32(date.DayOfWeek), 1);
        }
        ///<summary>
        /// 返回格式化的农历显示
        /// (如:戊子(鼠)年润四月廿三)
        ///</summary>
        public static string ToChinese(this DateTime date)
        {
            if (date == DateTime.Parse("0001-01-01 00:00:00")) { return string.Empty; }
            if (date == DateTime.Parse("1900-01-01 00:00:00")) { return string.Empty; }

            ChineseLunisolarCalendar cnCalendar = new ChineseLunisolarCalendar();
            int cny = cnCalendar.GetSexagenaryYear(date); //农历的年
            int cnm = cnCalendar.GetMonth(date);         //农历的月
            int cnd = cnCalendar.GetDayOfMonth(date); //农历的日
            int icnm = cnCalendar.GetLeapMonth(cnCalendar.GetYear(date)); //农历闰月

            string txcns = "";
            const string szText1 = "癸甲乙丙丁戊己庚辛壬";
            const string szText2 = "亥子丑寅卯辰巳午未申酉戌";
            const string szText3 = "猪鼠牛虎兔龙蛇马羊猴鸡狗";
            txcns += szText1.Substring(cny % 10, 1);
            txcns += szText2.Substring(cny % 12, 1);
            txcns += "(" + szText3.Substring(cny % 12, 1) + ")年";
            //格式化月份显示
            string[] cnMonth = { "", "正月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月", "十二月" };
            if (icnm > 0)
            {
                for (int i = icnm + 1; i < 13; i++) { cnMonth[icnm] = "闰" + cnMonth[icnm]; }
            }
            txcns += cnMonth[cnm];
            string[] cnDay ={ "", "初一", "初二", "初三", "初四", "初五", "初六", "初七"
                , "初八", "初九", "初十", "十一", "十二", "十三", "十四", "十五", "十六"
                , "十七", "十八", "十九", "二十", "廿一", "廿二", "廿三", "廿四", "廿五"
                , "廿六", "廿七", "廿八", "廿九", "三十" };
            txcns += cnDay[cnd];
            return txcns;
        }
        /// <summary>
        /// 获取当前时间的时间戳
        /// </summary>
        public static long Timestamp(this DateTime source, int len = 13)
        {
            if (len == 14) { return Convert.ToInt64(source.ToString("yyyyMMddHHmmss")); }
            TimeSpan time = (source - new DateTime(1970, 1, 1, 0, 0, 0, 0));
            if (len == 10) { return Convert.ToInt64(time.TotalSeconds); }
            return Convert.ToInt64(time.TotalMilliseconds);
        }
    }
}
