
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Text;

namespace Common.DatatableHandle
{
    public class ConvertDatatable
    {
        /// <summary>
        /// DataTable 到 string
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataTableToString(DataTable dt)
        {

            if (dt != null)
                return "";
            //!@&,#$%,^&*为字段的拼接字符串
            //为了防止连接字符串不在DataTable数据中存在，特意将拼接字符串写成特殊的字符！
            StringBuilder strData = new StringBuilder();
            StringWriter sw = new StringWriter();

            //DataTable 的当前数据结构以 XML 架构形式写入指定的流
            dt.WriteXmlSchema(sw);
            strData.Append(sw.ToString());
            sw.Close();
            strData.Append("@&@");
            for (int i = 0; i < dt.Rows.Count; i++)           //遍历dt的行
            {
                DataRow row = dt.Rows[i];
                if (i > 0)                                    //从第二行数据开始，加上行的连接字符串
                {
                    strData.Append("#$%");
                }
                for (int j = 0; j < dt.Columns.Count; j++)    //遍历row的列
                {
                    if (j > 0)                                //从第二个字段开始，加上字段的连接字符串
                    {
                        strData.Append("^&*");
                    }
                    strData.Append(Convert.ToString(row[j])); //取数据
                }
            }

            return strData.ToString();
        }


        /// <summary>
        /// string 到 DataTable
        /// </summary>
        /// <param name="strdata"></param>
        /// <returns></returns>
        public static DataTable StringToDataTable(string strdata)
        {
            if (string.IsNullOrEmpty(strdata))
            {
                return null;
            }
            DataTable dt = new DataTable();
            string[] strSplit = { "@&@" };
            string[] strRow = { "#$%" };    //分解行的字符串
            string[] strColumn = { "^&*" }; //分解字段的字符串

            string[] strArr = strdata.Split(strSplit, StringSplitOptions.None);
            StringReader sr = new StringReader(strArr[0]);
            dt.ReadXmlSchema(sr);
            sr.Close();


            string strTable = strArr[1]; //取表的数据
            if (!string.IsNullOrEmpty(strTable))
            {
                string[] strRows = strTable.Split(strRow, StringSplitOptions.None); //解析成行的字符串数组
                for (int rowIndex = 0; rowIndex < strRows.Length; rowIndex++)       //行的字符串数组遍历
                {
                    string vsRow = strRows[rowIndex]; //取行的字符串
                    string[] vsColumns = vsRow.Split(strColumn, StringSplitOptions.None); //解析成字段数组
                    for(int a=0;a<vsColumns.Length;a++)
                    {
                        if(vsColumns[a]== "")
                        {
                            vsColumns[a] = null;
                        }
                    }
                    dt.Rows.Add(vsColumns);
                }
            }
            return dt;
        }
        /// <summary>
        /// dataset 到 string
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DataSetToString(DataSet ds)
        {
            string str = "";
            try
            {
                foreach (DataTable dt in ds.Tables)
                {

                    if (dt != null)
                    {
                        //!@&,#$%,^&*为字段的拼接字符串
                        //为了防止连接字符串不在DataTable数据中存在，特意将拼接字符串写成特殊的字符！
                        StringBuilder strData = new StringBuilder();
                        StringWriter sw = new StringWriter();

                        //DataTable 的当前数据结构以 XML 架构形式写入指定的流
                        dt.WriteXmlSchema(sw);
                        strData.Append(sw.ToString());
                        sw.Close();
                        strData.Append("@&@");
                        for (int i = 0; i < dt.Rows.Count; i++)           //遍历dt的行
                        {
                            DataRow row = dt.Rows[i];
                            if (i > 0)                                    //从第二行数据开始，加上行的连接字符串
                            {
                                strData.Append("#$%");
                            }
                            for (int j = 0; j < dt.Columns.Count; j++)    //遍历row的列
                            {
                                if (j > 0)                                //从第二个字段开始，加上字段的连接字符串
                                {
                                    strData.Append("^&*");
                                }
                                strData.Append(Convert.ToString(row[j])); //取数据
                            }
                        }

                        str += strData.ToString() + "!@#$%^&";
                    }


                }
            }
            catch
            {
                str = "";
            }
            return str;
        }


        /// <summary>
        /// string 到 dataset
        /// </summary>
        /// <param name="strdata"></param>
        /// <returns></returns>
        public static DataSet StringToDataSet(string strDataSet)
        {

            if (strDataSet.Length > 0)
            {
                string[] aaaa = { "!@#$%^&" };
                string[] strDataTables = strDataSet.Split(aaaa, StringSplitOptions.None);
                DataSet ds = new DataSet();
                foreach (string strDataTable in strDataTables)
                {
                    if (!string.IsNullOrEmpty(strDataTable))
                    {
                        DataTable dt = new DataTable();
                        string[] strSplit = { "@&@" };
                        string[] strRow = { "#$%" };    //分解行的字符串
                        string[] strColumn = { "^&*" }; //分解字段的字符串

                        string[] strArr = strDataTable.Split(strSplit, StringSplitOptions.None);
                        StringReader sr = new StringReader(strArr[0]);
                        dt.ReadXmlSchema(sr);
                        sr.Close();


                        string strTable = strArr[1]; //取表的数据
                        if (!string.IsNullOrEmpty(strTable))
                        {
                            string[] strRows = strTable.Split(strRow, StringSplitOptions.None); //解析成行的字符串数组
                            for (int rowIndex = 0; rowIndex < strRows.Length; rowIndex++)       //行的字符串数组遍历
                            {
                                string vsRow = strRows[rowIndex]; //取行的字符串


                                string[] vsColumns = vsRow.Split(strColumn, StringSplitOptions.None); //解析成字段数组


                                dt.Rows.Add(vsColumns);

                            }
                        }
                        ds.Tables.Add(dt);
                    }
                }
                return ds;
            }
            else
            {
                return null;
            }
        }
    }
}


