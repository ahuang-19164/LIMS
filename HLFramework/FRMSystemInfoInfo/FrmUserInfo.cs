using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmUserInfo : DevExpress.XtraEditors.XtraForm
    {
        
        string tableName = "Common.UserInfo";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        public FrmUserInfo()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GroupInfo.Enabled = false;
            PEImg.DoubleClick += PEImg_DoubleClick;
            GridLookUpEdites.Formats(GECompanyNO);
            GridLookUpEdites.Formats(GEDepartmentNO);
            GridLookUpEdites.Formats(GERoleNO);
            GridLookUpEdites.Formats(GEWebRoleNO);
            GridLookUpEdites.Formats(RGEcompanyNO);
            GridLookUpEdites.Formats(RGEdepartmentNO);
            GridControls.formartGridView(GVInfo);

            TextEdits.TextFormat(TESort);
            DataTable SexDT = new DataTable();
            SexDT.Columns.Add("名称", typeof(string));
            SexDT.Rows.Add("男");
            SexDT.Rows.Add("女");
            SexDT.Rows.Add("/");
            LESex.Properties.DataSource = SexDT;
            LESex.Properties.ValueMember = "名称";
            LESex.Properties.DisplayMember = "名称";


        }

        private void PEImg_DoubleClick(object sender, EventArgs e)
        {
            PEImg.ShowImageEditorDialog();
        }

        private void FrmUserInfo_Load(object sender, EventArgs e)
        {
            RGEdepartmentNO.DataSource = CommonData.DTDepertmentInfoAll;
            RGEcompanyNO.DataSource = CommonData.DTCommonyInfoAll;
            if (CommonData.DTCommonyInfoAll != null)
            {
                if (CommonData.DTCommonyInfoAll.Select("state=1 and dstate=0").Count() > 0)
                {
                    GECompanyNO.Properties.DataSource = CommonData.DTCommonyInfoAll.Select("state=1 and dstate=0").CopyToDataTable();
                }
            }
            if (CommonData.DTDepertmentInfoAll != null)
            {
                if (CommonData.DTDepertmentInfoAll.Select("state=1 and dstate=0").Count() > 0)
                {
                    GEDepartmentNO.Properties.DataSource = CommonData.DTDepertmentInfoAll.Select("state=1 and dstate=0").CopyToDataTable();
                }
            }
            if (CommonData.DTRoleInfoAll != null)
            {
                if (CommonData.DTRoleInfoAll.Select("state=1 and dstate=0").Count() > 0)
                {
                    GERoleNO.Properties.DataSource = CommonData.DTRoleInfoAll.Select("state=1 and dstate=0").CopyToDataTable();
                }
            }
            if (CommonData.DTWebRoleInfoAll != null)
            {

                if (CommonData.DTWebRoleInfoAll.Select("state=1 and dstate=0").Count() > 0)
                {
                    GEWebRoleNO.Properties.DataSource = CommonData.DTWebRoleInfoAll.Select("state=1 and dstate=0").CopyToDataTable();
                }
            }

            GCInfo.DataSource = CommonData.DTUserInfoAll;


            GVInfo.ExpandAllGroups();
            GVInfo.BestFitColumns();
        }
        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {
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

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 1;
            GroupInfo.Enabled = true;
            if (CommonData.DTUserInfoAll != null)
            {
                if (CommonData.DTUserInfoAll.Select("no is not NULL", "no DESC").Count() == 0)
                {
                    TENO.EditValue = 1;
                }
                else
                {
                    TENO.EditValue = Convert.ToInt32(CommonData.DTUserInfoAll.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
                }
            }
            else
            {
                TENO.EditValue = 1;
            }

            TEUserNO.Enabled = true;
            TEUserNO.EditValue = "";
            TEName.EditValue = "";
            TEShortNames.EditValue = "";
            GECompanyNO.EditValue = "";
            GEDepartmentNO.EditValue = "";
            GERoleNO.EditValue = "";
            GEWebRoleNO.EditValue = "";
            TESort.EditValue = "";
            TEPwd.EditValue = "Abc123!";
            LESex.EditValue = "";
            TEBirthday.EditValue = "";
            TEPhone.EditValue = "";
            TEEmail.EditValue = "";
            TEWorkPhone.EditValue = "";
            TEWeChat.EditValue = "";
            TERemark.EditValue = "";
            CBState.Checked = false;
            CBwebstate.Checked = false;
            SelectValueID = 0;
            PEImg.Image = bitmaps = null;

        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditState = 2;
            GroupInfo.Enabled = true;
            TEUserNO.Enabled = false;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(TEPwd.EditValue==null&& TEPwd.EditValue.ToString().Trim().Length==0)
            {
                MessageBox.Show("账号密码不能为空！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // 密码至少要包含6个字符，同时包含至少一个大写字母、一个小写字母、一个数字和一个特殊字符
                string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$";
                if (!Regex.IsMatch(TEPwd.EditValue.ToString(), pattern))
                {
                    MessageBox.Show("密码格式错误！\r\n（密码至少要包含6个字符，同时包含至少一个大写字母、一个小写字母、一个数字和一个特殊字符）", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (EditState == 1)
                {
                    DataRow[] rows = CommonData.DTUserInfoAll.Select($"id='{TENO.EditValue}'");
                    if (rows.Count() == 0)
                    {
                        Dictionary<string, object> pairs = new Dictionary<string, object>();
                        pairs.Add("no", TENO.EditValue);
                        pairs.Add("userNO", TEUserNO.EditValue);
                        pairs.Add("names", TEName.EditValue);
                        pairs.Add("shortNames", TEShortNames.EditValue);
                        pairs.Add("companyNO", GECompanyNO.EditValue);
                        pairs.Add("departmentNO", GEDepartmentNO.EditValue);
                        pairs.Add("roleNO", GERoleNO.EditValue);
                        pairs.Add("webRoleNO", GEWebRoleNO.EditValue);
                        pairs.Add("sort", TESort.EditValue);
                        pairs.Add("pwd", TEPwd.EditValue);
                        pairs.Add("sex", LESex.EditValue);
                        pairs.Add("birthday", TEBirthday.EditValue);
                        pairs.Add("phone", TEPhone.EditValue);
                        pairs.Add("email", TEEmail.EditValue);
                        pairs.Add("workPhone", TEWorkPhone.EditValue);
                        pairs.Add("weChat", TEWeChat.EditValue);
                        pairs.Add("remark", TERemark.EditValue);
                        pairs.Add("state", CBState.Checked);
                        pairs.Add("webstate", CBwebstate.Checked);

                        iInfo insertInfo = new iInfo();
                        insertInfo.TableName = tableName;
                        insertInfo.values = pairs;
                        int a = ApiHelpers.postInfo(insertInfo);



                        iInfo insertInfoimg = new iInfo();
                        insertInfoimg.MessageShow = 1;
                        Dictionary<string, object> pairsimg = new Dictionary<string, object>();
                        pairsimg.Add("userNO", TENO.EditValue);
                        pairsimg.Add("userNames", TEName.EditValue);
                        pairsimg.Add("filestring", FileConverHelpers.BitmapTostring(bitmaps));
                        pairsimg.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        pairsimg.Add("state", 1);
                        insertInfoimg.values = pairsimg;
                        insertInfoimg.TableName = "Common.UserImg";
                        a = ApiHelpers.postInfo(insertInfoimg);

                    }
                    else
                    {
                        MessageBox.Show("用户名已存在,请使用其他用户名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (SelectValueID != 0)
                    {
                        if (EditState == 2)
                        {



                            Dictionary<string, object> pairs = new Dictionary<string, object>();
                            //pairs.Add("no", TENO.EditValue);
                            pairs.Add("userNO", TEUserNO.EditValue);
                            pairs.Add("names", TEName.EditValue);
                            pairs.Add("shortNames", TEShortNames.EditValue);
                            pairs.Add("companyNO", GECompanyNO.EditValue);
                            pairs.Add("departmentNO", GEDepartmentNO.EditValue);
                            pairs.Add("roleNO", GERoleNO.EditValue);
                            pairs.Add("webRoleNO", GEWebRoleNO.EditValue);
                            pairs.Add("sort", TESort.EditValue);
                            pairs.Add("pwd", TEPwd.EditValue);
                            pairs.Add("sex", LESex.EditValue);
                            pairs.Add("birthday", TEBirthday.EditValue);
                            pairs.Add("phone", TEPhone.EditValue);
                            pairs.Add("email", TEEmail.EditValue);
                            pairs.Add("workPhone", TEWorkPhone.EditValue);
                            pairs.Add("weChat", TEWeChat.EditValue);
                            pairs.Add("remark", TERemark.EditValue);
                            pairs.Add("state", CBState.Checked);
                            pairs.Add("webstate", CBwebstate.Checked);
                            uInfo updateInfo = new uInfo();
                            updateInfo.TableName = tableName;
                            updateInfo.values = pairs;
                            updateInfo.DataValueID = SelectValueID;
                            int a = ApiHelpers.postInfo(updateInfo);

                            uInfo updateInfoImg = new uInfo();
                            updateInfoImg.MessageShow = 1;
                            Dictionary<string, object> pairsimg = new Dictionary<string, object>();
                            //pairsimg.Add("userNO", TENO.EditValue);
                            pairsimg.Add("userNames", TEName.EditValue);
                            pairsimg.Add("filestring", FileConverHelpers.BitmapTostring(bitmaps));
                            pairsimg.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            pairsimg.Add("state", 1);
                            updateInfoImg.values = pairsimg;
                            updateInfoImg.wheres = $"userNO='{TENO.EditValue}'";
                            updateInfoImg.TableName = "Common.UserImg";
                            a = ApiHelpers.postInfo(updateInfoImg);
                        }
                    }
                }
                EditState = 0;
                //CommonDataRefresh commSystem = new CommonDataRefresh();
                CommonDataRefresh.GetUserInfo();
                //CommonDataRefresh.GetUserImg();
                GCInfo.DataSource = CommonData.DTUserInfoAll;
                GroupInfo.Enabled = false;
                GVInfo.ExpandAllGroups();
            }
 


        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            if (EditState != 1)
            {
                DataRow dataRow = GVInfo.GetFocusedDataRow();
                if (dataRow != null)
                {
                    SelectValueID = Convert.ToInt32(dataRow["id"]);
                    TENO.EditValue = dataRow["no"];
                    TEUserNO.EditValue = dataRow["userNO"];
                    TEName.EditValue = dataRow["names"];
                    TEShortNames.EditValue = dataRow["shortNames"];
                    GECompanyNO.EditValue = dataRow["companyNO"];
                    GEDepartmentNO.EditValue = dataRow["departmentNO"];
                    GERoleNO.EditValue = dataRow["roleNO"];
                    GEWebRoleNO.EditValue = dataRow["webRoleNO"];
                    TESort.EditValue = dataRow["sort"];
                    TEPwd.EditValue = dataRow["pwd"];
                    LESex.EditValue = dataRow["sex"];
                    TEBirthday.EditValue = dataRow["birthday"];
                    TEPhone.EditValue = dataRow["phone"];
                    TEEmail.EditValue = dataRow["email"];
                    TEWorkPhone.EditValue = dataRow["workPhone"];
                    TEWeChat.EditValue = dataRow["weChat"];
                    TERemark.EditValue = dataRow["remark"];
                    CBState.Checked=dataRow["state"]!= DBNull.Value ? Convert.ToBoolean(Convert.ToBoolean(Convert.ToBoolean(dataRow["state"]))) : false;
                    CBwebstate.Checked = dataRow["webstate"] != DBNull.Value ? Convert.ToBoolean(Convert.ToBoolean(Convert.ToBoolean(dataRow["webstate"]))) : false;;

                    sInfo selectimg = new sInfo();
                    selectimg.values = "filestring";
                    selectimg.TableName = "Common.UserImg";
                    selectimg.wheres = $"userNO='{ dataRow["no"]}' and state=1";
                    DataTable dt = ApiHelpers.postInfo(selectimg);
                    if (dt != null&&dt.Rows.Count>0)
                    {
                        PEImg.Image = bitmaps = dt.Rows[0][0] != DBNull.Value ? FileConverHelpers.StringToBitmap(dt.Rows[0][0].ToString()) : null;
                    }
                    else
                    {
                        PEImg.Image = bitmaps = null;
                    }
                }
            }
        }
        /// <summary>
        /// CheckBox联动方法
        /// </summary>
        public void CBboxlinkage()
        {
            if (GECompanyNO.EditValue != null)
            {
                if (CommonData.DTDepertmentInfoAll != null && CommonData.DTDepertmentInfoAll.Select($"companyNO='{GECompanyNO.EditValue}'").Count() > 0)
                {
                    GEDepartmentNO.Properties.DataSource = CommonData.DTDepertmentInfoAll.Select($"companyNO='{GECompanyNO.EditValue}'").CopyToDataTable();
                }
                else
                {
                    GEDepartmentNO.Properties.DataSource = null;
                }

            }
            else
            {
                GEDepartmentNO.Properties.DataSource = null;
            }
            if (GEDepartmentNO.EditValue != null)
            {
                if (CommonData.DTRoleInfoAll != null && CommonData.DTRoleInfoAll.Select($"departmentNO='{GEDepartmentNO.EditValue}'").Count() > 0)
                {
                    GERoleNO.Properties.DataSource = CommonData.DTRoleInfoAll.Select($"departmentNO='{GEDepartmentNO.EditValue}'").CopyToDataTable();
                    //GEWebRoleNO.Properties.DataSource = CommonData.DTWebRoleInfoAll.Select($"companyNO='{GEDepartmentNO.EditValue}'").CopyToDataTable();
                }
                else
                {
                    GERoleNO.Properties.DataSource = null;
                    //GEWebRoleNO.Properties.DataSource = null;
                }
                if (CommonData.DTWebRoleInfoAll != null && CommonData.DTWebRoleInfoAll.Select($"departmentNO='{GEDepartmentNO.EditValue}'").Count() > 0)
                {
                    //GERoleNO.Properties.DataSource = CommonData.DTRoleInfoAll.Select($"companyNO='{GEDepartmentNO.EditValue}'").CopyToDataTable();
                    GEWebRoleNO.Properties.DataSource = CommonData.DTWebRoleInfoAll.Select($"departmentNO='{GEDepartmentNO.EditValue}'").CopyToDataTable();
                }
                else
                {
                    //GERoleNO.Properties.DataSource = null;
                    GEWebRoleNO.Properties.DataSource = null;
                }

            }
            else
            {
                GERoleNO.Properties.DataSource = null;
                GEWebRoleNO.Properties.DataSource = null;
            }
        }
        private void GECompanyNO_EditValueChanged(object sender, EventArgs e)
        {
            CBboxlinkage();
        }

        private void GEDepartmentNO_EditValueChanged(object sender, EventArgs e)
        {
            CBboxlinkage();
        }

        private void GERoleNO_EditValueChanged(object sender, EventArgs e)
        {
            CBboxlinkage();
        }
        private void TEName_Leave(object sender, EventArgs e)
        {
            TEShortNames.EditValue = ConvertShortName.GetChineseSpell(TEName.EditValue.ToString());
        }
        Bitmap bitmaps;
        private void BTUpImg_Click(object sender, EventArgs e)
        {
            string filepath = OpenFileHelpers.GetFilePath();
            if (filepath != "")
            {
                PEImg.Image = bitmaps = ImageCompressHelper.SizeImage(FileConverHelpers.FilePathToBitmap(filepath), 150);
            }
        }

        private void BTClaer_Click(object sender, EventArgs e)
        {
            PEImg.Image = bitmaps = null;
        }

        private void BTDelectCompany_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                int a = DeleteHelper.hideinfo(SelectValueID, tableName);
                if (a > 0)
                {
                    CommonDataRefresh.GetUserInfo();
                    GVInfo.DeleteSelectedRows();
                }
            }
        }


    }
}
