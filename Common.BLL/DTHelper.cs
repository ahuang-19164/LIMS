using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Common.BLL
{
    public class DTHelper
    {


        /// <summary>
        /// 启用的数据信心("state=1 and dstate=0")
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        public static DataTable DTEnable(DataTable DT)
        {
            if (DT != null)
            {
                if (DT.Select("state=1 and dstate=0").Count() > 0)
                {
                    DataTable dataTable = DT.Select("state=1 and dstate=0").CopyToDataTable();
                    return dataTable;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 显示的数据信息("dstate=0")
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        public static DataTable DTVisible(DataTable DT)
        {
            if (DT != null)
            {
                if (DT.Select("dstate=0").Count() > 0)
                {
                    return DT.Select("dstate=0").CopyToDataTable();
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Datatable添加全部选项
        /// </summary>
        /// <param name="DT"></param>
        /// <returns></returns>
        public static List<sourceInfo> DTAddAll(DataTable DT)
        {
            List<sourceInfo> sourceInfos = new List<sourceInfo>();
            sourceInfo sourceInfoAll = new sourceInfo();
            sourceInfoAll.no = 0;
            sourceInfoAll.names = "全部";
            sourceInfoAll.shortNames = "QB";
            sourceInfoAll.customCode = "All";
            sourceInfos.Add(sourceInfoAll);
            if (DT != null)
            {
                foreach (DataRow row in DT.Rows)
                {
                    sourceInfo sourceInfoItem = new sourceInfo();
                    sourceInfoItem.no = row["no"];
                    sourceInfoItem.names = row["names"];
                    sourceInfoItem.shortNames = row["shortNames"];
                    sourceInfoItem.customCode = row["customCode"];
                    sourceInfos.Add(sourceInfoItem);
                }
            }
            return sourceInfos;
        }
        public class sourceInfo
        {
            public object no { get; set; }
            public object names { get; set; }
            public object shortNames { get; set; }
            public object customCode { get; set; }
        }


    }
}
