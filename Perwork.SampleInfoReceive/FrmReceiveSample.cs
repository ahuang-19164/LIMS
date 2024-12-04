using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.HotKey;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.PerModel;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perwork.SampleInfoReceive
{
    public partial class FrmReceiveSample : DevExpress.XtraEditors.XtraForm
    {
        
        //string GroupID;
        string TestReceiveDT = "";
        string TestReceiveInfo = "";
        public FrmReceiveSample()
        {


            //GroupID = GroupNO;
            string GroupNO = null;
            TestReceiveDT = ConfigInfos.ReadConfigInfo("TestReceiveDT");
            TestReceiveInfo = ConfigInfos.ReadConfigInfo("TestReceiveInfo");
            InitializeComponent();
            DEReceiveTimes.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEStartTimes.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEndTimes.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GEgroupNOs.EditValue = GroupNO;

            if (GroupNO != null)
            {
                GEgroupNOs.Enabled = false;

            }
            CEDefultNO.Checked = true;
            TENOTabs.Enabled = false;
            TENOSerials.Enabled = false;
            BTCreateTestNO.Enabled = false;
            TEbarcode.Enabled = false;
            TEhosBarcode.Enabled = false;
            //DEStartTimes.Enabled = false;
            //DEEndTimes.Enabled = false;


        }
        public FrmReceiveSample(string GroupNO)
        {


            //GroupID = GroupNO;
            //string GroupNO = null;
            TestReceiveDT = ConfigInfos.ReadConfigInfo("TestReceiveDT");
            TestReceiveInfo = ConfigInfos.ReadConfigInfo("TestReceiveInfo");
            InitializeComponent();
            DEReceiveTimes.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEStartTimes.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEndTimes.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GEgroupNOs.EditValue = GroupNO;

            if (GroupNO != null)
            {
                GEgroupNOs.Enabled = false;

            }
            CEDefultNO.Checked = true;
            TENOTabs.Enabled = false;
            TENOSerials.Enabled = false;
            BTCreateTestNO.Enabled = false;
            TEbarcode.Enabled = false;
            TEhosBarcode.Enabled = false;
            //DEStartTimes.Enabled = false;
            //DEEndTimes.Enabled = false;


        }

        private void FrmReceiveSample_Load(object sender, EventArgs e)
        {

            getPrintInfo();

            GridControls.formartGridView(GVSampleInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);

            GEgroupNOs.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest);
            GridLookUpEdites.Formats(GEgroupNOs);

            GEAgentNO.DataSource = WorkCommData.DTClientAgent;
            GridLookUpEdites.Formats(GEAgentNO);
            GEHospitalNO.DataSource = WorkCommData.DTClientInfo;
            GridLookUpEdites.Formats(GEHospitalNO);
            GEPatientType.DataSource = WorkCommData.DTTypePatient;
            GridLookUpEdites.Formats(GEPatientType);
            GESampleShape.DataSource = WorkCommData.DTTypeShape;
            GridLookUpEdites.Formats(GESampleShape);
            GESampleType.DataSource = WorkCommData.DTTypeSample;
            GridLookUpEdites.Formats(GESampleType);


            TextEdits.TextFormat(TENOSerials);
            TextEdits.TextFormat(TEFrameSerials);

            //SysPowerHelper.UserPower(barManager1);



            //BTSelect_ItemClick(null,null);
        }
        /// <summary>
        /// 获取打印机信息
        /// </summary>
        public void getPrintInfo()
        {
            try
            {


                //获取打印机
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    CBPrintInfo.Properties.Items.Add(printer);
                }
                PrintDocument fPrintDocument = new PrintDocument();    //获取默认打印机的方法
                CBPrintInfo.EditValue = fPrintDocument.PrinterSettings.PrinterName;
                //CBPrintList.SelectedIndex = 0;
            }
            catch
            {
                CBPrintInfo.EditValue = null;
            }

        }






        #region 导航栏方法

        private void CEDefultNO_CheckedChanged(object sender, EventArgs e)
        {
            if (CEDefultNO.Checked)
            {
                CECustomNO.Checked = false;
                CECheckNO.Checked = false;
                TENOTabs.Enabled = false;
                TENOSerials.Enabled = false;
                BTCreateTestNO.Enabled = false;
            }
        }

        private void CECustomNO_CheckedChanged(object sender, EventArgs e)
        {
            if (CECustomNO.Checked)
            {
                //CECheckNO.Checked = true;
                CEDefultNO.Checked = false;
                CECheckNO.Checked = false;
                TENOTabs.Enabled = true;
                TENOSerials.Enabled = true;
                BTCreateTestNO.Enabled = true;
            }
        }


        private void CECheckNO_CheckedChanged(object sender, EventArgs e)
        {
            if (CECheckNO.Checked)
            {
                //CECheckNO.Checked = true;
                CEDefultNO.Checked = false;
                CECustomNO.Checked = false;
                TENOTabs.Enabled = true;
                TENOSerials.Enabled = true;
                BTCreateTestNO.Enabled = true;
            }
        }

        #endregion



        private void BTSelects_Click(object sender, EventArgs e)
        {
            if (GEgroupNOs.EditValue != null)
            {
                BTSelects.Enabled = false;
                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载数据请稍等......");
                CECheckAll.Checked = false;

                ReceiveSelectModel receiveSelect = new ReceiveSelectModel();
                receiveSelect.UserName = CommonData.UserInfo.names;
                
                receiveSelect.startTime = Convert.ToDateTime(DEStartTimes.EditValue).ToString("yyyy-MM-dd");
                receiveSelect.endTime = Convert.ToDateTime(DEEndTimes.EditValue).AddDays(+1).ToString("yyyy-MM-dd");
                receiveSelect.groupNO = GEgroupNOs.EditValue.ToString();
                string Sr = JsonHelper.SerializeObjct(receiveSelect);
                WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveDT, Sr);
                DataTable dataTable = JsonHelper.StringToDT(jm);
                if (dataTable != null)
                {
                    dataTable.Columns.Add("check", typeof(bool));
                    //data.Columns.Add("testID", typeof(string));
                    GCSampleInfo.DataSource = dataTable;
                }
                else
                {
                    GCSampleInfo.DataSource = null;
                }
                GVSampleInfo.BestFitColumns();
                frmWait.HideMe(this);
                BTSelects.Enabled = true;
            }
            else
            {
                MessageBox.Show("请先选择专业组信息！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GEgroupNOs.EditValue != null)
            {
                FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载数据请稍等......");
                //try
                //{
                ReceiveSelectModel receiveSelect = new ReceiveSelectModel();
                receiveSelect.UserName = CommonData.UserInfo.names;
                
                receiveSelect.startTime = Convert.ToDateTime(DEStartTimes.EditValue).ToString("yyyy-MM-dd");
                receiveSelect.endTime = Convert.ToDateTime(DEEndTimes.EditValue).AddDays(+1).ToString("yyyy-MM-dd");
                receiveSelect.groupNO = GEgroupNOs.EditValue.ToString();
                string Sr = JsonHelper.SerializeObjct(receiveSelect);
                WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveDT, Sr);
                DataTable dataTable = JsonHelper.StringToDT(jm);
                if (dataTable != null)
                {
                    dataTable.Columns.Add("check", typeof(bool));
                    //data.Columns.Add("testID", typeof(string));
                    GCSampleInfo.DataSource = dataTable;
                }
                else
                {
                    GCSampleInfo.DataSource = null;
                }
                GVSampleInfo.BestFitColumns();
                frmWait.HideMe(this);
                //}
                //catch (Exception ex)
                //{
                //    frmWait.HideMe(this);
                //    MessageBox.Show("没有需要处理的标本信息。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            else
            {
                MessageBox.Show("请先选择专业组信息！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CECheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CECheckAll.Checked)
            {
                for (int dr = 0; dr < GVSampleInfo.RowCount; dr++)
                {
                    GVSampleInfo.SetRowCellValue(dr, "check", true);
                }
            }
            else
            {
                for (int dr = 0; dr < GVSampleInfo.RowCount; dr++)
                {
                    GVSampleInfo.SetRowCellValue(dr, "check", false);
                }
            }
        }

        private void BTReceives_Click(object sender, EventArgs e)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this, "", "正在处理接收信息，请稍等......");
            BTReceives.Enabled = false;
            try
            {
                if (CESelectState.Checked || CEScanState.Checked)
                {
                    //GVSampleInfo.FocusedRowHandle = -1;

                    //int[] samplesDt = GVSampleInfo.GetSelectedRows();

                    string msg = "";

                    bool checkState = true;//判断是否用check字段进行审核



                    for (int a = 0; a < GVSampleInfo.RowCount; a++)
                    {

                        DataRow dataRow = GVSampleInfo.GetDataRow(a);



                        #region
                        ReceiveInfoModel receiveInfoModel = new ReceiveInfoModel();
                        receiveInfoModel.UserName = CommonData.UserInfo.names;

                        receiveInfoModel.ReceiveTime = Convert.ToDateTime(DEReceiveTimes.EditValue).ToString("yyyy-MM-dd");
                        List<ReceiveSampleInfoModel> receiveInfos = new List<ReceiveSampleInfoModel>();
                        receiveInfoModel.ReceiveInfos = receiveInfos;
                        bool sampleState = dataRow["state"] != DBNull.Value ? Convert.ToBoolean(dataRow["state"]) : false;
                        if (!sampleState)
                        {
                            if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
                            {
                                if (Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
                                {
                                    ReceiveSampleInfoModel receiveInfo = new ReceiveSampleInfoModel();
                                    checkState = false;
                                    if (CEDefultNO.Checked)
                                    {
                                        if (GVSampleInfo.GetDataRow(a)["testNo"] == DBNull.Value || GVSampleInfo.GetDataRow(a)["testNo"].ToString().Trim() == "")
                                        {
                                            GVSampleInfo.SetRowCellValue(a, "testNo", dataRow["id"]);
                                            receiveInfo.perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
                                            receiveInfo.testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                                            receiveInfo.sampleid = dataRow["sampleID"] != DBNull.Value ? dataRow["sampleID"].ToString() : "";
                                            receiveInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                                            receiveInfo.testNo = dataRow["testNo"] != DBNull.Value ? dataRow["testNo"].ToString() : "";
                                            receiveInfo.frameNo = dataRow["frameNo"] != DBNull.Value ? dataRow["frameNo"].ToString() : "";
                                            receiveInfo.groupNO= GEgroupNOs.EditValue.ToString();
                                            receiveInfo.groupName = GEgroupNOs.Text;
                                            receiveInfos.Add(receiveInfo);
                                        }
                                        else
                                        {
                                            receiveInfo.perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
                                            receiveInfo.testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                                            receiveInfo.sampleid = dataRow["sampleID"] != DBNull.Value ? dataRow["sampleID"].ToString() : "";
                                            receiveInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                                            receiveInfo.testNo = dataRow["testNo"] != DBNull.Value ? dataRow["testNo"].ToString() : "";
                                            receiveInfo.frameNo = dataRow["frameNo"] != DBNull.Value ? dataRow["frameNo"].ToString() : "";
                                            receiveInfo.groupNO = GEgroupNOs.EditValue.ToString();
                                            receiveInfo.groupName = GEgroupNOs.Text;
                                            receiveInfos.Add(receiveInfo);
                                        }
                                    }
                                    else
                                    {
                                        if (dataRow["testNo"] != DBNull.Value || dataRow["testNo"].ToString().Trim() == "")
                                        {
                                            receiveInfo.perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
                                            receiveInfo.testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                                            receiveInfo.sampleid = dataRow["sampleID"] != DBNull.Value ? dataRow["sampleID"].ToString() : "";
                                            receiveInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                                            receiveInfo.testNo = dataRow["testNo"] != DBNull.Value ? dataRow["testNo"].ToString() : "";
                                            receiveInfo.frameNo = dataRow["frameNo"] != DBNull.Value ? dataRow["frameNo"].ToString() : "";
                                            receiveInfo.groupNO = GEgroupNOs.EditValue.ToString();
                                            receiveInfo.groupName = GEgroupNOs.Text;
                                            receiveInfos.Add(receiveInfo);
                                        }
                                        else
                                        {
                                            DialogResult dialog = MessageBox.Show($"{GVSampleInfo.GetDataRow(a)["barcode"].ToString()}没有定义实验编号。是否跳过该信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                            if (dialog != DialogResult.Yes)
                                            {
                                                break;
                                            }

                                        }
                                    }
                                }
                            }
                            if (receiveInfos.Count > 0)
                            {
                                string Sr = JsonHelper.SerializeObjct(receiveInfoModel);
                                WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveInfo, Sr);
                                commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                                
                                if (commReInfo != null&&commReInfo.code==0)
                                {
                                    foreach (commReSampleInfo sampleInfo in commReInfo.infos)
                                    {
                                        if (sampleInfo.code == 0)
                                        {
                                            GVSampleInfo.SetRowCellValue(a, "state", true);
                                            //for (int r = GVSampleInfo.RowCount - 1; r >= 0; r--)
                                            //{
                                            //    string barcode = GVSampleInfo.GetDataRow(r)["barcode"].ToString();

                                            //    if (sampleInfo.barcode == barcode)
                                            //    {
                                            //        GVSampleInfo.SetRowCellValue(r, "state", true);
                                            //    }
                                            //}
                                        }
                                        else
                                        {
                                            msg += sampleInfo.barcode+":" + sampleInfo.msg + "\r\n";
                                        }

                                    }
                                }
                                else
                                {
                                    msg = "接收失败";
                                    break;
                                }

                            }

                        }

                        #endregion

                    }
                    frmWait.HideMe(this);
                    if (msg == "")
                    {
                        //MessageBox.Show("接收完成！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                //frmWait.HideMe(this);
                BTReceives.Enabled = true;
            }
            catch (Exception ex)
            {
                frmWait.HideMe(this);
                BTReceives.Enabled = true;
                MessageBox.Show(ex.ToString(), "系统提示");
            }

        }

        private void GVSampleInfo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent") != DBNull.Value)
            {
                if (Convert.ToBoolean(GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent")))
                {
                    //e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))); ;//改变背景色
                    //e.Appearance.BackColor = Color.Transparent;//改变背景色
                    //e.Appearance.BackColor = Color.Aquamarine;//改变背景色
                    e.Appearance.ForeColor = System.Drawing.Color.Red;//改变字体颜色
                }
            }
            if (GVSampleInfo.GetRowCellValue(e.RowHandle, "state") != DBNull.Value)
            {
                if (Convert.ToBoolean(GVSampleInfo.GetRowCellValue(e.RowHandle, "state")))
                {
                    e.Appearance.BackColor = System.Drawing.Color.SpringGreen; ;//改变背景色
                    //e.Appearance.ForeColor = Color.Red;//改变字体颜色
                }
            }

        }

        private void GVSampleInfo_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "testNo")
            {
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            }
            if (e.Column.FieldName == "frameNo")
            {
                e.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            }
        }

        #region 样本号生成方法
        /// <summary>
        /// 生成样本编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTCreateTestNO_Click(object sender, EventArgs e)
        {
            if (TENOSerials.EditValue != null)
            {
                if (TENOSerials.EditValue.ToString().Length != 0)
                {
                    if (TENOTabs.EditValue == null)
                    {
                        for (int row = 0; row < GVSampleInfo.RowCount; row++)
                        {
                            DataRow dataRow = GVSampleInfo.GetDataRow(row);
                            if (!Convert.IsDBNull(dataRow["check"]))
                            {
                                if (Convert.ToBoolean(dataRow["check"]))
                                {
                                    int NOSerial = Convert.ToInt32(TENOSerials.EditValue);
                                    GVSampleInfo.SetRowCellValue(row, "testNo", NOSerial.ToString());
                                    TENOSerials.EditValue = NOSerial + 1;
                                }
                            }
                        }
                        GVSampleInfo.BestFitColumns();
                    }
                    else
                    {
                        for (int row = 0; row < GVSampleInfo.RowCount; row++)
                        {
                            DataRow dataRow = GVSampleInfo.GetDataRow(row);
                            if (!Convert.IsDBNull(dataRow["check"]))
                            {
                                if (Convert.ToBoolean(dataRow["check"]))
                                {
                                    int NOSerial = Convert.ToInt32(TENOSerials.EditValue);
                                    GVSampleInfo.SetRowCellValue(row, "testNo", TENOTabs.EditValue.ToString() + NOSerial.ToString());
                                    TENOSerials.EditValue = NOSerial + 1;
                                }
                            }
                        }
                        GVSampleInfo.BestFitColumns();
                    }

                }
            }
        }
        /// <summary>
        /// 生成试管架号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTCreateFrameNO_Click(object sender, EventArgs e)
        {
            if (TEFrameSerials.EditValue != null)
            {
                if (TEFrameSerials.EditValue.ToString().Length != 0)
                {
                    if (TEFrameTops.EditValue == null)
                    {
                        for (int row = 0; row < GVSampleInfo.RowCount; row++)
                        {
                            DataRow dataRow = GVSampleInfo.GetDataRow(row);
                            if (!Convert.IsDBNull(dataRow["check"]))
                            {
                                if (Convert.ToBoolean(dataRow["check"]))
                                {
                                    int NOSerial = Convert.ToInt32(TEFrameSerials.EditValue);
                                    GVSampleInfo.SetRowCellValue(row, "frameNo", NOSerial.ToString());
                                    TEFrameSerials.EditValue = NOSerial + 1;
                                }
                            }
                        }
                        GVSampleInfo.BestFitColumns();
                    }
                    else
                    {
                        for (int row = 0; row < GVSampleInfo.RowCount; row++)
                        {
                            DataRow dataRow = GVSampleInfo.GetDataRow(row);
                            if (!Convert.IsDBNull(dataRow["check"]))
                            {
                                if (Convert.ToBoolean(dataRow["check"]))
                                {
                                    int NOSerial = Convert.ToInt32(TEFrameSerials.EditValue);
                                    GVSampleInfo.SetRowCellValue(row, "frameNo", TEFrameTops.EditValue.ToString() + NOSerial.ToString());
                                    TEFrameSerials.EditValue = NOSerial + 1;
                                }
                            }
                        }
                        GVSampleInfo.BestFitColumns();
                    }

                }
            }
        }

        private void GVSampleInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {

                string ssssa = dataRow["groupCodes"] != DBNull.Value ? dataRow["groupCodes"].ToString() : "";
                if (ssssa.Length > 0)
                {
                    GCItemInfo.DataSource = WorkCommData.DTItemGroup.Select($"no in ({ssssa.Substring(0, ssssa.Length - 1)})").CopyToDataTable();
                }
                if (CECheckNO.Checked)
                {

                    if (TENOSerials.EditValue != null && TENOSerials.EditValue.ToString().Trim().Length != 0)
                    {
                        string testNo = dataRow["testNo"] != DBNull.Value && dataRow["testNo"].ToString().Trim() != "" ? dataRow["testNo"].ToString() : "";
                        if (testNo == "")
                        {
                            int NOSerial = Convert.ToInt32(TENOSerials.EditValue);
                            if (TENOTabs.EditValue == null)
                            {
                                GVSampleInfo.SetFocusedRowCellValue("testNo", NOSerial.ToString());
                            }
                            else
                            {
                                GVSampleInfo.SetFocusedRowCellValue("testNo", TENOTabs.EditValue.ToString() + NOSerial.ToString());
                            }
                            GVSampleInfo.SetFocusedRowCellValue("check", true);
                            TENOSerials.EditValue = NOSerial + 1;
                        }
                        else
                        {
                            if (!CEFrameNO.Checked)
                            {
                                DialogResult dialogResult = MessageBox.Show($"是否修改信息样本号？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    int NOSerial = Convert.ToInt32(TENOSerials.EditValue);
                                    if (TENOTabs.EditValue == null)
                                    {
                                        GVSampleInfo.SetFocusedRowCellValue("testNo", NOSerial.ToString());
                                    }
                                    else
                                    {
                                        GVSampleInfo.SetFocusedRowCellValue("testNo", TENOTabs.EditValue.ToString() + NOSerial.ToString());
                                    }
                                    GVSampleInfo.SetFocusedRowCellValue("check", true);
                                    TENOSerials.EditValue = NOSerial + 1;
                                }
                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"样本流水号设置错误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (CEFrameNO.Checked)
                {
                    if (TEFrameSerials.EditValue != null && TEFrameSerials.EditValue.ToString().Trim().Length != 0)
                    {
                        if (GVSampleInfo.GetFocusedRowCellValue("frameNo") == DBNull.Value || GVSampleInfo.GetFocusedRowCellValue("frameNo").ToString().Trim().Length == 0)
                        {
                            int NOSerial = Convert.ToInt32(TEFrameSerials.EditValue);
                            if (TEFrameTops.EditValue == null)
                            {
                                GVSampleInfo.SetFocusedRowCellValue("frameNo", NOSerial.ToString());
                            }
                            else
                            {
                                GVSampleInfo.SetFocusedRowCellValue("frameNo", TEFrameTops.EditValue.ToString() + NOSerial.ToString());
                            }
                            GVSampleInfo.SetFocusedRowCellValue("check", true);
                            TEFrameSerials.EditValue = NOSerial + 1;
                        }
                        else
                        {
                            DialogResult dialogResult = MessageBox.Show($"是否修改试管架号？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dialogResult == DialogResult.Yes)
                            {
                                int NOSerial = Convert.ToInt32(TEFrameSerials.EditValue);
                                if (TEFrameTops.EditValue == null)
                                {
                                    GVSampleInfo.SetFocusedRowCellValue("frameNo", NOSerial.ToString());
                                }
                                else
                                {
                                    GVSampleInfo.SetFocusedRowCellValue("frameNo", TEFrameTops.EditValue.ToString() + NOSerial.ToString());
                                }
                                GVSampleInfo.SetFocusedRowCellValue("check", true);
                                TEFrameSerials.EditValue = NOSerial + 1;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"试管架流水号设置错误！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                GCItemInfo.DataSource = null;
            }
        }



        #endregion
        #region 接收状态
        private void CESelectState_CheckedChanged(object sender, EventArgs e)
        {
            if (CESelectState.Checked)
            {
                CEScanState.Checked = false;
                CEDefultNO.Enabled = true;
                CECustomNO.Enabled = true;
                CECheckNO.Enabled = true;
                CEFrameNO.Enabled = true;

                CEDefultNO.Checked = true;
                CECustomNO.Checked = false;
                CECheckNO.Checked = false;
                CEFrameNO.Checked = false;

                TENOTabs.Enabled = false;
                TENOSerials.Enabled = false;
                TEbarcode.Enabled = false;
                TEhosBarcode.Enabled = false;
                BTSelects.Enabled = true;
                BTCreateTestNO.Enabled = false;
            }
            GCSampleInfo.DataSource = null;
            GCItemInfo.DataSource = null;
        }

        private void CEScanState_CheckedChanged(object sender, EventArgs e)
        {
            if (CEScanState.Checked)
            {
                sampleInfoTable = null;


                CESelectState.Checked = false;
                CEDefultNO.Enabled = false;

                CEDefultNO.Checked = false;



                CECustomNO.Enabled = true;
                CEFrameNO.Checked = true;
                CECheckNO.Checked = true;
                CECheckNO.Enabled = true;
                CEFrameNO.Enabled = true;

                TENOTabs.Enabled = true;
                TENOSerials.Enabled = true;
                TEbarcode.Enabled = true;
                TEhosBarcode.Enabled = true;
                BTSelects.Enabled = false;
                BTCreateTestNO.Enabled = true;
            }
            GCSampleInfo.DataSource = null;
            GCItemInfo.DataSource = null;
        }
        #endregion
        DataTable sampleInfoTable = null;
        private void TEbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//这是允许输入退格键
            {
                if (GEgroupNOs.EditValue != null)
                {
                    if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString().Trim().Length > 0)
                    {

                        bool receiveState = true;
                        if(sampleInfoTable!=null)
                        {
                            foreach (DataRow dataRow in sampleInfoTable.Rows)
                            {
                                string getbarcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                                if (getbarcode != "")
                                {
                                    if (getbarcode == TEbarcode.EditValue.ToString().Trim())
                                    {
                                        receiveState = false;
                                    }
                                }
                            }
                        }

                        if(receiveState)
                        {
                            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载数据请稍等......");
                            ReceiveSelectModel receiveSelect = new ReceiveSelectModel();
                            receiveSelect.UserName = CommonData.UserInfo.names;
                            
                            receiveSelect.barcode = TEbarcode.EditValue.ToString().Trim();
                            receiveSelect.groupNO = GEgroupNOs.EditValue.ToString();
                            string Sr = JsonHelper.SerializeObjct(receiveSelect);
                            WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveDT, Sr);
                            DataTable dataTable = JsonHelper.StringToDT(jm);
                            if (dataTable != null)
                            {
                                dataTable.Columns.Add("check", typeof(bool));
                                if (sampleInfoTable == null)
                                {
                                    sampleInfoTable = dataTable.Copy();

                                }
                                else
                                {
                                    object[] obj = new object[sampleInfoTable.Columns.Count];
                                    for (int i = 0; i < dataTable.Rows.Count; i++)
                                    {
                                        dataTable.Rows[i].ItemArray.CopyTo(obj, 0);
                                        sampleInfoTable.Rows.Add(obj);
                                    }
                                }
                                GCSampleInfo.DataSource = sampleInfoTable;
                                GVSampleInfo.ClearSelection();
                                GVSampleInfo.SelectRow(0);
                                GVSampleInfo.FocusedRowHandle = 0;
                                GVSampleInfo_RowClick(null, null);
                                GVSampleInfo.BestFitColumns();
                            }
                            else
                            {
                                MessageBox.Show("未找到标本信息。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            frmWait.HideMe(this);
                        }
                        else
                        {
                            MessageBox.Show("条码信息已存在。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("输入的条码信息有误！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择专业组信息！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                TEbarcode.SelectAll();
            }
        }

        private void TEhosBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (GEgroupNOs.EditValue != null)
            {
                if (TEhosBarcode.EditValue != null && TEhosBarcode.EditValue.ToString().Trim().Length > 0)
                {
                    FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载数据请稍等......");
                    //try
                    //{
                    ReceiveSelectModel receiveSelect = new ReceiveSelectModel();
                    receiveSelect.UserName = CommonData.UserInfo.names;
                    
                    receiveSelect.hosbarcode = TEhosBarcode.EditValue.ToString();
                    receiveSelect.groupNO = GEgroupNOs.EditValue.ToString();
                    string Sr = JsonHelper.SerializeObjct(receiveSelect);
                    WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveDT, Sr);
                    DataTable dataTable = JsonHelper.StringToDT(jm);
                    if (dataTable != null)
                    {
                        dataTable.Columns.Add("check", typeof(bool));
                        //data.Columns.Add("testID", typeof(string));
                        GCSampleInfo.DataSource = dataTable;
                    }
                    else
                    {
                        GCSampleInfo.DataSource = null;
                    }
                    GVSampleInfo.BestFitColumns();
                    frmWait.HideMe(this);
                    //}
                    //catch (Exception ex)
                    //{
                    //    frmWait.HideMe(this);
                    //    MessageBox.Show("没有需要处理的标本信息。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
                else
                {

                    MessageBox.Show("输入的外部条码信息有误！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请先选择专业组信息！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 补打条码方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTPrints_Click(object sender, EventArgs e)
        {

            bool checkState = true;
            int[] infos = GVSampleInfo.GetSelectedRows();

            for (int a = 0; a < GVSampleInfo.RowCount; a++)
            {
                if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
                {
                    if ((Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"])))
                    {
                        if (GVSampleInfo.GetDataRow(a)["testNo"] != DBNull.Value)
                        {
                            checkState = false;
                            DataRow dataRow = GVSampleInfo.GetDataRow(a);
                            printBarcode(dataRow);
                        }
                        else
                        {
                            MessageBox.Show(GVSampleInfo.GetDataRow(a)["barcode"].ToString() + ":样本号为空", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            if (checkState)
            {
                if (infos.Length > 0)
                {
                    foreach (int a in infos)
                    {
                        if (GVSampleInfo.GetDataRow(a)["testNo"] != DBNull.Value)
                        {
                            checkState = false;
                            DataRow dataRow = GVSampleInfo.GetDataRow(a);
                            printBarcode(dataRow);
                        }
                        else
                        {
                            MessageBox.Show(GVSampleInfo.GetDataRow(a)["barcode"].ToString() + ":样本号为空", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }
        private void printBarcode(DataRow sampleInfo)
        {
            try
            {


                BarTender.Application btApp = new BarTender.Application();
                BarTender.Format btFormat = new BarTender.Format();
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\CheckTemplateInfo\\SampleReceive.btw";
                if (File.Exists(filepath))
                {
                    btFormat = btApp.Formats.Open(AppDomain.CurrentDomain.BaseDirectory + "\\CheckTemplateInfo\\SampleReceive.btw", false, "");
                    //选择打印机
                    btFormat.Printer = CBPrintInfo.EditValue.ToString();

                    //设置打印份数
                    int CopiesOfLabel = 1;
                    btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;
                    if (sampleInfo["barcode"] != DBNull.Value)
                        btFormat.SetNamedSubStringValue("barcode", sampleInfo["testNo"].ToString());

                    if (sampleInfo["hospitalNames"] != DBNull.Value)
                        btFormat.SetNamedSubStringValue("hospitalNames", sampleInfo["hospitalNames"].ToString());


                    if (sampleInfo["patientName"] != DBNull.Value)
                        btFormat.SetNamedSubStringValue("patientName", sampleInfo["patientName"].ToString());


                    if (sampleInfo["patientSexNames"] != DBNull.Value)
                        btFormat.SetNamedSubStringValue("patientSexNames", sampleInfo["patientSexNames"].ToString());

                    if (sampleInfo["ageYear"] != DBNull.Value)
                        btFormat.SetNamedSubStringValue("ageYear", sampleInfo["ageYear"].ToString());


                    //if (sampleInfo["sampleID"] != DBNull.Value)
                    //    btFormat.SetNamedSubStringValue("sampleID", sampleInfo["id"].ToString());
                    if (sampleInfo["testNo"] != DBNull.Value|| sampleInfo["testNo"].ToString() != "")
                        btFormat.SetNamedSubStringValue("testNo", sampleInfo["testNo"].ToString());

                    if (sampleInfo["frameNo"] != DBNull.Value|| sampleInfo["frameNo"].ToString() != "")
                        btFormat.SetNamedSubStringValue("frameNo", sampleInfo["frameNo"].ToString());
                    if (sampleInfo["groupNO"] != DBNull.Value)
                    {
                        btFormat.SetNamedSubStringValue("groupNO", sampleInfo["groupNO"].ToString());
                        DataRow[] rows = WorkCommData.DTGroupTest.Select($"no='{sampleInfo["groupNO"]}'");
                        if (rows.Length > 0)
                        {
                            if (rows[0]["names"] != DBNull.Value)
                            {
                                btFormat.SetNamedSubStringValue("groupName", rows[0]["names"].ToString());
                            }
                        }
                    }

                    if (sampleInfo["groupCodes"] != DBNull.Value)
                        btFormat.SetNamedSubStringValue("groupCodes", sampleInfo["groupCodes"].ToString());


                    if (sampleInfo["groupNames"] != DBNull.Value)
                        btFormat.SetNamedSubStringValue("groupNames", sampleInfo["groupNames"].ToString());

                    //设置打印时是否跳出打印属性
                    btFormat.PrintOut(false, false);

                    //设置打印份数
                    //int CopiesOfLabel = shareNumbers;
                    //btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;
                    ////序列化打印时使用的
                    //btFormat.NumberSerializedLabels = Numbers;
                    ////向bartender模板传递变量,SN为条形码数据的一个共享名称
                    //string aaa = TEClientCode.EditValue.ToString() + SerialNo.ToString("0000000");
                    //btFormat.SetNamedSubStringValue("SN", TEClientCode.EditValue.ToString() + SerialNo.ToString("0000000"));
                    //btFormat.SetNamedSubStringValue("SC", TEclientNames.EditValue.ToString());
                    ////设置打印时是否跳出打印属性
                    //btFormat.PrintOut(false, false);

                    btFormat.Close(BarTender.BtSaveOptions.btDoNotSaveChanges);
                    btApp.Quit(BarTender.BtSaveOptions.btDoNotSaveChanges);




                }
                else
                {
                    MessageBox.Show($"未找到{filepath}文件模板", "系统提示");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #region hotKeys
        private void FrmReceiveSample_Enter(object sender, EventArgs e)
        {
            ////注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
            /////////////HotKeys.RegisterHotKey(Handle, 100, HotKeys.KeyModifiers.Shift, Keys.S);
            HotKeys.RegisterHotKey(Handle, 100, 0, Keys.F1);
            HotKeys.RegisterHotKey(Handle, 101, 0, Keys.F2);

        }



        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            //按快捷键 
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    switch (m.WParam.ToInt32())
                    {
                        case 100:  //按下的是F1
                            BTReceives_Click(null, null);
                            break;
                        case 101:  //按下的是F2
                            BTPrints_Click(null, null);
                            break;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        private void FrmReceiveSample_Leave(object sender, EventArgs e)
        {
            HotKeys.UnregisterHotKey(Handle, 100);
            //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
            HotKeys.UnregisterHotKey(Handle, 101);
        }

        #endregion hotKeys

        private void GEgroupNOs_EditValueChanged(object sender, EventArgs e)
        {
            TENOTabs.EditValue = "";
            TENOSerials.EditValue = 0;
            TEFrameTops.EditValue = "";
            TEFrameSerials.EditValue = 0;
        }
    }
}
