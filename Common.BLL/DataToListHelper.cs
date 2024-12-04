using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Common.BLL
{
    public class DataToListHelper
    {
        public static List<T> TableToEntity<T>(DataTable dt) where T : class, new()
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                PropertyInfo[] pArray = type.GetProperties();
                T entity = new T();
                foreach (PropertyInfo p in pArray)
                {
                    if (row[p.Name] is Int64)
                    {
                        p.SetValue(entity, Convert.ToInt32(row[p.Name]), null);
                        continue;
                    }
                    p.SetValue(entity, row[p.Name].ToString(), null);
                }
                list.Add(entity);
            }
            return list;
        }

    }
}
