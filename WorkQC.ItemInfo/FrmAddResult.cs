using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.QCModel;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmAddResult : XtraForm
    {
        string itemNO = "";
        string QCAddResult = "";        
        public FrmAddResult(string planid, string planItemID, string itemNOs)
        {


            QCAddResult = ConfigInfos.ReadConfigInfo("QCAddResult");
            itemNO = itemNOs;
            InitializeComponent();
            if (planid != "")
                GEQCPlan.EditValue = planid;
            if (planItemID != "")
                GEQCItem.EditValue = planItemID;
            DEQCTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void FrmAddResult_Load(object sender, EventArgs e)
        {
            GridLookUpEdites.Formats(GEQCPlan, QCInfoData.DTQCPlan);
            GridLookUpEdites.Formats(RGElevelNO, QCInfoData.DTQCLevel);
            GEQCItem.Properties.DisplayMember = "itemName";
            GEQCItem.Properties.ValueMember = "id";
            GEQCItem.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            GEQCItem.Properties.View.BestFitColumns();
            GEQCGrade.Properties.DisplayMember = "gradeName";
            GEQCGrade.Properties.ValueMember = "id";
            GEQCGrade.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            GEQCGrade.Properties.View.BestFitColumns();
            TextEdits.TextFormat(TEQCSort);
            GEQCItem.Properties.NullText = "";
            GEQCGrade.Properties.NullText = "";
            RGElevelNOs.DataSource = QCInfoData.DTQCLevel;
            RGElevelNOs.ValueMember = "no";
            RGElevelNOs.DisplayMember = "names";


        }
        private void BTOK_Click(object sender, EventArgs e)
        {
            if (GEQCGrade.EditValue != null && GEQCGrade.EditValue.ToString() != "")
            {
                if (TEResult.EditValue != null && TEResult.EditValue.ToString() != "")
                {
                    if (DEQCTime.EditValue != null && DEQCTime.EditValue.ToString() != "")
                    {
                        if (TEQCSort.EditValue != null && TEQCSort.EditValue.ToString() != "")
                        {


                            commInfoModel<QCAddModel> qCInfo = new commInfoModel<QCAddModel>();
                            qCInfo.UserName = CommonData.UserInfo.names;
                            
                            List<QCAddModel> listResult = new List<QCAddModel>();
                            QCAddModel qCAddModel = new QCAddModel();
                            qCAddModel.planid = GEQCPlan.EditValue != null ? GEQCPlan.EditValue.ToString() : "";
                            qCAddModel.planItemid = GEQCItem.EditValue != null ? GEQCItem.EditValue.ToString() : "";
                            qCAddModel.planGradeid = GEQCGrade.EditValue != null ? GEQCGrade.EditValue.ToString() : "";
                            qCAddModel.itemNO = itemNO;
                            qCAddModel.itemResult = TEResult.EditValue != null ? TEResult.EditValue.ToString() : "";
                            qCAddModel.remark = TERemark.EditValue != null ? TERemark.EditValue.ToString() : "";
                            qCAddModel.qcTime = DEQCTime.EditValue != null ? DEQCTime.EditValue.ToString() : "";
                            qCAddModel.sort = TEQCSort.EditValue != null ? Convert.ToInt32(TEQCSort.EditValue) : 0;
                            listResult.Add(qCAddModel);
                            qCInfo.infos = listResult;
                            string Sr = JsonHelper.SerializeObjct(qCInfo);

                            WebApiCallBack jm = ApiHelpers.postInfo(QCAddResult, Sr);
                            commReInfo<commReItemInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReItemInfo>>(jm);
                            if (commReInfo.code == 1)
                            {
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }




                            //iInfo iInfo = new iInfo();
                            //iInfo.TableName = "QC.QCItemResult";
                            //Dictionary<string, object> pairs = new Dictionary<string, object>();
                            //pairs.Add("planid", GEQCPlan.EditValue);
                            //pairs.Add("planItemid", GEQCItem.EditValue);
                            //pairs.Add("planGradeid", GEQCGrade.EditValue);
                            //pairs.Add("itemNO", itemNO);
                            //pairs.Add("itemResult", TEResult.EditValue);
                            ////pairs.Add("resultState", 0);
                            //pairs.Add("remark", TERemark.EditValue);
                            //pairs.Add("sort", TEQCSort.EditValue);
                            //pairs.Add("qcTime", DEQCTime.EditValue);
                            //pairs.Add("creater", CommonData.UserInfo.names);
                            //pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            //pairs.Add("state", 1);
                            //pairs.Add("dstate", 0);
                            //iInfo.values = pairs;
                            //int a = ApiHelpers.postInfo(iInfo);
                            //if(a==1)
                            //{
                            //    this.Close();
                            //}
                        }
                        else
                        {
                            MessageBox.Show("请填写质控次数", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("质控日期", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("选择质控结果", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("选择质控品信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
