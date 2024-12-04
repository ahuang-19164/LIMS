using Common.BLL;
using Common.Conn;
using Common.Data;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HLFramework
{
    public partial class FrmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {

        Dictionary<string, XtraTabPage> dictXtraTabPage = new Dictionary<string, XtraTabPage>();
        Dictionary<string, Form> dictXtraForm = new Dictionary<string, Form>();
        Dictionary<string, MethodInfo> FormMethods = new Dictionary<string, MethodInfo>();
        string UpFileHandle = "";
        string MessageInfo = "";
        string RefreshToken = "";


        public FrmMain()
        {
            UpFileHandle = ConfigInfos.ReadConfigInfo("GetUpgradeInfos");
            MessageInfo = ConfigInfos.ReadConfigInfo("MessageInfo");
            RefreshToken = ConfigInfos.ReadConfigInfo("RefreshToken");
            InitializeComponent();
            BTVersion.Caption = Application.CompanyName.ToString() + CommonData.version + "\n";
            ShowRibbinPage();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            //显示关闭框
            xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InTabControlHeader;
            FrmShowDashboard();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            BTUserInfo.Caption ="当前用户："+ CommonData.UserInfo.names;
            BTUserInfos.Caption ="当前用户："+ CommonData.UserInfo.names;
            //ribbonControl1.AllowMdiChildButtons = false;
            //ribbonControl1.Minimized = true;
        }

        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {
            string[] PowerList = CommonData.powerList;
            if (CommonData.UserInfo.id != 1)
            {
                for (int i = 0; i < accordionControl1.Elements.Count; i++)
                {
                    if (accordionControl1.Elements[i].Tag != null)
                    {
                        if (PowerList.Contains(accordionControl1.Elements[i].Tag.ToString()))
                        {
                            accordionControl1.Elements[i].Visible = true;
                        }
                        else
                        {
                            accordionControl1.Elements[i].Visible = false;
                        }
                    }
                    else
                    {
                        accordionControl1.Elements[i].Visible = false;
                    }
                }
                for (int i = 0; i < accordionControl1.Elements.Count; i++)
                {
                    if (accordionControl1.Elements[i].Tag != null)
                    {
                        if (PowerList.Contains(accordionControl1.Elements[i].Tag.ToString()))
                        {
                            accordionControl1.Elements[i].Enabled = true;
                        }
                        else
                        {
                            accordionControl1.Elements[i].Enabled = false;
                        }
                    }
                    //else
                    //{
                    //    ribbonControl1.Items[i].Enabled = false;
                    //}
                }
            }
        }


        private void ShowRibbinPage()
        {
            if (CommonData.DTPowerListAll != null)
            {
                FileConverHelper fileConverHelper = new FileConverHelper();
                DataRow[] rows = CommonData.DTPowerListAll.Select("moduleNO='0' and no<>'10' and no<>'0' and state=1", "sort");
                //DataRow[] rows = CommonData.DTPowerListAll.Select("moduleNO='0' and no<>'0' and state=1", "sort");
                if (rows.Count() != 0)
                {
                    for (int a = 0; a < rows.Count(); a++)
                    {
                        AccordionControlElement Page = new AccordionControlElement();
                        Page.Name = rows[a]["names"].ToString();
                        Page.Text = rows[a]["names"].ToString();
                        Page.Tag = rows[a]["no"].ToString();
                        DataRow[] GroupRows = CommonData.DTPowerListAll.Select($"moduleNO='{Page.Tag}'  and state=1", "sort");
                        if (GroupRows.Count() != 0)
                        {
                            for (int b = 0; b < GroupRows.Count(); b++)
                            {
                                AccordionControlElement pageGroup = new AccordionControlElement();
                                pageGroup.Expanded = true;
                                pageGroup.Name = GroupRows[b]["names"].ToString();
                                pageGroup.Text = GroupRows[b]["names"].ToString();
                                pageGroup.Tag = GroupRows[b]["no"].ToString();
                                //Page.Elements.Add(pageGroup);
                                DataRow[] ItemsRows = CommonData.DTPowerListAll.Select($"moduleNO='{pageGroup.Tag}'  and state=1", "sort");
                                if (ItemsRows.Count() != 0)
                                {
                                    for (int c = 0; c < ItemsRows.Count(); c++)
                                    {
                                        AccordionControlElement buttonItem = new AccordionControlElement();
                                        buttonItem.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
                                        buttonItem.Name = ItemsRows[c]["names"].ToString();
                                        buttonItem.Text = ItemsRows[c]["names"].ToString();
                                        buttonItem.Tag = ItemsRows[c]["tagValue"].ToString();
                                        //var asss = ItemsRows[c]["itemImg"].ToString().Length;
                                        //if (ItemsRows[c]["itemImg"] != null)
                                        //{

                                        //    if (ItemsRows[c]["itemImg"].ToString().Length != 0)
                                        //    {
                                        //        try
                                        //        {
                                        //            Bitmap bitmap = fileConverHelper.StringToBitmap(ItemsRows[c]["itemImg"].ToString());
                                        //            buttonItem.ImageOptions.Image = bitmap;
                                        //            //buttonItem.ImageOptions.LargeImage = bitmap;



                                        //            //using (MemoryStream ms = new MemoryStream((byte[])ItemsRows[c]["itemImg"]))
                                        //            //{

                                        //            //    Image image = System.Drawing.Image.FromStream(ms);
                                        //            //    buttonItem.ImageOptions.Image = image;
                                        //            //    buttonItem.ImageOptions.LargeImage = image;
                                        //            //}
                                        //        }
                                        //        catch
                                        //        {
                                        //            continue;
                                        //        }
                                        //    }
                                        //}
                                        //buttonItem.Click += ItemsInvoke_ItemClick;
                                        buttonItem.Click += ButtonItem_Click; ;
                                        pageGroup.Elements.Add(buttonItem);
                                    }

                                }
                                Page.Elements.Add(pageGroup);
                            }
                        }
                        accordionControl1.Elements.Add(Page);
                    }
                }
            }
        }




        /// <summary>
        /// TabControl加载窗体方法
        /// </summary>
        /// <param name="cText">标签名称</param>
        /// <param name="frm">Form窗体</param>
        private void ShowMDIForm(string cText, object FrmObject)
        {


            Form frm = (Form)FrmObject;
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this, "", "正在加载......");
            //try
            //{

            //判断是否已创建过
            if (dictXtraTabPage.ContainsKey(cText))
            {
                frmWait.HideMe(this);
                xtraTabControl1.SelectedTabPage = dictXtraTabPage[cText];
                return;
            }
            frm.TopLevel = false;//注意这里，否则加载不出来
            frm.Visible = true;
            frm.Dock = DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            //frm.WindowState = FormWindowState.Maximized;



            XtraTabPage xpage = new XtraTabPage();
            xpage.Controls.Add(frm);//添加要增加的控件
            xpage.Text = cText;//添加名称
            xpage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            xtraTabControl1.TabPages.Add(xpage);
            xtraTabControl1.SelectedTabPage = xpage;//显示该页
            xtraTabControl1.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders;
            dictXtraTabPage.Add(cText, xpage);//加入XtraTabPage字典
            dictXtraForm.Add(cText, frm);//加入XtraForm字典


            frmWait.HideMe(this);
            //}
            //catch(Exception ex)
            //{
            //    log.Error(ex);
            //    frmWait.HideMe(this);
            //    MessageBox.Show("请检查系统配置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }



        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {


            ClosePageButtonEventArgs a = (ClosePageButtonEventArgs)e;
            string cText = a.Page.Text;

            if (dictXtraForm.ContainsKey(cText))
            {
                Form form = dictXtraForm[cText] as Form;
                form.Close();
                form.Dispose();
                dictXtraForm.Remove(cText);


            }

            if (dictXtraTabPage.ContainsKey(cText))
            {
                xtraTabControl1.TabPages.Remove((XtraTabPage)a.Page);
                dictXtraTabPage.Remove(cText);
            }
            if (FormMethods.ContainsKey(cText))
            {
                FormMethods.Remove(cText);
            }
        }


        //MethodInfo FrmMethod;

        /// <summary>
        /// 反射调用窗体方法
        /// </summary>
        /// <param name="BTCaption">按钮名称</param>
        /// <param name="BTTag">按钮绑定值</param>
        public void FrmShowDashboard()
        {

            string names = "首页";
            //string names1 = rows[0]["className"] != DBNull.Value ? rows[0]["className"].ToString() : "";
            //string names2 = rows[0]["libraryName"] != DBNull.Value ? rows[0]["libraryName"].ToString() : "";
            Type FrmType = ReflectionHelper.CreateForm("FrmDashboardViewer", "Common.Dashboard", this);
            if (FrmType != null)
            {
                object FrmObject = Activator.CreateInstance(FrmType);//封装反射对象
                if (FrmObject != null)
                {

                    Form frm = (Form)FrmObject;
                    //FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this, "", "正在加载......");
                    //try
                    //{

                    //判断是否已创建过
                    if (dictXtraTabPage.ContainsKey(names))
                    {
                        //frmWait.HideMe(this);
                        xtraTabControl1.SelectedTabPage = dictXtraTabPage[names];
                        return;
                    }
                    frm.TopLevel = false;//注意这里，否则加载不出来
                    frm.Visible = true;
                    frm.Dock = DockStyle.Fill;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    //frm.WindowState = FormWindowState.Maximized;



                    XtraTabPage xpage = new XtraTabPage();
                    xpage.Controls.Add(frm);//添加要增加的控件
                    xpage.Text = names;//添加名称
                    xpage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
                    xtraTabControl1.TabPages.Add(xpage);
                    xtraTabControl1.SelectedTabPage = xpage;//显示该页
                    xtraTabControl1.ClosePageButtonShowMode = ClosePageButtonShowMode.InAllTabPageHeaders;
                    dictXtraTabPage.Add(names, xpage);//加入XtraTabPage字典
                    dictXtraForm.Add(names, frm);//加入XtraForm字典




                    //ShowMDIForm(names, FrmObject);///加载窗体到xtraTabControl
                    ///向子窗体中传入参数
                    if (!FormMethods.ContainsKey(names))
                    {
                        try
                        {
                            MethodInfo methodInfo = FrmType.GetMethod("FrmLoad");
                            if (methodInfo != null)
                            {
                                object[] paras = new object[] { 0 };
                                methodInfo.Invoke(FrmObject, paras);
                                FormMethods.Add(names, methodInfo);
                            }

                        }
                        catch
                        {

                        }

                    }
                }
                else
                {
                    MessageBox.Show("未读取到应用文件！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //}
            //catch(Exception ex)
            //{
            //    log.Error(ex);
            //    MessageBox.Show("请检查系统配置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// 反射调用窗体方法
        /// </summary>
        /// <param name="BTCaption">按钮名称</param>
        /// <param name="BTTag">按钮绑定值</param>
        public void FrmShowMethod(object BTTag)
        {
            //try
            //{
            DataRow[] rows = CommonData.DTPowerListAll.Select($"tagValue='{BTTag.ToString()}'");
            if (rows.Count() == 1)
            {
                string names = rows[0]["names"] != DBNull.Value ? rows[0]["names"].ToString() : "";
                string names1 = rows[0]["className"] != DBNull.Value ? rows[0]["className"].ToString() : "";
                string names2 = rows[0]["libraryName"] != DBNull.Value ? rows[0]["libraryName"].ToString() : "";
                Type FrmType = ReflectionHelper.CreateForm(rows[0]["className"].ToString(), rows[0]["libraryName"].ToString(), this);
                if (FrmType != null)
                {
                    object FrmObject = Activator.CreateInstance(FrmType);//封装反射对象
                    if (FrmObject != null)
                    {
                        ShowMDIForm(names, FrmObject);///加载窗体到xtraTabControl
                                                      ///向子窗体中传入参数
                        if (!FormMethods.ContainsKey(names))
                        {
                            try
                            {
                                MethodInfo methodInfo = FrmType.GetMethod("FrmLoad");
                                if (methodInfo != null)
                                {
                                    object[] paras = new object[] { BTTag };
                                    methodInfo.Invoke(FrmObject, paras);
                                    FormMethods.Add(names, methodInfo);
                                }

                            }
                            catch
                            {

                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("未读取到应用文件！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("请检查系统配置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
            //catch(Exception ex)
            //{
            //    log.Error(ex);
            //    MessageBox.Show("请检查系统配置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        private void ButtonItem_Click(object sender, EventArgs e)
        {
            AccordionControlElement accordionControl = sender as AccordionControlElement;
            FrmShowMethod(accordionControl.Tag);
        }

        public void ItemsInvoke_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmShowMethod(e.Item.Tag);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BTUserInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmChengePWD frmChenge = new FrmChengePWD();
            frmChenge.ShowDialog();
        }
        private void BTUserInfos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmChengePWD frmChenge = new FrmChengePWD();
            frmChenge.ShowDialog();
        }

        private void BTCommpany_Click(object sender, EventArgs e)
        {
            FrmCompanyinfo frmCompany = new FrmCompanyinfo();
            ShowMDIForm(BTCommpany.Text, frmCompany);
        }

        private void BTDepartment_Click(object sender, EventArgs e)
        {
            FrmDepartmentInfo frmDepartment = new FrmDepartmentInfo();
            ShowMDIForm(BTDepartment.Text, frmDepartment);
        }

        private void BTRole_Click(object sender, EventArgs e)
        {
            FrmRoleInfo frmRole = new FrmRoleInfo();
            ShowMDIForm(BTRole.Text, frmRole);
        }

        private void BTPower_Click(object sender, EventArgs e)
        {
            FrmPowerInfo frmPower = new FrmPowerInfo();
            ShowMDIForm(BTPower.Text, frmPower);
        }

        private void BTWebRole_Click(object sender, EventArgs e)
        {
            FrmWebRoleInfo frmWebRole = new FrmWebRoleInfo();
            ShowMDIForm(BTWebRole.Text, frmWebRole);
        }

        private void BTWebPower_Click(object sender, EventArgs e)
        {
            FrmWebPowerInfo frmWebPower = new FrmWebPowerInfo();
            ShowMDIForm(BTWebPower.Text, frmWebPower);
        }

        private void BTUser_Click(object sender, EventArgs e)
        {
            FrmUserInfo frmUser = new FrmUserInfo();
            ShowMDIForm(BTUser.Text, frmUser);
        }

        private void BTClass_Click(object sender, EventArgs e)
        {
            FrmModuleInfo frmModule = new FrmModuleInfo();
            ShowMDIForm(BTClass.Text, frmModule);
        }

        private void BTWebClass_Click(object sender, EventArgs e)
        {
            FrmWebModuleInfo frmWebModule = new FrmWebModuleInfo();
            ShowMDIForm(BTWebClass.Text, frmWebModule);
        }

        private void BTReSet_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this, "", "正在刷新基础数据......");
            Task CommInfoLoad = new Task(() =>
            {
                //CommonDataRefresh systemInfo = new CommonDataRefresh();
                CommonDataRefresh.GetSystemInfo();

            });
            CommInfoLoad.Start();
            CommInfoLoad.Wait();
            frmWait.HideMe(this);
        }

        private void BTUpData_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClientInfoModel clientInfo = new ClientInfoModel();
            clientInfo.UserName = CommonData.UserInfo.names;
            clientInfo.UserToken = CommonData.tokenInfo.token;
            clientInfo.Name = Application.ProductName;
            clientInfo.Version = CommonData.version;
            clientInfo.state = 1;
            string sr = JsonHelper.SerializeObjct(clientInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(UpFileHandle, sr);

            if (jm.code == 0)
            {
                clientModel clientInfos = JsonHelper.JsonConvertObject<clientModel>(jm);
                if(clientInfos!=null&&clientInfos.fileInfo.Count>0)
                {
                    clientInfos.userName = CommonData.UserInfo.names;
                    //clientInfos.userToken = CommonData.tokenInfo.token;
                    FrmUpFileInfo frmUpFileInfo = new FrmUpFileInfo(clientInfos);
                    frmUpFileInfo.ShowDialog();
                }
                else
                {
                    MessageBox.Show("当前版本已经是最新版本！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //else
            //{
            //    MessageBox.Show(jm.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void BTTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            WebApiCallBack jm = ApiHelpers.postInfo(RefreshToken);
            if (jm.code == 0)
            {
                UserInfoModel uinfo = JsonHelper.JsonConvertObject<UserInfoModel>(jm.data.ToString());
                if (uinfo.userInfo.state == true)
                {
                    CommonData.UserInfo = uinfo.userInfo;
                    CommonData.tokenInfo = uinfo.Authtoken;
                    FrmLoadInfo frmLoad = new FrmLoadInfo();
                    this.Hide();
                    frmLoad.Show();
                }
                else
                {
                    MessageBox.Show("账号已经停止使用！", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
