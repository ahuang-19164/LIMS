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

namespace workOther.MicrobeInfo
{
    public partial class FrmMicrobeSmear : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.MicrobeSmear";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;
        public FrmMicrobeSmear()
        {
            //tableName = TableNames;
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GInfo.Enabled = false;
            TextEdits.TextFormat(TESort);
            GridLookUpEdites.Formats(GEgroupCode);
            GridLookUpEdites.Formats(RGEgroupCode);
            GridControls.formartGridView(GVInfos);
            GridControls.showEmbeddedNavigator(GCInfos);

        }

        private void Frminfo_Load(object sender, EventArgs e)
        {

            //RGEgroupCode.DataSource = GEgroupCode.Properties.DataSource = WorkCommData.DTItemGroup.Select($"workNO='6' and dstate=0").CopyToDataTable();
            //RGEgroupCode.DataSource = WorkCommData.DTItemGroup;
            sInfo sInfo = new sInfo();
            sInfo.TableName = tableName;
            sInfo.wheres = "dstate=0";

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
            GEgroupCode.EditValue = 0;
            TEsmearValue.EditValue = "";
            TEremark.EditValue = "";
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
            GVInfos.FocusedRowHandle = -1;
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("no", TENO.EditValue);

                pairs.Add("names", TENames.EditValue);
                pairs.Add("shortNames", TEShortNames.EditValue);
                pairs.Add("customCode", TECustomCode.EditValue);
                pairs.Add("groupCode", GEgroupCode.EditValue);
                pairs.Add("value", TEsmearValue.EditValue);
                pairs.Add("remark", TEremark.EditValue);
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

                    pairs.Add("names", TENames.EditValue);
                    pairs.Add("shortNames", TEShortNames.EditValue);
                    pairs.Add("customCode", TECustomCode.EditValue);
                    pairs.Add("groupCode", GEgroupCode.EditValue);
                    pairs.Add("value", TEsmearValue.EditValue);
                    pairs.Add("remark", TEremark.EditValue);
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
            DialogResult result = MessageBox.Show("是否确定删除该信息！", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (GVInfos.GetFocusedRowCellValue("id") != null)
                {
                    SelectValueID = Convert.ToInt32(GVInfos.GetFocusedRowCellValue("id"));
                    hideInfo hideInfo = new hideInfo();
                    hideInfo.TableName = tableName;
                    hideInfo.DataValueID = SelectValueID;
                    ApiHelpers.postInfo(hideInfo);
                    GVInfos.DeleteRow(GVInfos.FocusedRowHandle);
                }
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

                DataRow dataRow = GVInfos.GetFocusedDataRow();
                if (dataRow != null)
                {
                    SelectValueID = Convert.ToInt32(dataRow["id"]);
                    TENO.EditValue = dataRow["no"];
                    TECustomCode.EditValue = dataRow["customCode"];
                    TENames.EditValue = dataRow["names"];
                    TEShortNames.EditValue = dataRow["shortNames"];
                    GEgroupCode.EditValue = dataRow["groupCode"];
                    TESort.EditValue = dataRow["sort"];
                    TEsmearValue.EditValue = dataRow["value"];
                    TEremark.EditValue = dataRow["remark"];
                    CBState.Checked = Convert.ToBoolean(dataRow["state"]);
                }
            }
        }
    }
}
