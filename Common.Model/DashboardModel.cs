using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class piesjsonsrouce
    {
        public object piesdata { get; set; }
        public object ResponseStatus { get; set; }
    }
    public class cardjsonsrouce
    {
        public object carddata { get; set; }
        public object ResponseStatus { get; set; }
    }
    public class chartjsonsrouce
    {
        public object chartdata { get; set; }
        public object ResponseStatus { get; set; }
    }


    /// <summary>
    /// 首页展示信息对象
    /// </summary>
    public class DashboardModel
    {
        public viewSrouce cardView { get; set; }
        public viewSrouce piesView { get; set; }
        public viewSrouce chartView { get; set; }
        public viewSrouce otherView { get; set; }
    }

    public class viewSrouce
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 对应值
        /// </summary>
        public List<viewData> data { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
    public class viewData
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// 对应值
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
    }
}
