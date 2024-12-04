﻿using Common.BLL;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmWebModuleInfo : DevExpress.XtraEditors.XtraForm
    {
        
        string tableName = "Common.PowerListWeb";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmWebModuleInfo()
        {
            InitializeComponent();
            treeList1.IndicatorWidth = 40;
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }

        }

        private void FrmModuleInfo_Load(object sender, EventArgs e)
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = tableName;
            selectInfo.OrderColumns = "no,moduleNO,sort";

            treeList1.DataSource = repositoryItemLookUpEdit1.DataSource = CommonData.DTPowerListAll = ApiHelpers.postInfo(selectInfo);


            repositoryItemLookUpEdit1.DisplayMember = "names";
            repositoryItemLookUpEdit1.ValueMember = "no";
            treeList1.KeyFieldName = "no";
            treeList1.ParentFieldName = "moduleNO";

            TEModuleNO.Properties.DataSource = CommonData.DTPowerListAll;
            TEModuleNO.Properties.ValueMember = "no";
            TEModuleNO.Properties.DisplayMember = "names";


            //gridView1.ExpandAllGroups();
            //gridView1.BestFitColumns();
            treeList1.BestFitColumns();
            repositoryItemPictureEdit1.BestFitWidth = 20;
            BTExpand.Caption = "关闭节点";
            treeList1.Nodes[0].ExpandAll();
            ExpandState = 1;


            layoutControlGroup1.Enabled = false;
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
                EditState = 1;
                if (treeList1.FocusedNode != null)
                {
                    layoutControlGroup1.Enabled = true;
                    DataTable DT2 = treeList1.DataSource as DataTable;
                    string b = treeList1.FocusedNode.GetValue("no").ToString();
                    string Newb = string.Empty;
                    DataRow[] NOdataRows = DT2.Select($"moduleNO='{b}'", "no DESC");

                    if (NOdataRows.Count() != 0)
                    {
                        Newb = (Convert.ToInt32(NOdataRows[0]["no"]) + 1).ToString();
                        //frmModule = new FrmModuleEdit(b, ModuleValue.ToString(), 1);
                    }
                    else
                    {
                        Newb = b + "01";
                    }
                    TEModuleNO.EditValue = b;
                    TENO.Text = Newb;
                    TEitemImg.Text = "";
                    TENames.Text = "";
                    TELibraryName.Text = "";
                    TEClassName.Text = "";
                    TETagValue.Text = Newb;
                    TERemark.Text = "";
                    TESort.Text = "100";
                    CBstate.Checked = true;


                    ////ModuleNOs = treeList1.FocusedNode.GetValue("ModuleNO").ToString();
                    //DataTable DT2 = treeList1.DataSource as DataTable;
                    ////string a = treeList1.FocusedNode.GetValue("ModuleNO").ToString();
                    //string b = treeList1.FocusedNode.GetValue("no").ToString();
                    //DataRow[] dataRows = DT2.Select($"moduleNO='{b}'", "no DESC");
                    ////FrmModuleEdit frmModule;
                    //string ModuleValue = string.Empty;
                    ////gridViewManager.SetFocusedRowCellValue("CommodityID", dataRows[0]["CommodityID"]);
                    ////int ModuleSubValue = Convert.ToInt32(dataRows[0]["no"]) + 1;
                    //if (dataRows.Count() != 0)
                    //{
                    //    int ModuleSubValue = Convert.ToInt32(dataRows[0]["no"]);
                    //    DataRow[] NOdataRows = DT2.Select($"no='{ModuleSubValue.ToString()}'", "no DESC");

                    //    if (NOdataRows.Count() != 0)
                    //    {
                    //        TEModuleNO.EditValue = (Convert.ToInt32(NOdataRows[0]["no"]) + 1).ToString();
                    //        //frmModule = new FrmModuleEdit(b, ModuleValue.ToString(), 1);
                    //    }
                    //    //gridViewManager.SetFocusedRowCellValue("CommodityID", dataRows[0]["CommodityID"]);
                    //    else
                    //    {
                    //        TEModuleNO.EditValue = ModuleSubValue.ToString() + "01";
                    //        //frmModule = new FrmModuleEdit(b, ModuleValue.ToString(), 1);
                    //    }

                    //}
                    //else
                    //{
                    //    TEModuleNO.EditValue = b.ToString() + "01";
                    //    //frmModule = new FrmModuleEdit(b, ModuleValue.ToString(), 1);
                    //}
                    ////frmModule.ShowDialog();
                    //FrmModuleInfo_Load(null, null);
                }
                else
                {
                    MessageBox.Show("请选择需要添加数据的父级菜单名称！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch
            {
                MessageBox.Show("编号类型错误！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 2;
            layoutControlGroup1.Enabled = true;

            //if(treeList1.FocusedNode.GetValue("no")!=null)
            //{
            //    string b = treeList1.FocusedNode.GetValue("no").ToString();
            //    DataTable DT2 = treeList1.DataSource as DataTable;
            //    //int ModuleSubValue = Convert.ToInt32(dataRows[0]["no"]);
            //    DataRow[] NOdataRows = DT2.Select($"no='{b}'", "no DESC");
            //    FrmModuleEdit frmModule = new FrmModuleEdit(NOdataRows[0], 2);
            //    frmModule.ShowDialog();
            //    FrmModuleInfo_Load(null, null);
            //}
            //else
            //{
            //    MessageBox.Show("请选择需要编辑的菜单名称！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FileConverHelper fileConverHelper = new FileConverHelper();
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("moduleNO", TEModuleNO.EditValue);
                pairs.Add("no", TENO.Text);
                pairs.Add("itemImg", TEitemImg.Text);
                pairs.Add("names", TENames.Text);
                pairs.Add("libraryName", TELibraryName.Text);
                pairs.Add("className", TEClassName.Text);
                pairs.Add("tagValue", TETagValue.Text);
                pairs.Add("sort", TESort.Text);
                pairs.Add("remark", TERemark.Text);
                pairs.Add("state", CBstate.Checked);
                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int a = ApiHelpers.postInfo(insertInfo);
            }

            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();

                    pairs.Add("itemImg", TEitemImg.Text);
                    pairs.Add("names", TENames.Text);
                    pairs.Add("libraryName", TELibraryName.Text);
                    pairs.Add("className", TEClassName.Text);
                    pairs.Add("tagValue", TETagValue.Text);
                    pairs.Add("sort", TESort.Text);
                    pairs.Add("remark", TERemark.Text);
                    pairs.Add("state", CBstate.Checked);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                }
            }


            EditState = 0;
            //CommonDataRefresh commSystem = new CommonDataRefresh();
            CommonDataRefresh.GetPowerList();
            FrmModuleInfo_Load(null, null);
            layoutControlGroup1.Enabled = false;
        }

        private void treeList1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                DataRow dataRow = treeList1.GetFocusedDataRow();
                //if (treeList1.FocusedNode != null)
                if (dataRow != null)
                {

                    //Bitmaps = new Bitmap();
                    SelectValueID = dataRow["moduleNO"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                    TEModuleNO.EditValue = dataRow["moduleNO"] != DBNull.Value ? dataRow["moduleNO"].ToString() : "";
                    TENO.Text = dataRow["no"] != DBNull.Value ? dataRow["no"].ToString() : "";
                    TEitemImg.Text = dataRow["itemImg"] != DBNull.Value ? dataRow["itemImg"].ToString() : "";
                    TENames.Text = dataRow["names"] != DBNull.Value ? dataRow["names"].ToString() : "";
                    TELibraryName.Text = dataRow["libraryName"] != DBNull.Value ? dataRow["libraryName"].ToString() : "";
                    TEClassName.Text = dataRow["className"] != DBNull.Value ? dataRow["className"].ToString() : "";
                    TETagValue.Text = dataRow["tagValue"] != DBNull.Value ? dataRow["tagValue"].ToString() : "";
                    TESort.Text = dataRow["sort"] != DBNull.Value ? dataRow["sort"].ToString() : "";
                    TERemark.Text = dataRow["remark"] != DBNull.Value ? dataRow["remark"].ToString() : "";
                    CBstate.Checked = dataRow["state"] != DBNull.Value ? Convert.ToBoolean(dataRow["state"]) : false;

                }
            }
        }

        private void treeList1_CustomDrawNodeIndicator(object sender, DevExpress.XtraTreeList.CustomDrawNodeIndicatorEventArgs e)
        {
            DevExpress.XtraTreeList.TreeList tmpTree = sender as DevExpress.XtraTreeList.TreeList;
            DevExpress.Utils.Drawing.IndicatorObjectInfoArgs args = e.ObjectArgs as DevExpress.Utils.Drawing.IndicatorObjectInfoArgs;
            if (args != null)
            {
                int rowNum = tmpTree.GetVisibleIndexByNode(e.Node) + 1;
                args.DisplayText = rowNum.ToString();
            }
            e.ImageIndex = -1;
        }
        int ExpandState = 0;
        private void BTExpand_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ExpandState == 0)
            {
                BTExpand.Caption = "关闭节点";
                treeList1.Nodes[0].ExpandAll();
                ExpandState = 1;
            }
            else
            {
                BTExpand.Caption = "展开节点";
                treeList1.CollapseAll();
                ExpandState = 0;
            }

        }


        private void BTDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            SelectValueID = Convert.ToInt32(treeList1.FocusedNode.GetValue("id"));
            DialogResult dialogResult = MessageBox.Show("确定删除选中信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                dInfo dInfo = new dInfo();
                dInfo.TableName = tableName;
                dInfo.DataValueID = SelectValueID;
                ApiHelpers.postInfo(dInfo);
            }
        }
    }
}
