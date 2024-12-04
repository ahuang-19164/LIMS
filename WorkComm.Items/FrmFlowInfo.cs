using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WorkComm.Items
{
    public partial class FrmFlowInfo : Form
    {
        string tableName = "WorkComm.ItemFlow";
        DataTable FrmDT = null;
        int EditState = 0;
        int SelectValueID = 0;//选择数据ID
        public FrmFlowInfo()
        {
            InitializeComponent();
            TextEdits.TextFormat(TEsort);
            GridControls.formartGridView(GVItemFlow);
            GridControls.showEmbeddedNavigator(GCItemFlow);
            groupInfo.Enabled = false;
        }
        //public static  List<sourceInfo> sourceInfos;

        private void FrmFlowInfo_Load(object sender, EventArgs e)
        {
            //sss = new List<sourceInfo>();
            sInfo sInfo = new sInfo();
            sInfo.TableName = tableName;
            DataTable dataTable = FrmDT = ApiHelpers.postInfo(sInfo);
            DataTable DTFlow = DTHelper.DTVisible(dataTable);
            GCItemFlow.DataSource = DTFlow;
            GVItemFlow.BestFitColumns();
            GridLookUpEdites.Formats(GENextFlow);
            GridLookUpEdites.Formats(RGENextFlow);

            DataTable DTFlows = DTFlow.Copy();
            DataRow dataRow = DTFlows.NewRow();
            dataRow["no"] = 0;
            dataRow["names"] = "结束流程";
            dataRow["shortNames"] = "end";
            dataRow["customCode"] = "任务完成";
            DTFlows.Rows.InsertAt(dataRow, 0);
            //DTAddAll(DTFlow);
            GENextFlow.Properties.DataSource = DTFlows;
            RGENextFlow.DataSource = DTFlows;

        }
        //public static List<sourceInfo> DTAddAll(DataTable DT)
        //{
        //    sourceInfos = new List<sourceInfo>();
        //    sourceInfo sourceInfoAll = new sourceInfo();
        //    sourceInfoAll.no = 0;
        //    sourceInfoAll.names = "结束流程";
        //    sourceInfoAll.shortNames = "JSLC";
        //    sourceInfoAll.customCode = "LastFlow";
        //    sourceInfos.Add(sourceInfoAll);
        //    if (DT != null)
        //    {
        //        foreach (DataRow row in DT.Rows)
        //        {
        //            sourceInfo sourceInfoItem = new sourceInfo();
        //            sourceInfoItem.no = row["no"];
        //            sourceInfoItem.names = row["names"];
        //            sourceInfoItem.shortNames = row["shortNames"];
        //            sourceInfoItem.customCode = row["customCode"];
        //            sourceInfos.Add(sourceInfoItem);
        //        }
        //    }
        //    return sourceInfos;
        //}
        //public class sourceInfo
        //{
        //    public object no { get; set; }
        //    public object names { get; set; }
        //    public object shortNames { get; set; }
        //    public object customCode { get; set; }
        //}

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupInfo.Enabled = true;
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
            TEcustomCode.EditValue = "";
            TEdataSource.EditValue = "";
            TEimgSource.EditValue = "";
            TEnames.EditValue = "";
            TEreflectionFile.EditValue = "";
            TEreflectionFrm.EditValue = "";
            TEshortNames.EditValue = "";
            GENextFlow.EditValue = "0";
            TEsort.EditValue = 999;


        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupInfo.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TEno.EditValue != null && TEnames.EditValue != null)
            {
                if (TEno.EditValue.ToString() != "" && TEnames.EditValue.ToString() != "")
                {
                    if (EditState == 1)
                    {
                        iInfo iInfo = new iInfo();
                        iInfo.TableName = tableName;
                        Dictionary<string, object> pairs = new Dictionary<string, object>();
                        pairs.Add("dstate", 0);
                        pairs.Add("state", CEstate.Checked);
                        pairs.Add("sort", TEsort.EditValue);
                        pairs.Add("no", TEno.EditValue);
                        pairs.Add("customCode", TEcustomCode.EditValue);
                        pairs.Add("dataSource", TEdataSource.EditValue);
                        pairs.Add("imgSource", TEimgSource.EditValue);
                        pairs.Add("names", TEnames.EditValue);
                        pairs.Add("reflectionFile", TEreflectionFile.EditValue);
                        pairs.Add("reflectionFrm", TEreflectionFrm.EditValue);
                        pairs.Add("shortNames", TEshortNames.EditValue);
                        pairs.Add("nextFlow", GENextFlow.EditValue);
                        iInfo.values = pairs;
                        ApiHelpers.postInfo(iInfo);

                        //sourceInfo sourceInfoItem = new sourceInfo();
                        //sourceInfoItem.no = TEno.EditValue;
                        //sourceInfoItem.names = TEnames.EditValue;
                        //sourceInfoItem.shortNames = TEshortNames.EditValue;
                        //sourceInfoItem.customCode = TEcustomCode.EditValue;
                        //sourceInfos.Add(sourceInfoItem);
                    }
                    if (SelectValueID != 0)
                    {
                        if (EditState == 2)
                        {
                            uInfo uInfo = new uInfo();
                            uInfo.TableName = tableName;

                            Dictionary<string, object> pairs = new Dictionary<string, object>();
                            pairs.Add("state", CEstate.Checked);
                            pairs.Add("sort", TEsort.EditValue);
                            pairs.Add("no", TEno.EditValue);
                            pairs.Add("customCode", TEcustomCode.EditValue);
                            pairs.Add("dataSource", TEdataSource.EditValue);
                            pairs.Add("imgSource", TEimgSource.EditValue);
                            pairs.Add("names", TEnames.EditValue);
                            pairs.Add("reflectionFile", TEreflectionFile.EditValue);
                            pairs.Add("reflectionFrm", TEreflectionFrm.EditValue);
                            pairs.Add("shortNames", TEshortNames.EditValue);
                            pairs.Add("nextFlow", GENextFlow.EditValue);
                            uInfo.values = pairs;
                            uInfo.DataValueID = SelectValueID;
                            ApiHelpers.postInfo(uInfo);
                        }
                    }
                    CommonDataRefresh.GetItemFlow();
                    FrmFlowInfo_Load(null, null);
                    groupInfo.Enabled = false;
                    EditState = 0;
                }
                else
                {
                    MessageBox.Show("必填项信息不能为空", "系统提示");
                }
            }
        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVItemFlow.GetFocusedDataRow() != null)
            {
                int ids = Convert.ToInt32(GVItemFlow.GetFocusedRowCellValue("id"));

                    if (ids != 0)
                    {
                        int a = DeleteHelper.hideinfo(ids, tableName);
                        if (a > 0)
                        {
                            CommonDataRefresh.GetItemFlow();
                            GVItemFlow.DeleteSelectedRows();
                        }
                    }
                
            }
            else
            {
                MessageBox.Show("请先选择需要编辑的项目", "系统提示");
            }
        }

        private void GVItemFlow_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {
                if (GVItemFlow.GetFocusedDataRow() != null)
                {
                    DataRow dataRow = GVItemFlow.GetFocusedDataRow();
                    SelectValueID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                    CEstate.Checked = dataRow["state"] != DBNull.Value ? Convert.ToBoolean(dataRow["state"]) : false;
                    TEno.EditValue = dataRow["no"];
                    TEcustomCode.EditValue = dataRow["customCode"];
                    TEdataSource.EditValue = dataRow["dataSource"];
                    TEimgSource.EditValue = dataRow["imgSource"];
                    TEnames.EditValue = dataRow["names"];
                    TEreflectionFile.EditValue = dataRow["reflectionFile"];
                    TEreflectionFrm.EditValue = dataRow["reflectionFrm"];
                    TEshortNames.EditValue = dataRow["shortNames"];
                    TEsort.EditValue = dataRow["sort"];
                    GENextFlow.EditValue = dataRow["nextFlow"];


                }
                else
                {
                    SelectValueID = 0;
                }
            }
        }

        private void TEnames_Leave(object sender, EventArgs e)
        {
            if (TEnames.EditValue != null)
            {
                TEshortNames.EditValue = ConvertShortName.GetChineseSpell(TEnames.EditValue.ToString());
            }
        }

        private void BTDesigner_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVItemFlow.GetFocusedDataRow();
            if(dataRow!=null)
            {
                int infoid = Convert.ToInt32(dataRow["id"]);
                if(infoid>=16)
                {
                    FrmDesigner frmDesigner = new FrmDesigner(dataRow);
                    Func<DataRow> func = frmDesigner.setFrom;
                    frmDesigner.ShowDialog();
                    dataRow = func();
                }
                else
                {
                    MessageBox.Show("系统内置模块不能编辑", "系统提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
    }
}
