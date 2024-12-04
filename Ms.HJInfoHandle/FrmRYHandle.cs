using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Data;
using System.Windows.Forms;

namespace Ms.HJInfoHandle
{
    public partial class FrmRYHandle : XtraForm
    {
        string itemcode = "";
        string sampleCode = "";
        /// <summary>
        /// 编辑混检管中的人员信息
        /// </summary>
        /// <param name="barcodes"></param>
        /// <param name="a">0 允许编辑，1禁止编辑</param>
        public FrmRYHandle(string barcodes, int a = 0)
        {
            InitializeComponent();
            sampleCode = barcodes;
            if (a != 0)
            {
                BTAdd.Enabled = false;
                BTDelete.Enabled = false;
                BTSave.Enabled = false;
            }
        }
        private void FrmRYHandle_Load(object sender, EventArgs e)
        {
            GridControls.showEmbeddedNavigator(GCInfo);
            GridControls.formartGridView(GVInfo);
            if(sampleCode != "")
            {
                sInfo uInfo = new sInfo();
                uInfo.TableName = "WorkPer.SampleBlendInfo";
                uInfo.wheres = $"barcode='{sampleCode}' and dstate=0";
                DataTable a = ApiHelpers.postInfo(uInfo);
                GCInfo.DataSource = a;
                GVInfo.BestFitColumns();
            }

        }
        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVInfo.AddNewRow();
        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVInfo.GetFocusedDataRow();
            if(dataRow!=null)
            {
                string blendid = dataRow["blendid"] != DBNull.Value ? dataRow["blendid"].ToString() : "";
                if(blendid!="")
                {
                    uInfo uInfo = new uInfo();
                    uInfo.TableName = "WorkPer.SampleBlendInfo";
                    uInfo.value = "dstate=1";
                    uInfo.wheres = $"blendid={blendid}";
                    int a= ApiHelpers.postInfo(uInfo);
                    if(a==1)
                    {
                        GVInfo.DeleteRow(GVInfo.FocusedRowHandle);
                    }
                }
                else
                {
                    GVInfo.DeleteRow(GVInfo.FocusedRowHandle);
                }
            }
            else
            {
                MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVInfo.FocusedRowHandle = -1;
            DataTable dataTable = GCInfo.DataSource as DataTable;
            //ApiHelpers.postInfo(dataTable, "WorkPer.SampleBlendInfo");
            ApiHelpers.postInfo(dataTable, "WorkPer.SampleBlendInfo");
            FrmRYHandle_Load(null, null);
        }

        private void GVInfo_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ColumnView View = sender as ColumnView;
            GVInfo.SetRowCellValue(e.RowHandle, "barcode", GVInfo.GetRowCellValue(GVInfo.RowCount - 2, "barcode"));
            GVInfo.SetRowCellValue(e.RowHandle, "id", GVInfo.GetRowCellValue(GVInfo.RowCount - 2, "id"));
            GVInfo.SetRowCellValue(e.RowHandle, "dstate", "false");
            GVInfo.SetRowCellValue(e.RowHandle, "creater", CommonData.UserInfo.names);
            GVInfo.SetRowCellValue(e.RowHandle, "createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
