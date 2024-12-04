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
using System.Windows.Forms;

namespace Ms.UpInfoHandle
{
    public partial class FrmSampleInfoExcel : DevExpress.XtraEditors.XtraForm
    {
        string filePath = null;
        string FileClassa = "";//文件信息类型
        ExcelHelper excelHelper = new ExcelHelper();
        
        string tablename = "WorkPer.SampleBlendInfo";
        DataTable sampleDT;
        DataTable importDT;
        DataTable nullDT;
        //string applycodes = "";
        //string applyNames = "";

        public FrmSampleInfoExcel()
        {
            InitializeComponent();

            BTSampleTakeTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            GridControls.formartGridView(GVSampleInfo);
            GridControls.showEmbeddedNavigator(GCSampleInfo);





            //CheckForIllegalCrossThreadCalls = false;
        }
        private void FrmSampleInfoExcel_Load(object sender, EventArgs e)
        {
            SysPowerHelper.UserPower(barManager1);
        }
        private void BTImportInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            string tablenames = tablename;
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "dbo.ImportConfigInfo";
            if (CEPerson.Checked)
            {
                selectInfo.wheres = $"TableNames='{tablename}' and type=1 and State='1'";
                selectInfo.OrderColumns = "sort";
                importDT = ApiHelpers.postInfo(selectInfo);
                FrmImportConfigInfo frmImportConfig = new FrmImportConfigInfo(importDT);
                frmImportConfig.ShowDialog();
            }
            else
            {
                if(CEHJ.Checked)
                {
                    selectInfo.wheres = $"TableNames='{tablename}' and type=2 and State='1'";
                    selectInfo.OrderColumns = "sort";
                    importDT = ApiHelpers.postInfo(selectInfo);
                    FrmImportConfigInfo frmImportConfig = new FrmImportConfigInfo(importDT);
                    frmImportConfig.ShowDialog();
                }
                else
                {
                    MessageBox.Show("请先选择导入类型！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

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



        private void BTUpSystem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GVSampleInfo.FocusedRowHandle = -1;
            //applycodes = "";
            //applyNames = "";
            memoEdit1.EditValue = "";
            //try
            //{
            //if (DTcheckInfo.Rows.Count > 0)
            //{

            //foreach (DataRow row in DTcheckInfo.Rows)
            //{
            //    applycodes += row["no"].ToString() + ",";
            //    applyNames += row["names"].ToString() + ",";
            //}
            //applycodes = applycodes.Substring(0, applycodes.Length - 1);
            //applyNames = applyNames.Substring(0, applyNames.Length - 1);
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "dbo.ImportConfigInfo";
            if (CEPerson.Checked)
            {
                selectInfo.wheres = $"TableNames='{tablename}' and type=1 and State='1'";
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
                if (CEHJ.Checked)
                {
                    selectInfo.wheres = $"TableNames='{tablename}' and type=2 and State='1'";
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
                    MessageBox.Show("请先选择导入类型！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            //}
            //else
            //{
            //    MessageBox.Show("项目信息不能为空！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



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
        //DataTable DTcheckInfo;

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
                //int sampleNumber = 1;//混采样本数量计数器
                string barcode = "";
                string perBarcode = "";
                Dictionary<string, object> oledic = new Dictionary<string, object>();//上一条记录信息
                for (int a=0;a<sampleDT.Rows.Count;a++)
                {
                    string newbarcode= sampleDT.Rows[a]["barcode"] != DBNull.Value ? sampleDT.Rows[a]["barcode"].ToString().ToUpper().Trim().Replace(" ", "") : "";

                    //if(newbarcode=="")
                    //    newbarcode=barcode;



                    if (barcode!= newbarcode && newbarcode != "")
                    {
                        if(perBarcode=="")
                            perBarcode = newbarcode;
                        barcode = newbarcode;
                        uInfo selectInfo = new uInfo();
                        selectInfo.value = "dstate=1";
                        //selectInfo.TableName = "WorkPer.SampleInfoExcel";
                        selectInfo.TableName = tablename;
                        selectInfo.wheres = $"barcode='{sampleDT.Rows[a]["barcode"].ToString()}'";
                        selectInfo.MessageShow = 1;
                        //DataTable excelDT = ApiHelpers.postInfo(selectInfo);
                        ApiHelpers.postInfo(selectInfo);
                    }
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    //if (!Convert.IsDBNull(sampleDT.Rows[a]["barcode"]))
                    if (newbarcode != "")
                    {



                        //if (excelDT == null)
                        //{
                        iInfo insertInfo = new iInfo();
                        insertInfo.TableName = tablename;
                        
                        string cardid = "";
                        bool receiveTimeState = false;//检测是否有样本时间
                        foreach (DataColumn sampleDC in sampleDT.Columns)
                        {
                            if (sampleDC.ColumnName == "barcode")
                            {
                                dic.Add(sampleDC.ColumnName, barcode);
                            }
                            else
                            {
                                if (sampleDC.ColumnName == "receiveTime")
                                    receiveTimeState = true;
                                if (backgroundWorker1.CancellationPending)
                                {
                                    backgroundWorker1.ReportProgress(valuenumber, String.Format("{0}%,操作被用户申请中断", valuenumber));
                                }

                                if (sampleDT.Rows[a][sampleDC.ColumnName] == null)
                                {
                                    dic.Add(sampleDC.ColumnName, importDT.Select($"tableNames='{tablename}' and ColumnNames='{sampleDC.ColumnName}'").CopyToDataTable().Rows[0]["DefaultValues"].ToString());
                                }
                                else
                                {
                                    if (sampleDT.Rows[a][sampleDC.ColumnName].ToString().Trim().Length == 0)
                                    {
                                        dic.Add(sampleDC.ColumnName, importDT.Select($"tableNames='{tablename}' and ColumnNames='{sampleDC.ColumnName}'").CopyToDataTable().Rows[0]["DefaultValues"].ToString());
                                    }
                                    else
                                    {
                                        dic.Add(sampleDC.ColumnName, sampleDT.Rows[a][sampleDC.ColumnName]);
                                        if (sampleDC.ColumnName == "patientCardNo")
                                        {
                                            cardid = sampleDT.Rows[a][sampleDC.ColumnName].ToString();
                                        }
                                    }
                                }
                            }
                        }
                        string cardstate = "";
                        if(dic.ContainsKey("patientCardNo"))
                        {
                            sampleSexAge sexAge = GetSexAge(cardid);

                            if (sexAge.sex != "" && sexAge.age != "" && sexAge.msg == "")
                            {
                                dic.Add("ageYear", sexAge.age);
                                dic.Add("patientSexNames", sexAge.sex);
                            }
                            else
                            {
                                cardstate = $"身份证{cardid}识别错误," + sexAge.msg;
                            }
                        }
                        if (!receiveTimeState)
                            dic.Add("receiveTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        dic.Add("state", 1);
                        dic.Add("dstate", 0);
                        //dic.Add("perStateNO", 1);
                        dic.Add("creater", CommonData.UserInfo.names);
                        dic.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        insertInfo.values = dic;
                        insertInfo.MessageShow = 1;
















                        try
                        {
                            int returna = ApiHelpers.postInfo(insertInfo);
                            if (returna == 1)
                            {
                                proValue = proValue + 1;
                                logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDT.Rows[a]["barcode"].ToString()}：导入成功;"+ cardstate;
                            }
                            else
                            {
                                logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDT.Rows[a]["barcode"].ToString()};导入失败：请检查数据格式是否匹配";
                            }
                        }
                        catch (Exception ex)
                        {
                            logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},条码号:{sampleDT.Rows[a]["barcode"].ToString()};导入失败：" + ex.ToString();
                        }


                    }
                    else
                    {

                        logtext = $"{ valuenumber }/{ sampleDT.Rows.Count},请检查第{valuenumber}条数据信息条码号是否正确：导入失败!";
                    }
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
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        public class sampleSexAge
        {
            public string age { get; set; }
            public string sex { get; set; }
            public string msg { get; set; }
        }

        public static sampleSexAge GetSexAge(string identityCard)
        {
            sampleSexAge sexAge = new sampleSexAge();
            try
            {
                sexAge.age = "";
                if (string.IsNullOrEmpty(identityCard))
                {
                    sexAge.age = "";
                }
                else
                {
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

                        sexAge.age = CalculateAge(Birthday, out string errorInfo).ToString();//根据生日计算年龄
                        sexAge.msg = errorInfo;
                        try
                        {
                            if (int.Parse(strSex) % 2 == 0)//性别代码为偶数是女性奇数为男性
                            {
                                sexAge.sex = "女";
                            }
                            else
                            {
                                sexAge.sex = "男";
                            }
                        }
                        catch (Exception ex)
                        {
                            sexAge.msg = sexAge.msg + ex.ToString();
                        }

                    }
                    else
                    {
                        sexAge.sex = "";
                    }
                }
                return sexAge;
            }
            catch(Exception ex)
            {
                sexAge.msg = ex.ToString();
                return sexAge;
            }
        }

        /// <summary>
        /// 根据出生日期，计算精确的年龄
        /// </summary>
        /// <param name="birthDate">生日</param>
        /// <returns></returns>
        public static int CalculateAge(string birthDay ,out string errorinfo)
        {
            errorinfo = "";
            try
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
            catch(Exception ex)
            {
                errorinfo = ex.ToString();
                return 0;
            }
        }

        private void CEPerson_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CEPerson.Checked)
            {
                CEHJ.Checked = false;
            }
            else
            {
                CEHJ.Checked = true;
            }
                

        }

        private void CEHJ_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CEHJ.Checked)
            {
                CEPerson.Checked = false;
            }
            else
            {
                CEPerson.Checked = true;
            }
        }
    }
}
