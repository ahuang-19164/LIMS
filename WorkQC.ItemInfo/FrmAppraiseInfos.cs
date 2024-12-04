using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmAppraiseInfos : XtraForm
    {
#pragma warning disable CS0414 // 字段“FrmAppraiseInfos.itemNO”已被赋值，但从未使用过它的值
        string itemNO = "";
#pragma warning restore CS0414 // 字段“FrmAppraiseInfos.itemNO”已被赋值，但从未使用过它的值
#pragma warning disable CS0414 // 字段“FrmAppraiseInfos.QCAddResult”已被赋值，但从未使用过它的值
        string QCAddResult = "";
#pragma warning restore CS0414 // 字段“FrmAppraiseInfos.QCAddResult”已被赋值，但从未使用过它的值
        public FrmAppraiseInfos(string planid, string planItemID, string itemNOs, object startTime, object endTime)
        {


            //QCAddResult = ConfigInfos.ReadConfigInfo("QCAddResult");
            //itemNO = itemNOs;
            InitializeComponent();





            DEStartTime.EditValue = startTime;
            DEEndTime.EditValue = endTime;
            if (planid != "")
                GEQCPlan.EditValue = planid;
            if (planItemID != "")
                GEQCItem.EditValue = planItemID;

        }
        private void FrmAddResult_Load(object sender, EventArgs e)
        {
            GridLookUpEdites.Formats(GEQCPlan, QCInfoData.DTQCPlan);
            GridLookUpEdites.Formats(RGElevelNOs, QCInfoData.DTQCLevel);
            GEQCItem.Properties.DisplayMember = "itemName";
            GEQCItem.Properties.ValueMember = "id";
            GEQCItem.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            GEQCItem.Properties.View.BestFitColumns();
            GEQCGrade.Properties.DisplayMember = "gradeName";
            GEQCGrade.Properties.ValueMember = "id";
            GEQCGrade.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            GEQCGrade.Properties.View.BestFitColumns();
            GEQCItem.Properties.NullText = "";
            GEQCGrade.Properties.NullText = "";
        }
        private void BTOK_Click(object sender, EventArgs e)
        {
            if (TEappraise.EditValue != null && TEappraise.EditValue.ToString().Length > 4)
            {
                iInfo iInfo = new iInfo();
                iInfo.TableName = "QC.AppraiseRecord";
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                iInfo.values = pairs;
                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                pairs.Add("qcEndTime", DEEndTime.EditValue);
                pairs.Add("qcStartTime", DEStartTime.EditValue);
                pairs.Add("planGradeid", GEQCGrade.EditValue);
                pairs.Add("planGradeName", GEQCGrade.Text);
                pairs.Add("planid", GEQCPlan.EditValue);
                pairs.Add("planItemid", GEQCItem.EditValue);
                pairs.Add("planItemName", GEQCItem.Text);
                pairs.Add("planName", GEQCPlan.Text);
                pairs.Add("creater", CommonData.UserInfo.names);
                pairs.Add("appraise", TEappraise.EditValue);
                pairs.Add("remark", TERemark.EditValue);
                iInfo.values = pairs;
                int a = ApiHelpers.postInfo(iInfo);

            }
            else
            {
                MessageBox.Show("请填写评价内容(不少于4个字)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void BTClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GEQCPlan_EditValueChanged(object sender, EventArgs e)
        {
            if (GEQCPlan.EditValue != null)
            {
                if (GEQCPlan.EditValue.ToString() != "")
                {
                    sInfo sInfo = new sInfo();
                    sInfo.TableName = "QC.QCPlanItem";
                    sInfo.wheres = $"planid='{GEQCPlan.EditValue}' and dstate=0 and state=1";
                    sInfo.OrderColumns = "sort";
                    GEQCItem.Properties.DataSource = ApiHelpers.postInfo(sInfo);
                }
                else
                {
                    GEQCItem.Properties.DataSource = null;
                }
            }
            else
            {
                GEQCItem.Properties.DataSource = null;
            }
        }

        private void GEQCItem_EditValueChanged(object sender, EventArgs e)
        {
            if (GEQCItem.EditValue != null)
            {
                if (GEQCItem.EditValue.ToString() != "")
                {
                    sInfo sInfo = new sInfo();
                    sInfo.TableName = "QC.QCPlanGrade";
                    sInfo.wheres = $"planItemid='{GEQCItem.EditValue}' and dstate=0 and state=1";
                    sInfo.OrderColumns = "sort";
                    GEQCGrade.Properties.DataSource = ApiHelpers.postInfo(sInfo);
                }
                else
                {
                    GEQCGrade.Properties.DataSource = null;
                }
            }
            else
            {
                GEQCGrade.Properties.DataSource = null;
            }
        }
    }
}
