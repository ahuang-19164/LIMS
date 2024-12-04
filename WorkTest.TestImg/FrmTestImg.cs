using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using Common.TestModel.Result;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WorkTest.TestImg
{
    public partial class FrmTestImg : DevExpress.XtraEditors.XtraForm
    {
        RepositoryItemComboBox comboBox;
        RepositoryItemTextEdit itemTextEdit;
        string SetResultTest = "";
        public FrmTestImg()
        {
            InitializeComponent();


            SetResultTest = ConfigInfos.ReadConfigInfo("SetResultTest");
            comboBox = new RepositoryItemComboBox();
            itemTextEdit = new RepositoryItemTextEdit();

            comboBox.Items.Add("阴性(-)");
            comboBox.Items.Add("阳性(+)");
            comboBox.Items.Add("未检出");
            comboBox.Items.Add("待定");
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            TextEdits.TextFormatDecimal(itemTextEdit);
            GridControls.formartGridView(GVTestInfo);
            GridControls.showEmbeddedNavigator(GCTestInfo);
            GVTestInfo.CustomRowCellEdit += GVTestInfo_CustomRowCellEdit;
            GVTestInfo.CustomDrawCell += GVTestInfo_CustomDrawCell;
            panelControl1.Width = 200;
        }

        private void GVTestInfo_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "flag")
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() == "↑↑")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                        if (e.CellValue.ToString() == "↓↓")
                        {
                            e.Appearance.BackColor = Color.AliceBlue;
                        }
                        if (e.CellValue.ToString() == "↑")
                        {
                            e.Appearance.BackColor = Color.IndianRed;
                        }
                        if (e.CellValue.ToString() == "↓")
                        {
                            e.Appearance.BackColor = Color.CadetBlue;
                        }
                    }
                }
                if (e.Column.FieldName == "itemResult")
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() == "阳性(+)")
                        {
                            e.Appearance.BackColor = Color.Red;
                        }
                        if (e.CellValue.ToString() == "阴性(-)")
                        {
                            e.Appearance.BackColor = Color.Green;
                        }
                        //if (e.CellValue.ToString() == "↑")
                        //{
                        //    e.Appearance.BackColor = Color.IndianRed;
                        //}
                        if (e.CellValue.ToString() == "待定")
                        {
                            e.Appearance.BackColor = Color.YellowGreen;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GVTestInfo_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "itemResult")
            {
                if (GVTestInfo.GetDataRow(e.RowHandle)["resultTypeNO"] != DBNull.Value)
                {
                    if (GVTestInfo.GetDataRow(e.RowHandle)["resultTypeNO"].ToString() == "4")
                    {
                        e.RepositoryItem = comboBox;
                    }
                    if (GVTestInfo.GetDataRow(e.RowHandle)["resultTypeNO"].ToString() == "3")
                    {
                        e.RepositoryItem = itemTextEdit;
                    }
                }

                //else
                //{
                //    e.RepositoryItem = this.repositorytxtProcUser;
                //}
            }

        }

        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="Barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {
            Task<DataTable> ResultTask = new Task<DataTable>(() =>
            {
                sInfo selectInfo = new sInfo();
                selectInfo.TableName = "WorkTest.SampleResult";
                selectInfo.wheres = $"testid='{testid}' and dstate=0";
                selectInfo.OrderColumns = "itemSort";
                //DataTable DTResult = ApiHelpers.postInfo(selectInfo);
                return ApiHelpers.postInfo(selectInfo);
            });
            ResultTask.Start();
            GCTestInfo.DataSource = ResultTask.Result;
            GVTestInfo.BestFitColumns();
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="ResultState">结果结果状态 1.检验者 2.复初审者 3.审核者.4.反审核</param>
        /// <returns>0,保存失败，1，结果为空值，2，保存成功</returns>
        public string postResultInfo(int ResultState,int perid, int testid,string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        {
            GVTestInfo.FocusedRowHandle = -1;




            //Task<string> task = new Task<string>(() =>
            //{
            if (ResultState == 4)
            {
                CommResultModel<TestInfoModel> testInfo = new CommResultModel<TestInfoModel>();
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
                    CommResultModel<TestInfoModel> testInfo = new CommResultModel<TestInfoModel>();
                    testInfo.UserName = CommonData.UserInfo.names;
                    
                    testInfo.ResultState = ResultState;
                    TestInfoModel resultTest = new TestInfoModel();
                    resultTest.barcode = barcode;
                    resultTest.perid = perid;
                    resultTest.testid = testid; resultTest.sampleID = sampleid;
                    resultTest.groupNO = groupNO;
                    resultTest.State = true;
                    resultTest.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    List<ItemResultModel> itemResults = new List<ItemResultModel>();
                    //List<ItemResultModel> itemResults = new List<ItemResultModel>();
                    DataTable dataTable = GCTestInfo.DataSource as DataTable;

                    bool saveState = true;
                    foreach (DataRow row in dataTable.Rows)
                    //for (int a = 0; a < GVTestInfo.RowCount; a++)
                    {
                        //DataRow row = GVTestInfo.GetDataRow(a);
                        if (row["resultNullState"] != DBNull.Value && Convert.ToBoolean(row["resultNullState"]))
                        {
                            ItemResultModel itemResult = new ItemResultModel();
                            //ItemResultModel itemResult = new ItemResultModel();
                            itemResult.itemCode = row["itemCodes"] != DBNull.Value ? row["itemCodes"].ToString() : "";
                            itemResult.itemResult = row["itemResult"] != DBNull.Value ? row["itemResult"].ToString() : "";
                            itemResult.itemFlag = row["flag"] != DBNull.Value ? row["flag"].ToString() : "";
                            itemResult.itemReportState = row["reportState"] != DBNull.Value ? row["reportState"].ToString() : "true";
                            itemResult.itemSort = row["itemSort"] != DBNull.Value ? Convert.ToInt32(row["itemSort"]) : 99;
                            //itemResult.itemSort = row["itemSort"] != row.;
                            //itemResult.resultNullState = row["resultNullState"].ToString();
                            itemResults.Add(itemResult);
                        }
                        else
                        {

                            if (row["itemResult"] != DBNull.Value && row["itemResult"].ToString().Trim().Length > 0)
                            {

                                ItemResultModel itemResult = new ItemResultModel();
                                itemResult.itemCode = row["itemCodes"] != DBNull.Value ? row["itemCodes"].ToString() : "";
                                itemResult.itemResult = row["itemResult"] != DBNull.Value ? row["itemResult"].ToString() : "";
                                itemResult.itemFlag = row["flag"] != DBNull.Value ? row["flag"].ToString() : "";
                                itemResult.itemReportState = row["reportState"] != DBNull.Value ? row["reportState"].ToString() : "true";
                                itemResult.itemSort = row["itemSort"] != DBNull.Value ? Convert.ToInt32(row["itemSort"]) : 99;
                                //itemResult.resultNullState = row["resultNullState"].ToString();
                                itemResults.Add(itemResult);
                            }
                            else
                            {
                                saveState = false;
                            }
                        }

                    }

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
                    return "{\"code\":1,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息！\"}";
                }
            }
            //});
            //task.Start();
            //string aaaa= task.Result;
            //return aaaa;
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





        #region 图片处理

        private void BTUpImg_Click(object sender, EventArgs e)
        {
            try
            {
                string FilePath = OpenFileHelpers.GetFilePath(FileExtensionName.img);
                if (FilePath.Length != 0)
                {
                    Bitmap bitmap = new Bitmap(FilePath);
                    Bitmap bitmaps = new Bitmap(bitmap);
                    NewPictureEdit("阅片采图", null, "2", bitmaps);
                    bitmap.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("请选择正确文件", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        PictureEdit pictureEdit;
        int pictureEditLocationys = 0;
        /// <summary>
        /// 新建SuperPictureEdit
        /// </summary>
        /// <param name="PictureName">图片名称</param>
        /// <param name="pictureDye">染色倍数</param>
        /// <param name="bitmap">图像</param>
        private void NewPictureEdit(string className, string PictureDye, string classNO, Bitmap bitmap)
        {
            try
            {

                if (bitmap != null)
                {
                    PictureEdit pictureEdit = new PictureEdit();
                    pictureEdit.Location = new System.Drawing.Point(pictureEditLocationys, 0);
                    pictureEdit.Size = new Size(200, 200);
                    pictureEdit.Image = bitmap;
                    pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                    panelControl1.Controls.Add(pictureEdit);
                    pictureEditLocationys += 210;
                    pictureEdit.DoubleClick += PictureEdit_DoubleClick;
                    pictureEdit.Click += PictureEdit_Click;
                }
            }
            catch
            {
                MessageBox.Show("请选择正确文件", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureEdit_Click(object sender, EventArgs e)
        {
            pictureEdit = sender as PictureEdit;
        }

        private void PictureEdit_DoubleClick(object sender, EventArgs e)
        {
            PictureEdit pictureEdit = sender as PictureEdit;
            pictureEdit.ShowImageEditorDialog();
        }

        private void BTDeleteImg_Click(object sender, EventArgs e)
        {
            int yy = 0;
            panelControl1.Controls.Remove(pictureEdit);
            foreach (Control control in panelControl1.Controls)
            {
                control.Location = new System.Drawing.Point(yy, 0);
                yy += 210;
            }
            pictureEditLocationys = yy;
        }
        #endregion
    }
}
