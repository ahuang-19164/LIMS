using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using DevExpress.XtraEditors;
using Perwork.SampleWeChatModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perwork.SmapleWechat
{
    public partial class FrmBlendEntry : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 插入数据库信息
        /// </summary>
        string wxEntryInfo = "http://localhost:9600/api/wxEntryInfo";
        /// <summary>
        /// 查询web数据库信息
        /// </summary>
        string wxInfoSelect = "http://localhost:9600/api/wxInfoSelect";
        public FrmBlendEntry()
        {
            InitializeComponent();
        }

        private void FrmBlendEntry_Load(object sender, EventArgs e)
        {
            wxInfoSelect = ConfigInfos.ReadConfigInfo("wxInfoSelect");
            wxEntryInfo = ConfigInfos.ReadConfigInfo("wxEntryInfo");
            DEstime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            GridControls.formartGridView(GVinfo);
            GridControls.showEmbeddedNavigator(GCInfo);
            //GridLookUpEdites.Formats(GEclientName);
            //GEclientName.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            //xianjikong.GetToken();
            //sampleInfos = new List<sampleInfo>();

            GridLookUpEdites.Formats(GEclientName, DTHelper.DTEnable(WorkCommData.DTClientInfo));
        }



        private void CEone_CheckedChanged(object sender, EventArgs e)
        {
            if (CEone.Checked)
            {
                CEmore.Checked = false;
            }
            else
            {
                CEmore.Checked = true ;
            }
                


                
        }

        private void CEmore_CheckedChanged(object sender, EventArgs e)
        {
            if (CEmore.Checked)
                CEone.Checked = false;

                
        }

        private void BTselect_Click(object sender, EventArgs e)
        {
            //DateTime dateTime = Convert.ToDateTime(DEstime.EditValue);
            //sInfo sInfo = new sInfo();
            //sInfo.TableName = "WorkPer.SampleInfo";
            //if(CEour.Checked)
            //{
            //    sInfo.wheres = $"dstate=0 and connstate=2 and creater='{CommonData.UserInfo.names}' and createTime>='{dateTime.ToString("yyyy-MM-dd")}' and createTime<='{dateTime.AddDays(+1).ToString("yyyy-MM-dd")}'";
            //}
            //else
            //{
            //    sInfo.wheres = $"dstate=0 and connstate=2 and createTime>='{dateTime.ToString("yyyy-MM-dd")}' and createTime<='{dateTime.AddDays(+1).ToString("yyyy-MM-dd")}'";
            //}
            //DataTable dataTable= ApiHelpers.postInfo(sInfo);
            //sampleInfos=new List<sampleInfo> ();
            //foreach(DataRow dataRow in dataTable.Rows)
            //{
            //    sampleInfo sample = new sampleInfo();
            //    sample.barcode=dataRow["barcode"] !=DBNull.Value? dataRow["barcode"].ToString():"";
            //    sample.sampleTime = dataRow["sampleTime"] !=DBNull.Value? dataRow["sampleTime"].ToString():"";
            //    sample.sampleLocation = dataRow["sampleLocation"] !=DBNull.Value? dataRow["sampleLocation"].ToString():"";
            //    sample.sampleTypeNames = dataRow["sampleTypeNames"] !=DBNull.Value? dataRow["sampleTypeNames"].ToString():"";
            //    sample.patientName = dataRow["patientName"] !=DBNull.Value? dataRow["patientName"].ToString():"";
            //    sample.patientSexNames = dataRow["patientSexNames"] !=DBNull.Value? dataRow["patientSexNames"].ToString():"";
            //    sample.ageYear = dataRow["ageYear"] !=DBNull.Value? dataRow["ageYear"].ToString():"";
            //    sample.patientCardNo = dataRow["patientCardNo"] !=DBNull.Value? dataRow["patientCardNo"].ToString():"";
            //    sample.number = dataRow["number"] !=DBNull.Value? dataRow["number"].ToString():"";
            //    sample.patientPhone = dataRow["patientPhone"] !=DBNull.Value? dataRow["patientPhone"].ToString():"";
            //    sample.creater = dataRow["receive"] !=DBNull.Value? dataRow["receive"].ToString():"";
            //    sample.receiveTime = dataRow["receiveTime"] !=DBNull.Value? dataRow["receiveTime"].ToString():"";
            //}
            //GCInfo.DataSource = new BindingList<sampleInfo>(sampleInfos);
        }

        private void BTedit_Click(object sender, EventArgs e)
        {

        }

        private void BTsave_Click(object sender, EventArgs e)
        {

        }

        private void BTdel_Click(object sender, EventArgs e)
        {
            //sampleInfo dataRow = GVinfo.GetFocusedRow() as sampleInfo;
            //if(dataRow != null)
            //{
            //    uInfo uInfo = new uInfo();
            //    uInfo.TableName = "WorkPer.SampleInfo";
            //    uInfo.value = "dstate=1";
            //    uInfo.wheres = $"barcode='{dataRow.barcode}' and perState=1";
            //    uInfo.MessageShow = 1;
            //    ApiHelpers.postInfo(uInfo);
            //    sampleInfos.Remove(dataRow);
            //    GCInfo.DataSource = new BindingList<sampleInfo>(sampleInfos);
            //}
            //else
            //{
            //    MessageBox.Show("请选择需要删除的信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }
        //List<sampleInfo> sampleInfos;
        //sampleInfo sampleInfo;
        private void BTReceive_Click(object sender, EventArgs e)
        {
            //if(sampleInfo!=null)
            //{
            //    sampleInfo.barcode = TEhospitalBarcode.EditValue != null ? TEhospitalBarcode.EditValue.ToString().Trim() : "";
            //    if (sampleInfo.barcode != "")
            //    {
            //        WxEntryModel entryInfo = new WxEntryModel();
            //        entryInfo.UserName = CommonData.UserInfo.names;
            //        
            //        entryInfo.sampleinfo = sampleInfo;



            //        string Sr = JsonHelper.SerializeObjct(entryInfo);
            //        string a = ApiHelpers.postInfo(wxEntryInfo, Sr);

            //        MEsampleState.EditValue = sampleInfo.barcode + "接收成功！\r\n" + MEsampleState.EditValue;
            //        //TEhospitalBarcode.EditValue = "";
            //        //TEhospitalBarcode.SelectAll();
            //        TESampleCode.Focus();
            //        TESampleCode.SelectAll();
            //    }
            //    else
            //    {
            //        MessageBox.Show("请输入试管编码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("样本信息不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        private void TEhospitalBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == (char)13)
            //{
            //    if (sampleInfo != null)
            //    {

            //        sampleInfo.barcode = TEhospitalBarcode.EditValue != null ? TEhospitalBarcode.EditValue.ToString().Trim() : "";
            //        if (sampleInfo.barcode != "")
            //        {
            //            BTReceive_Click(null, null);

            //        }
            //        else
            //        {
            //            MessageBox.Show("请输入试管编码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }

            //    }
            //    else
            //    {

            //        MessageBox.Show("样本信息不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }


            //}
        }
        private void TESampleCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (GEclientName.EditValue != null)
            //{


            //    if (CEmore.Checked || CEone.Checked)
            //    {
            //        if (TELocation.EditValue != null && TELocation.EditValue.ToString().Trim() != "")
            //        {
            //            if (TEhospitalBarcode.EditValue != null && TEhospitalBarcode.EditValue.ToString().Trim().Length > 0)
            //            {
            //                //string sinfo = xianjikong.getDataByCode(TEhospitalBarcode.EditValue.ToString().Trim());
            //                //jkinfoModel jkinfo = JsonHelper.JsonConvertObject<jkinfoModel>(sinfo);
            //                WxSelectModel wxSelectInfo = new WxSelectModel();
            //                wxSelectInfo.UserName = CommonData.UserInfo.names;
            //                wxSelectInfo.UserToken = CommonData.UserInfo.UserToken;
            //                wxSelectInfo.operatType = "0";
            //                wxSelectInfo.sampleCode = TEhospitalBarcode.EditValue.ToString();
            //                string aa = JsonHelper.SerializeObjct(wxSelectInfo);
            //                DataTable dataTable = ApiHelpers.postInfo(wxEntryInfo, aa);
            //                if (dataTable != null)
            //                {
            //                    sampleInfo = new sampleInfo();
            //                    //sampleInfo.barcode = jkinfo.data.tubeCode;


            //                    sampleInfo.sampleTypeNames = "口咽";
            //                    sampleInfo.number = NNO.Value.ToString();
            //                    sampleInfo.sampleLocation = TELocation.EditValue.ToString();
            //                    sampleInfo.sampleTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //                    sampleInfo.creater = CommonData.UserInfo.names;
            //                    sampleInfo.receiveTime = sampleInfo.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //                    sampleInfo.clientCode = GEclientName.EditValue.ToString();
            //                    sampleInfo.clientName = GEclientName.Text.ToString();


            //                    sampleInfo.id = dataTable.Rows[0]["id"] != DBNull.Value ? Convert.ToInt32(dataTable.Rows[0]["id"]) : 0;
            //                    sampleInfo.patientPhone = dataTable.Rows[0]["phone_no"] != DBNull.Value ? dataTable.Rows[0]["phone_no"].ToString() : "";
            //                    sampleInfo.patientCardNo = dataTable.Rows[0]["card_no"] != DBNull.Value ? dataTable.Rows[0]["card_no"].ToString() : "";
            //                    sampleInfo.patientName = dataTable.Rows[0]["user_name"] !=DBNull.Value? dataTable.Rows[0]["user_name"].ToString():"";
            //                    sampleInfo.patientSexNames = dataTable.Rows[0]["user_sex"] != DBNull.Value ? dataTable.Rows[0]["user_sex"].ToString() : "";
            //                    string patientAddress= dataTable.Rows[0]["user_address"] != DBNull.Value ? dataTable.Rows[0]["user_address"].ToString() : "";
            //                    string detail= dataTable.Rows[0]["address_detail"] != DBNull.Value ? dataTable.Rows[0]["address_detail"].ToString() : "";
            //                    sampleInfo.patientAddress = patientAddress + "/" + detail;
            //                    if (sampleInfo.patientSexNames == "男")
            //                        {
            //                        sampleInfo.patientSexNO = "1";
            //                        }
            //                        else
            //                        {
            //                            if (sampleInfo.patientSexNames == "女")
            //                            {
            //                            sampleInfo.patientSexNO = "2";
            //                            }
            //                            else
            //                            {
            //                            sampleInfo.patientSexNO = "3";
            //                            }
            //                        }
            //                    sampleInfo.ageYear = dataTable.Rows[0]["user_age"] != DBNull.Value ? dataTable.Rows[0]["user_age"].ToString() : ""; ;

            //                    if (CEone.Checked)
            //                    {
            //                        sampleInfo.sampleType = 1;
            //                        sampleInfo.applyCode = "10";
            //                        sampleInfo.applyName = "核算检测-人单检";
            //                    }
            //                    else
            //                    {
            //                        if (CEmore.Checked)
            //                        {
            //                            sampleInfo.sampleType = 2;
            //                            sampleInfo.applyCode = "17";
            //                            sampleInfo.applyName = "核算检测-人混检";
            //                        }
            //                    }


            //                    bool cfCode = false;
            //                    //if(jkinfo.data.checkResult=="1")
            //                    //{
            //                    foreach (sampleInfo sample in sampleInfos)
            //                    {
            //                        if (sample.patientCardNo == sampleInfo.patientCardNo)
            //                        {
            //                            cfCode = true;
            //                        }
            //                    }
            //                    if (cfCode)
            //                    {
            //                        MessageBox.Show("身份信息已经存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                        TESampleCode.Focus();
            //                        TESampleCode.SelectAll();

            //                    }
            //                    else
            //                    {
            //                        sampleInfos.Add(sampleInfo);
            //                        GCInfo.DataSource = new BindingList<sampleInfo>(sampleInfos);
            //                        GVinfo.BestFitColumns();
            //                        TESampleCode.Focus();
            //                        TESampleCode.SelectAll();

            //                    }

            //                }
            //                else
            //                {

            //                    MessageBox.Show("未找到相关信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    TESampleCode.Focus();
            //                    TESampleCode.SelectAll();
            //                }

            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("采样地点不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }

            //    }
            //    else
            //    {
            //        MessageBox.Show("请选择采样类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请选择客户信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void NNO_ValueChanged(object sender, EventArgs e)
        {
            if (CEone.Checked)
                NNO.Value = 1;
            if(CEmore.Checked)
            {
                if (NNO.Value > 10)
                    NNO.Value = 10;
                if (NNO.Value < 1)
                    NNO.Value = 1;
            }
        }
    }
}
