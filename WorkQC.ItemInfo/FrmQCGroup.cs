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

namespace WorkQC.ItemInfo
{
    public partial class FrmQCGroup : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "QC.RuleGroup";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmQCGroup()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            //GridLookUpEdites.Formats(GEclassNO);
            //GridLookUpEdites.Formats(GEcriteriaNO);
            //GridLookUpEdites.Formats(GEerrorNO);
            //GridLookUpEdites.Formats(GErangeNO);
            GridLookUpEdites.Formats(RGEclassNO);
            GridLookUpEdites.Formats(RGEcriteriaNO);
            GridLookUpEdites.Formats(RGEerrorNO);
            GridLookUpEdites.Formats(RGErangeNO);







            GridControls.formartGridView(GVRule);
            GridControls.showEmbeddedNavigator(GCRule);

            groupControl1.Enabled = false;
            TEno.ReadOnly = true;


        }

        private void Frminfo_Load(object sender, EventArgs e)
        {
            sInfo QCRuleGroupInfo = new sInfo();
            QCRuleGroupInfo.TableName = tableName;
            FrmDT = ApiHelpers.postInfo(QCRuleGroupInfo);
            GCRuleGroup.DataSource = DTHelper.DTVisible(FrmDT);


            sInfo QCRuleInfo = new sInfo();
            QCRuleInfo.TableName = "QC.RuleQC";
            DataTable DTRuleQC = ApiHelpers.postInfo(QCRuleInfo);
            DTRuleQC.Columns.Add("check", typeof(bool));
            GCRule.DataSource = DTHelper.DTVisible(DTRuleQC);



            RGEerrorNO.DataSource = QCInfoData.DTEerrorType;
            RGErangeNO.DataSource = QCInfoData.DTRangType;
            RGEcriteriaNO.DataSource = QCInfoData.DTCriteriaType;


            //GErangeNO.Properties.DataSource = null;
            //GEclassNO.Properties.DataSource = null;
            //GEcriteriaNO.Properties.DataSource = null;
            //GEerrorNO.Properties.DataSource = null;
            //GVInfos.ExpandAllGroups();
            GVRule.BestFitColumns();

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

            TEnames.EditValue = "";
            TEshortNames.EditValue = "";
            TEcustomCode.EditValue = "";
            TEremark.EditValue = "";
            TEsort.EditValue = 999;
            CEstate.Checked = false;
            for (int a = 0; a < GVRule.RowCount; a++)
            {
                GVRule.SetRowCellValue(a, "check", false);
            }
            CEstate.Checked = false;


        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupControl1.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string listQC = "";
            for (int a = 0; a < GVRule.RowCount; a++)
            {
                if (GVRule.GetRowCellValue(a, "check") != DBNull.Value && Convert.ToBoolean(GVRule.GetRowCellValue(a, "check")))
                {
                    listQC += GVRule.GetRowCellValue(a, "no") != DBNull.Value ? GVRule.GetRowCellValue(a, "no").ToString() + "," : "";
                }
            }
            if (listQC.Length > 0)
            {
                listQC = listQC.Substring(0, listQC.Length - 1);
            }

            if (EditState == 1)
            {

                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("dstate", 0);
                pairs.Add("state", CEstate.EditValue);
                pairs.Add("no", TEno.EditValue);
                pairs.Add("sort", TEsort.EditValue);
                pairs.Add("customCode", TEcustomCode.EditValue);
                pairs.Add("listQC", listQC);
                pairs.Add("names", TEnames.EditValue);
                pairs.Add("remark", TEremark.EditValue);
                pairs.Add("shortNames", TEshortNames.EditValue);
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
                    //pairs.Add("no", TEno.EditValue);
                    pairs.Add("sort", TEsort.EditValue);
                    pairs.Add("customCode", TEcustomCode.EditValue);
                    pairs.Add("listQC", listQC);
                    pairs.Add("names", TEnames.EditValue);
                    pairs.Add("remark", TEremark.EditValue);
                    pairs.Add("shortNames", TEshortNames.EditValue);
                    //pairs.Add("creater", CommonData.UserInfo.names);
                    //pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
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
            EditState = 0;
        }
        #endregion




        #region gridcontrol 方法

        private void GVInfos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {
                if (GVRuleGroup.GetFocusedDataRow() != null)
                {
                    SelectValueID = Convert.ToInt32(GVRuleGroup.GetFocusedRowCellValue("id"));

                    DataRow rows = GVRuleGroup.GetFocusedDataRow();

                    TEno.EditValue = rows["no"];
                    TEsort.EditValue = rows["sort"];
                    TEcustomCode.EditValue = rows["customCode"];
                    TEnames.EditValue = rows["names"];
                    TEremark.EditValue = rows["remark"];
                    TEshortNames.EditValue = rows["shortNames"];

                    if (rows["listQC"] != DBNull.Value)
                    {
                        string[] lQC = rows["listQC"].ToString().Split(',');

                        for (int a = 0; a < GVRule.RowCount; a++)
                        {
                            if (GVRule.GetRowCellValue(a, "no") != DBNull.Value)
                            {
                                if (lQC.Contains(GVRule.GetRowCellValue(a, "no").ToString()))
                                {
                                    GVRule.SetRowCellValue(a, "check", true);
                                }
                                else
                                {
                                    GVRule.SetRowCellValue(a, "check", false);

                                }
                            }
                            else
                            {
                                GVRule.SetRowCellValue(a, "check", false);

                            }

                        }
                    }





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

        private void GVRule_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 0)
            {
                if (GVRule.GetFocusedRowCellValue("check") != DBNull.Value)
                {
                    if (Convert.ToBoolean(GVRule.GetFocusedRowCellValue("check")))
                    {
                        GVRule.SetFocusedRowCellValue("check", false);
                    }
                    else
                    {
                        GVRule.SetFocusedRowCellValue("check", true);
                    }
                }
            }
        }
    }
}
