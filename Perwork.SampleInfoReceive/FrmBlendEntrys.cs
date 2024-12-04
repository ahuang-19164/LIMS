using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.PerModel;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perwork.SampleInfoReceive
{
    public partial class FrmBlendEntrys : DevExpress.XtraEditors.XtraForm
    {
        int conutNum = 0;
        string BlendEntry = "http://localhost:9600/api/BlendEntry";
        string TestReceiveDT = "";
        string TestReceiveInfo = "";
        public FrmBlendEntrys()
        {
            InitializeComponent();
        }

        private void FrmBlendEntry_Load(object sender, EventArgs e)
        {
            BlendEntry = ConfigInfos.ReadConfigInfo("BlendEntry");


            TestReceiveDT = ConfigInfos.ReadConfigInfo("TestReceiveDT");
            TestReceiveInfo = ConfigInfos.ReadConfigInfo("TestReceiveInfo");




            //DEstime.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            //GEclientName.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTClientInfo);
            //xianjikong.GetToken();
            sampleInfos = new List<ReceiveSampleInfoModel>();
            //GridControls.formartGridView(GVinfo);
            //GridControls.showEmbeddedNavigator(GCInfo);
            GridLookUpEdites.Formats(GEgroupNOs, DTHelper.DTEnable(WorkCommData.DTGroupTest));
        }

        List<ReceiveSampleInfoModel> sampleInfos;

        //DataTable sampleInfoTable = null;
        private void BTReceive_Click(object sender, EventArgs e)
        {

            if (GEgroupNOs.EditValue != null)
            {
                if (TEbarcode.EditValue != null && TEbarcode.EditValue.ToString().Trim().Length > 0)
                {
                    bool receiveState = true;
                    bool cfCode = false;//条码是否重复
                    if (TEbarcode.EditValue.ToString() != "HL001")
                    {

                        TEbarcode.Enabled = false;
                        foreach (ReceiveSampleInfoModel sample in sampleInfos)
                        {
                            if (sample.barcode == TEbarcode.EditValue.ToString().Trim())
                            {
                                cfCode = true;
                                receiveState = false;
                            }
                        }
                        if (cfCode)
                        {
                            foreach (Control control in tablePanel.Controls)
                            {
                                if (control is SimpleButton)
                                {
                                    SimpleButton simpleButton = control as SimpleButton;
                                    if (simpleButton.ToolTip.ToString() == TEbarcode.EditValue.ToString())
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
                                            simpleButton.Text = $"{TEsgj.EditValue.ToString() + "-" + String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n{TEbarcode.EditValue}\r\n";
                                            simpleButton.ToolTip = TEbarcode.EditValue.ToString();
                                            simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                                        }
                                        else
                                        {
                                            TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                        }
                                    }
                                }
                            }
                            //MessageBox.Show("试管号码已存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            TEbarcode.SelectAll();
                        }
                        if (receiveState)
                        {
                            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在加载数据请稍等......");
                            ReceiveSelectModel receiveSelect = new ReceiveSelectModel();
                            receiveSelect.UserName = CommonData.UserInfo.names;
                            
                            receiveSelect.barcode = TEbarcode.EditValue.ToString().Trim();
                            receiveSelect.groupNO = GEgroupNOs.EditValue.ToString();
                            string Sr =JsonHelper.SerializeObjct(receiveSelect);
                            
                            WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveDT, Sr);
                            DataTable dataTable = JsonHelper.StringToDT(jm);
                            if (dataTable != null && dataTable.Rows.Count > 0)
                            {
                                ReceiveSampleInfoModel sampleInfo = new ReceiveSampleInfoModel();
                                sampleInfo.barcode = dataTable.Rows[0]["barcode"] != DBNull.Value ? dataTable.Rows[0]["barcode"].ToString() : "";
                                sampleInfo.testid = dataTable.Rows[0]["id"] != DBNull.Value ? Convert.ToInt32(dataTable.Rows[0]["id"]) : 0;
                                //sampleInfo.clientName = data.Rows[0]["hospitalNames"] != DBNull.Value ? data.Rows[0]["hospitalNames"].ToString() : "";
                                //sampleInfo.sampleLocation = data.Rows[0]["sampleLocation"] != DBNull.Value ? data.Rows[0]["sampleLocation"].ToString() : "";
                                //sampleInfo.patientName = data.Rows[0]["patientName"] != DBNull.Value ? data.Rows[0]["patientName"].ToString() : "";
                                sampleInfo.perid = dataTable.Rows[0]["perid"] != DBNull.Value ? Convert.ToInt32(dataTable.Rows[0]["perid"]) : 0;
                                sampleInfo.testNo = dataTable.Rows[0]["id"] != DBNull.Value ? dataTable.Rows[0]["id"].ToString() : "";
                                //sampleInfo.frameNo = data.Rows[0]["id"] != DBNull.Value ? data.Rows[0]["id"].ToString() : "";
                                sampleInfo.frameNo = TEsgj.EditValue.ToString() +"-"+ String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString();


                                string sampleLocation= dataTable.Rows[0]["sampleLocation"] != DBNull.Value ? dataTable.Rows[0]["sampleLocation"].ToString() : "";

                                sampleInfos.Add(sampleInfo);

                                foreach (Control control in tablePanel.Controls)
                                {
                                    if (control is SimpleButton)
                                    {
                                        if (control.Tag.ToString() == TEkw.EditValue.ToString())
                                        {
                                            SimpleButton simpleButton = control as SimpleButton;
                                            if (simpleButton.AllowDrop == true)
                                            {
                                                foreach (ReceiveSampleInfoModel info in sampleInfos)
                                                {
                                                    if (info.barcode == simpleButton.ToolTip)
                                                    {
                                                        sampleInfos.Remove(info);
                                                    }
                                                }
                                                simpleButton.BackColor = Color.YellowGreen;
                                                simpleButton.Text = $"{TEsgj.EditValue.ToString() +"-"+ String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n{sampleInfo.barcode}\r\n{sampleLocation}";
                                                //simpleButton.Text = $"{TEsgj.EditValue.ToString() +"-"+ String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n{sampleInfo.barcode}\r\n{sampleInfo.sampleLocation}";
                                                simpleButton.ToolTip = sampleInfo.barcode;
                                                simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
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
                            else
                            {
                                MessageBox.Show("未找到标本信息。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            frmWait.HideMe(this);
                        }
                        else
                        {
                            MessageBox.Show("条码信息已存在。", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
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
                    MessageBox.Show("输入的条码信息有误！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("请先选择专业组信息！", "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            TEbarcode.SelectAll();

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

        //private void BTdel_Click(object sender, EventArgs e)
        //{
        //    sampleInfo dataRow = GVinfo.GetFocusedRow() as sampleInfo;
        //    if(dataRow != null)
        //    {
        //        uInfo uInfo = new uInfo();
        //        uInfo.TableName = "WorkPer.SampleInfo";
        //        uInfo.value = "dstate=1";
        //        uInfo.wheres = $"barcode='{dataRow.barcode}' and perState=1";
        //        uInfo.MessageShow = 1;
        //        ApiHelpers.postInfo(uInfo);
        //        sampleInfos.Remove(dataRow);
        //        GCInfo.DataSource = new BindingList<sampleInfo>(sampleInfos);
        //    }
        //    else
        //    {
        //        MessageBox.Show("请选择需要删除的信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }

        //}

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



        private void BTCreate_Click(object sender, EventArgs e)
        {
            //TablePanel tablePanel = new TablePanel();
            //layoutControl2.Size = new Size(100 * Convert.ToInt32(TEc.EditValue), 90* Convert.ToInt32(TEr.EditValue));
            //layoutControl2.MaximumSize = new Size(100 * Convert.ToInt32(TEc.EditValue), 90 * Convert.ToInt32(TEr.EditValue));
            //layoutControl2.MinimumSize = new Size(100 * Convert.ToInt32(TEc.EditValue), 90 * Convert.ToInt32(TEr.EditValue));

            //layoutControl2.Margin = new Padding(0, 0, 0, 0);

            conutNum = Convert.ToInt32(TEc.EditValue) * Convert.ToInt32(TEr.EditValue);
            layoutControl1.BeginUpdate();

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
                label.Text = Convert.ToChar('A' + r).ToString();
                label.Dock = DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tablePanel.SetColumn(label, 0);
                tablePanel.SetRow(label, r + 1);
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

            ////LayoutControlItem layoutControlItem = new LayoutControlItem();
            //tablePanel.ShowGrid = DevExpress.Utils.DefaultBoolean.True;
            ////tablePanel.AutoSize = true;
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
                    simpleButton.ToolTipTitle = "0";
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
            if (SelectSimpleButton.AllowDrop == true)
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
                SelectSimpleButton.Appearance.BackColor = Color.White;
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
            phf.Footer.Content.AddRange(new string[] { "流水号:", $"交接人:_________________   交接时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}   接收人人:______________  " });
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

        private void BTEnterRecive_Click(object sender, EventArgs e)
        {
            FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this,"", "正在处理接收信息，请稍等......");
            BTEnterRecive.Enabled = false;




            foreach (ReceiveSampleInfoModel receiveSample in sampleInfos)
            {
                #region
                ReceiveInfoModel receiveInfoModel = new ReceiveInfoModel();
                receiveInfoModel.UserName = CommonData.UserInfo.names;
                
                receiveInfoModel.ReceiveTime = Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM-dd");
                List<ReceiveSampleInfoModel> receiveInfos = new List<ReceiveSampleInfoModel>();
                receiveInfoModel.ReceiveInfos = receiveInfos;

                ReceiveSampleInfoModel receiveInfo = new ReceiveSampleInfoModel();

                if (receiveSample.frameNo == null || receiveSample.frameNo == "")
                {
                    receiveInfo.perid = Convert.ToInt32(receiveSample.perid);
                    receiveInfo.testid = Convert.ToInt32(receiveSample.testid); ;
                    receiveInfo.barcode = receiveSample.barcode;
                    receiveInfo.testNo = receiveSample.testNo;
                    receiveInfo.frameNo = receiveSample.frameNo;
                    receiveInfo.groupName = GEgroupNOs.Text;
                    receiveInfos.Add(receiveInfo);
                }
                else
                {
                    receiveInfo.perid = Convert.ToInt32(receiveSample.perid);
                    receiveInfo.testid = Convert.ToInt32(receiveSample.testid); ;
                    receiveInfo.barcode = receiveSample.barcode;
                    receiveInfo.testNo = receiveSample.testNo;
                    receiveInfo.frameNo = receiveSample.frameNo;
                    receiveInfo.groupName = GEgroupNOs.Text;
                    receiveInfos.Add(receiveInfo);
                }
                if (receiveInfos.Count > 0)
                {


                        string Sr = JsonHelper.SerializeObjct(receiveInfoModel);
                        WebApiCallBack jm = ApiHelpers.postInfo(TestReceiveInfo, Sr);

                    commReInfo<commReSampleInfo> commReInfo = JsonHelper.JsonConvertObject<commReInfo<commReSampleInfo>>(jm);

                    if (commReInfo.code == 1)
                    {

                        MessageBox.Show("接收完成！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //BTSelect_ItemClick(null, null);
                    }
                    else
                    {
                        MessageBox.Show(commReInfo.msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }


            #endregion

            frmWait.HideMe(this);
            BTEnterRecive.Enabled = true;
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
                        //if (control is SimpleButton)
                        //{
                        //    SimpleButton simpleButton = control as SimpleButton;
                        //    if (simpleButton.Tag.ToString() == TEkw.EditValue.ToString())
                        //    {
                        //        simpleButton.Text = $"{TEsgj.EditValue.ToString()+TEkw.EditValue.ToString()}\r\n质控编号:{a}";
                        //        simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                        //    }
                        //}

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
}
