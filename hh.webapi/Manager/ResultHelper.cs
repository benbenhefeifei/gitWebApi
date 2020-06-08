using System;
using System.Collections.Generic;

namespace hh.webapi
{
    /// <summary>
    /// ApiResult ---- API结果输出
    /// </summary>
    internal class ResultHelper
    {
        /// <summary>
        /// 输出消息定义
        /// </summary>
        internal static IDictionary<string, string> EMsg
        {
            get
            {
                IDictionary<string, string> result = new Dictionary<string, string>();
                result.Add("00000", "ok");
                result.Add("12100", "系统错误");
                result.Add("12104", "请求参数错误");
                result.Add("12110", "无权访问");
                result.Add("12112", "账号错误");
                result.Add("12113", "密码错误");
                result.Add("12555", "没有查询到你要的数据");
                return result;
            }
        }
        /// <summary>
        /// 消息输出
        /// </summary>
        /// <param name="code">消息码</param>
        /// <param name="emsg">消息内容</param>
        internal static ApiResult Info(string code = "00000", string emsg = "ok")
        {
            if (code == "00000") { emsg = "ok"; }
            if (string.IsNullOrEmpty(emsg)) { emsg = ResultHelper.EMsg[code]; }
            return new ApiResult() { Status = code, Message = emsg };
        }
        /// <summary>
        /// 数据结果输出
        /// </summary>
        /// <param name="data">数据结果</param>
        internal static ApiResult Data<T>(T data)
        {
            if (data == null) { return ResultHelper.Info("12555"); }
            return new ApiResultData() { Status = "00000", Message = "ok", Data = data };
        }
        /// <summary>
        /// 分页查询结果输出
        /// </summary>
        /// <param name="count">数据总行数</param>
        /// <param name="data">当前数据结果</param>
        /// <param name="page">当前页码</param>
        /// <param name="limit">每页条目</param>
        /// <param name="total">汇总结果</param>
        internal static ApiResult Page<T>(long count, List<T> data, int page, int limit, object total = null)
        {
            string code = "00000", emsg = "ok";
            if (count == 0) { count = data.Count; }
            if (count == 0) { return ResultHelper.Info("12555"); }
            return new ApiResultPage() { Status = code, Message = emsg, Count = count, Index = page, Limit = limit, Data = data, Total = total };
        }
    }
}
