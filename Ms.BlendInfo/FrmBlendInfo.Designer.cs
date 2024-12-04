
namespace Ms.BlendInfo
{
    partial class FrmBlendInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBlendInfo));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.TEbarcode = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TEpatientName = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TEpatientPhone = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TEpatientCardNo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.TEpassportNo = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.DEStartTime = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.DEEndTime = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.BTSelect = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.GCInfo = new DevExpress.XtraGrid.GridControl();
            this.GVInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.blendid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barcode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.testStateNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RGEtestStateNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.hospitalNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientSexNames = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ageYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientCardNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.passportNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sampleTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.receiveTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.testRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.patientAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEtestStateNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.TEbarcode,
            this.TEpatientName,
            this.TEpatientPhone,
            this.TEpatientCardNo,
            this.BTSelect,
            this.TEpassportNo,
            this.DEStartTime,
            this.DEEndTime});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3,
            this.repositoryItemTextEdit4,
            this.repositoryItemTextEdit5,
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(60, 139);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEbarcode, "", false, true, true, 135, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEpatientName, "", false, true, true, 98, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEpatientPhone, "", false, true, true, 143, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEpatientCardNo, "", false, true, true, 185, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.TEpassportNo, "", false, true, true, 152, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.DEStartTime, "", false, true, true, 115, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.DEEndTime, "", false, true, true, 109, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.BTSelect, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // TEbarcode
            // 
            this.TEbarcode.Caption = "条码号:";
            this.TEbarcode.Edit = this.repositoryItemTextEdit1;
            this.TEbarcode.Id = 0;
            this.TEbarcode.Name = "TEbarcode";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // TEpatientName
            // 
            this.TEpatientName.Caption = "姓名:";
            this.TEpatientName.Edit = this.repositoryItemTextEdit2;
            this.TEpatientName.Id = 1;
            this.TEpatientName.Name = "TEpatientName";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // TEpatientPhone
            // 
            this.TEpatientPhone.Caption = "联系电话:";
            this.TEpatientPhone.Edit = this.repositoryItemTextEdit3;
            this.TEpatientPhone.Id = 2;
            this.TEpatientPhone.Name = "TEpatientPhone";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // TEpatientCardNo
            // 
            this.TEpatientCardNo.Caption = "身份证号:";
            this.TEpatientCardNo.Edit = this.repositoryItemTextEdit4;
            this.TEpatientCardNo.Id = 3;
            this.TEpatientCardNo.Name = "TEpatientCardNo";
            // 
            // repositoryItemTextEdit4
            // 
            this.repositoryItemTextEdit4.AutoHeight = false;
            this.repositoryItemTextEdit4.Name = "repositoryItemTextEdit4";
            // 
            // TEpassportNo
            // 
            this.TEpassportNo.Caption = "其他证件号:";
            this.TEpassportNo.Edit = this.repositoryItemTextEdit5;
            this.TEpassportNo.Id = 5;
            this.TEpassportNo.Name = "TEpassportNo";
            // 
            // repositoryItemTextEdit5
            // 
            this.repositoryItemTextEdit5.AutoHeight = false;
            this.repositoryItemTextEdit5.Name = "repositoryItemTextEdit5";
            // 
            // DEStartTime
            // 
            this.DEStartTime.Caption = "查询日期:";
            this.DEStartTime.Edit = this.repositoryItemDateEdit1;
            this.DEStartTime.Id = 6;
            this.DEStartTime.Name = "DEStartTime";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // DEEndTime
            // 
            this.DEEndTime.Caption = "--";
            this.DEEndTime.Edit = this.repositoryItemDateEdit2;
            this.DEEndTime.Id = 7;
            this.DEEndTime.Name = "DEEndTime";
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // BTSelect
            // 
            this.BTSelect.Caption = "查询";
            this.BTSelect.Id = 4;
            this.BTSelect.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BTSelect.ImageOptions.Image")));
            this.BTSelect.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("BTSelect.ImageOptions.LargeImage")));
            this.BTSelect.Name = "BTSelect";
            this.BTSelect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BTSelect_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1524, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 659);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1524, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 635);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1524, 24);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 635);
            // 
            // GCInfo
            // 
            this.GCInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCInfo.Location = new System.Drawing.Point(0, 24);
            this.GCInfo.MainView = this.GVInfo;
            this.GCInfo.MenuManager = this.barManager1;
            this.GCInfo.Name = "GCInfo";
            this.GCInfo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RGEtestStateNO});
            this.GCInfo.Size = new System.Drawing.Size(1524, 635);
            this.GCInfo.TabIndex = 4;
            this.GCInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.GVInfo});
            // 
            // GVInfo
            // 
            this.GVInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.blendid,
            this.barcode,
            this.testStateNO,
            this.hospitalNames,
            this.patientName,
            this.patientSexNames,
            this.ageYear,
            this.patientPhone,
            this.patientCardNo,
            this.passportNo,
            this.sampleLocation,
            this.sampleTime,
            this.receiveTime,
            this.testRemark,
            this.patientAddress});
            this.GVInfo.GridControl = this.GCInfo;
            this.GVInfo.Name = "GVInfo";
            // 
            // blendid
            // 
            this.blendid.Caption = "编号";
            this.blendid.FieldName = "blendid";
            this.blendid.Name = "blendid";
            this.blendid.OptionsColumn.AllowFocus = false;
            this.blendid.Visible = true;
            this.blendid.VisibleIndex = 0;
            // 
            // barcode
            // 
            this.barcode.Caption = "条码号";
            this.barcode.FieldName = "barcode";
            this.barcode.Name = "barcode";
            this.barcode.Visible = true;
            this.barcode.VisibleIndex = 1;
            // 
            // testStateNO
            // 
            this.testStateNO.Caption = "样本状态";
            this.testStateNO.ColumnEdit = this.RGEtestStateNO;
            this.testStateNO.FieldName = "testStateNO";
            this.testStateNO.Name = "testStateNO";
            this.testStateNO.OptionsColumn.AllowFocus = false;
            this.testStateNO.Visible = true;
            this.testStateNO.VisibleIndex = 2;
            // 
            // RGEtestStateNO
            // 
            this.RGEtestStateNO.AutoHeight = false;
            this.RGEtestStateNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RGEtestStateNO.Name = "RGEtestStateNO";
            this.RGEtestStateNO.PopupView = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // hospitalNames
            // 
            this.hospitalNames.Caption = "客户名称";
            this.hospitalNames.FieldName = "hospitalNames";
            this.hospitalNames.Name = "hospitalNames";
            this.hospitalNames.OptionsColumn.AllowFocus = false;
            this.hospitalNames.Visible = true;
            this.hospitalNames.VisibleIndex = 3;
            // 
            // patientName
            // 
            this.patientName.Caption = "姓名";
            this.patientName.FieldName = "patientName";
            this.patientName.Name = "patientName";
            this.patientName.Visible = true;
            this.patientName.VisibleIndex = 4;
            // 
            // patientSexNames
            // 
            this.patientSexNames.Caption = "性别";
            this.patientSexNames.FieldName = "patientSexNames";
            this.patientSexNames.Name = "patientSexNames";
            this.patientSexNames.Visible = true;
            this.patientSexNames.VisibleIndex = 5;
            // 
            // ageYear
            // 
            this.ageYear.Caption = "年龄";
            this.ageYear.FieldName = "ageYear";
            this.ageYear.Name = "ageYear";
            this.ageYear.Visible = true;
            this.ageYear.VisibleIndex = 6;
            // 
            // patientPhone
            // 
            this.patientPhone.Caption = "联系方式";
            this.patientPhone.FieldName = "patientPhone";
            this.patientPhone.Name = "patientPhone";
            this.patientPhone.Visible = true;
            this.patientPhone.VisibleIndex = 7;
            // 
            // patientCardNo
            // 
            this.patientCardNo.Caption = "身份证号";
            this.patientCardNo.FieldName = "patientCardNo";
            this.patientCardNo.Name = "patientCardNo";
            this.patientCardNo.Visible = true;
            this.patientCardNo.VisibleIndex = 8;
            // 
            // passportNo
            // 
            this.passportNo.Caption = "其他证件号";
            this.passportNo.FieldName = "passportNo";
            this.passportNo.Name = "passportNo";
            this.passportNo.Visible = true;
            this.passportNo.VisibleIndex = 9;
            // 
            // sampleLocation
            // 
            this.sampleLocation.Caption = "采样地点";
            this.sampleLocation.FieldName = "sampleLocation";
            this.sampleLocation.Name = "sampleLocation";
            this.sampleLocation.Visible = true;
            this.sampleLocation.VisibleIndex = 10;
            // 
            // sampleTime
            // 
            this.sampleTime.Caption = "采样时间";
            this.sampleTime.FieldName = "sampleTime";
            this.sampleTime.Name = "sampleTime";
            this.sampleTime.OptionsColumn.AllowFocus = false;
            this.sampleTime.Visible = true;
            this.sampleTime.VisibleIndex = 11;
            // 
            // receiveTime
            // 
            this.receiveTime.Caption = "接收时间";
            this.receiveTime.FieldName = "receiveTime";
            this.receiveTime.Name = "receiveTime";
            this.receiveTime.OptionsColumn.AllowFocus = false;
            this.receiveTime.Visible = true;
            this.receiveTime.VisibleIndex = 12;
            // 
            // testRemark
            // 
            this.testRemark.Caption = "生成单位";
            this.testRemark.FieldName = "testRemark";
            this.testRemark.Name = "testRemark";
            this.testRemark.OptionsColumn.AllowFocus = false;
            this.testRemark.Visible = true;
            this.testRemark.VisibleIndex = 13;
            // 
            // patientAddress
            // 
            this.patientAddress.Caption = "样本来源";
            this.patientAddress.FieldName = "patientAddress";
            this.patientAddress.Name = "patientAddress";
            this.patientAddress.OptionsColumn.AllowFocus = false;
            this.patientAddress.Visible = true;
            this.patientAddress.VisibleIndex = 14;
            // 
            // FrmBlendInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 659);
            this.Controls.Add(this.GCInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmBlendInfo";
            this.Text = "混采信息查询";
            this.Load += new System.EventHandler(this.FrmBlendInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GCInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGEtestStateNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem TEbarcode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem TEpatientName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarEditItem TEpatientPhone;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraBars.BarEditItem TEpatientCardNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit4;
        private DevExpress.XtraBars.BarEditItem TEpassportNo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit5;
        private DevExpress.XtraBars.BarEditItem DEStartTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem DEEndTime;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem BTSelect;
        private DevExpress.XtraGrid.GridControl GCInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView GVInfo;
        private DevExpress.XtraGrid.Columns.GridColumn blendid;
        private DevExpress.XtraGrid.Columns.GridColumn barcode;
        private DevExpress.XtraGrid.Columns.GridColumn testStateNO;
        private DevExpress.XtraGrid.Columns.GridColumn hospitalNames;
        private DevExpress.XtraGrid.Columns.GridColumn patientName;
        private DevExpress.XtraGrid.Columns.GridColumn patientSexNames;
        private DevExpress.XtraGrid.Columns.GridColumn ageYear;
        private DevExpress.XtraGrid.Columns.GridColumn patientPhone;
        private DevExpress.XtraGrid.Columns.GridColumn patientCardNo;
        private DevExpress.XtraGrid.Columns.GridColumn passportNo;
        private DevExpress.XtraGrid.Columns.GridColumn sampleLocation;
        private DevExpress.XtraGrid.Columns.GridColumn sampleTime;
        private DevExpress.XtraGrid.Columns.GridColumn receiveTime;
        private DevExpress.XtraGrid.Columns.GridColumn testRemark;
        private DevExpress.XtraGrid.Columns.GridColumn patientAddress;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit RGEtestStateNO;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
    }
}