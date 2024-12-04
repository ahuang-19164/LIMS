using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Common.ResultInfo
{
    class ResultInfos
    {
        /// <summary>
        /// 返回状态0成功1失败
        /// </summary>
        public int Code { get; set; }
        public string Msg { get; set; }
        public DataTable Datas { get; set; } 
    }
}
