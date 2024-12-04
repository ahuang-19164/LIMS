using Common.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.JsonHelper
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
            if (json != "")
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }

        }
        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static T JsonConvertObject<T>(object json)
        {
            if (json == null)
                return default(T);
            if (json.ToString() != "")
            {
                return JsonConvert.DeserializeObject<T>(json.ToString());
            }
            else
            {
                return default(T);
            }

        }

        /// <summary>
        /// 解析WebApiCallBack生成对象实体
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="json">JSON字符串</param>
        /// <returns></returns>
        public static T JsonConvertObject<T>(WebApiCallBack jm)
        {
            if (jm.code == 0)
            {
                if (jm.data != null)
                    return JsonConvert.DeserializeObject<T>(jm.data.ToString());
            }
            return default(T);

        }




        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <returns></returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object obj = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = obj as T;
            return t;
        }
        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object obj = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            List<T> list = obj as List<T>;
            return list;
        }
        /// <summary>
        /// 将JSON转数组
        /// 用法:jsonArr[0]["xxxx"]
        /// </summary>
        /// <param name="json">json字符串</param>
        /// <returns></returns>
        public static JArray GetToJsonList(string json)
        {
            JArray jsonArr = (JArray)JsonConvert.DeserializeObject(json);
            return jsonArr;
        }
        /// <summary>
        /// 将DataTable转换成实体类
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<T> DtConvertToModel<T>(DataTable dt) where T : new()
        {
            List<T> ts = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                foreach (PropertyInfo pi in t.GetType().GetProperties())
                {
                    if (dt.Columns.Contains(pi.Name))
                    {
                        if (!pi.CanWrite) continue;
                        var value = dr[pi.Name];
                        if (value != DBNull.Value)
                        {
                            switch (pi.PropertyType.FullName)
                            {
                                case "System.Decimal":
                                    pi.SetValue(t, decimal.Parse(value.ToString()), null);
                                    break;
                                case "System.String":
                                    pi.SetValue(t, value.ToString(), null);
                                    break;
                                case "System.Int32":
                                    pi.SetValue(t, int.Parse(value.ToString()), null);
                                    break;
                                default:
                                    pi.SetValue(t, value, null);
                                    break;
                            }
                        }
                    }
                }
                ts.Add(t);
            }
            return ts;
        }





        #region 自定义字符串方法

        public static string DTToString(DataTable dt)
        {
            if (dt != null)
            {
                StringBuilder strData = new StringBuilder();
                StringWriter sw = new StringWriter();
                dt.WriteXmlSchema(sw);
                strData.Append(sw.ToString());
                strData.Append(",");

                foreach (DataRow rowVlue in dt.Rows)
                {
                    string rowString = "";
                    foreach (DataColumn column in dt.Columns)
                    {
                        rowString += rowVlue[column.ColumnName] != DBNull.Value ? rowVlue[column.ColumnName].ToString().Replace(",", "，") + "," : "@null,";
                    }
                    strData.Append(rowString);
                }
                string ss = strData.ToString();
                return ss.Substring(0, ss.Length - 1);
            }
            else
            {
                return "";
            }
        }
        public static DataTable StringToDT(string strdata)
        {
            try
            {
                if (string.IsNullOrEmpty(strdata))
                {
                    return null;
                }
                DataTable dt = new DataTable();
                string[] strSplit = strdata.Split(',');
                //string[] strArr = strdata.Split(strSplit, StringSplitOptions.None);
                StringReader sr = new StringReader(strSplit[0]);
                dt.ReadXmlSchema(sr);
                sr.Close();

                int columnscount = dt.Columns.Count;

                for (int a = 1; a < strSplit.Length;)
                {
                    object[] objects = new object[columnscount];
                    for (int b = 0; b < columnscount; b++)
                    {
                        if (strSplit[a] == "@null")
                        {
                            objects[b] = null;
                        }
                        else
                        {
                            objects[b] = strSplit[a].Replace("，", ",");
                        }
                        a++;
                    }
                    dt.Rows.Add(objects);

                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable StringToDT(WebApiCallBack jm)
        {
            if (jm != null && jm.code == 0)
            {
                try
                {
                    if (string.IsNullOrEmpty(jm.data.ToString()))
                    {
                        return null;
                    }
                    DataTable dt = new DataTable();
                    string[] strSplit = jm.data.ToString().Split(',');
                    //string[] strArr = strdata.Split(strSplit, StringSplitOptions.None);
                    StringReader sr = new StringReader(strSplit[0]);
                    dt.ReadXmlSchema(sr);
                    sr.Close();

                    int columnscount = dt.Columns.Count;

                    for (int a = 1; a < strSplit.Length;)
                    {
                        object[] objects = new object[columnscount];
                        for (int b = 0; b < columnscount; b++)
                        {
                            if (strSplit[a] == "@null")
                            {
                                objects[b] = null;
                            }
                            else
                            {
                                objects[b] = strSplit[a].Replace("，", ",");
                            }
                            a++;
                        }
                        dt.Rows.Add(objects);

                    }
                    return dt;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        #endregion
    }
}
