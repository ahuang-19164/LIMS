using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace WorkQC.ItemInfo
{
    public partial class FrmPlanInfo : DevExpress.XtraEditors.XtraForm
    {


        int FrmState = 0;
        string TableName = "QC.QCPlan";
        DataRow DRInfo = null;
        /// <summary>
        /// no=0编辑，其他为新增
        /// </summary>
        /// <param name="state"></param>
        /// <param name="NO"></param>
        public FrmPlanInfo(int no, DataRow DRPlan)
        {
            InitializeComponent();
            GridLookUpEdites.Formats(GEgroupNO);
            GridLookUpEdites.Formats(GEWorkNO);
            GridLookUpEdites.Formats(GEInstrumentNO);
            GridLookUpEdites.Formats(GEruleNO);
            TextEdits.TextFormat(TEsort);

            GEWorkNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupWork);



            //GEgroupNO.Properties.DataSource =DTHelper.DTEnable(WorkCommData.DTGroupTest);
            GEInstrumentNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTInstrumentInfo);
            sInfo sInfo = new sInfo();
            sInfo.TableName = "QC.RuleGroup";
            GEruleNO.Properties.DataSource = DTHelper.DTEnable(ApiHelpers.postInfo(sInfo));


            FrmState = no;
            DRInfo = DRPlan;
            if (no != 0)
            {

                CEstate.Checked = false;
                TEno.EditValue = no;
                TEsort.EditValue = 999;
                TEcustomCode.EditValue = "";
                TEnames.EditValue = "";
                TEremark.EditValue = "";
                TEshortNames.EditValue = "";
                GEWorkNO.EditValue = "";
                GEgroupNO.EditValue = "";
                GEInstrumentNO.EditValue = "";
                GEruleNO.EditValue = "";
                DEstartTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
                DEendTime.EditValue = "2099-01-01";

            }
            else
            {
                if (DRPlan != null)
                {
                    CEstate.Checked = DRPlan["state"] == DBNull.Value ? false : Convert.ToBoolean(DRPlan["state"]);
                    DEendTime.EditValue = DRPlan["endTime"];
                    DEstartTime.EditValue = DRPlan["startTime"];
                    TEno.EditValue = DRPlan["no"];
                    TEsort.EditValue = DRPlan["sort"];
                    TEcustomCode.EditValue = DRPlan["customCode"];
                    GEWorkNO.EditValue = DRPlan["workNO"];
                    GEgroupNO.EditValue = DRPlan["groupNO"];
                    GEInstrumentNO.EditValue = DRPlan["InstrumentNO"];
                    TEnames.EditValue = DRPlan["names"];
                    TEremark.EditValue = DRPlan["remark"];
                    GEruleNO.EditValue = DRPlan["ruleNO"];
                    TEshortNames.EditValue = DRPlan["shortNames"];
                }
            }
        }
        private void FrmPlanInfo_Load(object sender, EventArgs e)
        {

        }
        private void BTSave_Click(object sender, EventArgs e)
        {
            if (FrmState != 0)
            {
                iInfo iInfo = new iInfo();
                iInfo.TableName = TableName;
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("dstate", 0);
                pairs.Add("state", CEstate.Checked);
                pairs.Add("endTime", DEendTime.EditValue);
                pairs.Add("startTime", DEstartTime.EditValue);
                pairs.Add("no", TEno.EditValue);
                pairs.Add("sort", TEsort.EditValue);
                pairs.Add("customCode", TEcustomCode.EditValue);
                pairs.Add("workNO", GEWorkNO.EditValue);
                pairs.Add("groupNO", GEgroupNO.EditValue);
                pairs.Add("InstrumentNO", GEInstrumentNO.EditValue);
                pairs.Add("names", TEnames.EditValue);
                pairs.Add("remark", TEremark.EditValue);
                pairs.Add("ruleNO", GEruleNO.EditValue);
                pairs.Add("shortNames", TEshortNames.EditValue);
                pairs.Add("creater", CommonData.UserInfo.names);
                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                iInfo.values = pairs;
                int a = ApiHelpers.postInfo(iInfo);

                if (a == 1)
                {
                    this.Close();
                }

            }
            else
            {
                uInfo uInfo = new uInfo();
                uInfo.TableName = TableName;

                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("dstate", 0);
                pairs.Add("state", CEstate.Checked);
                pairs.Add("endTime", DEendTime.EditValue);
                pairs.Add("startTime", DEstartTime.EditValue);
                pairs.Add("no", TEno.EditValue);
                pairs.Add("sort", TEsort.EditValue);
                pairs.Add("customCode", TEcustomCode.EditValue);
                pairs.Add("workNO", GEWorkNO.EditValue);
                pairs.Add("groupNO", GEgroupNO.EditValue);
                pairs.Add("InstrumentNO", GEInstrumentNO.EditValue);
                pairs.Add("names", TEnames.EditValue);
                pairs.Add("remark", TEremark.EditValue);
                pairs.Add("ruleNO", GEruleNO.EditValue);
                pairs.Add("shortNames", TEshortNames.EditValue);
                pairs.Add("creater", CommonData.UserInfo.names);
                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                uInfo.values = pairs;
                uInfo.DataValueID = Convert.ToInt32(DRInfo["id"]);
                int a = ApiHelpers.postInfo(uInfo);
                if (a == 1)
                {
                    this.Close();
                }
            }
        }


        private void BTClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEgroupNO_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void GEWorkNO_EditValueChanged(object sender, EventArgs e)
        {
            if (GEWorkNO.EditValue != null && GEWorkNO.EditValue.ToString() != "")
            {
                GEgroupNO.EditValue = "";
                GEgroupNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest.Select($"workNO='{GEWorkNO.EditValue}'").CopyToDataTable());
            }
            else
            {
                GEgroupNO.EditValue = "";
                GEgroupNO.Properties.DataSource = null;
            }
        }
    }
}
