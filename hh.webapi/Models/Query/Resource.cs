using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace hh.webapi.Models
{
    public class Navbar
    {
        /// <summary>
        /// 导航资源 KEY
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }
        /// <summary>
        /// 导航资源 名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        /// <summary>
        /// 导航资源 图标
        /// </summary>
        [JsonProperty("icon")]
        public string Icon { get; set; }
        /// <summary>
        /// 链接
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }
        /// <summary>
        /// 子资源
        /// </summary>
        [JsonProperty("children")]
        public List<Navbar> Children { get; set; }
    }

    public class ResPower
    {
        /// <summary>
        /// 导航资源 KEY
        /// </summary>
        [JsonProperty("id")]
        public string ID { get; set; }
        /// <summary>
        /// 导航资源 KEY
        /// </summary>
        [JsonProperty("field")]
        public string Field { get; set; }
        /// <summary>
        /// 导航资源 名称
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        /// 导航资源 图标
        /// </summary>
        [JsonProperty("spread")]
        public bool Spread { get; set; }
        /// <summary>
        /// 子资源
        /// </summary>
        [JsonProperty("children")]
        public List<ResPower> Children { get; set; }
    }
}
