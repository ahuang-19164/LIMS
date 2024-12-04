using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.logisticsInfos
{
    public partial class FrmLogisticsBarcode : DevExpress.XtraEditors.XtraForm
    {
        int selectID = 0;
        int Sno = 0;//流水号记录
        public FrmLogisticsBarcode()
        {
            InitializeComponent();
            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);

            TextEdits.TextFormat(TEshareNumbers);
            TextEdits.TextFormat(TENumbers);
            TextEdits.TextFormat(TEBarcodeNumbers);
            TextEdits.TextFormat(TESerialNo);
        }
        private void FrmLogisticsBarcode_Load(object sender, EventArgs e)
        {
            GCInfo.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            GVInfo.BestFitColumns();
            getPrintInfo();
            getTemplateInfo();
            CBtemplate.SelectedIndex = 0;
        }
        public void getPrintInfo()
        {
            //获取打印机
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                CBPrintList.Properties.Items.Add(printer);
            }
            PrintDocument fPrintDocument = new PrintDocument();    //获取默认打印机的方法
            CBPrintList.Text = fPrintDocument.PrinterSettings.PrinterName;
            //CBPrintList.SelectedIndex = 0;

        }
        /// <summary>
        /// 读取条码模板信息
        /// </summary>
        public void getTemplateInfo()
        {
            string FileDirectory = Application.StartupPath + "\\BarCodeTemplateInfo";
            if (Directory.Exists(FileDirectory))
            {
                DirectoryInfo root = new DirectoryInfo(FileDirectory);
                foreach (FileInfo f in root.GetFiles())
                {

                    string name = f.Name;
                    string fullName = f.FullName;
                    string ename = f.Extension;
                    if (ename == ".btw")
                    {
                        CBtemplate.Properties.Items.Add(name);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(FileDirectory);
            }
        }


        //private static BarTender.Application btApp = new BarTender.Application();
        //private static BarTender.Format btFormat = new BarTender.Format();

        private void BTPrint_Click(object sender, EventArgs e)
        {
            if (CBPrintList.EditValue != null && CBtemplate.EditValue != null)
            {
                if (CBPrintList.Text != "" && CBtemplate.Text != "")
                {


                    if (TEclientNames.EditValue != null && TEClientCode.EditValue != null)
                    {
                        if (TEclientNames.EditValue.ToString() != "" && TEClientCode.EditValue.ToString() != "")
                        {

                            if (TESerialNo.EditValue != null && TEshareNumbers.EditValue != null && TENumbers.EditValue != null)
                            {
                                if (TESerialNo.EditValue.ToString() != "" && TEshareNumbers.EditValue.ToString() != "" && TENumbers.EditValue.ToString() != "")
                                {
                                    int SerialNo = Convert.ToInt32(TESerialNo.EditValue);//流水号
                                    int shareNumbers = Convert.ToInt32(TEshareNumbers.EditValue);//打印份数
                                    int Numbers = Convert.ToInt32(TENumbers.EditValue);//打印数量
                                    iInfo insertInfo = new iInfo();
                                    insertInfo.TableName = "WorkComm.ClientBarcodeLog";
                                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    //pairs.Add("id", TEid.EditValue);
                                    pairs.Add("operater", CommonData.UserInfo.names);
                                    //pairs.Add("operater", TEoperater.EditValue);
                                    pairs.Add("hospitalNO", TEClientCode.EditValue.ToString());
                                    pairs.Add("logInfo", $"打印流水号：{shareNumbers}-{Numbers}");
                                    pairs.Add("operatType", "打印条码");
                                    insertInfo.values = pairs;
                                    insertInfo.MessageShow = 1;
                                    int i = ApiHelpers.postInfo(insertInfo);
                                    try
                                    {
                                        BarTender.Application btApp = new BarTender.Application();
                                        BarTender.Format btFormat = new BarTender.Format();
                                        btFormat = btApp.Formats.Open(AppDomain.CurrentDomain.BaseDirectory + "\\BarCodeTemplateInfo\\" + CBtemplate.Text, false, "");
                                        //选择打印机
                                        btFormat.Printer = CBPrintList.Text;
                                        for (int a = 1; a <= Numbers; a++)
                                        {
                                            //设置打印份数
                                            int CopiesOfLabel = shareNumbers;
                                            btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;

                                            int aa = SerialNo + a;


                                            //向bartender模板传递变量,SN为条形码数据的一个共享名称
                                            string aaa = TEClientCode.EditValue.ToString() + aa.ToString("000000");
                                            btFormat.SetNamedSubStringValue("SN", aaa);
                                            btFormat.SetNamedSubStringValue("SC", TEclientNames.EditValue.ToString());
                                            //设置打印时是否跳出打印属性
                                            btFormat.PrintOut(false, false);
                                        }
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


                                        SetSerialNo(SerialNo + Numbers);
                                        TESerialNo.EditValue = SerialNo + Numbers;
                                        WorkCommData.DTClientInfo.Select($"no='{TEClientCode.EditValue}'")[0]["serialNo"] = SerialNo + Numbers;
                                        GVInfo.SetFocusedRowCellValue("serialNo", SerialNo + Numbers);



                                        //}
                                        //退出时是否保存标签
                                        btFormat.Close();

                                        //btFormat.Close(BarTender.BtSaveOptions.btSaveChanges);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("错误信息: " + ex.Message);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("流水号和打印份数不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("流水号和打印份数不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("请选择需要打印条码的客户！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择需要打印条码的客户！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("请选择打印机和打印模板！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("请选择打印机和打印模板！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BTrepairBarcode_Click(object sender, EventArgs e)
        {
            if (CBPrintList.EditValue != null && CBtemplate.EditValue != null)
            {
                if (CBPrintList.Text != "" && CBtemplate.Text != "")
                {
                    if (TErepairBarcode.EditValue != null && TEBarcodeNumbers.EditValue != null)
                    {
                        if (TErepairBarcode.EditValue.ToString() != "" && TEBarcodeNumbers.EditValue.ToString() != "")
                        {
                            int BarcodeNumbers = Convert.ToInt32(TEBarcodeNumbers.EditValue);
                            string barcode = TErepairBarcode.EditValue.ToString();
                            string clientname = "";

                            string hosptilcode = barcode.Substring(0, 5);
                            DataRow[] dataRow = WorkCommData.DTClientInfo.Select($"no='{hosptilcode}'");
                            if (dataRow.Count() > 0)
                            {
                                clientname = dataRow[0]["names"].ToString();
                            }

                            try
                            {
                                iInfo insertInfo = new iInfo();
                                insertInfo.TableName = "WorkComm.ClientBarcodeLog";
                                Dictionary<string, object> pairs = new Dictionary<string, object>();
                                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                //pairs.Add("id", TEid.EditValue);
                                pairs.Add("operater", CommonData.UserInfo.names);
                                //pairs.Add("operater", TEoperater.EditValue);
                                pairs.Add("hospitalNO", hosptilcode);
                                pairs.Add("logInfo", $"补打条码号：{barcode}");
                                pairs.Add("operatType", "补打条码");
                                insertInfo.values = pairs;
                                insertInfo.MessageShow = 1;
                                int i = ApiHelpers.postInfo(insertInfo);



                                BarTender.Application btApp = new BarTender.Application();
                                BarTender.Format btFormat = new BarTender.Format();
                                btFormat = btApp.Formats.Open(AppDomain.CurrentDomain.BaseDirectory + "\\BarCodeTemplateInfo\\" + CBtemplate.Text, false, "");

                                //向bartender模板传递变量,SN为条形码数据的一个共享名称
                                btFormat.SetNamedSubStringValue("SN", barcode);
                                btFormat.SetNamedSubStringValue("SC", clientname);

                                //选择打印机
                                btFormat.Printer = CBPrintList.Text;

                                //设置打印份数
                                //int CopiesOfLabel = Int32.Parse(TENumbers.EditValue.ToString());
                                int CopiesOfLabel = BarcodeNumbers;
                                btFormat.IdenticalCopiesOfLabel = CopiesOfLabel;

                                //设置打印时是否跳出打印属性
                                btFormat.PrintOut(false, false);

                                //退出时是否保存标签
                                btFormat.Close();
                                //btFormat.Close(BarTender.BtSaveOptions.btSaveChanges);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("错误信息: " + ex.Message);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("请填写补打条码和份数！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请填写补打条码和份数！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("请选择打印机和打印模板！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请选择打印机和打印模板！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GVInfo_Click(object sender, EventArgs e)
        {
            if (GVInfo.GetFocusedDataRow() != null)
            {
                DataRow dataRow = GVInfo.GetFocusedDataRow();
                selectID = Convert.ToInt32(dataRow["id"]);
                TEclientNames.EditValue = dataRow["names"];
                TEClientCode.EditValue = dataRow["no"];
                TESerialNo.EditValue = dataRow["serialNo"];
                if (dataRow["serialNo"] != DBNull.Value)
                {
                    if (dataRow["serialNo"].ToString().Length > 0)
                    {
                        Sno = Convert.ToInt32(dataRow["serialNo"]);
                    }
                }

            }
        }
        //重置流水号
        private void TEResetCode_Click(object sender, EventArgs e)
        {
            if (TESerialNo.EditValue != null)
            {
                if (TESerialNo.EditValue.ToString() != "")
                {
                    SetSerialNo(Convert.ToInt32(TESerialNo.EditValue));
                    WorkCommData.DTClientInfo.Select($"no='{TEClientCode.EditValue}'")[0]["serialNo"] = TESerialNo.EditValue;
                    GVInfo.SetFocusedRowCellValue("serialNo", TESerialNo.EditValue);

                    iInfo insertInfo = new iInfo();
                    insertInfo.TableName = "WorkComm.ClientBarcodeLog";
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //pairs.Add("id", TEid.EditValue);
                    pairs.Add("operater", CommonData.UserInfo.names);
                    //pairs.Add("operater", TEoperater.EditValue);
                    pairs.Add("hospitalNO", TEClientCode.EditValue);
                    pairs.Add("logInfo", $"条码号重置：由{Sno}重置为{TESerialNo.EditValue}");
                    pairs.Add("operatType", "条码重置");
                    insertInfo.values = pairs;
                    insertInfo.MessageShow = 1;
                    int i = ApiHelpers.postInfo(insertInfo);

                }
            }
        }

        public void SetSerialNo(int value)
        {

            uInfo updateInfo = new uInfo();
            updateInfo.TableName = "WorkComm.ClientInfo";
            updateInfo.value = $"serialNo={value}";
            updateInfo.DataValueID = selectID;
            updateInfo.MessageShow = 1;
            int i = ApiHelpers.postInfo(updateInfo);
        }
    }
}
