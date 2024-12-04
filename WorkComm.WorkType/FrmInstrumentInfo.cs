using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.WorkType
{
    public partial class FrmInstrumentInfo : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.InstrumentInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;
        public FrmInstrumentInfo()
        {
            //tableName = TableNames;
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            TextEdits.TextFormat(TESort);
            GridLookUpEdites.Formats(GEgroupNO);
            GridLookUpEdites.Formats(RGEgroupNO, WorkCommData.DTGroupTest);
            GridControls.formartGridView(GVInfos);
            GridControls.showEmbeddedNavigator(GCInfos);

        }

        private void Frminfo_Load(object sender, EventArgs e)
        {

            GEgroupNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest);
            //RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkComm.InstrumentInfo";
            sInfo.wheres = " dstate=0";
            GCInfos.DataSource = FrmDT = ApiHelpers.postInfo(sInfo);

            GVInfos.BestFitColumns();
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
            GInfo.Enabled = true;
            EditState = 1;
            if (FrmDT.Select("no is not NULL", "no DESC").Count() == 0)
            {
                TENO.EditValue = 1;
            }
            else
            {
                TENO.EditValue = Convert.ToInt32(FrmDT.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            TENames.EditValue = "";
            TEShortNames.EditValue = "";
            TECustomCode.EditValue = "";
            GEgroupNO.EditValue = null;
            TERemark.EditValue = "";
            TESort.EditValue = 999;
            CBState.Checked = false;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GInfo.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENO.EditValue);
                pairs.Add("groupNO", GEgroupNO.EditValue);
                pairs.Add("names", TENames.EditValue);
                pairs.Add("shortNames", TEShortNames.EditValue);
                pairs.Add("customCode", TECustomCode.EditValue);
                pairs.Add("remark", TERemark.EditValue);
                pairs.Add("state", CBState.Checked);
                pairs.Add("sort", TESort.EditValue);
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
                    pairs.Add("no", TENO.EditValue);
                    pairs.Add("groupNO", GEgroupNO.EditValue);
                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);
                    pairs.Add("customCode", TECustomCode.EditValue);
                    pairs.Add("remark", TERemark.EditValue);
                    pairs.Add("state", CBState.Checked);
                    pairs.Add("sort", TESort.EditValue);
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
            Frminfo_Load(null, null);
            GInfo.Enabled = false;

        }
        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {

                int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                if (a > 0)
                {
                    CommonDataRefresh.GetInstrumentInfo();
                    GVInfos.DeleteSelectedRows();
                }
            

        }
        private void TENames_Leave(object sender, EventArgs e)
        {

            if (TENames.EditValue != null)
                TEShortNames.EditValue = ConvertShortName.GetChineseSpell(TENames.EditValue.ToString());

        }
        private void GVInfos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {

                SelectValueID = Convert.ToInt32(GVInfos.GetFocusedRowCellValue("id"));
                DataRow[] rows = FrmDT.Select($"id='{SelectValueID}'");
                if (rows.Count() != 0)
                {
                    TENO.EditValue = rows[0]["no"];
                    TECustomCode.EditValue = rows[0]["customCode"];
                    TENames.EditValue = rows[0]["names"];
                    TEShortNames.EditValue = rows[0]["shortNames"];
                    GEgroupNO.EditValue = rows[0]["groupNO"];
                    TESort.EditValue = rows[0]["sort"];
                    TERemark.EditValue = rows[0]["remark"];
                    CBState.Checked = Convert.ToBoolean(rows[0]["state"]);
                }
            }
        }

        private void GCInfos_Click(object sender, EventArgs e)
        {

        }
    }
}
