using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ms.BlendInfo
{
    public partial class FrmBlendInfo : XtraForm
    {
        public FrmBlendInfo()
        {
            InitializeComponent();
        }
        private void FrmBlendInfo_Load(object sender, EventArgs e)
        {
            DEStartTime.EditValue = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
            DEEndTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);
            GridLookUpEdites.Formats(RGEtestStateNO, WorkCommData.DTStateTest);
            GridControls.ShowViewColor(GVInfo);

        }
        private void BTSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkPer.SampleBlendInfo";
            sInfo.wheres = "dstate=0";
            if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString().Trim() != "")
                sInfo.wheres += $" and barcode like '%{TEbarcode.EditValue.ToString().Trim()}%'";
            if (TEpatientName.EditValue != null && TEpatientName.EditValue.ToString().Trim() != "")
                sInfo.wheres += $" and patientName like '%{TEpatientName.EditValue.ToString().Trim()}%'";
            if (TEpatientPhone.EditValue != null && TEpatientPhone.EditValue.ToString().Trim() != "")
                sInfo.wheres += $" and patientPhone like '%{TEpatientPhone.EditValue.ToString().Trim()}%'";
            if (TEpatientCardNo.EditValue != null && TEpatientCardNo.EditValue.ToString().Trim() != "")
                sInfo.wheres += $" and patientCardNo like '%{TEpatientCardNo.EditValue.ToString().Trim()}%'";
            if (TEpassportNo.EditValue != null && TEpassportNo.EditValue.ToString().Trim() != "")
                sInfo.wheres += $" and passportNo like '%{TEpassportNo.EditValue.ToString().Trim()}%'";
            if(sInfo.wheres == "dstate=0")
                sInfo.wheres += $" and createTime>='{Convert.ToDateTime(DEStartTime.EditValue).ToString("yyyy-MM-dd")}' and createTime<='{Convert.ToDateTime(DEEndTime.EditValue).AddDays(+1).ToString("yyyy-MM-dd")}'";
            GCInfo.DataSource= ApiHelpers.postInfo(sInfo);
            GVInfo.BestFitColumns();
        }


    }
}
