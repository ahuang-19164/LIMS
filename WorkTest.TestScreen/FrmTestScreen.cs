using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using Common.TestModel.Result;
using System;
using System.Data;
using System.Windows.Forms;



namespace WorkTest.TestScreen
{
    public partial class FrmTestScreen : DevExpress.XtraEditors.XtraForm
    {
        string SetResultScreen = "";
        public FrmTestScreen()
        {
            InitializeComponent();
            //CommonData.configInfos.TryGetValue("SetResultScreen", out string ResultScreen);
            SetResultScreen = ConfigInfos.ReadConfigInfo("SetResultScreen");
        }

        private void FrmTestScreen_Load(object sender, EventArgs e)
        {
            MemoEdits.AddDoubleMethod(MEDiagnosis);
            MemoEdits.AddDoubleMethod(MEDiagnosisRemark);

            //MEDiagnosis.DoubleClick += MEDiagnosis_DoubleClick; ;
            //MEDiagnosisRemark.DoubleClick += MEDiagnosis_DoubleClick;
        }

        //private void MEDiagnosis_DoubleClick(object sender, EventArgs e)
        //{
        //    MemoEdit memoEdit = sender as MemoEdit;
        //    FrmShowDictionary frmShowDictionary = new FrmShowDictionary(memoEdit.Tag.ToString());
        //    Func<string> func = frmShowDictionary.ReturnResult;
        //    frmShowDictionary.ShowDialog();
        //    memoEdit.EditValue = func();
        //}
        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {

            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkTest.ResultScreen";
            selectInfo.wheres = $"testid='{testid}' and state=1";
            selectInfo.OrderColumns = "createTime desc";
            DataTable DTResult = ApiHelpers.postInfo(selectInfo);
            if (DTResult != null)
            {

                MEDiagnosis.EditValue = DTResult.Rows[0]["diagnosis"] != DBNull.Value ? DTResult.Rows[0]["diagnosis"] : "";
                MEDiagnosisRemark.EditValue = DTResult.Rows[0]["diagnosisRemark"] != DBNull.Value ? DTResult.Rows[0]["diagnosisRemark"] : "";
            }
            else
            {
                MEDiagnosis.EditValue = "";
                MEDiagnosisRemark.EditValue = "";
            }

            //MessageBox.Show("是否确定删除此照片？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }



        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="ResultState">结果结果状态 1.检验者 2.复初审者 3.审核者</param>
        /// <returns></returns>
        public string postResultInfo(int ResultState,int perid, int testid,string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        {

            if (testid != 0 && barcode != "")
            {


                //CommResultModel<ScreenInfoModel> resultScreenInfo = new CommResultModel<ScreenInfoModel>();
                CommResultModel<ScreenInfoModel> resultScreenInfo = new CommResultModel<ScreenInfoModel>();
                resultScreenInfo.UserName = CommonData.UserInfo.names;
                
                if (info != null)
                {
                    resultScreenInfo.AutographInfo = info;
                }
                ScreenInfoModel resultScreen = new ScreenInfoModel();
                //ScreenInfoModel resultScreen = new ScreenInfoModel();


                resultScreenInfo.ResultState = ResultState;
                resultScreen.State = true;
                resultScreen.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //resultScreen.pathologyNo = PNO;
                resultScreen.Barcode = barcode;
                resultScreen.PictureCode = barcode;
                resultScreen.groupNO = groupNO;

                resultScreen.perid = perid;
                resultScreen.testid = testid;resultScreen.sampleID = sampleid;
                if (MEDiagnosis.EditValue != null)
                    resultScreen.diagnosis = MEDiagnosis.EditValue.ToString();
                if (MEDiagnosisRemark.EditValue != null)
                    resultScreen.diagnosisRemark = MEDiagnosisRemark.EditValue.ToString();
                resultScreenInfo.Result = resultScreen;
                string s = JsonHelper.SerializeObjct(resultScreenInfo);
                WebApiCallBack jm = ApiHelpers.postInfo(SetResultScreen, s);
                return jm.data.ToString();
            }
            else
            {
                return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息。\"}";
                //MessageBox.Show("请选择需要保存信息的标本信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
