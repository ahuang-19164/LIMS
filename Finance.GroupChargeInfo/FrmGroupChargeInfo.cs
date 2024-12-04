using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Finance.GroupChargeInfo
{
    public partial class FrmGroupChargeInfo : DevExpress.XtraEditors.XtraForm
    {
        string tableName = "Finance.GroupChargeInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmGroupChargeInfo()
        {
            InitializeComponent();


            SysPowerHelper.UserPower(barManager1);







            GridControls.formartGridView(GVInfo);


            GridLookUpEdites.Formats(RGEagentNO);
            GridLookUpEdites.Formats(RGEhospitalNO);
            GridLookUpEdites.Formats(RGEchargeLevelNO);
            GridLookUpEdites.Formats(RGEgroupCode);
            GridLookUpEdites.Formats(RGEpatientTypeNO);



            GridLookUpEdites.Formats(GEagentNO);
            GridLookUpEdites.Formats(GEhospitalNO);
            GridLookUpEdites.Formats(GEchargeLevelNO);
            GridLookUpEdites.Formats(GEgroupCode);
            GridLookUpEdites.Formats(GEpatientTypeNO);
            TextEdits.TextFormatDecimal(TEstandardCharge);
            TextEdits.TextFormatDecimal(TEsettlementCharge);
            GroupInfo.Enabled = false;


            //TextEdits.TextFormat(TESort);
            //TextEdits.TextFormat(TESort);
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }

        }

        private void FrmCompanyinfo_Load(object sender, EventArgs e)
        {
            //TextEdits.TextFormat(TESort);
            //GCInfo.DataSource = CommonData.DTCommonyInfoAll;


            sInfo selectInfo = new sInfo();
            selectInfo.TableName = tableName;
            //selectInfo.wheres = "dstate=0";
            selectInfo.OrderColumns = "groupCode";

            GCInfo.DataSource = ApiHelpers.postInfo(selectInfo);




            RGEagentNO.DataSource = WorkCommData.DTClientAgent;
            GEagentNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientAgent);
            RGEhospitalNO.DataSource = WorkCommData.DTClientInfo;
            GEhospitalNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            RGEchargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            GEchargeLevelNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeLevel);
            RGEpatientTypeNO.DataSource = WorkCommData.DTTypePatient;
            GEpatientTypeNO.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypePatient);
            RGEgroupCode.DataSource = WorkCommData.DTItemGroup;
            GEgroupCode.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTItemGroup);





            GVInfo.BestFitColumns();
        }
        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {

            //string[] PowerList = CommonData.powerList;
            foreach (BarItem BT in barManager1.Items)
            {
                if (CommonData.UserInfo.id != 1)
                {
                    if (BT.Tag != null)
                    {
                        if (CommonData.powerList.Contains(BT.Tag.ToString()))
                        {
                            BT.Enabled = true;
                        }
                        else
                        {
                            BT.Enabled = false;
                        }
                    }
                    else
                    {
                        BT.Enabled = false;
                    }
                }
                else
                {
                    BT.Enabled = true;
                }

            }

        }



        private void gridView1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                int handle = GVInfo.FocusedRowHandle;
                if (GVInfo.GetFocusedDataRow() != null)
                {
                    DataRow dr = GVInfo.GetFocusedDataRow();
                    SelectValueID = Convert.ToInt32(dr["id"]);
                    GEagentNO.EditValue = dr["agentNO"];
                    GEhospitalNO.EditValue = dr["hospitalNO"];
                    GEpatientTypeNO.EditValue = dr["patientTypeNO"];
                    GEchargeLevelNO.EditValue = dr["chargeLevelNO"];
                    GEgroupCode.EditValue = dr["groupCode"];
                    TEsettlementCharge.EditValue = dr["settlementCharge"];
                    TEstandardCharge.EditValue = dr["standardCharge"];
                    DEstartTime.EditValue = dr["startTime"];
                    DEendTime.EditValue = dr["endTime"];
                    TEdepartment.EditValue = dr["department"];
                    CEdiscountState.Checked = Convert.ToBoolean(dr["discountState"]);
                    CEState.Checked = Convert.ToBoolean(dr["state"]);
                }
            }

        }
        private void BTAddCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GroupInfo.Enabled = true;
            EditState = 1;
            GEagentNO.EditValue = "";
            GEhospitalNO.EditValue = "";
            GEpatientTypeNO.EditValue = "";
            GEchargeLevelNO.EditValue = "";
            GEgroupCode.EditValue = "";
            TEdepartment.EditValue = "";
            TEsettlementCharge.EditValue = 0.00;
            TEstandardCharge.EditValue = 0.00;
            DEstartTime.EditValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            DEendTime.EditValue = DateTime.Now.AddYears(+10).ToString("yyyy-MM-dd HH:mm"); ;
            CEdiscountState.Checked = true;
            //CEState.Checked = Convert.ToBoolean(dr["state"]);
            CEState.Checked = true;
        }

        private void BTEditCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GroupInfo.Enabled = true;
            EditState = 2;
        }

        private void BTSaveCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (GEgroupCode.EditValue != null && TEsettlementCharge.EditValue != null && TEstandardCharge.EditValue != null)
            {
                if (GEgroupCode.EditValue.ToString() != "")
                {


                    sInfo selectInfo = new sInfo();
                    selectInfo.wheres = "1";
                    selectInfo.TableName = "Finance.GroupChargeInfo";
                    selectInfo.wheres = $"discountState='{CEdiscountState.Checked}' and agentNO='{GEagentNO.EditValue}' and hospitalNO='{GEhospitalNO.EditValue}' and patientTypeNO=''{GEpatientTypeNO.EditValue} and department='{TEdepartment.EditValue}' and chargeLevelNO='{GEchargeLevelNO.EditValue}' and groupCode='{GEgroupCode.EditValue}'";
                    DataTable aaa = ApiHelpers.postInfo(selectInfo);

                    if (EditState == 1)
                    {
                        if (aaa == null)
                        {
                            if (TEsettlementCharge.EditValue.ToString().Trim() == "")
                                TEsettlementCharge.EditValue = "0";
                            if (TEstandardCharge.EditValue.ToString().Trim() == "")
                                TEstandardCharge.EditValue = "0";
                            Dictionary<string, object> pairs = new Dictionary<string, object>();
                            pairs.Add("discountState", CEdiscountState.Checked);
                            pairs.Add("state", CEState.Checked);
                            pairs.Add("endTime", DEendTime.EditValue);
                            pairs.Add("startTime", DEstartTime.EditValue);
                            pairs.Add("settlementCharge", TEsettlementCharge.EditValue);
                            pairs.Add("standardCharge", TEstandardCharge.EditValue);
                            pairs.Add("chargeLevelNO", GEchargeLevelNO.EditValue);
                            pairs.Add("department", TEdepartment.EditValue);
                            //pairs.Add("id", dataTable.Rows[0]["id"]);
                            pairs.Add("agentNO", GEagentNO.EditValue);
                            pairs.Add("groupCode", GEgroupCode.EditValue);
                            pairs.Add("hospitalNO", GEhospitalNO.EditValue);
                            pairs.Add("patientTypeNO", GEpatientTypeNO.EditValue);
                            pairs.Add("creater", CommonData.UserInfo.names);
                            pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            iInfo insertInfo = new iInfo();
                            insertInfo.TableName = tableName;
                            insertInfo.values = pairs;
                            int a = Convert.ToInt32(ApiHelpers.postInfo(insertInfo));

                        }
                        else
                        {
                            MessageBox.Show("已经有该信息项，请勿重复添加！", "系统提示");
                        }
                    }

                    if (SelectValueID != 0)
                    {
                        if (EditState == 2)
                        {
                            Dictionary<string, object> pairs = new Dictionary<string, object>();
                            pairs.Add("discountState", CEdiscountState.Checked);
                            pairs.Add("state", CEState.Checked);
                            pairs.Add("endTime", DEendTime.EditValue);
                            pairs.Add("startTime", DEstartTime.EditValue);
                            pairs.Add("settlementCharge", TEsettlementCharge.EditValue);
                            pairs.Add("standardCharge", TEstandardCharge.EditValue);
                            pairs.Add("chargeLevelNO", GEchargeLevelNO.EditValue);
                            pairs.Add("department", TEdepartment.EditValue);
                            //pairs.Add("id", dataTable.Rows[0]["id"]);
                            pairs.Add("agentNO", GEagentNO.EditValue);
                            pairs.Add("groupCode", GEgroupCode.EditValue);
                            pairs.Add("hospitalNO", GEhospitalNO.EditValue);
                            pairs.Add("patientTypeNO", GEpatientTypeNO.EditValue);
                            pairs.Add("creater", CommonData.UserInfo.names);
                            pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            uInfo updateInfo = new uInfo();
                            updateInfo.TableName = tableName;
                            updateInfo.values = pairs;
                            updateInfo.DataValueID = SelectValueID;

                            int a = Convert.ToInt32(ApiHelpers.postInfo(updateInfo));
                        }
                    }
                    EditState = 0;
                    CommonDataRefresh.GetCommpanyInfo();
                    FrmCompanyinfo_Load(null, null);
                    GroupInfo.Enabled = false;

                }
                else
                {

                    MessageBox.Show("请选择项目信息！", "系统提示");
                }
            }
            else
            {

                MessageBox.Show("请选择项目信息！", "系统提示");
            }


        }

        private void TECompanyName_Leave(object sender, EventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void BTDelectCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (SelectValueID != 0)
            //{
            //    int a = DeleteHelper.hideinfo(SelectValueID, tableName);
            //    if (a > 0)
            //    {
            //        CommonDataRefresh.GetCommpanyInfo();
            //        GVInfo.DeleteSelectedRows();
            //    }
            //}
        }

        private void GCInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
