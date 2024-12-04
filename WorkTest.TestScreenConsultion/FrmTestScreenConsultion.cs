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



namespace WorkTest.TestScreenConsultion
{
    public partial class FrmTestScreenConsultion : DevExpress.XtraEditors.XtraForm
    {
        string SetResultConsultation = "";
        public FrmTestScreenConsultion()
        {
            InitializeComponent();
            //CommonData.configInfos.TryGetValue("SetResultConsultation", out string ResultConsultation);
            SetResultConsultation = ConfigInfos.ReadConfigInfo("SetResultConsultation");
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
            selectInfo.TableName = "WorkTest.ResultConsultation";
            selectInfo.wheres = $"testid='{testid}' and dstate=0";
            selectInfo.OrderColumns = "createTime desc";
            DataTable DTResult = ApiHelpers.postInfo(selectInfo);
            if (DTResult != null)
            {

                MEprimaryDiagnosis.EditValue = DTResult.Rows[0]["primaryDiagnosis"] != DBNull.Value ? DTResult.Rows[0]["primaryDiagnosis"] : "";
                MEDiagnosis.EditValue = DTResult.Rows[0]["diagnosis"] != DBNull.Value ? DTResult.Rows[0]["diagnosis"] : "";
                MEDiagnosisRemark.EditValue = DTResult.Rows[0]["diagnosisRemark"] != DBNull.Value ? DTResult.Rows[0]["diagnosisRemark"] : "";
                //MEpathologicDiagnosis.EditValue = ResultTask.Result.Rows[0]["diagnosis"] != DBNull.Value ? ResultTask.Result.Rows[0]["diagnosis"] : "";
            }
            else
            {
                MEprimaryDiagnosis.EditValue = "";
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
                CommResultModel<PathnologyInfoModel> pathnologyInfo = new CommResultModel<PathnologyInfoModel>();
                pathnologyInfo.UserName = CommonData.UserInfo.names;
                
                if (info != null)
                {
                    pathnologyInfo.AutographInfo = info;
                }
                PathnologyInfoModel pathnology = new PathnologyInfoModel();


                pathnologyInfo.ResultState = ResultState;
                pathnology.State = true;
                pathnology.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //pathnology.PathologyNo = PNO;
                pathnology.Barcode = barcode;
                pathnology.PictureCode = barcode;
                pathnology.groupNO = groupNO;
                pathnology.perid = perid;
                pathnology.testid = testid; pathnology.sampleID = sampleid;
                if (MEprimaryDiagnosis.EditValue != null)
                    pathnology.primaryDiagnosis = MEprimaryDiagnosis.EditValue.ToString();
                if (MEDiagnosis.EditValue != null)
                    pathnology.pathologicDiagnosis = MEDiagnosis.EditValue.ToString();
                if (MEDiagnosisRemark.EditValue != null)
                    pathnology.diagnosisRemark = MEDiagnosisRemark.EditValue.ToString();
                pathnologyInfo.Result = pathnology;
                string s = JsonHelper.SerializeObjct(pathnologyInfo);
                WebApiCallBack jm = ApiHelpers.postInfo(SetResultConsultation, s);
                return jm.data.ToString();
            }
            else
            {
                return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息。\"}";

            }
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
