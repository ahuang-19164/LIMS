using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace workOther.MicrobeInfo
{
    public partial class FrmMicrobeAntibiotic : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "WorkComm.MicrobeAntibiotic";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;
        public FrmMicrobeAntibiotic()
        {
            CreateInfo();
            //tableName = TableNames;
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GInfo.Enabled = false;

            TextEdits.TextFormat(TESort);
            //GridLookUpEdites.Formats(GEgroupCode);
            GridLookUpEdites.Formats(RGEgroupCode);
            GridControls.formartGridView(GVInfos);
            GridControls.showEmbeddedNavigator(GCInfos);
            Formats(GEmethodName, DTmethodType);
            Formats(GEaqualitative, DTaqualitative);

            Formats(RGEmethodName, DTmethodType);
            Formats(RGEaqualitative, DTaqualitative);




        }
        /// <summary>
        ///格式化gridlookupEdit gridview 绑定 no,names,shortNames,customCode 字段
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void Formats(GridLookUpEdit gridLookUpEdit, DataTable dataSource = null)
        {
            gridLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            gridLookUpEdit.Properties.View.BestFitColumns();
            gridLookUpEdit.Properties.AutoComplete = false;
            gridLookUpEdit.Properties.ImmediatePopup = true;
            gridLookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            gridLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gridLookUpEdit.Properties.View.Columns.AddRange(new GridColumn[] {
                new GridColumn {FieldName = "no",MaxWidth=100,Caption="编号",Visible=true },
                new GridColumn {FieldName = "names",MinWidth=150,Caption="名称",Visible=true  },
                new GridColumn {FieldName = "shortNames", MinWidth=50,Caption = "拼音简称",Visible=true}});

            gridLookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            gridLookUpEdit.Properties.View.BestFitColumns();
            gridLookUpEdit.Properties.DisplayMember = "names";
            gridLookUpEdit.Properties.ValueMember = "names";
            //gridLookUpEdit.EditValue = "";
            gridLookUpEdit.Properties.NullText = "";
            gridLookUpEdit.Properties.SearchMode = GridLookUpSearchMode.AutoSuggest;

            if (dataSource != null)
            {
                gridLookUpEdit.Properties.DataSource = dataSource;
            }




            //gridLookUpEdit.EditValueChanging += GridLookUpEdit_EditValueChanging;

            //gridLookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
            //gridLookUpEdit.EnabledChanged += GridLookUpEdit_EnabledChanged;
        }

        /// <summary>
        ///格式化gridlookupEdit gridview 绑定 no,names,shortNames,customCode 字段
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void Formats(RepositoryItemGridLookUpEdit repositoryItemGridLookUp, DataTable datasrouce = null)
        {
            repositoryItemGridLookUp.AutoComplete = false;
            repositoryItemGridLookUp.ImmediatePopup = true;
            repositoryItemGridLookUp.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryItemGridLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryItemGridLookUp.View.Columns.AddRange(new GridColumn[] {
                new GridColumn {FieldName = "no",MaxWidth=100,Caption="编号",Visible=true },
                new GridColumn {FieldName = "names",MinWidth=150,Caption="类型",Visible=true  },
                new GridColumn {FieldName = "shortNames",MinWidth=50,Caption = "拼音简称",Visible=true  }});
            repositoryItemGridLookUp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repositoryItemGridLookUp.View.BestFitColumns();
            repositoryItemGridLookUp.DisplayMember = "names";
            repositoryItemGridLookUp.ValueMember = "names";
            repositoryItemGridLookUp.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            repositoryItemGridLookUp.NullText = "";
            repositoryItemGridLookUp.SearchMode = GridLookUpSearchMode.AutoSuggest;
            if (datasrouce != null)
            {
                repositoryItemGridLookUp.DataSource = datasrouce;
            }
            //repositoryItemGridLookUp.EditValueChanging += RepositoryItemGridLookUp_EditValueChanging;
            //repositoryItemGridLookUp.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
        }
        static DataTable DTresultType;
        static DataTable DTmethodType;
        static DataTable DTaqualitative;

        public static void CreateInfo()
        {
            DTresultType = new DataTable();
            DTmethodType = new DataTable();
            DTaqualitative = new DataTable();


            DTresultType.Columns.AddRange(new DataColumn[] {
            new DataColumn() { ColumnName = "no" },
            new DataColumn() { ColumnName = "names" },
            new DataColumn() { ColumnName = "shortNames" } });
            DTmethodType.Columns.AddRange(new DataColumn[] {
            new DataColumn() { ColumnName = "no" },
            new DataColumn() { ColumnName = "names" },
            new DataColumn() { ColumnName = "shortNames" } });
            DTaqualitative.Columns.AddRange(new DataColumn[] {
            new DataColumn() { ColumnName = "no" },
            new DataColumn() { ColumnName = "names" },
            new DataColumn() { ColumnName = "shortNames" }});
            DTresultType.Rows.Add("1", "检测结果", "JCJG");
            DTresultType.Rows.Add("2", "涂片结果", "TPJG");
            DTresultType.Rows.Add("3", "阳性结果", "YXJG");
            DTresultType.Rows.Add("4", "阴性结果", "YXJG");
            DTmethodType.Rows.Add("1", "+", "+");
            DTmethodType.Rows.Add("2", "BLAC", "BLAC");
            DTmethodType.Rows.Add("3", "ESBL", "ESBL");
            DTmethodType.Rows.Add("4", "IB", "IB");
            DTmethodType.Rows.Add("4", "MS", "MS");
            DTaqualitative.Rows.Add("1", "敏感", "MG");
            DTaqualitative.Rows.Add("2", "耐药", "NY");
            DTaqualitative.Rows.Add("3", "中介", "ZJ");
            DTaqualitative.Rows.Add("4", "其他", "QT");
        }








        private void Frminfo_Load(object sender, EventArgs e)
        {

            //RGEgroupCode.DataSource = GEgroupCode.Properties.DataSource = WorkCommData.DTItemGroup.Select($"workNO='6' and dstate=0").CopyToDataTable();
            //RGEgroupCode.DataSource = WorkCommData.DTItemGroup;
            sInfo sInfo = new sInfo();
            sInfo.TableName = tableName;
            FrmDT = WorkCommData.DTMicrobeAntibiotic = ApiHelpers.postInfo(sInfo);
            GCInfos.DataSource = DTHelper.DTVisible(FrmDT);
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
            TEnamesEn.EditValue = "";
            TEchannel.EditValue = "";
            TEmicValue.EditValue = "";
            TEkbValue.EditValue = "";
            TEitemResult.EditValue = "";
            GEmethodName.EditValue = "";
            GEaqualitative.EditValue = "";
            //GEgroupCode.EditValue = 0;
            TEvalue.EditValue = "";
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
                pairs.Add("namesEn", TEnamesEn.EditValue);
                pairs.Add("channel", TEchannel.EditValue);
                pairs.Add("micValue", TEmicValue.EditValue);
                pairs.Add("kbValue", TEkbValue.EditValue);
                pairs.Add("itemResult", TEitemResult.EditValue);
                pairs.Add("methodName", GEmethodName.EditValue);
                pairs.Add("aqualitative", GEaqualitative.EditValue);

                //pairs.Add("groupCode", GEgroupCode.EditValue);
                pairs.Add("value", TEvalue.EditValue);
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
                    pairs.Add("namesEn", TEnamesEn.EditValue);
                    pairs.Add("channel", TEchannel.EditValue);

                    pairs.Add("micValue", TEmicValue.EditValue);
                    pairs.Add("kbValue", TEkbValue.EditValue);
                    pairs.Add("itemResult", TEitemResult.EditValue);
                    pairs.Add("methodName", GEmethodName.EditValue);
                    pairs.Add("aqualitative", GEaqualitative.EditValue);

                    //pairs.Add("groupCode", GEgroupCode.EditValue);
                    pairs.Add("value", TEvalue.EditValue);
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
                    TEnamesEn.EditValue = dataRow["namesEn"];
                    TEchannel.EditValue = dataRow["channel"];

                    TEmicValue.EditValue = dataRow["micValue"];
                    TEkbValue.EditValue = dataRow["kbValue"];
                    TEitemResult.EditValue = dataRow["itemResult"];
                    GEmethodName.EditValue = dataRow["methodName"];
                    GEaqualitative.EditValue = dataRow["aqualitative"];





                    //GEgroupCode.EditValue = dataRow["groupCode"];
                    TESort.EditValue = dataRow["sort"];
                    TEvalue.EditValue = dataRow["value"];
                    TEremark.EditValue = dataRow["remark"];
                    CBState.Checked = Convert.ToBoolean(dataRow["state"]);
                }
            }
        }
    }
}
