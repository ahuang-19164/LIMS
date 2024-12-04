using Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Table
{
    public class DataTableHelper
    {
        //public static string DataTableToString(DataTable dt)
        //{
        //    //!@&,#$%,^&*为字段的拼接字符串
        //    //为了防止连接字符串不在DataTable数据中存在，特意将拼接字符串写成特殊的字符！
        //    StringBuilder strData = new StringBuilder();
        //    StringWriter sw = new StringWriter();

        //    //DataTable 的当前数据结构以 XML 架构形式写入指定的流
        //    dt.WriteXmlSchema(sw);
        //    strData.Append(sw.ToString());
        //    sw.Close();
        //    strData.Append("@&@");
        //    for (int i = 0; i < dt.Rows.Count; i++)             //遍历dt的行
        //    {
        //        DataRow row = dt.Rows[i];
        //        if (i > 0)                                    //从第二行数据开始，加上行的连接字符串
        //        {
        //            strData.Append("#$%");
        //        }
        //        for (int j = 0; j < dt.Columns.Count; j++)    //遍历row的列
        //        {
        //            if (j > 0)                                //从第二个字段开始，加上字段的连接字符串
        //            {
        //                strData.Append("^&*");
        //            }
        //            strData.Append(Convert.ToString(row[j])); //取数据
        //        }
        //    }

        //    return strData.ToString();
        //}
        //public static DataTable StringToDataTable(string strdata)
        //{
        //    if (string.IsNullOrEmpty(strdata))
        //    {
        //        return null;
        //    }
        //    DataTable dt = new DataTable();
        //    string[] strSplit = { "@&@" };
        //    string[] strRow = { "#$%" }; //分解行的字符串
        //    string[] strColumn = { "^&*" }; //分解字段的字符串

        //    string[] strArr = strdata.Split(strSplit, StringSplitOptions.None);
        //    StringReader sr = new StringReader(strArr[0]);
        //    dt.ReadXmlSchema(sr);
        //    sr.Close();


        //    string strTable = strArr[1]; //取表的数据
        //    if (!string.IsNullOrEmpty(strTable))
        //    {
        //        string[] strRows = strTable.Split(strRow, StringSplitOptions.None); //解析成行的字符串数组
        //        for (int rowIndex = 0; rowIndex < strRows.Length; rowIndex++) //行的字符串数组遍历
        //        {
        //            string vsRow = strRows[rowIndex]; //取行的字符串
        //            string[] vsColumns = vsRow.Split(strColumn, StringSplitOptions.None); //解析成字段数组
        //            dt.Rows.Add(vsColumns);
        //        }
        //    }
        //    return dt;
        //}


        //public static string DTToString(DataTable dt)
        //{
        //    if (dt != null)
        //    {
        //        StringBuilder strData = new StringBuilder();
        //        StringWriter sw = new StringWriter();
        //        dt.WriteXmlSchema(sw);
        //        strData.Append(sw.ToString());
        //        strData.Append(",");

        //        foreach (DataRow rowVlue in dt.Rows)
        //        {
        //            string rowString = "";
        //            foreach (DataColumn column in dt.Columns)
        //            {
        //                rowString += rowVlue[column.ColumnName] != DBNull.Value ? rowVlue[column.ColumnName].ToString().Replace(",", "，") + "," : "@null,";
        //            }
        //            strData.Append(rowString);
        //        }
        //        string ss = strData.ToString();
        //        return ss.Substring(0, ss.Length - 1);
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        //public static DataTable StringToDT(string strdata)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(strdata))
        //        {
        //            return null;
        //        }
        //        DataTable dt = new DataTable();
        //        string[] strSplit = strdata.Split(',');
        //        //string[] strArr = strdata.Split(strSplit, StringSplitOptions.None);
        //        StringReader sr = new StringReader(strSplit[0]);
        //        dt.ReadXmlSchema(sr);
        //        sr.Close();

        //        int columnscount = dt.Columns.Count;

        //        for (int a = 1; a < strSplit.Length;)
        //        {
        //            object[] objects = new object[columnscount];
        //            for (int b = 0; b < columnscount; b++)
        //            {
        //                if (strSplit[a] == "@null")
        //                {
        //                    objects[b] = null;
        //                }
        //                else
        //                {
        //                    objects[b] = strSplit[a].Replace("，", ",");
        //                }
        //                a++;
        //            }
        //            dt.Rows.Add(objects);

        //        }
        //        return dt;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        //public static DataTable StringToDT(WebApiCallBack jm)
        //{
        //    if(jm!=null&&jm.code==0)
        //    {
        //        try
        //        {
        //            if (string.IsNullOrEmpty(jm.data.ToString()))
        //            {
        //                return null;
        //            }
        //            DataTable dt = new DataTable();
        //            string[] strSplit = jm.data.ToString().Split(',');
        //            //string[] strArr = strdata.Split(strSplit, StringSplitOptions.None);
        //            StringReader sr = new StringReader(strSplit[0]);
        //            dt.ReadXmlSchema(sr);
        //            sr.Close();

        //            int columnscount = dt.Columns.Count;

        //            for (int a = 1; a < strSplit.Length;)
        //            {
        //                object[] objects = new object[columnscount];
        //                for (int b = 0; b < columnscount; b++)
        //                {
        //                    if (strSplit[a] == "@null")
        //                    {
        //                        objects[b] = null;
        //                    }
        //                    else
        //                    {
        //                        objects[b] = strSplit[a].Replace("，", ",");
        //                    }
        //                    a++;
        //                }
        //                dt.Rows.Add(objects);

        //            }
        //            return dt;
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
