using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Data;

namespace workOther.ItemDelegate
{
    public partial class FrmItemDelegateInfo : XtraForm
    {
        public FrmItemDelegateInfo()
        {
            InitializeComponent();
            DEstartTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            DEendTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GEDelegateStateNO.EditValue = 0;
            GridLookUpEdites.Formats(RGEDelegateStateNO);
            GridLookUpEdites.Formats(RGEdelegateStateNOs);
            GridLookUpEdites.Formats(RGEdelegateClientNO);
            GridLookUpEdites.Formats(RGEtestStateNO);
            GridLookUpEdites.Formats(RGEdelePersonNO);
            RGEdelePersonNO.DataSource = CommonData.DTUserInfoAll;
            RGEDelegateStateNO.DataSource = DTHelper.DTAddAll(OtherInfoData.DTDelegateState);
            RGEdelegateStateNOs.DataSource = OtherInfoData.DTDelegateState;
            RGEdelegateClientNO.DataSource = WorkCommData.DTClientDelegateInfo;
            RGEtestStateNO.DataSource = WorkCommData.DTStateTest;

            GridControls.formartGridView(GVdelegateInfo);
            GridControls.showEmbeddedNavigator(GCdelegateInfo);
            GridControls.ShowViewColor(GVdelegateInfo);
            SysPowerHelper.UserPower(barManager1);


        }



        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkOther.delegateInfoView";
            string wheres = $" createTime>='{DEstartTime.EditValue}' and createTime<='{Convert.ToDateTime(DEendTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}' ";
            if (Convert.ToInt32(GEDelegateStateNO.EditValue) != 0)
            {
                wheres += $"and delegateStateNO = '{GEDelegateStateNO.EditValue}' ";
            }
            if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString() != "")
            {
                wheres += $"and barcode like '%{TEbarcode.EditValue}%' ";
            }
            if (TEpatientName.EditValue != null && TEpatientName.EditValue.ToString() != "")
            {
                wheres += $"and patientName like '%{TEpatientName.EditValue}%' ";
            }
            sInfo.wheres = wheres;
            DataTable dataTable = ApiHelpers.postInfo(sInfo);
            GCdelegateInfo.DataSource = dataTable;
            GVdelegateInfo.BestFitColumns();
        }
        private void BTHandleInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GVdelegateInfo.GetFocusedDataRow() != null)
            {
                DataRow sampleInfo = GVdelegateInfo.GetFocusedDataRow();
                FrmDelegeteHandle frmDelegeteHandle = new FrmDelegeteHandle(sampleInfo);
                Func<deleInfo> func = frmDelegeteHandle.reinfo;
                frmDelegeteHandle.ShowDialog();
                deleInfo deleInfo = func();
                if (deleInfo != null)
                {

                    GVdelegateInfo.SetFocusedRowCellValue("checker", deleInfo.checker);
                    GVdelegateInfo.SetFocusedRowCellValue("checkTime", deleInfo.checkTime);
                    GVdelegateInfo.SetFocusedRowCellValue("record", deleInfo.record);
                    GVdelegateInfo.SetFocusedRowCellValue("remark", deleInfo.remark);
                    GVdelegateInfo.SetFocusedRowCellValue("delegateStateNO", deleInfo.stateNO);
                    GVdelegateInfo.SetFocusedRowCellValue("delePersonNO", deleInfo.delePerson);
                    if (deleInfo.testStateNO != null)
                        GVdelegateInfo.SetFocusedRowCellValue("testStateNO", deleInfo.testStateNO);
                    GVdelegateInfo.BestFitColumns();
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

        private void GCdelegateInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
