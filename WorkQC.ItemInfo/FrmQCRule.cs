using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
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
    public partial class FrmQCRule : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "QC.RuleQC";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmQCRule()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(GEclassNO);
            GridLookUpEdites.Formats(GEcriteriaNO);
            GridLookUpEdites.Formats(GEerrorNO);
            GridLookUpEdites.Formats(GErangeNO);
            GridLookUpEdites.Formats(RGEclassNO);
            GridLookUpEdites.Formats(RGEcriteriaNO);
            GridLookUpEdites.Formats(RGEerrorNO);
            GridLookUpEdites.Formats(RGErangeNO);
            TextEdits.TextFormatDecimal(TEnValue);
            TextEdits.TextFormatDecimal(TEmValue);
            TextEdits.TextFormatDecimal(TExValue);
            TextEdits.TextFormatDecimal(TEyValue);
            TextEdits.TextFormat(TEsort);
            GridControls.formartGridView(GVRule);
            GridControls.showEmbeddedNavigator(GCRule);

            groupControl1.Enabled = false;



        }

        private void Frminfo_Load(object sender, EventArgs e)
        {

            sInfo sInfo = new sInfo();
            sInfo.TableName = tableName;
            string sr = JsonHelper.SerializeObjct(sInfo);
            FrmDT = ApiHelpers.postInfo(sInfo);

            RGEclassNO.DataSource = QCInfoData.DTRuleClass;
            GEclassNO.Properties.DataSource = QCInfoData.DTRuleClass;




            GEcriteriaNO.Properties.DataSource = QCInfoData.DTCriteriaType;

            GEerrorNO.Properties.DataSource = QCInfoData.DTEerrorType;

            GErangeNO.Properties.DataSource = QCInfoData.DTRangType;
            RGEerrorNO.DataSource = QCInfoData.DTEerrorType;
            RGErangeNO.DataSource = QCInfoData.DTRangType;
            RGEcriteriaNO.DataSource = QCInfoData.DTCriteriaType;

            GCRule.DataSource = DTHelper.DTVisible(FrmDT);

            TEno.ReadOnly = true;
            //GVInfos.ExpandAllGroups();
            GVRule.BestFitColumns();

        }
#pragma warning disable CS0414 // 字段“FrmQCRule.RuleGroup”已被赋值，但从未使用过它的值
        DataTable RuleGroup = null;
#pragma warning restore CS0414 // 字段“FrmQCRule.RuleGroup”已被赋值，但从未使用过它的值
#pragma warning disable CS0414 // 字段“FrmQCRule.RuleQC”已被赋值，但从未使用过它的值
        DataTable RuleQC = null;
#pragma warning restore CS0414 // 字段“FrmQCRule.RuleQC”已被赋值，但从未使用过它的值
        //DataTable RuleQC = null;


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
            TEmValue.EditValue = "";
            TEnValue.EditValue = "";
            TExValue.EditValue = "";
            TEyValue.EditValue = "";
            GEclassNO.EditValue = "";
            GEcriteriaNO.EditValue = "";
            TEcustomCode.EditValue = "";
            GEerrorNO.EditValue = "";
            TEexplain.EditValue = "";
            TEnames.EditValue = "";
            GErangeNO.EditValue = "";
            TEremark.EditValue = "";
            TEshortNames.EditValue = "";
            TEsort.EditValue = 999;






            CEstate.Checked = false;


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



                pairs.Add("state", CEstate.EditValue);
                pairs.Add("mValue", TEmValue.EditValue);
                pairs.Add("nValue", TEnValue.EditValue);
                pairs.Add("xValue", TExValue.EditValue);
                pairs.Add("yValue", TEyValue.EditValue);
                pairs.Add("classNO", GEclassNO.EditValue);
                pairs.Add("criteriaNO", GEcriteriaNO.EditValue);
                pairs.Add("customCode", TEcustomCode.EditValue);
                pairs.Add("errorNO", GEerrorNO.EditValue);
                pairs.Add("explain", TEexplain.EditValue);
                pairs.Add("names", TEnames.EditValue);
                pairs.Add("no", TEno.EditValue);
                pairs.Add("rangeNO", GErangeNO.EditValue);
                pairs.Add("remark", TEremark.EditValue);
                pairs.Add("shortNames", TEshortNames.EditValue);
                pairs.Add("sort", TEsort.EditValue);
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

                    pairs.Add("state", CEstate.EditValue);
                    pairs.Add("mValue", TEmValue.EditValue);
                    pairs.Add("nValue", TEnValue.EditValue);
                    pairs.Add("xValue", TExValue.EditValue);
                    pairs.Add("yValue", TEyValue.EditValue);
                    pairs.Add("classNO", GEclassNO.EditValue);
                    pairs.Add("criteriaNO", GEcriteriaNO.EditValue);
                    pairs.Add("customCode", TEcustomCode.EditValue);
                    pairs.Add("errorNO", GEerrorNO.EditValue);
                    pairs.Add("explain", TEexplain.EditValue);
                    pairs.Add("names", TEnames.EditValue);
                    pairs.Add("no", TEno.EditValue);
                    pairs.Add("rangeNO", GErangeNO.EditValue);
                    pairs.Add("remark", TEremark.EditValue);
                    pairs.Add("shortNames", TEshortNames.EditValue);
                    pairs.Add("sort", TEsort.EditValue);


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

                    GVRule.DeleteSelectedRows();
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
                if (GVRule.GetFocusedDataRow() != null)
                {
                    SelectValueID = Convert.ToInt32(GVRule.GetFocusedRowCellValue("id"));

                    DataRow rows = GVRule.GetFocusedDataRow();

                    TEmValue.EditValue = rows["mValue"];
                    TEnValue.EditValue = rows["nValue"];
                    TExValue.EditValue = rows["xValue"];
                    TEyValue.EditValue = rows["yValue"];
                    GEclassNO.EditValue = rows["classNO"];
                    GEcriteriaNO.EditValue = rows["criteriaNO"];
                    TEcustomCode.EditValue = rows["customCode"];
                    GEerrorNO.EditValue = rows["errorNO"];
                    TEexplain.EditValue = rows["explain"];
                    TEnames.EditValue = rows["names"];
                    TEno.EditValue = rows["no"];
                    GErangeNO.EditValue = rows["rangeNO"];
                    TEremark.EditValue = rows["remark"];
                    TEshortNames.EditValue = rows["shortNames"];
                    TEsort.EditValue = rows["sort"];

                    CEstate.EditValue = rows["state"] != DBNull.Value ? Convert.ToBoolean(rows["state"]) : false;
                }
            }
        }

        #endregion

        private void TENames_Leave(object sender, EventArgs e)
        {
            if (TEnames.EditValue != null)
            {
                TEshortNames.EditValue = ConvertShortName.GetChineseSpell(TEnames.EditValue.ToString());
            }

        }


    }
}
