using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace HLFramework
{
    public partial class FrmDepartmentInfo : DevExpress.XtraEditors.XtraForm
    {
        
        string tableName = "Common.DepartmentInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
#pragma warning disable CS0169 // 从不使用字段“FrmDepartmentInfo.modelTable”
        DataTable modelTable;
#pragma warning restore CS0169 // 从不使用字段“FrmDepartmentInfo.modelTable”


        public FrmDepartmentInfo()
        {
            InitializeComponent();
            GridControls.formartGridView(GVInfo);

            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(GECompanyNo);
            GridLookUpEdites.Formats(GESuper);
            GridLookUpEdites.Formats(GEDirector);
            GridLookUpEdites.Formats(GEAssistant);
            GridLookUpEdites.Formats(GESeniorRole);
            GridLookUpEdites.Formats(GEChargeSuperior);
            LookUpEdits.Formats(repositoryItemLookUpEdit1);
            LookUpEdits.Formats(repositoryItemLookUpEdit2);
            TextEdits.TextFormat(TESort);
        }

        private void FrmDepartmentInfo_Load(object sender, EventArgs e)
        {
            GCInfo.DataSource =DTHelper.DTVisible(CommonData.DTDepertmentInfoAll);
            GroupInfo.Enabled = false;
            repositoryItemLookUpEdit1.DataSource = DTHelper.DTEnable(CommonData.DTCommonyInfoAll);

            GECompanyNo.Properties.DataSource = DTHelper.DTEnable(CommonData.DTCommonyInfoAll);
            repositoryItemLookUpEdit2.DataSource = DTHelper.DTEnable(CommonData.DTDepertmentInfoAll);
            GESuper.Properties.DataSource = DTHelper.DTEnable(CommonData.DTDepertmentInfoAll);
            GEChargeSuperior.Properties.DataSource = GESeniorRole.Properties.DataSource = GEAssistant.Properties.DataSource = GEDirector.Properties.DataSource =DTHelper.DTEnable(CommonData.DTUserInfoAll);
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
            //FRMStart_Activated();
            EditState = 1;
            GroupInfo.Enabled = true;
            if (CommonData.DTDepertmentInfoAll != null)
            {
                if (CommonData.DTDepertmentInfoAll.Select("no is not NULL", "no DESC").Count() == 0)
                {
                    TENO.EditValue = 1;
                }
                else
                {
                    TENO.EditValue = Convert.ToInt32(CommonData.DTDepertmentInfoAll.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
                }
            }
            else
            {
                TENO.EditValue = 1;
            }


            //TENO.EditValue = string.Format("{0:000}", Convert.ToInt32(CommSystemInfo.DTDepartmentInfoAll.Select("no is not NULL", "no DESC")[0]["no"]) + 1);
            TEName.EditValue = "";
            TEShortNames.EditValue = "";
            TECustomCode.EditValue = "";
            GECompanyNo.EditValue = "";
            GESuper.EditValue = "";
            GEDirector.EditValue = "";
            GEAssistant.EditValue = "";
            GESeniorRole.EditValue = "";
            GEChargeSuperior.EditValue = "";
            TEPhone.EditValue = "";
            TEFax.EditValue = "";
            TEAddress.EditValue = "";
            TEFunctions.EditValue = "";
            TERemark.EditValue = "";
            TESort.EditValue = 999;
            CBState.Checked = false;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 2;
            GroupInfo.Enabled = true;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                SelectValueID = Convert.ToInt32(GVInfo.GetFocusedRowCellValue("id"));
                DataRow[] rows = CommonData.DTDepertmentInfoAll.Select($"id='{SelectValueID}'");
                if (rows.Count() != 0)
                {
                    TENO.EditValue = rows[0]["no"];
                    TEName.EditValue = rows[0]["names"];
                    TEShortNames.EditValue = rows[0]["shortNames"];
                    TECustomCode.EditValue = rows[0]["customCode"];
                    GECompanyNo.EditValue = rows[0]["companyNo"];
                    GESuper.EditValue = rows[0]["super"];
                    GEDirector.EditValue = rows[0]["director"];
                    GEAssistant.EditValue = rows[0]["assistant"];
                    GESeniorRole.EditValue = rows[0]["seniorRole"];
                    GEChargeSuperior.EditValue = rows[0]["chargeSuperior"];
                    TEPhone.EditValue = rows[0]["phone"];
                    TEFax.EditValue = rows[0]["fax"];
                    TEAddress.EditValue = rows[0]["address"];
                    TEFunctions.EditValue = rows[0]["functions"];
                    TERemark.EditValue = rows[0]["remark"];
                    TESort.EditValue = rows[0]["sort"];
                    CBState.Checked = rows[0]["state"] != DBNull.Value ? Convert.ToBoolean(Convert.ToBoolean(rows[0]["state"])) : false;
                }

            }
        }

        private void BTSaveCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENO.EditValue);
                pairs.Add("names", TEName.EditValue);
                pairs.Add("shortNames", TEShortNames.EditValue);
                pairs.Add("customCode", TECustomCode.EditValue);
                pairs.Add("companyNo", GECompanyNo.EditValue);
                pairs.Add("super", GESuper.EditValue);
                pairs.Add("director", GEDirector.EditValue);
                pairs.Add("assistant", GEAssistant.EditValue);
                pairs.Add("seniorRole", GESeniorRole.EditValue);
                pairs.Add("chargeSuperior", GEChargeSuperior.EditValue);
                pairs.Add("phone", TEPhone.EditValue);
                pairs.Add("fax", TEFax.EditValue);
                pairs.Add("address", TEAddress.EditValue);
                pairs.Add("functions", TEFunctions.EditValue);
                pairs.Add("remark", TERemark.EditValue);
                pairs.Add("sort", TESort.EditValue);
                pairs.Add("state", CBState.Checked);
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
                    //pairs.Add("no", TENO.EditValue);
                    pairs.Add("names", TEName.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);
                    pairs.Add("customCode", TECustomCode.EditValue);
                    pairs.Add("companyNo", GECompanyNo.EditValue);
                    pairs.Add("super", GESuper.EditValue);
                    pairs.Add("director", GEDirector.EditValue);
                    pairs.Add("assistant", GEAssistant.EditValue);
                    pairs.Add("seniorRole", GESeniorRole.EditValue);
                    pairs.Add("chargeSuperior", GEChargeSuperior.EditValue);
                    pairs.Add("phone", TEPhone.EditValue);
                    pairs.Add("fax", TEFax.EditValue);
                    pairs.Add("address", TEAddress.EditValue);
                    pairs.Add("functions", TEFunctions.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("sort", TESort.EditValue);
                    pairs.Add("state", CBState.Checked);
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
            CommonDataRefresh.GetDepartmentInfo();
            FrmDepartmentInfo_Load(null, null);
            GroupInfo.Enabled = false;
        }
        //#region hotKeys
        //private void FRMStart_Activated()
        //{
        //    ////注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
        //    HotKeys.RegisterHotKey(Handle, 100, HotKeys.KeyModifiers.Shift, Keys.S);
        //    HotKeys.RegisterHotKey(Handle, 100, 0, Keys.F1);
        //    //注册热键Ctrl+B，Id号为101。HotKey.KeyModifiers.Ctrl也可以直接使用数字2来表示。
        //    HotKeys.RegisterHotKey(Handle, 101, 0, Keys.Delete);
        //    ////注册热键Alt+D，Id号为102。HotKey.KeyModifiers.Alt也可以直接使用数字1来表示。
        //    HotKeys.RegisterHotKey(Handle, 102, (uint)HotKeys.KeyModifiers.Ctrl, Keys.S);

        //    HotKeys.RegisterHotKey(Handle, 103, (uint)HotKeys.KeyModifiers.Ctrl, Keys.Q);
        //    ////注册热键Shift+S，Id号为100。HotKey.KeyModifiers.Shift也可以直接使用数字4来表示。
        //    HotKeys.RegisterHotKeys(Handle, 103, HotKeys.KeyModifiers.Shift, Keys.S);
        //}

        //protected override void WndProc(ref Message m)
        //{
        //    const int WM_HOTKEY = 0x0312;
        //    //按快捷键 
        //    switch (m.Msg)
        //    {
        //        case WM_HOTKEY:
        //            switch (m.WParam.ToInt32())
        //            {
        //                case 100:  //按下的是F1
        //                    MessageBox.Show("按的是F1");     //此处填写快捷键响应代码     
        //                    break;
        //                case 101:  //按下的是delete
        //                    MessageBox.Show("按下的是delete");         //此处填写快捷键响应代码
        //                    break;
        //                case 102:  //按下的是Ctrl+s
        //                    MessageBox.Show("按下的是Ctrl+s");         //此处填写快捷键响应代码
        //                    break;
        //                    //case 103:  //按下的是Ctrl+q
        //                    //    BTNextPage_ItemClick(null, null);          //此处填写快捷键响应代码
        //                    //    break;
        //            }
        //            break;
        //    }
        //    base.WndProc(ref m);
        //}



        //#endregion hotKeys

        private void TEName_Leave(object sender, EventArgs e)
        {
            TEShortNames.EditValue = Common.ConvertShort.ConvertShortName.GetChineseSpell(TEName.EditValue.ToString());
        }

        private void BTDelectCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                if (a > 0)
                {
                    CommonDataRefresh.GetDepartmentInfo();
                    GVInfo.DeleteSelectedRows();
                }
            }
        }
    }
}
