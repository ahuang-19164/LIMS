using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace workOther.ClientServiceInfo
{
    public partial class FrmRecordInfo : XtraForm
    {
        public FrmRecordInfo()
        {
            InitializeComponent();
            DEstartTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEendTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GEStateNO.EditValue = 0;
            GridLookUpEdites.Formats(RGEStateNO);
            GridLookUpEdites.Formats(RGEStateNOs);
            GridLookUpEdites.Formats(RGEdelegateClientNO);
            GridLookUpEdites.Formats(RGEtestStateNO);
            GridLookUpEdites.Formats(RGEhandleTypeNO);
            RGEhandleTypeNO.DataSource = OtherInfoData.DTHandleState;
            RGEStateNO.DataSource = DTHelper.DTAddAll(OtherInfoData.DTServeState);
            RGEStateNOs.DataSource = OtherInfoData.DTServeState;
            //RGEdelegateClientNO.DataSource = WorkCommData.DTClientDelegateInfo;
            RGEtestStateNO.DataSource = WorkCommData.DTStatePerWork;
            GridControls.formartGridView(GVdelegateInfo);
            GridControls.showEmbeddedNavigator(GCdelegateInfo);
            GridControls.ShowViewColor(GVdelegateInfo);

        }



        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkOther.ServeInfoView";
            string wheres = $" createTime>='{DEstartTime.EditValue}' and createTime<='{Convert.ToDateTime(DEendTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}'  and recordTypeNO not in ('3','4','5')";
            if (Convert.ToInt32(GEStateNO.EditValue) != 0)
            {
                wheres += $"and recordTypeNO = '{GEStateNO.EditValue}'";
            }
            if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString() != "")
            {
                wheres += $"and barcode like '%{TEbarcode.EditValue}%'";
            }
            if (TEpatientName.EditValue != null && TEpatientName.EditValue.ToString() != "")
            {
                wheres += $"and patientName like '%{TEpatientName.EditValue}%'";
            }
            sInfo.wheres = wheres;
            DataTable dataTable = ApiHelpers.postInfo(sInfo);
            GCdelegateInfo.DataSource = dataTable;
            GVdelegateInfo.BestFitColumns();
        }
        private void BTHandleInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BTHandleInfo.Enabled)
            {
                if (GVdelegateInfo.GetFocusedDataRow() != null)
                {
                    DataRow sampleInfo = GVdelegateInfo.GetFocusedDataRow();
                    //string recordTypeNO = sampleInfo["recordTypeNO"] != DBNull.Value ? sampleInfo["recordTypeNO"].ToString() : "";
                    //if(recordTypeNO=="1")
                    //{
                    FrmRecordHandle frmTestHandle = new FrmRecordHandle(sampleInfo);
                    Func<ReturnInfo> func = frmTestHandle.reinfo;
                    frmTestHandle.ShowDialog();
                    ReturnInfo deleInfo = func();
                    if (deleInfo != null)
                    {

                        GVdelegateInfo.SetFocusedRowCellValue("handler", deleInfo.handler);
                        GVdelegateInfo.SetFocusedRowCellValue("handleTime", deleInfo.handleTime);
                        GVdelegateInfo.SetFocusedRowCellValue("handleResult", deleInfo.handleResult);
                        GVdelegateInfo.SetFocusedRowCellValue("remark", deleInfo.remark);
                        GVdelegateInfo.SetFocusedRowCellValue("handleTypeNO", deleInfo.handleTypeNO);
                        sampleInfo["state"] = deleInfo.state;
                        if (deleInfo.testStateNO.ToString() != "0")
                        {
                            GVdelegateInfo.SetFocusedRowCellValue("testStateNO", deleInfo.testStateNO);

                        }
                        GVdelegateInfo.BestFitColumns();
                    }
                }
            }
        }


        private void GVdelegateInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void GVdelegateInfo_DoubleClick(object sender, EventArgs e)
        {
            BTHandleInfo_ItemClick(null, null);
        }


        private void BTImg_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DataRow dataRow = GVdelegateInfo.GetFocusedDataRow();
            if (dataRow != null)
            {

                string barcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                sInfo selectInfoImg = new sInfo();
                selectInfoImg.values = "top 1 *";
                selectInfoImg.TableName = "WorkPer.SampleImg";
                selectInfoImg.wheres = $"barcode='{barcode}' and dstate=0 and state=1";
                selectInfoImg.OrderColumns = "createTime desc";
                DataTable dataTableImg = ApiHelpers.postInfo(selectInfoImg);
                if (dataTableImg != null)
                {
                    if (dataTableImg.Rows[0]["filestring"] != DBNull.Value)
                    {
                        string SImgString = dataTableImg.Rows[0]["filestring"].ToString();
                        Bitmap CameraImage = FileConverHelpers.StringToBitmap(SImgString);
                        ShowImgHelper.ViewOrignalImage(CameraImage);
                    }
                }
                else
                {
                    MessageBox.Show("未找到匹配的原始单图片！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
