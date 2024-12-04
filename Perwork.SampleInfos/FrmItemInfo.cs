using Common.ControlHandle;
using Common.Data;
using System;
using System.Data;
using System.Linq;

namespace Perwork.SampleInfos
{
    public partial class FrmItemInfo : DevExpress.XtraEditors.XtraForm
    {
        string applyNOs = "";//组套项目列表
        string groupNOs = "";//组合项目列表
        string ItemNOs = "";//项目信息列表
        public FrmItemInfo(string applyNO)
        {
            InitializeComponent();
            applyNOs = applyNO;
            GridLookUpEdites.Formats(RGEgroupNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(RGEsampleTypeNO);
            GridControls.formartGridView(GVTestInfo);
            GridControls.showEmbeddedNavigator(GCTestInfo);

        }

        private void FrmItemInfo_Load(object sender, EventArgs e)
        {



            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;






            DataSet dataSet = new DataSet();

            if (WorkCommData.DTItemApply != null)
            {
                if (WorkCommData.DTItemApply.Select($"no='{applyNOs}'").Count() > 0)
                {
                    DataTable DTapply = WorkCommData.DTItemApply.Select($"no='{applyNOs}'").CopyToDataTable();
                    DTapply.TableName = "applyInfo";
                    dataSet.Tables.Add(DTapply);
                    groupNOs = DTapply.Rows[0]["groupItemList"].ToString();

                }
            }
            if (WorkCommData.DTItemGroup != null)
            {
                if (WorkCommData.DTItemGroup.Select($"no in ({groupNOs})").Count() > 0)
                {
                    DataTable DTgroup = WorkCommData.DTItemGroup.Select($"no in ({groupNOs})").CopyToDataTable();
                    DTgroup.TableName = "groupInfo";
                    dataSet.Tables.Add(DTgroup);
                    foreach (DataRow dataRow in DTgroup.Rows)
                    {
                        ItemNOs += dataRow["testItemList"];
                    }
                    ItemNOs = ItemNOs.Substring(0, ItemNOs.Length - 1);
                }
            }
            if (WorkCommData.DTItemTest != null)
            {
                if (WorkCommData.DTItemTest.Select($"no in ({ItemNOs})").Count() > 0)
                {
                    DataTable DTitem = WorkCommData.DTItemTest.Select($"no in ({ItemNOs})").CopyToDataTable();
                    DTitem.TableName = "itemInfo";
                    dataSet.Tables.Add(DTitem);
                }
            }



            GCTestInfo.DataSource = dataSet.Tables["itemInfo"];
            //GVTestInfo.Columns["groupNO"].SortOrder= DevExpress.Data.ColumnSortOrder.Ascending;
            //GVTestInfo.EndSort();

            //DataRelation dr = new DataRelation("组合项目清单", dataSet.Tables["applyInfo"].Columns["no"], dataSet.Tables["groupInfo"].Columns["no"]);

            ////设定关系，ds.a(表).id(字段)=ds.b.id

            //DataRelation dr2 = new DataRelation("检测项目清单", dataSet.Tables["groupInfo"].Columns["no"], dataSet.Tables["itemInfo"].Columns["no"]);

            //dataSet.Relations.Add(dr);

            //dataSet.Relations.Add(dr2);

            //gridControl1.DataSource = dataSet.Tables["applyInfo"];//设定主表

            GVTestInfo.BestFitColumns();





        }
    }
}
