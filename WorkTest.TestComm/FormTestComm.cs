using Common.BLL;
using Common.Conn;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using Common.TestModel.Result;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkTest.TestComm
{
    public partial class FormTestComm : XtraForm
    {

        LayoutControlGroup layoutControlGroup;
        List<controlsInfo> controlsInfos;
        controlsInfo controlinfo;
        LayoutControlItem layoutControlItem;


        //TextEdit textEdit;
        //ComboBoxEdit comboBoxEdit;
        //PictureEdit pictureEdit;
        //CheckEdit checkEdit;
        //DateEdit dateEdit;
        //MemoEdit memoEdit;

        string filepath = Application.StartupPath;
        string SetResultTest = "";//保存结果接口地址
        string tableName = "";//结果表名称
        string tableImg = "";//图片表名称
        string itemCodes = "";//项目编号

        string oldfrmFile = "";
        public FormTestComm()
        {
            InitializeComponent();
            SetResultTest = ConfigInfos.ReadConfigInfo("SetResultComm");
            layoutControlGroup = new LayoutControlGroup();
            layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup.GroupBordersVisible = false;
            LCForm.Root = layoutControlGroup;
            frmDatas = "";
        }



        private static string frmDatas = "";


        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="Barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {
            string groupFlowNO = SampleInfo["groupFlowNO"] != DBNull.Value ? SampleInfo["groupFlowNO"].ToString() : "";
            DataRow[] rows=  WorkCommData.DTItemFlow.Select($"no='{groupFlowNO}'");
            tableName = rows[0]["dataSource"] != DBNull.Value ? rows[0]["dataSource"].ToString() : "";
            tableImg = rows[0]["imgSource"] != DBNull.Value ? rows[0]["imgSource"].ToString() : "";
            string frmData = rows[0]["frmData"] != DBNull.Value ? rows[0]["frmData"].ToString() : "";
            string frmFile = rows[0]["frmFile"] != DBNull.Value ? rows[0]["frmFile"].ToString() : "";
            bool frmState = rows[0]["frmState"] != DBNull.Value ? Convert.ToBoolean(rows[0]["frmState"]): false;
            string tester = SampleInfo["tester"] != DBNull.Value ? SampleInfo["tester"].ToString() : "";
            int testState = TestStateNO;

            if (frmData != "" && frmState)
            {
                controlsInfos = JsonHelper.DeserializeJsonToObject<List<controlsInfo>>(frmData);
                //loadFrom(controlsInfos);

                ///读取检验结果
                if (tableName != "")
                {
                    Task<DataTable> ResultTask = new Task<DataTable>(() =>
                    {
                        sInfo selectInfo = new sInfo();
                        selectInfo.TableName = tableName;
                        selectInfo.wheres = $"testid='{testid}' and state=1";
                        return ApiHelpers.postInfo(selectInfo);
                    });
                    ResultTask.Start();
                    DataTable dataTable = ResultTask.Result;
                    if(dataTable!=null)
                    {
                        itemCodes = dataTable.Rows[0]["itemCodes"] != DBNull.Value ? dataTable.Rows[0]["itemCodes"].ToString() : "";
                        //if (tester != "" && dataTable != null && dataTable.Rows.Count > 0)
                        if (dataTable != null && dataTable.Rows.Count > 0)
                        {
                            foreach (controlsInfo info in controlsInfos)
                            {
                                if (dataTable.Columns.Contains(info.name))
                                {
                                    //Type columsType= dataTable.Columns[info.name].GetType();
                                    if (info.type == "CheckEdit")
                                    {
                                        info.check = dataTable.Rows[0][info.name] != DBNull.Value ? Convert.ToBoolean(dataTable.Rows[0][info.name]) : false;
                                    }
                                    else
                                    {
                                        if (dataTable.Rows[0][info.name] != DBNull.Value)
                                            info.defaultValue = dataTable.Rows[0][info.name].ToString();
                                    }

                                }
                            }

                        }
                        if (tableImg != "")
                        {
                            Task<DataTable> ResultImg = new Task<DataTable>(() =>
                            {
                                sInfo selectInfo = new sInfo();
                                selectInfo.TableName = tableImg;
                                selectInfo.wheres = $"testid='{testid}' and state=1";
                                return ApiHelpers.postInfo(selectInfo);
                            });
                            ResultImg.Start();
                            DataTable dataTableImg = ResultImg.Result;
                            if (tester != "" && dataTableImg != null && dataTableImg.Rows.Count > 0)
                            {
                                foreach (controlsInfo info in controlsInfos)
                                {
                                    if (dataTableImg.Columns.Contains(info.name))
                                    {
                                        //Type columsType= dataTable.Columns[info.name].GetType();
                                        if (info.type == "PictureEdit")
                                        {

                                            string imgName = dataTableImg.Rows[0][info.name] == DBNull.Value ? dataTableImg.Rows[0][info.name].ToString() : "";
                                            string FullFilePath = filepath + "\\TestImg\\" + tableImg + "\\" + imgName;
                                            if (File.Exists(FullFilePath))
                                            {
                                                info.imgPath = FullFilePath;
                                            }
                                            else
                                            {
                                                commInfoModel<FileModel> commInfo = new commInfoModel<FileModel>();
                                                List<FileModel> fileModels = new List<FileModel>();
                                                FileModel testDownModel = new FileModel();
                                                testDownModel.fileName = imgName;
                                                testDownModel.dirname = tableImg;
                                                testDownModel.fileType = "1";
                                                fileModels.Add(testDownModel);
                                                commInfo.infos = fileModels;

                                                //string sr = JsonHelper.SerializeObjct(commInfo);
                                                bool filestate = ApiHelpers.PostDownTestFile(commInfo, out string filepath);
                                                if (filestate)
                                                {
                                                    info.imgPath = filepath;
                                                }
                                            }

                                        }
                                    }
                                }

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("未读取到检验结果信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                if(frmDatas==""&& frmDatas!=frmData)
                {
                    frmDatas = frmData;
                    loadFrom(controlsInfos);
                    string path = Application.StartupPath + "\\flow";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    string paths = path + "\\" + frmFile;
                    if (File.Exists(paths))
                    {
                        LCForm.RestoreLayoutFromXml(paths);
                    }
                    else
                    {
                        commInfoModel<FileModel> commInfo = new commInfoModel<FileModel>();
                        List<FileModel> fileModels = new List<FileModel>();
                        FileModel FileModel = new FileModel();
                        FileModel.fileName = frmFile;
                        FileModel.fileType = "1";
                        fileModels.Add(FileModel);
                        commInfo.infos = fileModels;
                        //string sr = JsonHelper.SerializeObjct(commInfo);
                        if (ApiHelpers.PostDownFlowFile(commInfo))
                            LCForm.RestoreLayoutFromXml(paths);
                    }
                }
                else
                {
                    loadFrom(controlsInfos,false);
                }


                //加载相关流程
                //if (oldfrmFile == ""&& oldfrmFile!= frmFile)
                //{
                //    oldfrmFile = frmFile;
                //    string path = Application.StartupPath + "\\flow";
                //    if (!Directory.Exists(path))
                //        Directory.CreateDirectory(path);
                //    string paths = path + "\\" + frmFile;
                //    if (File.Exists(paths))
                //    {
                //        LCForm.RestoreLayoutFromXml(paths);
                //    }
                //    else
                //    {
                //        commInfoModel<FileModel> commInfo = new commInfoModel<FileModel>();
                //        List<FileModel> fileModels = new List<FileModel>();
                //        FileModel FileModel = new FileModel();
                //        FileModel.fileName = frmFile;
                //        FileModel.fileType = "1";
                //        fileModels.Add(FileModel);
                //        commInfo.infos = fileModels;
                //        //string sr = JsonHelper.SerializeObjct(commInfo);
                //        if (ApiHelpers.PostDownFlowFile(commInfo))
                //            LCForm.RestoreLayoutFromXml(paths);
                //    }
                //}
            }


        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="ResultState">结果结果状态 1.检验者 2.复初审者 3.审核者</param>
        /// <returns></returns>
        public string postResultInfo(int ResultState, int perid, int testid, string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        {

            //GVTestInfo.FocusedRowHandle = -1;




            //Task<string> task = new Task<string>(() =>
            //{
            if (ResultState == 4)
            {
                CommResultModel<TestInfoModel> testInfo = new CommResultModel<TestInfoModel>();
                //CommResultModel<TestInfoModel> testInfo = new CommResultModel<TestInfoModel>();
                testInfo.UserName = CommonData.UserInfo.names;
                
                testInfo.ResultState = ResultState;
                TestInfoModel resultTest = new TestInfoModel();
                resultTest.barcode = barcode;
                resultTest.perid = perid;
                resultTest.testid = testid; resultTest.sampleID = sampleid;
                resultTest.groupNO = groupNO;


                resultTest.State = true;
                resultTest.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //resultTest.ListResult = itemResults;
                testInfo.AutographInfo = info;
                testInfo.Result = resultTest;
                string s = JsonHelper.SerializeObjct(testInfo);
                WebApiCallBack jm = ApiHelpers.postInfo(SetResultTest, s);
                return jm.data.ToString();
            }
            else
            {


                if (barcode != "" && testid != 0 && groupNO != "")
                {
                    CommResultModel<GeneInfoModel> testInfo = new CommResultModel<GeneInfoModel>();
                    testInfo.UserName = CommonData.UserInfo.names;
                    
                    testInfo.ResultState = ResultState;
                    //testInfo.resultTable = tableName;

                    GeneInfoModel resultTest = new GeneInfoModel();
                    resultTest.barcode = barcode;
                    resultTest.perid = perid;
                    resultTest.testid = testid; resultTest.sampleID = sampleid;
                    resultTest.groupNO = groupNO;
                    resultTest.State = true;
                    resultTest.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));





                    //List<ItemResultModel> itemResults = new List<ItemResultModel>();
                    List<GeneItemModel> itemResults = new List<GeneItemModel>();
                    //DataTable dataTable = GCTestInfo.DataSource as DataTable;

                    bool saveState = true;


                    GeneItemModel itemResult = new GeneItemModel();
                    itemResult.itemCode = itemCodes;
                    List<GeneResultModel> resultInfos = new List<GeneResultModel>();
                    foreach (var gccontrol in LCForm.Items)
                    {
                        if (gccontrol is LayoutControlGroup)
                        {
                            LayoutControlGroup lControlGroup = gccontrol as LayoutControlGroup;
                            foreach (var lcontrol in lControlGroup.Items)
                            {
                                if (lcontrol is LayoutControlItem)
                                {
                                    LayoutControlItem lControlItem = lcontrol as LayoutControlItem;
                                    if(lControlItem.Control!=null)
                                    {
                                        GeneResultModel resultInfo = new GeneResultModel();

                                        if (lControlItem.Control is PictureEdit)
                                        {
                                            PictureEdit pictureEdit = lControlItem.Control as PictureEdit;
                                            if (pictureEdit.Image != null)
                                            {
                                                string filePath = DateTime.Now.ToString("yyyy-MM-dd") + "\\" + barcode + "-" + itemCodes + "-" + lControlItem.Control.Name;
                                                string filePaths = Application.StartupPath + "\\localImg\\" + DateTime.Now.ToString("yyyy-MM-dd");
                                                if (!Directory.Exists(filePaths))
                                                    Directory.CreateDirectory(filePaths);
                                                int a = 0;
                                                string fullPath = Application.StartupPath + "\\localImg\\" + filePath;
                                                for (a = 0; a < 10000; a++)
                                                {
                                                    if (!File.Exists(fullPath + "-" + a + ".png"))
                                                    {
                                                        fullPath = fullPath + "-" + a + ".png";
                                                        break;
                                                    }
                                                }

                                                pictureEdit.Image.Save(fullPath, ImageFormat.Png);

                                                resultInfo.key = lControlItem.Control.Name;
                                                resultInfo.names = lControlItem.Text;
                                                resultInfo.value = FileConverHelper.FilePathToString(fullPath);
                                                resultInfos.Add(resultInfo);
                                            }
                                        }
                                        if (lControlItem.Control is CheckEdit)
                                        {
                                            CheckEdit checkEdit = lControlItem.Control as CheckEdit;
                                            resultInfo.key = lControlItem.Control.Name;
                                            resultInfo.names = lControlItem.Text;
                                            resultInfo.value = checkEdit.Checked == true ? "1" : "0";
                                            resultInfos.Add(resultInfo);
                                        }
                                        //if (lControlItem.Control is MemoEdit)
                                        //{
                                        //    MemoEdit memoEdit = lControlItem.Control as MemoEdit;
                                        //    resultInfo.value = memoEdit.EditValue != null ? memoEdit.EditValue.ToString() : "";
                                        //    resultInfos.Add(resultInfo);
                                        //}
                                        //if (lControlItem.Control is ComboBoxEdit)
                                        //{
                                        //    ComboBoxEdit comboBoxEdit = lControlItem.Control as ComboBoxEdit;
                                        //    resultInfo.value = comboBoxEdit.EditValue != null ? comboBoxEdit.EditValue.ToString() : "";
                                        //    resultInfos.Add(resultInfo);
                                        //}
                                        //if (lControlItem.Control is DateEdit)
                                        //{
                                        //    DateEdit dateEdit = lControlItem.Control as DateEdit;
                                        //    resultInfo.value = dateEdit.EditValue != null ? dateEdit.EditValue.ToString() : "";
                                        //    resultInfos.Add(resultInfo);
                                        //}
                                        if (lControlItem.Control is TextEdit)
                                        {
                                            TextEdit textEdit = lControlItem.Control as TextEdit;
                                            resultInfo.key = lControlItem.Control.Name;
                                            resultInfo.names = lControlItem.Text;
                                            resultInfo.value = textEdit.EditValue != null ? textEdit.EditValue.ToString() : "";
                                            resultInfos.Add(resultInfo);
                                        }
                                    }

                                }

                            }
                        }
                    }
                    if (resultInfos.Count>0)
                    {
                        itemResult.itemResults = resultInfos;
                        itemResults.Add(itemResult);

                        resultTest.ListResult = itemResults;



                        testInfo.AutographInfo = info;
                        testInfo.Result = resultTest;


                        if (saveState && itemResults != null)
                        {
                            string s = JsonHelper.SerializeObjct(testInfo);
                            WebApiCallBack jm = ApiHelpers.postInfo(SetResultTest, s);
                            return jm.data.ToString();
                        }
                        else
                        {
                            //MessageBox.Show("检验结果有空值。请检查样本结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return "检验结果有空值。请检查样本结果！";
                            return "{\"code\":1,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"检验结果有空值。请检查样本结果！\"}";
                        }
                    }
                    else
                    {
                        return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"未检测到检验结果。请检查样本结果！\"}";
                    }

                }
                else
                {
                    return "{\"code\":1,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息！\"}";
                }
            }
        }

        /// <summary>
        /// 其他功能反射
        /// </summary>
        /// <param name="ValueInfo"></param>
        /// <returns></returns>
        public void setOtherInfo(object ValueInfo)
        {
            try
            {
                if (ValueInfo != null)
                {
                    string values = ValueInfo.ToString();
                    if (values == "1")
                    {
                        //BTTakePicture_ItemClick(null, null);
                    }
                    if (values == "2")
                    {
                        //BTDeletePicture_ItemClick(null, null);
                    }
                }
            }
            catch
            {

            }

        }

        #region 选择控件

        private void resetcolor()
        {
            foreach (var gcontrol in LCForm.Items)
            {
                if (gcontrol is LayoutControlGroup)
                {
                    LayoutControlGroup layoutControlGroup = gcontrol as LayoutControlGroup;
                    foreach (var control in layoutControlGroup.Items)
                    {
                        if (control is LayoutControlItem)
                        {
                            LayoutControlItem item = control as LayoutControlItem;
                            item.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
                        }
                    }
                }
            }
        }

        private void TextEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            //TECname.Text = controlinfo.name;
            //TECdefult.Text = controlinfo.defaultValue;
            //TElayoutName.Text = controlinfo.layoutItemName;
            //TECdicName.Text = controlinfo.dicName;
            //TECdicType.Text = controlinfo.dicType;
            //BECominfo.Text = "";
            //CECe.Checked = controlinfo.enabled;
            //CECv.Checked = controlinfo.visible;
            //CECheckState.Checked = false;
            //TECcolumn.Text = controlinfo.Tag;
            //BECominfo.Enabled = false;
            //CECheckState.Enabled = false;
            //TECdicName.Enabled = true;
            //TECdicType.Enabled = true;

        }

        private void PictureEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            PictureEdit pictureEdit = layoutControlItem.Control as PictureEdit;
            //TECname.Text = controlinfo.name;
            //TECdefult.Text = controlinfo.defaultValue;
            //TElayoutName.Text = controlinfo.layoutItemName;
            //TECdicName.Text = "";
            //TECdicType.Text = "";
            //BECominfo.Text = "";
            //CECe.Checked = controlinfo.enabled;
            //CECv.Checked = controlinfo.visible;
            //CECheckState.Checked = false;
            //TECcolumn.Text = controlinfo.Tag;

            //BECominfo.Enabled = false;
            //CECheckState.Enabled = false;
            //TECdicName.Enabled = false;
            //TECdicType.Enabled = false;
        }

        private void ComboBoxEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            ComboBoxEdit comboBoxEdit = layoutControlItem.Control as ComboBoxEdit;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            ////if (controlinfo != null)
            ////{
            //TECname.Text = controlinfo.name;
            //TECdefult.Text = controlinfo.defaultValue;
            //TElayoutName.Text = controlinfo.layoutItemName;
            //TECdicName.Text = "";
            //TECdicType.Text = "";
            //string a = "";
            //if (controlinfo.comboEditVlaues != null && controlinfo.comboEditVlaues.Count > 0)
            //{
            //    foreach (string s in controlinfo.comboEditVlaues)
            //    {
            //        a += s + ",";
            //    }
            //    BECominfo.Text = a.Substring(0, a.Length - 1);
            //}
            //CECe.Checked = controlinfo.enabled;
            //CECv.Checked = controlinfo.visible;
            //CECheckState.Checked = false;
            //TECcolumn.Text = controlinfo.Tag;

            //BECominfo.Enabled = true;
            //CECheckState.Enabled = false;
            //TECdicName.Enabled = false;
            //TECdicType.Enabled = false;
        }

        private void CheckEdit_Click(object sender, EventArgs e)
        {
            LayoutControlItem layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            CheckEdit checkEdit = layoutControlItem.Control as CheckEdit;
            //TECname.Text = controlinfo.name;
            //TECdefult.Text = controlinfo.defaultValue;
            //TElayoutName.Text = controlinfo.layoutItemName;
            //TECdicName.Text = "";
            //TECdicType.Text = "";
            //BECominfo.Text = "";
            //CECe.Checked = controlinfo.enabled;
            //CECv.Checked = controlinfo.visible;
            //CECheckState.Checked = controlinfo.check;
            //TECcolumn.Text = controlinfo.Tag;

            //BECominfo.Enabled = false;
            //CECheckState.Enabled = true;
            //TECdicName.Enabled = false;
            //TECdicType.Enabled = false;
        }
        private void DateEdit_Click(object sender, EventArgs e)
        {
            LayoutControlItem layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            //TECname.Text = controlinfo.name;
            //TECdefult.Text = controlinfo.defaultValue;
            //TElayoutName.Text = controlinfo.layoutItemName;
            //TECdicName.Text = "";
            //TECdicType.Text = "";
            //BECominfo.Text = "";
            //CECe.Checked = controlinfo.enabled;
            //CECv.Checked = controlinfo.visible;
            //CECheckState.Checked = false;
            //TECcolumn.Text = controlinfo.Tag;

            //BECominfo.Enabled = false;
            //CECheckState.Enabled = false;
            //TECdicName.Enabled = false;
            //TECdicType.Enabled = false;
        }

        private void MemoEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            //TECname.Text = controlinfo.name;
            //TECdefult.Text = controlinfo.defaultValue;
            //TElayoutName.Text = controlinfo.layoutItemName;
            //TECdicName.Text = controlinfo.dicName;
            //TECdicType.Text = controlinfo.dicType;
            //BECominfo.Text = "";
            //CECe.Checked = controlinfo.enabled;
            //CECv.Checked = controlinfo.visible;
            //CECheckState.Checked = false;
            //TECcolumn.Text = controlinfo.Tag;

            //BECominfo.Enabled = false;
            //CECheckState.Enabled = false;
            //TECdicName.Enabled = true;
            //TECdicType.Enabled = true;

        }

        #endregion

        #region 控件其他功能


        //combobox添加内容
        //private void BECominfo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        //{

        //    FrmComboEditValues formBarcodeInfo = new FrmComboEditValues(BECominfo.Text);
        //    Func<string> func = formBarcodeInfo.reStringinfo;
        //    formBarcodeInfo.ShowDialog();
        //    string ss = func();
        //    BECominfo.EditValue = ss;
        //    if (ss != "")
        //    {
        //        string[] ssss = BECominfo.EditValue.ToString().Split(',');
        //        controlinfo.comboEditVlaues = ssss.ToList();
        //        comboBoxEdit.Properties.Items.Clear();
        //        comboBoxEdit.Properties.Items.AddRange(ssss);
        //    }
        //    else
        //    {
        //        controlinfo.comboEditVlaues = null;
        //        comboBoxEdit.Properties.Items.Clear();
        //    }

        //}


        //开启摄像头
        private void PictureEditEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                PictureEdit Edit = sender as PictureEdit;
                Edit.ShowTakePictureDialog();
            }
        }
        ////
        //private void PictureEditEdit_Click(object sender, EventArgs e)
        //{
        //    PictureEdit Edit = sender as PictureEdit;
        //    Edit.ShowTakePictureDialog();

        //}
        //打开图片编辑器
        private void PictureEditEdit_DoubleClick(object sender, EventArgs e)
        {
            PictureEdit Edit = sender as PictureEdit;
            //Edit.ImageEditorDialogShowing();
            Edit.ShowImageEditorDialog();
        }

        #endregion

        #region 构建窗体方法

        public void loadFrom(List<controlsInfo> controlsInfos, bool refrm = true)
        {
            if (refrm)
            {
                LCForm.Controls.Clear();
                foreach (controlsInfo controlinfo in controlsInfos)
                {
                    //加载文本框
                    if (controlinfo.type == "TextEdit")
                    {
                        TextEdit Edit = new TextEdit();
                        Edit.Name = controlinfo.name;
                        Edit.Text = controlinfo.defaultValue;
                        Edit.Enabled = controlinfo.enabled;
                        Edit.Visible = controlinfo.visible;
                        Edit.Tag = controlinfo.dicName + "," + controlinfo.dicName;
                        Edit.ToolTip = controlinfo.Tag;
                        MemoEdits.AddDoubleMethod(Edit);

                        LayoutControlItem layoutControlItem = new LayoutControlItem();
                        layoutControlItem.Control = Edit;
                        layoutControlItem.Text = controlinfo.layoutItemName;
                        //layoutControlItem.Click += TextEdit_Click;
                        layoutControlItem.TextVisible = true;
                        layoutControlGroup.AddItem(layoutControlItem);
                    }
                    //加载图片框
                    if (controlinfo.type == "PictureEdit")
                    {
                        PictureEdit Edit = new PictureEdit();
                        Edit.Name = controlinfo.name;
                        Edit.Text = controlinfo.defaultValue;
                        //Edit.KeyDown += Edit_Click;
                        Edit.KeyPress += PictureEditEdit_KeyPress; ;
                        Edit.DoubleClick += PictureEditEdit_DoubleClick;
                        Edit.Properties.SizeMode = PictureSizeMode.Zoom;
                        Edit.Enabled = controlinfo.enabled;
                        Edit.Visible = controlinfo.visible;
                        Edit.Tag = controlinfo.Tag;
                        Edit.ToolTip = controlinfo.Tag;
                        Edit.LoadAsync(controlinfo.imgPath);

                        //Edit.Click += Edit_Click;
                        LayoutControlItem layoutControlItem = new LayoutControlItem();
                        layoutControlItem.Control = Edit;
                        layoutControlItem.Text = controlinfo.layoutItemName;
                        //layoutControlItem.Click += PictureEdit_Click;
                        layoutControlItem.TextVisible = true;
                        layoutControlGroup.AddItem(layoutControlItem);
                    }

                    //加载下拉框
                    if (controlinfo.type == "ComboBoxEdit")
                    {
                        ComboBoxEdit Edit = new ComboBoxEdit();
                        Edit.Name = controlinfo.name;
                        Edit.Text = controlinfo.defaultValue;
                        Edit.Properties.Items.AddRange(controlinfo.comboEditVlaues);
                        Edit.Enabled = controlinfo.enabled;
                        Edit.Visible = controlinfo.visible;
                        Edit.Tag = controlinfo.Tag;
                        Edit.ToolTip = controlinfo.Tag;


                        LayoutControlItem layoutControlItem = new LayoutControlItem();
                        layoutControlItem.Control = Edit;
                        layoutControlItem.Text = controlinfo.layoutItemName;
                        //layoutControlItem.Click += ComboBoxEdit_Click;
                        layoutControlItem.TextVisible = true;
                        layoutControlGroup.AddItem(layoutControlItem);
                    }
                    //加载选择框
                    if (controlinfo.type == "CheckEdit")
                    {
                        CheckEdit Edit = new CheckEdit();
                        Edit.Name = controlinfo.name;
                        Edit.Text = controlinfo.defaultValue;
                        Edit.Checked = controlinfo.check;
                        Edit.Enabled = controlinfo.enabled;
                        Edit.Visible = controlinfo.visible;
                        Edit.Tag = controlinfo.Tag;
                        Edit.ToolTip = controlinfo.Tag;


                        LayoutControlItem layoutControlItem = new LayoutControlItem();
                        layoutControlItem.Control = Edit;
                        layoutControlItem.Text = controlinfo.layoutItemName;
                        //layoutControlItem.Click += CheckEdit_Click;
                        layoutControlItem.TextVisible = true;
                        layoutControlGroup.AddItem(layoutControlItem);
                    }
                    //加载时间框
                    if (controlinfo.type == "DateEdit")
                    {
                        DateEdit Edit = new DateEdit();
                        Edit.Name = controlinfo.name;
                        Edit.Text = controlinfo.defaultValue;
                        Edit.Enabled = controlinfo.enabled;
                        Edit.Visible = controlinfo.visible;
                        Edit.Tag = controlinfo.Tag;
                        Edit.ToolTip = controlinfo.Tag;
                        Edit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        Edit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                        Edit.Properties.EditMask = "yyyy-MM-dd HH:mm:ss";
                        LayoutControlItem layoutControlItem = new LayoutControlItem();
                        layoutControlItem.Control = Edit;
                        layoutControlItem.Text = controlinfo.layoutItemName;
                        //layoutControlItem.Click += DateEdit_Click;
                        layoutControlItem.TextVisible = true;
                        layoutControlGroup.AddItem(layoutControlItem);
                    }
                    //加载富文本框
                    if (controlinfo.type == "MemoEdit")
                    {
                        MemoEdit Edit = new MemoEdit();
                        Edit.Name = controlinfo.name;
                        Edit.Text = controlinfo.defaultValue;

                        Edit.Enabled = controlinfo.enabled;
                        Edit.Visible = controlinfo.visible;
                        //Edit.Tag = controlinfo.Tag;
                        Edit.ToolTip = controlinfo.Tag;
                        Edit.Tag = controlinfo.dicName + "," + controlinfo.dicType;
                        MemoEdits.AddDoubleMethod(Edit);

                        LayoutControlItem layoutControlItem = new LayoutControlItem();
                        layoutControlItem.Control = Edit;
                        layoutControlItem.Text = controlinfo.layoutItemName;
                        //layoutControlItem.Click += MemoEdit_Click;
                        layoutControlItem.TextVisible = true;
                        layoutControlGroup.AddItem(layoutControlItem);
                    }

                }
            }
            else
            {
                foreach (var gccontrol in LCForm.Items)
                {
                    if (gccontrol is LayoutControlGroup)
                    {
                        LayoutControlGroup lControlGroup = gccontrol as LayoutControlGroup;
                        foreach (var lcontrol in lControlGroup.Items)
                        {
                            if (lcontrol is LayoutControlItem)
                            {
                                LayoutControlItem lControlItem = lcontrol as LayoutControlItem;
                                if (lControlItem.Control != null)
                                {
                                    foreach (controlsInfo controlsInfo in controlsInfos)
                                    {
                                        if (controlsInfo.name == lControlItem.Control.Name)
                                        {
                                            if (controlsInfo.type == "CheckEdit")
                                            {
                                                CheckEdit checkEdit = lControlItem.Control as CheckEdit;
                                                checkEdit.Checked = controlsInfo.check;
                                            }
                                            else
                                            {

                                                if (controlsInfo.type == "PictureEdit")
                                                {
                                                    PictureEdit Edit = lControlItem.Control as PictureEdit;
                                                    Edit.Text = controlsInfo.defaultValue;
                                                    //Edit.KeyDown += Edit_Click;
                                                    //Edit.KeyPress += PictureEditEdit_KeyPress; ;
                                                    //Edit.DoubleClick += PictureEditEdit_DoubleClick;
                                                    //Edit.Properties.SizeMode = PictureSizeMode.Zoom;
                                                    //Edit.Enabled = controlinfo.enabled;
                                                    //Edit.Visible = controlinfo.visible;
                                                    //Edit.Tag = controlinfo.Tag;
                                                    //Edit.ToolTip = controlinfo.Tag;
                                                    Edit.LoadAsync(controlsInfo.imgPath);
                                                }
                                                else
                                                {

                                                    lControlItem.Control.Text = controlsInfo.defaultValue;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }


        }


        #endregion
    }





    public class controlsInfo
    {
        /// <summary>
        /// layoutItem名称
        /// </summary>
        public string layoutItemName { get; set; }
        /// <summary>
        /// 控件名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 控件绑定字段名称
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string defaultValue { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string imgPath { get; set; }
        /// <summary>
        /// 是否选择
        /// </summary>
        public bool check { get; set; }
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool enabled { get; set; } = true;
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool visible { get; set; } = true;
        /// <summary>
        /// 下拉框值
        /// </summary>
        public List<string> comboEditVlaues { get; set; }

        /// <summary>
        /// 绑定字典
        /// </summary>
        public string dicName { get; set; }
        /// <summary>
        /// 绑定字典类型
        /// </summary>
        public string dicType { get; set; }
    }
}
