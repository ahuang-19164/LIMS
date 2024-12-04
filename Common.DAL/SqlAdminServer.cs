using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Common.DAL
{
    public class SqlAdminServer
    {
        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>
        public static int ExecuteSqlTran(List<String> SQLStringList)
        {
            string connstring = "Server=124.115.219.162,8500;DataBase=HLMISDB;Uid=sa;Pwd=abc123,";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    int count = 0;
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n];
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            count += cmd.ExecuteNonQuery();

                        }
                    }
                    tx.Commit();
                    return count;
                }
#pragma warning disable CS0168 // 声明了变量“err”，但从未使用过
                catch (Exception err)
#pragma warning restore CS0168 // 声明了变量“err”，但从未使用过
                {
                    tx.Rollback();
                    return 0;
                }
            }

        }



    }
}
