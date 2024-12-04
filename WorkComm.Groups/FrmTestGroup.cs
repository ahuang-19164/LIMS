using Common.BLL;
using Common.Conn;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.Groups
{
    public partial class FrmTestGroup : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.GroupTest";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable frmDt;

        public FrmTestGroup()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridControls.formartGridView(GVInfo);







            GridLookUpEdites.Formats(RGEworkNO);
            GridLookUpEdites.Formats(GEworkNO);
            GridLookUpEdites.Formats(GEratifier);
            GridLookUpEdites.Formats(GEtestPreson);
            GridLookUpEdites.Formats(RGEcontrolType);
            TextEdits.TextFormat(TESort);
            GridControls.formartGridView(GVGroupGird);
            RGEworkNO.DataSource = WorkCommData.DTGroupWork;
            GEworkNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupWork);
            GEtestPreson.Properties.DataSource = GEratifier.Properties.DataSource = DTHelper.DTEnable(CommonData.DTUserInfoAll);
            RGEcontrolType.DataSource = ControlClass.ControlType();
            if (WorkCommData.DTGroupGridView != null)
                frmDt = WorkCommData.DTGroupGridView.Clone();
        }

        private void FrmTestGroup_Load(object sender, EventArgs e)
        {


            GCInfo.DataSource = DTHelper.DTVisible(WorkCommData.DTGroupTest);
            layoutControlGroup1.Enabled = false;
            GCGroupGrid.Enabled = false;
            GVInfo.ExpandAllGroups();
            GVInfo.BestFitColumns();

        }

        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {
            //string[] PowerList = CommonData.powerList;
            foreach (BarItem BT in barManager1.Items)
            {
                if (CommonData.UserInfo.id != 1)
                {
                    if (BT.Tag != null)
                    {
                        if (CommonData.powerList.Contains(BT.Tag.ToString()))
                        {
                            BT.Enabled = true;
                        }
                        else
                        {
                            BT.Enabled = false;
                        }
                    }
                    else
                    {
                        BT.Enabled = false;
                    }
                }
                else
                {
                    BT.Enabled = true;
                }

            }
        }



        private void BTAddGroup_Click(object sender, EventArgs e)
        {
            BTAdd_ItemClick(null, null);
        }
        private void BTEditGroup_Click(object sender, EventArgs e)
        {
            BTEdit_ItemClick(null, null);
        }

        private void BTSaveGroup_Click(object sender, EventArgs e)
        {
            BTSaveCompany_ItemClick(null, null);
        }
        private void BTDeleteGroup_Click(object sender, EventArgs e)
        {
            BTDelect_ItemClick(null, null);
        }


        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 1;
            layoutControlGroup1.Enabled = true;
            if (WorkCommData.DTGroupTest.Select("no is not NULL", "no DESC").Count() == 0)
            {
                TEno.EditValue = 1;
            }
            else
            {
                TEno.EditValue = Convert.ToInt32(WorkCommData.DTGroupTest.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }


            //TENO.EditValue = string.Format("{0:000}", Convert.ToInt32(CommSystemInfo.DTDepartmentInfoAll.Select("no is not NULL", "no DESC")[0]["no"]) + 1);
            TEnames.EditValue = "";
            GEworkNO.EditValue = "";
            PEItemImg.EditValue = "";
            GEtestPreson.EditValue = "";
            GEratifier.EditValue = "";
            TEPhone.EditValue = "";
            TEFunctions.EditValue = "";
            TERemark.EditValue = "";
            TESort.EditValue = "";
            CBReviewState.Checked = false;
            CBTREqual.Checked = false;
            CBTCEqual.Checked = false;
            CBRCEqual.Checked = false;
            CBState.Checked = false;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 2;
            layoutControlGroup1.Enabled = true;
        }
        Bitmap Bitmaps = null;
        object WorkNOss = "";
        object TestNOss = "";



        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                SelectValueID = Convert.ToInt32(GVInfo.GetFocusedRowCellValue("id"));
                DataRow[] rows = WorkCommData.DTGroupTest.Select($"id='{SelectValueID}'");
                if (rows.Count() != 0)
                {
                    TEno.EditValue = TestNOss = rows[0]["no"];
                    TEnames.EditValue = rows[0]["names"];
                    PEItemImg.Image = Bitmaps = FileConverHelpers.StringToBitmap(rows[0]["itemImg"].ToString());
                    GEworkNO.EditValue = WorkNOss = rows[0]["WorkNO"];
                    GEtestPreson.EditValue = rows[0]["TestPreson"];
                    GEratifier.EditValue = rows[0]["Ratifier"];
                    TEPhone.EditValue = rows[0]["PresonPhone"];
                    TEFunctions.EditValue = rows[0]["Functions"];
                    TERemark.EditValue = rows[0]["Remark"];
                    TESort.EditValue = rows[0]["sort"];
                    CBReviewState.Checked = Convert.ToBoolean(rows[0]["ReviewState"]);
                    CBTREqual.Checked = Convert.ToBoolean(rows[0]["TREqual"]);
                    CBTCEqual.Checked = Convert.ToBoolean(rows[0]["TCEqual"]);
                    CBRCEqual.Checked = Convert.ToBoolean(rows[0]["RCEqual"]);
                    CBState.Checked = Convert.ToBoolean(rows[0]["state"]);






                    sInfo selectInfo3 = new sInfo();
                    selectInfo3.TableName = "WorkComm.GroupGridView";
                    selectInfo3.wheres = $"TestNO='{TestNOss}'";
                    selectInfo3.OrderColumns = "sort";
                    DataTable dataTable = ApiHelpers.postInfo(selectInfo3);
                    if (dataTable != null)
                    {
                        GCGroupGrid.DataSource = dataTable;
                        GVGroupGird.BestFitColumns();
                    }
                    else
                    {
                        GCGroupGrid.DataSource = frmDt;
                        GVGroupGird.BestFitColumns();
                    }
                }

            }
        }

        private void BTSaveCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (EditState == 1)
            {
                Bitmap Bitmapsaa = Bitmaps;
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TEno.EditValue);
                pairs.Add("names", TEnames.EditValue);
                pairs.Add("WorkNO", GEworkNO.EditValue);
                pairs.Add("TestPreson", GEtestPreson.EditValue);
                pairs.Add("Ratifier", GEratifier.EditValue);
                pairs.Add("PresonPhone", TEPhone.EditValue);
                pairs.Add("itemImg", FileConverHelpers.BitmapTostring(Bitmapsaa));
                pairs.Add("Functions", TEFunctions.EditValue);
                pairs.Add("Remark", TERemark.EditValue);
                pairs.Add("sort", TESort.EditValue);
                pairs.Add("ReviewState", CBReviewState.Checked);
                pairs.Add("TREqual", CBTREqual.Checked);
                pairs.Add("TCEqual", CBTCEqual.Checked);
                pairs.Add("RCEqual", CBRCEqual.Checked);
                pairs.Add("state", CBState.Checked);
                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int a = ApiHelpers.postInfo(insertInfo);



            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Bitmap Bitmapsaa = Bitmaps;
                    string aaaa = FileConverHelpers.BitmapTostring(Bitmapsaa);
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    pairs.Add("no", TEno.EditValue);
                    pairs.Add("names", TEnames.EditValue);
                    pairs.Add("WorkNO", GEworkNO.EditValue);
                    pairs.Add("TestPreson", GEtestPreson.EditValue);
                    pairs.Add("Ratifier", GEratifier.EditValue);
                    pairs.Add("PresonPhone", TEPhone.EditValue);
                    pairs.Add("itemImg", FileConverHelpers.BitmapTostring(Bitmapsaa));
                    pairs.Add("Functions", TEFunctions.EditValue);
                    pairs.Add("Remark", TERemark.EditValue);
                    pairs.Add("sort", TESort.EditValue);
                    pairs.Add("ReviewState", CBReviewState.Checked);
                    pairs.Add("TREqual", CBTREqual.Checked);
                    pairs.Add("TCEqual", CBTCEqual.Checked);
                    pairs.Add("RCEqual", CBRCEqual.Checked);
                    pairs.Add("state", CBState.Checked);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                }

            }
            EditState = 0;
            CommonDataRefresh.GetGroupTest();
            FrmTestGroup_Load(null, null);
            layoutControlGroup1.Enabled = false;
        }
        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确定删除当前信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.Yes)
            {
                if (SelectValueID != 0)
                {
                    int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                    if (a > 0)
                    {
                        CommonDataRefresh.GetGroupTest();
                        GVInfo.DeleteSelectedRows();
                    }
                }
            }
        }

        private void BTUpLoadFile_Click(object sender, EventArgs e)
        {


            string a = OpenFileHelpers.GetFilePath();
            if (a != "")
            {
                PEItemImg.Image = Bitmaps = FileConverHelpers.FilePathToBitmap(a);
            }
            //OpenFileHelper openFile = new OpenFileHelper();
            //string filepath = OpenFileHelpers.GetFilePath();
            //PEItemImg.Image = Bitmaps = FileConverHelpers.FilePathToBitmap(filepath);
        }

        #region 列表管理按钮
        private void BTAddColumns_Click(object sender, EventArgs e)
        {
            GVGroupGird.AddNewRow();
            GCGroupGrid.Enabled = true;
        }

        private void BTEditColumns_Click(object sender, EventArgs e)
        {
            GCGroupGrid.Enabled = true;
        }

        private void BTASaveColumns_Click(object sender, EventArgs e)
        {
            GVGroupGird.FocusedRowHandle = -1;
            DataTable data = GCGroupGrid.DataSource as DataTable;
            if (data != null)
            {
                ApiHelpers.postInfo(data, "WorkComm.GroupGridView");
            }
            GCGroupGrid.Enabled = false;
            WorkCommDataHandle.GetGroupGridView();
        }

        private void BTDeleteColumns_Click(object sender, EventArgs e)
        {
            if(GVGroupGird.GetFocusedRowCellValue("id")!=DBNull.Value)
            {
                int viewid = Convert.ToInt32(GVGroupGird.GetFocusedRowCellValue("id"));
                if (SelectValueID != 0)
                {
                    int asa = DeleteHelper.deleteinfo(viewid, "WorkComm.GroupGridView");
                    if (asa > 0)
                    {

                        GVGroupGird.DeleteSelectedRows();
                    }
                }
            }
            else
            {
                GVGroupGird.DeleteSelectedRows();
            }

            
        }
        private void GVGroupGird_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (TestNOss != null && WorkNOss != null)
            {
                GVGroupGird.SetRowCellValue(e.RowHandle, "testNO", TestNOss);
                GVGroupGird.SetRowCellValue(e.RowHandle, "workNO", WorkNOss);
                GVGroupGird.SetRowCellValue(e.RowHandle, "controlType", "1");
                GVGroupGird.SetRowCellValue(e.RowHandle, "controlVisible", true);
                GVGroupGird.SetRowCellValue(e.RowHandle, "controlEnabled", true);
                GVGroupGird.SetRowCellValue(e.RowHandle, "allFocus", true);
                GVGroupGird.SetRowCellValue(e.RowHandle, "allowEdit", true);
                GVGroupGird.SetRowCellValue(e.RowHandle, "readOnly", true);
                GVGroupGird.SetRowCellValue(e.RowHandle, "sort", "999");
                GVGroupGird.SetRowCellValue(e.RowHandle, "state", true);
            }
            else
            {
                MessageBox.Show("请选择需要编辑的专业组", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }




        #endregion

    }
}
