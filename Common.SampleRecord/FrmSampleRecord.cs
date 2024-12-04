using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.LoadShow;
using Common.PerModel;
using Common.SqlModel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using System;
using System.Data;
using System.Windows.Forms;

namespace Common.SampleRecord
{
    public partial class FrmSampleRecord : DevExpress.XtraEditors.XtraForm
    {
        string EntryTableName = "WorkPer.SampleInfo";
        public FrmSampleRecord(DataRow barcode)
        {
            InitializeComponent();

            ReadSampleInfo(barcode);
            foreach (var control in layoutControl1.Items)
            {
                PairsInfoModel pairsOther = new PairsInfoModel();
                if (control is LayoutControlItem)
                {
                    LayoutControlItem tmp = control as LayoutControlItem;
                    //var first = tmp.Text;//ID,Name,Age,Adress
                    //controlname = tmp.Text.Trim();//ID,Name,Age,Adress
                    if (tmp.Control is DevExpress.XtraEditors.TextEdit)
                    {
                        var aaaa = tmp.Control as DevExpress.XtraEditors.TextEdit;
                        aaaa.ReadOnly = true;
                    }
                }
            }
        }

        private void FrmPerworkInfoCheck_Load(object sender, EventArgs e)
        {
            GridLookUpEdites.Formats(GEagentNo);
            GridLookUpEdites.Formats(GEhospitalNo);
            GridLookUpEdites.Formats(GEpatientSexNO);
            GridLookUpEdites.Formats(GEpatientTypeNO);
            GridLookUpEdites.Formats(GEsampleShapeNO);
            GridLookUpEdites.Formats(GEsampleTypeNO);
            //GridControls.formartGridView(GVItemInfo);
            //GridControls.showEmbeddedNavigator(GCItemInfo);

            GridControls.formartGridView(GVrecord, false);
            GridControls.ShowViewColor(GVrecord);
            GEagentNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientAgent);


            ///RGEhospitalNo.DataSource=GEhospitalNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            ///RGEpatientSexNO.DataSource=GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEhospitalNo.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            GEpatientSexNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSex);
            GEpatientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypePatient);
            GEsampleShapeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeShape);
            GEsampleTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);

        }

        private void ReadSampleInfo(DataRow SampleInfoRow)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载标本信息......");
            try
            {

                if (SampleInfoRow["barcode"] != DBNull.Value)
                {
                    string Barcode = SampleInfoRow["barcode"].ToString();
                    //PathologyNo = SampleInfoRow["pathologyNo"].ToString();
                    //groupNO = SampleInfoRow["groupNO"].ToString();
                    DEreceiveTime.EditValue = SampleInfoRow["receiveTime"];
                    DEsampleTime.EditValue = SampleInfoRow["sampleTime"];
                    TEageDay.EditValue = SampleInfoRow["ageDay"];
                    TEageMoth.EditValue = SampleInfoRow["ageMoth"];
                    TEageYear.EditValue = SampleInfoRow["ageYear"];
                    TEpatientName.EditValue = SampleInfoRow["patientName"];
                    TEpatientName.EditValue = SampleInfoRow["patientName"];
                    GEagentNo.EditValue = SampleInfoRow["agentNo"];
                    TEhospitalBarcode.EditValue = SampleInfoRow["hospitalBarcode"];
                    //TEapplyItemCodes.EditValue = SampleInfoRow["applyItemCodes"];
                    //TEapplyItemNames.EditValue = SampleInfoRow["applyItemNames"];
                    TEbarcode.EditValue = SampleInfoRow["barcode"];
                    TEbedNo.EditValue = SampleInfoRow["bedNo"];
                    TEclinicalDiagnosis.EditValue = SampleInfoRow["clinicalDiagnosis"];
                    TEsampleLocation.EditValue = SampleInfoRow["sampleLocation"];
                    TEcutPart.EditValue = SampleInfoRow["cutPart"];
                    TEdepartment.EditValue = SampleInfoRow["department"];
                    TEdoctorPhone.EditValue = SampleInfoRow["doctorPhone"];
                    GEhospitalNo.EditValue = SampleInfoRow["hospitalNo"];
                    TEmedicalNo.EditValue = SampleInfoRow["medicalNo"];
                    DEmenstrualTime.EditValue = SampleInfoRow["menstrualTime"];
                    TEpathologyNo.EditValue = SampleInfoRow["pathologyNo"];
                    TEpatientCardNo.EditValue = SampleInfoRow["patientCardNo"];
                    TEpatientPhone.EditValue = SampleInfoRow["patientPhone"];
                    GEpatientSexNO.EditValue = SampleInfoRow["patientSexNO"];
                    GEpatientTypeNO.EditValue = SampleInfoRow["patientTypeNO"];
                    TEperRemark.EditValue = SampleInfoRow["perRemark"];
                    GEsampleShapeNO.EditValue = SampleInfoRow["sampleShapeNO"];
                    GEsampleTypeNO.EditValue = SampleInfoRow["sampleTypeNO"];
                    TEsendDoctor.EditValue = SampleInfoRow["sendDoctor"];
                    TEpatientAddress.EditValue = SampleInfoRow["patientAddress"];
                    TEpassportNo.EditValue = SampleInfoRow["passportNo"];
                                        CEurgent.Checked = SampleInfoRow["urgent"]!=DBNull.Value? Convert.ToBoolean(SampleInfoRow["urgent"]):false;

                    sInfo selectInfor = new sInfo();
                    selectInfor.TableName = "WorkComm.SampleRecord";
                    selectInfor.UserName = CommonData.UserInfo.names;
                    
                    selectInfor.MessageShow = 1;
                    string whereValue2 = $"barcode='{Barcode}'";
                    selectInfor.wheres = whereValue2;
                    DataTable datar = ApiHelpers.postInfo(selectInfor);
                    GCrecord.DataSource = datar;
                    GVrecord.BestFitColumns();

                    frmWait.HideMe(this);

                }
                else
                {
                    frmWait.HideMe(this);
                    MessageBox.Show("未找到该条码的记录信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                frmWait.HideMe(this);
                MessageBox.Show(ex.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
    }
}
