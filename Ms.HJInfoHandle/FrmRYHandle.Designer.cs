
namespace Ms.HJInfoHandle
{
    partial class FrmRYHandle
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRYHandle));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.BTAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BTDelete = new DevExpress.XtraBars.BarButtonItem();
            this.BTSave = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.blendid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ageYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientSexNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.receiveTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.passportNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dstate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.createTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.creater = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.BTAdd,
            this.BTSave,
            this.BTDelete});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // BTAdd
            // 
            this.BTAdd.Caption = "新增";
            this.BTAdd.Id = 0;
            this.BTAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTAdd.ImageOptions.Image")));
            this.BTAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTAdd.ImageOptions.LargeImage")));
            this.BTAdd.Name = "BTAdd";
            this.BTAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTAdd_ItemClick);
            // 
            // BTDelete
            // 
            this.BTDelete.Caption = "删除";
            this.BTDelete.Id = 2;
            this.BTDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTDelete.ImageOptions.Image")));
            this.BTDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTDelete.ImageOptions.LargeImage")));
            this.BTDelete.Name = "BTDelete";
            this.BTDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTDelete_ItemClick);
            // 
            // BTSave
            // 
            this.BTSave.Caption = "保存";
            this.BTSave.Id = 1;
            this.BTSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.Image")));
            this.BTSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSave.ImageOptions.LargeImage")));
            this.BTSave.Name = "BTSave";
            this.BTSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSave_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1234, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 612);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1234, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 588);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1234, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 588);
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(0, 24);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.Size = new System.Drawing.Size(1234, 588);
            this.GCInfo.TabIndex = 4;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.blendid,
            this.id,
            this.barcode,
            this.patientName,
            this.patientPhone,
            this.ageYear,
            this.patientSexNames,
            this.patientCardNo,
            this.sampleTime,
            this.receiveTime,
            this.sampleLocation,
            this.passportNo,
            this.dstate,
            this.createTime,
            this.creater});
            this.GVInfo.DetailHeight = 408;
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            this.GVInfo.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.GVInfo_InitNewRow);
            // 
            // blendid
            // 
            this.blendid.Caption = "编号";
            this.blendid.FieldName = "blendid";
            this.blendid.MinWidth = 23;
            this.blendid.Name = "blendid";
            this.blendid.OptionsColumn.AllowFocus = false;
            this.blendid.Visible = true;
            this.blendid.VisibleIndex = 0;
            this.blendid.Width = 87;
            // 
            // id
            // 
            this.id.Caption = "检验编号";
            this.id.FieldName = "id";
            this.id.MinWidth = 23;
            this.id.Name = "id";
            this.id.OptionsColumn.AllowFocus = false;
            this.id.Visible = true;
            this.id.VisibleIndex = 1;
            this.id.Width = 87;
            // 
            // barcode
            // 
            this.barcode.Caption = "条码号";
            this.barcode.FieldName = "barcode";
            this.barcode.MinWidth = 23;
            this.barcode.Name = "barcode";
            this.barcode.OptionsColumn.AllowFocus = false;
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 2;
            this.barcode.Width = 87;
            // 
            // patientName
            // 
            this.patientName.Caption = "姓名";
            this.patientName.FieldName = "patientName";
            this.patientName.MinWidth = 23;
            this.patientName.Name = "patientName";
            this.patientName.Visible = true;
            this.patientName.VisibleIndex = 3;
            this.patientName.Width = 87;
            // 
            // patientPhone
            // 
            this.patientPhone.Caption = "联系电话";
            this.patientPhone.FieldName = "patientPhone";
            this.patientPhone.MinWidth = 23;
            this.patientPhone.Name = "patientPhone";
            this.patientPhone.Visible = true;
            this.patientPhone.VisibleIndex = 6;
            this.patientPhone.Width = 87;
            // 
            // ageYear
            // 
            this.ageYear.Caption = "年龄";
            this.ageYear.FieldName = "ageYear";
            this.ageYear.Name = "ageYear";
            this.ageYear.Visible = true;
            this.ageYear.VisibleIndex = 5;
            // 
            // patientSexNames
            // 
            this.patientSexNames.Caption = "性别";
            this.patientSexNames.FieldName = "patientSexNames";
            this.patientSexNames.Name = "patientSexNames";
            this.patientSexNames.Visible = true;
            this.patientSexNames.VisibleIndex = 4;
            // 
            // patientCardNo
            // 
            this.patientCardNo.Caption = "身份证号";
            this.patientCardNo.FieldName = "patientCardNo";
            this.patientCardNo.MinWidth = 23;
            this.patientCardNo.Name = "patientCardNo";
            this.patientCardNo.Visible = true;
            this.patientCardNo.VisibleIndex = 7;
            this.patientCardNo.Width = 87;
            // 
            // sampleTime
            // 
            this.sampleTime.Caption = "采样时间";
            this.sampleTime.FieldName = "sampleTime";
            this.sampleTime.MinWidth = 23;
            this.sampleTime.Name = "sampleTime";
            this.sampleTime.Visible = true;
            this.sampleTime.VisibleIndex = 8;
            this.sampleTime.Width = 87;
            // 
            // receiveTime
            // 
            this.receiveTime.Caption = "接收时间";
            this.receiveTime.FieldName = "receiveTime";
            this.receiveTime.MinWidth = 23;
            this.receiveTime.Name = "receiveTime";
            this.receiveTime.Visible = true;
            this.receiveTime.VisibleIndex = 9;
            this.receiveTime.Width = 87;
            // 
            // sampleLocation
            // 
            this.sampleLocation.Caption = "采样地点";
            this.sampleLocation.FieldName = "sampleLocation";
            this.sampleLocation.MinWidth = 23;
            this.sampleLocation.Name = "sampleLocation";
            this.sampleLocation.Visible = true;
            this.sampleLocation.VisibleIndex = 10;
            this.sampleLocation.Width = 87;
            // 
            // passportNo
            // 
            this.passportNo.Caption = "证件号";
            this.passportNo.FieldName = "passportNo";
            this.passportNo.MinWidth = 23;
            this.passportNo.Name = "passportNo";
            this.passportNo.Visible = true;
            this.passportNo.VisibleIndex = 11;
            this.passportNo.Width = 87;
            // 
            // dstate
            // 
            this.dstate.Caption = "有效";
            this.dstate.FieldName = "dstate";
            this.dstate.Name = "dstate";
            // 
            // createTime
            // 
            this.createTime.Caption = "创建时间";
            this.createTime.FieldName = "createTime";
            this.createTime.Name = "createTime";
            this.createTime.Visible = true;
            this.createTime.VisibleIndex = 13;
            // 
            // creater
            // 
            this.creater.Caption = "创建者";
            this.creater.FieldName = "creater";
            this.creater.Name = "creater";
            this.creater.Visible = true;
            this.creater.VisibleIndex = 12;
            // 
            // FrmRYHandle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 632);
            this.Controls.Add(this.GCInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmRYHandle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "人员混检信息";
            this.Load += new System.EventHandler(this.FrmRYHandle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraGrid.Columns.GridColumn blendid;
        private DevExpress.XtraGrid.Columns.GridColumn id;
        private DevExpress.XtraGrid.Columns.GridColumn barcode;
        private DevExpress.XtraGrid.Columns.GridColumn patientName;
        private DevExpress.XtraGrid.Columns.GridColumn patientPhone;
        private DevExpress.XtraGrid.Columns.GridColumn patientCardNo;
        private DevExpress.XtraGrid.Columns.GridColumn sampleTime;
        private DevExpress.XtraGrid.Columns.GridColumn receiveTime;
        private DevExpress.XtraGrid.Columns.GridColumn sampleLocation;
        private DevExpress.XtraGrid.Columns.GridColumn passportNo;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem BTAdd;
        private DevExpress.XtraBars.BarButtonItem BTDelete;
        private DevExpress.XtraBars.BarButtonItem BTSave;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.Columns.GridColumn dstate;
        private DevExpress.XtraGrid.Columns.GridColumn ageYear;
        private DevExpress.XtraGrid.Columns.GridColumn patientSexNames;
        private DevExpress.XtraGrid.Columns.GridColumn createTime;
        private DevExpress.XtraGrid.Columns.GridColumn creater;
    }
}