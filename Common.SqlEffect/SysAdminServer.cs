
using Common.DAL;
using Common.Data;
using Common.RegisterInfo;
using Common.SqlModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace Common.SqlEffect
{
    public class SysAdminServer
    {
        //public static string sqlconnE = "Server=192.168.0.24,1433;DataBase=ELIMSDB;Uid=sa;Pwd=abc123,";
        //public static string sqlconnH = "Server=192.168.0.28,1433;DataBase=HLMISDB;Uid=sa;Pwd=abc123,";
        //SqlHelper sqlHelper = new SqlHelper();


        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static DataTable LoadAuthen(LoadInfo info)
        {
            DataTable dt = null;
            if (info.UserToken == "LoginIn")
            {
                if (info.UserName != null && info.UserPwd != null)
                {
                    if (info.UserName.Length != 0 && info.UserPwd.Length != 0)
                    {
                        string token = MD5Hepler.GetMd5String("HLIMS" + info.UserName + "Hlong" + DateTime.Now.ToString("yyyy-MM-dd") + "!!!");
                        string Ssql = $"select * from Common.UserInfo where UserNO='{info.UserName}' and Pwd='{info.UserPwd}'";
                        string Ssql2 = $"INSERT INTO Common.UserLoadInfo (NO,Names,Token,CreateTime,EndTime) VALUES('{info.UserName}','{info.UserPwd}','{token}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd HH:mm:ss")}')";
                        SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql2);
                        dt = SqlHelper.ExecuteDataset(CommonData.sqlconnH, CommandType.Text, Ssql).Tables[0];
                        //dt = SqlHelper.r(sqlconn, CommandType.Text, Ssql).Tables[0];
                        if (dt.Rows.Count != 1)
                        {
                            return dt;
                        }
                    }
                }
            }
            return dt;
        }



        #region select

        /// <summary>
        /// 查询数据返回datatable
        /// </summary>
        /// <param name="SelectValue">查询json</param>
        /// <returns></returns>
        public static DataTable SelectsH(sInfo info)
        {
            try
            {
                DataTable dt = null;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            string Ssql = "select ";
                            if (info.values != null)
                            {
                                if (info.values.Length != 0)
                                {
                                    Ssql += info.values + "  from  " + info.TableName;
                                }
                                else
                                {
                                    Ssql += " * from  " + info.TableName;
                                }

                            }
                            else
                            {
                                Ssql += " * from  " + info.TableName;
                            }

                            if (info.wheres != null)
                            {
                                if (info.wheres.Length != 0)
                                {
                                    Ssql += " where " + info.wheres;
                                }

                            }
                            if (info.GroupColumns != null)
                            {
                                if (info.GroupColumns.Length != 0)
                                {
                                    Ssql += " group by " + info.GroupColumns;
                                }

                            }
                            if (info.OrderColumns != null)
                            {
                                if (info.OrderColumns.Length != 0)
                                {
                                    Ssql += " order by " + info.OrderColumns;
                                }

                            }
                            dt = SqlHelper.ExecuteDataset(CommonData.sqlconnH, CommandType.Text, Ssql).Tables[0];
                            dt.TableName = info.TableName;
                        }
                    }
                return dt;

            }
            catch
            {
                return null;
            }
        }




        /// <summary>
        /// 查询数据返回dataset
        /// </summary>
        /// <param name="SelectValue">查询json</param>
        /// <returns></returns>
        public static DataSet SelectsDSH(sInfo info)
        {
            try
            {
                DataSet dt = null;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            string sss = "";
                            string[] names = info.TableName.Split(',');
                            foreach(string name in names)
                            {
                                string Ssql = "select ";
                                if (info.values != null)
                                {
                                    if (info.values.Length != 0)
                                    {
                                        Ssql += info.values + "  from  " + name;
                                    }
                                    else
                                    {
                                        Ssql += " * from  " + name;
                                    }

                                }
                                else
                                {
                                    Ssql += " * from  " + name;
                                }

                                if (info.wheres != null)
                                {
                                    if (info.wheres.Length != 0)
                                    {
                                        Ssql += " where " + info.wheres;
                                    }

                                }
                                if (info.GroupColumns != null)
                                {
                                    if (info.GroupColumns.Length != 0)
                                    {
                                        Ssql += " group by " + info.GroupColumns;
                                    }

                                }
                                if (info.OrderColumns != null)
                                {
                                    if (info.OrderColumns.Length != 0)
                                    {
                                        Ssql += " order by " + info.OrderColumns;
                                    }

                                }
                                sss += Ssql + ";";
                            }

                            dt = SqlHelper.ExecuteDataset(CommonData.sqlconnH, CommandType.Text, sss);
                        }
                    }
                return dt;

            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 查询数据返回datatable
        /// </summary>
        /// <param name="SelectValue">查询json</param>
        /// <returns></returns>
        public static DataTable selects(sInfo info)
        {
            try
            {
                DataTable dt = null;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            string Ssql = "select ";
                            if (info.values != null)
                            {
                                if (info.values.Length != 0)
                                {
                                    Ssql += info.values + "  from  " + info.TableName;
                                }
                                else
                                {
                                    Ssql += " * from  " + info.TableName;
                                }

                            }
                            else
                            {
                                Ssql += " * from  " + info.TableName;
                            }

                            if (info.values != null)
                            {
                                if (info.values.Length != 0)
                                {
                                    Ssql += " where " + info.values;
                                }

                            }
                            if (info.GroupColumns != null)
                            {
                                if (info.GroupColumns.Length != 0)
                                {
                                    Ssql += " group by " + info.GroupColumns;
                                }

                            }
                            if (info.OrderColumns != null)
                            {
                                if (info.OrderColumns.Length != 0)
                                {
                                    Ssql += " order by " + info.OrderColumns;
                                }

                            }
                            dt = SqlHelper.ExecuteDataset(CommonData.sqlconnH, CommandType.Text, Ssql).Tables[0];
                            dt.TableName = info.TableName;
                        }
                    }
                return dt;

            }
            catch
            {
                return null;
            }

        }


        #endregion





        #region update


        /// <summary>
        /// 修改数据返回影响行数
        /// </summary>
        /// <param name="UpdateValue">查询json</param>
        /// <returns></returns>
        public int update(uInfo info)
        {
            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "update " + info.TableName;
                            if (info.value != null)
                            {
                                if (info.value.Length != 0)
                                {
                                    Ssql += " set  " + info.value;

                                    if (info.DataValueID != 0)
                                    {
                                        Ssql += " where  id=" + info.DataValueID;
                                        a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                    }
                                    else
                                    {
                                        if (info.wheres != null)
                                        {
                                            if (info.wheres.Length != 0)
                                            {
                                                Ssql += " where  " + info.wheres;
                                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (info.values != null)
                                    {
                                        string setValue = string.Empty;
                                        foreach (KeyValuePair<string, object> pair in info.values)
                                        {
                                            setValue += pair.Key + "=N'" + pair.Value + "',";
                                        }
                                        Ssql += " set  " + setValue.Substring(0, setValue.Length - 1);
                                        if (info.DataValueID != 0)
                                        {
                                            Ssql += " where  id=" + info.DataValueID;
                                            a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                        }
                                        else
                                        {
                                            if (info.wheres != null)
                                            {
                                                if (info.wheres.Length != 0)
                                                {
                                                    Ssql += " where  " + info.wheres;
                                                    a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                return a;
            }
            catch
            {
                return 0;
            }

        }
        /// <summary>
        /// 修改数据返回影响行数
        /// </summary>
        /// <param name="UpdateValue">查询json</param>
        /// <returns></returns>
        public static int updates(uInfo info)
        {
            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "update " + info.TableName;
                            if (info.value != null)
                            {
                                if (info.value.Length != 0)
                                {
                                    Ssql += " set  " + info.value;

                                    if (info.DataValueID != 0)
                                    {
                                        Ssql += " where  id=" + info.DataValueID;
                                        a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                    }
                                    else
                                    {
                                        if (info.wheres != null)
                                        {
                                            if (info.wheres.Length != 0)
                                            {
                                                Ssql += " where  " + info.wheres;
                                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (info.values != null)
                                {
                                    if (info.values.Count > 0)
                                    {
                                        string setValue = string.Empty;
                                        foreach (KeyValuePair<string, object> pair in info.values)
                                        {
                                            setValue += pair.Key + "=N'" + pair.Value + "',";
                                        }
                                        Ssql += " set  " + setValue.Substring(0, setValue.Length - 1);
                                        if (info.DataValueID != 0)
                                        {
                                            Ssql += " where  id=" + info.DataValueID;
                                            a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                        }
                                        else
                                        {
                                            if (info.wheres != null)
                                            {
                                                if (info.wheres.Length != 0)
                                                {
                                                    Ssql += " where  " + info.wheres;
                                                    a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                return a;
            }
            catch
            {
                return 0;
            }

        }
        /// <summary>
        /// 修改数据返回影响行数
        /// </summary>
        /// <param name="UpdateValue">查询json</param>
        /// <returns></returns>
        public static int updatesH(uInfo info)
        {
            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "update " + info.TableName;
                            if (info.value != null)
                            {
                                if (info.value != "")
                                {
                                    Ssql += " set  " + info.value;
                                    if (info.DataValueID != 0)
                                    {
                                        Ssql += " where  id=" + info.DataValueID;
                                        a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                    }
                                    else
                                    {
                                        if (info.wheres != null)
                                        {
                                            if (info.wheres != "")
                                            {
                                                Ssql += " where  " + info.wheres;
                                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (info.values != null)
                                    {
                                        string setValue = string.Empty;
                                        foreach (KeyValuePair<string, object> pair in info.values)
                                        {
                                            setValue += pair.Key + "=N'" + pair.Value + "',";
                                        }
                                        Ssql += " set  " + setValue.Substring(0, setValue.Length - 1);
                                        if (info.DataValueID != 0)
                                        {
                                            Ssql += " where  id=" + info.DataValueID;
                                            a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                        }
                                        else
                                        {
                                            if (info.wheres != "")
                                            {
                                                Ssql += " where  " + info.values;
                                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (info.values != null)
                                {
                                    string setValue = string.Empty;
                                    foreach (KeyValuePair<string, object> pair in info.values)
                                    {
                                        setValue += pair.Key + "=N'" + pair.Value + "',";
                                    }
                                    Ssql += " set  " + setValue.Substring(0, setValue.Length - 1);
                                    if (info.DataValueID != 0)
                                    {
                                        Ssql += " where  id=" + info.DataValueID;
                                        a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                    }
                                    else
                                    {
                                        if (info.wheres != "")
                                        {
                                            Ssql += " where  " + info.wheres;
                                            a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                        }
                                    }
                                }
                            }

                        }
                    }
                return a;
            }
            catch
            {
                return 0;
            }

        }

        #endregion




        #region delete

        /// <summary>
        /// 删除数据返回影响行数
        /// </summary>
        /// <param name="SelectValue">查询json</param>
        /// <returns></returns>
        public static int deletes(dInfo info)
        {
            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "delete " + info.TableName;
                            if (info.DataValueID > 1)
                            {
                                Ssql += " where  id=" + info.DataValueID;
                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                            }
                        }
                    }
                return a;
            }
            catch
            {
                return 0;
            }
        }
        public static int deletesH(dInfo info)
        {
            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "delete " + info.TableName;
                            if (info.DataValueID > 1)
                            {
                                Ssql += " where  id=" + info.DataValueID;
                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                            }
                        }
                    }
                return a;
            }
            catch
            {
                return 0;
            }
        }


        #endregion





        #region hide
        /// <summary>
        /// 隐藏信息
        /// </summary>
        /// <param name="HideValue"></param>
        /// <returns></returns>
        public int hide(hideInfo info)
        {

            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "update " + info.TableName + " Set dstate=1";
                            if (info.DataValueID > 1)
                            {
                                Ssql += " where  id=" + info.DataValueID;
                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                            }
                        }
                    }

                return a;
            }
            catch
            {
                return 0;
            }

        }
        public static int hides(hideInfo info)
        {

            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "update " + info.TableName + " Set dstate=1";
                            if (info.DataValueID > 1)
                            {
                                Ssql += " where  id=" + info.DataValueID;
                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                            }
                        }
                    }
                return a;
            }
            catch
            {
                return 0;
            }

        }
        public static int hidesH(hideInfo info)
        {

            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "update " + info.TableName + " Set dstate=1";
                            if (info.DataValueID > 1)
                            {
                                Ssql += " where  id=" + info.DataValueID;
                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                            }
                        }
                    }
                return a;
            }
            catch
            {
                return 0;
            }

        }

        #endregion





        #region insert

        public int insert(iInfo info)
        {
            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                    if (info.TableName != null)
                    {
                        if (info.TableName.Length != 0)
                        {
                            string Cname = string.Empty;
                            string CValue = string.Empty;
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "insert into " + info.TableName;
                            if (info.values != null)
                            {
                                foreach (KeyValuePair<string, object> item in info.values)
                                {
                                    Cname += item.Key + ",";
                                    CValue += "N'" + item.Value + "',";
                                }
                                Cname = "(" + Cname.Substring(0, Cname.Length - 1) + ")";
                                CValue = "(" + CValue.Substring(0, CValue.Length - 1) + ")";

                                Ssql += Cname + " values " + CValue;
                                a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                            }
                            else
                            {
                                if (info.listValues != null)
                                {
                                    foreach (KeyValuePair<string, List<object>> item in info.listValues)
                                    {
                                        Cname += item.Key + ",";
                                        if (info.listValues.Count != item.Value.Count)
                                        {
                                            foreach (string s in item.Value)
                                            {
                                                CValue += "'" + item.Value + "',";
                                            }
                                            CValue = "(" + CValue.Substring(0, CValue.Length - 1) + "),";
                                        }

                                    }
                                    CValue = CValue.Substring(0, CValue.Length - 1);
                                    Ssql += Cname + " values " + CValue;
                                    a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                }
                            }
                        }
                    }
                return a;
            }
            catch
            {
                return 0;
            }
        }
        public static int inserts(iInfo info)
        {
            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                {

                    if (info.TableName != null)
                    {


                        if (info.TableName.Length != 0)
                        {
                            string Cname = string.Empty;
                            string CValue = string.Empty;
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "insert into " + info.TableName;
                            if (info.values != null)
                            {
                                if (info.values.Count > 0)
                                {
                                    foreach (KeyValuePair<string, object> item in info.values)
                                    {
                                        Cname += item.Key + ",";
                                        CValue += "N'" + item.Value + "',";
                                    }
                                    Cname = "(" + Cname.Substring(0, Cname.Length - 1) + ")";
                                    CValue = "(" + CValue.Substring(0, CValue.Length - 1) + ")";

                                    Ssql += Cname + " values " + CValue;
                                    a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                }
                            }
                            else
                            {
                                if (info.listValues != null)
                                {
                                    if (info.listValues.Count > 0)
                                    {
                                        foreach (KeyValuePair<string, List<object>> item in info.listValues)
                                        {
                                            Cname += item.Key + ",";
                                            if (info.listValues.Count != item.Value.Count)
                                            {
                                                foreach (string s in item.Value)
                                                {
                                                    CValue += "'" + item.Value + "',";
                                                }
                                                CValue = "(" + CValue.Substring(0, CValue.Length - 1) + "),";
                                            }

                                        }
                                        CValue = CValue.Substring(0, CValue.Length - 1);
                                        Ssql += Cname + " values " + CValue;
                                        a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                    }

                                }
                            }
                        }
                    }
                }
                return a;
            }
            catch
            {
                return 0;
            }
        }
        public static int insertsH(iInfo info)
        {
            try
            {
                int a = 0;
                if (SysLoadInfo.UserAuthens(info.UserToken))
                {

                    if (info.TableName != null)
                    {


                        if (info.TableName.Length != 0)
                        {
                            string Cname = string.Empty;
                            string CValue = string.Empty;
                            //update HLMISDB.Common.UserInfo set remark='aaaa'
                            string Ssql = "insert into " + info.TableName;
                            if (info.values != null)
                            {
                                if (info.values.Count > 0)
                                {
                                    foreach (KeyValuePair<string, object> item in info.values)
                                    {
                                        Cname += item.Key + ",";
                                        CValue += "N'" + item.Value + "',";
                                    }
                                    Cname = "(" + Cname.Substring(0, Cname.Length - 1) + ")";
                                    CValue = "(" + CValue.Substring(0, CValue.Length - 1) + ")";

                                    Ssql += Cname + " values " + CValue;
                                    a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                }
                            }
                            else
                            {
                                if (info.listValues != null)
                                {
                                    if (info.listValues.Count > 0)
                                    {
                                        foreach (KeyValuePair<string, List<object>> item in info.listValues)
                                        {
                                            Cname += item.Key + ",";
                                            if (info.listValues.Count != item.Value.Count)
                                            {
                                                foreach (string s in item.Value)
                                                {
                                                    CValue += "'" + item.Value + "',";
                                                }
                                                CValue = "(" + CValue.Substring(0, CValue.Length - 1) + "),";
                                            }

                                        }
                                        CValue = CValue.Substring(0, CValue.Length - 1);
                                        Ssql += Cname + " values " + CValue;
                                        a = SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                    }

                                }
                            }
                        }
                    }
                }
                return a;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        #endregion





        #region saveTable
        public static bool SaveTablesH(SaveTableInfo saveTable)
        {
            try
            {
                bool a = false;
                int b = 0;
                if (SysLoadInfo.UserAuthens(saveTable.UserToken))
                {
                    if (saveTable.DT != null)
                    {
                        string Ssql = "";
                        foreach (DataRow dataRow in saveTable.DT.Rows)
                        {
                            if (dataRow["id"] != null)
                            {
                                if (dataRow["id"].ToString() != "")
                                {
                                    Ssql += $"update {saveTable.TableName} set ";
                                    string setValue = "";
                                    for (int ss = 1; ss < saveTable.DT.Columns.Count; ss++)
                                    {
                                        if(dataRow[ss]!=DBNull.Value&& dataRow[ss].ToString()!="")
                                        {
                                            setValue += saveTable.DT.Columns[ss].ColumnName + "=N'" + dataRow[ss] + "',";
                                        }
                                        else
                                        {
                                            setValue += saveTable.DT.Columns[ss].ColumnName + "=null,";
                                        }

                                        
                                    }
                                    Ssql += setValue.Substring(0, setValue.Length - 1);
                                    Ssql += $" where id={dataRow["id"]};\r\n";
                                    //b += SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                }
                                else
                                {
                                    Ssql +="insert into " + saveTable.TableName;
                                    string Cname = string.Empty;
                                    string CValue = string.Empty;
                                    for (int ss = 1; ss < saveTable.DT.Columns.Count; ss++)
                                    {
                                        Cname += saveTable.DT.Columns[ss].ColumnName + ",";
                                        if (dataRow[ss] != DBNull.Value && dataRow[ss].ToString() != "")
                                        {
                                            CValue += "N'" + dataRow[ss] + "',";
                                        }
                                        else
                                        {
                                            CValue += "null,";
                                        }
                                    }
                                    Cname = "(" + Cname.Substring(0, Cname.Length - 1) + ")";
                                    CValue = "(" + CValue.Substring(0, CValue.Length - 1) + ")";

                                    Ssql += Cname + " values " + CValue+ ";\r\n";
                                    //b += SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                                }
                            }
                            else
                            {
                                Ssql += "insert into " + saveTable.TableName;
                                string Cname = string.Empty;
                                string CValue = string.Empty;
                                for (int ss = 1; ss < saveTable.DT.Columns.Count; ss++)
                                {
                                    Cname += saveTable.DT.Columns[ss].ColumnName + ",";
                                    CValue += "N'" + dataRow[ss] + "',";
                                }
                                Cname = "(" + Cname.Substring(0, Cname.Length - 1) + ")";
                                CValue = "(" + CValue.Substring(0, CValue.Length - 1) + ")";
                                Ssql += Cname + " values " + CValue+";\r\n";
                                
                            }
                        }
                        b += SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);

                    }
                }
                if (b != 0)
                    a = true;
                return a;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public static bool SaveTablesH(string userName, string userToken, string TableName, DataTable data)
        {
            try
            {
                bool a = false;
                int b = 0;
                if (SysLoadInfo.UserAuthens(userToken))
                {

                    foreach (DataRow dataRow in data.Rows)
                    {
                        if (dataRow["id"] != null)
                        {
                            if (dataRow["id"].ToString() != "")
                            {
                                string sqqq = $"update {TableName} set ";
                                string setValue = "";
                                for (int ss = 1; ss < data.Columns.Count; ss++)
                                {
                                    setValue += data.Columns[ss].ColumnName + "=N'" + dataRow[ss] + "',";
                                }
                                sqqq += setValue.Substring(0, setValue.Length - 1);
                                sqqq += $" where id={dataRow["id"]}";
                                b += SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, sqqq);
                            }
                            else
                            {
                                string Ssql = "insert into " + TableName;
                                string Cname = string.Empty;
                                string CValue = string.Empty;
                                for (int ss = 1; ss < data.Columns.Count; ss++)
                                {
                                    Cname += data.Columns[ss].ColumnName + ",";
                                    CValue += "N'" + dataRow[ss] + "',";
                                }
                                Cname = "(" + Cname.Substring(0, Cname.Length - 1) + ")";
                                CValue = "(" + CValue.Substring(0, CValue.Length - 1) + ")";

                                Ssql += Cname + " values " + CValue;
                                b += SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                            }
                        }
                        else
                        {
                            string Ssql = "insert into " + TableName;
                            string Cname = string.Empty;
                            string CValue = string.Empty;
                            for (int ss = 1; ss < data.Columns.Count; ss++)
                            {
                                Cname += data.Columns[ss].ColumnName + ",";
                                CValue += "N'" + dataRow[ss] + "',";
                            }
                            Cname = "(" + Cname.Substring(0, Cname.Length - 1) + ")";
                            CValue = "(" + CValue.Substring(0, CValue.Length - 1) + ")";

                            Ssql += Cname + " values " + CValue;
                            b += SqlHelper.ExecuteNonQuery(CommonData.sqlconnH, CommandType.Text, Ssql);
                        }
                    }


                }
                if (b != 0)
                    a = true;
                return a;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion
    }
}
