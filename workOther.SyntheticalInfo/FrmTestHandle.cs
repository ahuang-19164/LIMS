using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.Model;
using Common.JsonHelper;
using Common.TestModel;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace workOther.SyntheticalInfo
{
    public partial class FrmTestHandle : XtraForm
    {
        int infoID = 0;
        int testid = 0;

        int perid = 0;
        //int sampleInfoID = 0;



        string barcode = "";
        string groupCodes = "";
#pragma warning disable CS0414 // 字段“FrmTestHandle.groupNames”已被赋值，但从未使用过它的值
        string groupNames = "";
#pragma warning restore CS0414 // 字段“FrmTestHandle.groupNames”已被赋值，但从未使用过它的值


        string TestInfoHandle = "";
        public FrmTestHandle(DataRow sampleInfo, string recordTypeNO = "")
        {
            TestInfoHandle = ConfigInfos.ReadConfigInfo("TestInfoHandle");
            InitializeComponent();
            //submitItemCodes = "";

            if (sampleInfo != null)
            {



                infoID = sampleInfo["subid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["subid"]) : 0;
                perid = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;
                //sampleInfoID = sampleInfo["id"] != DBNull.Value ? Convert.ToInt32(sampleInfo["id"]) : 0;
                //testid = sampleInfo["testid"] != DBNull.Value ? Convert.ToInt32(sampleInfo["testid"]) : 0;


                barcode = sampleInfo["barcode"] != DBNull.Value ? sampleInfo["barcode"].ToString() : "";

                TEBarcode.EditValue = barcode;

                TEhosiptalNo.EditValue = sampleInfo["hospitalNO"];
                TEhosName.EditValue = sampleInfo["hospitalNames"];
                TEpatientName.EditValue = sampleInfo["patientName"];
                TEsexName.EditValue = sampleInfo["patientSexNames"];
                TEageYear.EditValue = sampleInfo["ageYear"];
                GEperStateNO.EditValue = sampleInfo["perStateNO"];
                DEsampleTime.EditValue = sampleInfo["sampleTime"];
                DEsendTime.EditValue = sampleInfo["receiveTime"];
                //TEcreater.EditValue= CommonData.UserInfo.names;
                //DEcreateTime.EditValue= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                groupCodes = sampleInfo["submitItemCodes"] != DBNull.Value ? sampleInfo["submitItemCodes"].ToString() : "";

                GErecordTypeNO.EditValue = sampleInfo["recordTypeNO"];
                TErecordValue.EditValue = sampleInfo["recordValue"];

                TEcreater.EditValue = sampleInfo["creater"];
                DEcreateTime.EditValue = sampleInfo["createTime"];

                TEhandleResult.EditValue = sampleInfo["handleResult"];
                TEremark.EditValue = sampleInfo["remark"];

                TEhandler.EditValue = sampleInfo["handler"];
                DEhandleTime.EditValue = sampleInfo["handleTime"];

                bool infostate = sampleInfo["state"] != DBNull.Value ? Convert.ToBoolean(sampleInfo["state"]) : false;
                if (infostate)
                {

                    CEOK.Checked = true;
                }
                else
                {
                    CEOK.Checked = false;
                }

                string handleTypeNO = sampleInfo["handleTypeNO"] != DBNull.Value ? sampleInfo["handleTypeNO"].ToString() : "";
                if (handleTypeNO != "")
                {
                    if (handleTypeNO == "2")
                    {
                        BTsave.Enabled = false;
                    }
                    GEhandleTypeNO.EditValue = handleTypeNO;
                }
                else
                {
                    GEhandleTypeNO.EditValue = "2";
                }
                //groupNames = sampleInfo["groupNames"] != DBNull.Value ? sampleInfo["groupNames"].ToString() : "";
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


        }
        private void FrmTestHandle_Load(object sender, EventArgs e)
        {

            //GridLookUpEdites.Formats(GEDelegateClient);
            GridLookUpEdites.Formats(GEperStateNO);
            GridLookUpEdites.Formats(GEhandleTypeNO);
            GridLookUpEdites.Formats(GErecordTypeNO);
            GEhandleTypeNO.Properties.DataSource = DTHelper.DTEnable(OtherInfoData.DTHandleState);
            GErecordTypeNO.Properties.DataSource = DTHelper.DTEnable(OtherInfoData.DTSubmitState);
            //GEDelegateClient.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientDelegateInfo);




            GridLookUpEdites.Formats(RGEsampleTypeNO);
            GridLookUpEdites.Formats(RGEinstrumentNO);
            GridLookUpEdites.Formats(RGEmethodNO);
            GridLookUpEdites.Formats(RGEgroupNO);

            RGEsampleTypeNO.DataSource = WorkCommData.DTTypeSample;
            RGEinstrumentNO.DataSource = WorkCommData.DTInstrumentInfo;
            RGEmethodNO.DataSource = WorkCommData.DTTypeMethod;
            GEperStateNO.Properties.DataSource = WorkCommData.DTStatePerWork;
            RGEgroupNO.DataSource = WorkCommData.DTGroupTest;
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


                if (GEhandleTypeNO.EditValue != null && GEhandleTypeNO.EditValue.ToString() != "")
                {
                    if (GErecordTypeNO.EditValue != null && GErecordTypeNO.EditValue.ToString() != "")
                    {
                        if (TEhandleResult.EditValue != null && TEhandleResult.EditValue.ToString().Trim().Length >= 4)
                        {

                            if (GEhandleTypeNO.EditValue.ToString() == "2")
                            {
                                if (CENO.Checked || CEOK.Checked)
                                {
                                    commInfoModel<TesthandleModel> commInfo = new commInfoModel<TesthandleModel>();
                                    int subState = 0;
                                    subState = GErecordTypeNO.EditValue != null ? Convert.ToInt32(GErecordTypeNO.EditValue) : 0;
                                    if (subState != 0)
                                    {
                                        string CheckGroupCodes = "";
                                        string CheckGroupNames = "";
                                        for (int a = 0; a < GVTestInfo.RowCount; a++)
                                        {

                                            string itemcode = GVTestInfo.GetRowCellValue(a, "no") != DBNull.Value ? GVTestInfo.GetRowCellValue(a, "no").ToString() : "";
                                            CheckGroupCodes += itemcode + ",";
                                            string itemName = GVTestInfo.GetRowCellValue(a, "names") != DBNull.Value ? GVTestInfo.GetRowCellValue(a, "names").ToString() : "";
                                            CheckGroupNames += itemName + ",";

                                        }
                                        if (CheckGroupCodes != "")
                                        {
                                            commInfo.state = subState;
                                            commInfo.UserName = CommonData.UserInfo.names;
                                            
                                            List<TesthandleModel> testInfos = new List<TesthandleModel>();
                                            TesthandleModel testInfohandle = new TesthandleModel();
                                            testInfohandle.id = infoID;
                                            testInfohandle.perid = perid;
                                            testInfohandle.testid = testid;
                                            testInfohandle.barcode = barcode;
                                            if (CEOK.Checked)
                                            {
                                                testInfohandle.state = true;
                                                testInfohandle.infoState = true;
                                            }
                                            if (CENO.Checked)
                                            {
                                                testInfohandle.state = false;
                                                testInfohandle.infoState = false;
                                            }
                                            testInfohandle.submitItemCodes = CheckGroupCodes;
                                            testInfohandle.submitItemNames = CheckGroupNames;
                                            testInfohandle.handleTypeNO = GEhandleTypeNO.EditValue.ToString();
                                            testInfohandle.handleResult = TEhandleResult.EditValue.ToString();
                                            testInfohandle.remark = TEremark.EditValue != null ? TEremark.EditValue.ToString() : "";
                                            testInfohandle.handler = CommonData.UserInfo.names;
                                            //testInfohandle.handleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                            testInfos.Add(testInfohandle);
                                            commInfo.infos = testInfos;

                                            string Sr = JsonHelper.SerializeObjct(commInfo);
                                            WebApiCallBack jm = ApiHelpers.postInfo(TestInfoHandle, Sr);
                                            commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                                            if (commReInfo!=null)
                                            {
                                                rInfo = new ReturnInfo();
                                                foreach (commReSampleInfo commReSample in commReInfo.infos)
                                                {
                                                    if (commReSample != null)
                                                    {
                                                        if (commReSample.handleState == 1)
                                                        {
                                                            rInfo.testStateNO = commReSample.testState;
                                                            rInfo.handleTypeNO = GEhandleTypeNO.EditValue;
                                                            rInfo.handleResult = TEhandleResult.EditValue;
                                                            rInfo.handler = CommonData.UserInfo.names;
                                                            rInfo.state = CEOK.Checked;
                                                            rInfo.handleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                            rInfo.remark = TEremark.EditValue != null ? TEremark.EditValue.ToString() : "";
                                                        }
                                                    }
                                                }
                                                this.Close();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("未检测到需要处理的项目信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("请选择提交状态！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("请选择申请状态！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                commInfoModel<TesthandleModel> commInfo = new commInfoModel<TesthandleModel>();
                                int subState = 0;
                                subState = GErecordTypeNO.EditValue != null ? Convert.ToInt32(GErecordTypeNO.EditValue) : 0;
                                if (subState != 0)
                                {
                                    string CheckGroupCodes = "";
                                    string CheckGroupNames = "";
                                    for (int a = 0; a < GVTestInfo.RowCount; a++)
                                    {

                                        string itemcode = GVTestInfo.GetRowCellValue(a, "no") != DBNull.Value ? GVTestInfo.GetRowCellValue(a, "no").ToString() : "";
                                        CheckGroupCodes += itemcode + ",";
                                        string itemName = GVTestInfo.GetRowCellValue(a, "names") != DBNull.Value ? GVTestInfo.GetRowCellValue(a, "names").ToString() : "";
                                        CheckGroupNames += itemName + ",";

                                    }
                                    if (CheckGroupCodes != "")
                                    {
                                        commInfo.state = subState;
                                        commInfo.UserName = CommonData.UserInfo.names;
                                        
                                        List<TesthandleModel> testInfos = new List<TesthandleModel>();
                                        TesthandleModel testInfohandle = new TesthandleModel();
                                        testInfohandle.id = infoID;
                                        testInfohandle.perid = perid;
                                        testInfohandle.testid = testid;
                                        testInfohandle.barcode = barcode;
                                        if (CEOK.Checked)
                                            testInfohandle.state = true;
                                        if (CENO.Checked)
                                            testInfohandle.state = false;
                                        testInfohandle.submitItemCodes = CheckGroupCodes;
                                        testInfohandle.submitItemNames = CheckGroupNames;
                                        testInfohandle.handleTypeNO = GEhandleTypeNO.EditValue.ToString();
                                        testInfohandle.handleResult = TEhandleResult.EditValue.ToString();
                                        testInfohandle.remark = TEremark.EditValue != null ? TEremark.EditValue.ToString() : "";
                                        testInfohandle.handler = CommonData.UserInfo.names;
                                        //testInfohandle.handleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                        testInfos.Add(testInfohandle);
                                        commInfo.infos = testInfos;

                                        string Sr = JsonHelper.SerializeObjct(commInfo);
                                        WebApiCallBack jm = ApiHelpers.postInfo(TestInfoHandle, Sr);
                                        commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);
                                        if (commReInfo.code == 1)
                                        {
                                            rInfo = new ReturnInfo();
                                            foreach (commReSampleInfo commReSample in commReInfo.infos)
                                            {
                                                if (commReSample != null)
                                                {
                                                    if (commReSample.handleState == 1)
                                                    {
                                                        rInfo.testStateNO = commReSample.testState;
                                                        rInfo.handleTypeNO = GEhandleTypeNO.EditValue;
                                                        rInfo.handleResult = TEhandleResult.EditValue;
                                                        rInfo.handler = CommonData.UserInfo.names;
                                                        rInfo.state = CEOK.Checked;
                                                        rInfo.handleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                                        rInfo.remark = TEremark.EditValue != null ? TEremark.EditValue.ToString() : "";
                                                    }
                                                }
                                            }
                                            this.Close();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("未检测到需要处理的项目信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("请选择提交状态！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }


                        }
                        else
                        {
                            MessageBox.Show("请填写处理记录,至少4个字！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("请选择处理类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CENO_CheckedChanged(object sender, EventArgs e)
        {
            if (CENO.Checked)
            {
                CEOK.Checked = false;
                //GEDelegateClient.Enabled = true;
            }
        }

        private void CEOK_CheckedChanged(object sender, EventArgs e)
        {
            if (CEOK.Checked)
            {
                CENO.Checked = false;
                GEhandleTypeNO.EditValue = "2";
                //GEDelegateClient.Enabled = true;
            }
        }
        public ReturnInfo reinfo()
        {
            return rInfo;
        }
    }
}
