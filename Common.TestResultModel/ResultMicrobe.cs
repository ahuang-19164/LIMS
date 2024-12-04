using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.TestResultModel
{
    //public class ResultaaaMicrobeInfo
    //{
    //    /// <summary>
    //    /// 申请ID
    //    /// </summary>
    //    public int perid { get; set; } = 0;
    //    /// <summary>
    //    /// 样本ID
    //    /// </summary>
    //    public int testid { get; set; }=0;
    //    /// <summary>
    //    /// 专业组编号
    //    /// </summary>
    //    public string groupNO { get; set; }
    //    /// <summary>
    //    /// 条码号
    //    /// </summary>
    //    public string barcode { get; set; }
    //    /// <summary>
    //    /// 检验状态
    //    /// </summary>
    //    public bool testState { get; set; }
    //    /// <summary>
    //    /// 结果集合
    //    /// </summary>
    //    public List<ResultMicrobe> listResult { get; set; }
    //}
    public class ResultMicrobe
    {
        public bool delstate { get; set; }
        public bool reportState { get; set; }
        public bool resultNullState { get; set; }
        public bool state { get; set; }
        public int id { get; set; } = 0;
        public int itemSort { get; set; }
        public string barcode { get; set; }
        public string delstateClientNO { get; set; }
        public string diagnosis { get; set; }
        public string diagnosisRemark { get; set; }
        public string groupCode { get; set; }
        public string groupName { get; set; }
        public string groupNO { get; set; }
        public string itemCodes { get; set; }
        public string itemNames { get; set; }
        public string itemRemark { get; set; }
        public string itemResult { get; set; }
        public string channel { get; set; }
        public int perid { get; set; }
        public string resultType { get; set; }
        public int testid { get; set; }=0;
        public List<ResultAntibiotic> AntibioticInfos { get; set; }
    }
    public class ResultAntibiotic
    {
        public bool dstate { get; set; }
        public bool state { get; set; }
        public int id { get; set; }
        public string antibioticEN { get; set; }
        public string antibioticNames { get; set; }
        public string antibioticNo { get; set; }
        public string aqualitative { get; set; }
        public string barcode { get; set; }
        public string groupNO { get; set; }
        public string itemCodes { get; set; }
        public string itemNames { get; set; }
        public string itemResult { get; set; }
        public int itemSort { get; set; }
        public string kbValue { get; set; }
        public string methodName { get; set; }
        public string micValue { get; set; }
        public int perid { get; set; }
        public string remark { get; set; }
        public int testid { get; set; }=0;
        public string channel { get; set; }
    }
}
