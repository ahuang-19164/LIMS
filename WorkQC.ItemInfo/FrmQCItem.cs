using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmQCItem : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "QC.QCItem";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmQCItem()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }


            GridLookUpEdites.Formats(GEbatchNO);
            GridLookUpEdites.Formats(GEgradeNO);
            GridLookUpEdites.Formats(GEgroupNO);
            GridLookUpEdites.Formats(GEitemNO);
            GridLookUpEdites.Formats(GElevelNO);
            GridLookUpEdites.Formats(GEplanNO);
            GridLookUpEdites.Formats(GEqcgroupNO);
            GridLookUpEdites.Formats(GEworkNO);

            GridLookUpEdites.Formats(RGEbatchNO);
            GridLookUpEdites.Formats(RGEgradeNO);
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEitemNO);
            GridLookUpEdites.Formats(RGElevelNO);
            GridLookUpEdites.Formats(RGEplanNO);
            GridLookUpEdites.Formats(RGEqcgroupNO);
            GridLookUpEdites.Formats(RGEworkNO);



            GEbatchNO.Properties.DataSource = DTHelper.DTEnable(QCInfoData.DTQCBatch);
            GEgradeNO.Properties.DataSource = DTHelper.DTEnable(QCInfoData.DTQCGrade);


            GElevelNO.Properties.DataSource = DTHelper.DTEnable(QCInfoData.DTQCLevel);
            GEplanNO.Properties.DataSource = DTHelper.DTEnable(QCInfoData.DTQCPlan);
            GEqcgroupNO.Properties.DataSource = DTHelper.DTEnable(QCInfoData.DTRuleGroup);




            GEworkNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupWork);
            //GEgroupNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest);
            //GEitemNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTItemTest);

            RGEbatchNO.DataSource = QCInfoData.DTQCBatch;
            RGEgradeNO.DataSource = QCInfoData.DTQCGrade;

            RGElevelNO.DataSource = QCInfoData.DTQCLevel;
            RGEplanNO.DataSource = QCInfoData.DTQCPlan;
            RGEqcgroupNO.DataSource = QCInfoData.DTRuleGroup;

            RGEitemNO.DataSource = WorkCommData.DTItemTest;
            RGEworkNO.DataSource = WorkCommData.DTGroupWork;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;


            TextEdits.TextFormat(TEsort);
            TextEdits.TextFormatDecimal(TEavgValue);
            TextEdits.TextFormatDecimal(TEcvValue);
            TextEdits.TextFormatDecimal(TEsdValue);
            GridControls.formartGridView(GVItem);
            GridControls.showEmbeddedNavigator(GCItem);

            groupControl1.Enabled = false;
            TEno.ReadOnly = true;


        }

        private void Frminfo_Load(object sender, EventArgs e)
        {

            GElevelNO.Properties.DataSource = QCInfoData.DTQCLevel;
            RGElevelNO.DataSource = QCInfoData.DTQCLevel;


            sInfo sInfo = new sInfo();
            sInfo.TableName = tableName;
            string sr = JsonHelper.SerializeObjct(sInfo);
            FrmDT = ApiHelpers.postInfo(sInfo);


            GCItem.DataSource = DTHelper.DTVisible(FrmDT);
            //GVInfos.ExpandAllGroups();
            GVItem.BestFitColumns();

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

            groupControl1.Enabled = true;
            EditState = 1;

            if (FrmDT == null)
            {
                TEno.EditValue = 1;
            }
            else
            {
                TEno.EditValue = Convert.ToInt32(FrmDT.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }

            CEstate.Checked = false;
            TEavgValue.EditValue = "";
            TEcvValue.EditValue = "";
            TEsdValue.EditValue = "";
            TEsort.EditValue = "";
            GEbatchNO.EditValue = null;
            GEgradeNO.EditValue = null;
            GEgroupNO.EditValue = null;
            GEitemNO.EditValue = null;
            GElevelNO.EditValue = null;
            GEplanNO.EditValue = null;
            GEqcgroupNO.EditValue = null;
            GEworkNO.EditValue = null;
            TEremark.EditValue = "";



        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupControl1.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("dstate", 0);
                pairs.Add("state", CEstate.EditValue);
                pairs.Add("avgValue", TEavgValue.EditValue);
                pairs.Add("cvValue", TEcvValue.EditValue);
                pairs.Add("sdValue", TEsdValue.EditValue);
                pairs.Add("no", TEno.EditValue);
                pairs.Add("sort", TEsort.EditValue);
                pairs.Add("batchNO", GEbatchNO.EditValue);
                pairs.Add("gradeNO", GEgradeNO.EditValue);
                pairs.Add("groupNO", GEgroupNO.EditValue);
                pairs.Add("itemNO", GEitemNO.EditValue);
                pairs.Add("levelNO", GElevelNO.EditValue);
                pairs.Add("planNO", GEplanNO.EditValue);
                pairs.Add("qcgroupNO", GEqcgroupNO.EditValue);
                pairs.Add("remark", TEremark.EditValue);
                pairs.Add("workNO", GEworkNO.EditValue);

                pairs.Add("creater", CommonData.UserInfo.names);
                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

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
                    pairs.Add("dstate", 0);
                    pairs.Add("state", CEstate.EditValue);
                    pairs.Add("avgValue", TEavgValue.EditValue);
                    pairs.Add("cvValue", TEcvValue.EditValue);
                    pairs.Add("sdValue", TEsdValue.EditValue);
                    //pairs.Add("no", TEno.EditValue);
                    pairs.Add("sort", TEsort.EditValue);
                    pairs.Add("batchNO", GEbatchNO.EditValue);
                    pairs.Add("gradeNO", GEgradeNO.EditValue);
                    pairs.Add("groupNO", GEgroupNO.EditValue);
                    pairs.Add("itemNO", GEitemNO.EditValue);
                    pairs.Add("levelNO", GElevelNO.EditValue);
                    pairs.Add("planNO", GEplanNO.EditValue);
                    pairs.Add("qcgroupNO", GEqcgroupNO.EditValue);
                    pairs.Add("remark", TEremark.EditValue);
                    pairs.Add("workNO", GEworkNO.EditValue);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                }
            }


            EditState = 0;

            Frminfo_Load(null, null);
            groupControl1.Enabled = false;

        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                DialogResult dialogResult = MessageBox.Show("是否确定删除该信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    hideInfo hideInfo = new hideInfo();
                    hideInfo.TableName = tableName;
                    hideInfo.DataValueID = SelectValueID;
                    ApiHelpers.postInfo(hideInfo);

                    GVItem.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion




        #region gridcontrol 方法

        private void GVInfos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {
                if (GVItem.GetFocusedDataRow() != null)
                {
                    SelectValueID = Convert.ToInt32(GVItem.GetFocusedRowCellValue("id"));

                    DataRow rows = GVItem.GetFocusedDataRow();



                    TEavgValue.EditValue = rows["avgValue"];
                    TEcvValue.EditValue = rows["cvValue"];
                    TEsdValue.EditValue = rows["sdValue"];
                    TEno.EditValue = rows["no"];
                    TEsort.EditValue = rows["sort"];
                    GEbatchNO.EditValue = rows["batchNO"];
                    GEgradeNO.EditValue = rows["gradeNO"];
                    GEgroupNO.EditValue = rows["groupNO"];
                    GEitemNO.EditValue = rows["itemNO"];
                    GElevelNO.EditValue = rows["levelNO"];
                    GEplanNO.EditValue = rows["planNO"];
                    GEqcgroupNO.EditValue = rows["qcgroupNO"];
                    TEremark.EditValue = rows["remark"];
                    GEworkNO.EditValue = rows["workNO"];


                    CEstate.EditValue = rows["state"] != DBNull.Value ? Convert.ToBoolean(rows["state"]) : false;
                }
            }
        }




        #endregion

        private void GEworkNO_EditValueChanged(object sender, EventArgs e)
        {
            if (GEworkNO.EditValue != null)
            {
                if (DTHelper.DTEnable(WorkCommData.DTGroupTest).Select($"workNO={GEworkNO.EditValue}").Count() > 0)
                    GEgroupNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTGroupTest).Select($"workNO={GEworkNO.EditValue}").CopyToDataTable();
                //GEitemNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTItemTest);
            }

        }

        private void GEgroupNO_EditValueChanged(object sender, EventArgs e)
        {
            if (GEgroupNO.EditValue != null)
            {
                if (DTHelper.DTEnable(WorkCommData.DTItemTest).Select($"groupNO='{GEgroupNO.EditValue}'").Count() > 0)
                    GEitemNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTItemTest).Select($"groupNO='{GEgroupNO.EditValue}'").CopyToDataTable();
            }
        }
    }
}
