using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace workOther.ItemDelegate
{
    public partial class FrmDelegeteHandle : XtraForm
    {
        int infoID = 0;
        int testid = 0;
        string barcode = "";
        string itemCodes = "";
        public FrmDelegeteHandle(DataRow sampleInfo)
        {
            InitializeComponent();
            itemCodes = "";
            if (sampleInfo != null)
            {
                TEbarcode.ReadOnly = true;
                TEhosBarcode.ReadOnly = true;
                BTSelect.Enabled = false;
                //testid = sampleInfo["delid"] !=DBNull.Value? sampleInfo["delid"].ToString() :"";
                infoID = sampleInfo["delid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["delid"]) : 0;
                barcode = sampleInfo["barcode"] != DBNull.Value ? sampleInfo["barcode"].ToString() : "";
                testid = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;
                TEbarcode.EditValue = sampleInfo["barcode"];
                TEhosBarcode.EditValue = sampleInfo["hospitalBarcode"];
                TEhosiptalNo.EditValue = sampleInfo["hospitalNO"];
                TEhosName.EditValue = sampleInfo["hospitalNames"];
                TEpatientName.EditValue = sampleInfo["patientName"];
                TEsexName.EditValue = sampleInfo["patientSexNames"];
                TEageYear.EditValue = sampleInfo["ageYear"];
                GEgroupNO.EditValue = sampleInfo["groupNO"];
                DEsampleTime.EditValue = sampleInfo["sampleTime"];
                DEsendTime.EditValue = sampleInfo["receiveTime"];
                TEcreater.EditValue = sampleInfo["creater"];
                DEcreateTime.EditValue = sampleInfo["createTime"];
                TEreason.EditValue = sampleInfo["reason"];
                TErecord.EditValue = sampleInfo["record"];
                GEdelePersonNO.Text = sampleInfo["delePerson"] != DBNull.Value&& sampleInfo["delePerson"].ToString()=="" ? sampleInfo["delePerson"].ToString() : null;
                GEDelegateClient.EditValue = sampleInfo["delegateClientNO"];
                TEremark.EditValue = sampleInfo["remark"];
                itemCodes = sampleInfo["itemCodes"] != DBNull.Value ? sampleInfo["itemCodes"].ToString() : "";
                //DataTable groupInfo = WorkCommData.DTItemGroup.Select($"no in ({itemCodes})").CopyToDataTable();
                string sampleState = sampleInfo["delegateStateNO"] != DBNull.Value ? sampleInfo["delegateStateNO"].ToString() : "1";
                if (sampleState == "1" || sampleState == "2")
                {
                    CEOK.Checked = true; CENO.Checked = false;
                }
                if (sampleState == "3")
                {
                    CEOK.Checked = false; CENO.Checked = true;
                }





                DataTable ItemInfo = WorkCommData.DTItemTest.Select($"no in ({itemCodes})").CopyToDataTable();
                GCTestInfo.DataSource = ItemInfo;

            }
            //else
            //{

            //}


        }
        private void FrmDelegateTest_Load(object sender, EventArgs e)
        {

            GridLookUpEdites.Formats(GEDelegateClient);
            GridLookUpEdites.Formats(GEgroupNO);
            GridLookUpEdites.Formats(GEdelePersonNO);
            GEdelePersonNO.Properties.DataSource = DTHelper.DTEnable(CommonData.DTUserInfoAll);
            GEDelegateClient.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientDelegateInfo);




            GridLookUpEdites.Formats(RGEsampleTypeNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(RGEgroupNO);

            RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            GEgroupNO.Properties.DataSource = RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            getPrintInfo();
        }

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
            }
            catch
            {
                CBPrintInfo.EditValue = null;
            }
            //CBPrintList.SelectedIndex = 0;

        }
        private void BTSelect_Click(object sender, EventArgs e)
        {

        }

        private void BTprint_Click(object sender, EventArgs e)
        {

            if (CBPrintInfo.EditValue != null)
            {
                //DataRowView drv = (DataRowView)BS_Roads.Current;
                PrintingSystem ps = new PrintingSystem();
                //PrintableComponentLink link = new PrintableComponentLink(ps);
                PrintableComponentLink link = new PrintableComponentLink(ps);
                link.Component = layoutControl1;
                //link.Component = layoutControl1.print;



                link.Landscape = true;
                link.PaperKind = PaperKind.A5Extra;
                link.Margins = new Margins(20, 20, 80, 50);
                PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();
                //phf.Header.Content.AddRange(new string[] { "", drv["线路名"].ToString() + "站点信息表", "" });
                phf.Header.Content.AddRange(new string[] { "", "外送项目委托单", "" });
                phf.Header.Font = new System.Drawing.Font("宋体", 16, System.Drawing.FontStyle.Regular);
                phf.Header.LineAlignment = BrickAlignment.Center;
                phf.Footer.Content.Clear();
                phf.Footer.Content.AddRange(new string[] { $"委托单位:{GEDelegateClient.Text}   派送人:{GEdelePersonNO.Text}", "", $"打印人:{CommonData.UserInfo.names}       " + String.Format("打印时间: {0:g}", DateTime.Now) });
                phf.Footer.LineAlignment = BrickAlignment.Center;
                link.CreateDocument();
                link.ShowPreview();
            }
            else
            {
                MessageBox.Show("打印机不可用...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




            //layoutControl1.ShowPrintPreview();
        }
        deleInfo deleInfo;
        private void BTsave_Click(object sender, EventArgs e)
        {
            deleInfo = new deleInfo();
            if (CEOK.Checked)
            {
                if (GEDelegateClient.EditValue != null && GEDelegateClient.EditValue.ToString() != "")
                {
                    if (GEdelePersonNO.EditValue != null && GEdelePersonNO.EditValue.ToString() != "")
                    {


                        uInfo uInfo = new uInfo();
                        uInfo.TableName = "WorkOther.DelegeteRecord";
                        Dictionary<string, object> pairs = new Dictionary<string, object>();
                        //pairs.Add("testStateNO",4);
                        pairs.Add("delegateStateNO", 4);
                        pairs.Add("delegateClientNO", GEDelegateClient.EditValue);
                        pairs.Add("record", TErecord.EditValue);
                        pairs.Add("remark", TEremark.EditValue);
                        pairs.Add("delePerson", GEdelePersonNO.Text);
                        pairs.Add("checker", CommonData.UserInfo.names);
                        pairs.Add("checkTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        uInfo.MessageShow = 1;
                        uInfo.values = pairs;
                        uInfo.wheres = $"id='{infoID}'";
                        int a = ApiHelpers.postInfo(uInfo);
                        if (a == 1)
                        {
                            if (barcode != "" && testid != 0)
                            {
                                uInfo uInfo1 = new uInfo();
                                uInfo1.TableName = "WorkTest.SampleInfo";
                                Dictionary<string, object> pairs1 = new Dictionary<string, object>();
                                pairs1.Add("testStateNO", 5);
                                pairs1.Add("delegateState", 1);
                                uInfo1.values = pairs1;
                                uInfo1.wheres = $"barcode='{barcode}' and id='{testid}'";
                                uInfo1.MessageShow = 1;
                                int b = ApiHelpers.postInfo(uInfo1);
                                if (b == 1)
                                {
                                    uInfo uInfo2 = new uInfo();
                                    uInfo2.TableName = "WorkTest.SampleResult";
                                    Dictionary<string, object> pairs2 = new Dictionary<string, object>();
                                    //pairs2.Add("testStateNO", 5);
                                    pairs2.Add("delegateState", 1);
                                    pairs2.Add("delstateClientNO", GEDelegateClient.EditValue);
                                    uInfo2.values = pairs2;
                                    uInfo2.wheres = $"barcode='{barcode}' and testid='{testid}' and itemCodes in ({itemCodes})";
                                    uInfo2.MessageShow = 1;
                                    ApiHelpers.postInfo(uInfo2);
                                    this.Close();
                                }
                                //pairs1.Add("delegateStateNO", 2);
                                //pairs.Add("delegateClientNO", GEDelegateClient.EditValue);
                            }




                            deleInfo.record = TErecord.EditValue;
                            deleInfo.stateNO =4;
                            deleInfo.remark = TEremark.EditValue;
                            deleInfo.testStateNO = 5;
                            deleInfo.checker = CommonData.UserInfo.names;
                            deleInfo.delePerson = GEdelePersonNO.EditValue;
                            deleInfo.checkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择派送人！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("请选择委托医院！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (CENO.Checked)
            {
                uInfo uInfo = new uInfo();
                uInfo.TableName = "WorkOther.DelegeteRecord";
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("delegateStateNO", 3);
                pairs.Add("delegateClientNO", GEDelegateClient.EditValue);
                pairs.Add("record", TErecord.EditValue);
                pairs.Add("remark", TEremark.EditValue);
                pairs.Add("delePerson", GEdelePersonNO.Text);
                pairs.Add("checker", CommonData.UserInfo.names);
                pairs.Add("checkTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                uInfo.MessageShow = 1;
                uInfo.values = pairs;
                uInfo.wheres = $"testid='{infoID}'";
                int a = ApiHelpers.postInfo(uInfo);
                if (a == 1)
                {
                    deleInfo.record = TErecord.EditValue;
                    deleInfo.remark = TEremark.EditValue;
                    deleInfo.checker = CommonData.UserInfo.names;
                    deleInfo.stateNO = 3;
                    deleInfo.checkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    this.Close();
                }
            }
        }
        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CENO_CheckedChanged(object sender, EventArgs e)
        {
            if (CENO.Checked)
            {
                CEOK.Checked = false;
                GEDelegateClient.Enabled = false;
                GEDelegateClient.EditValue = null;
            }
        }

        private void CEOK_CheckedChanged(object sender, EventArgs e)
        {
            if (CEOK.Checked)
            {
                CENO.Checked = false;
                GEDelegateClient.Enabled = true;
            }
        }
        public deleInfo reinfo()
        {
            return deleInfo;
        }
    }
}
