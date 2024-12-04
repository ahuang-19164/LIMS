using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.Groups
{
    public partial class FrmWorkGroup : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.GroupWork";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmWorkGroup()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }

            GridControls.formartGridView(GVInfo);




            GridLookUpEdites.Formats(RGEcompanyNO);
            GridLookUpEdites.Formats(GEcompanyNO);
            GridLookUpEdites.Formats(GEworkPreson);
            RGEcompanyNO.DataSource = CommonData.DTCommonyInfoAll;
            GEcompanyNO.Properties.DataSource = DTHelper.DTEnable(CommonData.DTCommonyInfoAll);
            GEworkPreson.Properties.DataSource = DTHelper.DTEnable(CommonData.DTUserInfoAll);
        }

        private void FrmCompanyinfo_Load(object sender, EventArgs e)
        {
            groupInfo.Enabled = false;
            FrmDT = WorkCommData.DTGroupWork;
            GCInfo.DataSource = DTHelper.DTVisible(FrmDT);
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

        #region barmassage方法
        private void BTAddCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
            TEnames.EditValue = "";
            GEworkPreson.EditValue = "";
            GEcompanyNO.EditValue = "";
            TEremark.EditValue = "";
            TEsort.EditValue = "";
            CEstate.Checked = false;
        }

        private void BTEditCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupInfo.Enabled = true;
            EditState = 2;
        }

        private void BTSaveCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TEno.EditValue);
                pairs.Add("names", TEnames.EditValue);
                pairs.Add("workPreson", GEworkPreson.EditValue);
                pairs.Add("companyNO", GEcompanyNO.EditValue);
                pairs.Add("remark", TEremark.EditValue);
                pairs.Add("state", CEstate.Checked);
                pairs.Add("sort", TEsort.EditValue);

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
                    pairs.Add("no", TEno.EditValue);
                    pairs.Add("names", TEnames.EditValue);
                    pairs.Add("workPreson", GEworkPreson.EditValue);
                    pairs.Add("companyNO", GEcompanyNO.EditValue);
                    pairs.Add("remark", TEremark.EditValue);
                    pairs.Add("state", CEstate.Checked);
                    pairs.Add("sort", TEsort.EditValue);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                }
            }


            EditState = 0;
            CommonDataRefresh.GetGroupWork();
            FrmCompanyinfo_Load(null, null);
            groupInfo.Enabled = false;

        }
        #endregion




        #region gridcontrol 方法
        private void gridView1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                SelectValueID = Convert.ToInt32(GVInfo.GetFocusedRowCellValue("id"));
                DataRow[] rows = FrmDT.Select($"id='{SelectValueID}'");
                if (rows.Count() != 0)
                {
                    TEno.EditValue = rows[0]["no"];
                    TEnames.EditValue = rows[0]["names"];
                    GEcompanyNO.EditValue = rows[0]["companyNO"];
                    GEworkPreson.EditValue = rows[0]["workPreson"];
                    TEremark.EditValue = rows[0]["remark"];
                    TEsort.EditValue = rows[0]["sort"];
                    CEstate.Checked = Convert.ToBoolean(rows[0]["state"]);
                }
            }

        }

        #endregion

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (GVInfo.GetFocusedRowCellValue("id") != DBNull.Value)
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
            else
            {
                GVInfo.DeleteSelectedRows();
            }

            
        }
    }
}
