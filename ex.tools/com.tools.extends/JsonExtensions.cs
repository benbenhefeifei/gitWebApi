
namespace System
{
    using IO;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// JSON字符串转换扩展
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// [自定义扩展] 将此实例的属性值以JSON字符串形式返回
        /// </summary>
        public static string ToJsonString(this object source, string dateTimeFormat = "yyyy-MM-dd HH:mm:ss")
        {
            if (source != null)
            {
                JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                {
                    //这句是解决问题的关键,也就是json.net官方给出的解决配置选项.
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                };
                JsonSerializer jsonSerializer = JsonSerializer.Create(jsonSettings);
                jsonSerializer.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = dateTimeFormat });
                using (StringWriter stringWriter = new StringWriter())
                {
                    jsonSerializer.Serialize(stringWriter, source);
                    return stringWriter.ToString();
                }
            }
            return "{}";
        }


        public static string ToJson(this object value)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            //settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            string json = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, settings).Replace("\r\n", ""); ;
            return json;
        }
        public static T Deserialize<T>(string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}
