using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.Groups
{
    public partial class FrmTestPower : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.GroupPower";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID



        public FrmTestPower()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }


            GridControls.formartGridView(GVInfo);



            GridLookUpEdites.Formats(RGEworkNO);
            GridLookUpEdites.Formats(RGEuserNO);
            RGEworkNO.DataSource = WorkCommData.DTGroupWork;
            RGEuserNO.DataSource = CommonData.DTUserInfoAll;
            GCInfo.DataSource = DTHelper.DTVisible(WorkCommData.DTGroupTest);





        }

        private void FrmTestGroup_Load(object sender, EventArgs e)
        {

            groupList.Enabled = false;
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

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (SelectValueID != 0)
            {
                EditState = 1;
                groupList.Enabled = true;
                GVGroupPower.AddNewRow();
            }
            else
            {
                MessageBox.Show("请选择专业组", "系统提示！");
            }

        }
        string workNOa = "";
        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 2;
            groupList.Enabled = true;
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                DataRow dataRow = GVInfo.GetFocusedDataRow();
                SelectValueID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                string TestNO = dataRow["no"] != DBNull.Value ? dataRow["no"].ToString() : "";
                workNOa = dataRow["workNO"] != DBNull.Value ? dataRow["workNO"].ToString() : "";

                //string TestNO = GVInfo.GetFocusedRowCellValue("no").ToString();
                if (TestNO != "")
                {
                    if (WorkCommData.DTGroupPower != null)
                    {

                        if (WorkCommData.DTGroupPower.Select($"testNO='{TestNO}' and workNO='{workNOa}'").Count() > 0)
                        {
                            GCGroupPower.DataSource = WorkCommData.DTGroupPower.Select($"testNO='{TestNO}' and workNO='{workNOa}'").CopyToDataTable();
                            GVGroupPower.BestFitColumns();
                        }
                        else
                        {
                            DataTable dt = WorkCommData.DTGroupPower.Clone();
                            GCGroupPower.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 0;
            GVGroupPower.FocusedRowHandle = -1;

            DataTable data = GCGroupPower.DataSource as DataTable;
            ApiHelpers.postInfo(data, tableName);
            CommonDataRefresh.GetGroupPower();
            FrmTestGroup_Load(null, null);
        }

        private void GVGroupPower_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ColumnView View = sender as ColumnView;

            View.SetRowCellValue(e.RowHandle, View.Columns["workNO"], workNOa); //复制最后一行的数据到新行
            //View.SetRowCellValue(e.RowHandle, View.Columns["testNO"], string.Format("{0:000}", GVInfo.GetFocusedRowCellValue("no"))); //复制最后一行的数据到新行
            View.SetRowCellValue(e.RowHandle, View.Columns["testNO"], GVInfo.GetFocusedRowCellValue("no")); //复制最后一行的数据到新行
            //View.SetRowCellValue(e.RowHandle, View.Columns["state"], GVGroupPower.GetRowCellValue(GVGroupPower.GetRowHandle(GVGroupPower.RowCount - 2), GVGroupPower.Columns[0])); //复制最后一行的数据到新行 
            View.SetRowCellValue(e.RowHandle, View.Columns["state"], true); //复制最后一行的数据到新行 


            //View.SetRowCellValue(e.RowHandle, View.Columns[1], GVGroupPower.GetRowCellValue(GVGroupPower.GetRowHandle(GVGroupPower.RowCount - 2), GVGroupPower.Columns[1])); //复制最后一行的数据到新行 
        }

        private void splitContainerControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (GVGroupPower.GetFocusedRowCellValue("id") != DBNull.Value)
            {
                int idaa = Convert.ToInt32(GVGroupPower.GetFocusedDataRow()["id"]);
                if (idaa != 0)
                {
                    int asa = DeleteHelper.deleteinfo(idaa, tableName);
                    if (asa > 0)
                    {
                        CommonDataRefresh.GetGroupPower();
                        GVGroupPower.DeleteSelectedRows();
                    }
                }
            }
            else
            {
                GVGroupPower.DeleteSelectedRows();
            }


            
        }
    }
}
