using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace workOther.ItemDelegate
{
    public partial class FrmDelegateTest : XtraForm
    {
        int sampleInfoID = 0;
        public FrmDelegateTest(DataRow sampleInfo)
        {
            InitializeComponent();
            //GEDelegateType.EditValue = 1;

            if (sampleInfo != null)
            {
                TEbarcode.ReadOnly = true;
                TEhosBarcode.ReadOnly = true;
                BTSelect.Enabled = false;
                sampleInfoID = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;
                TEbarcode.EditValue = sampleInfo["barcode"];
                TEhosBarcode.EditValue = sampleInfo["hospitalBarcode"];
                TEhosiptalNo.EditValue = sampleInfo["hospitalNO"];
                TEhosName.EditValue = sampleInfo["hospitalNames"];
                TEpatientName.EditValue = sampleInfo["patientName"];
                TEsexName.EditValue = sampleInfo["patientSexNames"];
                TEageYear.EditValue = sampleInfo["ageYear"];
                GEgroupNO.EditValue = sampleInfo["groupNO"];
                DEsampleTime.EditValue = sampleInfo["sampleTime"];
                DEsendTime.EditValue = sampleInfo["receiveTime"];
                //TEcreater.EditValue= CommonData.UserInfo.names;
                //DEcreateTime.EditValue= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string groupCodes = sampleInfo["groupCodes"] != DBNull.Value ? sampleInfo["groupCodes"].ToString() : "";
                DataTable groupInfo = WorkCommData.DTItemGroup.Select($"no in ({groupCodes})").CopyToDataTable();
                string itemcodes = "";
                foreach (DataRow dataRow in groupInfo.Rows)
                {
                    string groupItems = dataRow["testItemList"] != DBNull.Value ? dataRow["testItemList"].ToString() : "";
                    itemcodes += groupItems;
                }
                DataTable ItemInfo = WorkCommData.DTItemTest.Select($"no in ({itemcodes})").CopyToDataTable();
                ItemInfo.Columns.Add("check", typeof(bool));
                GCTestInfo.DataSource = ItemInfo;

            }
            //else
            //{

            //}

        }
        private void FrmDelegateTest_Load(object sender, EventArgs e)
        {

            GridLookUpEdites.Formats(GEgroupNO);
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
            GEgroupNO.Properties.DataSource = RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
        }
        private void BTSelect_Click(object sender, EventArgs e)
        {

        }

        private void BTprint_Click(object sender, EventArgs e)
        {

        }

        private void BTsave_Click(object sender, EventArgs e)
        {
            if (TEreason.EditValue != null)
            {
                if (TEreason.EditValue.ToString().Trim().Length > 4)
                {


                    string itemCodes = "";
                    string itemNames = "";
                    for (int a = 0; a < GVTestInfo.RowCount; a++)
                    {
                        if (GVTestInfo.GetRowCellValue(a, "check") != DBNull.Value)
                        {
                            if (Convert.ToBoolean(GVTestInfo.GetRowCellValue(a, "check")))
                            {
                                string itemcode = GVTestInfo.GetRowCellValue(a, "no") != DBNull.Value ? GVTestInfo.GetRowCellValue(a, "no").ToString() : "";
                                itemCodes += itemcode + ",";
                                string itemName = GVTestInfo.GetRowCellValue(a, "names") != DBNull.Value ? GVTestInfo.GetRowCellValue(a, "names").ToString() : "";
                                itemNames += itemName + ",";
                            }
                        }

                    }


                    if (itemCodes != "" && itemNames != "")
                    {
                        itemCodes = itemCodes.Substring(0, itemCodes.Length - 1);
                        itemNames = itemNames.Substring(0, itemNames.Length - 1);
                        uInfo uInfo = new uInfo();
                        uInfo.TableName = "WorkTest.SampleInfo";
                        uInfo.value = "delegateState=1";
                        uInfo.DataValueID = sampleInfoID;
                        uInfo.MessageShow = 1;
                        int s = ApiHelpers.postInfo(uInfo);
                        if (s > 0)
                        {
                            iInfo iInfo = new iInfo();
                            iInfo.TableName = "WorkOther.DelegeteRecord";
                            Dictionary<string, object> pairs = new Dictionary<string, object>();
                            pairs.Add("dstate", 0);
                            pairs.Add("state", 1);
                            pairs.Add("testID", sampleInfoID);
                            pairs.Add("creater", CommonData.UserInfo.names);
                            pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            pairs.Add("barcode", TEbarcode.EditValue);
                            pairs.Add("delegateStateNO", 1);
                            pairs.Add("itemCodes", itemCodes);
                            pairs.Add("itemNames", itemNames);
                            pairs.Add("reason", TEreason.EditValue);
                            iInfo.values = pairs;
                            iInfo.MessageShow = 1;
                            s = ApiHelpers.postInfo(iInfo);
                            if (s > 0)
                            {
                                SaveState = "0";
                                this.Close();
                            }
                        }


                    }
                    else
                    {
                        SaveState = "0";
                        MessageBox.Show("未获取到需要委托的项目！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SaveState = "0";
                    MessageBox.Show("请填写委托原因,至少4个字！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SaveState = "0";
                MessageBox.Show("请填写委托原因,至少4个字！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
