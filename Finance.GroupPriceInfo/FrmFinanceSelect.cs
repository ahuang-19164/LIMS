using Common.BLL;
using Common.Data;
using Common.FinanceModel;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

using System;
using System.Collections.Generic;
using System.Data;

namespace Finance.GroupPriceInfo
{
    public partial class FrmFinanceSelect : DevExpress.XtraEditors.XtraForm
    {
        string SelectFinanceInfo = "";
        DataTable selectInfoDT = null;
        List<PairsFinanceModel> selectInfos;
        public FrmFinanceSelect()
        {
            selectInfos = new List<PairsFinanceModel>();
            InitializeComponent();
        }

        private void FrmFinanceSelect_Load(object sender, EventArgs e)
        {
            DEperTimeStart.EditValue = DEreceiveTimeStart.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date;
            DEperTimeEnd.EditValue = DEreceiveTimeEnd.EditValue = DateTime.Now.AddDays(1 - DateTime.Now.Day).Date.AddMonths(1).AddSeconds(-1);
            SelectFinanceInfo = ConfigInfos.ReadConfigInfo("FinanceInfoSelect");
            formartButtonEdit(BEagentNames);
            formartButtonEdit(BEhospitalNames);
            formartButtonEdit(BEpatientSexNames);
            formartButtonEdit(BEsampleTypeNames);
            formartButtonEdit(BEpatientTypeNames);
            formartButtonEdit(BEsampleShapeNames);


            formartButtonEdit(BEchargeTypeNO);
            formartButtonEdit(BEgroupNames);
            formartButtonEdit(BEpersonNO);

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
        private void RefreshList(PairsFinanceModel ssss)
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
            Func<PairsFinanceModel> func = frmSelectInfo.ReturnListString;
            frmSelectInfo.ShowDialog();
            PairsFinanceModel info = func();
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
                case "personNO":
                    dataTable = DTHelper.DTVisible(CommonData.DTUserInfoAll);
                    break;
                default:
                    dataTable = null;
                    break;
            }
            FrmSelectInfo frmSelectInfo = new FrmSelectInfo(dataTable);
            Func<PairsFinanceModel> func = frmSelectInfo.ReturnListString;
            frmSelectInfo.ShowDialog();
            PairsFinanceModel info = func();
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
            commInfoModel<SelectFinanceModel> commInfo = new commInfoModel<SelectFinanceModel>();
            List<SelectFinanceModel> selectFinances = new List<SelectFinanceModel>();
            SelectFinanceModel selectPer = new SelectFinanceModel();
            //List<PairsInfoModel> pairsInfos = new List<PairsInfoModel>();
            selectPer.UserName = CommonData.UserInfo.names;


            foreach (var control in layoutInfo.Items)
            {
                //PairsInfoModel pairs = new PairsInfoModel();
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
                                            selectPer.perTimeEnd = controlvalue;
                                            break;
                                        case "DEperTimeStart":
                                            selectPer.perTimeStart = controlvalue;
                                            break;
                                        case "DEreceiveTimeEnd":
                                            selectPer.receiveTimeEnd = controlvalue;
                                            break;
                                        case "DEreceiveTimeStart":
                                            selectPer.receiveTimeStart = controlvalue;
                                            break;
                                        case "DEsampleTimeEnd":
                                            selectPer.sampleTimeEnd = controlvalue;
                                            break;
                                        case "DEsampleTimeStart":
                                            selectPer.sampleTimeStart = controlvalue;
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
                                        PairsFinanceModel pairs = new PairsFinanceModel();
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
                                //        PairsInfoModel pairs = new PairsInfoModel();
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
                selectPer.PairsInfo = selectInfos;
            selectFinances.Add(selectPer);
            commInfo.infos = selectFinances;
            string Sr = JsonHelper.SerializeObjct(commInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(SelectFinanceInfo, Sr);
            frmWait.HideMe(this);


            selectInfoDT =JsonHelper.StringToDT(jm);
            BTSelect.Enabled = true;
            this.Close();
        }
        public DataTable ReturnSelectInfo()
        {
            return selectInfoDT;
        }
    }
}
