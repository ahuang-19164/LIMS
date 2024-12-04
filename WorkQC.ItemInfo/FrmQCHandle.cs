using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;

namespace WorkQC.ItemInfo
{
    public partial class FrmQCHandle : XtraForm
    {
        public FrmQCHandle(string planItemid, string qcTime, string itemResultsort)
        {
            InitializeComponent();


            GridControls.formartGridView(gridView1, false);
            GridControls.showEmbeddedNavigator(gridControl1);

            GridControls.ShowViewColor(gridView1);

            GridControls.formartGridView(GVHandle, false);
            GridControls.showEmbeddedNavigator(GCHandle);




            sInfo sInfo = new sInfo();
            sInfo.TableName = "QC.QCItemResult";
            sInfo.wheres = $"planItemid='{planItemid}' and qcTime='{qcTime}' and sort='{itemResultsort}' and resultType='失控' and dstate=0";
            //sInfo.OrderColumns = "";
            gridControl1.DataSource = ApiHelpers.postInfo(sInfo);
            gridView1.BestFitColumns();




            sInfo sInfo2 = new sInfo();
            sInfo2.TableName = "QC.QCPlanGrade";
            sInfo2.wheres = $"planItemid='{planItemid}' and dstate=0";
            RGEgradeid.DataSource = ApiHelpers.postInfo(sInfo2);


            sInfo sInfo3 = new sInfo();
            sInfo3.TableName = "QC.HandleRecord";
            sInfo3.wheres = $"planItemid='{planItemid}' and qcTime='{qcTime}' and dstate=0";
            //sInfo.OrderColumns = "";
            GCHandle.DataSource = ApiHelpers.postInfo(sInfo3);
            GVHandle.BestFitColumns();
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
            RGEgradeid.DisplayMember = "gradeCode";
            RGEgradeid.ValueMember = "id";

        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = gridView1.GetFocusedDataRow();
            if (dataRow != null)
            {
                FrmQCHandleInfo frmQCHandleInfo = new FrmQCHandleInfo(dataRow);
                frmQCHandleInfo.ShowDialog();
            }

        }

        private void BTClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
