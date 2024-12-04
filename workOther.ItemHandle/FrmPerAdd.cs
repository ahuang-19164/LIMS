using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace workOther.ItemHandle
{
    public partial class FrmPerAdd : XtraForm
    {
        string FrmState = "";
        int perid = 0;
        int infoID = 0;
        string groupCodes = "";
#pragma warning disable CS0414 // 字段“FrmPerAdd.groupNames”已被赋值，但从未使用过它的值
        string groupNames = "";
#pragma warning restore CS0414 // 字段“FrmPerAdd.groupNames”已被赋值，但从未使用过它的值
        /// <summary>
        /// 提交增项申请
        /// </summary>
        /// <param name="sampleInfo">DR样本信息</param>
        /// <param name="recordTypeNO">1新增2编辑</param>
        public FrmPerAdd(DataRow sampleInfo, string recordTypeNO = "")
        {
            FrmState = recordTypeNO;
            InitializeComponent();
            //GEDelegateType.EditValue = 1;
            FrmDT = WorkCommData.DTItemGroup.Clone();
            FrmDT.Columns.Add("check", typeof(bool));

            if (sampleInfo == null)
            {
                TEbarcode.ReadOnly = false;
                GErecordTypeNO.ReadOnly = false;


            }
            else
            {
                TEbarcode.ReadOnly = true;
                //GErecordTypeNO.ReadOnly = true;
                //GErecordTypeNO.EditValue = recordTypeNO;
            }
            GErecordTypeNO.EditValue = "4";
            Start(sampleInfo);





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
            GridLookUpEdites.Formats(RGEsampleTypeNOs);
            GridLookUpEdites.Formats(RGEinstrumentNOs);
            GridLookUpEdites.Formats(RGEmethodNOs);
            GridLookUpEdites.Formats(RGEgroupNOs);

            GridLookUpEdites.Formats(GErecordTypeNO);
            GErecordTypeNO.Properties.DataSource = OtherInfoData.DTSubmitState;

            RGEsampleTypeNOs.DataSource = RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEinstrumentNOs.DataSource = RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNOs.DataSource = RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            RGEgroupNOs.DataSource = RGEgroupNO.DataSource = WorkCommData.DTGroupTest;

            GEperStateNO.Properties.DataSource = WorkCommData.DTStatePerWork;
            GErecordTypeNO.EditValueChanged += GEperStateNO_EditValueChanged;
            TEreason.Focus();
        }

        private void GEperStateNO_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
                if (gridLookUpEdit.EditValue != null)
                {
                    DataRow dataRow = gridLookUpEdit.Properties.View.GetFocusedDataRow();
                    int colorback = dataRow["typeColor"] != DBNull.Value ? Convert.ToInt32(dataRow["typeColor"]) : 0;
                    gridLookUpEdit.BackColor = Color.FromArgb(colorback);
                }
            }
            catch
            {

            }
        }


        private void Start(DataRow sampleInfo)
        {

            try
            {



                if (sampleInfo != null)
                {


                    //TEbarcode.ReadOnly = true;
                    //TEhosBarcode.ReadOnly = true;
                    //BTSelect.Enabled = false;
                    //perid = sampleInfo["perid"] !=DBNull.Value? Convert.ToInt32(sampleInfo["perid"]):0;

                    perid = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;
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

                    sInfo sInfo = new sInfo();
                    sInfo.values = " groupCodes";
                    sInfo.TableName = "WorkTest.SampleInfo";
                    sInfo.wheres = $"perid='{perid}' and dstate=0";
                    DataTable groupItemInfos = ApiHelpers.postInfo(sInfo);




                    if (FrmState == "2")
                    {
                        TEreason.EditValue = sampleInfo["recordValue"];
                        infoID = sampleInfo["subid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["subid"]) : 0;
                        string subGroupCodes = sampleInfo["submitItemCodes"] != DBNull.Value ? sampleInfo["submitItemCodes"].ToString() : "";
                        if (subGroupCodes != "")
                        {
                            DataTable AddInfo = WorkCommData.DTItemGroup.Select($"no in ({subGroupCodes})").CopyToDataTable();
                            GCAddInfo.DataSource = AddInfo;
                            GVAddInfo.BestFitColumns();
                        }
                    }


                    if (groupItemInfos != null)
                    {
                        foreach (DataRow dataRow in groupItemInfos.Rows)
                        {
                            string groupItems = dataRow["groupCodes"] != DBNull.Value ? dataRow["groupCodes"].ToString() : "";
                            groupCodes += groupItems;
                        }
                        groupCodes = groupCodes.Length > 0 ? groupCodes.Substring(0, groupCodes.Length - 1) : "";
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
                    Start(dataTable.Rows[0]);
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
                            for (int a = 0; a < GVAddInfo.RowCount; a++)
                            {

                                string itemcode = GVAddInfo.GetRowCellValue(a, "no") != DBNull.Value ? GVAddInfo.GetRowCellValue(a, "no").ToString() : "";
                                CheckGroupCodes += itemcode + ",";
                                string itemName = GVAddInfo.GetRowCellValue(a, "names") != DBNull.Value ? GVAddInfo.GetRowCellValue(a, "names").ToString() : "";
                                CheckGroupNames += itemName + ",";

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
                                    uInfo uInfo = new uInfo();
                                    uInfo.TableName = "WorkOther.SpecialRecord";
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
                                    uInfo.values = pairs;
                                    uInfo.wheres = $"id={infoID}";
                                    uInfo.MessageShow = 1;
                                    int s = ApiHelpers.postInfo(uInfo);
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
        DataTable FrmDT;
        private void BTAddItem_Click(object sender, EventArgs e)
        {
            string aaaa = groupCodes;
            if (GVAddInfo.RowCount > 0)
            {
                for (int a = 0; a < GVAddInfo.RowCount; a++)
                {
                    aaaa += "," + GVAddInfo.GetRowCellValue(a, "no");
                }
            }
            FrmShowGroup frmShowGroup = new FrmShowGroup(aaaa);

            Func<List<DataRow>> Func = frmShowGroup.ReturnResult;
            frmShowGroup.ShowDialog();
            if (Func() != null)
            {
                foreach (DataRow row in Func())
                {
                    DataRow dataRow = FrmDT.NewRow();
                    dataRow.ItemArray = row.ItemArray;
                    FrmDT.Rows.Add(dataRow);
                }
                GCAddInfo.DataSource = FrmDT;
                GVAddInfo.BestFitColumns();
            }
        }

        private void BTClearItem_Click(object sender, EventArgs e)
        {
            if (GVAddInfo.GetFocusedDataRow() != null)
            {
                GVAddInfo.DeleteRow(GVAddInfo.FocusedRowHandle);
            }
        }
    }
}
