namespace Common.SqlEffect
{
    public class SysLoadInfo
    {
        public static bool UserAuthens(string UserToken)
        {
            //UserState = "aaaaa";
            return true;
        }
        /// <summary>
        /// 正式可用
        /// </summary>
        /// <param name="UserToken"></param>
        /// <returns></returns>
        //public  static bool UserAuthens(string UserToken)
        //{
        //    DataTable dataTable = LoadAuthen(UserToken);
        //    if (dataTable.Rows.Count==1)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public static DataTable LoadAuthen(string UserToken)
        //{
        //    DataTable dt = null;

        //        if (UserToken!= null)
        //        {
        //            string Ssql = $"select Top 1 * from Common.UserLoadInfo where CreateTime>'{DateTime.Now.ToString("yyyy-MM-dd")}' and Token='{filterValue(UserToken)}'";
        //            dt = SqlHelper.ExecuteDataset(SysAdminServer.sqlconnH, CommandType.Text, Ssql).Tables[0];
        //            //dt = SqlHelper.r(sqlconn, CommandType.Text, Ssql).Tables[0];
        //            if (dt.Rows.Count== 1)
        //            {
        //                return dt;
        //            }
        //        }
        //    return dt;
        //}
        /// <summary>
        /// 参数过滤器
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static string filterValue(string a)
        {

            string s = "";
            if (a == null)
            {
                return s;
            }
            else
            {
                s = a.ToString().ToLower();
                if (s.Contains("select"))
                {
                    a = "Eorr";
                }
                else
                {
                    if (s.Contains("update"))
                    {
                        a = "Eorr";
                    }
                    else
                    {
                        if (s.Contains("detele"))
                        {
                            a = "Eorr";

                        }

                    }
                }
                return a.ToString();
            }

        }

    }
}
