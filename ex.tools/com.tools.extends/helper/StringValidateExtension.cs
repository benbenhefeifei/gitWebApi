/***********************************************
 * 版权声明：2017-2020 
 * 作    者：吴文吉
 * 功能描述：自定义字符串验证操作处理 （扩展）
 * 创建时间：2017-07-27
 * 更新历史：（日期倒序）
 * *********************************************/

using System.Linq;
using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    /// 正则表达式 验证扩展
    /// </summary>
    public static class StringValidateExtension
    {
        #region 与字符串相关校验
        /// <summary>
        /// 校验是否是英文和数字组合，
        /// 只能是英文和数字,并且以英文开头
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsRegUserName(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = new Regex("^[a-zA-Z][a-zA-Z0-9_]*$").Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否包含中文字符
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsHasChinese(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = new Regex("[\u4e00-\u9fa5]").Match(inputData);
            return m.Success;
        }
        #endregion

        #region 与数字相关校验
        /// <summary>
        /// 校验是正整数
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsInteger(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = new Regex("^[1-9]\\d*$").Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否数字
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsNumber(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = new Regex("^[0-9]+$").Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否数字 可带正负号
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsNumberSign(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = new Regex("^[+-]?[0-9]+$").Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否是浮点数
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsDecimal(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = new Regex("^[0-9]+[.]?[0-9]+$").Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsDecimalSign(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = new Regex("^[+-]?[0-9]+[.]?[0-9]+$").Match(inputData);
            return m.Success;
        }
        #endregion

        #region 与通讯方式相关的校验
        /// <summary>
        /// 电子邮件地址格式校验正则表达式，其中 w 表示英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        /// </summary>
        private static Regex RegEmail = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        /// <summary>
        /// 移动手机验证
        /// </summary>
        private static Regex RegMoveMobile = new Regex(@"(^1(3[4-9]|4[7]|5[0-27-9]|7[8]|8[2-478])\d{8}$)|(^1705\d{7}$)");
        /// <summary>
        /// 联通手机验证
        /// </summary>
        private static Regex RegUnicomMobile = new Regex(@"(^1(3[0-2]|4[5]|5[56]|7[6]|8[56])\d{8}$)|(^1709\d{7}$)");
        /// <summary>
        /// 电信手机验证
        /// </summary>
        private static Regex RegTelecomMobile = new Regex(@"(^1((77|8[019])[0-9]|349|700)\d{7}$)");
        /// <summary>
        /// 电信手机CDMA验证
        /// </summary>
        private static Regex RegTelecomCDMA = new Regex(@"^1[35]3\d{8}$");
        /// <summary>
        /// 座机验证
        /// </summary>
        private static Regex RegOfficePhone = new Regex(@"/^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?/");

        /// <summary>
        /// 校验是否式电子邮件
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsEmail(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否是移动手机号码
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsMoveMobile(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = RegMoveMobile.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否是联通手机号码
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsUnicomMobile(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = RegUnicomMobile.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否是电信手机号码
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsTelecomMobile(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = RegTelecomMobile.Match(inputData);
            if (!m.Success) { m = RegTelecomCDMA.Match(inputData); }
            return m.Success;
        }
        /// <summary>
        /// 校验是否是手机号码
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsMobile(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            bool success = IsMoveMobile(inputData);
            if (!success) { success = IsUnicomMobile(inputData); }
            if (!success) { success = IsTelecomMobile(inputData); }
            return success;
        }
        /// <summary>
        /// 校验是否是座机
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsOfficePhone(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = RegOfficePhone.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否是座机 或 手机号码
        /// </summary>
        public static bool IsPhone(this string inputData)
        {
            return inputData.IsOfficePhone() || inputData.IsMobile();
        }
        #endregion

        #region 与网络相关的校验
        /// <summary>
        /// 网址验证，以http://开头
        /// </summary>
        private static Regex RegUrl = new Regex(@"((https://)|(http://))([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?");
        /// <summary>
        /// IP地址验证，长度为32位，分为4段，每段8位，用十进制数字表示，每段数字范围为0~255，段与段之间用英文句点“.”隔开
        /// </summary>
        private static Regex IpAddress = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");

        /// <summary>
        /// 校验是否是HTTP开头的网址
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsHttpUrl(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = RegUrl.Match(inputData);
            return m.Success;
        }
        /// <summary>
        /// 校验是否是合法的IP地址
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool IsIpAddr(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) return false;
            Match m = IpAddress.Match(inputData);
            return m.Success;
        }
        #endregion

        #region 与身份证相关的校验
        /// <summary>
        /// 15位身份证号校验
        /// </summary>
        private static Regex Reg15IdCardNo = new Regex(@"^[1-9]\d{5}\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{2}$");
        /// <summary>
        /// 18位身份证号校验
        /// </summary>
        private static Regex Reg18IdCardNo = new Regex(@"^[1-9]\d{5}(18|19|([23]\d))\d{2}((0[1-9])|(10|11|12))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$");
        
        /// <summary>
        /// 校验是否是15位身份证号合法性
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool TryIdCard15(this string source, out int gender, out DateTime birthday)
        {
            long n = 0;
            gender = 2;
            birthday = DateTime.Parse("1970-01-01");
            if (!string.IsNullOrWhiteSpace(source) && Reg15IdCardNo.Match(source).Success)
            {
                if (!long.TryParse(source, out n) || n < Math.Pow(10, 14))
                {
                    return false;
                }
                string sex = source.Substring(12, 3);
                if (!string.IsNullOrWhiteSpace(sex))
                {
                    gender = int.Parse(sex);
                    string date = "19" + source.Substring(6, 2) + "-" + source.Substring(8, 2) + "-" + source.Substring(10, 2);
                    return DateTime.TryParse(date, out birthday);
                }
            }
            return false;
        }
        /// <summary>
        /// 校验是否是18位身份证号合法性
        /// </summary>
        /// <param name="inputData">校验对象</param>
        public static bool TryIdCard18(this string source, out int gender, out DateTime birthday)
        {
            gender = 2;
            birthday = DateTime.Parse("1970-01-01");
            if (!string.IsNullOrWhiteSpace(source) && Reg18IdCardNo.Match(source).Success)
            {
                string idNumber = source;
                if (!long.TryParse(idNumber.Remove(17), out var n) || n < Math.Pow(10, 16))
                {
                    return false;
                }
                string sex = idNumber.Substring(14, 3);
                if (!string.IsNullOrWhiteSpace(sex))
                {
                    gender = int.Parse(sex);
                    string date = idNumber.Substring(6, 4) + "-" + idNumber.Substring(10, 2) + "-" + idNumber.Substring(12, 2);
                    if (DateTime.TryParse(date, out birthday))
                    {
                        string[] ac = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
                        string[] wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
                        char[] ai = idNumber.Remove(17).ToCharArray();
                        // 加权求和
                        int sum = 0;
                        for (int i = 0; i < 17; i++)
                        {
                            sum += int.Parse(wi[i]) * int.Parse(ai[i].ToString());
                        }
                        Math.DivRem(sum, 11, out int y);
                        return ac[y] == idNumber.Substring(17, 1).ToLower();
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 校验是否是身份证号长度是否合法
        /// </summary>
        public static bool IsIdCard(this string inputData)
        {
            if (string.IsNullOrWhiteSpace(inputData)) { return false; }
            int gender = 2;
            DateTime birthday = DateTime.Parse("1970-01-01");
            bool result = inputData.TryIdCard15(out gender, out birthday);
            if (!result) { result = inputData.TryIdCard18(out gender, out birthday); }
            return result;
        }
        #endregion

    }
}