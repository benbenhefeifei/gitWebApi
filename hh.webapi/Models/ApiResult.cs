using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace hh.webapi
{    
    /// <summary>
    /// ApiResultData ---- API数据结果输出
    /// 状态码==00000，有以下数据
    /// </summary>
    public class ApiResultData : ApiResult
    {
        /// <summary>
        /// 结果数据
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
    }
    /// <summary>
    /// ApiResultPage ---- API分页数据结果输出
    /// 状态码==00000，有以下数据
    /// </summary>
    public class ApiResultPage : ApiResult
    {        
        /// <summary>
        /// 结果数据
        /// </summary>
        [JsonProperty("count")]
        public long Count { get; set; }
        /// <summary>
        /// 结果数据
        /// </summary>
        [JsonProperty("page")]
        public int Index { get; set; }
        /// <summary>
        /// 结果数据
        /// </summary>
        [JsonProperty("size")]
        public int Limit { get; set; }

        /// <summary>
        /// 结果数据
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
        /// <summary>
        /// 数据小计与合计
        /// </summary>
        [JsonProperty("total")]
        public object Total { get; set; }
    }
    /// <summary>
    /// ApiResult ---- API结果输出
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
        /// <summary>
        /// 状态消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }

}
