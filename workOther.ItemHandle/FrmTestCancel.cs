using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace workOther.ItemHandle
{
    public partial class FrmTestCancel : XtraForm
    {
        string FrmState = "";
        int testid = 0;
        int perid = 0;
        int infoID = 0;
#pragma warning disable CS0414 // 字段“FrmTestCancel.groupCodes”已被赋值，但从未使用过它的值
        string groupCodes = "";
#pragma warning restore CS0414 // 字段“FrmTestCancel.groupCodes”已被赋值，但从未使用过它的值
        ////string groupNames = "";
        string CheckGroupCodes = "";
        string CheckGroupNames = "";
        /// <summary>
        /// 提交增项申请
        /// </summary>
        /// <param name="sampleInfo">DR样本信息</param>
        /// <param name="recordTypeNO">1新增2编辑</param>
        public FrmTestCancel(DataRow sampleInfo, string recordTypeNO = "")
        {

            FrmState = recordTypeNO;
            InitializeComponent();
            //GEDelegateType.EditValue = 1;
            if (sampleInfo == null)
            {
                TEbarcode.ReadOnly = false;
                GErecordTypeNO.ReadOnly = false;


            }
            else
            {
                TEbarcode.ReadOnly = true;
                GErecordTypeNO.ReadOnly = true;
                //GErecordTypeNO.EditValue = recordTypeNO;
            }
            GErecordTypeNO.EditValue = "5";
            Start(sampleInfo, recordTypeNO);

        }
        private void FrmDelegateTest_Load(object sender, EventArgs e)
        {

            GridLookUpEdites.Formats(GEperStateNO);
            //GridLookUpEdites.Formats(GEDelegateType);
            //GridLookUpEdites.Formats(GEDelegateClient);
            //GEDelegateType.Properties.DataSource = OtherInfoData.DTDelegateState;
            //GEDelegateClient.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientDelegateInfo);

            GridLookUpEdites.Formats(GErecordTypeNO);
            GErecordTypeNO.Properties.DataSource = OtherInfoData.DTSubmitState;


            GridLookUpEdites.Formats(RGEsampleTypeNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(RGEgroupNO);

            RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            GEperStateNO.Properties.DataSource = WorkCommData.DTStatePerWork;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;


            TEreason.Focus();
        }


        private void Start(DataRow sampleInfo, string recordTypeNO = "")
        {
            //FrmDT = WorkCommData.DTItemGroup.Clone();
            try
            {
                if (sampleInfo != null)
                {
                    //TEbarcode.ReadOnly = true;
                    //TEhosBarcode.ReadOnly = true;
                    //BTSelect.Enabled = false;
                    //perid = sampleInfo["perid"] !=DBNull.Value? Convert.ToInt32(sampleInfo["perid"]):0;
                    if (FrmState == "2")
                        infoID = sampleInfo["subid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["subid"]) : 0;
                    testid = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;
                    perid = sampleInfo["perid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["perid"]) : 0;

                    TEbarcode.EditValue = sampleInfo["barcode"];
                    //TEhosBarcode.EditValue= sampleInfo["hospitalBarcode"];
                    TEhosiptalNo.EditValue = sampleInfo["hospitalNO"];
                    TEhosName.EditValue = sampleInfo["hospitalNames"];
                    TEpatientName.EditValue = sampleInfo["patientName"];
                    TEsexName.EditValue = sampleInfo["patientSexNames"];
                    TEageYear.EditValue = sampleInfo["ageYear"];
                    //GEperStateNO.EditValue = sampleInfo["perStateNO"];
                    DEsampleTime.EditValue = sampleInfo["sampleTime"];
                    DEsendTime.EditValue = sampleInfo["receiveTime"];

                    //TEcreater.EditValue= CommonData.UserInfo.names;
                    //DEcreateTime.EditValue= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string groupCodes = sampleInfo["groupCodes"] != DBNull.Value ? sampleInfo["groupCodes"].ToString() : "";

                    //sInfo sInfo = new sInfo();
                    //sInfo.values = " groupCodes";
                    //sInfo.TableName = "WorkTest.SampleInfo";
                    //sInfo.wheres = $"id='{testid}' and dstate=0";
                    //DataTable groupItemInfos = ApiHelpers.postInfo(sInfo);

                    if (groupCodes != "")
                    {

                        DataTable groupInfo = WorkCommData.DTItemGroup.Select($"no in ({groupCodes})").CopyToDataTable();
                        groupInfo.Columns.Add("check", typeof(bool));
                        GCTestInfo.DataSource = groupInfo;
                        GVTestInfo.BestFitColumns();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统错误:" + ex.ToString(), "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }
        private void BTSelect_Click(object sender, EventArgs e)
        {
            if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString() != "")
            {
                sInfo sInfo = new sInfo();
                sInfo.TableName = "WorkPer.SampleInfo";
                sInfo.wheres = $" barcode='{TEbarcode.EditValue}'";
                DataTable dataTable = ApiHelpers.postInfo(sInfo);
                if (dataTable != null)
                {
                    Start(dataTable.Rows[0], "3");
                }
                else
                {
                    MessageBox.Show("没有查询到条码信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("没有查询到条码信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            if (testid != 0)
            {
                if (GErecordTypeNO.EditValue != null)
                {
                    if (TEreason.EditValue != null)
                    {
                        if (TEreason.EditValue.ToString().Trim().Length >= 4)
                        {


                            CheckGroupCodes = "";
                            CheckGroupNames = "";
                            for (int a = 0; a < GVTestInfo.RowCount; a++)
                            {
                                if (GVTestInfo.GetRowCellValue(a, "check") != DBNull.Value)
                                {
                                    if (Convert.ToBoolean(GVTestInfo.GetRowCellValue(a, "check")))
                                    {
                                        string itemcode = GVTestInfo.GetRowCellValue(a, "no") != DBNull.Value ? GVTestInfo.GetRowCellValue(a, "no").ToString() : "";
                                        CheckGroupCodes += itemcode + ",";
                                        string itemName = GVTestInfo.GetRowCellValue(a, "names") != DBNull.Value ? GVTestInfo.GetRowCellValue(a, "names").ToString() : "";
                                        CheckGroupNames += itemName + ",";
                                    }
                                }
                            }
                            if (CheckGroupCodes != "")
                            {
                                CheckGroupCodes = CheckGroupCodes.Length > 0 ? CheckGroupCodes.Substring(0, CheckGroupCodes.Length - 1) : "";
                                CheckGroupNames = CheckGroupNames.Length > 0 ? CheckGroupNames.Substring(0, CheckGroupNames.Length - 1) : "";

                                if (FrmState == "1")
                                {
                                    iInfo iInfo = new iInfo();
                                    iInfo.TableName = "WorkOther.SpecialRecord";
                                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                                    //pairs.Add("dstate", CEdstate.EditValue);
                                    //pairs.Add("state", CEstate.EditValue);
                                    //pairs.Add("handleTime", TEhandleTime.EditValue);
                                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    //pairs.Add("id", TEid.EditValue);
                                    //pairs.Add("contact", TEcontact.EditValue);
                                    pairs.Add("creater", CommonData.UserInfo.names);
                                    //pairs.Add("handler", TEhandler.EditValue);
                                    //pairs.Add("contact", TEcontact.EditValue);

                                    //pairs.Add("contactMode", TEcontactMode.EditValue);
                                    pairs.Add("submitItemCodes", CheckGroupCodes);
                                    pairs.Add("submitItemNames", CheckGroupNames);
                                    //pairs.Add("handleResult", TEhandleResult.EditValue);
                                    //pairs.Add("handleTypeNO", GEhandleTypeNO.EditValue);
                                    pairs.Add("perid", perid);
                                    //pairs.Add("pleasLevel", TEpleasLevel.EditValue);
                                    pairs.Add("recordTypeNO", GErecordTypeNO.EditValue);
                                    pairs.Add("recordValue", TEreason.EditValue);
                                    //pairs.Add("testid", sampleInfoID);
                                    pairs.Add("barcode", TEbarcode.EditValue);
                                    iInfo.values = pairs;
                                    iInfo.MessageShow = 1;
                                    int s = ApiHelpers.postInfo(iInfo);
                                    if (s == 1)
                                    {
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    uInfo iInfo = new uInfo();
                                    iInfo.TableName = "WorkOther.SpecialRecord";
                                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                                    //pairs.Add("dstate", CEdstate.EditValue);
                                    //pairs.Add("state", CEstate.EditValue);
                                    //pairs.Add("handleTime", TEhandleTime.EditValue);
                                    pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                    //pairs.Add("id", TEid.EditValue);
                                    //pairs.Add("contact", TEcontact.EditValue);
                                    pairs.Add("creater", CommonData.UserInfo.names);
                                    //pairs.Add("handler", TEhandler.EditValue);
                                    //pairs.Add("contact", TEcontact.EditValue);

                                    //pairs.Add("contactMode", TEcontactMode.EditValue);
                                    pairs.Add("submitItemCodes", CheckGroupCodes);
                                    pairs.Add("submitItemNames", CheckGroupNames);
                                    //pairs.Add("handleResult", TEhandleResult.EditValue);
                                    //pairs.Add("handleTypeNO", GEhandleTypeNO.EditValue);
                                    //pairs.Add("perid", perid);
                                    //pairs.Add("pleasLevel", TEpleasLevel.EditValue);
                                    pairs.Add("recordTypeNO", GErecordTypeNO.EditValue);
                                    pairs.Add("recordValue", TEreason.EditValue);
                                    //pairs.Add("testid", sampleInfoID);
                                    //pairs.Add("barcode", TEbarcode.EditValue);
                                    iInfo.values = pairs;
                                    iInfo.wheres = $"id={infoID}";
                                    iInfo.MessageShow = 1;
                                    int s = ApiHelpers.postInfo(iInfo);
                                    if (s == 1)
                                    {
                                        this.Close();
                                    }
                                }

                            }

                        }
                        else
                        {
                            SaveState = "0";
                            MessageBox.Show("请填写提交原因,至少4个字！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        SaveState = "0";
                        MessageBox.Show("请填写提交原因,至少4个字！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SaveState = "0";
                    MessageBox.Show("提交类型不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string SaveState = "0";
        /// <summary>
        /// 0失败，1成功
        /// </summary>
        /// <returns></returns>
        public string reSaveState()
        {
            return SaveState;
        }

    }
}
