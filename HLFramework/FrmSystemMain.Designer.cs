namespace HLFramework
{
    partial class FrmSystemMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BTUserInformation = new DevExpress.XtraBars.BarButtonItem();
            this.BTUserRole = new DevExpress.XtraBars.BarButtonItem();
            this.BTUserPower = new DevExpress.XtraBars.BarButtonItem();
            this.BTUserDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.BTUserCompany = new DevExpress.XtraBars.BarButtonItem();
            this.BTModuleInfo = new DevExpress.XtraBars.BarButtonItem();
            this.BTDesigner = new DevExpress.XtraBars.BarButtonItem();
            this.BTLayoutSet = new DevExpress.XtraBars.BarButtonItem();
            this.BTGridSet = new DevExpress.XtraBars.BarButtonItem();
            this.BTAssembly = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.BTUserWebRole = new DevExpress.XtraBars.BarButtonItem();
            this.BTUserWebPower = new DevExpress.XtraBars.BarButtonItem();
            this.BTWebModuleInfo = new DevExpress.XtraBars.BarButtonItem();
            this.BTDictionaries = new DevExpress.XtraBars.BarButtonItem();
            this.BTMessger = new DevExpress.XtraBars.BarButtonItem();
            this.BTUpData = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem4 = new DevExpress.XtraBars.BarStaticItem();
            this.skinDropDownButtonItem1 = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.ribbonMiniToolbar1 = new DevExpress.XtraBars.Ribbon.RibbonMiniToolbar(this.components);
            this.RGSystemManager = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RPGUserManager = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RPGModuleInfo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar2 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.TBInfos = new DevExpress.XtraBars.BarStaticItem();
            this.BTDataRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.BTUserInfoName = new DevExpress.XtraBars.BarButtonItem();
            this.BTDateTimeNow = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.BTUpdateValue = new DevExpress.XtraBars.BarButtonItem();
            this.BTUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.BTUserName = new DevExpress.XtraBars.BarButtonItem();
            this.BSTime = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.BTUserInformation,
            this.BTUserRole,
            this.BTUserPower,
            this.BTUserDepartment,
            this.BTUserCompany,
            this.BTModuleInfo,
            this.BTDesigner,
            this.BTLayoutSet,
            this.BTGridSet,
            this.BTAssembly,
            this.barButtonItem7,
            this.BTUserWebRole,
            this.BTUserWebPower,
            this.BTWebModuleInfo,
            this.BTDictionaries,
            this.BTMessger,
            this.BTUpData,
            this.barStaticItem4,
            this.skinDropDownButtonItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 24;
            this.ribbonControl1.MiniToolbars.Add(this.ribbonMiniToolbar1);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsPageCategories.ShowCaptions = false;
            this.ribbonControl1.PageHeaderItemLinks.Add(this.skinDropDownButtonItem1);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.RGSystemManager,
            this.ribbonPage1});
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowSearchItem = true;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1280, 128);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar2;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden;
            // 
            // BTUserInformation
            // 
            this.BTUserInformation.Caption = "用户管理";
            this.BTUserInformation.Id = 3;
            this.BTUserInformation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUserInformation.ImageOptions.Image")));
            this.BTUserInformation.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTUserInformation.ImageOptions.LargeImage")));
            this.BTUserInformation.Name = "BTUserInformation";
            this.BTUserInformation.Tag = "100107";
            this.BTUserInformation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUserInformation_ItemClick);
            // 
            // BTUserRole
            // 
            this.BTUserRole.Caption = "角色管理";
            this.BTUserRole.Id = 4;
            this.BTUserRole.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUserRole.ImageOptions.Image")));
            this.BTUserRole.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTUserRole.ImageOptions.LargeImage")));
            this.BTUserRole.Name = "BTUserRole";
            this.BTUserRole.Tag = "100103";
            this.BTUserRole.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUserRole_ItemClick);
            // 
            // BTUserPower
            // 
            this.BTUserPower.Caption = "权限管理";
            this.BTUserPower.Id = 5;
            this.BTUserPower.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUserPower.ImageOptions.Image")));
            this.BTUserPower.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTUserPower.ImageOptions.LargeImage")));
            this.BTUserPower.Name = "BTUserPower";
            this.BTUserPower.Tag = "100104";
            this.BTUserPower.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUserPower_ItemClick);
            // 
            // BTUserDepartment
            // 
            this.BTUserDepartment.Caption = "部门管理";
            this.BTUserDepartment.Id = 6;
            this.BTUserDepartment.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUserDepartment.ImageOptions.Image")));
            this.BTUserDepartment.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTUserDepartment.ImageOptions.LargeImage")));
            this.BTUserDepartment.Name = "BTUserDepartment";
            this.BTUserDepartment.Tag = "100102";
            this.BTUserDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUserDepartment_ItemClick);
            // 
            // BTUserCompany
            // 
            this.BTUserCompany.Caption = "公司维护";
            this.BTUserCompany.Id = 7;
            this.BTUserCompany.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUserCompany.ImageOptions.Image")));
            this.BTUserCompany.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTUserCompany.ImageOptions.LargeImage")));
            this.BTUserCompany.Name = "BTUserCompany";
            this.BTUserCompany.Tag = "100101";
            this.BTUserCompany.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUserCompany_ItemClick);
            // 
            // BTModuleInfo
            // 
            this.BTModuleInfo.Caption = "模块信息";
            this.BTModuleInfo.Id = 1;
            this.BTModuleInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTModuleInfo.ImageOptions.Image")));
            this.BTModuleInfo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTModuleInfo.ImageOptions.LargeImage")));
            this.BTModuleInfo.Name = "BTModuleInfo";
            this.BTModuleInfo.Tag = "100201";
            this.BTModuleInfo.VisibleInSearchMenu = false;
            this.BTModuleInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTModuleInfo_ItemClick);
            // 
            // BTDesigner
            // 
            this.BTDesigner.Caption = "窗体设计器";
            this.BTDesigner.Id = 2;
            this.BTDesigner.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTDesigner.ImageOptions.Image")));
            this.BTDesigner.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTDesigner.ImageOptions.LargeImage")));
            this.BTDesigner.Name = "BTDesigner";
            this.BTDesigner.Tag = "100203";
            this.BTDesigner.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDesigner_ItemClick);
            // 
            // BTLayoutSet
            // 
            this.BTLayoutSet.Caption = "布局信息维护";
            this.BTLayoutSet.Id = 3;
            this.BTLayoutSet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTLayoutSet.ImageOptions.Image")));
            this.BTLayoutSet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTLayoutSet.ImageOptions.LargeImage")));
            this.BTLayoutSet.Name = "BTLayoutSet";
            this.BTLayoutSet.Tag = "100204";
            this.BTLayoutSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTMoudelDesign_ItemClick);
            // 
            // BTGridSet
            // 
            this.BTGridSet.Caption = "列表信息维护";
            this.BTGridSet.Id = 4;
            this.BTGridSet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTGridSet.ImageOptions.Image")));
            this.BTGridSet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTGridSet.ImageOptions.LargeImage")));
            this.BTGridSet.Name = "BTGridSet";
            this.BTGridSet.Tag = "100205";
            this.BTGridSet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTMoudelColumns_ItemClick);
            // 
            // BTAssembly
            // 
            this.BTAssembly.Caption = "反射练习";
            this.BTAssembly.Id = 5;
            this.BTAssembly.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTAssembly.ImageOptions.Image")));
            this.BTAssembly.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTAssembly.ImageOptions.LargeImage")));
            this.BTAssembly.Name = "BTAssembly";
            this.BTAssembly.Tag = "110101";
            this.BTAssembly.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAssembly_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "barButtonItem7";
            this.barButtonItem7.Id = 6;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // BTUserWebRole
            // 
            this.BTUserWebRole.Caption = "Web角色管理";
            this.BTUserWebRole.Id = 7;
            this.BTUserWebRole.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUserWebRole.ImageOptions.Image")));
            this.BTUserWebRole.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTUserWebRole.ImageOptions.LargeImage")));
            this.BTUserWebRole.Name = "BTUserWebRole";
            this.BTUserWebRole.Tag = "100105";
            this.BTUserWebRole.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUserWebRole_ItemClick);
            // 
            // BTUserWebPower
            // 
            this.BTUserWebPower.Caption = "Web权限管理";
            this.BTUserWebPower.Id = 8;
            this.BTUserWebPower.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUserWebPower.ImageOptions.Image")));
            this.BTUserWebPower.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTUserWebPower.ImageOptions.LargeImage")));
            this.BTUserWebPower.Name = "BTUserWebPower";
            this.BTUserWebPower.Tag = "100106";
            this.BTUserWebPower.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUserWebPower_ItemClick);
            // 
            // BTWebModuleInfo
            // 
            this.BTWebModuleInfo.Caption = "Web模块维护";
            this.BTWebModuleInfo.Id = 9;
            this.BTWebModuleInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTWebModuleInfo.ImageOptions.Image")));
            this.BTWebModuleInfo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTWebModuleInfo.ImageOptions.LargeImage")));
            this.BTWebModuleInfo.Name = "BTWebModuleInfo";
            this.BTWebModuleInfo.Tag = "100202";
            this.BTWebModuleInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTWebModuleInfo_ItemClick);
            // 
            // BTDictionaries
            // 
            this.BTDictionaries.Caption = "字段信息维护";
            this.BTDictionaries.Id = 11;
            this.BTDictionaries.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTDictionaries.ImageOptions.Image")));
            this.BTDictionaries.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTDictionaries.ImageOptions.LargeImage")));
            this.BTDictionaries.Name = "BTDictionaries";
            this.BTDictionaries.Tag = "100205";
            // 
            // BTMessger
            // 
            this.BTMessger.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BTMessger.Caption = "消息信息";
            this.BTMessger.Id = 16;
            this.BTMessger.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTMessger.ImageOptions.SvgImage")));
            this.BTMessger.Name = "BTMessger";
            this.BTMessger.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTMessger_ItemClick);
            // 
            // BTUpData
            // 
            this.BTUpData.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BTUpData.Caption = "检查更新";
            this.BTUpData.Id = 17;
            this.BTUpData.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTUpData.ImageOptions.SvgImage")));
            this.BTUpData.Name = "BTUpData";
            this.BTUpData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUpData_ItemClick);
            // 
            // barStaticItem4
            // 
            this.barStaticItem4.Caption = "联系微信:15596683926";
            this.barStaticItem4.Id = 20;
            this.barStaticItem4.Name = "barStaticItem4";
            // 
            // skinDropDownButtonItem1
            // 
            this.skinDropDownButtonItem1.Id = 21;
            this.skinDropDownButtonItem1.Name = "skinDropDownButtonItem1";
            this.skinDropDownButtonItem1.DownChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.skinDropDownButtonItem1_DownChanged);
            // 
            // ribbonMiniToolbar1
            // 
            this.ribbonMiniToolbar1.ParentControl = this;
            // 
            // RGSystemManager
            // 
            this.RGSystemManager.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RPGUserManager,
            this.RPGModuleInfo});
            this.RGSystemManager.Name = "RGSystemManager";
            this.RGSystemManager.Tag = "10";
            this.RGSystemManager.Text = "系统管理";
            // 
            // RPGUserManager
            // 
            this.RPGUserManager.ItemLinks.Add(this.BTUserCompany);
            this.RPGUserManager.ItemLinks.Add(this.BTUserDepartment);
            this.RPGUserManager.ItemLinks.Add(this.BTUserRole);
            this.RPGUserManager.ItemLinks.Add(this.BTUserPower);
            this.RPGUserManager.ItemLinks.Add(this.BTUserWebRole);
            this.RPGUserManager.ItemLinks.Add(this.BTUserWebPower);
            this.RPGUserManager.ItemLinks.Add(this.BTUserInformation);
            this.RPGUserManager.Name = "RPGUserManager";
            this.RPGUserManager.Tag = "1001";
            this.RPGUserManager.Text = "用户管理";
            // 
            // RPGModuleInfo
            // 
            this.RPGModuleInfo.ItemLinks.Add(this.BTModuleInfo);
            this.RPGModuleInfo.ItemLinks.Add(this.BTWebModuleInfo);
            this.RPGModuleInfo.ItemLinks.Add(this.BTDesigner);
            this.RPGModuleInfo.ItemLinks.Add(this.BTLayoutSet);
            this.RPGModuleInfo.ItemLinks.Add(this.BTGridSet);
            this.RPGModuleInfo.ItemLinks.Add(this.BTDictionaries);
            this.RPGModuleInfo.Name = "RPGModuleInfo";
            this.RPGModuleInfo.Tag = "1002";
            this.RPGModuleInfo.Text = "模块信息";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Tag = "10000000000000";
            this.ribbonPage1.Text = "基础维护";
            this.ribbonPage1.Visible = false;
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BTAssembly);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Tag = "9001";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar2
            // 
            this.ribbonStatusBar2.ItemLinks.Add(this.TBInfos);
            this.ribbonStatusBar2.ItemLinks.Add(this.BTDataRefresh);
            this.ribbonStatusBar2.ItemLinks.Add(this.BTUpData);
            this.ribbonStatusBar2.ItemLinks.Add(this.BTMessger);
            this.ribbonStatusBar2.ItemLinks.Add(this.BTUserInfoName);
            this.ribbonStatusBar2.ItemLinks.Add(this.BTDateTimeNow);
            this.ribbonStatusBar2.ItemLinks.Add(this.barStaticItem4);
            this.ribbonStatusBar2.Location = new System.Drawing.Point(0, 755);
            this.ribbonStatusBar2.Name = "ribbonStatusBar2";
            this.ribbonStatusBar2.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar2.Size = new System.Drawing.Size(1280, 27);
            // 
            // TBInfos
            // 
            this.TBInfos.Caption = "西安屹辰智禾信息科技有限公司 ";
            this.TBInfos.Id = 42;
            this.TBInfos.Name = "TBInfos";
            // 
            // BTDataRefresh
            // 
            this.BTDataRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BTDataRefresh.Caption = "更新数据源";
            this.BTDataRefresh.Id = 55;
            this.BTDataRefresh.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTDataRefresh.ImageOptions.SvgImage")));
            this.BTDataRefresh.Name = "BTDataRefresh";
            this.BTDataRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDataRefresh_ItemClick);
            // 
            // BTUserInfoName
            // 
            this.BTUserInfoName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BTUserInfoName.Caption = "用户名称";
            this.BTUserInfoName.Id = 44;
            this.BTUserInfoName.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTUserInfoName.ImageOptions.SvgImage")));
            this.BTUserInfoName.Name = "BTUserInfoName";
            this.BTUserInfoName.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTUserInfoName_ItemClick);
            // 
            // BTDateTimeNow
            // 
            this.BTDateTimeNow.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BTDateTimeNow.Caption = "当前时间";
            this.BTDateTimeNow.Id = 45;
            this.BTDateTimeNow.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("BTDateTimeNow.ImageOptions.SvgImage")));
            this.BTDateTimeNow.Name = "BTDateTimeNow";
            this.BTDateTimeNow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "欢迎使用ERP系统！";
            this.barStaticItem2.Id = 42;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // BTUpdateValue
            // 
            this.BTUpdateValue.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BTUpdateValue.Caption = "更新数据源";
            this.BTUpdateValue.Id = 55;
            this.BTUpdateValue.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUpdateValue.ImageOptions.Image")));
            this.BTUpdateValue.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTUpdateValue.ImageOptions.LargeImage")));
            this.BTUpdateValue.Name = "BTUpdateValue";
            // 
            // BTUpdate
            // 
            this.BTUpdate.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BTUpdate.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.BTUpdate.Caption = "检查更新";
            this.BTUpdate.Id = 43;
            this.BTUpdate.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("BTUpdate.ImageOptions.DisabledImage")));
            this.BTUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUpdate.ImageOptions.Image")));
            this.BTUpdate.Name = "BTUpdate";
            this.BTUpdate.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BTUpdate.Tag = "0";
            // 
            // BTUserName
            // 
            this.BTUserName.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BTUserName.Caption = "用户名称";
            this.BTUserName.Id = 44;
            this.BTUserName.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTUserName.ImageOptions.Image")));
            this.BTUserName.Name = "BTUserName";
            // 
            // BSTime
            // 
            this.BSTime.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.BSTime.Caption = "当前时间";
            this.BSTime.Id = 45;
            this.BSTime.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BSTime.ImageOptions.Image")));
            this.BSTime.Name = "BSTime";
            this.BSTime.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "欢迎使用ERP系统！";
            this.barStaticItem1.Id = 42;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem1.Caption = "更新数据源";
            this.barButtonItem1.Id = 55;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem2.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barButtonItem2.Caption = "检查更新";
            this.barButtonItem2.Id = 43;
            this.barButtonItem2.ImageOptions.DisabledImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.DisabledImage")));
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.barButtonItem2.Tag = "0";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barButtonItem3.Caption = "用户名称";
            this.barButtonItem3.Id = 44;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem3.Caption = "当前时间";
            this.barStaticItem3.Id = 45;
            this.barStaticItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItem3.ImageOptions.Image")));
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 128);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.Size = new System.Drawing.Size(1280, 627);
            this.xtraTabControl1.TabIndex = 16;
            this.xtraTabControl1.CloseButtonClick += new System.EventHandler(this.xtraTabControl1_CloseButtonClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl1;
            // 
            // timer1
            // 
            this.timer1.Interval = 120000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // FrmSystemMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1280, 782);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.ribbonStatusBar2);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmSystemMain.IconOptions.Icon")));
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmSystemMain.IconOptions.Image")));
            this.Name = "FrmSystemMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HLIMS实验室信息管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSystemMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmSystemMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage RGSystemManager;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPGUserManager;
        private DevExpress.XtraBars.BarButtonItem BTUserInformation;
        private DevExpress.XtraBars.BarButtonItem BTUserRole;
        private DevExpress.XtraBars.BarButtonItem BTUserPower;
        private DevExpress.XtraBars.BarButtonItem BTUserDepartment;
        private DevExpress.XtraBars.BarButtonItem BTUserCompany;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarButtonItem BTUpdateValue;
        private DevExpress.XtraBars.BarButtonItem BTUpdate;
        private DevExpress.XtraBars.BarButtonItem BTUserName;
        private DevExpress.XtraBars.BarStaticItem BSTime;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar2;
        private DevExpress.XtraBars.BarStaticItem TBInfos;
        private DevExpress.XtraBars.BarButtonItem BTDataRefresh;
        private DevExpress.XtraBars.BarButtonItem BTUserInfoName;
        private DevExpress.XtraBars.BarStaticItem BTDateTimeNow;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RPGModuleInfo;
        private DevExpress.XtraBars.BarButtonItem BTModuleInfo;
        private DevExpress.XtraBars.BarButtonItem BTDesigner;
        private DevExpress.XtraBars.BarButtonItem BTLayoutSet;
        private DevExpress.XtraBars.BarButtonItem BTGridSet;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BTAssembly;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraBars.BarButtonItem BTUserWebRole;
        private DevExpress.XtraBars.BarButtonItem BTUserWebPower;
        private DevExpress.XtraBars.BarButtonItem BTWebModuleInfo;
        private DevExpress.XtraBars.BarButtonItem BTDictionaries;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.Ribbon.RibbonMiniToolbar ribbonMiniToolbar1;
        private DevExpress.XtraBars.BarButtonItem BTMessger;
        private DevExpress.XtraBars.BarButtonItem BTUpData;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private DevExpress.XtraBars.BarStaticItem barStaticItem4;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem1;
    }
}

