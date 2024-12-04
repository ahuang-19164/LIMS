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

namespace Perwork.SampleSort
{
    public partial class FrmSampleSort : DevExpress.XtraEditors.XtraForm
    {
        
        //string GroupID;
        string SampleSortDT = "";
        string SampleSortInfo = "";
        public FrmSampleSort()
        {


            //GroupID = GroupNO;
            string GroupNO = null;
            SampleSortDT = ConfigInfos.ReadConfigInfo("SampleSortDT");
            SampleSortInfo = ConfigInfos.ReadConfigInfo("SampleSortInfo");

            InitializeComponent();
            DEStartTimes.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEEndTimes.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            TEbarcode.Enabled = false;



        }

        private void FrmReceiveSample_Load(object sender, EventArgs e)
        {

            getPrintInfo();

            GridControls.formartGridView(GVSampleInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);
            GridControls.ShowViewColor(GVSampleInfo);

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
            GridLookUpEdites.Formats(RGEGroupNO,WorkCommData.DTGroupTest);
            GridLookUpEdites.Formats(RGEperStateNO,WorkCommData.DTStatePerWork);



            //SysPowerHelper.UserPower(barManager1);



            //BTSelect_ItemClick(null,null);
        }

        /// <summary>
        /// 全选方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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




        #region 查询样本信息方法

        DataSet DSSample =null;//样本信息【0】录入信息，【1】检验分组信息
        DataTable DTperInfo = null;
        DataTable DTtestInfo = null;//检验信息
        /// <summary>
        /// 按钮查询样本信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTSelects_Click(object sender, EventArgs e)
        {

            
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载数据请稍等......");
            try
            {
                DTperInfo = null;
                DTtestInfo = null;//检验信息

                if (CESelectState.Checked)
                {
                    DSSample = null;
                    CECheckAll.Checked = false;
                    SortSelectModel sampleSort = new SortSelectModel();
                    sampleSort.UserName = CommonData.UserInfo.names;

                    sampleSort.startTime = Convert.ToDateTime(DEStartTimes.EditValue).ToString("yyyy-MM-dd");
                    sampleSort.endTime = Convert.ToDateTime(DEEndTimes.EditValue).AddDays(+1).ToString("yyyy-MM-dd");
                    string Sr = JsonHelper.SerializeObjct(sampleSort);
                    WebApiCallBack jm = ApiHelpers.postInfo(SampleSortDT, Sr);
                    DTperInfo = JsonHelper.StringToDT(jm.data.ToString());
                    DTtestInfo = JsonHelper.StringToDT(jm.otherData.ToString()); ;
                    if (DTperInfo == null)
                    {
                        MessageBox.Show("未找到标本信息。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DTperInfo.Columns.Add("check", typeof(bool));
                        GCSampleInfo.DataSource = DTperInfo;
                        GVSampleInfo.BestFitColumns();
                    }
                    BTSelects.Enabled = true;

                }
                else
                {
                    if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString().Trim().Length > 0)
                    {

                        bool receiveState = true;
                        if (DTtestInfo != null)
                        {
                            foreach (DataRow dataRow in DTtestInfo.Rows)
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
                        if (receiveState)
                        {
                            SortSelectModel sampleSortModel = new SortSelectModel();
                            sampleSortModel.UserName = CommonData.UserInfo.names;
                            sampleSortModel.barcode = TEbarcode.EditValue.ToString().Trim();
                            string Sr = JsonHelper.SerializeObjct(sampleSortModel);
                            WebApiCallBack jm = ApiHelpers.postInfo(SampleSortDT, Sr);
                            DTperInfo = JsonHelper.StringToDT(jm.data.ToString());
                            DTtestInfo = JsonHelper.StringToDT(jm.otherData.ToString()); ;
                            if (DTperInfo == null)
                            {
                                MessageBox.Show("未找到标本信息。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                              else
                            {
                                DTperInfo.Columns.Add("check", typeof(bool));
                                GCSampleInfo.DataSource = DTperInfo;
                                GCGroupInfo.DataSource = DTtestInfo;
                                //GVSampleInfo.ClearSelection();
                                //GVSampleInfo.SelectRow(0);
                                //GVSampleInfo.FocusedRowHandle = 0;
                                GVSampleInfo.BestFitColumns();
                            }




                            //if (DTperInfo == null)
                            //{
                            //    DTtestInfo = dataTable.Copy();
                            //}
                            //else
                            //{
                            //    object[] obj = new object[DTtestInfo.Columns.Count];
                            //    for (int i = 0; i < dataTable.Rows.Count; i++)
                            //    {
                            //        dataTable.Rows[i].ItemArray.CopyTo(obj, 0);
                            //        DTtestInfo.Rows.Add(obj);
                            //    }
                            //}


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
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmWait.HideMe(this);
            }
            frmWait.HideMe(this);

        }
        /// <summary>
        /// 条码对话框回车查询样本信息方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TEbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//这是允许输入退格键
            {

                if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString().Trim().Length > 0)
                {

                    bool receiveState = true;
                    if (DTtestInfo != null)
                    {
                        foreach (DataRow dataRow in DTtestInfo.Rows)
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

                    if (receiveState)
                    {
                        FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载数据请稍等......");
                        SortSelectModel sampleSortModel = new SortSelectModel();
                        sampleSortModel.UserName = CommonData.UserInfo.names;
                        sampleSortModel.barcode = TEbarcode.EditValue.ToString().Trim();
                        string Sr = JsonHelper.SerializeObjct(sampleSortModel);
                        WebApiCallBack jm = ApiHelpers.postInfo(SampleSortDT, Sr);
                        DTperInfo = JsonHelper.StringToDT(jm.data.ToString());
                        DTtestInfo = JsonHelper.StringToDT(jm.otherData.ToString()); ;
                        if (DTperInfo == null)
                        {
                            MessageBox.Show("未找到标本信息。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DTperInfo.Columns.Add("check", typeof(bool));
                            GCSampleInfo.DataSource = DTperInfo;
                            GCGroupInfo.DataSource = DTtestInfo;
                            //GVSampleInfo.ClearSelection();
                            //GVSampleInfo.SelectRow(0);
                            //GVSampleInfo.FocusedRowHandle = 0;
                            GVSampleInfo.BestFitColumns();
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

                TEbarcode.SelectAll();
            }
        }


        #endregion


        private void BTSort_Click(object sender, EventArgs e)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在处理接收信息，请稍等......");
            BTSort.Enabled = false;
            try
            {
                if (CESelectState.Checked || CEScanState.Checked)
                {
                    //GVSampleInfo.FocusedRowHandle = -1;

                    int[] samplesDt = GVSampleInfo.GetSelectedRows();

                    string msg = "";

                    bool checkState = true;//判断是否用check字段进行审核



                    for (int a = 0; a < GVSampleInfo.RowCount; a++)
                    {

                        SortInfoModel sampleSortInfoModel = new SortInfoModel();
                        sampleSortInfoModel.UserName = CommonData.UserInfo.names;
                        List<SampleInfoSortModel> sampleSortInfos = new List<SampleInfoSortModel>();


                        DataRow dataRow = GVSampleInfo.GetDataRow(a);
                        #region

                        sampleSortInfoModel.sampleSortInfos = sampleSortInfos;
                        bool sampleState = dataRow["state"] != DBNull.Value ? Convert.ToBoolean(dataRow["state"]) : false;
                        if (sampleState)
                        {
                            if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
                            {
                                if (Convert.ToBoolean(GVSampleInfo.GetDataRow(a)["check"]))
                                {
                                    SampleInfoSortModel sampleSortInfo = new SampleInfoSortModel();
                                    checkState = false;
                                    sampleSortInfo.perid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                                    sampleSortInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                                    sampleSortInfos.Add(sampleSortInfo);
                                }
                            }
                            if (sampleSortInfos.Count > 0)
                            {
                                string Sr = JsonHelper.SerializeObjct(sampleSortInfoModel);
                                WebApiCallBack jm = ApiHelpers.postInfo(SampleSortInfo, Sr);
                                commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                                if (commReInfo != null)
                                {
                                    foreach (commReSampleInfo sampleInfo in commReInfo.infos)
                                    {
                                        if (sampleInfo.code == 0)
                                        {

                                            GVSampleInfo.SetRowCellValue(a, "sortState", true);
                                            //foreach (int r in samplesDt)
                                            //{
                                            //    string barcode = GVSampleInfo.GetDataRow(r)["barcode"].ToString();
                                            //    if (sampleInfo.barcode == barcode)
                                            //        GVSampleInfo.SetRowCellValue(r, "sortState", true);
                                            //}
                                        }
                                        else
                                        {
                                            msg += sampleInfo.msg + "\r\n";
                                        }

                                    }
                                }

                            }
                        }
                        #endregion
                    }
                    frmWait.HideMe(this);
                    if (msg == "")
                    {
                        
                        //MessageBox.Show("分拣完成！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                BTSort.Enabled = true;
            }
            catch (Exception ex)
            {
                frmWait.HideMe(this);
                BTSort.Enabled = true;
                MessageBox.Show(ex.ToString(), "系统提示");
            }

        }


        #region gcinfo方法

        private void GVSampleInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {

                string perBarcode = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "";
                if(CESelectState.Checked)
                {
                    GCGroupInfo.DataSource = DTtestInfo.Select($"perid='{perBarcode}'").CopyToDataTable();
                }
                else
                {
                    FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this, "", "正在加载数据请稍等......");
                    SortSelectModel sampleSortModel = new SortSelectModel();
                    sampleSortModel.UserName = CommonData.UserInfo.names;
                    sampleSortModel.barcode = dataRow["barcode"]!=DBNull.Value? dataRow["barcode"].ToString():"";
                    string Sr = JsonHelper.SerializeObjct(sampleSortModel);
                    if(sampleSortModel.barcode!="")
                    {
                        WebApiCallBack jm = ApiHelpers.postInfo(SampleSortDT, Sr);
                        DTperInfo = JsonHelper.StringToDT(jm.data.ToString());
                        DTtestInfo = JsonHelper.StringToDT(jm.otherData.ToString()); ;
                        if (DTtestInfo != null)
                            GCGroupInfo.DataSource = DTtestInfo;
                    }
                }
                    

            }
            else
            {
                GCGroupInfo.DataSource = null;
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
            if (GVSampleInfo.GetRowCellValue(e.RowHandle, "sortState") != DBNull.Value)
            {
                if (Convert.ToBoolean(GVSampleInfo.GetRowCellValue(e.RowHandle, "sortState")))
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
#endregion

        #region 接收方式
        private void CESelectState_CheckedChanged(object sender, EventArgs e)
        {
            DSSample = null;

            if (CESelectState.Checked)
            {
                DTtestInfo = null;
                CEScanState.Checked = false;
                TEbarcode.Enabled = false;
                BTSelects.Enabled = true;

            }
            GCSampleInfo.DataSource = null;
            GCGroupInfo.DataSource = null;
        }

        private void CEScanState_CheckedChanged(object sender, EventArgs e)
        {
            DSSample = null;

            if (CEScanState.Checked)
            {
                DTtestInfo = null;
                CESelectState.Checked = false;
                TEbarcode.Enabled = true;
                BTSelects.Enabled = false;
            }
            GCSampleInfo.DataSource = null;
            GCGroupInfo.DataSource = null;
        }
        #endregion




        #region 打印条码

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

                        checkState = false;
                        DataRow dataRow = GVSampleInfo.GetDataRow(a);
                        string perBarcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                        DataRow[] DRgroupInfos = DTtestInfo.Select($"barcode='{perBarcode}'");
                        printBarcode(DRgroupInfos);
                    }
                }
            }
            if (checkState)
            {
                if (infos.Length > 0)
                {
                    foreach (int a in infos)
                    {

                        checkState = false;
                        DataRow dataRow = GVSampleInfo.GetDataRow(a);
                        string perBarcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                        DataRow[] DRgroupInfos = DTtestInfo.Select($"barcode='{perBarcode}'");
                        printBarcode(DRgroupInfos);

                    }
                }
            }
        }





        private void printBarcode(DataRow[] sampleInfos)
        {
            try
            {
                foreach(DataRow sampleInfo in sampleInfos)
                {
                    BarTender.Application btApp = new BarTender.Application();
                    BarTender.Format btFormat = new BarTender.Format();
                    string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\CheckTemplateInfo\\SampleSort.btw";
                    if (File.Exists(filepath))
                    {
                        btFormat = btApp.Formats.Open(filepath, false, "");
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


                        ////if (sampleInfo["sampleID"] != DBNull.Value)
                        ////    btFormat.SetNamedSubStringValue("sampleID", sampleInfo["id"].ToString());
                        //if (sampleInfo["testNo"] != DBNull.Value || sampleInfo["testNo"].ToString() != "")
                        //    btFormat.SetNamedSubStringValue("testNo", sampleInfo["testNo"].ToString());

                        //if (sampleInfo["frameNo"] != DBNull.Value || sampleInfo["frameNo"].ToString() != "")
                        //    btFormat.SetNamedSubStringValue("frameNo", sampleInfo["frameNo"].ToString());
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


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

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
                            BTSort_Click(null, null);
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


    }
}
