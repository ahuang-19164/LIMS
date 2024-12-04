using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using DevExpress.XtraEditors;
using Ms.jikongHandle;
using Ms.jikongModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace MS.BlendEntry
{
    public partial class FrmBlendEntry : DevExpress.XtraEditors.XtraForm
    {

        string EntryInfoJK = "http://localhost:9600/api/BlendEntry";
        public FrmBlendEntry()
        {
            InitializeComponent();
        }

        private void FrmBlendEntry_Load(object sender, EventArgs e)
        {
            EntryInfoJK = ConfigInfos.ReadConfigInfo("EntryInfoJK");
            DEstime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            //GEclientName.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            xianjikong.GetToken();
            sampleInfos = new List<JKSampleInfoModel>();
            GridControls.formartGridView(GVinfo);
            GridControls.showEmbeddedNavigator(GCInfo);
            GridLookUpEdites.Formats(GEclientName, DTHelper.DTEnable(WorkCommData.DTClientInfo));
        }

        List<JKSampleInfoModel> sampleInfos;
        private void BTReceive_Click(object sender, EventArgs e)
        {
            if (GEclientName.EditValue != null)
            {

                //if (CEmore.Checked || CEone.Checked)
                //{
                if (TEhospitalBarcodes.EditValue != null && TEhospitalBarcodes.EditValue.ToString().Trim().Length > 0)
                {
                    string[] ss = TEhospitalBarcodes.EditValue.ToString().Split(',');

                    string msg = "";
                    JKEntryModel entryInfo = new JKEntryModel();
                    entryInfo.UserName = CommonData.UserInfo.names;
                    List<JKSampleInfoModel> jKSampleInfos = new List<JKSampleInfoModel>();
                    foreach (string sinfo in ss)
                    {
                        if(sinfo.Length>0)
                        {
                            string sinfos= xianjikong.getDataByCode(sinfo);
                            jkinfoModel jkinfo = JsonHelper.JsonConvertObject<jkinfoModel>(sinfos);
                            if (jkinfo.code == "200")
                            {

                                JKSampleInfoModel info = new JKSampleInfoModel();
                                info.barcode = jkinfo.data.tubeCode;
                                //info.sampleTime = jkinfo.data.receiveTime;
                                if (jkinfo.data.receiveVO.collectionPart == "口咽")
                                {
                                    info.sampleTypeNames = "口咽拭子";
                                }
                                else
                                {
                                    info.sampleTypeNames = jkinfo.data.receiveVO.collectionPart;
                                }
                                info.id = GCInfo.DataSource != null ? GVinfo.RowCount + 1 : 0;
                                info.number = jkinfo.data.receiveVO.collectionNum;
                                info.sampleLocation = jkinfo.data.receiveVO.collectLocationName;
                                info.sampleTime = jkinfo.data.receiveVO.startTime;
                                info.creater = CommonData.UserInfo.names;
                                info.receiveTime = info.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                info.clientCode = GEclientName.EditValue.ToString();
                                info.clientName = GEclientName.Text.ToString();

                                if (jkinfo.data.person != null)
                                {
                                    info.patientName = jkinfo.data.person.personName;
                                    info.patientSexNames = jkinfo.data.person.sex;
                                    if (jkinfo.data.person.sex == "男")
                                    {
                                        info.patientSexNO = "1";
                                    }
                                    else
                                    {
                                        if (jkinfo.data.person.sex == "女")
                                        {
                                            info.patientSexNO = "2";
                                        }
                                        else
                                        {
                                            info.patientSexNO = "3";
                                        }
                                    }

                                    info.ageYear = jkinfo.data.person.age;
                                    info.patientPhone = jkinfo.data.person.personPhone;
                                    info.patientCardNo = jkinfo.data.person.idCard;
                                }
                                if (info.patientPhone != null && info.patientCardNo != null)
                                {
                                    if (info.patientPhone.Trim() != "" && info.patientCardNo.Trim() != "")
                                    {
                                        info.sampleType = 1;
                                        info.applyCode = "10";
                                        info.applyName = "核酸检测-人单检";
                                    }
                                    else
                                    {
                                        info.sampleType = 2;
                                        info.applyCode = "17";
                                        info.applyName = "核酸检测-人混检";
                                    }
                                }
                                else
                                {
                                    info.sampleType = 2;
                                    info.applyCode = "17";
                                    info.applyName = "核酸检测-人混检";
                                }


                                bool cfCode = false;
                                //if(jkinfo.data.checkResult=="1")
                                //{
                                foreach (JKSampleInfoModel sample in sampleInfos)
                                {
                                    if (sample.barcode == info.barcode)
                                    {
                                        cfCode = true;
                                    }
                                }
                                if (cfCode)
                                {
                                    
                                    MEsampleState.EditValue = $"试管号码{sinfo}已存在！" + "\r\n" + MEsampleState.EditValue;
                                    msg+= $"试管号码{sinfo}已存在\r\n";
                                    //if (ss.Length == 1)
                                    //    MessageBox.Show($"试管号码{sinfo}已存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //TEhospitalBarcodes.SelectAll();
                                }
                                else
                                {

                                    //将信息插入到全局List中
                                    sampleInfos.Add(info);
                                    //将信息插入到接口集合中
                                    jKSampleInfos.Add(info);

                                    //TEhospitalBarcode.EditValue = "";
                                    //TEhospitalBarcodes.SelectAll();
                                }

                            }
                            else
                            {
                                MEsampleState.EditValue = sinfo + jkinfo.msg+"\r\n" + MEsampleState.EditValue;
                                if (ss.Length == 1)
                                    MessageBox.Show(sinfo+jkinfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                
                            }
                        }
                    }
                    entryInfo.sampleinfos = jKSampleInfos;
                    string Sr = JsonHelper.SerializeObjct(entryInfo);
                    WebApiCallBack jm = ApiHelpers.postInfo(EntryInfoJK, Sr);


                    if (jm.code == 0)
                    {
                        if(jm.data!=null)
                        {
                            List<commReInfo<string>> commReInfos = JsonHelper.JsonConvertObject<List<commReInfo<string>>>(jm.data.ToString());
                            //commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                            //GCInfo.DataSource = new BindingList<JKSampleInfoModel>(sampleInfos);

                            foreach (commReInfo<string> commReInfo in commReInfos)
                            {
                                MEsampleState.EditValue = commReInfo.msg + "\r\n" + MEsampleState.EditValue;
                            }
                            GVinfo.BestFitColumns();
                        }
                    }
                    else
                    {
                        MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择客户信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            TEhospitalBarcodes.SelectAll();
        }

        private void TEhospitalBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                BTReceive_Click(null, null);
                
            }
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
            DateTime dateTime = Convert.ToDateTime(DEstime.EditValue);
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkPer.SampleInfo";
            if(CEour.Checked)
            {
                sInfo.wheres = $"dstate=0 and connstate=1 and creater='{CommonData.UserInfo.names}' and createTime>='{dateTime.ToString("yyyy-MM-dd")}' and createTime<='{dateTime.AddDays(+1).ToString("yyyy-MM-dd")}'";
            }
            else
            {
                sInfo.wheres = $"dstate=0 and connstate=1 and createTime>='{dateTime.ToString("yyyy-MM-dd")}' and createTime<='{dateTime.AddDays(+1).ToString("yyyy-MM-dd")}'";
            }
            DataTable DTInfo= ApiHelpers.postInfo(sInfo);
            sampleInfos.Clear();
            foreach(DataRow dataRow in DTInfo.Rows)
            {
                JKSampleInfoModel sampleInfo = new JKSampleInfoModel();
                sampleInfo.barcode = dataRow["barcode"]!=DBNull.Value? dataRow["barcode"].ToString():"";
                sampleInfo.sampleTypeNames = dataRow["sampleTypeNames"] !=DBNull.Value? dataRow["sampleTypeNames"].ToString():"";
                sampleInfo.number = dataRow["number"] !=DBNull.Value? dataRow["number"].ToString():"";
                sampleInfo.sampleLocation = dataRow["sampleLocation"] !=DBNull.Value? dataRow["sampleLocation"].ToString():"";
                sampleInfo.sampleTime = dataRow["sampleTime"] !=DBNull.Value? dataRow["sampleTime"].ToString():"";
                sampleInfo.creater = dataRow["creater"] !=DBNull.Value? dataRow["creater"].ToString():"";
                sampleInfo.receiveTime = dataRow["receiveTime"] !=DBNull.Value? dataRow["receiveTime"].ToString():"";
                sampleInfo.clientCode = dataRow["hospitalNO"] !=DBNull.Value? dataRow["hospitalNO"].ToString():"";
                sampleInfo.clientName = dataRow["hospitalNames"] !=DBNull.Value? dataRow["hospitalNames"].ToString():"";
                sampleInfo.patientName = dataRow["patientName"] !=DBNull.Value? dataRow["patientName"].ToString():"";
                sampleInfo.patientSexNames = dataRow["patientSexNames"] !=DBNull.Value? dataRow["patientSexNames"].ToString():"";
                sampleInfo.ageYear = dataRow["ageYear"] !=DBNull.Value? dataRow["ageYear"].ToString():"";
                sampleInfo.patientPhone = dataRow["patientPhone"] !=DBNull.Value? dataRow["patientPhone"].ToString():"";
                sampleInfo.patientCardNo = dataRow["patientCardNo"] !=DBNull.Value? dataRow["patientCardNo"].ToString():"";
                sampleInfo.applyCode = dataRow["applyItemCodes"] !=DBNull.Value? dataRow["applyItemCodes"].ToString():"";
                sampleInfo.applyName = dataRow["applyItemNames"] !=DBNull.Value? dataRow["applyItemNames"].ToString():"";
                sampleInfos.Add(sampleInfo);

            }
            GCInfo.DataSource = new BindingList<JKSampleInfoModel>(sampleInfos);
            GVinfo.BestFitColumns();
        }

        private void BTedit_Click(object sender, EventArgs e)
        {

        }

        private void BTsave_Click(object sender, EventArgs e)
        {

        }

        private void BTdel_Click(object sender, EventArgs e)
        {
            JKSampleInfoModel dataRow = GVinfo.GetFocusedRow() as JKSampleInfoModel;
            if(dataRow != null)
            {
                uInfo uInfo = new uInfo();
                uInfo.TableName = "WorkPer.SampleInfo";
                uInfo.value = "dstate=1";
                uInfo.wheres = $"barcode='{dataRow.barcode}' and perState=1";
                uInfo.MessageShow = 1;
                ApiHelpers.postInfo(uInfo);
                sampleInfos.Remove(dataRow);
                GCInfo.DataSource = new BindingList<JKSampleInfoModel>(sampleInfos);
            }
            else
            {
                MessageBox.Show("请选择需要删除的信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            sampleInfos.Clear();
            GCInfo.DataSource = new BindingList<JKSampleInfoModel>(sampleInfos);
        }
        //string barcodestring = "";
        private void TEhospitalBarcodes_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormBarcodeInfo formBarcodeInfo = new FormBarcodeInfo("");
            Func<string> func = formBarcodeInfo.reStringinfo;
            formBarcodeInfo.ShowDialog();
            TEhospitalBarcodes.EditValue = func();
        }

    }
}
