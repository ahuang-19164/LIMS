using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.QCModel
{
    public class QCrecordModel
    {
        /// <summary>
        /// 质控编号
        /// </summary>
        public string QCCode { get; set; }
        /// <summary>
        /// 质控水平
        /// </summary>
        public string QCLevel { get; set; }
        /// <summary>
        /// 质控项目
        /// </summary>
        public string QCItem { get; set; }
        /// <summary>
        /// 质控专业组
        /// </summary>
        public string QCGroupNO { get; set; }
        /// <summary>
        /// 质控次数
        /// </summary>
        public string QCnumber { get; set; }

    }
}
