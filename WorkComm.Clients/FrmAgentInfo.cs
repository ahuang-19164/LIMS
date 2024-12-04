using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.Clients
{
    public partial class FrmAgentInfo : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.ClientAgent";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;
        DataTable DTPowerListAll;
        public FrmAgentInfo()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(RGEChargeLevelNO);
            GridLookUpEdites.Formats(RGEPersonNO);
            GridLookUpEdites.Formats(GEPersonNO);
            GridLookUpEdites.Formats(RGEpersonsNO);
            TextEdits.TextFormat(TESort);
            GridControls.formartGridView(GVAgentInfo);



        }

        private void Frminfo_Load(object sender, EventArgs e)
        {
            DTPowerListAll = CommonData.DTWebPowerListAll;
            layoutControl1.Enabled = false;
            TENO.Enabled = false;
            //GLECompanyNO.Properties.DataSource = repositoryItemLookUpEdit1.DataSource = CommonData.DTCommonyInfoAll;
            //GLECompanyNO.Properties.ValueMember = repositoryItemLookUpEdit1.ValueMember = "no";
            //GLECompanyNO.Properties.DisplayMember = repositoryItemLookUpEdit1.DisplayMember = "names";
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = tableName;
            selectInfo.OrderColumns = "sort";
            GCAgentInfo.DataSource = FrmDT = ApiHelpers.postInfo(selectInfo);

            GEPersonNO.Properties.DataSource = CommonData.DTUserInfoAll;
            RGEpersonsNO.DataSource = RGEPersonNO.DataSource = CommonData.DTUserInfoAll;
            RGEChargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            GVAgentInfo.BestFitColumns();
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

        #region barmassage方法
        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            layoutControl1.Enabled = true;
            EditState = 1;

            TENO.EditValue = "";
            TESort.EditValue = "";
            DESignTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEExpireTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            CEwebstate.Checked = false;
            CEState.Checked = false;
            TENames.EditValue = "";
            TEShortNames.EditValue = "";
            TEDisNames.EditValue = "";
            TEContacts.EditValue = "";
            TEContactsPhone.EditValue = "";
            TEInvoiceCode.EditValue = "";
            TEInvoicePhone.EditValue = "";
            TEInvoiceAddress.EditValue = "";
            TERemark.EditValue = "";
            TEAddress.EditValue = "";
            TEEmail.EditValue = "";
            TEWechat.EditValue = "";
            GEPersonNO.EditValue = "";
            TEPassWord.EditValue = "";
            TEInvoiceNames.EditValue = "";









            //TEAddress.EditValue = "";
            //TEContacts.EditValue = "";
            //TEContactsPhone.EditValue = "";
            //TEEmail.EditValue = "";
            //TEInvoiceAddress.EditValue = "";
            //TEInvoiceCode.EditValue = "";
            //TEInvoiceNames.EditValue = "";
            //TEInvoicePhone.EditValue = "";
            //TENames.EditValue = "";
            //TENamesEn.EditValue = "";
            //TENO.EditValue = "";
            //TEPassWord.EditValue = "";
            //TERemark.EditValue = "";
            //TEShortNames.EditValue = "";
            //TESort.EditValue = "";
            //TEWechat.EditValue = "";
            //GEPerson.EditValue = "";
            //CBState.Checked = false;
            //CBwebstate.Checked = false;
            //DEExpireTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            //DESignTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");


        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControl1.Enabled = true;
            TENO.Enabled = false;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string powerList = "";
            if (SelectValueID != 0)
            {

                uInfo updateInfo = new uInfo();
                updateInfo.TableName = tableName;

                powerList = "0," + getPowerList();
                //TEText.EditValue = powerList;
                updateInfo.value = $"powerList='{powerList.Substring(0, powerList.Length - 1)}'";
                updateInfo.DataValueID = SelectValueID;
                int i = ApiHelpers.postInfo(updateInfo);
                //CommonDataRefresh commSystem = new CommonDataRefresh();
                CommonDataRefresh.GetRoleInfo();
            }


            if (EditState == 1)
            {
                if(TENO.EditValue!=null&&TENO.EditValue.ToString().Trim().Length>=4)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    pairs.Add("sort", TESort.EditValue);
                    pairs.Add("signTime", DESignTime.EditValue);
                    pairs.Add("expireTime", DEExpireTime.EditValue);
                    pairs.Add("webstate", CEwebstate.EditValue);
                    pairs.Add("state", CEState.EditValue);
                    pairs.Add("dstate", 0);
                    pairs.Add("no", TENO.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);
                    pairs.Add("disNames", TEDisNames.EditValue);
                    pairs.Add("contacts", TEContacts.EditValue);
                    pairs.Add("contactsPhone", TEContactsPhone.EditValue);
                    pairs.Add("invoiceCode", TEInvoiceCode.EditValue);
                    pairs.Add("invoicePhone", TEInvoicePhone.EditValue);
                    pairs.Add("invoiceAddress", TEInvoiceAddress.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("address", TEAddress.EditValue);
                    pairs.Add("email", TEEmail.EditValue);
                    pairs.Add("wechat", TEWechat.EditValue);
                    pairs.Add("personNO", GEPersonNO.EditValue);
                    pairs.Add("passWord", TEPassWord.EditValue);
                    pairs.Add("invoiceNames", TEInvoiceNames.EditValue);
                    pairs.Add("powerList", powerList);
                    iInfo insertInfo = new iInfo();
                    insertInfo.TableName = tableName;
                    insertInfo.values = pairs;
                    int a = ApiHelpers.postInfo(insertInfo);
                    TENO.Enabled = false;
                }
                else
                {
                    MessageBox.Show("代理商编号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();

                    pairs.Add("sort", TESort.EditValue);
                    pairs.Add("signTime", DESignTime.EditValue);
                    pairs.Add("expireTime", DEExpireTime.EditValue);
                    pairs.Add("webstate", CEwebstate.EditValue);
                    pairs.Add("state", CEState.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);
                    pairs.Add("disNames", TEDisNames.EditValue);
                    pairs.Add("contacts", TEContacts.EditValue);
                    pairs.Add("contactsPhone", TEContactsPhone.EditValue);
                    pairs.Add("invoiceCode", TEInvoiceCode.EditValue);
                    pairs.Add("invoicePhone", TEInvoicePhone.EditValue);
                    pairs.Add("invoiceAddress", TEInvoiceAddress.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("address", TEAddress.EditValue);
                    pairs.Add("email", TEEmail.EditValue);
                    pairs.Add("wechat", TEWechat.EditValue);
                    pairs.Add("personNO", GEPersonNO.EditValue);
                    pairs.Add("passWord", TEPassWord.EditValue);
                    pairs.Add("invoiceNames", TEInvoiceNames.EditValue);
                    pairs.Add("powerList", powerList);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                    TENO.Enabled = false;
                }
            }


            EditState = 0;
            CommonDataRefresh.GetClientAgent();
            Frminfo_Load(null, null);
            layoutControl1.Enabled = false;

        }


        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {

                    if (SelectValueID != 0)
                    {
                        int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                        if (a > 0)
                        {
                            CommonDataRefresh.GetCommpanyInfo();
                            GVAgentInfo.DeleteSelectedRows();
                        }
                    }
                
            }
            else
            {
                MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion




        #region gridcontrol 方法
        private void gridView1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                if (FrmDT != null)
                {
                    SelectValueID = Convert.ToInt32(GVAgentInfo.GetFocusedRowCellValue("id"));
                    DataRow[] rows = FrmDT.Select($"id='{SelectValueID}'");
                    if (rows.Count() != 0)
                    {
                        TESort.EditValue = rows[0]["sort"];
                        DESignTime.EditValue = rows[0]["signTime"];
                        DEExpireTime.EditValue = rows[0]["ExpireTime"];
                        CEwebstate.EditValue = Convert.ToBoolean(rows[0]["webstate"]);
                        CEState.EditValue = Convert.ToBoolean(rows[0]["state"]);
                        TENO.EditValue = rows[0]["no"];
                        TENames.EditValue = rows[0]["names"];
                        TEShortNames.EditValue = rows[0]["shortNames"];
                        TEDisNames.EditValue = rows[0]["disNames"];
                        TEContacts.EditValue = rows[0]["contacts"];
                        TEContactsPhone.EditValue = rows[0]["contactsPhone"];
                        TEInvoiceCode.EditValue = rows[0]["invoiceCode"];
                        TEInvoicePhone.EditValue = rows[0]["invoicePhone"];
                        TEInvoiceAddress.EditValue = rows[0]["invoiceAddress"];
                        TERemark.EditValue = rows[0]["remark"];
                        TEAddress.EditValue = rows[0]["address"];
                        TEEmail.EditValue = rows[0]["email"];
                        TEWechat.EditValue = rows[0]["wechat"];
                        GEPersonNO.EditValue = rows[0]["personNO"];
                        TEPassWord.EditValue = rows[0]["passWord"];
                        TEInvoiceNames.EditValue = rows[0]["invoiceNames"];

                        string PowerList = rows[0]["powerList"] != DBNull.Value ? rows[0]["powerList"].ToString() : "";
                        foreach (Control control in PCPowerView.Controls)
                        {
                            if (control is TreeList)
                            {
                                TreeList treeList = (TreeList)control;

                                SetChecked(PowerList.Split(','), treeList);

                            }
                        }


                        if (WorkCommData.DTClientInfo.Select($"agentNO='{rows[0]["no"]}'").Count() > 0)
                        {
                            GCClientnfo.DataSource = WorkCommData.DTClientInfo.Select($"agentNO='{rows[0]["no"]}'").CopyToDataTable();
                            GVClientInfo.BestFitColumns();

                        }
                        else
                        {
                            GCClientnfo.DataSource = null;
                        }
                    }
                }

            }

        }

        #endregion

        private void TENames_Leave(object sender, EventArgs e)
        {
            if (TENames.EditValue != null)
            {
                TEShortNames.EditValue = ConvertShortName.GetChineseSpell(TENames.EditValue.ToString());
            }

        }

        private void BTAgentClient_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void TENO_Leave(object sender, EventArgs e)
        {
            string a = TENO.EditValue != null ? TENO.EditValue.ToString().ToUpper() : "";
            if (WorkCommData.DTClientAgent.Select($"no='{a}'").Count() > 0)
            {
                MessageBox.Show("客户编号重复", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TENO.EditValue = "";
            }
            else
            {
                TENO.EditValue = a;
            }
        }

        #region 权限功能

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


        /// <summary>
        /// 获取选中的节点
        /// </summary>
        /// <param name="tree"></param>
        private void SetChecked(string[] PowerList, TreeList tree)
        {
            foreach (TreeListNode DRowView in tree.Nodes)
            {
                DataRowView drv = tree.GetDataRecordByNode(DRowView) as DataRowView;
                if (PowerList.Contains((string)drv["tagValue"]))
                {
                    DRowView.Checked = true;

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
                if (PowerList.Contains((string)drv2["tagValue"]))
                {
                    node.Checked = true;
                }
                else
                {
                    node.Checked = false;
                }
                SetCheckedKeyID(PowerList, node, tree);
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

        #endregion
    }
}
