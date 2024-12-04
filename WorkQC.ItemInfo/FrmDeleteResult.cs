using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmDeleteResult : XtraForm
    {
        public FrmDeleteResult(string itemNO, string qcTime, string itemResultsort)
        {
            InitializeComponent();


            GridControls.formartGridView(gridView1);
            GridControls.showEmbeddedNavigator(gridControl1);
            GridControls.ShowViewColor(gridView1);

            sInfo sInfo = new sInfo();
            sInfo.TableName = "QC.QCItemResult";
            sInfo.wheres = $"itemNO='{itemNO}' and qcTime='{qcTime}' and sort='{itemResultsort}' and dstate=0";
            //sInfo.OrderColumns = "";
            gridControl1.DataSource = ApiHelpers.postInfo(sInfo);





            sInfo sInfo2 = new sInfo();
            sInfo2.TableName = "QC.QCPlanGrade";
            sInfo2.wheres = $"itemNO='{itemNO}' and dstate=0";
            RGEgradeid.DataSource = ApiHelpers.postInfo(sInfo2);




            gridView1.BestFitColumns();





        }

        private void FrmEditResult_Load(object sender, EventArgs e)
        {
            //GridLookUpEdites.Formats(RGEresultType, QCInfoData.DTCriteriaType);
            //GridLookUpEdites.Formats(RGEresultRule,QCInfoData.DTRuleQC);
            GridLookUpEdites.Formats(RGEitemNO, WorkCommData.DTItemTest);
            RepositoryItemGridLookUpEdit RGEQCLevel = new RepositoryItemGridLookUpEdit();
            GridLookUpEdites.Formats(RGEQCLevel, QCInfoData.DTQCLevel);
            //RGEQCLevel.DataSource = QCInfoData.DTQCLevel;
            //RGEQCLevel.DisplayMember = "names";
            //RGEQCLevel.ValueMember = "no";

            RGEgradeid.View.Columns.AddRange(new GridColumn[] {
                new GridColumn {FieldName = "id",MaxWidth=100,Caption="编号",Visible=false },
                new GridColumn {FieldName = "gradeid",MaxWidth=100,Caption="质控编号",Visible=true },
                new GridColumn {FieldName = "gradeCode",MinWidth=150,Caption="质控品号",Visible=true  },
                new GridColumn {FieldName = "gradeName",MinWidth=50,Caption = "质控名称",Visible=true  },
                new GridColumn {FieldName = "levelNO",MinWidth=50,Caption = "水平类型",Visible=true,ColumnEdit = RGEQCLevel},
                new GridColumn {FieldName = "producer",MinWidth=50,Caption = "生产商",Visible=true  },
                new GridColumn {FieldName = "排序",MinWidth=50,Caption = "排序",Visible=true  }});




            RGEgradeid.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            RGEgradeid.View.BestFitColumns();

            RGEgradeid.NullText = "";
            RGEgradeid.DisplayMember = "gradeName";
            RGEgradeid.ValueMember = "id";

        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = gridView1.GetFocusedDataRow();
            if (dataRow != null)
            {
                int id = Convert.ToInt32(dataRow["id"]);
                DialogResult dialogResult = MessageBox.Show("是否确定删除记录？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    hideInfo dInfo = new hideInfo();
                    dInfo.TableName = "QC.QCItemResult";
                    dInfo.DataValueID = id;
                    ApiHelpers.postInfo(dInfo);
                }
            }

        }

        private void BTClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
