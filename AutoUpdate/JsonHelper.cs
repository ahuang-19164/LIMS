using Newtonsoft.Json;

namespace AutoUpdate
{
    public class JsonHelper
    {
        /// <summary>
        /// 将对象序列化为json格式
        /// </summary>
        /// <param name="obj">序列化对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObjct(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static T JsonConvertObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }

}