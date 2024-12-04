using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace workOther.SyntheticalInfo
{
    public partial class FrmTestOther : XtraForm
    {
        int perid = 0;
        int sampleInfoID = 0;
        string groupCodes = "";
        string groupNames = "";
        public FrmTestOther(DataRow sampleInfo, string recordTypeNO = "")
        {
            InitializeComponent();
            //GEDelegateType.EditValue = 1;

            if (sampleInfo != null)
            {


                TEbarcode.ReadOnly = true;
                //TEhosBarcode.ReadOnly = true;
                BTSelect.Enabled = false;
                perid = sampleInfo["perid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["perid"]) : 0;
                sampleInfoID = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;
                TEbarcode.EditValue = sampleInfo["barcode"];
                //TEhosBarcode.EditValue= sampleInfo["hospitalBarcode"];
                TEhosiptalNo.EditValue = sampleInfo["hospitalNO"];
                TEhosName.EditValue = sampleInfo["hospitalNames"];
                TEpatientName.EditValue = sampleInfo["patientName"];
                TEsexName.EditValue = sampleInfo["patientSexNames"];
                TEageYear.EditValue = sampleInfo["ageYear"];
                //GEperStateNO.EditValue= sampleInfo["perStateNO"];
                DEsampleTime.EditValue = sampleInfo["sampleTime"];
                DEsendTime.EditValue = sampleInfo["receiveTime"];
                //TEcreater.EditValue= CommonData.UserInfo.names;
                //DEcreateTime.EditValue= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                groupCodes = sampleInfo["groupCodes"] != DBNull.Value ? sampleInfo["groupCodes"].ToString() : "";
                groupNames = sampleInfo["groupNames"] != DBNull.Value ? sampleInfo["groupNames"].ToString() : "";
                DataTable groupInfo = WorkCommData.DTItemGroup.Select($"no in ({groupCodes})").CopyToDataTable();
                //string itemcodes = "";
                //foreach (DataRow dataRow in groupInfo.Rows)
                //{
                //    string groupItems = dataRow["testItemList"] != DBNull.Value ? dataRow["testItemList"].ToString() : "";
                //    itemcodes += groupItems;
                //}
                //DataTable ItemInfo = WorkCommData.DTItemTest.Select($"no in ({itemcodes})").CopyToDataTable();
                groupInfo.Columns.Add("check", typeof(bool));
                GCTestInfo.DataSource = groupInfo;

            }
            if (recordTypeNO != "")
            {
                GErecordTypeNO.ReadOnly = true;
                GErecordTypeNO.EditValue = recordTypeNO;
                GridLookUpEdites.Formats(GErecordTypeNO);
                GErecordTypeNO.Properties.DataSource = OtherInfoData.DTSubmitState;
            }


        }
        private void FrmDelegateTest_Load(object sender, EventArgs e)
        {

            GridLookUpEdites.Formats(GEperStateNO);
            //GridLookUpEdites.Formats(GEDelegateType);
            //GridLookUpEdites.Formats(GEDelegateClient);
            //GEDelegateType.Properties.DataSource = OtherInfoData.DTDelegateState;
            //GEDelegateClient.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientDelegateInfo);




            GridLookUpEdites.Formats(RGEsampleTypeNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(RGEgroupNO);

            RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            GEperStateNO.Properties.DataSource = RGEgroupNO.DataSource = WorkCommData.DTGroupTest;


            TEreason.Focus();
        }
        private void BTSelect_Click(object sender, EventArgs e)
        {

        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            if (perid != 0)
            {
                if (GErecordTypeNO.EditValue != null)
                {
                    if (TEreason.EditValue != null)
                    {
                        if (TEreason.EditValue.ToString().Trim().Length >= 4)
                        {


                            string CheckGroupCodes = "";
                            string CheckGroupNames = "";
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
                                pairs.Add("testid", sampleInfoID);
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
                                SaveState = "0";
                                MessageBox.Show("请选择提要处理的项目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
