using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportTool.Model
{
    public class commInfoModel<T>
    {

        public int code { get; set; } = 0;

        public T info{get;set;}
        public string msg { get; set; }
    }
}
