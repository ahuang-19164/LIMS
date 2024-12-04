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

namespace workOther.SampleStores
{
    public partial class FrmStores : XtraForm
    {

        string tableName = "dbo.sw_stores";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT = null;


        public FrmStores()
        {
            InitializeComponent();
        }
        private void FrmStores_Load(object sender, EventArgs e)
        {
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(GEsampleType);
            GridLookUpEdites.Formats(RGEsampleType);
            //TextEdits.TextFormatDecimal(TEDiscount);
            //TextEdits.TextFormatDecimal(RTEDiscount);
            TextEdits.TextFormat(TEDay);
            TextEdits.TextFormat(TESort);
            TextEdits.TextFormat(TECell);
            TextEdits.TextFormat(TERow);
            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);


            GEsampleType.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);
            RGEsampleType.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);

            TENO.Enabled = false;
            layoutControl1.Enabled = false;

            sInfo selectInfo = new sInfo();
            selectInfo.TableName = tableName;
            selectInfo.OrderColumns = "sort";
            FrmDT = ApiHelpers.postInfo(selectInfo);
            GCInfo.DataSource = DTHelper.DTVisible(FrmDT);



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


        private void BTAdd_ItemClick(object sender, ItemClickEventArgs e)
        {

            layoutControl1.Enabled = true;
            //TENO.Enabled = true;
            EditState = 1;


            TENO.EditValue = FrmDT!=null? FrmDT.Rows.Count+1:1;
            TENames.EditValue = "";
            TEShortNames.EditValue = "";
            TECustomCode.EditValue = "";
            TEDay.EditValue = "";
            TECell.EditValue = "";
            TERow.EditValue = "";
            GEsampleType.EditValue = "";
            TESort.EditValue = "";
            TEAdd.EditValue = "";
            TERemark.EditValue = "";
            CEState.Checked = true;
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControl1.Enabled = true;
            TENO.Enabled = false;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Dictionary<string, object> pairs = new Dictionary<string, object>();
            
            pairs.Add("names", TENames.EditValue);
            pairs.Add("shortNames", TEShortNames.EditValue);
            pairs.Add("customCode", TECustomCode.EditValue);
            pairs.Add("saveDay", TEDay.EditValue);
            pairs.Add("storesCell", TECell.EditValue);
            pairs.Add("storesRow", TERow.EditValue);
            pairs.Add("sampleTypeNO", GEsampleType.EditValue);
            pairs.Add("sort", TESort.EditValue);
            pairs.Add("address", TEAdd.EditValue);
            pairs.Add("remark", TERemark.EditValue);
            pairs.Add("state", CEState.Checked);


            if (EditState == 1)
            {
                if (TENO.EditValue != null)
                {
                    pairs.Add("no", TENO.EditValue);
                    pairs.Add("storesTypeNO", 1);
                    pairs.Add("createTime", DateTime.Now);
                    pairs.Add("dstate", false);
                    iInfo insertInfo = new iInfo();
                    insertInfo.TableName = tableName;
                    insertInfo.values = pairs;
                    int a = ApiHelpers.postInfo(insertInfo);
                    TENO.Enabled = false;
                }
                else
                {
                    MessageBox.Show("编号不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                    TENO.Enabled = false;
                }
            }


            EditState = 0;
            //CommonDataRefresh.GetClientAgent();
            FrmStores_Load(null, null);
            layoutControl1.Enabled = false;
        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {

                if (SelectValueID != 0)
                {

                    hideInfo hideInfo = new hideInfo();
                    hideInfo.DataValueID = SelectValueID;
                    hideInfo.TableName = tableName;
                    //int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                    int a = ApiHelpers.postInfo(hideInfo);
                    if (a > 0)
                    {
                        //CommonDataRefresh.GetCommpanyInfo();
                        GVInfo.DeleteSelectedRows();
                    }
                }

            }
            else
            {
                MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TENames_Leave(object sender, EventArgs e)
        {
            if (TENames.EditValue != null)
            {
                TEShortNames.EditValue = ConvertShortName.GetChineseSpell(TENames.EditValue.ToString());
            }
        }

        private void GVInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {
                DataRow rows = GVInfo.GetFocusedDataRow();
                //DataRow[] rows = FrmDT.Select($"id='{SelectValueID}'");
                if (rows != null)
                {
                    SelectValueID = rows["id"] != null ? Convert.ToInt32(rows["id"]) : 0;
                    TENO.EditValue = rows["no"];
                    TENames.EditValue = rows["names"];
                    TEShortNames.EditValue = rows["shortNames"];
                    TECustomCode.EditValue = rows["customCode"];
                    TEDay.EditValue = rows["saveDay"];
                    TECell.EditValue = rows["storesCell"];
                    TERow.EditValue = rows["storesRow"];
                    GEsampleType.EditValue = rows["sampleTypeNO"];
                    TESort.EditValue = rows["sort"];
                    TEAdd.EditValue = rows["address"];
                    TERemark.EditValue = rows["remark"];
                    CEState.Checked = true;

                }
            }
        }
    }
}
