using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.WorkType
{
    public partial class FrmWorkType : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.WorkTypeInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        string TypeNO = "";
        string TypeNames = "";
        string ClassNO = "";
        string ClassNames = "";
        DataTable FrmDT;
        DataTable FrmDTGroupType;
        public FrmWorkType()
        {
            //tableName = TableNames;
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridControls.formartGridView(GVInfo);

            TextEdits.TextFormat(TEsort);
            groupInfo.Enabled = false;
        }

        private void Frminfo_Load(object sender, EventArgs e)
        {
            sInfo selectInfo = new sInfo();
            selectInfo.values = "TypeNO,TypeNames,ClassNO,ClassNames";
            selectInfo.TableName = "WorkComm.WorkTypeInfo";
            selectInfo.GroupColumns = "TypeNO,TypeNames,ClassNO,ClassNames";
            selectInfo.OrderColumns = "TypeNO";
            FrmDTGroupType = ApiHelpers.postInfo(selectInfo);

            if (FrmDTGroupType != null)
            {
                for (int a = 0; a < FrmDTGroupType.Rows.Count;)
                {
                    NavBarGroup navBarGroup = new NavBarGroup();
                    navBarGroup.Caption = FrmDTGroupType.Rows[a]["TypeNames"].ToString();
                    navBarGroup.Name = FrmDTGroupType.Rows[a]["TypeNO"].ToString();
                    if (FrmDTGroupType.Select($"TypeNO='{FrmDTGroupType.Rows[a]["TypeNO"].ToString()}'") != null)
                    {
                        foreach (DataRow dataRow in FrmDTGroupType.Select($"TypeNO='{FrmDTGroupType.Rows[a]["TypeNO"].ToString()}'").CopyToDataTable().Rows)
                        {
                            NavBarItem navBarItem = new NavBarItem();
                            navBarItem.Caption = dataRow["classNames"].ToString();
                            navBarItem.Name = dataRow["classNO"].ToString();
                            navBarItem.LinkClicked += NavBarItem_LinkClicked;
                            navBarGroup.ItemLinks.Add(navBarItem);
                            a = a + 1;

                        }
                    }
                    navBarControl1.Groups.Add(navBarGroup);
                }
            }
        }

        private void NavBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            ClassNames = e.Link.Caption;
            ClassNO = e.Link.ItemName;
            if (WorkCommData.DTWorkType.Select($"classNO='{ClassNO}' and dstate=0").Count() > 0)
            {
                FrmDT = WorkCommData.DTWorkType.Select($"classNO='{ClassNO}' and dstate=0").CopyToDataTable();
                GCInfo.DataSource = FrmDT;
                TypeNO = FrmDT.Rows[0]["TypeNO"].ToString();
                TypeNames = FrmDT.Rows[0]["TypeNames"].ToString();
                EditState = 0;
                GVInfo.BestFitColumns();
                TEno.EditValue = "";
                TEclassNames.EditValue = "";
                TEnames.EditValue = "";
                TEshortNames.EditValue = "";
                TEcustomCode.EditValue = "";
                CEtypeColor.EditValue = "";
                TERemark.EditValue = "";
                TEvalueCode.EditValue = "";
                TEsort.EditValue = "";
            }
            GVInfo.BestFitColumns();
            //MessageBox.Show(ClassNO + ClassNames);
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
            groupInfo.Enabled = true;
            EditState = 1;
            if (FrmDT.Select("no is not NULL", "no DESC").Count() == 0)
            {
                TEno.EditValue = 1;
            }
            else
            {
                TEno.EditValue = Convert.ToInt32(FrmDT.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            TEclassNames.EditValue = FrmDT.Rows[0]["classNames"];
            TEnames.EditValue = "";
            TEshortNames.EditValue = "";
            TEcustomCode.EditValue = "";
            CEtypeColor.EditValue = "";
            TERemark.EditValue = "";
            TEvalueCode.EditValue = "";
            TEsort.EditValue = 999;
            CBstate.Checked = true;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupInfo.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState != 0)
            {
                if (EditState == 1)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    pairs.Add("no", TEno.EditValue.ToString());
                    pairs.Add("TypeNO", TypeNO);
                    pairs.Add("TypeNames", TypeNames);
                    pairs.Add("classNO", ClassNO);
                    pairs.Add("classNames", ClassNames);
                    pairs.Add("names", TEnames.EditValue);
                    pairs.Add("ShortNames", TEshortNames.EditValue);
                    pairs.Add("customCode", TEcustomCode.EditValue);
                    pairs.Add("TypeColor", CEtypeColor.EditValue);
                    pairs.Add("Remark", TERemark.EditValue);
                    pairs.Add("state", CBstate.Checked);
                    pairs.Add("sort", TEsort.EditValue);
                    pairs.Add("valueCode", TEvalueCode.EditValue);
                    pairs.Add("dstate", 0);

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
                        //pairs.Add("no", TENO.EditValue.ToString());
                        pairs.Add("TypeNO", TypeNO);
                        pairs.Add("TypeNames", TypeNames);
                        pairs.Add("classNO", ClassNO);
                        pairs.Add("classNames", ClassNames);
                        pairs.Add("names", TEnames.EditValue);
                        pairs.Add("ShortNames", TEshortNames.EditValue);
                        pairs.Add("customCode", TEcustomCode.EditValue);
                        pairs.Add("TypeColor", CEtypeColor.EditValue);
                        pairs.Add("Remark", TERemark.EditValue);
                        pairs.Add("state", CBstate.Checked);
                        pairs.Add("sort", TEsort.EditValue);
                        pairs.Add("valueCode", TEvalueCode.EditValue);
                        pairs.Add("dstate", 0);
                        uInfo updateInfo = new uInfo();
                        updateInfo.TableName = tableName;
                        updateInfo.values = pairs;
                        updateInfo.DataValueID = SelectValueID;
                        int a = ApiHelpers.postInfo(updateInfo);
                    }
                }


                EditState = 0;
                //CommonDataRefresh commSystem = new CommonDataRefresh();
                CommonDataRefresh.GetWorkType();
                //Frminfo_Load(null, null);
                groupInfo.Enabled = false;
                FrmDT = WorkCommData.DTWorkType.Select($"classNO='{ClassNO}' and dstate=0").CopyToDataTable();
                GCInfo.DataSource = FrmDT;
            }
            else
            {
                MessageBox.Show("请选择需要编辑的信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }


        }
        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {

                int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                if (a > 0)
                {
                    CommonDataRefresh.GetWorkType();
                    GVInfo.DeleteSelectedRows();
                }
            

        }
        private void TENames_Leave(object sender, EventArgs e)
        {

            if (TEnames.EditValue != null)
                TEshortNames.EditValue = ConvertShortName.GetChineseSpell(TEnames.EditValue.ToString());

        }


        private void gridView1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                if (FrmDT != null)
                {
                    SelectValueID = Convert.ToInt32(GVInfo.GetFocusedRowCellValue("id"));
                    DataRow[] rows = FrmDT.Select($"id='{SelectValueID}'");
                    if (rows.Count() != 0)
                    {
                        TEno.EditValue = rows[0]["no"];
                        TEclassNames.EditValue = rows[0]["classNames"];
                        TEnames.EditValue = rows[0]["names"];
                        TEshortNames.EditValue = rows[0]["ShortNames"];
                        TEcustomCode.EditValue = rows[0]["customCode"];
                        CEtypeColor.EditValue = rows[0]["TypeColor"];
                        TEsort.EditValue = rows[0]["sort"];
                        TERemark.EditValue = rows[0]["Remark"];
                        CBstate.Checked = Convert.ToBoolean(rows[0]["state"]);
                        TEvalueCode.EditValue = rows[0]["valueCode"];
                        GVInfo.BestFitColumns();
                    }
                }
            }

        }

        private void BTAdds_Click(object sender, EventArgs e)
        {
            BTAdd_ItemClick(null, null);
        }

        private void BTEdites_Click(object sender, EventArgs e)
        {
            BTEdit_ItemClick(null, null);
        }

        private void BTSaves_Click(object sender, EventArgs e)
        {
            BTSave_ItemClick(null, null);
        }

        private void BTDeletes_Click(object sender, EventArgs e)
        {
            BTDelect_ItemClick(null, null);
        }
    }
}
