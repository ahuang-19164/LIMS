using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorkTest.UploadReport;

namespace workOther.SendEmail
{
    public partial class FrmSendEmail : XtraForm
    {
        private static string SendEmail = "";
        public FrmSendEmail()
        {
            InitializeComponent();
            DEstartTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEendTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GESendState.EditValue = 1;
            SendEmail = ConfigInfos.ReadConfigInfo("SendEmail");





            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("no", typeof(int));
            dataTable.Columns.Add("names", typeof(string));
            dataTable.Columns.Add("shortNames", typeof(string));
            dataTable.Columns.Add("customCode", typeof(string));
            //dataTable.Rows.Add(0, "全部", "qb", "A");
            dataTable.Rows.Add(1, "未发送", "wfs", "W");
            dataTable.Rows.Add(2, "发送成功", "fscg", "S");
            dataTable.Rows.Add(3, "发送失败", "fssb", "E");




            GridLookUpEdites.Formats(RGESendState);
            GridLookUpEdites.Formats(RGEeState);
            GridLookUpEdites.Formats(RGEtestStateNO);
            RGESendState.DataSource = DTHelper.DTAddAll(dataTable);
            RGEeState.DataSource = dataTable;
            RGEtestStateNO.DataSource = WorkCommData.DTStateTest;

            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);
            GridControls.ShowViewColor(GVInfo);
            SysPowerHelper.UserPower(barManager1);


        }



        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkTest.SampleInfo";
            string wheres = $" createTime>='{DEstartTime.EditValue}' and createTime<='{Convert.ToDateTime(DEendTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}' and TestStateNO='6' ";
            if (Convert.ToInt32(GESendState.EditValue) != 0)
            {
                wheres += $"and eState = '{GESendState.EditValue}'";
            }
            if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString() != "")
            {
                wheres += $"and barcode like '%{TEbarcode.EditValue}%'";
            }
            if (TEpatientName.EditValue != null && TEpatientName.EditValue.ToString() != "")
            {
                wheres += $"and patientName like '%{TEpatientName.EditValue}%'";
            }
            sInfo.wheres = wheres;
            DataTable dataTable = ApiHelpers.postInfo(sInfo);
            if (dataTable != null)
            {
                dataTable.Columns.Add("check", typeof(bool));
                //data.Columns.Add("testID", typeof(string));
                GCInfo.DataSource = dataTable;
            }
            else
            {
                GCInfo.DataSource = null;
            }
            GVInfo.BestFitColumns();
        }

        private void BTSend_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InfoModel<sampleInfo> infoModel = new InfoModel<sampleInfo>();
            if (GCInfo.DataSource != null && GVInfo.DataRowCount > 0)
            {
                GVInfo.FocusedRowHandle = -1;
                infoModel.UserName = CommonData.UserInfo.names;
                
                string errorinfo = "";
                List<sampleInfo> samples = new List<sampleInfo>();
                for (int a = 0; a < GVInfo.RowCount; a++)
                {
                    DataRow dataRow = GVInfo.GetDataRow(a);
                    bool instate = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                    string patientAddress = dataRow["patientAddress"] != DBNull.Value ? dataRow["patientAddress"].ToString() : "";
                    int perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
                    int testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                    string barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                    if (instate&&perid!=0&&testid!=0)
                    {
                        if(patientAddress != ""&& patientAddress.Contains("@"))
                        {
                            sampleInfo info = new sampleInfo();
                            info.perid = perid;
                            info.testid = testid;
                            info.barcode = barcode;
                            info.email = patientAddress;
                            samples.Add(info);
                        }
                        else
                        {
                            errorinfo += "条码号:" + barcode + "邮箱地址为空或格式不正确。\r\n";
                        }
                    }
                }
                if(samples.Count>0)
                {

                    Task task = new Task(() =>
                      {
                          infoModel.infos = samples;
                          string Sr = JsonHelper.SerializeObjct(infoModel);
                          ApiHelpers.postInfo(SendEmail, Sr);
                      });
                    task.Start();
                    if(errorinfo!="")
                        MessageBox.Show(errorinfo, "系统提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MessageBox.Show("请求已发送，稍等片刻查询发送结果！","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("请求错误"+errorinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BTReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVInfo.GetFocusedDataRow();
            if(dataRow!=null)
            {
                int perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
                int testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                string barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                string hospitalNO = dataRow["hospitalNO"] != DBNull.Value ? dataRow["hospitalNO"].ToString() : "";
                string testStateNO = dataRow["testStateNO"] != DBNull.Value ? dataRow["testStateNO"].ToString() : "";
                if (perid != 0 && testid != 0)
                {
                    FrmUpReport frmUpReport = new FrmUpReport(perid, testid, barcode, hospitalNO, testStateNO);
                    frmUpReport.ShowDialog();
                }
            }

            

        }

        private void CEAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(GCInfo.DataSource!=null&&GVInfo.DataRowCount>0)
            {
                for(int a=0;a<GVInfo.RowCount;a++)
                {
                    GVInfo.SetRowCellValue(a, "check", CEAll.Checked);
                }
            }
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void GVInfo_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

            try
            {
                if (e.Column.FieldName.Contains("eState"))
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() == "1")
                        {

                            e.Appearance.BackColor = Color.YellowGreen;
                        }
                        if (e.CellValue.ToString() == "2")
                        {

                            e.Appearance.BackColor = Color.Green;
                        }
                        if (e.CellValue.ToString() == "3")
                        {

                            e.Appearance.BackColor = Color.Red;
                        }
                    }
                }
            }
            catch //(Exception ex)
            {

                //throw ex;

            }

        }
    }
}
