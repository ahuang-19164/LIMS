using Common.BLL;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmGridColumns : DevExpress.XtraEditors.XtraForm
    {
        string tableName = "Common.GridColumns";
#pragma warning disable CS0414 // 字段“FrmGridColumns.EditState”已被赋值，但从未使用过它的值
        int EditState = 0;//1.新增 2.编辑
#pragma warning restore CS0414 // 字段“FrmGridColumns.EditState”已被赋值，但从未使用过它的值
        public FrmGridColumns()
        {
            InitializeComponent();
            gridView1.IndicatorWidth = 40;
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
        }

        private void FrmGridColumns_Load(object sender, EventArgs e)
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = tableName;
            selectInfo.OrderColumns = "ControlNO,sort";
            gridControl1.DataSource = CommonData.DTWebPowerListAll = ApiHelpers.postInfo(selectInfo);
            gridView1.BestFitColumns();
            DataTable data = new DataTable();
            data.Columns.Add("no", typeof(string));
            data.Columns.Add("names", typeof(string));
            data.Rows.Add("GridControl", "列表菜单");
            data.Rows.Add("LayoutControl", "控件菜单");

            repositoryItemLookUpEdit1.DataSource = data;
            repositoryItemLookUpEdit1.ValueMember = "no";
            repositoryItemLookUpEdit1.DisplayMember = "Name";


            DataTable data2 = new DataTable();
            data2.Columns.Add("no", typeof(string));
            data2.Columns.Add("names", typeof(string));
            data2.Rows.Add("textedit", "文本框");
            data2.Rows.Add("checkedit", "选择框");
            data2.Rows.Add("dateedit", "日期框");
            data2.Rows.Add("lookupedit", "下拉框");

            repositoryItemLookUpEdit2.DataSource = data2;
            repositoryItemLookUpEdit2.ValueMember = "no";
            repositoryItemLookUpEdit2.DisplayMember = "Name";


        }
        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {
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
            try
            {

                gridView1.AddNewRow();


            }
            catch
            {
                MessageBox.Show("编号类型错误！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            gridView1.FocusedRowHandle = -1;
            DataTable DT2 = gridControl1.DataSource as DataTable;
            //SqlConnServer.save(DT2, tableName);
        }


        int ExpandState = 0;
        private void BTExpand_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ExpandState == 0)
            {
                BTExpand.Caption = "关闭节点";
                gridView1.OptionsBehavior.AutoExpandAllGroups = true;
                ExpandState = 1;
            }
            else
            {
                BTExpand.Caption = "展开节点";
                gridView1.OptionsBehavior.AutoExpandAllGroups = false;
                ExpandState = 0;
            }

        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["controlName"], "ControlName");
            view.SetRowCellValue(e.RowHandle, view.Columns["controlNO"], "1000000");
        }
    }
}
