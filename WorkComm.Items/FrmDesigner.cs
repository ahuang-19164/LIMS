using Common.BLL;
using Common.Conn;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkComm.Items
{
    public partial class FrmDesigner : XtraForm
    {
        private static string frmDatas = "";//
        public FrmDesigner(DataRow dataRow)
        {
            InitializeComponent();
            controlsInfos = new List<controlsInfo>();
            layoutControlGroup = new LayoutControlGroup();
            layoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            layoutControlGroup.GroupBordersVisible = false;
            LCForm.Root = layoutControlGroup;



            frmDr = dataRow;
            infoid = Convert.ToInt32(dataRow["id"]);
            string frmFile = dataRow["frmFile"] != DBNull.Value ? dataRow["frmFile"].ToString() : "";
            string frmData = dataRow["frmData"] != DBNull.Value ? dataRow["frmData"].ToString() : "";
            bool frmState = dataRow["frmState"] != DBNull.Value ? Convert.ToBoolean(dataRow["frmState"]) : false;
            if (frmData != "" && frmState)
            {

                //if (frmData!=frmDatas)
                //{
                controlsInfos = JsonHelper.DeserializeJsonToObject<List<controlsInfo>>(frmData);
                loadFrom(controlsInfos);
                if (frmFile != "")
                {
                    string path = Application.StartupPath + "\\flow";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    string paths = path + "\\" + frmFile;
                    if (File.Exists(paths))
                    {
                        LCForm.RestoreLayoutFromXml(paths);
                    }
                    else
                    {
                        commInfoModel<FileModel> commInfo = new commInfoModel<FileModel>();
                        List<FileModel> fileModels = new List<FileModel>();
                        FileModel FileModel = new FileModel();
                        FileModel.fileName = frmFile;
                        FileModel.fileType = "1";
                        fileModels.Add(FileModel);
                        commInfo.infos = fileModels;
                        //string sr = JsonHelper.SerializeObjct(commInfo);
                        if (ApiHelpers.PostDownFlowFile(commInfo))
                            LCForm.RestoreLayoutFromXml(paths);
                    }
                }
                frmDatas = frmData;
                //}
                //else
                //{
                //    controlsInfos = JsonHelper.DeserializeJsonToObject<List<controlsInfo>>(frmData);
                //    loadFrom(controlsInfos);
                //}

            }



        }
        int infoid = 0;
        DataRow frmDr;
        public DataRow setFrom()
        {
            return frmDr;
        }


        #region 界面功能

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LCForm.ShowCustomizationForm();
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(infoid!=0)
            {
                string newfilename = Guid.NewGuid().ToString("N") + ".xml";
                string frmData = JsonHelper.SerializeObjct(controlsInfos);
                frmDr["frmFile"] = newfilename;
                frmDr["frmData"] = frmData;
                frmDr["frmState"] = true;
                string path = Application.StartupPath + "\\flow";
                string paths = path+"\\" + newfilename;
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                if(!File.Exists(paths))
                    LCForm.SaveLayoutToXml(paths);


                uInfo uInfo = new uInfo();
                uInfo.TableName = "WorkComm.ItemFlow";
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("frmFile", newfilename);
                pairs.Add("frmData", frmData);
                pairs.Add("frmState", 1);
                uInfo.values = pairs;
                uInfo.MessageShow = 0;
                uInfo.wheres = $"id={infoid}";
                ApiHelpers.postInfo(uInfo);

                commInfoModel<FileModel> commInfo = new commInfoModel<FileModel>();
                List<FileModel> fileModes = new List<FileModel>();
                FileModel FileModel = new FileModel();
                FileModel.fileName = newfilename;
                FileModel.fileType = "1";
                FileModel.fileString = FileConverHelper.FilePathToString(paths);
                fileModes.Add(FileModel);
                commInfo.infos = fileModes;
                //string sra = JsonHelper.SerializeObjct(FileModel);
                ApiHelpers.PostUpFlowFile(commInfo);
                //a.PostBaseUpFile(sra);

            }
            else
            {
                MessageBox.Show("保存失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void BTload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Xml|*.xml";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LCForm.RestoreLayoutFromXml(openFileDialog.FileName);
                }

            }
        }

        private void 保存信息_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TEFromInfo.EditValue = JsonHelper.SerializeObjct(controlsInfos);
        }

        private void BTLoadFrm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //controlsInfos = JsonHelper.JsonConvertObject<List<controlsInfo>>(TEFromInfo.Text);
            //loadFrom(controlsInfos);
            //string path = @"C:\Users\huang\Desktop\1.xml";
            //LCForm.RestoreLayoutFromXml(path);
            //Guid guid = new Guid();
            string a = Guid.NewGuid().ToString("N");
            TEFromInfo.EditValue = a;
        }

        private void BTDeleteControl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (layoutControlItem.Control != null)
            {
                Control control = layoutControlItem.Control;
                control.Dispose();
                layoutControlGroup.Remove(layoutControlItem);
                layoutControlGroup.BestFit();
                controlsInfos.Remove(controlinfo);
                LCForm.Refresh();
            }
        }


        #endregion


        LayoutControlGroup layoutControlGroup;
        List<controlsInfo> controlsInfos;
        controlsInfo controlinfo;
        LayoutControlItem layoutControlItem;


        TextEdit textEdit;
        ComboBoxEdit comboBoxEdit;
        PictureEdit pictureEdit;
        CheckEdit checkEdit;
        DateEdit dateEdit;
        MemoEdit memoEdit;



        #region 新增控件
        private void BTAddText_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            textEdit = new TextEdit();
            for (int a = 0; a < 10000; a++)
            {
                bool aas = controlsInfos.Any((n) => n.name == "textEdit" + a);
                if (!aas)
                {
                    controlsInfo controlsInfo = new controlsInfo();
                    controlsInfo.name = "textEdit" + a;
                    controlsInfo.defaultValue = "textEdit" + a;
                    controlsInfo.type = "TextEdit";
                    controlsInfo.layoutItemName = "文本框";
                    controlsInfos.Add(controlsInfo);
                    textEdit.Name = "textEdit" + a;
                    textEdit.Text = "textEdit" + a;

                    break;
                }
            }
            layoutControlItem = new LayoutControlItem();
            layoutControlItem.Control = textEdit;
            layoutControlItem.Text = "文本框";
            layoutControlItem.Click += TextEdit_Click;
            layoutControlGroup.AddItem(layoutControlItem);
        }

        private void BTAddImg_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pictureEdit = new PictureEdit();
            for (int a = 0; a < 10000; a++)
            {
                bool aas = controlsInfos.Any((n) => n.name == "PictureEdit" + a);
                if (!aas)
                {
                    controlsInfo controlsInfo = new controlsInfo();
                    controlsInfo.name = "PictureEdit" + a;
                    controlsInfo.defaultValue = "PictureEdit" + a;
                    controlsInfo.type = "PictureEdit";
                    controlsInfo.layoutItemName = "图片框";
                    controlsInfos.Add(controlsInfo);
                    pictureEdit.Name = "PictureEdit" + a;
                    pictureEdit.Text = "PictureEdit" + a;
                    break;
                }
            }
            layoutControlItem = new LayoutControlItem();
            layoutControlItem.Control = pictureEdit;
            layoutControlItem.Text = "图片框";
            layoutControlItem.TextVisible = true;
            layoutControlItem.Click += PictureEdit_Click;
            layoutControlGroup.AddItem(layoutControlItem);
        }


        private void BTAddcom_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            comboBoxEdit = new ComboBoxEdit();
            for (int a = 0; a < 10000; a++)
            {
                bool aas = controlsInfos.Any((n) => n.name == "ComboBoxEdit" + a);
                if (!aas)
                {
                    controlsInfo controlsInfo = new controlsInfo();
                    controlsInfo.name = "ComboBoxEdit" + a;
                    controlsInfo.defaultValue = "ComboBoxEdit" + a;
                    controlsInfo.type = "ComboBoxEdit";
                    controlsInfo.layoutItemName = "下拉框";
                    List<string> sss = new List<string>
                    {
                        "aaaaa",
                        "bbbbb",
                        "CCCCC",
                        "ddddd"

                    };
                    controlsInfo.comboEditVlaues = sss;
                    controlsInfos.Add(controlsInfo);
                    comboBoxEdit.Name = "ComboBoxEdit" + a;
                    comboBoxEdit.Text = "ComboBoxEdit" + a;
                    comboBoxEdit.Properties.Items.AddRange(sss);




                    break;
                }
            }
            layoutControlItem = new LayoutControlItem();
            layoutControlItem.Control = comboBoxEdit;
            layoutControlItem.Text = "下拉框";
            layoutControlItem.TextVisible = true;
            layoutControlItem.Click += ComboBoxEdit_Click;
            layoutControlGroup.AddItem(layoutControlItem);
        }


        private void BTAddCheck_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            checkEdit = new CheckEdit();
            for (int a = 0; a < 10000; a++)
            {
                bool aas = controlsInfos.Any((n) => n.name == "CheckEdit" + a);
                if (!aas)
                {
                    controlsInfo controlsInfo = new controlsInfo();
                    controlsInfo.name = "CheckEdit" + a;
                    controlsInfo.defaultValue = "CheckEdit" + a;
                    controlsInfo.type = "CheckEdit";
                    controlsInfo.layoutItemName = "选择框";
                    controlsInfos.Add(controlsInfo);
                    checkEdit.Name = "CheckEdit" + a;
                    checkEdit.Text = "CheckEdit" + a;
                    break;
                }
            }
            layoutControlItem = new LayoutControlItem();
            layoutControlItem.Control = checkEdit;
            layoutControlItem.Text = "选择框";
            layoutControlItem.TextVisible = true;
            layoutControlItem.Click += CheckEdit_Click;
            layoutControlGroup.AddItem(layoutControlItem);
        }


        private void BTAddDateTime_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            dateEdit = new DateEdit();
            dateEdit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            dateEdit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            dateEdit.Properties.EditMask = "yyyy-MM-dd HH:mm:ss";
            for (int a = 0; a < 10000; a++)
            {
                bool aas = controlsInfos.Any((n) => n.name == "DateEdit" + a);
                if (!aas)
                {
                    controlsInfo controlsInfo = new controlsInfo();
                    controlsInfo.name = "DateEdit" + a;
                    controlsInfo.defaultValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    controlsInfo.type = "DateEdit";
                    controlsInfo.layoutItemName = "时间框";
                    controlsInfos.Add(controlsInfo);
                    dateEdit.Name = "DateEdit" + a;
                    dateEdit.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                }
            }
            layoutControlItem = new LayoutControlItem();
            layoutControlItem.Control = dateEdit;
            layoutControlItem.Text = "时间框";
            layoutControlItem.TextVisible = true;
            layoutControlItem.Click += DateEdit_Click;
            layoutControlGroup.AddItem(layoutControlItem);
        }


        private void BTAddRich_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            memoEdit = new MemoEdit();
            for (int a = 0; a < 10000; a++)
            {
                bool aas = controlsInfos.Any((n) => n.name == "MemoEdit" + a);
                if (!aas)
                {
                    controlsInfo controlsInfo = new controlsInfo();
                    controlsInfo.name = "MemoEdit" + a;
                    controlsInfo.defaultValue = "MemoEdit" + a;
                    controlsInfo.type = "MemoEdit";
                    controlsInfo.layoutItemName = "富文本框";
                    controlsInfos.Add(controlsInfo);
                    memoEdit.Name = "MemoEdit" + a;
                    memoEdit.Text = "MemoEdit" + a;
                    break;
                }
            }
            layoutControlItem = new LayoutControlItem();
            layoutControlItem.Control = memoEdit;
            layoutControlItem.Text = "富文本框";
            layoutControlItem.TextVisible = true;
            layoutControlItem.Click += MemoEdit_Click;
            layoutControlGroup.AddItem(layoutControlItem);
        }


        #endregion


        #region 选择控件

        private void resetcolor()
        {
            foreach (LayoutControlItem item in layoutControlGroup.Items)
            {
                item.AppearanceItemCaption.BackColor = System.Drawing.Color.Transparent;
            }

        }

        private void TextEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            textEdit = layoutControlItem.Control as TextEdit;
            TECname.Text = controlinfo.name;
            TECdefult.Text = controlinfo.defaultValue;
            TElayoutName.Text = controlinfo.layoutItemName;
            TECdicName.Text = controlinfo.dicName;
            TECdicType.Text = controlinfo.dicType;
            BECominfo.Text = "";
            CECe.Checked = controlinfo.enabled;
            CECv.Checked = controlinfo.visible;
            CECheckState.Checked = false;
            TECcolumn.Text = controlinfo.Tag;
            BECominfo.Enabled = false;
            CECheckState.Enabled = false;
            TECdicName.Enabled = true;
            TECdicType.Enabled = true;

        }

        private void PictureEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            pictureEdit = layoutControlItem.Control as PictureEdit;
            TECname.Text = controlinfo.name;
            TECdefult.Text = controlinfo.defaultValue;
            TElayoutName.Text = controlinfo.layoutItemName;
            TECdicName.Text = "";
            TECdicType.Text = "";
            BECominfo.Text = "";
            CECe.Checked = controlinfo.enabled;
            CECv.Checked = controlinfo.visible;
            CECheckState.Checked = false;
            TECcolumn.Text = controlinfo.Tag;

            BECominfo.Enabled = false;
            CECheckState.Enabled = false;
            TECdicName.Enabled = false;
            TECdicType.Enabled = false;
        }

        private void ComboBoxEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            comboBoxEdit= layoutControlItem.Control as ComboBoxEdit;
            //if (controlinfo != null)
            //{
            TECname.Text = controlinfo.name;
            TECdefult.Text = controlinfo.defaultValue;
            TElayoutName.Text = controlinfo.layoutItemName;
            TECdicName.Text = "";
            TECdicType.Text = "";
            string a = "";
            if (controlinfo.comboEditVlaues != null && controlinfo.comboEditVlaues.Count > 0)
            {
                foreach (string s in controlinfo.comboEditVlaues)
                {
                    a += s + ",";
                }
                BECominfo.Text = a.Substring(0, a.Length - 1);
            }
            CECe.Checked = controlinfo.enabled;
            CECv.Checked = controlinfo.visible;
            CECheckState.Checked = false;
            TECcolumn.Text = controlinfo.Tag;

            BECominfo.Enabled = true;
            CECheckState.Enabled = false;
            TECdicName.Enabled = false;
            TECdicType.Enabled = false;
        }

        private void CheckEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            checkEdit = layoutControlItem.Control as CheckEdit;
            TECname.Text = controlinfo.name;
            TECdefult.Text = controlinfo.defaultValue;
            TElayoutName.Text = controlinfo.layoutItemName;
            TECdicName.Text = "";
            TECdicType.Text = "";
            BECominfo.Text = "";
            CECe.Checked = controlinfo.enabled;
            CECv.Checked = controlinfo.visible;
            CECheckState.Checked = controlinfo.check;
            TECcolumn.Text = controlinfo.Tag;

            BECominfo.Enabled = false;
            CECheckState.Enabled = true;
            TECdicName.Enabled = false;
            TECdicType.Enabled = false;
        }
        private void DateEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            dateEdit = layoutControlItem.Control as DateEdit;
            TECname.Text = controlinfo.name;
            TECdefult.Text = controlinfo.defaultValue;
            TElayoutName.Text = controlinfo.layoutItemName;
            TECdicName.Text = "";
            TECdicType.Text = "";
            BECominfo.Text = "";
            CECe.Checked = controlinfo.enabled;
            CECv.Checked = controlinfo.visible;
            CECheckState.Checked = false;
            TECcolumn.Text = controlinfo.Tag;

            BECominfo.Enabled = false;
            CECheckState.Enabled = false;
            TECdicName.Enabled = false;
            TECdicType.Enabled = false;
        }

        private void MemoEdit_Click(object sender, EventArgs e)
        {
            layoutControlItem = sender as LayoutControlItem;
            resetcolor();
            layoutControlItem.AppearanceItemCaption.BackColor = System.Drawing.Color.Silver;
            controlinfo = controlsInfos.First((n) => n.name == layoutControlItem.Control.Name);
            memoEdit = layoutControlItem.Control as MemoEdit;
            TECname.Text = controlinfo.name;
            TECdefult.Text = controlinfo.defaultValue;
            TElayoutName.Text = controlinfo.layoutItemName;
            TECdicName.Text = controlinfo.dicName;
            TECdicType.Text = controlinfo.dicType;
            BECominfo.Text = "";
            CECe.Checked = controlinfo.enabled;
            CECv.Checked = controlinfo.visible;
            CECheckState.Checked = false;
            TECcolumn.Text = controlinfo.Tag;

            BECominfo.Enabled = false;
            CECheckState.Enabled = false;
            TECdicName.Enabled = true;
            TECdicType.Enabled = true;

        }

        #endregion

        #region 控件其他功能


        //combobox添加内容
        private void BECominfo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            FrmComboEditValues formBarcodeInfo = new FrmComboEditValues(BECominfo.Text);
            Func<string> func = formBarcodeInfo.reStringinfo;
            formBarcodeInfo.ShowDialog();
            string ss = func();
            BECominfo.EditValue = ss;
            if (ss != "")
            {
                string[] ssss = BECominfo.EditValue.ToString().Split(',');
                controlinfo.comboEditVlaues = ssss.ToList();
                comboBoxEdit.Properties.Items.Clear();
                comboBoxEdit.Properties.Items.AddRange(ssss);
            }
            else
            {
                controlinfo.comboEditVlaues = null;
                comboBoxEdit.Properties.Items.Clear();
            }

        }


        //开启摄像头
        private void PictureEditEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                PictureEdit Edit = sender as PictureEdit;
                Edit.ShowTakePictureDialog();
            }
        }
        ////
        //private void PictureEditEdit_Click(object sender, EventArgs e)
        //{
        //    PictureEdit Edit = sender as PictureEdit;
        //    Edit.ShowTakePictureDialog();

        //}
        //打开图片编辑器
        private void PictureEditEdit_DoubleClick(object sender, EventArgs e)
        {
            PictureEdit Edit = sender as PictureEdit;
            //Edit.ImageEditorDialogShowing();
            Edit.ShowImageEditorDialog();
        }

        #endregion


        #region 编辑属性

        private void TElayoutName_EditValueChanged(object sender, EventArgs e)
        {
            if (TElayoutName.EditValue != null && TElayoutName.EditValue.ToString().Trim() != "")
            {
                controlinfo.layoutItemName = TElayoutName.EditValue.ToString();
                layoutControlItem.Text = TElayoutName.EditValue.ToString();
            }
        }
        private void TECname_EditValueChanged(object sender, EventArgs e)
        {
            if (TECname.EditValue != null && TECname.EditValue.ToString().Trim() != "")
            {
                controlinfo.name = TECname.EditValue.ToString();
                layoutControlItem.Control.Name = TECname.EditValue.ToString();
            }
        }
        private void TECname_Leave(object sender, EventArgs e)
        {

        }

        private void TECdefult_Leave(object sender, EventArgs e)
        {
            if (controlinfo.type != "DateEdit")
            {
                if (TECdefult.EditValue != null && TECdefult.EditValue.ToString().Trim() != "")
                {

                    controlinfo.defaultValue = TECdefult.EditValue.ToString();
                    layoutControlItem.Control.Text = TECdefult.EditValue.ToString();
                }
            }
            else
            {
                try
                {
                    if (TECdefult.EditValue != null && TECdefult.EditValue.ToString().Trim() != "")
                    {
                        Convert.ToDateTime(TECdefult.EditValue.ToString());
                        controlinfo.defaultValue = TECdefult.EditValue.ToString();
                        layoutControlItem.Control.Text = TECdefult.EditValue.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("时间控件显示信息必须为时间格式", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TECdefult.Focus();
                    TECdefult.SelectAll();
                }

            }
        }
        private void TECdefult_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void CECe_CheckedChanged(object sender, EventArgs e)
        {
            controlinfo.enabled = CECe.Checked;
            //layoutControlItem.Control.Text = TECdefult.EditValue.ToString();
        }

        private void CECv_CheckedChanged(object sender, EventArgs e)
        {
            controlinfo.visible = CECv.Checked;
        }

        private void CECheckState_CheckedChanged(object sender, EventArgs e)
        {
            controlinfo.check = CECheckState.Checked;
        }
        private void TECcolumn_EditValueChanged(object sender, EventArgs e)
        {
            if (TECcolumn.EditValue != null && TECcolumn.EditValue.ToString().Trim() != "")
            {
                controlinfo.Tag = TECcolumn.EditValue.ToString();
                //layoutControlItem.Control.Name = TECname.EditValue.ToString();
            }
        }

        private void TECdicName_EditValueChanged(object sender, EventArgs e)
        {
            if (TECdicName.EditValue != null && TECdicName.EditValue.ToString().Trim() != "")
            {
                controlinfo.dicName = TECdicName.EditValue.ToString();
                //layoutControlItem.Control.Name = TECname.EditValue.ToString();
            }
        }

        private void TECdicType_EditValueChanged(object sender, EventArgs e)
        {
            if (TECdicType.EditValue != null && TECdicType.EditValue.ToString().Trim() != "")
            {
                controlinfo.dicType = TECdicType.EditValue.ToString();
                //layoutControlItem.Control.Name = TECname.EditValue.ToString();
            }
        }

        #endregion



        # region 构建窗体方法

        public void loadFrom(List<controlsInfo> controlsInfos)
        {
            LCForm.Controls.Clear();
            foreach (controlsInfo controlinfo in controlsInfos)
            {
                //加载文本框
                if (controlinfo.type == "TextEdit")
                {
                    TextEdit Edit = new TextEdit();
                    Edit.Name = controlinfo.name;
                    Edit.Text = controlinfo.defaultValue;
                    Edit.Enabled = controlinfo.enabled;
                    Edit.Visible = controlinfo.visible;
                    Edit.Tag = controlinfo.dicName + "," + controlinfo.dicType;
                    Edit.ToolTip = controlinfo.Tag;
                    //Edit.Tag = controlinfo.dicName + "," + controlinfo.dicName;
                    MemoEdits.AddDoubleMethod(Edit);

                    LayoutControlItem layoutControlItem = new LayoutControlItem();
                    layoutControlItem.Control = Edit;
                    layoutControlItem.Text = controlinfo.layoutItemName;
                    layoutControlItem.Click += TextEdit_Click;
                    layoutControlItem.TextVisible = true;
                    layoutControlGroup.AddItem(layoutControlItem);
                }
                //加载图片框
                if (controlinfo.type == "PictureEdit")
                {
                    PictureEdit Edit = new PictureEdit();
                    Edit.Name = controlinfo.name;
                    Edit.Text = controlinfo.defaultValue;
                    //Edit.KeyDown += Edit_Click;
                    Edit.KeyPress += PictureEditEdit_KeyPress; ;
                    Edit.DoubleClick += PictureEditEdit_DoubleClick;
                    Edit.Properties.SizeMode = PictureSizeMode.Zoom;
                    Edit.Enabled = controlinfo.enabled;
                    Edit.Visible = controlinfo.visible;
                    Edit.Tag = controlinfo.Tag;
                    Edit.ToolTip = controlinfo.Tag;


                    //Edit.Click += Edit_Click;
                    LayoutControlItem layoutControlItem = new LayoutControlItem();
                    layoutControlItem.Control = Edit;
                    layoutControlItem.Text = controlinfo.layoutItemName;
                    layoutControlItem.Click += PictureEdit_Click;
                    layoutControlItem.TextVisible = true;
                    layoutControlGroup.AddItem(layoutControlItem);
                }

                //加载下拉框
                if (controlinfo.type == "ComboBoxEdit")
                {
                    ComboBoxEdit Edit = new ComboBoxEdit();
                    Edit.Name = controlinfo.name;
                    Edit.Text = controlinfo.defaultValue;
                    Edit.Properties.Items.AddRange(controlinfo.comboEditVlaues);
                    Edit.Enabled = controlinfo.enabled;
                    Edit.Visible = controlinfo.visible;
                    Edit.Tag = controlinfo.Tag;
                    Edit.ToolTip = controlinfo.Tag;


                    LayoutControlItem layoutControlItem = new LayoutControlItem();
                    layoutControlItem.Control = Edit;
                    layoutControlItem.Text = controlinfo.layoutItemName;
                    layoutControlItem.Click += ComboBoxEdit_Click;
                    layoutControlItem.TextVisible = true;
                    layoutControlGroup.AddItem(layoutControlItem);
                }
                //加载选择框
                if (controlinfo.type == "CheckEdit")
                {
                    CheckEdit Edit = new CheckEdit();
                    Edit.Name = controlinfo.name;
                    Edit.Text = controlinfo.defaultValue;
                    Edit.Checked = controlinfo.check;
                    Edit.Enabled = controlinfo.enabled;
                    Edit.Visible = controlinfo.visible;
                    Edit.Tag = controlinfo.Tag;
                    Edit.ToolTip = controlinfo.Tag;


                    LayoutControlItem layoutControlItem = new LayoutControlItem();
                    layoutControlItem.Control = Edit;
                    layoutControlItem.Text = controlinfo.layoutItemName;
                    layoutControlItem.Click += CheckEdit_Click;
                    layoutControlItem.TextVisible = true;
                    layoutControlGroup.AddItem(layoutControlItem);
                }
                //加载时间框
                if (controlinfo.type == "DateEdit")
                {
                    DateEdit Edit = new DateEdit();
                    Edit.Name = controlinfo.name;
                    Edit.Text = controlinfo.defaultValue;
                    Edit.Enabled = controlinfo.enabled;
                    Edit.Visible = controlinfo.visible;
                    Edit.Tag = controlinfo.Tag;
                    Edit.ToolTip = controlinfo.Tag;
                    Edit.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    Edit.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                    Edit.Properties.EditMask = "yyyy-MM-dd HH:mm:ss";

                    LayoutControlItem layoutControlItem = new LayoutControlItem();
                    layoutControlItem.Control = Edit;
                    layoutControlItem.Text = controlinfo.layoutItemName;
                    layoutControlItem.Click += DateEdit_Click;
                    layoutControlItem.TextVisible = true;
                    layoutControlGroup.AddItem(layoutControlItem);
                }
                //加载富文本框
                if (controlinfo.type == "MemoEdit")
                {
                    MemoEdit Edit = new MemoEdit();
                    Edit.Name = controlinfo.name;
                    Edit.Text = controlinfo.defaultValue;

                    Edit.Enabled = controlinfo.enabled;
                    Edit.Visible = controlinfo.visible;
                    //Edit.Tag = controlinfo.Tag;
                    Edit.ToolTip = controlinfo.Tag;
                    Edit.Tag = controlinfo.dicName + "," + controlinfo.dicType;
                    MemoEdits.AddDoubleMethod(Edit);

                    LayoutControlItem layoutControlItem = new LayoutControlItem();
                    layoutControlItem.Control = Edit;
                    layoutControlItem.Text = controlinfo.layoutItemName;
                    layoutControlItem.Click += MemoEdit_Click;
                    layoutControlItem.TextVisible = true;
                    layoutControlGroup.AddItem(layoutControlItem);
                }

            }

        }

        private void BTClear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            controlsInfos.Clear();
            LCForm.Clear();
        }
        #endregion

















        ////加载文本框
        //if (controlinfo.type == "TextEdit")
        //{
        //if (TECname.EditValue != null && TECname.EditValue.ToString().Trim() != "")
        //{
        //    controlinfo.layoutItemName = TECname.EditValue.ToString();
        //    layoutControlItem.Text= TECname.EditValue.ToString();

        //}
        //}
        ////加载图片框
        //if (controlinfo.type == "PictureEdit")
        //{
        //    PictureEdit Edit = new PictureEdit();
        //    Edit.Name = controlinfo.name;
        //    Edit.Text = controlinfo.defaultValue;
        //    layoutControlItem = new LayoutControlItem();
        //    layoutControlItem.Control = Edit;
        //    layoutControlItem.Text = "图片框";
        //    layoutControlItem.Click += PictureEdit_Click;
        //    layoutControlGroup.AddItem(layoutControlItem);
        //}

        ////加载图片框
        //if (controlinfo.type == "ComboBoxEdit")
        //{
        //    ComboBoxEdit Edit = new ComboBoxEdit();
        //    Edit.Name = controlinfo.name;
        //    Edit.Text = controlinfo.defaultValue;
        //    layoutControlItem = new LayoutControlItem();
        //    layoutControlItem.Control = Edit;
        //    layoutControlItem.Text = "下拉框";
        //    layoutControlItem.Click += ComboBoxEdit_Click;
        //    layoutControlGroup.AddItem(layoutControlItem);
        //}
        ////加载选择框
        //if (controlinfo.type == "CheckEdit")
        //{
        //    CheckEdit Edit = new CheckEdit();
        //    Edit.Name = controlinfo.name;
        //    Edit.Text = controlinfo.defaultValue;
        //    layoutControlItem = new LayoutControlItem();
        //    layoutControlItem.Control = Edit;
        //    layoutControlItem.Text = "选择框";
        //    layoutControlItem.Click += CheckEdit_Click;
        //    layoutControlGroup.AddItem(layoutControlItem);
        //}
        ////加载时间框
        //if (controlinfo.type == "DateEdit")
        //{
        //    DateEdit Edit = new DateEdit();
        //    Edit.Name = controlinfo.name;
        //    Edit.Text = controlinfo.defaultValue;
        //    //textEdit.Properties.Items.Add(controlinfo.comboEditVlaues);
        //    layoutControlItem = new LayoutControlItem();
        //    layoutControlItem.Control = Edit;
        //    layoutControlItem.Text = "时间框";
        //    layoutControlItem.Click += DateEdit_Click;
        //    layoutControlGroup.AddItem(layoutControlItem);
        //}
        ////加载时间框
        //if (controlinfo.type == "MemoEdit")
        //{
        //    MemoEdit Edit = new MemoEdit();
        //    Edit.Name = controlinfo.name;
        //    Edit.Text = controlinfo.defaultValue;
        //    //textEdit.Properties.Items.Add(controlinfo.comboEditVlaues);
        //    layoutControlItem = new LayoutControlItem();
        //    layoutControlItem.Control = Edit;
        //    layoutControlItem.Text = "富文本框";
        //    layoutControlItem.Click += MemoEdit_Click;
        //    layoutControlGroup.AddItem(layoutControlItem);
        //}
        //}






    }
}
public class controlsInfo
{
    /// <summary>
    /// layoutItem名称
    /// </summary>
    public string layoutItemName { get; set; }
    /// <summary>
    /// 控件名称
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// 控件绑定字段名称
    /// </summary>
    public string Tag { get; set; }

    /// <summary>
    /// 控件类型
    /// </summary>
    public string type { get; set; }
    /// <summary>
    /// 默认值
    /// </summary>
    public string defaultValue { get; set; }
    /// <summary>
    /// 是否选择
    /// </summary>
    public bool check { get; set; }
    /// <summary>
    /// 是否可编辑
    /// </summary>
    public bool enabled { get; set; } = true;
    /// <summary>
    /// 是否显示
    /// </summary>
    public bool visible { get; set; } = true;
    /// <summary>
    /// 下拉框值
    /// </summary>
    public List<string> comboEditVlaues { get; set; }

    /// <summary>
    /// 绑定字典
    /// </summary>
    public string dicName { get; set; }
    /// <summary>
    /// 绑定字典类型
    /// </summary>
    public string dicType { get; set; }
}