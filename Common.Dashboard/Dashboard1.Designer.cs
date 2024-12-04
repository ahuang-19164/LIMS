
namespace Common.Dashboard
{
    partial class Dashboard1
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.DashboardCommon.ChartPane chartPane1 = new DevExpress.DashboardCommon.ChartPane();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup2 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem2 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup3 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem3 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem4 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            this.cardDashboardItem1 = new DevExpress.DashboardCommon.CardDashboardItem();
            this.pieDashboardItem1 = new DevExpress.DashboardCommon.PieDashboardItem();
            this.chartDashboardItem1 = new DevExpress.DashboardCommon.ChartDashboardItem();
            this.cardDashboardItem2 = new DevExpress.DashboardCommon.CardDashboardItem();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // cardDashboardItem1
            // 
            this.cardDashboardItem1.ComponentName = "cardDashboardItem1";
            this.cardDashboardItem1.DataItemRepository.Clear();
            this.cardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = true;
            this.cardDashboardItem1.Name = "样本统计";
            this.cardDashboardItem1.ShowCaption = false;
            // 
            // pieDashboardItem1
            // 
            this.pieDashboardItem1.ComponentName = "pieDashboardItem1";
            this.pieDashboardItem1.DataItemRepository.Clear();
            this.pieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.pieDashboardItem1.Name = "客户送检统计";
            this.pieDashboardItem1.ShowCaption = false;
            this.pieDashboardItem1.ShowPieCaptions = false;
            // 
            // chartDashboardItem1
            // 
            this.chartDashboardItem1.AxisX.TitleVisible = false;
            this.chartDashboardItem1.ComponentName = "chartDashboardItem1";
            this.chartDashboardItem1.DataItemRepository.Clear();
            this.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.chartDashboardItem1.Name = "专业组样本量统计";
            chartPane1.Name = "Pane 1";
            chartPane1.PrimaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.PrimaryAxisY.ShowGridLines = true;
            chartPane1.PrimaryAxisY.TitleVisible = true;
            chartPane1.SecondaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.SecondaryAxisY.ShowGridLines = false;
            chartPane1.SecondaryAxisY.TitleVisible = true;
            this.chartDashboardItem1.Panes.AddRange(new DevExpress.DashboardCommon.ChartPane[] {
            chartPane1});
            this.chartDashboardItem1.ShowCaption = false;
            // 
            // cardDashboardItem2
            // 
            this.cardDashboardItem2.ComponentName = "cardDashboardItem2";
            this.cardDashboardItem2.DataItemRepository.Clear();
            this.cardDashboardItem2.InteractivityOptions.IgnoreMasterFilters = false;
            this.cardDashboardItem2.Name = "Cards 1";
            this.cardDashboardItem2.ShowCaption = false;
            // 
            // Dashboard1
            // 
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.pieDashboardItem1,
            this.chartDashboardItem1,
            this.cardDashboardItem1,
            this.cardDashboardItem2});
            dashboardLayoutItem1.DashboardItem = this.cardDashboardItem2;
            dashboardLayoutItem1.Weight = 22.919708029197082D;
            dashboardLayoutItem2.DashboardItem = this.cardDashboardItem1;
            dashboardLayoutItem2.Weight = 28.626692456479692D;
            dashboardLayoutItem3.DashboardItem = this.chartDashboardItem1;
            dashboardLayoutItem3.Weight = 49.242424242424242D;
            dashboardLayoutItem4.DashboardItem = this.pieDashboardItem1;
            dashboardLayoutItem4.Weight = 50.757575757575758D;
            dashboardLayoutGroup3.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem3,
            dashboardLayoutItem4});
            dashboardLayoutGroup3.DashboardItem = null;
            dashboardLayoutGroup3.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup3.Weight = 71.373307543520312D;
            dashboardLayoutGroup2.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem2,
            dashboardLayoutGroup3});
            dashboardLayoutGroup2.DashboardItem = null;
            dashboardLayoutGroup2.Weight = 77.080291970802918D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1,
            dashboardLayoutGroup2});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            dashboardLayoutGroup1.Weight = 100D;
            this.LayoutRoot = dashboardLayoutGroup1;
            this.Title.ShowMasterFilterState = false;
            this.Title.Text = "Dashboard";
            this.Title.Visible = false;
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardDashboardItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        private DevExpress.DashboardCommon.ChartDashboardItem chartDashboardItem1;
        private DevExpress.DashboardCommon.PieDashboardItem pieDashboardItem1;
        private DevExpress.DashboardCommon.CardDashboardItem cardDashboardItem1;
        private DevExpress.DashboardCommon.CardDashboardItem cardDashboardItem2;
    }
}
