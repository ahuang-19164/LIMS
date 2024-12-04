using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmWebPowerInfo : DevExpress.XtraEditors.XtraForm
    {
        
        string tableName = "Common.RoleInfoWeb";
#pragma warning disable CS0414 // 字段“FrmWebPowerInfo.EditState”已被赋值，但从未使用过它的值
        int EditState = 0;//1.新增 2.编辑
#pragma warning restore CS0414 // 字段“FrmWebPowerInfo.EditState”已被赋值，但从未使用过它的值
        int SelectValueID = 0;//选择数据ID
        DataTable DTPowerListAll;
        public FrmWebPowerInfo()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            LookUpEdits.Formats(LEdepartmentNO);
            LookUpEdits.Formats(LEcompanyNO);
            GridControls.formartGridView(GVInfo);


        }
        private void FrmPowerInfo_Load(object sender, EventArgs e)
        {

            //DTPowerListAll = CommonData.DTPowerListAll;
            DTPowerListAll = CommonData.DTWebPowerListAll;
            GCInfo.DataSource = CommonData.DTWebRoleInfoAll;
            LEdepartmentNO.DataSource = CommonData.DTDepertmentInfoAll;
            LEcompanyNO.DataSource = CommonData.DTCommonyInfoAll;
            FrmShowPowerView();
            GVInfo.ExpandAllGroups();//展开所有分组
            GVInfo.BestFitColumns();//自适应宽度


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
        public void FrmShowPowerView()
        {
            if (DTPowerListAll != null)
            {
                DataRow[] DRModuleRows = DTPowerListAll.Select("moduleNO=0 and state=1", "no ASC");
                //DataRow[] DRNoRows = DTPowerListAll.Select($"moduleNO=0");
                //DataRow[] DRCBRows = DTPowerListAll.Select("moduleNO=0", "no ASC");

                for (int ModuleRows = DRModuleRows.Count() - 1; ModuleRows > 0; ModuleRows--)
                {
                    int TreeListPoint = 1;

                    TreeListColumn Names = new TreeListColumn(); ;
                    Names.Caption = DRModuleRows[ModuleRows]["names"].ToString();
                    Names.FieldName = "names";
                    Names.Visible = true;
                    Names.Name = DRModuleRows[ModuleRows]["moduleNO"].ToString();
                    Names.OptionsColumn.AllowFocus = false;

                    TreeList treeList = new TreeList();
                    treeList.Dock = System.Windows.Forms.DockStyle.Left;
                    treeList.Location = new System.Drawing.Point(TreeListPoint, 1);
                    treeList.Name = DRModuleRows[ModuleRows]["names"].ToString();
                    treeList.Size = new System.Drawing.Size(200, 550);
                    treeList.TabIndex = ModuleRows;
                    treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                    treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] { Names });
                    treeList.OptionsView.ShowCheckBoxes = true;
                    treeList.OptionsView.ShowIndicator = false;
                    string a = DRModuleRows[ModuleRows]["no"].ToString();
                    DataRow[] DRNoRows = DTPowerListAll.Select($"no like '{DRModuleRows[ModuleRows]["no"]}%' and state=1", "no ASC");
                    treeList.DataSource = DRNoRows.CopyToDataTable();
                    treeList.KeyFieldName = "no";
                    treeList.ParentFieldName = "moduleNO";
                    treeList.AfterCheckNode += treeXZQ_AfterCheckNode;

                    PCPowerView.AutoScroll = true;
                    PCPowerView.Controls.Add(treeList);
                    TreeListPoint += 200;
                    treeList.ExpandAll();
                }
            }

        }
        private void treeXZQ_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }
        /// <summary>
        /// 更新父节点Check状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedParentNodes(TreeListNode node, CheckState check)
        {
            //if (node.ParentNode != null)
            //{
            //    bool b = false;
            //    CheckState state;
            //    for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
            //    {
            //        state = (CheckState)node.ParentNode.Nodes[i].CheckState;
            //        if (!check.Equals(state))
            //        {
            //            b = !b;
            //            break;
            //        }
            //    }
            //    node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
            //    SetCheckedParentNodes(node.ParentNode, check);
            //}
        }
        /// <summary>
        /// 更新子节点Check状态
        /// </summary>
        /// <param name="node"></param>
        /// <param name="check"></param>
        private void SetCheckedChildNodes(TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        private void BTSaveCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {

                uInfo updateInfo = new uInfo();
                updateInfo.TableName = tableName;

                string powerList = "0," + getPowerList();
                TEText.EditValue = powerList;
                updateInfo.value = $"powerList='{powerList.Substring(0, powerList.Length - 1)}'";
                updateInfo.DataValueID = SelectValueID;
                int i = ApiHelpers.postInfo(updateInfo);
                //CommonDataRefresh commSystem = new CommonDataRefresh();
                CommonDataRefresh.GetRoleInfo();
            }
        }




        private List<string> lstCheckedKeyID = new List<string>();//选择KeyID集合

        public string getPowerList()
        {
            string PowerList = "";
            foreach (Control control in PCPowerView.Controls)
            {
                if (control is TreeList)
                {
                    TreeList treeList = (TreeList)control;
                    findOrigin(treeList);
                    if (lstCheckedKeyID.Count != 0)
                    {
                        for (int i = 0; i < lstCheckedKeyID.Count; i++)
                        {
                            PowerList += lstCheckedKeyID[i].ToString() + ",";
                        }
                    }

                }
            }
            return PowerList;
        }


        /// <summary>
        /// 获取选中的节点
        /// </summary>
        /// <param name="tree"></param>
        private void findOrigin(TreeList tree)
        {
            this.lstCheckedKeyID.Clear();

            if (tree.Nodes.Count > 0)
            {
                foreach (TreeListNode root in tree.Nodes)
                {
                    if (root.CheckState == CheckState.Checked)
                    {
                        DataRowView drv = tree.GetDataRecordByNode(root) as DataRowView;
                        string KeyFieldName = (string)drv["tagValue"];
                        lstCheckedKeyID.Add(KeyFieldName);
                        GetCheckedKeyID(root, tree);
                    }
                }
            }
        }
        /// <summary>
        /// 获取选择状态的数据主键ID集合
        /// </summary>
        /// <param name="parentNode">父级节点</param>
        private void GetCheckedKeyID(TreeListNode parentNode, TreeList tree)
        {
            if (parentNode.Nodes.Count == 0)
            {
                return;//递归终止
            }

            foreach (TreeListNode node in parentNode.Nodes)
            {
                if (node.CheckState == CheckState.Checked)
                {
                    DataRowView drv = tree.GetDataRecordByNode(node) as DataRowView;//关键代码，就是不知道是这样获取数据而纠结了很久(鬼知道可以转换为DataRowView啊)
                    if (drv != null)
                    {
                        string KeyFieldName = (string)drv["tagValue"];
                        lstCheckedKeyID.Add(KeyFieldName);
                    }
                }
                GetCheckedKeyID(node, tree);
            }
        }


        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (GVInfo.GetFocusedRowCellValue("id") != null)
            {

                SelectValueID = Convert.ToInt32(GVInfo.GetFocusedRowCellValue("id"));
                DataRow[] rows = CommonData.DTWebRoleInfoAll.Select($"id='{SelectValueID}'");
                if (rows.Count() != 0)
                {
                    string PowerList = rows[0]["powerList"] != DBNull.Value ? rows[0]["powerList"].ToString() : "";
                    if (PowerList != "")
                    {
                        foreach (Control control in PCPowerView.Controls)
                        {
                            if (control is TreeList)
                            {
                                TreeList treeList = (TreeList)control;

                                SetChecked(PowerList.Split(','), treeList);

                            }
                        }
                    }
                    else
                    {
                        foreach (Control control in PCPowerView.Controls)
                        {
                            if (control is TreeList)
                            {
                                TreeList treeList = (TreeList)control;

                                SetChecked(null, treeList);

                            }
                        }

                    }

                }
                else
                {
                    foreach (Control control in PCPowerView.Controls)
                    {
                        if (control is TreeList)
                        {
                            TreeList treeList = (TreeList)control;

                            SetChecked(null, treeList);

                        }
                    }

                }
            }
        }


        #region 权限列表选择

        /// <summary>
        /// 获取选中的节点
        /// </summary>
        /// <param name="tree"></param>
        private void SetChecked(string[] PowerList, TreeList tree)
        {
            foreach (TreeListNode DRowView in tree.Nodes)
            {
                DataRowView drv = tree.GetDataRecordByNode(DRowView) as DataRowView;
                if (PowerList != null)
                {
                    string a = drv["tagValue"] != DBNull.Value ? drv["tagValue"].ToString() : "";
                    if (a != "" && PowerList.Contains(a))
                    {
                        DRowView.Checked = true;
                    }
                    else
                    {
                        DRowView.Checked = false;
                    }
                }
                else
                {
                    DRowView.Checked = false;
                }

                SetCheckedKeyID(PowerList, DRowView, tree);
            }

        }
        /// <summary>
        /// 获取选择状态的数据主键ID集合
        /// </summary>
        /// <param name="parentNode">父级节点</param>
        private void SetCheckedKeyID(string[] PowerList, TreeListNode parentNode, TreeList tree)
        {
            if (parentNode.Nodes.Count == 0)
            {
                return;//递归终止
            }

            foreach (TreeListNode node in parentNode.Nodes)
            {
                DataRowView drv2 = tree.GetDataRecordByNode(node) as DataRowView;

                if (PowerList != null)
                {
                    string a = drv2["tagValue"] != DBNull.Value ? drv2["tagValue"].ToString() : "";
                    if (a != "" && PowerList.Contains(a))
                    {
                        node.Checked = true;
                    }
                    else
                    {
                        node.Checked = false;
                    }
                }
                else
                {
                    node.Checked = false;
                }
                SetCheckedKeyID(PowerList, node, tree);
            }
        }
        #endregion 权限列表选择

        private void BTEdit_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
