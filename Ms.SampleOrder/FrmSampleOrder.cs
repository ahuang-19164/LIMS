
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ms.SampleOrder
{
    public partial class FrmSampleOrder : XtraForm
    {
        public FrmSampleOrder()
        {
            InitializeComponent();
        }
        LayoutControl layoutControl = null;
        //LayoutControlGroup layoutControlGroup = null;
        private void BTCreate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            layoutControl = new LayoutControl();
            panelControl.Controls.Add(layoutControl);
            layoutControl.Dock = DockStyle.Fill;
            //layoutControlGroup= new LayoutControlGroup();
            layoutControl.Root.Name= "root";
            layoutControl.Root.TextVisible = false;
            layoutControl.Root.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            //layoutControl.Root.Clear();

            //layoutControl.Root.OptionsTableLayoutGroup.ColumnDefinitions.Clear();

            //layoutControlGroup.GroupStyle =new DevExpress.XtraLayout.Utils.GroupStyle.;

            layoutControl.Root.GroupBordersVisible = false;
            layoutControl.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            //layoutControl.Root.OptionsTableLayoutGroup.RowDefinitions[0].SizeType = System.Windows.Forms.SizeType.Percent;
            //layoutControl.Root.OptionsTableLayoutGroup.RowDefinitions[0].Height = Convert.ToDouble(1 / Convert.ToDouble(TERow.EditValue));
            for (int a = 0; a < Convert.ToInt32(TERow.EditValue)-1; a++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                columnDefinition.SizeType = System.Windows.Forms.SizeType.Percent;
                //columnDefinition.Width = Convert.ToDouble(1/ Convert.ToDouble(TERow.EditValue));
                layoutControl.Root.OptionsTableLayoutGroup.ColumnDefinitions.Add(columnDefinition);
            }
            for (int a = 0; a < Convert.ToInt32(TEColumns.EditValue)-1; a++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.SizeType = System.Windows.Forms.SizeType.Percent;
                //rowDefinition.Height = Convert.ToDouble(1/ Convert.ToDouble(TEColumns.EditValue));
                layoutControl.Root.OptionsTableLayoutGroup.RowDefinitions.Add(rowDefinition);
            }
            double sdddd = 1 / Convert.ToDouble(TERow.EditValue);
            double sdadddd = 1 / Convert.ToDouble(TEColumns.EditValue);

            for (int a = 0; a < layoutControl.Root.OptionsTableLayoutGroup.ColumnDefinitions.Count; a++)
            {
                layoutControl.Root.OptionsTableLayoutGroup.ColumnDefinitions[a].SizeType = System.Windows.Forms.SizeType.Percent;
                layoutControl.Root.OptionsTableLayoutGroup.ColumnDefinitions[a].Width = Convert.ToDouble(1 / Convert.ToDouble(TERow.EditValue));
            }
            for (int a = 0; a < layoutControl.Root.OptionsTableLayoutGroup.RowDefinitions.Count; a++)
            {
                layoutControl.Root.OptionsTableLayoutGroup.RowDefinitions[a].SizeType = System.Windows.Forms.SizeType.Percent;
                layoutControl.Root.OptionsTableLayoutGroup.RowDefinitions[a].Height = Convert.ToDouble(1 / Convert.ToDouble(TERow.EditValue));
            }

            layoutControl.Root.OptionsTableLayoutGroup.RemoveRowAt(1);
            layoutControl.Root.OptionsTableLayoutGroup.RemoveRowAt(2);
            //layoutControl.Root.OptionsTableLayoutGroup.RemoveColumnAt(2);
            layoutControl.Root.OptionsTableLayoutGroup.RemoveColumnAt(1);
            //layoutControl.AddGroup(layoutControlGroup);


















            //TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            //tableLayoutPanel.RowCount = Convert.ToInt32(TERow.EditValue);
            //for(int a=0;a< Convert.ToInt32(TERow.EditValue);a++)
            //{
            //    tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            //}



            //tableLayoutPanel.ColumnCount = Convert.ToInt32(TEColumns.EditValue);
            //for (int a = 0; a < Convert.ToInt32(TERow.EditValue); a++)
            //{
            //    tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            //}


            //panelControl.Controls.Add(tableLayoutPanel);
            //tableLayoutPanel.Location =new Point(0,0);
            ////tableLayoutPanel.CellPaint += tableLayoutPanel1_CellPaint;
            ////tableLayoutPanel.BackColor = Color.Red;

        }
        void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 1 && e.Row == 0)
            {
                var rectangle = e.CellBounds;
                rectangle.Inflate(-1, -1);

                //ControlPaint.DrawBorder3D(e.Graphics, rectangle, Border3DStyle.Raised, Border3DSide.All); // 3D border
                ControlPaint.DrawBorder(e.Graphics, rectangle, Color.Red, ButtonBorderStyle.Dotted); // dotted border
            }
        }
        int a = 0;
        int b = 0;
        private void BTAddControl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            SimpleButton simpleButton = new SimpleButton();
            simpleButton.Text = "test";

            LayoutControlItem layoutControlItem = new LayoutControlItem();
            //layoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            layoutControlItem.Control = simpleButton;
            //layoutControlItem.Location = new System.Drawing.Point(89, 0);
            layoutControlItem.MinSize = new System.Drawing.Size(200, 200);
            layoutControlItem.MaxSize = new System.Drawing.Size(200, 200);
            //layoutControlItem.Name = "layoutControlItem2";
            layoutControlItem.OptionsTableLayoutItem.ColumnIndex = a;
            layoutControlItem.OptionsTableLayoutItem.RowIndex = b;
            //layoutControlItem.Size = new System.Drawing.Size(89, 61);
            //layoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            //layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            layoutControlItem.TextVisible = false;
            layoutControl.Root.AddItem(layoutControlItem);
            //layoutControl.Controls.Add(simpleButton);
            a++;
            b++;
        }

        private void BTprint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(ps);
            link.Component = layoutControl;


            //是否为横版
            link.Landscape = true;
            //link.PaperKind = PaperKind.A4Extra;
            link.PaperKind = PaperKind.A4;
            link.Margins = new Margins(20, 20, 80, 50);
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            //phf.Header.Content.AddRange(new string[] { "", drv["线路名"].ToString() + "站点信息表", "" });
            phf.Header.Content.AddRange(new string[] { "", "试管架清单", "" });
            phf.Header.Font = new System.Drawing.Font("宋体", 16, System.Drawing.FontStyle.Regular);
            phf.Header.LineAlignment = BrickAlignment.Center;
            phf.Footer.Content.Clear();
            //phf.Footer.Content.AddRange(new string[] { "", "", $"打印人:{CommonData.UserInfo.names}       " + String.Format("打印时间: {0:g}", DateTime.Now) });
            phf.Footer.Content.AddRange(new string[] { "", "", $"打印人:aaaaaaa       " + String.Format("打印时间: {0:g}", DateTime.Now) });
            phf.Footer.LineAlignment = BrickAlignment.Center;
            link.CreateDocument();
            link.ShowPreview();
            //layoutControl.ShowPrintPreview();
            ////OptionsView  = new OptionsView();
            ////optionsView.
            //layoutControl.op
        }
    }
}
