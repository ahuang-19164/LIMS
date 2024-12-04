using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workOther.SampleStores
{
    public partial class FrmStoresPower : XtraForm
    {

        string tableName = "dbo.sw_stores";
        string storesPowerTableName = "dbo.sw_storespower";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable userpowerDT = null;

        public FrmStoresPower()
        {
            InitializeComponent();
        }
        private void FrmStores_Load(object sender, EventArgs e)
        {
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            //GridLookUpEdites.Formats(GEsampleType);
            //GridLookUpEdites.Formats(RGEsampleType);
            ////TextEdits.TextFormatDecimal(TEDiscount);
            ////TextEdits.TextFormatDecimal(RTEDiscount);
            //TextEdits.TextFormat(TEDay);
            //TextEdits.TextFormat(TESort);
            //TextEdits.TextFormat(TECell);
            //TextEdits.TextFormat(TERow);
            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);

            GridControls.formartGridView(GVUserList);
            GridControls.showEmbeddedNavigator(GCUserList);


            sInfo selectInfo = new sInfo();
            selectInfo.TableName = tableName;
            selectInfo.OrderColumns = "sort";
            GCInfo.DataSource = DTHelper.DTVisible(ApiHelpers.postInfo(selectInfo));


            //GridLookUpEdites.Formats(RGEworkNO);
            GridLookUpEdites.Formats(RGEuserNO);
            //RGEworkNO.DataSource = WorkCommData.DTGroupWork;
            RGEuserNO.DataSource = CommonData.DTUserInfoAll;


            userpowerDT = new DataTable();
            userpowerDT.Columns.Add("id",typeof(int));
            userpowerDT.Columns.Add("userNo", typeof(string));
            userpowerDT.Columns.Add("storesid", typeof(int));
            userpowerDT.Columns.Add("state", typeof(bool));
            userpowerDT.Columns.Add("createShelf", typeof(bool));
            userpowerDT.Columns.Add("editShelf", typeof(bool));
            userpowerDT.Columns.Add("entrySample", typeof(bool));
            userpowerDT.Columns.Add("editSample", typeof(bool));
            userpowerDT.Columns.Add("delsample", typeof(bool));
            userpowerDT.Columns.Add("handleSample", typeof(bool));
            userpowerDT.Columns.Add("rehandleSample", typeof(bool));
            userpowerDT.Columns.Add("searchSample", typeof(bool));
            userpowerDT.Columns.Add("cancelSample", typeof(bool));


            GUserInfo.Enabled = false;

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
                GUserInfo.Enabled = true;
                GVUserList.AddNewRow();
            }
            else
            {
                MessageBox.Show("请选择存储库", "系统提示！");
            }
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 2;
            GUserInfo.Enabled = true;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 0;
            GUserInfo.Enabled = false;
            GVUserList.FocusedRowHandle = -1;

            DataTable data = GCUserList.DataSource as DataTable;
            ApiHelpers.postInfo(data, storesPowerTableName);
            //CommonDataRefresh.GetGroupPower();
            //FrmStores_Load(null, null);
            GVInfo_RowClick(null, null);
        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVUserList.GetFocusedRowCellValue("id") != DBNull.Value)
            {
                int idaa = Convert.ToInt32(GVUserList.GetFocusedDataRow()["id"]);
                if (idaa != 0)
                {
                    int asa = DeleteHelper.deleteinfo(idaa, storesPowerTableName);
                    if (asa > 0)
                    {
                        //CommonDataRefresh.GetGroupPower();
                        GVUserList.DeleteSelectedRows();
                    }
                }
            }
            else
            {
                GVUserList.DeleteSelectedRows();
            }
        }

        private void TENames_Leave(object sender, EventArgs e)
        {
            //if (TENames.EditValue != null)
            //{
            //    TEShortNames.EditValue = ConvertShortName.GetChineseSpell(TENames.EditValue.ToString());
            //}
        }

        private void GVInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow storesDR = GVInfo.GetFocusedDataRow();
            if(storesDR!=null)
            {
                SelectValueID = storesDR["id"] != DBNull.Value ? Convert.ToInt32(storesDR["id"]) : 0;
                sInfo sInfo = new sInfo();
                sInfo.TableName = storesPowerTableName;
                sInfo.wheres = $"storesid={SelectValueID}";
               DataTable dt= ApiHelpers.postInfo(sInfo);

                if(dt!=null)
                {
                    GCUserList.DataSource = dt;
                }
                else
                {
                    GCUserList.DataSource = userpowerDT;
                }

            }
            else
            {
               
                SelectValueID = 0;
            }

        }

        private void GVUserList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ColumnView View = sender as ColumnView;

            View.SetRowCellValue(e.RowHandle, View.Columns["storesid"], SelectValueID); //复制最后一行的数据到新行
            //View.SetRowCellValue(e.RowHandle, View.Columns["testNO"], string.Format("{0:000}", GVInfo.GetFocusedRowCellValue("no"))); //复制最后一行的数据到新行
            View.SetRowCellValue(e.RowHandle, View.Columns["userNo"], ""); //复制最后一行的数据到新行
            //View.SetRowCellValue(e.RowHandle, View.Columns["state"], GVGroupPower.GetRowCellValue(GVGroupPower.GetRowHandle(GVGroupPower.RowCount - 2), GVGroupPower.Columns[0])); //复制最后一行的数据到新行 
            View.SetRowCellValue(e.RowHandle, View.Columns["state"], true); //复制最后一行的数据到新行 
            View.SetRowCellValue(e.RowHandle, View.Columns["createShelf"],false);
            View.SetRowCellValue(e.RowHandle, View.Columns["editShelf"],false);
            View.SetRowCellValue(e.RowHandle, View.Columns["entrySample"],false);
            View.SetRowCellValue(e.RowHandle, View.Columns["editSample"],false);
            View.SetRowCellValue(e.RowHandle, View.Columns["delsample"],false);
            View.SetRowCellValue(e.RowHandle, View.Columns["handleSample"],false);
            View.SetRowCellValue(e.RowHandle, View.Columns["rehandleSample"],false);
            View.SetRowCellValue(e.RowHandle, View.Columns["searchSample"],false);
            View.SetRowCellValue(e.RowHandle, View.Columns["cancelSample"],false);


        }
    }
}
