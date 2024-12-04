using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmQCHandleInfo : XtraForm
    {
#pragma warning disable CS0414 // 字段“FrmQCHandleInfo.itemNO”已被赋值，但从未使用过它的值
        string itemNO = "";
#pragma warning restore CS0414 // 字段“FrmQCHandleInfo.itemNO”已被赋值，但从未使用过它的值
        string QCAddResult = "";
        DataRow DRQCResults;

        DataTable DTGradeInfo;
        public FrmQCHandleInfo(DataRow DRQCResult)
        {
            QCAddResult = ConfigInfos.ReadConfigInfo("QCAddResult");
            InitializeComponent();
            DRQCResults = DRQCResult;




        }
        private void FrmAddResult_Load(object sender, EventArgs e)
        {


            GridLookUpEdites.Formats(GEQCPlan, QCInfoData.DTQCPlan);
            GridLookUpEdites.Formats(RGElevelNOs, QCInfoData.DTQCLevel);
            GridLookUpEdites.Formats(GELevelNO, QCInfoData.DTQCLevel);

            GEQCItem.Properties.DisplayMember = "itemName";
            GEQCItem.Properties.ValueMember = "id";
            GEQCItem.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            GEQCItem.Properties.View.BestFitColumns();
            //TEQCGrade.Properties.DisplayMember = "gradeName";
            //TEQCGrade.Properties.ValueMember = "id";
            //TEQCGrade.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //TEQCGrade.Properties.View.BestFitColumns();
            TextEdits.TextFormat(TEQCSort);
            GEQCItem.Properties.NullText = "";
            TEQCGrade.Properties.NullText = "";


            if (DRQCResults != null)
            {

                string aaaa = DRQCResults["planid"] != DBNull.Value ? DRQCResults["planid"].ToString() : "";
                GEQCPlan.EditValue = aaaa;
                //GEQCPlan.EditValue = DRQCResults["planid"] != DBNull.Value ? DRQCResults["planid"].ToString() : "";
                GEQCItem.EditValue = DRQCResults["planItemid"] != DBNull.Value ? DRQCResults["planItemid"].ToString() : "";



                //GEQCGrade.EditValue = DRQCResults["planGradeid"] != DBNull.Value ? DRQCResults["planGradeid"].ToString() : "";


                string Gredeid = DRQCResults["planGradeid"] != DBNull.Value ? DRQCResults["planGradeid"].ToString() : "";
                if (Gredeid != "")
                {
                    DataRow[] DRgradeInfos = DTGradeInfo.Select($"id='{Gredeid}'");
                    if (DRgradeInfos.Count() > 0)
                    {
                        TEQCGrade.EditValue = DRgradeInfos[0]["gradeCode"];
                        GELevelNO.EditValue = DRgradeInfos[0]["levelNO"];
                    }
                }

                TEResult.EditValue = DRQCResults["itemResult"];
                TEResultType.EditValue = DRQCResults["resultType"];
                TEresultRule.EditValue = DRQCResults["resultRule"];
                DEQCTime.EditValue = DRQCResults["qcTime"];
                TEQCSort.EditValue = DRQCResults["sort"];
            }
        }
        private void BTOK_Click(object sender, EventArgs e)
        {
            if (TEQCGrade.EditValue != null && TEQCGrade.EditValue.ToString() != "")
            {
                if (TEResult.EditValue != null && TEResult.EditValue.ToString() != "")
                {
                    if (DEQCTime.EditValue != null && DEQCTime.EditValue.ToString() != "")
                    {
                        if (TEQCSort.EditValue != null && TEQCSort.EditValue.ToString() != "")
                        {

                            iInfo iInfo = new iInfo();
                            iInfo.TableName = "QC.HandleRecord";

                            Dictionary<string, object> pairs = new Dictionary<string, object>();

                            pairs.Add("handler", CommonData.UserInfo.names);
                            pairs.Add("handleRecord", TEReason.EditValue);
                            pairs.Add("handleTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            pairs.Add("itemNO", DRQCResults["itemNO"]);
                            pairs.Add("levelName", GELevelNO.Text);
                            pairs.Add("levelNO", GELevelNO.EditValue);
                            pairs.Add("planGradeid", DRQCResults["planGradeid"]);
                            pairs.Add("planGradeName", TEQCGrade.Text);
                            pairs.Add("planid", DRQCResults["planid"]);
                            pairs.Add("planItemid", DRQCResults["planItemid"]);
                            pairs.Add("planItemName", GEQCItem.Text);
                            pairs.Add("planName", GEQCPlan.Text);
                            pairs.Add("qcSort", DRQCResults["sort"]);
                            pairs.Add("qcTime", DRQCResults["qcTime"]);
                            pairs.Add("remark", TERemark.EditValue);
                            pairs.Add("result", DRQCResults["itemResult"]);
                            pairs.Add("resultid", DRQCResults["id"]);
                            pairs.Add("resultReason", TEReason.EditValue);
                            pairs.Add("resultRule", TEresultRule.EditValue);



                            iInfo.values = pairs;



                            int a = ApiHelpers.postInfo(iInfo);
                            if (a == 1)
                            {
                                this.Close();
                            }









                            //QCInfo<QCAddModel> qCInfo = new QCInfo<QCAddModel>();
                            //qCInfo.UserName = CommonData.UserInfo.names;
                            //
                            //List<QCAddModel> listResult = new List<QCAddModel>();
                            //QCAddModel qCAddModel = new QCAddModel();
                            //qCAddModel.planid = GEQCPlan.EditValue != null ? GEQCPlan.EditValue.ToString() : "";
                            //qCAddModel.planItemid = GEQCItem.EditValue != null ? GEQCItem.EditValue.ToString() : "";
                            //qCAddModel.planGradeid = TEQCGrade.EditValue != null ? TEQCGrade.EditValue.ToString() : "";
                            //qCAddModel.itemNO = itemNO;
                            //qCAddModel.itemResult = TEResult.EditValue != null ? TEResult.EditValue.ToString() : "";
                            //qCAddModel.remark = TERemark.EditValue != null ? TERemark.EditValue.ToString() : "";
                            //qCAddModel.qcTime = DEQCTime.EditValue != null ? DEQCTime.EditValue.ToString() : "";
                            //qCAddModel.sort = TEQCSort.EditValue != null ? Convert.ToInt32(TEQCSort.EditValue) : 0;
                            //listResult.Add(qCAddModel);
                            //qCInfo.infos = listResult;
                            //string Sr = JsonHelper.SerializeObjct(qCInfo);

                            //string a= ApiHelpers.postInfo(QCAddResult, Sr);
                            //if(a=="True")
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
                    //GELevelNO.Properties.DataSource= TEQCGrade.Properties.DataSource = ApiHelpers.postInfo(sInfo);
                    DTGradeInfo = ApiHelpers.postInfo(sInfo);
                }
                else
                {
                    //GELevelNO.Properties.DataSource = TEQCGrade.Properties.DataSource = null;
                    DTGradeInfo = null;
                }
            }
            else
            {
                //GELevelNO.Properties.DataSource = TEQCGrade.Properties.DataSource = null;
                DTGradeInfo = null;
            }
        }
    }
}
