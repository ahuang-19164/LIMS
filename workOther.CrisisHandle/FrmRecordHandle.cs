using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;

using Common.SqlModel;
using Common.TestModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace workOther.CrisisHandle
{
    public partial class FrmRecordHandle : XtraForm
    {
        int infoID = 0;
        int testid = 0;

        int perid = 0;
        //int sampleInfoID = 0;



        string barcode = "";
#pragma warning disable CS0414 // 字段“FrmRecordHandle.groupCodes”已被赋值，但从未使用过它的值
        string groupCodes = "";
#pragma warning restore CS0414 // 字段“FrmRecordHandle.groupCodes”已被赋值，但从未使用过它的值
        //string groupNames = "";


        string CrisisHandle = "";
        public FrmRecordHandle(DataRow sampleInfo, string recordTypeNO = "")
        {
            CrisisHandle = ConfigInfos.ReadConfigInfo("CrisisHandle");
            InitializeComponent();
            //submitItemCodes = "";
            try
            {
                if (sampleInfo != null)
                {


                    infoID = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;

                    perid = sampleInfo["perid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["perid"]) : 0;

                    //sampleInfoID = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;
                    testid = sampleInfo["testid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["testid"]) : 0;


                    barcode = sampleInfo["barcode"] != DBNull.Value ? sampleInfo["barcode"].ToString() : "";

                    TEBarcode.EditValue = barcode;


                    TEhosiptalNo.EditValue = sampleInfo["hospitalNO"];
                    TEhosName.EditValue = sampleInfo["hospitalNames"];
                    TEpatientName.EditValue = sampleInfo["patientName"];
                    TEsexName.EditValue = sampleInfo["patientSexNames"];
                    TEageYear.EditValue = sampleInfo["ageYear"];
                    GEtestStateNO.EditValue = sampleInfo["testStateNO"];
                    DEsampleTime.EditValue = sampleInfo["sampleTime"];
                    DEsendTime.EditValue = sampleInfo["receiveTime"];
                    TEcreater.EditValue = sampleInfo["creater"];
                    //DEcreateTime.EditValue= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    DEcreateTime.EditValue = sampleInfo["createTime"]; ;
                    //groupCodes = sampleInfo["submitItemCodes"] != DBNull.Value ? sampleInfo["submitItemCodes"].ToString() : "";

                    GEgroupNO.EditValue = sampleInfo["groupNO"];



                    //TEhandleResult.EditValue =sampleInfo["handleResult"];
                    TEremark.EditValue = sampleInfo["remark"];

                    //TEhandler.EditValue= sampleInfo["handler"];
                    //DEhandleTime.EditValue= sampleInfo["handleTime"];


                    TEcreater.EditValue = sampleInfo["creater"];
                    DEcreateTime.EditValue = sampleInfo["createTime"];
                    TEhandler.EditValue = sampleInfo["handler"];
                    TEhandleTime.EditValue = sampleInfo["handleTime"];



                    TEcontact.EditValue = sampleInfo["contact"];
                    TEcontactMode.EditValue = sampleInfo["contactMode"];

                    TEhandleResult.EditValue = sampleInfo["handleResult"];

                    CEstate.Checked = sampleInfo["state"] != DBNull.Value ? Convert.ToBoolean(sampleInfo["state"]) : false;
                    sInfo sInfo = new sInfo();
                    sInfo.TableName = "WorkOther.CrisisRecord";
                    sInfo.wheres = $"perid='{perid}' and testid='{testid}' and crisisItemCodes='{sampleInfo["crisisItemCodes"]}' and dstate=0";
                    GCTestInfo.DataSource = ApiHelpers.postInfo(sInfo);
                }

            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {

            }

        }
        private void FrmTestHandle_Load(object sender, EventArgs e)
        {

            //GridLookUpEdites.Formats(GEDelegateClient);
            GridLookUpEdites.Formats(GEtestStateNO);
            //GridLookUpEdites.Formats(GEhandleTypeNO);
            //GridLookUpEdites.Formats(GErecordTypeNO);
            //GEhandleTypeNO.Properties.DataSource =DTHelper.DTEnable(OtherInfoData.DTHandleState);
            //GErecordTypeNO.Properties.DataSource= OtherInfoData.DTServeState;
            //GEDelegateClient.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientDelegateInfo);




            GridLookUpEdites.Formats(RGEsampleTypeNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(GEgroupNO);

            RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            GEtestStateNO.Properties.DataSource = WorkCommData.DTStateTest;
            GEgroupNO.Properties.DataSource = WorkCommData.DTGroupTest;
            //getPrintInfo();
        }


        //private void BTSelect_Click(object sender, EventArgs e)
        //{
        //    sInfo sInfo = new sInfo();
        //    sInfo.TableName = "WorkOther.SubmitInfoView";
        //    string where = "dstate=0";
        //    if()
        //    where+=" and "
        //}

        ReturnInfo rInfo;
        private void BTsave_Click(object sender, EventArgs e)
        {

            try
            {

                if (TEhandleResult.EditValue != null && TEhandleResult.EditValue.ToString().Trim().Length >= 4)
                {

                    commInfoModel<TesthandleModel> commInfo = new commInfoModel<TesthandleModel>();



                    //commInfo.state = subState;
                    commInfo.UserName = CommonData.UserInfo.names;
                    
                    List<TesthandleModel> testInfos = new List<TesthandleModel>();
                    TesthandleModel testInfohandle = new TesthandleModel();
                    testInfohandle.id = infoID;
                    testInfohandle.perid = perid;
                    testInfohandle.testid = testid;
                    testInfohandle.barcode = barcode;
                    testInfohandle.state = CEstate.Checked;
                    testInfohandle.contact = TEcontact.EditValue != null ? TEcontact.EditValue.ToString() : "";
                    testInfohandle.contactMode = TEcontactMode.EditValue != null ? TEcontactMode.EditValue.ToString() : "";


                    testInfohandle.handleResult = TEhandleResult.EditValue.ToString();
                    testInfohandle.remark = TEremark.EditValue != null ? TEremark.EditValue.ToString() : "";
                    testInfohandle.handler = CommonData.UserInfo.names;
                    //testInfohandle.handleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    testInfos.Add(testInfohandle);
                    commInfo.infos = testInfos;

                    string Sr = JsonHelper.SerializeObjct(commInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(CrisisHandle, Sr);
                    commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                    rInfo = new ReturnInfo();
                    if (commReInfo!=null)
                    {
                        foreach (commReSampleInfo commReSample in commReInfo.infos)
                        {
                            if (commReSample != null)
                            {
                                if (commReSample.handleState == 1)
                                {
                                    //rInfo.testStateNO = commReSample.testState;
                                    rInfo.contact = TEcontact.EditValue;
                                    rInfo.contactMode = TEcontactMode.EditValue;
                                    rInfo.handleResult = TEhandleResult.EditValue;
                                    rInfo.handler = CommonData.UserInfo.names;
                                    rInfo.state = CEstate.Checked;
                                    rInfo.handleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    rInfo.remark = TEremark.EditValue != null ? TEremark.EditValue.ToString() : "";
                                    //rInfo.msg = commReSample.msg;
                                }
                                else
                                {
                                    rInfo.handleTypeNO = 0;
                                    MessageBox.Show(commReSample.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        this.Close();
                    }
                    else
                    {
                        rInfo.handleTypeNO = 0;
                        MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("请填写处理记录,至少4个字！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ReturnInfo reinfo()
        {
            return rInfo;
        }
    }
}
