using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.PerModel;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workOther.ItemHandle
{
    public partial class FrmItemInfo : XtraForm
    {




        string SampleInfoCheckBc = "";
        public FrmItemInfo()
        {

            InitializeComponent();
            SampleInfoCheckBc = ConfigInfos.ReadConfigInfo("SampleInfoCheckBc");
            getPrintInfo();
            DEstartTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEendTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GEStateNO.EditValue = 0;
            GridLookUpEdites.Formats(RGEStateNO);
            GridLookUpEdites.Formats(RGEStateNOs);
            GridLookUpEdites.Formats(RGEdelegateClientNO);
            GridLookUpEdites.Formats(RGEperStateNO);
            GridLookUpEdites.Formats(RGEhandleTypeNO);
            RGEhandleTypeNO.DataSource = OtherInfoData.DTHandleState;
            RGEStateNO.DataSource = DTHelper.DTAddAll(OtherInfoData.DTSubmitState);
            RGEStateNOs.DataSource = OtherInfoData.DTSubmitState;
            //RGEdelegateClientNO.DataSource = WorkCommData.DTClientDelegateInfo;
            RGEperStateNO.DataSource = WorkCommData.DTStatePerWork;
            GridControls.formartGridView(GVSampleInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);
            GridControls.ShowViewColor(GVSampleInfo);
            SysPowerHelper.UserPower(barManager1);


        }
        public void getPrintInfo()
        {
            try
            {
                //获取打印机
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    RCBPrint.Items.Add(printer);
                }
                PrintDocument fPrintDocument = new PrintDocument();    //获取默认打印机的方法
                CBPrint.EditValue = fPrintDocument.PrinterSettings.PrinterName;
                //CBPrintList.SelectedIndex = 0;
            }
            catch
            {
                CBPrint.EditValue = null;
            }
        }


        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkOther.SubmitInfoView";
            //string wheres = $" createTime>='{DEstartTime.EditValue}' and createTime<='{Convert.ToDateTime(DEendTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}' and recordTypeNO in ('3','4','5') and dstate=0";
            string wheres = $" createTime>='{DEstartTime.EditValue}' and createTime<='{Convert.ToDateTime(DEendTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}'  and dstate=0";
            if (Convert.ToInt32(GEStateNO.EditValue) != 0)
            {
                wheres += $"and recordTypeNO = '{GEStateNO.EditValue}'";
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
            GCSampleInfo.DataSource = dataTable;
            GVSampleInfo.BestFitColumns();
        }
        private void BTHandleInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BTHandleInfo.Enabled)
            {
                if (GVSampleInfo.GetFocusedDataRow() != null)
                {
                    DataRow sampleInfo = GVSampleInfo.GetFocusedDataRow();
                    //string recordTypeNO = sampleInfo["recordTypeNO"] != DBNull.Value ? sampleInfo["recordTypeNO"].ToString() : "";
                    //if(recordTypeNO=="1")
                    //{
                    FrmItemHandle frmTestHandle = new FrmItemHandle(sampleInfo);
                    Func<ReturnInfo> func = frmTestHandle.reinfo;
                    frmTestHandle.ShowDialog();
                    ReturnInfo deleInfo = func();
                    if (deleInfo != null)
                    {
                        if (deleInfo.handleTypeNO.ToString() != "0")
                        {
                            GVSampleInfo.SetFocusedRowCellValue("handler", deleInfo.handler);
                            GVSampleInfo.SetFocusedRowCellValue("handleTime", deleInfo.handleTime);
                            GVSampleInfo.SetFocusedRowCellValue("handleResult", deleInfo.handleResult);
                            GVSampleInfo.SetFocusedRowCellValue("remark", deleInfo.remark);
                            GVSampleInfo.SetFocusedRowCellValue("handleTypeNO", deleInfo.handleTypeNO);
                            sampleInfo["state"] = deleInfo.state;
                            if (deleInfo.testStateNO.ToString() != "0")
                            {
                                GVSampleInfo.SetFocusedRowCellValue("testStateNO", deleInfo.testStateNO);

                            }
                            GVSampleInfo.BestFitColumns();
                        }
                        //else
                        //{
                        //    MessageBox.Show(deleInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
            }



        }


        private void GVdelegateInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void GVdelegateInfo_DoubleClick(object sender, EventArgs e)
        {
            BTHandleInfo_ItemClick(null, null);
        }


        private void BTImg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {

                string barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                sInfo selectInfoImg = new sInfo();
                selectInfoImg.values = "top 1 *";
                selectInfoImg.TableName = "WorkPer.SampleImg";
                selectInfoImg.wheres = $"barcode='{barcode}' and dstate=0 and state=1";
                selectInfoImg.OrderColumns = "createTime desc";
                DataTable dataTableImg = ApiHelpers.postInfo(selectInfoImg);
                if (dataTableImg != null)
                {
                    if (dataTableImg.Rows.Count > 0)
                    {
                        if (dataTableImg.Rows[0]["filestring"] != DBNull.Value)
                        {
                            string SImgString = dataTableImg.Rows[0]["filestring"].ToString();
                            if (SImgString != "")
                            {
                                Bitmap CameraImage = FileConverHelpers.StringToBitmap(SImgString);
                                ShowImgHelper.ViewOrignalImage(CameraImage);
                            }
                            else
                            {
                                MessageBox.Show("未找到匹配的原始单图片！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("未找到匹配的原始单图片！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("未找到匹配的原始单图片！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("未找到匹配的原始单图片！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("未找到匹配的原始单图片！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BTBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    int[] samplesDt = GVSampleInfo.GetSelectedRows();
            //    string resultInfo = "";
            //    bool checkState = true;//判断是否用check字段进行审核

            //    for (int a = 0; a < GVSampleInfo.RowCount; a++)
            //    {

            //        if (GVSampleInfo.GetDataRow(a)["check"] != DBNull.Value)
            //        {

            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                //DataRow dataRow = GVSampleInfo.GetDataRow(a);
                //if (Convert.ToBoolean(dataRow["check"]))
                //{
                //checkState = false;
                if (dataRow["barcode"] != DBNull.Value)
                {


                        CheckInfoModel checkInfoModel = new CheckInfoModel();
                        checkInfoModel.UserName = CommonData.UserInfo.names;
                        
                        List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();
                        CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
                        sampleInfo.perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
                        sampleInfo.testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                        sampleInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                        sampleList.Add(sampleInfo);
                        checkInfoModel.checkSampleInfos = sampleList;
                        string Sr = JsonHelper.SerializeObjct(checkInfoModel);
                        WebApiCallBack jm=ApiHelpers.postInfo(SampleInfoCheckBc, Sr);

                    commReInfo<CheckGroupBarcode> CheckCodeModelModel = JsonHelper.JsonConvertObject<commReInfo<CheckGroupBarcode>>(jm);
                    if (CheckCodeModelModel.code == 1)
                    {
                        foreach (CheckGroupBarcode groupBarcode in CheckCodeModelModel.infos)
                        {
                            printBarcode(groupBarcode);
                        }
                    }
                    else
                    {
                        MessageBox.Show(CheckCodeModelModel.msg, "系统提示");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需要打印的样本信息", "系统提示");
            }


            //        }
            //    }
            //    if (checkState)
            //    {
            //        foreach (int a in samplesDt)
            //        {
            //            DataRow dataRow = GVSampleInfo.GetDataRow(a);
            //            if (dataRow["barcode"] != DBNull.Value)
            //            {

            //                Task<string> task = new Task<string>(() =>
            //                {


            //                    CheckInfoModel checkInfoModel = new CheckInfoModel();
            //                    checkInfoModel.UserName = CommonData.UserInfo.names;
            //                    
            //                    List<CheckSampleInfoModel> sampleList = new List<CheckSampleInfoModel>();
            //                    CheckSampleInfoModel sampleInfo = new CheckSampleInfoModel();
            //                    sampleInfo.perid = dataRow["perid"] != DBNull.Value ? Convert.ToInt32(dataRow["perid"]) : 0;
            //                    sampleInfo.testid = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
            //                    sampleInfo.barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
            //                    sampleList.Add(sampleInfo);
            //                    checkInfoModel.checkSampleInfos = sampleList;
            //                    string Sr = JsonHelper.SerializeObjct(checkInfoModel);
            //                    return ApiHelpers.postInfo(SampleInfoCheckBc, Sr);
            //                });
            //                task.Start();
            //                task.Wait();
            //                string s = task.Result;

            //                commReInfo<CheckGroupBarcode> CheckCodeModelModel = JsonHelper.JsonConvertObject<commReInfo<CheckGroupBarcode>>(jm);
            //                if (CheckCodeModelModel.code == 1)
            //                {
            //                    foreach (CheckGroupBarcode groupBarcode in CheckCodeModelModel.infos)
            //                    {
            //                        printBarcode(groupBarcode);
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show(CheckCodeModelModel.msg, "系统提示");
            //                }
            //            }
            //        }
            //    }

            //    if (resultInfo != "")
            //        MessageBox.Show(resultInfo, "系统提示");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void printBarcode(CheckGroupBarcode groupBarcode)
        {
            try
            {


                BarTender.Application btApp = new BarTender.Application();
                BarTender.Format btFormat = new BarTender.Format();
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\CheckTemplateInfo\\SampleCheck.btw";
                if (File.Exists(filepath))
                {
                    btFormat = btApp.Formats.Open(AppDomain.CurrentDomain.BaseDirectory + "\\CheckTemplateInfo\\SampleCheck.btw", false, "");
                    //选择打印机
                    btFormat.Printer = CBPrint.EditValue.ToString();

                    //设置打印份数
                    int CopiesOfLabel = 1;
                    btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;
                    if (groupBarcode.barcode != null)
                        btFormat.SetNamedSubStringValue("barcode", groupBarcode.barcode);
                    if (groupBarcode.hospitalNames != null)
                        btFormat.SetNamedSubStringValue("hospitalNames", groupBarcode.hospitalNames);
                    if (groupBarcode.patientName != null)
                        btFormat.SetNamedSubStringValue("patientName", groupBarcode.patientName);
                    if (groupBarcode.patientSexNames != null)
                        btFormat.SetNamedSubStringValue("patientSexNames", groupBarcode.patientSexNames);
                    if (groupBarcode.ageYear != null)
                        btFormat.SetNamedSubStringValue("ageYear", groupBarcode.ageYear);
#pragma warning disable CS0472 // 由于“int”类型的值永不等于“int?”类型的 "null"，该表达式的结果始终为“true”
                    if (groupBarcode.sampleID != null)
#pragma warning restore CS0472 // 由于“int”类型的值永不等于“int?”类型的 "null"，该表达式的结果始终为“true”
                        btFormat.SetNamedSubStringValue("sampleID", groupBarcode.sampleID.ToString());
                    if (groupBarcode.groupNO != null)
                    {
                        btFormat.SetNamedSubStringValue("groupNO", groupBarcode.groupNO);
                        DataRow[] rows = WorkCommData.DTGroupTest.Select($"no='{groupBarcode.groupNO}'");
                        if (rows.Length > 0)
                        {
                            if (rows[0]["names"] != DBNull.Value)
                            {
                                btFormat.SetNamedSubStringValue("groupName", rows[0]["names"].ToString());
                            }
                        }
                    }
                    if (groupBarcode.groupName != null)
                        btFormat.SetNamedSubStringValue("groupName", groupBarcode.groupName);
                    if (groupBarcode.groupCodes != null)
                        btFormat.SetNamedSubStringValue("groupCodes", groupBarcode.groupCodes);
                    if (groupBarcode.groupNames != null)
                        btFormat.SetNamedSubStringValue("groupNames", groupBarcode.groupNames);

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

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVSampleInfo.GetFocusedDataRow();
            if (dataRow != null)
            {

                string subState = dataRow["recordTypeNO"] != DBNull.Value ? dataRow["recordTypeNO"].ToString() : "";
                string handleTypeNO = dataRow["handleTypeNO"] != DBNull.Value ? dataRow["handleTypeNO"].ToString() : "1";
                if (handleTypeNO != "2")
                {
                    if (subState != "")
                    {
                        switch (subState)
                        {
                            case "4":
                                FrmPerAdd frmTestAdd = new FrmPerAdd(dataRow, "2");
                                frmTestAdd.ShowDialog();
                                break;
                            case "5":
                                FrmPerCancel frmTestCancel = new FrmPerCancel(dataRow, "2");
                                frmTestCancel.ShowDialog();
                                break;
                            default:
                                FrmPerCancel frmTestCancel2 = new FrmPerCancel(dataRow, "2");
                                frmTestCancel2.ShowDialog();
                                break;
                        }
                        BTSelect_ItemClick(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("不能修改已完成处理的信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
