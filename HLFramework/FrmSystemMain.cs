using Common.BLL;
using Common.Conn;
using Common.Data;
using Common.LoadShow;
using Common.MessageHandle;
using Common.Model;
using Common.SqlModel;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.JsonHelper;

namespace HLFramework
{
    public partial class FrmSystemMain : DevExpress.XtraEditors.XtraForm
    {

        log4net.ILog log = (log4net.ILog)log4net.LogManager.GetLogger("");
        Dictionary<string, XtraTabPage> dictXtraTabPage = new Dictionary<string, XtraTabPage>();
        Dictionary<string, Form> dictXtraForm = new Dictionary<string, Form>();
        Dictionary<string, MethodInfo> FormMethods = new Dictionary<string, MethodInfo>();
        string UpFileHandle = "";
        string MessageInfo = "";
        public FrmSystemMain()
        {
            UpFileHandle = ConfigInfos.ReadConfigInfo("UpFileHandle");
            MessageInfo = ConfigInfos.ReadConfigInfo("MessageInfo");
            InitializeComponent();
            TBInfos.Caption = Application.CompanyName.ToString() +CommonData.version + "\n";
            ShowRibbinPage();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }

        }

        //作用 加快界面加载 

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        /// <summary>
        /// 加载内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSystemMain_Load(object sender, EventArgs e)
        {
            //Program.UserInfo.UserName = "admin";
            BTUserInfoName.Caption = CommonData.UserInfo.names;
            BTDateTimeNow.Caption = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ribbonControl1.AllowMdiChildButtons = false;
            ribbonControl1.Minimized = true;
            //timer1_Tick(null, null);




        }
        ////panl内部切换窗体方法
        //private void form(Form form)
        //{
        //    foreach (Control item in this.panel1.Controls)
        //    {
        //        if (item is Form)
        //        {
        //            Form ctl = (Form)item;
        //            ctl.Close();
        //            //((Form)item).Close();
        //        }
        //    }
        //    form.TopLevel = false;
        //    form.FormBorderStyle = FormBorderStyle.None;
        //    //form.ControlBox = false;
        //    form.Parent = this.panel1;
        //    form.Dock = DockStyle.Fill;
        //    form.Show();
        //}

        #region 管理方法

        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {
            string[] PowerList = CommonData.powerList;
            if (CommonData.UserInfo.id != 1)
            {
                for (int i = 0; i < ribbonControl1.Pages.Count; i++)
                {
                    if (ribbonControl1.Pages[i].Tag != null)
                    {
                        if (PowerList.Contains(ribbonControl1.Pages[i].Tag.ToString()))
                        {
                            ribbonControl1.Pages[i].Visible = true;
                        }
                        else
                        {
                            ribbonControl1.Pages[i].Visible = false;
                        }
                    }
                    else
                    {
                        ribbonControl1.Pages[i].Visible = false;
                    }
                }
                for (int i = 0; i < ribbonControl1.Items.Count; i++)
                {
                    if (ribbonControl1.Items[i].Tag != null)
                    {
                        if (PowerList.Contains(ribbonControl1.Items[i].Tag.ToString()))
                        {
                            ribbonControl1.Items[i].Enabled = true;
                        }
                        else
                        {
                            ribbonControl1.Items[i].Enabled = false;
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
                if (rows.Count() != 0)
                {
                    for (int a = 0; a < rows.Count(); a++)
                    {
                        RibbonPage Page = new RibbonPage();
                        Page.Name = rows[a]["names"].ToString();
                        Page.Text = rows[a]["names"].ToString();
                        Page.Tag = rows[a]["no"].ToString();
                        DataRow[] GroupRows = CommonData.DTPowerListAll.Select($"moduleNO='{Page.Tag}'  and state=1", "sort");
                        if (GroupRows.Count() != 0)
                        {
                            for (int b = 0; b < GroupRows.Count(); b++)
                            {
                                RibbonPageGroup pageGroup = new RibbonPageGroup();
                                pageGroup.Name = GroupRows[b]["names"].ToString();
                                pageGroup.Text = GroupRows[b]["names"].ToString();
                                pageGroup.Tag = GroupRows[b]["no"].ToString();
                                //Page.Groups.Add(pageGroup);
                                DataRow[] ItemsRows = CommonData.DTPowerListAll.Select($"moduleNO='{pageGroup.Tag}'  and state=1", "sort");
                                if (ItemsRows.Count() != 0)
                                {
                                    for (int c = 0; c < ItemsRows.Count(); c++)
                                    {
                                        BarButtonItem buttonItem = new BarButtonItem();
                                        buttonItem.Name = ItemsRows[c]["names"].ToString();
                                        buttonItem.Caption = ItemsRows[c]["names"].ToString();
                                        buttonItem.Tag = ItemsRows[c]["tagValue"].ToString();
                                        var asss = ItemsRows[c]["itemImg"].ToString().Length;
                                        if (ItemsRows[c]["itemImg"] != null)
                                        {

                                            if (ItemsRows[c]["itemImg"].ToString().Length != 0)
                                            {
                                                try
                                                {
                                                    Bitmap bitmap = fileConverHelper.StringToBitmap(ItemsRows[c]["itemImg"].ToString());
                                                    buttonItem.ImageOptions.Image = bitmap;
                                                    buttonItem.ImageOptions.LargeImage = bitmap;



                                                    //using (MemoryStream ms = new MemoryStream((byte[])ItemsRows[c]["itemImg"]))
                                                    //{

                                                    //    Image image = System.Drawing.Image.FromStream(ms);
                                                    //    buttonItem.ImageOptions.Image = image;
                                                    //    buttonItem.ImageOptions.LargeImage = image;
                                                    //}
                                                }
                                                catch
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                        buttonItem.ItemClick += ItemsInvoke_ItemClick;
                                        pageGroup.ItemLinks.Add(buttonItem);
                                    }

                                }
                                Page.Groups.Add(pageGroup);
                            }
                        }
                        ribbonControl1.Pages.Add(Page);
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
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载......");
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
        public void ItemsInvoke_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmShowMethod(e.Item.Tag);
        }

        #endregion




        #region 按钮方法
        private void BTUserCompany_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmCompanyinfo frmCompany = new FrmCompanyinfo();
            ShowMDIForm(BTUserCompany.Caption, frmCompany);
        }

        private void BTUserDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmDepartmentInfo frmDepartment = new FrmDepartmentInfo();
            ShowMDIForm(BTUserDepartment.Caption, frmDepartment);
        }

        private void BTUserRole_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmRoleInfo frmRole = new FrmRoleInfo();
            ShowMDIForm(BTUserRole.Caption, frmRole);
        }
        private void BTUserWebRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWebRoleInfo frmWebRole = new FrmWebRoleInfo();
            ShowMDIForm(BTUserWebRole.Caption, frmWebRole);
        }

        private void BTUserInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUserInfo frmUser = new FrmUserInfo();
            ShowMDIForm(BTUserInformation.Caption, frmUser);
        }
        private void BTUserPower_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmPowerInfo frmPower = new FrmPowerInfo();
            ShowMDIForm(BTUserPower.Caption, frmPower);
        }
        private void BTUserWebPower_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWebPowerInfo frmWebPower = new FrmWebPowerInfo();
            ShowMDIForm(BTUserWebPower.Caption, frmWebPower);
        }
        private void BTModuleInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmModuleInfo frmModule = new FrmModuleInfo();
            ShowMDIForm(BTModuleInfo.Caption, frmModule);
        }
        private void BTWebModuleInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWebModuleInfo frmWebModule = new FrmWebModuleInfo();
            ShowMDIForm(BTWebModuleInfo.Caption, frmWebModule);
        }

        private void BTDesigner_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //FrmDesigner frmDesigner = new FrmDesigner();
            //ShowMDIForm(BTDesigner.Caption, frmDesigner);


            FRMMoudelDesign rMMoudelDesign = new FRMMoudelDesign();
            ShowMDIForm(BTDesigner.Caption, rMMoudelDesign);
        }
        private void BTMoudelDesign_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmGridColumns frmGridColumns = new FrmGridColumns();
            //FrmWebModuleInfo frmWebModule = new FrmWebModuleInfo();
            ShowMDIForm(BTLayoutSet.Caption, frmGridColumns);
        }
        private void BTMoudelColumns_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FRMMoudelColumns fRMMoudelColumns = new FRMMoudelColumns();
            //FrmWebModuleInfo frmWebModule = new FrmWebModuleInfo();
            //ShowMDIForm(BTMoudelDesign.Caption, fRMMoudelColumns);
        }

        private void BTUserInfoName_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChengePWD frmChenge = new FrmChengePWD();
            frmChenge.ShowDialog();
        }

        private void BTAssembly_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmShowMethod(BTAssembly.Tag);
        }


        private void FrmSystemMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }













        #endregion

        private void BTDataRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在刷新基础数据......");
            Task CommInfoLoad = new Task(() =>
            {
                //CommonDataRefresh systemInfo = new CommonDataRefresh();
                CommonDataRefresh.GetSystemInfo();

            });
            CommInfoLoad.Start();
            CommInfoLoad.Wait();
            frmWait.HideMe(this);
        }

        private void BTClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }








        private void BTMianMax_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void BTUpData_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClientInfoModel clientInfo = new ClientInfoModel();
            clientInfo.UserName = CommonData.UserInfo.names;
            clientInfo.UserToken = CommonData.tokenInfo.token;
            clientInfo.Name = Application.ProductName;
            clientInfo.Version = Application.ProductVersion;
            clientInfo.state = 1;
            string sr = JsonHelper.SerializeObjct(clientInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(UpFileHandle, sr);
            UpInfoModel upinfo = JsonHelper.JsonConvertObject<UpInfoModel>(jm.data.ToString());
            if (upinfo.code == 1)
            {
                upinfo.clientInfo.userName = CommonData.UserInfo.names;
                upinfo.clientInfo.userToken = CommonData.tokenInfo.token;
                FrmUpFileInfo frmUpFileInfo = new FrmUpFileInfo(upinfo.clientInfo);
                frmUpFileInfo.ShowDialog();
            }
            else
            {
                MessageBox.Show("当前版本已经是最新版本！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





        List<ReMessageInfo> reMessageInfos;

        #region 消息提醒
        private void timer1_Tick(object sender, EventArgs e)
        {

            GetMessageInfo getMessageInfo = new GetMessageInfo();
            getMessageInfo.UserName = CommonData.UserInfo.names;
            getMessageInfo.UserToken = CommonData.tokenInfo.token;
            //getMessageInfo.userRole = CommonData.UserInfo.roleNO;
            string sr = JsonHelper.SerializeObjct(getMessageInfo);
            WebApiCallBack jm = ApiHelpers.postInfo(MessageInfo, sr);
            if (jm.code==0)
            {
                commReInfo<ReMessageInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<ReMessageInfo>>(jm.data.ToString());
                if (commReInfo.code == 1)
                {
                    reMessageInfos = commReInfo.infos;

                    //backgroundWorker.RunWorkerAsync();
                    for (int a = 1; a <= reMessageInfos.Count; a++)
                    {
                        //Task task = new Task(() =>
                        //{
                        FrmMessage frmMessage = new FrmMessage(1, reMessageInfos[a - 1]);
                        frmMessage.TransfEvent += frm_TransfEvent;
                        frmMessage.Show();

                        //});
                        //task.Start();
                        //task.Wait();
                    }
                }
            }




            //backgroundWorker.RunWorkerAsync();z
            ////Task task = new Task(() =>
            ////{

            //for (int a = 1; a < 5; a++)
            //{
            //    FrmMessage frmMessage = new FrmMessage(a, null);
            //    frmMessage.TransfEvent += frm_TransfEvent;
            //    frmMessage.Show();
            //}
            ////FrmMessage frmMessage = new FrmMessage(1, null);
            ////frmMessage.TransfEvent += frm_TransfEvent;
            ////frmMessage.Show();
            ////FrmMessage frmMessage2 = new FrmMessage(2, null);
            ////frmMessage2.TransfEvent += frm_TransfEvent;
            ////frmMessage2.Show();

            ////});
            ////task.Start();



        }





        //事件处理方法
        void frm_TransfEvent(string value)
        {
            try
            {
                if (value != "")
                {
                    FrmShowMethod(value);
                }

            }
#pragma warning disable CS0168 // 声明了变量“ex”，但从未使用过
            catch (Exception ex)
#pragma warning restore CS0168 // 声明了变量“ex”，但从未使用过
            {

            }

        }

        private void BTMessger_ItemClick(object sender, ItemClickEventArgs e)
        {
            //timer1_Tick(null, null);
        }


        #endregion
        //string messageNo = "";
        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (reMessageInfos != null)
            {
                for (int a = 1; a <= reMessageInfos.Count; a++)
                {
                    //Task task = new Task(() =>
                    //{
                    FrmMessage frmMessage = new FrmMessage(a, reMessageInfos[a]);
                    frmMessage.TransfEvent += frm_TransfEvent;
                    frmMessage.Show();
                    //});
                    //task.Start();
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }

        private void skinPaletteDropDownButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void skinDropDownButtonItem1_DownChanged(object sender, ItemClickEventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinDropDownButtonItem1.SearchTags);
        }

        private void cboSkins_DownChanged(object sender, ItemClickEventArgs e)
        {
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.set(cboSkins.SearchTags);
        }
    }
}
