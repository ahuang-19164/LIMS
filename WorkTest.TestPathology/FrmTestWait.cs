using Common.TestModel.Result;
using DevExpress.XtraEditors;
using System.Data;


namespace WorkTest.TestPathology
{
    public partial class FrmTestWait : XtraForm
    {
        public FrmTestWait()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="Barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {

        }




        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="ResultState">结果结果状态 1.检验者 2.复初审者 3.审核者</param>
        /// <returns></returns>
        public string postResultInfo(int ResultState,int perid, int testid,string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        {
            return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请到切片包埋模块中进行操作。\"}";
            //return "请到切片包埋模块中进行操作";
        }
    }
}
