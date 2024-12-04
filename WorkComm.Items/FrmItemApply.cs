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

namespace WorkComm.Items
{
    public partial class FrmItemApply : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.ItemApply";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmItemApply()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }

            GridLookUpEdites.Formats(GEclientNO);
            GridLookUpEdites.Formats(GEcompanyNO);
            GridLookUpEdites.Formats(RGEclientNO);

            GridLookUpEdites.Formats(RGEGcontainerTypeNO);
            GridLookUpEdites.Formats(RGEGsampleTypeNO);
            GridLookUpEdites.Formats(RGEGworkNO);
            GridLookUpEdites.Formats(RGEclientNO);


            GridControls.formartGridView(GVApplyInfo);

            GridControls.showEmbeddedNavigator(GCApplyInfo);

            GridControls.formartGridView(GVGroupInfo);

            GridControls.showEmbeddedNavigator(GCGroupInfo);

            TextEdits.TextFormat(TEsort);
        }

        private void FrmCompanyinfo_Load(object sender, EventArgs e)
        {

            groupInfo.Enabled = false;
            RGEGcontainerTypeNO.DataSource = WorkCommData.DTTypeContainer;
            RGEGsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEGworkNO.DataSource = WorkCommData.DTGroupWork;






            RGEclientNO.DataSource = WorkCommData.DTClientInfo;

            GEclientNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);

            GEcompanyNO.Properties.DataSource = DTHelper.DTEnable(CommonData.DTCommonyInfoAll);

            GCApplyInfo.DataSource = DTHelper.DTVisible(WorkCommData.DTItemApply);

            FrmDT = WorkCommData.DTItemGroup.Clone();
            GCGroupInfo.DataSource = FrmDT;

            GVApplyInfo.ExpandAllGroups();
            GVApplyInfo.BestFitColumns();

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
            if (WorkCommData.DTItemApply == null)
            {
                TEno.EditValue = 1;
            }
            else
            {
                TEno.EditValue = Convert.ToInt32(WorkCommData.DTItemApply.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }

            CEstate.Checked = true;
            CEWxState.Checked = true;

            //TEno.EditValue = "";
            TEsort.EditValue = 999;
            GEclientNO.EditValue = "";
            GEcompanyNO.EditValue = "";
            TEcustomCode.EditValue = "";
            TEdisNames.EditValue = "";
            TEnames.EditValue = "";
            TEremark.EditValue = "";
            TEshortNames.EditValue = "";



            itemList = "";
            FrmDT.Rows.Clear();

        }

        private void BTEditCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupInfo.Enabled = true;
            EditState = 2;
        }

        private void BTSaveCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TEno.EditValue != null && TEnames.EditValue != null)
            {


                if (TEno.EditValue.ToString() != "" && TEnames.EditValue.ToString() != "")
                {
                    if (EditState == 1)
                    {
                        Dictionary<string, object> pairs = new Dictionary<string, object>();
                        pairs.Add("state", CEstate.EditValue);
                        pairs.Add("wxstate", CEWxState.EditValue);
                        pairs.Add("no", TEno.EditValue);
                        pairs.Add("sort", TEsort.EditValue);
                        pairs.Add("clientNO", GEclientNO.EditValue);
                        pairs.Add("companyNO", GEcompanyNO.EditValue);
                        pairs.Add("customCode", TEcustomCode.EditValue);
                        pairs.Add("disNames", TEdisNames.EditValue);
                        pairs.Add("names", TEnames.EditValue);
                        pairs.Add("remark", TEremark.EditValue);
                        pairs.Add("shortNames", TEshortNames.EditValue);
                        pairs.Add("groupItemList", GetitemList());
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
                            pairs.Add("wxstate", CEWxState.EditValue);
                            //pairs.Add("no", TEno.EditValue);
                            pairs.Add("sort", TEsort.EditValue);
                            pairs.Add("clientNO", GEclientNO.EditValue);
                            pairs.Add("companyNO", GEcompanyNO.EditValue);
                            pairs.Add("customCode", TEcustomCode.EditValue);
                            pairs.Add("disNames", TEdisNames.EditValue);
                            pairs.Add("names", TEnames.EditValue);
                            pairs.Add("remark", TEremark.EditValue);
                            pairs.Add("shortNames", TEshortNames.EditValue);
                            pairs.Add("groupItemList", GetitemList());
                            uInfo updateInfo = new uInfo();
                            updateInfo.TableName = tableName;
                            updateInfo.values = pairs;
                            updateInfo.DataValueID = SelectValueID;
                            int a = ApiHelpers.postInfo(updateInfo);
                        }
                    }


                    EditState = 0;
                    CommonDataRefresh.GetItemApply();
                    //FrmCompanyinfo_Load(null, null);
                    GCApplyInfo.DataSource = WorkCommData.DTItemApply;
                    groupInfo.Enabled = false;
                }
                else
                {
                    MessageBox.Show("必填项信息不能为空", "系统提示");
                }
            }

        }
        #endregion




        #region gridcontrol 方法
        private void gridView1_Click(object sender, EventArgs e)
        {
            FrmDT.Rows.Clear();
            if (EditState != 1)
            {
                if (WorkCommData.DTItemApply != null)
                {
                    SelectValueID = Convert.ToInt32(GVApplyInfo.GetFocusedRowCellValue("id"));
                    DataRow[] rows = WorkCommData.DTItemApply.Select($"id='{SelectValueID}'");
                    if (rows.Count() != 0)
                    {
                        CEstate.Checked = Convert.ToBoolean(rows[0]["state"]);
                        CEWxState.Checked = Convert.ToBoolean(rows[0]["wxstate"]);
                        TEno.EditValue = rows[0]["no"];
                        TEsort.EditValue = rows[0]["sort"];
                        GEclientNO.EditValue = rows[0]["clientNO"];
                        GEcompanyNO.EditValue = rows[0]["companyNO"];
                        TEcustomCode.EditValue = rows[0]["customCode"];
                        TEdisNames.EditValue = rows[0]["disNames"];
                        TEnames.EditValue = rows[0]["names"];
                        TEremark.EditValue = rows[0]["remark"];
                        TEshortNames.EditValue = rows[0]["shortNames"];
                        itemList = rows[0]["groupItemList"] != DBNull.Value ? rows[0]["groupItemList"].ToString() : "";
                    }
                }
            }
            GetitemInfo(itemList);
        }
        #endregion

        private void TENames_Leave(object sender, EventArgs e)
        {
            if (TEnames.EditValue != null)
            {
                TEshortNames.EditValue = ConvertShortName.GetChineseSpell(TEnames.EditValue.ToString());
            }

        }


        string itemList = "";
        Func<DataRow> Func;
        private void BTAddGroup_Click(object sender, EventArgs e)
        {
            FrmShowGroup frmShowGroup = new FrmShowGroup(GetitemList());
            Func = frmShowGroup.ReturnResult;
            frmShowGroup.ShowDialog();
            if (Func() != null)
            {
                DataRow dataRow = FrmDT.NewRow();
                dataRow.ItemArray = Func().ItemArray;
                FrmDT.Rows.Add(dataRow);
                GVGroupInfo.BestFitColumns();
            }
        }

        private void BTRemoveGroup_Click(object sender, EventArgs e)
        {
            GVGroupInfo.DeleteSelectedRows();
        }

        private void BTUp_Click(object sender, EventArgs e)
        {
            int ii = GVGroupInfo.FocusedRowHandle;
            if (ii != 0)
            {
                DataRow newdata = FrmDT.NewRow();
                newdata.ItemArray = FrmDT.Rows[ii].ItemArray;
                FrmDT.Rows.RemoveAt(ii);
                FrmDT.Rows.InsertAt(newdata, ii - 1);
                FrmDT.AcceptChanges();
                GVGroupInfo.FocusedRowHandle = ii - 1;

                //GVItemInfo.FocusedRowHandle = GVItemInfo.FocusedRowHandle - 2;
            }
        }

        private void BTDown_Click(object sender, EventArgs e)
        {
            int ii = GVGroupInfo.FocusedRowHandle;
            if (ii < GVGroupInfo.RowCount - 1)
            {
                DataRow newdata = FrmDT.NewRow();
                newdata.ItemArray = FrmDT.Rows[ii].ItemArray;
                FrmDT.Rows.RemoveAt(ii);
                FrmDT.Rows.InsertAt(newdata, ii + 1);
                FrmDT.AcceptChanges();
                GVGroupInfo.FocusedRowHandle = ii + 1;
            }
        }
        /// <summary>
        /// 获取子项集合信息。（包含优先级）
        /// </summary>
        /// <returns></returns>
        public string GetitemList()
        {
            itemList = "";
            for (int i = 0; i < GVGroupInfo.RowCount; i++)
            {
                itemList += GVGroupInfo.GetRowCellValue(i, "no") + ",";
            }
            return itemList;
        }

        /// <summary>
        /// 读取项目子项信息
        /// </summary>
        /// <param name="itemlists"></param>
        public void GetitemInfo(string itemlists)
        {
            FrmDT.Rows.Clear();
            if (itemlists != "")
            {
                string[] itemNOs = itemlists.Split(',');
                for (int i = 0; i < itemNOs.Count(); i++)
                {
                    if (!Convert.IsDBNull(itemNOs[i]))
                    {
                        if (itemNOs[i] != "")
                        {
                            DataRow dataRow = FrmDT.NewRow();
                            dataRow.ItemArray = WorkCommData.DTItemGroup.Select($"no='{itemNOs[i]}'")[0].ItemArray;
                            FrmDT.Rows.InsertAt(dataRow, i);
                            GVGroupInfo.BestFitColumns();

                        }
                    }
                }
            }
        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (GVApplyInfo.GetFocusedDataRow() != null)
            {
                int ids = Convert.ToInt32(GVApplyInfo.GetFocusedRowCellValue("id"));

                        if (ids != 0)
                        {
                            int a = DeleteHelper.hideinfo(ids, tableName);
                            if (a > 0)
                            {
                                CommonDataRefresh.GetItemApply();
                                GVApplyInfo.DeleteSelectedRows();
                            }
                        }
                    
                
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的项目", "系统提示");
            }
        }
    }
}
