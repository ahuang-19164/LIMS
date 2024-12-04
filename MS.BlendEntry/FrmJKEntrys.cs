using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using Ms.jikongHandle;
using Ms.jikongModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;

using System.Windows.Forms;

namespace MS.BlendEntry
{
    public partial class FrmJKEntrys : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// 架子孔数
        /// </summary>
        int conutNum = 0;
        //string JKEntry = "http://localhost:9600/api/BlendEntry";
        string EntryInfoJK = "http://localhost:9600/api/BlendEntry";
        public FrmJKEntrys()
        {
            InitializeComponent();
        }

        private void FrmBlendEntry_Load(object sender, EventArgs e)
        {
            //JKEntry = ConfigInfos.ReadConfigInfo("JKEntry");
            EntryInfoJK = ConfigInfos.ReadConfigInfo("EntryInfoJK");
            //DEstime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            //GEclientName.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            //xianjikong.GetToken();
            sampleInfos = new List<EntrysampleInfo>();
            //GridControls.formartGridView(GVinfo);
            //GridControls.showEmbeddedNavigator(GCInfo);
            GridLookUpEdites.Formats(GEclientName, DTHelper.DTEnable(WorkCommData.DTClientInfo));
        }

        List<EntrysampleInfo> sampleInfos;
        private void BTReceive_Click(object sender, EventArgs e)
        {
            if(conutNum>0)
            {
                if (GEclientName.EditValue != null)
                {
                    if (TEsgj.EditValue != null && TEsgj.EditValue.ToString().Trim() != "")
                    {

                        if (TEkw.EditValue != null && TEkw.EditValue.ToString().Trim() != "")
                        {
                            if (Convert.ToInt32(TEkw.EditValue) <= conutNum)
                            {


                                //if (CEmore.Checked || CEone.Checked)
                                //{
                                if (TEBarcode.EditValue != null && TEBarcode.EditValue.ToString().Trim().Length > 0)
                                {
                                    if (TEBarcode.EditValue.ToString() != "HL001")
                                    {
                                        //判断条码是否存在
                                        bool cfCode = false;
                                        string entryBarocde = TEBarcode.EditValue.ToString().Trim();
                                        EntrysampleInfo info = new EntrysampleInfo();


                                        info.creater = CommonData.UserInfo.names;
                                        info.barcode = entryBarocde;
                                        //info.receiveTime = info.createTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                                        info.clientCode = GEclientName.EditValue.ToString();
                                        info.frameNo = TEsgj.EditValue.ToString() + "-" + String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString();
                                        
                                        
                                        
                                        info.clientName = GEclientName.Text.ToString();


                                        //foreach (EntrysampleInfo sample in sampleInfos)
                                        //{
                                        //    if (sample.barcode == entryBarocde)
                                        //    {
                                        //        cfCode = true;
                                        //    }
                                        //}
                                        //if (cfCode)
                                        //{
                                        foreach (Control control in tablePanel.Controls)
                                        {
                                            if (control is SimpleButton)
                                            {
                                                SimpleButton simpleButton = control as SimpleButton;
                                                if (simpleButton.ToolTip.ToString() == entryBarocde)
                                                {
                                                    if (simpleButton.AllowDrop == true)
                                                    {
                                                        simpleButton.BackColor = Color.White;
                                                        simpleButton.Text = "";
                                                        simpleButton.ToolTip = "";
                                                        simpleButton.Appearance.BackColor = Color.White;
                                                    }
                                                }

                                                if (control.Tag.ToString() == TEkw.EditValue.ToString())
                                                {
                                                    if (simpleButton.AllowDrop == true)
                                                    {
                                                        simpleButton.BackColor = Color.YellowGreen;
                                                        simpleButton.Text = $"{TEsgj.EditValue.ToString() + "-" + String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n{entryBarocde}";
                                                        simpleButton.ToolTip = entryBarocde;
                                                        simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                                                    }
                                                    else
                                                    {
                                                        TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                                    }
                                                }
                                            }
                                        }
                                        //    //MessageBox.Show("试管号码已存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //    TEBarcode.SelectAll();
                                        //}
                                        //else
                                        //{
                                        //foreach (Control control in tablePanel.Controls)
                                        //{
                                        //    if (control is SimpleButton)
                                        //    {
                                        //        if (control.Tag.ToString() == TEkw.EditValue.ToString())
                                        //        {
                                        //            SimpleButton simpleButton = control as SimpleButton;
                                        //            if (simpleButton.AllowDrop == true)
                                        //            {
                                        //                simpleButton.BackColor = Color.YellowGreen;
                                        //                simpleButton.Text = $"{TEsgj.EditValue.ToString() + "-" + String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n{entryBarocde}";
                                        //                simpleButton.ToolTip = entryBarocde;
                                        //                simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                                        //            }
                                        //            else
                                        //            {
                                        //                TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                        //            }
                                        //        }
                                        //    }
                                        //}
                                        TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                        ////判断是否已经存在

                                        //foreach (EntrysampleInfo sample in sampleInfos)
                                        //{
                                        //    if (sample.barcode == entryBarocde)
                                        //    {
                                        //        cfCode = true;
                                        //    }
                                        //}
                                        //if (cfCode)
                                        //{
                                        //    sampleInfos.Add(info);
                                        //}
                                        EntryInfo entryInfo = new EntryInfo();
                                        entryInfo.UserName = CommonData.UserInfo.names;
                                        
                                        entryInfo.sampleinfo = info;
                                        string Sr = JsonHelper.SerializeObjct(entryInfo);
                                        WebApiCallBack jm = ApiHelpers.postInfo(EntryInfoJK, Sr);
                                        commReInfo<string> commReInfo = JsonHelper.JsonConvertObject<commReInfo<string>>(jm);
                                        if (commReInfo.code == 1)
                                        {
                                            MEsampleState.EditValue = entryBarocde + "接收成功！\r\n" + MEsampleState.EditValue;
                                        }
                                        else
                                        {
                                            MEsampleState.EditValue = entryBarocde + $":{commReInfo.msg}\r\n" + MEsampleState.EditValue;
                                            //MessageBox.Show("接收信息错误：" + commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        //}
                                        //}
                                    }
                                    else
                                    {
                                        //质控信息处理逻辑
                                        if (TEzk.EditValue != null && TEzk.EditValue.ToString().Trim() != "")
                                        {
                                            int kenum = Convert.ToInt32(TEzk.EditValue);
                                            for (int a = 0; a < kenum; a++)
                                            {
                                                if (Convert.ToInt32(TEkw.EditValue) > conutNum)
                                                {
                                                    MessageBox.Show("试管架已满，请使用下一架！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    break;
                                                }
                                                foreach (Control control in tablePanel.Controls)
                                                {
                                                    if (control is SimpleButton)
                                                    {
                                                        SimpleButton simpleButton = control as SimpleButton;
                                                        if (control.Tag.ToString() == TEkw.EditValue.ToString())
                                                        {
                                                            if (simpleButton.AllowDrop == true)
                                                            {
                                                                simpleButton.Text = $"{TEsgj.EditValue.ToString() + "-" + String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n质控编号:{String.Format("{0:00}", a)}";
                                                                simpleButton.ToolTip = $"";
                                                                simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                                                            }
                                                            else
                                                            {
                                                                TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                                            }
                                                        }
                                                    }
                                                }
                                                TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                            }

                                            //TEkw.EditValue = Convert.ToInt32(TEzk.EditValue) + Convert.ToInt32(TEkw.EditValue);
                                        }
                                        else
                                        {
                                            MessageBox.Show("请填写质控数量！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }

                                    }
                                }
                                else
                                {
                                    MessageBox.Show("条码号不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("试管架已满，请使用下一架！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("孔位号不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入试管架号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("请选择客户信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("架子孔数不能为0，请先确认架子信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            TEBarcode.SelectAll();
        }

        private void TEhospitalBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                BTReceive_Click(null, null);
                
            }
        }

        private void CEone_CheckedChanged(object sender, EventArgs e)
        {
            if (CEone.Checked)
            {
                CEmore.Checked = false;
            }
            else
            {
                CEmore.Checked = true ;
            }
                


                
        }

        private void CEmore_CheckedChanged(object sender, EventArgs e)
        {
            if (CEmore.Checked)
                CEone.Checked = false;

                
        }


        private void BTedit_Click(object sender, EventArgs e)
        {

        }

        private void BTsave_Click(object sender, EventArgs e)
        {

        }


        private void BTCreate_Click(object sender, EventArgs e)
        {
            //TablePanel tablePanel = new TablePanel();
            //layoutControl2.Size = new Size(100 * Convert.ToInt32(TEc.EditValue), 90* Convert.ToInt32(TEr.EditValue));
            //layoutControl2.MaximumSize = new Size(100 * Convert.ToInt32(TEc.EditValue), 90 * Convert.ToInt32(TEr.EditValue));
            //layoutControl2.MinimumSize = new Size(100 * Convert.ToInt32(TEc.EditValue), 90 * Convert.ToInt32(TEr.EditValue));

            //layoutControl2.Margin = new Padding(0, 0, 0, 0);

            conutNum = Convert.ToInt32(TEc.EditValue) * Convert.ToInt32(TEr.EditValue);
            layoutControl1.BeginUpdate();

            //tablePanel = new DevExpress.Utils.Layout.TablePanel();
            //layoutControl2.Controls.Add(tablePanel);
            //this.tablePanel.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            //new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            //new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            //tablePanel.Location = new System.Drawing.Point(12, 12);
            //tablePanel.Name = "tablePanel";
            //tablePanel.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            //new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F),
            //new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            //tablePanel.Size = new System.Drawing.Size(1081, 720);
            //tablePanel.TabIndex = 4;
            //// 
            //// layoutControlItem13
            //// 
            //layoutControlItem13.Control = this.tablePanel;
            //layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            //layoutControlItem13.Name = "layoutControlItem13";
            //layoutControlItem13.Size = new System.Drawing.Size(1085, 724);
            //layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            //layoutControlItem13.TextVisible = false;





            //tablePanel = new DevExpress.Utils.Layout.TablePanel();
            //layoutControlItem13.Control = this.tablePanel;
            tablePanel.Rows.Clear();
            tablePanel.Columns.Clear();
            tablePanel.Controls.Clear();
            tablePanel.Size = new Size(100 * Convert.ToInt32(TEc.EditValue) + 20, 70 * Convert.ToInt32(TEr.EditValue) + 20);
            tablePanel.MaximumSize = new Size(100 * Convert.ToInt32(TEc.EditValue) + 20, 70 * Convert.ToInt32(TEr.EditValue) + 20);
            tablePanel.MinimumSize = new Size(100 * Convert.ToInt32(TEc.EditValue) + 20, 70 * Convert.ToInt32(TEr.EditValue) + 20);
            tablePanel.Rows.Add(new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20.00f));
            tablePanel.Columns.Add(new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20.00f));
            for (int r = 0; r < Convert.ToInt32(TEr.EditValue); r++)
            {
                Label label = new Label();
                //label.Text = (r + 1).ToString();
                label.Text =Convert.ToChar('A' + r).ToString() ;
                label.Dock = DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tablePanel.SetColumn(label, 0);
                tablePanel.SetRow(label, r + 1);
                tablePanel.Rows.Add(new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, (tablePanel.Size.Height - 20) / Convert.ToInt32(TEr.EditValue)));
                tablePanel.Rows.Add(new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, (tablePanel.Size.Height - 20) / Convert.ToInt32(TEr.EditValue)));
                //tablePanel.Rows.Add(new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80));
                tablePanel.Controls.Add(label);
            }
            for (int c = 0; c < Convert.ToInt32(TEc.EditValue); c++)
            {
                Label label = new Label();
                label.Text = (c + 1).ToString();
                label.Dock = DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tablePanel.SetColumn(label, c + 1);
                tablePanel.SetRow(label, 0);
                tablePanel.Columns.Add(new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, (tablePanel.Size.Width - 20) / Convert.ToInt32(TEc.EditValue)));
                //tablePanel.Columns.Add(new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80));
                tablePanel.Controls.Add(label);
            }

            //LayoutControlItem layoutControlItem = new LayoutControlItem();
            tablePanel.ShowGrid = DevExpress.Utils.DefaultBoolean.True;
            //tablePanel.AutoSize = true;
            tablePanel.AutoScroll = true;




            //layoutControlItem.Control = tablePanel;
            //layoutControlItem.Name = "Item";
            ////layoutControlItem.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            //layoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            //layoutControlItem.TextVisible = false;
            ////tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;

            //layoutControl1.Root.AddItem(layoutControlItem);

            int a = 0;

            //for (int r = 0; r < Convert.ToInt32(TEr.EditValue); r++)
            for (int c = 0; c < Convert.ToInt32(TEc.EditValue); c++)
            {
                //for (int c = 0; c < Convert.ToInt32(TEc.EditValue); c++)
                for (int r = 0; r < Convert.ToInt32(TEr.EditValue); r++)
                {
                    a++;
                    SimpleButton simpleButton = new SimpleButton();
                    simpleButton.Appearance.BackColor = System.Drawing.Color.White;
                    tablePanel.Controls.Add(simpleButton);
                    tablePanel.SetColumn(simpleButton, c + 1);
                    simpleButton.Name = "BT" + a.ToString();
                    tablePanel.SetRow(simpleButton, r + 1);
                    //simpleButton.Size = new System.Drawing.Size(100, 70);
                    simpleButton.Dock = DockStyle.Fill;
                    simpleButton.TabIndex = a;
                    simpleButton.Tag = a;
                    simpleButton.AllowDrop = true;
                    //simpleButton.AllowDrop = true;
                    //simpleButton.ToolTipTitle = "0";
                    //simpleButton.Text = "BT" + a.ToString();
                    //simpleButton.all = "BT" + a.ToString();

                    simpleButton.Click += SimpleButton_Click; ;
                    simpleButton.DoubleClick += SimpleButton_DoubleClick;
                }

            }


            //layoutControl1.ShowPrintPreview();

            layoutControl1.EndUpdate();

        }

        private void SimpleButton_DoubleClick(object sender, EventArgs e)
        {
            SelectSimpleButton = sender as SimpleButton;
            if (SelectSimpleButton.AllowDrop ==true)
            {
                SelectSimpleButton.AllowDrop = false;
                SelectSimpleButton.Appearance.BackColor = Color.GreenYellow;
                //TEkw.EditValue = SimpleButton.Tag;
                //SimpleButton.ToolTipTitle = "1";
            }
            else
            {
                SelectSimpleButton.AllowDrop = true;
                //SimpleButton = sender as SimpleButton;
                //TEkw.EditValue = SimpleButton.Tag;
                SelectSimpleButton.Appearance.BackColor =Color.White;
                //SimpleButton.ToolTipTitle = "0";
            }
        }

        SimpleButton SelectSimpleButton;
        private void SimpleButton_Click(object sender, EventArgs e)
        {
            SelectSimpleButton = sender as SimpleButton;
            TEkw.EditValue = SelectSimpleButton.Tag;
        }

        private void BTPrint_Click(object sender, EventArgs e)
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(ps);
            //link.Component = gridControl1;
            link.Component = layoutControl2;




            //是否为横版
            link.Landscape = true;
            link.PaperKind = PaperKind.A4;
            //link.PaperKind = PaperKind.A4;
            link.Margins = new Margins(20, 20, 80, 50);
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            //phf.Header.Content.AddRange(new string[] { "", drv["线路名"].ToString() + "站点信息表", "" });
            phf.Header.Content.AddRange(new string[] { "", "试管架清单", $"试管架编号:{TEsgj.EditValue}" });
            //phf..AddRange(new string[] { "", "试管架清单", "当前时间"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
            phf.Header.Font = new System.Drawing.Font("宋体", 16, System.Drawing.FontStyle.Regular);
            phf.Header.LineAlignment = BrickAlignment.Center;
            phf.Footer.Content.Clear();
            //phf.Footer.Content.AddRange(new string[] { "", "", $"打印人:{CommonData.UserInfo.names}       " + String.Format("打印时间: {0:g}", DateTime.Now) });
            //phf.Footer.Content.AddRange(new string[] { "流水号:", "打印人:", $"交接人:            " + String.Format("打印时间: {0:g}", DateTime.Now) });
            phf.Footer.Content.AddRange(new string[] { "流水号:", $"交接人:_______________________________   交接时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}   接收人:____________________________  " });
            phf.Footer.LineAlignment = BrickAlignment.Center;
            link.CreateDocument();
            link.ShowPreviewDialog();
        }


        private void TEkw_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
        }

        private void TEr_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
        }

        private void TEc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar < '0' || e.KeyChar > '9'; //允许输入数字
            if (e.KeyChar == (char)8) //允许输入回退键
            {
                e.Handled = false;
            }
        }

        private void TEsgj_EditValueChanged(object sender, EventArgs e)
        {
            TEkw.EditValue = 1;
        }

        private void BTAddQC_Click(object sender, EventArgs e)
        {
            if (TEzk.EditValue != null && TEzk.EditValue.ToString().Trim() != "")
            {
                int kenum = Convert.ToInt32(TEzk.EditValue);
                for (int a = 0; a < kenum; a++)
                {
                    if (Convert.ToInt32(TEkw.EditValue) > conutNum)
                    {
                        MessageBox.Show("试管架已满，请使用下一架！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                    foreach (Control control in tablePanel.Controls)
                    {
                        if (control is SimpleButton)
                        {
                            if (control.Tag.ToString() == TEkw.EditValue.ToString())
                            {
                                SimpleButton simpleButton = control as SimpleButton;
                                if (simpleButton.AllowDrop == true)
                                {

                                    simpleButton.Text = $"{TEsgj.EditValue.ToString() +"-"+ String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n质控编号:{String.Format("{0:00}", a)}";
                                    simpleButton.ToolTip = $"";
                                    simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                                }
                                else
                                {
                                    TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                }
                            }
                        }
                    }
                    TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                }
                //TEkw.EditValue = Convert.ToInt32(TEzk.EditValue) + Convert.ToInt32(TEkw.EditValue);
            }
            else
            {
                MessageBox.Show("请填写质控数量！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            foreach (Control control in tablePanel.Controls)
            {
                if (control is SimpleButton)
                {
                    
                    SimpleButton simpleButton = control as SimpleButton;
                    ///simpleButton.AllowDrop = true;
                    if (simpleButton.AllowDrop == true)
                    {
                        simpleButton.Appearance.BackColor = System.Drawing.Color.White;
                        simpleButton.Text = "";
                        simpleButton.ToolTip = "";
                    }
                }
            }
            TEkw.EditValue = 1;
        }
    }
}
