using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;

using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Common.CreateReport
{
    public partial class FrmReportEdit : DevExpress.XtraEditors.XtraForm
    {

        string tableName = "Report.SrouceInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmReportEdit()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            GridControls.formartGridView(gridView1);
            GridLookUpEdites.Formats(GETypeNO);
        }
        private void FrmReportEdit_Load(object sender, EventArgs e)
        {

            GETypeNO.Properties.DataSource = ReportCommData.DTReportType;
            gridControl1.DataSource = ReportCommData.DTReportSrouceInfo;
            gridView1.BestFitColumns();
            TENames.Leave += TENames_Leave;
            gridView1.Click += GridView1_Click;

        }

        private void GridView1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                int handle = gridView1.FocusedRowHandle;
                DataRow dr = gridView1.GetFocusedDataRow();
                SelectValueID = Convert.ToInt32(dr["id"]);
                TENo.EditValue = dr["no"];
                TENames.EditValue = dr["names"];
                TEshortNames.EditValue = dr["shortNames"];
                TEcustomCode.EditValue = dr["customCode"];
                GETypeNO.EditValue = dr["typeNO"];
                TEDataSrouce.EditValue = dr["srouceNames"];
                TEImgSrouce.EditValue = dr["imgSrouce"];
                TERemark.EditValue = dr["remark"];
                CEState.Checked = Convert.ToBoolean(dr["state"]); ;

            }
        }

        private void TENames_Leave(object sender, EventArgs e)
        {
            TEshortNames.EditValue = ConvertShortName.GetChineseSpell(TENames.EditValue.ToString());
        }

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            EditState = 1;
            if (ReportCommData.DTReportSrouceInfo == null)
            {
                TENo.EditValue = 1;
            }
            else
            {
                TENo.EditValue = Convert.ToInt32(ReportCommData.DTReportSrouceInfo.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            TENames.EditValue = "";
            TEshortNames.EditValue = "";
            TEcustomCode.EditValue = "";
            GETypeNO.EditValue = "";
            TEDataSrouce.EditValue = "";
            TEImgSrouce.EditValue = "";
            TERemark.EditValue = "";
            CEState.Checked = true;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENo.EditValue);
                pairs.Add("names", TENames.EditValue);
                pairs.Add("shortNames", TEshortNames.EditValue);
                pairs.Add("customCode", TEcustomCode.EditValue);
                pairs.Add("typeNO", GETypeNO.EditValue);
                pairs.Add("srouceNames", TEDataSrouce.EditValue);
                pairs.Add("imgSrouce", TEImgSrouce.EditValue);
                pairs.Add("remark", TERemark.EditValue);
                pairs.Add("state", CEState.EditValue);
                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                pairs.Add("dstate", 0);

                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int a = Convert.ToInt32(SqlConnServer.postinserts(insertInfo));

            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    pairs.Add("no", TENo.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("shortNames", TEshortNames.EditValue);
                    pairs.Add("customCode", TEcustomCode.EditValue);
                    pairs.Add("typeNO", GETypeNO.EditValue);
                    pairs.Add("srouceNames", TEDataSrouce.EditValue);
                    pairs.Add("imgSrouce", TEImgSrouce.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("state", CEState.EditValue);
                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    pairs.Add("dstate", 0);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = Convert.ToInt32(SqlConnServer.postupdates(updateInfo));
                }
            }
            EditState = 0;
            CommonDataRefresh.GetreportSrouce();
            FrmReportEdit_Load(null, null);
            groupBox1.Enabled = false;
        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void BTReportInput_Click(object sender, EventArgs e)
        {
            if (SelectValueID == 0)
            {
                XtraMessageBox.Show("请选择需要导入模板的信息！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    //openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
                    openFileDialog.InitialDirectory = "C:\\Users\\huang\\Desktop\\";
                    //openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
                    openFileDialog.Filter = "repx|*.repx";
                    //openFileDialog.Filter = "repx|*.csv;*.xls;*.xlsx";
                    openFileDialog.RestoreDirectory = true;
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string FileClassa = System.IO.Path.GetExtension(openFileDialog.FileName); //文件扩展名
                        if (FileClassa != ".repx")
                        {
                            XtraMessageBox.Show("文件类型错误！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DialogResult result = XtraMessageBox.Show("是否确定导入当前模板", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                byte[] bytes = File.ReadAllBytes(openFileDialog.FileName);
                                string base64String = Convert.ToBase64String(bytes);
                                uInfo updateInfo = new uInfo();
                                updateInfo.TableName = tableName;
                                Dictionary<string, object> pairs = new Dictionary<string, object>();
                                pairs.Add("fileString", base64String);
                                updateInfo.values = pairs;
                                updateInfo.DataValueID = SelectValueID;
                                updateInfo.MessageShow = 1;
                                int a = Convert.ToInt32(SqlConnServer.postupdates(updateInfo));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("请检查选择文件是否正常！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        XtraReport xtraReport;
        XRDesignFormEx designForm;

        private void BTReportEdite_Click(object sender, EventArgs e)
        {
            if (SelectValueID != 0)
            {

                sInfo selectInfo = new sInfo();
                //selectInfo.wheres = "fileString";
                selectInfo.wheres = $"id={SelectValueID}";
                selectInfo.TableName = tableName;
                DataTable dataTable = SqlConnServer.postselects(selectInfo);
                if (dataTable != null)
                {
                    if (!Convert.IsDBNull(dataTable.Rows[0]["fileString"]))
                    {
                        if (!Convert.IsDBNull(dataTable.Rows[0]["srouceNames"]))
                        {

                            if (!Convert.IsDBNull(dataTable.Rows[0]["imgSrouce"]))
                            {
                                LoadReport(dataTable.Rows[0]["srouceNames"].ToString(), dataTable.Rows[0]["imgSrouce"].ToString(), dataTable.Rows[0]["fileString"].ToString());
                            }
                            else
                            {
                                LoadReport(dataTable.Rows[0]["srouceNames"].ToString(), null, dataTable.Rows[0]["fileString"].ToString());
                            }

                        }
                        else
                        {
                            LoadReport(null, null, dataTable.Rows[0]["fileString"].ToString());
                        }
                    }
                    else
                    {
                        CreatNewRepor();
                    }

                }

                //xtraReport1.DataSource = dt;
            }
            else
            {
                XtraMessageBox.Show("请选择编辑信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void DesignForm_ReportStateChanged(object sender, ReportStateEventArgs e)
        {
            //只要报表发生改变就立即将状态设置为保存
            //避免系统默认保存对话框的出现
            if (e.ReportState == ReportState.Changed)
            {
                ((XRDesignFormEx)sender).DesignPanel.ReportState = ReportState.Saved;
            }
        }

        private void DesignForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectValueID != 0)
            {
                DialogResult result = XtraMessageBox.Show("是否保存当前修改内容", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    System.IO.MemoryStream ms = new MemoryStream();
                    xtraReport.SaveLayout(ms);
                    byte[] fff = ms.ToArray();
                    string base64String = Convert.ToBase64String(fff);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    pairs.Add("fileString", base64String);
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    updateInfo.MessageShow = 1;
                    int a = Convert.ToInt32(SqlConnServer.postupdates(updateInfo));
                }
            }
        }
        /// <summary>
        /// 读取模板信息
        /// </summary>
        /// <param name="srouceName"></param>
        /// <param name="imgSrouce"></param>
        /// <param name="fileString"></param>
        public void LoadReport(string srouceNames, string imgSrouce, string fileString)
        {
            try
            {


                if (fileString.Length > 0)
                {
                    xtraReport = new XtraReport();
                    byte[] arr = Convert.FromBase64String(fileString);
                    Stream stream = new MemoryStream(arr);
                    DataSet dataSet = new DataSet();
                    if (srouceNames != null)
                    {
                        if (srouceNames != "")
                        {
                            string[] tablenames = srouceNames.Split(',');
                            foreach (string tablename in tablenames)
                            {
                                if (srouceNames != "")
                                {
                                    sInfo selectInfo = new sInfo();
                                    selectInfo.wheres = " top 1 * ";
                                    selectInfo.TableName = tablename;
                                    DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                    if (dataTable != null)
                                    {
                                        dataTable.TableName = tablename.Replace(".", "");
                                        dataSet.Tables.Add(dataTable);
                                    }
                                }
                            }
                        }
                    }
                    if (imgSrouce != null)
                    {
                        if (imgSrouce != "")
                        {
                            string[] tableImgs = imgSrouce.Split(',');
                            foreach (string tableImg in tableImgs)
                            {
                                sInfo selectInfo = new sInfo();
                                selectInfo.TableName = tableImg;
                                selectInfo.wheres = $"barcode='T01027000908' and state=1";
                                DataTable dataTable = SqlConnServer.postselects(selectInfo);
                                if (dataTable != null)
                                {
                                    dataTable.TableName = tableImg.Replace(".", "");
                                    dataTable.Columns.Add("img", typeof(Image));
                                    foreach (DataRow dataRow in dataTable.Rows)
                                    {
                                        string imgstr = dataRow["filestring"].ToString();
                                        dataRow["img"] = FileConverHelpers.StringToBitmap(imgstr);
                                    }
                                    dataSet.Tables.Add(dataTable);
                                }
                            }
                        }
                    }
                    dataSet.DataSetName = "dataInfo";
                    xtraReport.DataSource = dataSet;

                    xtraReport.LoadLayout(stream);
                    designForm = new XRDesignFormEx();
                    //隐藏按钮  这段
                    designForm.DesignPanel.SetCommandVisibility(new ReportCommand[]{
                        ReportCommand.NewReport,
                        ReportCommand.SaveFile,
                        ReportCommand.SaveFileAs,
                        ReportCommand.SaveAll,
                        ReportCommand.NewReportWizard,
                        ReportCommand.OpenFile,
                        ReportCommand.Paste
                    }, CommandVisibility.Verb);
                    designForm.FormClosing += DesignForm_FormClosing;
                    designForm.ReportStateChanged += DesignForm_ReportStateChanged;
                    // 加载报表. 
                    designForm.OpenReport(xtraReport);
                    // 打开设计器
                    designForm.ShowDialog();
                    designForm.Dispose();

                }
                else
                {
                    CreatNewRepor();
                }
            }
            catch
            {
                CreatNewRepor();
            }
        }

        public void CreatNewRepor()
        {
            designForm = new XRDesignFormEx();
            xtraReport = new XtraReport();
            //隐藏按钮  这段
            designForm.DesignPanel.SetCommandVisibility(new ReportCommand[]{
                            //ReportCommand.NewReport,
                            ReportCommand.SaveFile,
                            ReportCommand.SaveFileAs,
                            ReportCommand.SaveAll,
                            ReportCommand.NewReportWizard,
                            ReportCommand.OpenFile,
                            ReportCommand.Paste

                        }, CommandVisibility.Verb);
            designForm.FormClosing += DesignForm_FormClosing;
            designForm.ReportStateChanged += DesignForm_ReportStateChanged;
            // 加载报表. 
            designForm.OpenReport(xtraReport);
            // 打开设计器
            designForm.ShowDialog();
            designForm.Dispose();
        }
    }
}
