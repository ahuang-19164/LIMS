using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.ExcelHandle;
using Common.Log;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Perwork.SampleInfos
{
    public partial class FrmSampleInfoExcel : DevExpress.XtraEditors.XtraForm
    {
        string filePath = null;
        string FileClassa = "";//文件信息类型
        ExcelHelper excelHelper = new ExcelHelper();
        
        public FrmSampleInfoExcel()
        {
            InitializeComponent();

            BTSampleTakeTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            GridControls.formartGridView(GVSampleInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);





            GridControls.formartGridView(GVapplyInfo);
            GridControls.formartGridView(GVcheckInfo);
            GridControls.showEmbeddedNavigator(GCapplyInfo);
            GridControls.showEmbeddedNavigator(GCcheckInfo);


            //CheckForIllegalCrossThreadCalls = false;
        }
        private void FrmSampleInfoExcel_Load(object sender, EventArgs e)
        {

            SysPowerHelper.UserPower(barManager1);
            GCapplyInfo.DataSource = DTHelper.DTEnable(WorkCommData.DTItemApply);
            DTcheckInfo = WorkCommData.DTItemApply.Clone();
            GCcheckInfo.DataSource = DTcheckInfo;
            GVapplyInfo.BestFitColumns();


        }
        private void BTImportInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            string tablenames = tablename;
            FrmImportConfigInfo frmImportConfig = new FrmImportConfigInfo(tablenames);
            frmImportConfig.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("系统错误！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    CommonLogText.WriteLog(this.Text, ex.ToString());
            //}


        }

        private void BTSelectFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //try
            //{
            FileClassa = "";//重置文件信息
            CBSheetLista.Items.Clear();//清空Combox数据
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
                openFileDialog.InitialDirectory = "C:\\Users\\huang\\Desktop\\";
                //openFileDialog.Filter = "文本文件|*.*|C#文件|*.cs|所有文件|*.*";
                openFileDialog.Filter = "Text|*.csv;*.xls;*.xlsx";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TEFilePath.EditValue = filePath = openFileDialog.FileName;
                    //FileClassa = System.IO.Path.GetExtension(openFileDialog.FileName); //文件扩展名
                    List<string> SheetName = excelHelper.GetFileSheet(filePath, out string fileclass);
                    FileClassa = fileclass;
                    if (fileclass != ".csv" && fileclass != ".xls" && fileclass != ".xlsx")
                    {
                        MessageBox.Show("文件类型错误！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (fileclass != ".csv")
                        {

                            CBSheetList.EditValue = SheetName[0];
                            foreach (string i in SheetName)//测试读取状态
                            {
                                CBSheetLista.Items.Add(i);
                            }
                        }
                    }
                }
            }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("请检查选择文件是否正常！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    CommonLogText.WriteLog(this.Text, ex.ToString());
            //}
        }

        private void BTLoadFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            GVSampleInfo.Columns.Clear();
            GVSampleInfo.OptionsView.ColumnAutoWidth = false;
            GCSampleInfo.DataSource = null;
            DataTable dt = new DataTable();
            if (FileClassa == ".xls" || FileClassa == ".xlsx")
            {
                dt = excelHelper.ExcelToDataTableCheck(CBSheetList.EditValue.ToString(), true);
                GCSampleInfo.DataSource = dt;

            }
            if (FileClassa == ".csv")
            {
                dt = excelHelper.CsvToDataTableCheck(filePath);

                GCSampleInfo.DataSource = dt;
            }
            GVSampleInfo.BestFitColumns();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("请检查选择文件格式是否正确！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    CommonLogText.WriteLog(this.Text, ex.ToString());
            //}

        }

        private void CBCheckState_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            if (CBCheckState.Checked == true)
            {
                for (int a = 0; a < GVSampleInfo.RowCount; a++)
                {
                    GVSampleInfo.SetRowCellValue(a, "选择", true);
                }
            }
            else
            {
                for (int a = 0; a < GVSampleInfo.RowCount; a++)
                {
                    GVSampleInfo.SetRowCellValue(a, "选择", false);
                }
            }
            GVSampleInfo.BestFitColumns();
            //}
            //catch (Exception ex)
            //{
            //    CommonLogText.WriteLog(this.Text, ex.ToString());
            //}

        }


        string tablename = "WorkPer.SampleInfo";
        DataTable sampleDT;///导入样本信息
        DataTable importDT;///导入配置信息
        DataTable nullDT;
        string applycodes = "";
        string applyNames = "";

        private void BTUpSystem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GVSampleInfo.FocusedRowHandle = -1;
            applycodes = "";
            applyNames = "";
            memoEdit1.EditValue = "";
            //try
            //{
            if (DTcheckInfo.Rows.Count > 0)
            {
                
                foreach (DataRow row in DTcheckInfo.Rows)
                {
                    applycodes += row["no"].ToString() + ",";
                    applyNames += row["names"].ToString() + ",";
                }
                applycodes = applycodes.Substring(0, applycodes.Length - 1);
                applyNames = applyNames.Substring(0, applyNames.Length - 1);
                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "dbo.ImportConfigInfo";
                selectInfo.wheres = $"TableNames='{tablename}' and State='1'";
                importDT = ApiHelpers.postInfo(selectInfo);
                sampleDT = GCSampleInfo.DataSource as DataTable;
                if (importDT != null)
                {
                    if (importDT.Select($"IsNull=true").Count() > 0)
                    {
                        nullDT = importDT.Select($"IsNull=true").CopyToDataTable();
                    }

                    //DataTable sampleDTs = sampleDT.Select($"选择=true").CopyToDataTable();
                    if (sampleDT != null)
                    {
                        if (sampleDT.Select($"选择=true").Count() > 0)
                        {
                            BTUpSystem.Enabled = false;
                            sampleDT = sampleDT.Select($"选择=true").CopyToDataTable();
                            progressBar1.Maximum = sampleDT.Rows.Count;
                            progressBar1.Minimum = 0;
                            sampleDT.Columns.Remove("选择");
                            //waitHandler = new AutoResetEvent(false);
                            //Task<string> insertSampleInfo = new Task<string>(() =>
                            //{
                            backgroundWorker1.RunWorkerAsync();
                            //return "aaaa";

                            //});
                            //insertSampleInfo.Start();
                            BTUpSystem.Enabled = true;
                            CommonLogText.WriteLog(this.Text, memoEdit1.EditValue.ToString());
                        }
                        else
                        {
                            MessageBox.Show("请选择导入信息！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //MessageBox.Show("导入失败！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有需要导入的信息！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("未找到导入对应信息！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("项目信息不能为空！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("系统错误！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    CommonLogText.WriteLog(this.Text, ex.ToString());
            //}
        }




        private void BTDeleteSample_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            GVSampleInfo.DeleteRow(GVSampleInfo.FocusedRowHandle);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("请选择需要删除的数据", "系统提示");
            //    CommonLogText.WriteLog(this.Text, ex.ToString());
            //}

        }
        DataTable DTcheckInfo;
        private void GVapplyInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVapplyInfo.GetFocusedDataRow() != null)
            {
                if (DTcheckInfo.Select($"no='{GVapplyInfo.GetFocusedDataRow()["no"].ToString()}'").Count() == 0)
                {
                    DataRow newdata = DTcheckInfo.NewRow();
                    newdata.ItemArray = GVapplyInfo.GetFocusedDataRow().ItemArray;
                    DTcheckInfo.Rows.InsertAt(newdata, 0);
                    DTcheckInfo.AcceptChanges();

                }
                GVapplyInfo.OptionsFind.AlwaysVisible = false;
                //GVapplyInfo.ShowFindPanel();
                GVapplyInfo.OptionsFind.AlwaysVisible = true;
            }
        }

        private void GVcheckInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVcheckInfo.GetFocusedDataRow() != null)
            {
                DataRow row = GVcheckInfo.GetFocusedDataRow();
                DTcheckInfo.Rows.Remove(GVcheckInfo.GetFocusedDataRow());
                //GVcheckInfo.DeleteRow(GVcheckInfo.FocusedRowHandle);
            }
        }
        //AutoResetEvent waitHandler = null;
        int proValue = 0;//插入成功信息数量
        int sampleCount = 0;
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            backgroundWorker1.WorkerReportsProgress = true;
            //try
            //{

            string logtext = "";//插入日志
            int nullconut = 0;//必填信息数量
            proValue = 0;//插入成功信息数量
            sampleCount = sampleDT.Columns.Count;//数据总量

            //遍历Excel中不为空的数据字段和移除没有包含维护信息的字段

            for (int a = sampleDT.Columns.Count - 1; a >= 0; a--)
            {


                DataRow[] dataRows = importDT.Select($"ExcelCellNames='{sampleDT.Columns[a].ColumnName}'");
                if (dataRows.Length == 1)
                {
                    if (nullDT.Select($"ExcelCellNames='{sampleDT.Columns[a].ColumnName}'").Length == 1)
                    {
                        //记录excel表中非空字段的数量
                        nullconut = nullconut + 1;
                    }
                    //过滤excel中列头，修改为插入表的列头
                    sampleDT.Columns[a].ColumnName = dataRows[0]["ColumnNames"].ToString().Replace(" ","").Trim();
                }
                else
                {
                    //删除多余的字段列
                    sampleDT.Columns.Remove(sampleDT.Columns[a]);
                }

            }

            if (nullconut == nullDT.Rows.Count)
            {
                int valuenumber = 0;
                foreach (DataRow sampleDR in sampleDT.Rows)
                {
                    valuenumber = valuenumber + 1;//进度计数器
                                                  //Task<string> insertSampleInfo = new Task<string>(() => 
                                                  //{
                    iInfo insertInfo = new iInfo();
                    insertInfo.TableName = tablename;
                    if (!Convert.IsDBNull(sampleDR["barcode"]))
                    {
                        string barcode = sampleDR["barcode"].ToString().ToUpper().Trim().Replace(" ", "");
                        sInfo selectInfo = new sInfo();
                        selectInfo.values = "1";
                        //selectInfo.TableName = "WorkPer.SampleInfoExcel";
                        selectInfo.TableName = tablename;
                        selectInfo.wheres = $"barcode='{barcode}'";
                        DataTable excelDT = ApiHelpers.postInfo(selectInfo);
                        if (excelDT == null)
                        {
                            Dictionary<string, object> dic = new Dictionary<string, object>();
                            //bool receiveTimeState = false;//检测是否有样本时间
                            string sampleColumnsValue = "";
                            //遍历其他信息
                            foreach (DataColumn sampleDC in sampleDT.Columns)
                            {
                                sampleColumnsValue = "";

                                if(sampleDC.ColumnName== "receiveTime")
                                    sampleColumnsValue= sampleDR[sampleDC.ColumnName].ToString().Trim();
                                if (sampleDC.ColumnName.Contains("Time"))
                                {
                                    sampleColumnsValue = sampleDR[sampleDC.ColumnName].ToString().Replace("：",":");
                                }
                                else
                                {
                                    sampleColumnsValue = sampleDR[sampleDC.ColumnName].ToString().Trim();
                                }

                                if (sampleDC.ColumnName == "barcode")
                                {
                                    dic.Add(sampleDC.ColumnName, barcode);
                                    if (barcode.Length == 11)
                                    {
                                        //string ls = TEbarcode.EditValue.ToString().Substring(6,6);
                                        //if (Int64.TryParse(ls, out Int64 intA))
                                        //{

                                        string hosptilcode = barcode.Substring(0, 5).ToUpper();
                                        DataRow[] dataRow = WorkCommData.DTClientInfo.Select($"no='{hosptilcode}'");
                                        if (dataRow.Count() > 0)
                                        {
                                            if(!dic.ContainsKey("hospitalNO"))
                                                dic.Add("hospitalNO", hosptilcode);
                                            if (!dic.ContainsKey("hospitalNames"))
                                                dic.Add("hospitalNames", dataRow[0]["names"]);
                                        }
                                    }
                                }
                                else
                                {
                                    if (sampleDC.ColumnName=="hospitalNO")
                                    {
                                        DataRow[] dataRow = WorkCommData.DTClientInfo.Select($"no='{sampleColumnsValue}'");
                                        if (dataRow.Count() > 0)
                                        {
                                            if (!dic.ContainsKey("hospitalNO"))
                                                dic.Add("hospitalNO", sampleColumnsValue);
                                            if (!dic.ContainsKey("hospitalNames"))
                                                dic.Add("hospitalNames", dataRow[0]["names"]);
                                        }
                                    }
                                    if (sampleDC.ColumnName == "hospitalNames")
                                    {
                                        DataRow[] dataRow = WorkCommData.DTClientInfo.Select($"names='{sampleColumnsValue}'");
                                        if (dataRow.Count() > 0)
                                        {
                                            if (!dic.ContainsKey("hospitalNO"))
                                                dic.Add("hospitalNO", dataRow[0]["names"]);
                                            if (!dic.ContainsKey("hospitalNames"))
                                                dic.Add("hospitalNames", sampleColumnsValue);
                                        }
                                    }


                                    if (!dic.ContainsKey(sampleDC.ColumnName))
                                    {
                                        //if (sampleDC.ColumnName == "receiveTime")
                                        //    receiveTimeState = true;
                                        if (backgroundWorker1.CancellationPending)
                                        {
                                            backgroundWorker1.ReportProgress(valuenumber, String.Format("{0}%,操作被用户申请中断", valuenumber));
                                        }

                                        if (sampleDR[sampleDC.ColumnName] == null)
                                        {
                                            dic.Add(sampleDC.ColumnName, importDT.Select($"tableNames='{tablename}' and ColumnNames='{sampleDC.ColumnName}'").CopyToDataTable().Rows[0]["DefaultValues"].ToString());
                                        }
                                        else
                                        {
                                            if (sampleDR[sampleDC.ColumnName].ToString().Trim().Length == 0&& !sampleDC.ColumnName.Contains("Time"))
                                            {
                                                dic.Add(sampleDC.ColumnName, importDT.Select($"tableNames='{tablename}' and ColumnNames='{sampleDC.ColumnName}'").CopyToDataTable().Rows[0]["DefaultValues"].ToString());
                                            }
                                            else
                                            {
                                                if(sampleColumnsValue!="")
                                                    dic.Add(sampleDC.ColumnName, sampleColumnsValue);

                                            }
                                        }
                                    }
                                }
                            }
                            if(!dic.ContainsKey("receiveTime"))
                                dic.Add("receiveTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            string cardError = string.Empty;
                            if (dic.ContainsKey("patientCardNo"))
                            {
                                try
                                {
                                    bool cardid = dic.TryGetValue("patientCardNo", out object patientCardid);
                                    if (patientCardid != null)
                                    {
                                        string identityCard = patientCardid.ToString();
                                        if (identityCard.Length == 15 || identityCard.Length == 18)//身份证号码只能为15位或18位其它不合法
                                        {
                                            string strSex = string.Empty;
                                            string Birthday = string.Empty;
                                            if (identityCard.Length == 18)//处理18位的身份证号码从号码中得到生日和性别代码
                                            {
                                                Birthday = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
                                                strSex = identityCard.Substring(14, 3);
                                            }
                                            if (identityCard.Length == 15)
                                            {
                                                Birthday = "19" + identityCard.Substring(6, 2) + "-" + identityCard.Substring(8, 2) + "-" + identityCard.Substring(10, 2);
                                                strSex = identityCard.Substring(12, 3);
                                            }
                                            dic.Add("ageYear", CalculateAge(Birthday).ToString());
                                            //TEageYear.EditValue = CalculateAge(Birthday).ToString();//根据生日计算年龄
                                            if (int.Parse(strSex) % 2 == 0)//性别代码为偶数是女性奇数为男性
                                            {

                                                if (!dic.ContainsKey("patientSexNO"))
                                                {
                                                    dic.Add("patientSexNO", 2);
                                                    if (!dic.ContainsKey("patientSexNames"))
                                                        dic.Add("patientSexNames", "女");
                                                }
                                            }
                                            else
                                            {
                                                if (!dic.ContainsKey("patientSexNO"))
                                                {
                                                    dic.Add("patientSexNO", 1);
                                                    if (!dic.ContainsKey("patientSexNames"))
                                                        dic.Add("patientSexNames", "男");
                                                }
                                            }
                                        }
                                    }
                                }
                                catch(Exception ex)
                                {
                                    cardError = ex.ToString();
                                }

                            }
                            if (dic.ContainsKey("patientSexNames"))
                            {
                                bool sexState = dic.TryGetValue("patientSexNames", out object sexNO);
                                if (sexState)
                                {
                                    string patintSexNO = sexNO.ToString();
                                    if (patintSexNO == "男")
                                    {
                                        if(!dic.ContainsKey("patientSexNO"))
                                        {
                                            dic.Add("patientSexNO", 1);
                                        }

                                    }
                                    else
                                    {
                                        if (patintSexNO == "女")
                                        {
                                            if (!dic.ContainsKey("patientSexNO"))
                                            {
                                                dic.Add("patientSexNO", 2);
                                            }
                                        }
                                        else
                                        {
                                            dic.Add("patientSexNO", 3);
                                        }
                                    }

                                }
                            }
                            if(dic.ContainsKey("sampleTypeNames"))
                            {
                                    DataRow[] dataRow = WorkCommData.DTTypeSample.Select($"names='{sampleColumnsValue}'");
                                    if (dataRow.Count() > 0)
                                    {
                                        if (!dic.ContainsKey("sampleTypeNames"))
                                            dic.Add("sampleTypeNames", sampleColumnsValue);
                                        if (!dic.ContainsKey("sampleTypeNO"))
                                            dic.Add("sampleTypeNO", dataRow[0]["no"]);
                                    }
                            }
                            else
                            {
                                if (!dic.ContainsKey("sampleTypeNames"))
                                    dic.Add("sampleTypeNames", "口咽拭子");
                                if (!dic.ContainsKey("sampleTypeNO"))
                                    dic.Add("sampleTypeNO", 46);
                            }
                            dic.Add("applyItemCodes", applycodes);
                            dic.Add("applyItemNames", applyNames);
                            dic.Add("sampleShapeNO", 48);
                            dic.Add("sampleShapeNames", "合格");
                            dic.Add("state", 1);
                            dic.Add("dstate", 0);
                            dic.Add("perStateNO", 1);
                            dic.Add("creater", CommonData.UserInfo.names);
                            dic.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                            if(dic.ContainsKey("barcode"))
                            {
                                if (dic.ContainsKey("hospitalNO"))
                                {


                                    bool CardNoState = true;
                                    if (dic.TryGetValue("patientCardNo", out object patientCardid))
                                    {
                                        string spatientCardid = patientCardid != null ? patientCardid.ToString().Trim() : "";
                                        if (!IsIdCard(spatientCardid) && spatientCardid != "")
                                        {
                                            CardNoState = false;
                                        }
                                    }
                                    bool phoneState = true;
                                    if (dic.TryGetValue("patientPhone", out object phone))
                                    {
                                        string sphone = phone != null ? phone.ToString().Trim() : "";
                                        if (sphone != "")
                                        {
                                            phoneState = IsHandset(sphone);
                                        }
                                    }

                                    if (CardNoState && phoneState)
                                    {
                                        insertInfo.values = dic;
                                        insertInfo.MessageShow = 1;
                                        int returna = ApiHelpers.postInfo(insertInfo);
                                        if (returna == 1)
                                        {
                                            proValue = proValue + 1;
                                            logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDR["barcode"].ToString()}：导入成功";
                                        }
                                        else
                                        {
                                            logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDR["barcode"].ToString()};导入失败：请检查数据格式是否匹配";
                                        }
                                    }
                                    else
                                    {
                                        string errorstring = "";
                                        if (!phoneState)
                                        {
                                            errorstring = "手机号错误";
                                        }

                                        if (!CardNoState)
                                        {
                                            errorstring = "身份证验证失败";
                                        }
                                        insertInfo.values = dic;
                                        insertInfo.MessageShow = 1;
                                        int returna = ApiHelpers.postInfo(insertInfo);
                                        if (returna == 1)
                                        {
                                            proValue = proValue + 1;
                                            logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDR["barcode"].ToString()}：导入成功:" + errorstring;
                                        }
                                        else
                                        {
                                            logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDR["barcode"].ToString()};导入失败:" + errorstring;
                                        }
                                    }
                                }
                                else
                                {
                                    logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDR["barcode"].ToString()};导入失败：未包含客户编号信息。";
                                }
                            }
                            else
                            {
                                logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDR["barcode"].ToString()};导入失败：未包含条码号信息。";
                            }

                        }
                        else
                        {
                            logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDR["barcode"].ToString()};条码重复：导入失败!";
                        }
                    }
                    else
                    {
                        logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},请检查第{valuenumber}条数据信息条码号是否正确：导入失败!";
                    }
                    //return logtext;
                    //});
                    //insertSampleInfo.Start();
                    //insertSampleInfo.Wait();
                    ////Thread.Sleep(50);

                    //调用 ReportProgress 方法，会触发ProgressChanged事件
                    //backgroundWorker1.ReportProgress(valuenumber, insertSampleInfo.Result);
                    backgroundWorker1.ReportProgress(valuenumber, logtext);



                    //waitHandler.WaitOne();
                }
                
            }
            else
            {
                MessageBox.Show($"请检查必填项是否完整！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }
        /// <summary>
        /// 验证手机号
        /// </summary>
        /// <param name="str_handset"></param>
        /// <returns></returns>
        public static bool IsHandset(string str_handset)
        {
            if(str_handset.Trim().Length==11)
            {
                return Regex.IsMatch(str_handset, @"^1[123456789]\d{9}$");
            }
            else
            {
                return false;
            }

                
        }

        /// <summary>
        /// 验证身份证是否合法
        /// </summary>
        /// <param name="idCard">要验证的身份证</param>
        public static bool IsIdCard(string idCard)
        {
            bool state = false;
            if(idCard.Length==18||idCard.Length==15)
            {
                if(idCard.Length==18)
                {
                    state= CheckIDCard18(idCard,out string error);
                }
                else
                {
                    state= CheckIDCard15(idCard);
                }
            }
            return state;
        }
        /// <summary>  
        /// 18位身份证号码验证  
        /// </summary>  
        private static bool CheckIDCard18(string idNumber,out string error)
        {
            bool state = true;
            try
            {
                error = "";
                long n = 0;
                if (long.TryParse(idNumber.Remove(17), out n) == false|| n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)
                {
                    return false;//数字验证  
                }
                string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");
                DateTime time = new DateTime();
                bool yearState = DateTime.TryParse(birth, out time);
                if (yearState)
                {
                    if (time > DateTime.Now)
                    {
                        state= false;//生日验证  
                    }
                }
                else
                {
                    state= false;//生日验证  
                }
            }
            catch(Exception ex)
            {
                error = ex.ToString();
                state= false;//生日验证
            }
            return state;//符合GB11643-1999标准  
        }
        /// <summary>  
        /// 15位身份证号码验证  
        /// </summary>  
        private static bool CheckIDCard15(string idNumber)
        {
            long n = 0;
            if (long.TryParse(idNumber, out n) == false || n < Math.Pow(10, 14))
            {
                return false;//数字验证  
            }
            //string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
            //if (address.IndexOf(idNumber.Remove(2)) == -1)
            //{
            //    return false;//省份验证  
            //}
            string birth = idNumber.Substring(6, 6).Insert(4, "-").Insert(2, "-");
            DateTime time = new DateTime();
            if (DateTime.TryParse(birth, out time) == false)
            {
                return false;//生日验证  
            }
            return true;
        }









        /// <summary>
        /// 根据出生日期，计算精确的年龄
        /// </summary>
        /// <param name="birthDate">生日</param>
        /// <returns></returns>
        public static int CalculateAge(string birthDay)
        {
            DateTime birthDate = DateTime.Parse(birthDay);
            DateTime nowDateTime = DateTime.Now;
            int age = nowDateTime.Year - birthDate.Year;
            //再考虑月、天的因素
            if (nowDateTime.Month < birthDate.Month || (nowDateTime.Month == birthDate.Month && nowDateTime.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }
        //Func<string> Func;
        delegate void ChangeInvoke(string num);
        private void ChangeNum(string num)
        {
            label1.Text = num;
        }
        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            string ssss = e.UserState.ToString();
            string[] a = ssss.Split(',');

            label1.Text = a[0];
            string saaa = a[1];
            memoEdit1.Text = a[1] + "\r\n" + memoEdit1.Text;
            memoEdit1.Update();
            label1.Update();
            ////waitHandler.Set();
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show($"成功导入{proValue}条数据，共{sampleDT.Rows.Count}条数据！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Value = 0;
        }
    }
}
