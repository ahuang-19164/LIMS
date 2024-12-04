using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using Common.TestModel.Result;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkTest.TestMicrobe
{
    public partial class FrmTestMicrobe : XtraForm
    {
        string GetTestInfo = "";
        string SetTestInfo = "";
#pragma warning disable CS0169 // 从不使用字段“FrmTestMicrobe.dr”
        DataRelation dr;
#pragma warning restore CS0169 // 从不使用字段“FrmTestMicrobe.dr”
        public FrmTestMicrobe()
        {
            string startPath = Application.StartupPath;
            ConfigInfos.GetConfigInfo(startPath);
            GetTestInfo = ConfigInfos.ReadConfigInfo("GetTestMicrobeInfo");
            SetTestInfo = ConfigInfos.ReadConfigInfo("SetResultMicrobe");
            InitializeComponent();
            GridControls.formartGridView(GVItemInfo);
            GVItemInfo.DetailHeight = 10000;
            GVItemInfo.OptionsDetail.SmartDetailHeight = false;
            GridControls.showEmbeddedNavigator(GCInfo);



            //sys_userinfo userInfo = new sys_userinfo();
            //userInfo.names = "aaa";
            //userInfo.id = 1;

            //CommonData.UserInfo = userInfo;
            //CommonDataRefresh.GetSystemInfo();
            //CommonDataRefresh.GetWorkType();



            CreateInfo();
            Formats(RGEresultType, DTresultType);
            RGEmethodType = new RepositoryItemGridLookUpEdit();
            Formats(RGEmethodType, DTmethodType);
            RGEaqualitative = new RepositoryItemGridLookUpEdit();
            Formats(RGEaqualitative, DTaqualitative);


            //setResultInfo(2588, "T10011111772", "11", "");





            //var node = new GridLevelNode();
            //node.LevelTemplate = GVAntibiotic;
            //node.RelationName = "AntibioticInfos";//这里对应集合的属性名称
            //GCInfo.LevelTree.Nodes.AddRange(new GridLevelNode[] { node });

            ////添加对应的视图集合显示
            //GCInfo.ViewCollection.Clear();
            //GCInfo.ViewCollection.AddRange(new BaseView[] { GVItemInfo, GVAntibiotic });





            //var topNode = new GridLevelNode();
            //topNode.LevelTemplate = GVAntibiotic;           //这里是对应的视图
            //topNode.RelationName = "aaa";   //这里对应集合的属性名称
            //GCInfo.LevelTree.Nodes.Add(topNode);
            //GCInfo.ViewCollection.Clear();
            //GCInfo.ViewCollection.AddRange(new BaseView[] { GVItemInfo, GVAntibiotic });





            //GCInfo.ViewCollection.Clear();
            //GCInfo.ViewCollection.AddRange(new BaseView[] { GVItemInfo, GVAntibiotic });
        }
        RepositoryItemGridLookUpEdit RGEmethodType;
        RepositoryItemGridLookUpEdit RGEaqualitative;
        private void FrmTestMicrobe_Load(object sender, EventArgs e)
        {



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
#pragma warning disable CS0169 // 从不使用字段“FrmTestMicrobe.Ds”
        DataSet Ds;
#pragma warning restore CS0169 // 从不使用字段“FrmTestMicrobe.Ds”

        BindingList<MicrobeResultModel> ListMicrobeInfo;
        int infotestid = 0;
        string infobarcode = "";
        string infogroupNO = "";
        string infoflowNO = "";
        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="Barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {

            infotestid = testid;
            infobarcode = SampleInfo["barcode"] != DBNull.Value ? SampleInfo["barcode"].ToString() : "";
            infogroupNO = SampleInfo["groupNO"] != DBNull.Value ? SampleInfo["groupNO"].ToString() : "";
            infoflowNO = SampleInfo["groupFlowNO"] != DBNull.Value ? SampleInfo["groupFlowNO"].ToString() : ""; ;
            commInfoModel<GetMicrobeItemModel> commInfoModel = new commInfoModel<GetMicrobeItemModel>();
            //InfoLoad<GetMicrobeItemModel> InfoLoad = new InfoLoad<GetMicrobeItemModel>();
            commInfoModel.UserName = CommonData.UserInfo.names;
                
            List<GetMicrobeItemModel> testItems = new List<GetMicrobeItemModel>();
            GetMicrobeItemModel testItem = new GetMicrobeItemModel();
                testItem.testid = testid;
                testItem.Barcode = infobarcode;
                testItem.groupNO = infogroupNO;
                testItem.flowNO = infoflowNO;
                testItems.Add(testItem);
            commInfoModel.infos = testItems;
                string Sr = JsonHelper.SerializeObjct(commInfoModel);
                WebApiCallBack jm= ApiHelpers.postInfo(GetTestInfo, Sr);

            commReInfo<MicrobeInfoModel> ItemInfos = JsonHelper.JsonConvertObject<commReInfo<MicrobeInfoModel>>(jm);
            if (ItemInfos.infos != null&& ItemInfos.infos.Count>0)
            {
                //dr = new DataRelation("AntibioticInfos", Ds.Tables[0].Columns["itemCodes"], Ds.Tables[1].Columns["itemCodes"]);
                ListMicrobeInfo = new BindingList<MicrobeResultModel>(ItemInfos.infos[0].listResult); // 将List转换为BindList 
                                                                                               //var node = new GridLevelNode();
                                                                                               //node.LevelTemplate = GVAntibiotic;
                                                                                               //node.RelationName = "AntibioticInfos";//这里对应集合的属性名称
                                                                                               //GCInfo.LevelTree.Nodes.AddRange(new GridLevelNode[] { node });
                                                                                               ////添加对应的视图集合显示
                                                                                               //GCInfo.ViewCollection.Clear();
                                                                                               //GCInfo.ViewCollection.AddRange(new BaseView[] { GVItemInfo, GVAntibiotic });
                GCInfo.DataSource = ListMicrobeInfo;  //绑定主表到GridControl  从表会自动绑定到主表的行里面  如需设置从表 
                GCInfo.RefreshDataSource();
                GVItemInfo.BestFitColumns();
                GVAntibiotic.BestFitColumns();

                ExpandAllRows(GVItemInfo);
            }
            else
            {
                ListMicrobeInfo = null;
                GCInfo.DataSource = null;
            }
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="ResultState">结果结果状态 1.检验者 2.复初审者 3.审核者.4.反审核</param>
        /// <returns>0,保存失败，1，结果为空值，2，保存成功</returns>
        public string postResultInfo(int ResultState,int perid, int testid,string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        {

            //GVAntibiotics.FocusedRowHandle = -1;
            //GVItemInfo.FocusedRowHandle = -1;

            foreach (GridView GV in GCInfo.Views)
            {
                GV.FocusedRowHandle = -1;
            }
            if (barcode != "" && testid != 0 && groupNO != "")
            {
                //ResultInfo<TestInfo> resultInfo = new ResultInfo<TestInfo>();
                CommResultModel<MicrobeInfoModel> resultInfo = new CommResultModel<MicrobeInfoModel>();
                resultInfo.UserName = CommonData.UserInfo.names;
                
                resultInfo.ResultState = ResultState;
                resultInfo.testFlowNO = flowNO;
                resultInfo.AutographInfo = info;
                if (ResultState != 4)
                {
                    //List<TestInfo> testInfos = new List<TestInfo>();
                    MicrobeInfoModel testInfo = new MicrobeInfoModel();
                    testInfo.barcode = barcode;
                    testInfo.perid = perid;
                    testInfo.testid = testid;
                    testInfo.sampleID = sampleid;
                    testInfo.groupNO = groupNO;
                    List<MicrobeResultModel> microbeInfos = new List<MicrobeResultModel>(ListMicrobeInfo);
                    testInfo.listResult = microbeInfos;
                    //testInfos.Add(testInfo);
                    resultInfo.Result = testInfo;
                    string s = JsonHelper.SerializeObjct(resultInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(SetTestInfo, s);
                    return jm.data.ToString();
                }
                else
                {
                    MicrobeInfoModel testInfo = new MicrobeInfoModel();
                    testInfo.barcode = barcode;
                    testInfo.perid = perid;
                    testInfo.testid = testid;testInfo.sampleID = sampleid;
                    testInfo.groupNO = groupNO;
                    //List<MicrobeInfo> microbeInfos = new List<MicrobeInfo>(ListMicrobeInfo);
                    //testInfo.listResult = microbeInfos;
                    //testInfos.Add(testInfo);
                    resultInfo.Result = testInfo;
                    string s = JsonHelper.SerializeObjct(resultInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(SetTestInfo, s);
                    return jm.data.ToString();



                    //List<MicrobeTestInfo> microbeTestInfos = new List<MicrobeTestInfo>();
                    //MicrobeTestInfo microbeTestInfo = new MicrobeTestInfo();
                    //microbeTestInfo.barcode = barcode;
                    //microbetestInfo.testid = testid;testInfo.sampleID = sampleid;
                    //microbeTestInfo.groupNO = groupNO;
                    //microbeTestInfos.Add(microbeTestInfo);
                    //resultInfo.resultInfos= microbeTestInfos;
                    //string s = JsonHelper.SerializeObjct(resultInfo);
                    //string aaa = ApiHelpers.postInfo(SetTestInfo, s);
                    //return aaa;
                }


            }
            else
            {
                return "{\"code\":0,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息。\"}";
            }
        }


        public void ExpandAllRows(GridView view)
        {
            view.BeginUpdate();
            try
            {
                int dataRowCount = view.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                    view.SetMasterRowExpanded(rHandle, true);
            }
            finally
            {
                view.EndUpdate();
            }
        }




        GridView GVAntibiotics;
        private void GVItemInfo_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            RepositoryItemTextEdit RGETextEdit = new RepositoryItemTextEdit();
            //RGETextEdit.EditValueChanged += RGETextEdit_EditValueChanged;
            //RGETextEdit.Click += RGETextEdit_Click;
            //GridView gridView = sender as GridView;
            GVAntibiotics = GVItemInfo.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;
            if (GVAntibiotics != null)
            {
                GVAntibiotics.Columns.Clear();
                GridColumn GCantibioticNo = new GridColumn { Name = "a", FieldName = "antibioticNo", Caption = "编号", MaxWidth = 60, Visible = true };
                GCantibioticNo.OptionsColumn.AllowFocus = false;
                GCantibioticNo.ColumnEdit = RGETextEdit;
                GridColumn GCantibioticNames = new GridColumn { Name = "b", FieldName = "antibioticNames", Caption = "名称", Visible = true };
                GCantibioticNames.OptionsColumn.AllowFocus = false;
                GCantibioticNames.ColumnEdit = RGETextEdit;
                GridColumn GCantibioticEN = new GridColumn { Name = "c", FieldName = "antibioticEN", Caption = "英文名称", Visible = true };
                GCantibioticEN.OptionsColumn.AllowFocus = false;
                GCantibioticEN.ColumnEdit = RGETextEdit;
                GridColumn GCmicValue = new GridColumn { Name = "d", FieldName = "micValue", Caption = "MIC值", Visible = true };
                GCmicValue.OptionsColumn.AllowFocus = true;
                GCmicValue.ColumnEdit = RGETextEdit;
                GridColumn GCkbValue = new GridColumn { Name = "e", FieldName = "kbValue", Caption = "K-B值", Visible = true };
                GCkbValue.OptionsColumn.AllowFocus = true;
                GCkbValue.ColumnEdit = RGETextEdit;
                GridColumn GCitemResult = new GridColumn { Name = "f", FieldName = "itemResult", Caption = "结果", MinWidth = 100, Visible = true };
                GCitemResult.OptionsColumn.AllowFocus = true;
                GCitemResult.ColumnEdit = RGETextEdit;
                GridColumn GCmethodName = new GridColumn { Name = "g", FieldName = "methodName", Caption = "结果类型", Visible = true };
                GCmethodName.ColumnEdit = RGEmethodType;
                //RGEmethodType.EditValueChanged += RGETextEdit_EditValueChanged;
                GCmethodName.OptionsColumn.AllowFocus = true;
                GridColumn GCaqualitative = new GridColumn { Name = "h", FieldName = "aqualitative", Caption = "定性", Visible = true };
                GCaqualitative.ColumnEdit = RGEaqualitative;
                //RGEaqualitative.EditValueChanged += RGETextEdit_EditValueChanged;
                GCaqualitative.OptionsColumn.AllowFocus = true;
                GridColumn GCitemSort = new GridColumn { Name = "i", FieldName = "itemSort", Caption = "排序", MaxWidth = 35, Visible = true };
                GCitemSort.OptionsColumn.AllowFocus = true;
                GCitemSort.ColumnEdit = RGETextEdit;
                GridColumn GCremark = new GridColumn { Name = "j", FieldName = "remark", Caption = "备注", Visible = true };
                GCremark.OptionsColumn.AllowFocus = true;
                GCremark.ColumnEdit = RGETextEdit;
                GridColumn GCchannel = new GridColumn { Name = "k", FieldName = "channel", Caption = "通道号", Visible = false };
                GCchannel.OptionsColumn.AllowFocus = true;
                //GCchannel.ColumnEdit = RGETextEdit;
                GVAntibiotics.Columns.AddRange(new GridColumn[] { GCantibioticNo, GCantibioticNames, GCantibioticEN, GCmicValue, GCkbValue, GCitemResult, GCmethodName, GCaqualitative, GCremark, GCitemSort, GCchannel });
                //    GVAntibiotics.Columns.Add(new GridColumn { Name = "a", FieldName = "antibioticNo", Caption = "编号", MaxWidth = 60,Visible = true }); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "b", FieldName = "antibioticNames", Caption = "名称", Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "c", FieldName = "antibioticEN", Caption = "英文名称", Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "d", FieldName = "micValue", Caption = "MIC值", Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "e", FieldName = "kbValue", Caption = "K-B值", Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "f", FieldName = "itemResult", Caption = "结果", Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "g", FieldName = "methodName", Caption = "方法", Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "h", FieldName = "aqualitative", Caption = "定性", Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "e", FieldName = "itemSort", Caption = "排序", MaxWidth = 35, Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "f", FieldName = "remark", Caption = "备注", Visible = true}); ;
                //GVAntibiotics.Columns.Add(new GridColumn { Name = "g", FieldName = "channel", Caption = "通道号", Visible = false}); ;


                //GVAntibiotics.he
                GridControls.formartGridView(GVAntibiotics);
                GVAntibiotics.RowClick += GVAntibiotics_RowClick;
                GVAntibiotics.BestFitColumns();
                //GVAntibiotics.Click += GVAntibiotics_Click;
            }
        }


        private void GVItemInfo_RowClick(object sender, RowClickEventArgs e)
        {


        }




        private void GVAntibiotics_RowClick(object sender, RowClickEventArgs e)
        {
            MicrobeInfoModel microbeInfo = GVItemInfo.GetFocusedRow() as MicrobeInfoModel;
            //MicrobeInfoModel microbeInfo = GVItemInfo.GetFocusedRow() as MicrobeInfoModel;
            GVAntibiotics = sender as GridView;
            MicrobeAntibioticModel antibioticInfo = GVAntibiotics.FocusedValue as MicrobeAntibioticModel;
        }

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            FrmShowItem frmShowItem = new FrmShowItem("", infoflowNO);
            Func<DataRow> func = frmShowItem.ReturnResult;
            frmShowItem.ShowDialog();
            DataRow DRItemInfo = func();


            if (ListMicrobeInfo == null)
            {
                BindingList<MicrobeResultModel> microbeInfos = new BindingList<MicrobeResultModel>();
                //BindingList<MicrobeInfoModel> microbeInfos = new BindingList<MicrobeInfoModel>();
                if (DRItemInfo != null)
                {
                    MicrobeResultModel microbeInfo = new MicrobeResultModel();
                    microbeInfo.testid = infotestid;
                    microbeInfo.barcode = infobarcode;
                    microbeInfo.groupNO = infogroupNO;
                    microbeInfo.itemCodes = DRItemInfo["no"] != DBNull.Value ? DRItemInfo["no"].ToString() : "";
                    microbeInfo.itemNames = DRItemInfo["names"] != DBNull.Value ? DRItemInfo["names"].ToString() : "";
                    microbeInfo.channel = DRItemInfo["channel"] != DBNull.Value ? DRItemInfo["channel"].ToString() : "";
                    microbeInfo.itemResult = DRItemInfo["defaultValue"] != DBNull.Value ? DRItemInfo["defaultValue"].ToString() : "";
                    microbeInfo.itemSort = DRItemInfo["sort"] != DBNull.Value ? Convert.ToInt32(DRItemInfo["sort"]) : 0;
                    microbeInfo.reportState = DRItemInfo["visibleState"] != DBNull.Value ? Convert.ToBoolean(DRItemInfo["visibleState"]) : true;
                    microbeInfo.state = DRItemInfo["state"] != DBNull.Value ? Convert.ToBoolean(DRItemInfo["state"]) : true;
                    microbeInfo.resultNullState = DRItemInfo["resultNullState"] != DBNull.Value ? Convert.ToBoolean(DRItemInfo["resultNullState"]) : true;
                    microbeInfo.delstate = DRItemInfo["delegeteState"] != DBNull.Value ? Convert.ToBoolean(DRItemInfo["delegeteState"]) : false;
                    microbeInfo.delstateClientNO = DRItemInfo["delegeteCompanyNO"] != DBNull.Value ? DRItemInfo["delegeteCompanyNO"].ToString() : "";
                    //microbeInfo.itemSort = DRItemInfo["sort"] != DBNull.Value ? Convert.ToInt32(DRItemInfo["sort"]) : 0;
                    microbeInfos.Add(microbeInfo);
                }
                ListMicrobeInfo = microbeInfos;
            }
            else
            {
                if (DRItemInfo != null)
                {
                    //MicrobeInfo microbeInfo = new MicrobeInfo();
                    MicrobeResultModel microbeInfo = new MicrobeResultModel();
                    microbeInfo.testid = infotestid;
                    microbeInfo.barcode = infobarcode;
                    microbeInfo.groupNO = infogroupNO;
                    microbeInfo.itemCodes = DRItemInfo["no"] != DBNull.Value ? DRItemInfo["no"].ToString() : "";
                    microbeInfo.itemNames = DRItemInfo["names"] != DBNull.Value ? DRItemInfo["names"].ToString() : "";
                    microbeInfo.channel = DRItemInfo["channel"] != DBNull.Value ? DRItemInfo["channel"].ToString() : "";
                    microbeInfo.itemResult = DRItemInfo["defaultValue"] != DBNull.Value ? DRItemInfo["defaultValue"].ToString() : "";
                    microbeInfo.itemSort = DRItemInfo["sort"] != DBNull.Value ? Convert.ToInt32(DRItemInfo["sort"]) : 0;
                    microbeInfo.reportState = DRItemInfo["visibleState"] != DBNull.Value ? Convert.ToBoolean(DRItemInfo["visibleState"]) : true;
                    microbeInfo.state = DRItemInfo["state"] != DBNull.Value ? Convert.ToBoolean(DRItemInfo["state"]) : true;
                    microbeInfo.resultNullState = DRItemInfo["resultNullState"] != DBNull.Value ? Convert.ToBoolean(DRItemInfo["resultNullState"]) : true;
                    microbeInfo.delstate = DRItemInfo["delegeteState"] != DBNull.Value ? Convert.ToBoolean(DRItemInfo["delegeteState"]) : false;
                    microbeInfo.delstateClientNO = DRItemInfo["delegeteCompanyNO"] != DBNull.Value ? DRItemInfo["delegeteCompanyNO"].ToString() : "";
                    //microbeInfo.itemSort = DRItemInfo["sort"] != DBNull.Value ? Convert.ToInt32(DRItemInfo["sort"]) : 0;
                    ListMicrobeInfo.Add(microbeInfo);
                }
            }
            GCInfo.DataSource = null;
            GCInfo.DataSource = ListMicrobeInfo;
            GVItemInfo.BestFitColumns();
            ExpandAllRows(GVItemInfo);


        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MicrobeResultModel microbeInfo = GVItemInfo.GetFocusedRow() as MicrobeResultModel;
            if (microbeInfo.id != 0)
            {
                DialogResult dialogResult = MessageBox.Show("确定删除该项目信息！", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    hideInfo hideInfo = new hideInfo();
                    hideInfo.TableName = "WorkTest.ResultMicrobeInfo";
                    hideInfo.DataValueID = microbeInfo.id;
                    int a = ApiHelpers.postInfo(hideInfo);
                    if (a == 1)
                    {
                        GVItemInfo.DeleteSelectedRows();
                        //ListMicrobeInfo.Remove(microbeInfo);
                        //GCInfo.DataSource = null;
                        //GCInfo.DataSource = ListMicrobeInfo;
                        //ExpandAllRows(GVItemInfo);
                    }

                }
            }
            else
            {
                GVItemInfo.DeleteSelectedRows();
            }

        }

        private void BTGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MicrobeResultModel microbeInfo = GVItemInfo.GetFocusedRow() as MicrobeResultModel;
            if (microbeInfo != null)
            {
                if (microbeInfo.itemCodes != null)
                {
                    FrmAddGroup frmAddGroup = new FrmAddGroup();
                    Func<DataTable> func = frmAddGroup.reDT;
                    frmAddGroup.ShowDialog();
                    DataTable reDataTable = func();
                    if (reDataTable != null)
                    {
                        if (microbeInfo.AntibioticInfos != null)
                        {
                            foreach (DataRow dataRow in reDataTable.Rows)
                            {
                                MicrobeAntibioticModel antibioticInfo = new MicrobeAntibioticModel();
                                antibioticInfo.perid = microbeInfo.perid;
                                antibioticInfo.testid = microbeInfo.testid;
                                antibioticInfo.barcode = microbeInfo.barcode;
                                antibioticInfo.itemCodes = microbeInfo.itemCodes;
                                antibioticInfo.itemNames = microbeInfo.itemNames;
                                antibioticInfo.antibioticNo = dataRow["no"] != DBNull.Value ? dataRow["no"].ToString() : "";
                                antibioticInfo.antibioticNames = dataRow["names"] != DBNull.Value ? dataRow["names"].ToString() : "";
                                antibioticInfo.antibioticEN = dataRow["namesEn"] != DBNull.Value ? dataRow["namesEn"].ToString() : "";
                                antibioticInfo.micValue = dataRow["micValue"] != DBNull.Value ? dataRow["micValue"].ToString() : "";
                                antibioticInfo.kbValue = dataRow["kbValue"] != DBNull.Value ? dataRow["kbValue"].ToString() : "";
                                antibioticInfo.itemResult = dataRow["itemResult"] != DBNull.Value ? dataRow["itemResult"].ToString() : "";
                                antibioticInfo.methodName = dataRow["methodName"] != DBNull.Value ? dataRow["methodName"].ToString() : "";
                                antibioticInfo.aqualitative = dataRow["aqualitative"] != DBNull.Value ? dataRow["aqualitative"].ToString() : "";
                                antibioticInfo.channel = dataRow["channel"] != DBNull.Value ? dataRow["channel"].ToString() : "";
                                antibioticInfo.itemSort = dataRow["sort"] != DBNull.Value ? Convert.ToInt32(dataRow["sort"]) : 0;
                                antibioticInfo.remark = dataRow["remark"] != DBNull.Value ? dataRow["remark"].ToString() : "";
                                //antibioticInfo.itemSort = microbeInfo.perid;
                                //antibioticInfo.remark = microbeInfo.perid;
                                microbeInfo.AntibioticInfos.Add(antibioticInfo);
                            }
                        }
                        else
                        {
                            List<MicrobeAntibioticModel> AntibioticInfos = new List<MicrobeAntibioticModel>();
                            foreach (DataRow dataRow in reDataTable.Rows)
                            {
                                MicrobeAntibioticModel antibioticInfo = new MicrobeAntibioticModel();
                                antibioticInfo.perid = microbeInfo.perid;
                                antibioticInfo.testid = microbeInfo.testid;
                                antibioticInfo.barcode = microbeInfo.barcode;
                                antibioticInfo.itemCodes = microbeInfo.itemCodes;
                                antibioticInfo.itemNames = microbeInfo.itemNames;
                                antibioticInfo.antibioticNo = dataRow["no"] != DBNull.Value ? dataRow["no"].ToString() : "";
                                antibioticInfo.antibioticNames = dataRow["names"] != DBNull.Value ? dataRow["names"].ToString() : "";
                                antibioticInfo.antibioticEN = dataRow["namesEn"] != DBNull.Value ? dataRow["namesEn"].ToString() : "";
                                antibioticInfo.micValue = dataRow["micValue"] != DBNull.Value ? dataRow["micValue"].ToString() : "";
                                antibioticInfo.kbValue = dataRow["kbValue"] != DBNull.Value ? dataRow["kbValue"].ToString() : "";
                                antibioticInfo.itemResult = dataRow["itemResult"] != DBNull.Value ? dataRow["itemResult"].ToString() : "";
                                antibioticInfo.methodName = dataRow["methodName"] != DBNull.Value ? dataRow["methodName"].ToString() : "";
                                antibioticInfo.aqualitative = dataRow["aqualitative"] != DBNull.Value ? dataRow["aqualitative"].ToString() : "";
                                antibioticInfo.channel = dataRow["channel"] != DBNull.Value ? dataRow["channel"].ToString() : "";
                                antibioticInfo.itemSort = dataRow["sort"] != DBNull.Value ? Convert.ToInt32(dataRow["sort"]) : 0;
                                antibioticInfo.remark = dataRow["remark"] != DBNull.Value ? dataRow["remark"].ToString() : "";
                                //antibioticInfo.itemSort = microbeInfo.perid;
                                //antibioticInfo.remark = microbeInfo.perid;
                                AntibioticInfos.Add(antibioticInfo);
                            }
                            microbeInfo.AntibioticInfos = AntibioticInfos;
                        }
                        GCInfo.DataSource = null;
                        GCInfo.DataSource = ListMicrobeInfo;

                        //GVAntibiotics.BestFitColumns();
                        ExpandAllRows(GVItemInfo);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择项目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            else
            {
                MessageBox.Show("请先选择需要加抗生素项目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }



        }

        private void BTAddAntibiotic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MicrobeResultModel microbeInfo = GVItemInfo.GetFocusedRow() as MicrobeResultModel;
            if (microbeInfo != null)
            {
                if (microbeInfo.itemCodes != null)
                {
                    FrmAddAntibiotic frmAddAntibiotic = new FrmAddAntibiotic();
                    Func<DataTable> func = frmAddAntibiotic.reDT;
                    frmAddAntibiotic.ShowDialog();
                    DataTable reDataTable = func();
                    if (reDataTable != null)
                    {
                        if (microbeInfo.AntibioticInfos != null)
                        {
                            foreach (DataRow dataRow in reDataTable.Rows)
                            {
                                MicrobeAntibioticModel antibioticInfo = new MicrobeAntibioticModel();
                                antibioticInfo.perid = microbeInfo.perid;
                                antibioticInfo.testid = microbeInfo.testid;
                                antibioticInfo.barcode = microbeInfo.barcode;
                                antibioticInfo.itemCodes = microbeInfo.itemCodes;
                                antibioticInfo.itemNames = microbeInfo.itemNames;
                                antibioticInfo.antibioticNo = dataRow["no"] != DBNull.Value ? dataRow["no"].ToString() : "";
                                antibioticInfo.antibioticNames = dataRow["names"] != DBNull.Value ? dataRow["names"].ToString() : "";
                                antibioticInfo.antibioticEN = dataRow["namesEn"] != DBNull.Value ? dataRow["namesEn"].ToString() : "";
                                antibioticInfo.micValue = dataRow["micValue"] != DBNull.Value ? dataRow["micValue"].ToString() : "";
                                antibioticInfo.kbValue = dataRow["kbValue"] != DBNull.Value ? dataRow["kbValue"].ToString() : "";
                                antibioticInfo.itemResult = dataRow["itemResult"] != DBNull.Value ? dataRow["itemResult"].ToString() : "";
                                antibioticInfo.methodName = dataRow["methodName"] != DBNull.Value ? dataRow["methodName"].ToString() : "";
                                antibioticInfo.aqualitative = dataRow["aqualitative"] != DBNull.Value ? dataRow["aqualitative"].ToString() : "";
                                antibioticInfo.channel = dataRow["channel"] != DBNull.Value ? dataRow["channel"].ToString() : "";
                                antibioticInfo.itemSort = dataRow["sort"] != DBNull.Value ? Convert.ToInt32(dataRow["sort"]) : 0;
                                antibioticInfo.remark = dataRow["remark"] != DBNull.Value ? dataRow["remark"].ToString() : "";
                                //antibioticInfo.itemSort = microbeInfo.perid;
                                //antibioticInfo.remark = microbeInfo.perid;
                                microbeInfo.AntibioticInfos.Add(antibioticInfo);
                            }
                        }
                        else
                        {
                            List<MicrobeAntibioticModel> AntibioticInfos = new List<MicrobeAntibioticModel>();
                            foreach (DataRow dataRow in reDataTable.Rows)
                            {
                                MicrobeAntibioticModel antibioticInfo = new MicrobeAntibioticModel();
                                antibioticInfo.perid = microbeInfo.perid;
                                antibioticInfo.testid = microbeInfo.testid;
                                antibioticInfo.barcode = microbeInfo.barcode;
                                antibioticInfo.itemCodes = microbeInfo.itemCodes;
                                antibioticInfo.itemNames = microbeInfo.itemNames;
                                antibioticInfo.antibioticNo = dataRow["no"] != DBNull.Value ? dataRow["no"].ToString() : "";
                                antibioticInfo.antibioticNames = dataRow["names"] != DBNull.Value ? dataRow["names"].ToString() : "";
                                antibioticInfo.antibioticEN = dataRow["namesEn"] != DBNull.Value ? dataRow["namesEn"].ToString() : "";
                                antibioticInfo.micValue = dataRow["micValue"] != DBNull.Value ? dataRow["micValue"].ToString() : "";
                                antibioticInfo.kbValue = dataRow["kbValue"] != DBNull.Value ? dataRow["kbValue"].ToString() : "";
                                antibioticInfo.itemResult = dataRow["itemResult"] != DBNull.Value ? dataRow["itemResult"].ToString() : "";
                                antibioticInfo.methodName = dataRow["methodName"] != DBNull.Value ? dataRow["methodName"].ToString() : "";
                                antibioticInfo.aqualitative = dataRow["aqualitative"] != DBNull.Value ? dataRow["aqualitative"].ToString() : "";
                                antibioticInfo.channel = dataRow["channel"] != DBNull.Value ? dataRow["channel"].ToString() : "";
                                antibioticInfo.itemSort = dataRow["sort"] != DBNull.Value ? Convert.ToInt32(dataRow["sort"]) : 0;
                                antibioticInfo.remark = dataRow["remark"] != DBNull.Value ? dataRow["remark"].ToString() : "";
                                //antibioticInfo.itemSort = microbeInfo.perid;
                                //antibioticInfo.remark = microbeInfo.perid;
                                AntibioticInfos.Add(antibioticInfo);
                            }
                            microbeInfo.AntibioticInfos = AntibioticInfos;
                        }
                        GCInfo.DataSource = null;
                        GCInfo.DataSource = ListMicrobeInfo;
                        //GVAntibiotics.BestFitColumns();
                        ExpandAllRows(GVItemInfo);
                    }
                }
                else
                {
                    MessageBox.Show("请先选择项目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }

            }
            else
            {
                MessageBox.Show("请先选择需要加抗生素项目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }


        }

        private void GridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            ColumnView View = sender as ColumnView;
            View.SetRowCellValue(e.RowHandle, View.Columns["no"], 10000);
            //View.SetRowCellValue(e.RowHandle, View.Columns["state"], true);
            View.SetRowCellValue(e.RowHandle, View.Columns["itemSort"], 999);
        }

        private void BTDelAntibiotic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MicrobeResultModel microbeInfo = GVItemInfo.GetFocusedRow() as MicrobeResultModel;
            MicrobeAntibioticModel antibioticInfo = GVAntibiotics.GetFocusedRow() as MicrobeAntibioticModel;
#pragma warning disable CS0472 // 由于“int”类型的值永不等于“int?”类型的 "null"，该表达式的结果始终为“true”
            if (antibioticInfo != null && antibioticInfo.id != null && antibioticInfo.id != 0)
#pragma warning restore CS0472 // 由于“int”类型的值永不等于“int?”类型的 "null"，该表达式的结果始终为“true”
            {
                DialogResult dialogResult = MessageBox.Show("确定删除该项目信息！", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    hideInfo hideInfo = new hideInfo();
                    hideInfo.TableName = "WorkTest.ResultMicrobeItem";
                    hideInfo.DataValueID = antibioticInfo.id;
                    int a = ApiHelpers.postInfo(hideInfo);
                    if (a == 1)
                    {
                        GVAntibiotics.DeleteSelectedRows();
                        microbeInfo.AntibioticInfos.Remove(antibioticInfo);
                        GCInfo.DataSource = null;
                        GCInfo.DataSource = ListMicrobeInfo;
                        ExpandAllRows(GVItemInfo);
                    }

                }
            }
            else
            {
                GVAntibiotics.DeleteSelectedRows();
                microbeInfo.AntibioticInfos.Remove(antibioticInfo);
                GCInfo.DataSource = null;
                GCInfo.DataSource = ListMicrobeInfo;
                ExpandAllRows(GVItemInfo);
            }

        }



        private void BTTest_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void RTEitemResult_DoubleClick(object sender, EventArgs e)
        {
            MicrobeResultModel microbeInfo = GVItemInfo.GetFocusedRow() as MicrobeResultModel;
            if (microbeInfo != null)
            {
                string ResultTypeValue = microbeInfo.resultType != null ? microbeInfo.resultType : "";
                switch (ResultTypeValue)
                {
                    case "检测结果":
                        FrmResultType frmResultType1 = new FrmResultType(WorkCommData.DTMicrobeTest);
                        Func<string> func1 = frmResultType1.ReresultValue;
                        frmResultType1.ShowDialog();
                        //microbeInfo.itemResult = func1();
                        GVItemInfo.SetFocusedRowCellValue("itemResult", func1());
                        break;
                    case "涂片结果":
                        FrmResultType frmResultType2 = new FrmResultType(WorkCommData.DTMicrobeSmear);
                        Func<string> func2 = frmResultType2.ReresultValue;
                        frmResultType2.ShowDialog();
                        GVItemInfo.SetFocusedRowCellValue("itemResult", func2());
                        //microbeInfo.itemResult = func2();
                        break;
                    case "阳性结果":
                        FrmResultType frmResultType3 = new FrmResultType(WorkCommData.DTMicrobeCultivation);
                        Func<string> func3 = frmResultType3.ReresultValue;
                        frmResultType3.ShowDialog();
                        GVItemInfo.SetFocusedRowCellValue("itemResult", func3());
                        //microbeInfo.itemResult = func3();
                        break;
                    case "阴性结果":
                        FrmResultType frmResultType4 = new FrmResultType(WorkCommData.DTMicrobeTest);
                        Func<string> func4 = frmResultType4.ReresultValue;
                        frmResultType4.ShowDialog();
                        GVItemInfo.SetFocusedRowCellValue("itemResult", func4());
                        //microbeInfo.itemResult = func4();
                        break;
                    default:
                        break;
                }
                GVItemInfo.FocusedColumn.BestFit();
            }

        }
        /// <summary>
        /// 更换结果类型，清空结果描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RGEresultType_EditValueChanged(object sender, EventArgs e)
        {
            GVItemInfo.SetFocusedRowCellValue("itemResult", "");
        }


    }
}
