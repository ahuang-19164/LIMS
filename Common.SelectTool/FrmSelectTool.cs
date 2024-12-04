using Common.BLL;
using Common.Data;
using Common.FinanceModel;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.StatisticModel;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

using System;
using System.Collections.Generic;
using System.Data;

namespace Common.SelectTool
{
    public partial class FrmSelectTool : DevExpress.XtraEditors.XtraForm
    {
        string StatisticSampleInfo = "";
        DataTable selectInfoDT = null;
        List<PairsSelectModel> selectInfos;
        string typeNames = "";
        public FrmSelectTool(string typeName)
        {
            selectInfos = new List<PairsSelectModel>();
            InitializeComponent();
            if (typeName != null)
                typeNames = typeName;
        }

        private void FrmFinanceSelect_Load(object sender, EventArgs e)
        {

            //DEperTimeStart.EditValue = DEcheckTimeStart.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            //DEperTimeEnd.EditValue = DEcheckTimeEnd.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);




            StatisticSampleInfo = ConfigInfos.ReadConfigInfo("StatisticSampleInfo");

            formartButtonEdit(BEagentNames);
            formartButtonEdit(BEhospitalNames);
            formartButtonEdit(BEpatientSexNames);
            formartButtonEdit(BEsampleTypeNames);
            formartButtonEdit(BEpatientTypeNames);
            formartButtonEdit(BEsampleShapeNames);
            formartButtonEdit(BEgroupNames);

            DEperTimeStart.EditValue = DEcheckTimeStart.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            DEperTimeEnd.EditValue = DEcheckTimeEnd.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);

        }
        private void formartButtonEdit(ButtonEdit buttonEdit)
        {
            buttonEdit.Properties.Buttons.Clear();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            buttonEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(buttonEdit.Name.Substring(2),DevExpress.XtraEditors.Controls.ButtonPredefines.Search),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close)});
            buttonEdit.Properties.ReadOnly = true;
            buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
        }
        private void ButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ButtonEdit buttonEdit = sender as ButtonEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Search)
            {
                if (e.Button.Tag != null)
                {
                    string controlName = e.Button.Tag.ToString();
                    switch (controlName)
                    {
                        case "agentNames":
                            buttonEdit.EditValue = showinfo(controlName);
                            break;
                        case "hospitalNames":
                            buttonEdit.EditValue = showhospitalinfo(controlName);
                            break;
                        case "patientSexNames":
                            buttonEdit.EditValue = showinfo(controlName);
                            break;
                        case "sampleTypeNames":
                            buttonEdit.EditValue = showinfo(controlName);
                            break;
                        case "patientTypeNames":
                            buttonEdit.EditValue = showinfo(controlName);
                            break;
                        case "sampleShapeNames":
                            buttonEdit.EditValue = showinfo(controlName);
                            break;
                        case "chargeTypeNO":
                            buttonEdit.EditValue = showinfo(controlName);
                            break;
                        case "groupNames":
                            buttonEdit.EditValue = showinfo(controlName);
                            break;
                        case "personNO":
                            buttonEdit.EditValue = showinfo(controlName);
                            break;
                    }

                }


            }
            else
            {
                buttonEdit.EditValue = null;
            }
            //if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            //{

            //}
        }
        /// <summary>
        /// 刷新查询信息集合
        /// </summary>
        private void RefreshList(PairsSelectModel ssss)
        {
            if (selectInfos != null)
            {
                for (int a = selectInfos.Count - 1; a >= 0; a--)
                {
                    if (selectInfos[a].keyName == ssss.keyName)
                    {

                        selectInfos.Remove(selectInfos[a]);
                    }
                }
            }


            selectInfos.Add(ssss);
        }
        private string showhospitalinfo(string controlName)
        {
            DataTable dataTable = null;
            switch (controlName)
            {
                case "hospitalNames":
                    dataTable = WorkCommData.DTClientInfo;
                    break;
                default:
                    dataTable = null;
                    break;
            }

            FrmSelectClientInfo frmSelectInfo = new FrmSelectClientInfo(dataTable);
            Func<PairsSelectModel> func = frmSelectInfo.ReturnListString;
            frmSelectInfo.ShowDialog();
            PairsSelectModel info = func();
            //PairsInfo info = func();
            if (info != null)
            {
                info.keyName = controlName;
                RefreshList(info);
                return info.keyValue;
            }
            else
            {
                return null;
            }

        }
        private string showinfo(string controlName)
        {

            DataTable dataTable = null;
            switch (controlName)
            {
                case "agentNames":
                    dataTable = WorkCommData.DTClientAgent;
                    break;
                case "patientSexNames":
                    dataTable = WorkCommData.DTTypeSex;
                    break;
                case "sampleTypeNames":
                    dataTable = WorkCommData.DTTypeSample;
                    break;
                case "patientTypeNames":
                    dataTable = WorkCommData.DTTypePatient;
                    break;
                case "sampleShapeNames":
                    dataTable = WorkCommData.DTTypeShape;
                    break;
                case "chargeTypeNO":
                    dataTable = FinanceInfoData.DTChargeType;
                    break;
                case "groupNames":
                    dataTable = WorkCommData.DTGroupTest;
                    break;
                default:
                    dataTable = null;
                    break;
            }
            FrmSelectOtherInfo frmSelectInfo = new FrmSelectOtherInfo(dataTable);
            Func<PairsSelectModel> func = frmSelectInfo.ReturnListString;
            frmSelectInfo.ShowDialog();
            PairsSelectModel info = func();
            if (info != null)
            {
                info.keyName = controlName;
                RefreshList(info);
                return info.keyValue;
            }
            else
            {
                return null;
            }
        }

        private void BTclose_ItemClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTSelect_Click(object sender, EventArgs e)
        {
            BTSelect.Enabled = false;
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"系统提示", "查询信息请稍后......");

            SelectToolModel infos = new SelectToolModel();
            //List<PairsInfo> pairsInfos = new List<PairsInfo>();
            infos.UserName = CommonData.UserInfo.names;
            
            infos.typeName = typeNames;
            foreach (var control in layoutInfo.Items)
            {
                //PairsInfo pairs = new PairsInfo();
                string controlname = "";
                string controlkey = "";
                string controlvalue = "";

                if (control is LayoutControlItem)
                {
                    LayoutControlItem tmp = control as LayoutControlItem;
                    var first = tmp.Text;//ID,Name,Age,Adress
                    controlname = tmp.Text.Trim().Replace(" ", "").Replace(":", "");//ID,Name,Age,Adress

                    if (tmp.Control is TextEdit)
                    {
                        var aaaa = tmp.Control as TextEdit;

                        controlkey = aaaa.Name;

                        if (aaaa.EditValue != null)
                        {
                            if (controlkey.Contains("Time"))
                            {
                                controlvalue = aaaa.Text.ToString();//ID,Name,Age,Adress
                                if (controlvalue.Length > 0)
                                {
                                    switch (controlkey)
                                    {
                                        case "DEperTimeEnd":
                                            infos.perTimeEnd = controlvalue;
                                            break;
                                        case "DEperTimeStart":
                                            infos.perTimeStart = controlvalue;
                                            break;
                                        case "DEreceiveTimeEnd":
                                            infos.receiveTimeEnd = controlvalue;
                                            break;
                                        case "DEreceiveTimeStart":
                                            infos.receiveTimeStart = controlvalue;
                                            break;
                                        case "DEsampleTimeEnd":
                                            infos.sampleTimeEnd = controlvalue;
                                            break;
                                        case "DEsampleTimeStart":
                                            infos.sampleTimeStart = controlvalue;
                                            break;
                                        case "DEcheckTimeEnd":
                                            infos.checkTimeEnd = controlvalue;
                                            break;
                                        case "DEcheckTimeStart":
                                            infos.checkTimeStart = controlvalue;
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                controlvalue = aaaa.EditValue.ToString();//ID,Name,Age,Adress
                                if (!controlkey.Contains("BE"))
                                {
                                    if (controlvalue.Length > 0)
                                    {
                                        PairsSelectModel pairs = new PairsSelectModel();
                                        pairs.keyValue = controlvalue;
                                        pairs.keyName = controlkey.Substring(2);
                                        pairs.type = "2";
                                        //pairsInfos.Add(pairs);
                                        selectInfos.Add(pairs);
                                    }
                                }
                                //else
                                //{
                                //    if (controlvalue.Length > 0)
                                //    {
                                //        PairsInfo pairs = new PairsInfo();
                                //        pairs.keyValue = controlvalue;
                                //        pairs.keyName = controlkey.Substring(2);
                                //        pairs.type = "2";
                                //        pairsInfos.Add(pairs);
                                //    }
                                //}
                            }
                        }
                    }
                }
            }
            if (selectInfos.Count > 0)
                infos.PairsInfo = selectInfos;
            string Sr = Common.JsonHelper.JsonHelper.SerializeObjct(infos);
            WebApiCallBack jm = ApiHelpers.postInfo(StatisticSampleInfo, Sr);

            DataTable dataTable = Common.JsonHelper.JsonHelper.StringToDT(jm);
            selectInfoDT = dataTable;
            BTSelect.Enabled = true;
            frmWait.HideMe(this);
            this.Close();
        }
        public DataTable ReturnSelectInfo()
        {
            return selectInfoDT;
        }

        private void TEbarcode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmSelectBarcodeInfo formBarcodeInfo = new FrmSelectBarcodeInfo("");
            Func<string> func = formBarcodeInfo.reStringinfo;
            formBarcodeInfo.ShowDialog();
            TEbarcode.EditValue = func();
        }

        private void TEhospitalBarcocde_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmSelectBarcodeInfo formBarcodeInfo = new FrmSelectBarcodeInfo("");
            Func<string> func = formBarcodeInfo.reStringinfo;
            formBarcodeInfo.ShowDialog();
            TEhospitalBarcocde.EditValue = func();
        }
    }
}
