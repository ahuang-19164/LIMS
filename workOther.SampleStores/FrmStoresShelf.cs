using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.JsonHelper;
using Common.LoadShow;
using Common.Model;
using Common.SqlModel;
using DevExpress.Utils.Layout;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace workOther.SampleStores
{
    public partial class FrmStoresShelf : XtraForm
    {



        /// <summary>
        /// 总孔数
        /// </summary>
        int conutNum = 0;
        /// <summary>
        /// 默认行数
        /// </summary>
        int shelfrow = 12;
        /// <summary>
        /// 默认列数
        /// </summary>
        int shelfcell = 8;


        /// <summary>
        /// 保存天数
        /// </summary>
        int shelfsaveday = 0;

        /// <summary>
        /// 标本库NO
        /// </summary>
        string infostoresNO = "";

        /// <summary>
        /// 标本架NO
        /// </summary>
        string infoshelfNO = "";
        /// <summary>
        /// 查询的条码号
        /// </summary>
        string sbarcode = "";

        /// <summary>
        /// 标本库表
        /// </summary>
        string storestablename = "sw_stores";

        /// <summary>
        /// 存储库权限
        /// </summary>
        string storespowertablename = "sw_storespower";
    
        /// <summary>
        /// 标本架表 
        /// </summary>
        string shelftablaname = "sw_shelf";

        /// <summary>
        /// 标本储存记录表
        /// </summary>
        string recordtablaname = "sw_record";

        /// <summary>
        /// 当前空位
        /// </summary>
        int ckw = 1;


        string ApiStoresRecordHandle = "";

        SimpleButton SelectSimpleButton=new SimpleButton();



        /// <summary>
        /// 存储库id
        /// </summary>
        string storesid = "0";
        /// <summary>
        /// 用户储存库权限表
        /// </summary>
        DataTable storespowerDT;

        /// <summary>
        /// 存储库表
        /// </summary>
        DataTable storesDT = null;



        public FrmStoresShelf()
        {
            InitializeComponent();
            ApiStoresRecordHandle = ConfigInfos.ReadConfigInfo("StoresRecordHandle");
        }
        private void FrmStores_Load(object sender, EventArgs e)
        {
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }

            
            ////TextEdits.TextFormatDecimal(TEDiscount);
            ////TextEdits.TextFormatDecimal(RTEDiscount);
            //TextEdits.TextFormat(TEDay);
            //TextEdits.TextFormat(TESort);
            //TextEdits.TextFormat(TECell);
            //TextEdits.TextFormat(TERow);
            GridControls.formartGridView(GVInfo);
            GridControls.showEmbeddedNavigator(GCInfo);
            GridControls.formartGridView(GVShelf);
            GridControls.showEmbeddedNavigator(GCShelf);
            GridControls.ShowViewColor(GVShelf);
            GridControls.formartGridView(GVRecord);
            GridControls.showEmbeddedNavigator(GCRecord);
            GridControls.ShowViewColor(GVRecord);

                            
            //GridLookUpEdites.Formats(RGEsampleType);
            //RGEsampleType.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);
            GridLookUpEdites.Formats(GErecordType,SWCommData.DTRecordType);
            GridLookUpEdites.Formats(RGEshelfTypeNO,SWCommData.DTShelfType);
            GridLookUpEdites.Formats(RGErecordTypeNO,SWCommData.DTRecordType);

            //GEsampleType.Properties.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeSample);



            sInfo sInfopower = new sInfo();
            //sInfopower.values = "id,userNo,storesid";
            sInfopower.TableName = storespowertablename;
            sInfopower.wheres = $"userNo='{CommonData.UserInfo.no}'";
            storespowerDT = ApiHelpers.postInfo(sInfopower);


            if(storespowerDT != null)
            {
                string storesids = "";
                foreach (DataRow row in storespowerDT.Rows)
                {
                    storesids +=row["storesid"]+",";
                }

                if (storesids!="")
                {
                    storesids = storesids.Substring(0, storesids.Length - 1);
                    sInfo sInfo = new sInfo();
                    sInfo.TableName = storestablename;
                    sInfo.wheres = $"id in ({storesids}) and state=1";
                    storesDT = ApiHelpers.postInfo(sInfo);
                    GCInfo.DataSource = storesDT;
                    GridLookUpEdites.Formatsbyid(RGEStoresinfo, storesDT);


                }
            }

            TEkw.EditValue = ckw;
            GInfo.Enabled = false;
            layoutControl2.Enabled = false;
            GErecordType.EditValue = "1";


            lc5.BackColor = System.Drawing.Color.FromArgb(143, 58, 29);
            lc4.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
            lc3.BackColor = System.Drawing.Color.FromArgb(250, 128, 114);
            lc2.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
            lc1.BackColor = System.Drawing.Color.LightGreen;

            ///新增标本架
            BTAdd.Enabled = false;
            //编辑标本架
            BTEdit.Enabled = false;
            ///录入标本
            BTEntry.Enabled = false;
            ///修改标本
            BTEditRecord.Enabled = false;
            ///删除标本
            BTDelete.Enabled = false;
            ///查询标本
            BTSelect.Enabled = false;
            ///处理标本
            BTSampleHandle.Enabled = false;
            ///反处理标本
            BTRehandle.Enabled = false;
            ///取消录入
            BTCancel.Enabled = false;


            xtraTabStete = true;

        }

        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {

            //string[] PowerList = CommonData.powerList;
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


        /// <summary>
        /// 存储库权限管理方法
        /// </summary>
        public void storesPower()
        {
            DataRow powerDR = storespowerDT.Select($"storesid={storesid}").First();
            if (powerDR != null)
            {
                ///新增标本架
                BTAdd.Enabled = powerDR["createShelf"] != DBNull.Value ? Convert.ToBoolean(powerDR["createShelf"]) : false;
                //编辑标本架
                BTEdit.Enabled = powerDR["editShelf"] != DBNull.Value ? Convert.ToBoolean(powerDR["editShelf"]) : false;
                ///录入标本
                BTEntry.Enabled = powerDR["entrySample"] != DBNull.Value ? Convert.ToBoolean(powerDR["entrySample"]) : false;
                ///修改标本
                BTEditRecord.Enabled = powerDR["editSample"] != DBNull.Value ? Convert.ToBoolean(powerDR["editSample"]) : false;
                ///删除标本
                BTDelete.Enabled = powerDR["delsample"] != DBNull.Value ? Convert.ToBoolean(powerDR["delsample"]) : false;
                ///查询标本
                BTSelect.Enabled = powerDR["searchSample"] != DBNull.Value ? Convert.ToBoolean(powerDR["searchSample"]) : false;
                ///处理标本
                BTSampleHandle.Enabled = powerDR["handleSample"] != DBNull.Value ? Convert.ToBoolean(powerDR["handleSample"]) : false;
                ///反处理标本
                BTRehandle.Enabled = powerDR["rehandleSample"] != DBNull.Value ? Convert.ToBoolean(powerDR["rehandleSample"]) : false;
                ///取消录入
                BTCancel.Enabled = powerDR["cancelSample"] != DBNull.Value ? Convert.ToBoolean(powerDR["cancelSample"]) : false;

            }
        }

        #region mannager 操作方法
        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(storesDT!=null)
            {
                DataRow dataRow = storesDT.Select($"id={storesid}").First();
                if (dataRow != null)
                {
                    FrmShelfAdd frmShelfAdd = new FrmShelfAdd(dataRow);
                    frmShelfAdd.ShowDialog();
                    GVInfo_RowClick(null, null);
                }
                else
                {
                    MessageBox.Show("请选择存储库", "系统提示！");
                }
            }
        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVShelf.GetFocusedDataRow();
            if (dataRow != null)
            {
                FrmShelfAdd frmShelfAdd = new FrmShelfAdd(2, dataRow);
                frmShelfAdd.ShowDialog();
                GVInfo_RowClick(null, null);
            }
            else
            {
                MessageBox.Show("请选择需要编辑的标本架", "系统提示！");
            }

        }

        private void BTEntry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GInfo.Enabled = true;
        }

        private void BTEditRecord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(BTEditRecord.Enabled==true)
            {
                DataRow dataRow = GVRecord.GetFocusedDataRow();
                if (dataRow != null)
                {
                    FrmEditRecord frmEditRecord = new FrmEditRecord(dataRow);
                    frmEditRecord.ShowDialog();
                }
            }
        }

        private void BTCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            GInfo.Enabled = false;
        }


        private void BTCreate_ItemClick(object sender, ItemClickEventArgs e)
        {
            CreateShelf();
        }
        private void BTPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            PrintingSystem ps = new PrintingSystem();
            PrintableComponentLink link = new PrintableComponentLink(ps);
            //link.Component = gridControl1;
            link.Component = layoutControl3;




            //是否为横版
            link.Landscape = true;
            link.PaperKind = PaperKind.A4;
            //link.PaperKind = PaperKind.A4;
            link.Margins = new Margins(20, 20, 80, 50);
            PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
            phf.Header.Content.Clear();
            //phf.Header.Content.AddRange(new string[] { "", drv["线路名"].ToString() + "站点信息表", "" });
            phf.Header.Content.AddRange(new string[] { "", "标本架清单", $"标本架编号:{TEShelfNO.EditValue}" });
            //phf..AddRange(new string[] { "", "试管架清单", "当前时间"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") });
            phf.Header.Font = new System.Drawing.Font("宋体", 16, System.Drawing.FontStyle.Regular);
            phf.Header.LineAlignment = BrickAlignment.Center;
            phf.Footer.Content.Clear();
            //phf.Footer.Content.AddRange(new string[] { "", "", $"打印人:{CommonData.UserInfo.names}       " + String.Format("打印时间: {0:g}", DateTime.Now) });
            //phf.Footer.Content.AddRange(new string[] { "流水号:", "打印人:", $"交接人:            " + String.Format("打印时间: {0:g}", DateTime.Now) });
            phf.Footer.Content.AddRange(new string[] { "流水号:", $"处理人:{CommonData.UserInfo.names}   处理时间:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}   处理人:____________________________  " });
            phf.Footer.LineAlignment = BrickAlignment.Center;
            link.CreateDocument();
            link.ShowPreviewDialog();
        }


        private void BTTest_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void BTSelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            string aa= TEBarcodes.EditValue!=null?TEBarcodes.EditValue.ToString():"";
            if (aa != "")
            {
                sInfo sInfo = new sInfo();
                sInfo.TableName = recordtablaname;
                sInfo.wheres = $"barcode='{aa}'";
                DataTable dt = ApiHelpers.postInfo(sInfo);
                if (dt != null)
                    dt.Columns.Add("check", typeof(bool));
                GCRecord.DataSource = dt;
                GVRecord.BestFitColumns();

            }

        }


        private void CEALL_CheckedChanged(object sender, ItemClickEventArgs e)
        {
            if (CEALL.Checked)
            {
                for (int a = 0; a < GVRecord.RowCount; a++)
                {
                    GVRecord.SetRowCellValue(a, "check", true);
                }
            }
            else
            {
                for (int a = 0; a < GVRecord.RowCount; a++)
                {
                    GVRecord.SetRowCellValue(a, "check", false);
                }
            }
        }


        private void BTSampleHandle_ItemClick(object sender, ItemClickEventArgs e)
        {
            GVRecord.FocusedRowHandle = -1;
            List<string> ids = new List<string>();
            for(int a = GVRecord.RowCount - 1; a >= 0; a--)
            {
                DataRow dataRow = GVRecord.GetDataRow(a);

                bool sta = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                int ss = dataRow["recordTypeNO"] != DBNull.Value ? Convert.ToInt32(dataRow["recordTypeNO"]) : 1;
                if(ss==3)
                {
                    if (sta)
                    {
                        ids.Add(dataRow["id"].ToString());
                    }
                }
            }
            commInfoModel<string> commInfoModel = new commInfoModel<string>();
            commInfoModel.infos = ids;
            commInfoModel.state = 2;
            string sr = JsonHelper.SerializeObjct(commInfoModel);
            var jm= ApiHelpers.postInfo(ApiStoresRecordHandle, sr);
            for (int a = GVRecord.RowCount - 1; a >= 0; a--)
            {
                DataRow dataRow = GVRecord.GetDataRow(a);

                bool sta = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                int ss = dataRow["recordTypeNO"] != DBNull.Value ? Convert.ToInt32(dataRow["recordTypeNO"]) : 1;
                if (ss == 3)
                {
                    if (sta)
                    {
                        dataRow["recordTypeNO"]=2;
                    }
                }
            }
        }

        private void BTRehandle_ItemClick(object sender, ItemClickEventArgs e)
        {
            GVRecord.FocusedRowHandle = -1;
            List<string> ids = new List<string>();
            for (int a = GVRecord.RowCount - 1; a >= 0; a--)
            {
                DataRow dataRow = GVRecord.GetDataRow(a);
                bool sta = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                int ss = dataRow["recordTypeNO"] != DBNull.Value ? Convert.ToInt32(dataRow["recordTypeNO"]) : 1;
                if (ss == 2)
                {
                    if (sta)
                    {
                        dataRow["recordTypeNO"] = 1;
                    }
                }
            }
            commInfoModel<string> commInfoModel = new commInfoModel<string>();
            commInfoModel.infos = ids;
            commInfoModel.state = 1;
            string sr = JsonHelper.SerializeObjct(commInfoModel);
            var jm = ApiHelpers.postInfo(ApiStoresRecordHandle, sr);

            for (int a = GVRecord.RowCount - 1; a >= 0; a--)
            {
                DataRow dataRow = GVRecord.GetDataRow(a);

                bool sta = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                int ss = dataRow["recordTypeNO"] != DBNull.Value ? Convert.ToInt32(dataRow["recordTypeNO"]) : 1;
                if (ss == 2)
                {
                    if (sta)
                    {
                        dataRow["recordTypeNO"] = 1;
                    }
                }
            }
        }

        private void BTDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            GVRecord.FocusedRowHandle = -1;
            DialogResult dialogResult = MessageBox.Show("确定删除选中数据？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialogResult==DialogResult.Yes)
            {
                for (int a = GVRecord.RowCount - 1; a >= 0; a--)
                {
                    DataRow dataRow = GVRecord.GetDataRow(a);
                    bool sta = dataRow["check"] != DBNull.Value ? Convert.ToBoolean(dataRow["check"]) : false;
                    if (sta)
                    {
                        dInfo dInfo = new dInfo();
                        dInfo.TableName = recordtablaname;
                        dInfo.DataValueID = Convert.ToInt32(dataRow["id"]);
                        dInfo.MessageShow = 1;
                        var jm = ApiHelpers.postInfo(dInfo);
                        GVRecord.DeleteRow(a);
                    }

                }
            }

        }

        private void RGEStoresinfo_EditValueChanged(object sender, EventArgs e)
        {
            if(BTStoresinfo.EditValue!=null)
            {
                storesid = BTStoresinfo.EditValue.ToString();
                getshelfinfo();
            }

        }
        private void BTStoresinfo_EditValueChanged(object sender, EventArgs e)
        {
            if (BTStoresinfo.EditValue != null)
            {
                storesid = BTStoresinfo.EditValue.ToString();
                getshelfinfo();
            }
        }

        #endregion


        bool ssstate = false;

        #region layoutControl 控件方法
        private void TEInputBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (!ssstate)
                {
                    sbarcode = TEInputBarcode.EditValue != null ? TEInputBarcode.EditValue.ToString().Trim() : "";
                    bool s= getsampleinfo(sbarcode);
                    if(s)
                        ssstate = true;
                }
                else
                {
                    saveshelfinfo();
                    TEInputBarcode.SelectAll();
                    ssstate = false;
                }

            }
        }

        private void TEInputBarcode_Leave(object sender, EventArgs e)
        {
            ssstate = false;
        }
        private void TEInputBarcode_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FormBarcodeInfo formBarcodeInfo = new FormBarcodeInfo("");
            Func<string> func = formBarcodeInfo.reStringinfo;
            formBarcodeInfo.ShowDialog();
            TEInputBarcode.EditValue = func();
        }
        private void DESaveDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                BTSaveShelf_Click(null, null);
            }
        }
        private void BTSaveShelf_Click(object sender, EventArgs e)
        {
            saveshelfinfo();
        }

        #endregion


        #region gridcontorl 操作方法

        DataRow rowsss = null;
        private void GVInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dataRow = GVInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                storesid= dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "0";
                getshelfinfo();
            }
            else
            {
                GCShelf.DataSource = null;
            }
        }
        private void GVShelf_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            TEkw.EditValue =ckw= 1;
            DataRow dataRow = GVShelf.GetFocusedDataRow();
            if (dataRow != null)
            {
                if (dataRow != rowsss)
                {
                    FrmWait frmWait = new FrmWait(); frmWait.ShowMe(this, "", "正在加载......");
                    rowsss = dataRow;
                    infoshelfNO = dataRow["no"] != DBNull.Value ? dataRow["no"].ToString() : "";
                    TEShelfNO.EditValue = infoshelfNO;
                    shelfsaveday = dataRow["saveDay"] != DBNull.Value ? Convert.ToInt32(dataRow["saveDay"]) : 0;
                    DESaveDay.EditValue = DateTime.Now.AddDays(shelfsaveday);
                    shelfcell = dataRow["shelfCell"] != DBNull.Value ? Convert.ToInt32(dataRow["shelfCell"]) : 0;
                    shelfrow = dataRow["shelfRow"] != DBNull.Value ? Convert.ToInt32(dataRow["shelfRow"]) : 0;


                    if(xtraTabStete)
                    {
                        CreateShelf();
                        ShelfView();
                    }
                    else
                    {
                        gccontorl();
                    }




                    frmWait.HideMe(this);
                }
            }
            else
            {
                TEShelfNO.EditValue = "";

            }


        }

        private void GVRecord_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dataRow = GVRecord.GetFocusedDataRow();
            if (dataRow != null)
            {
                sbarcode = dataRow["barcode"] != DBNull.Value ? dataRow["barcode"].ToString() : "";
                getsampleinfo(sbarcode);
            }
        }


        private void GVRecord_DoubleClick(object sender, EventArgs e)
        {
            BTEditRecord_ItemClick(null, null);
            
        }

        #endregion









        #region 标本架模块操作

        private void getshelfinfo()
        {
            //infostoresNO = dataRow["no"] != DBNull.Value ? dataRow["no"].ToString() : "";
            if (storesid != "")
            {
                storesPower();
                sInfo sInfo = new sInfo();
                sInfo.TableName = shelftablaname;
                sInfo.wheres = $"storesNO='{storesid}' and state=1";
                GCShelf.DataSource = ApiHelpers.postInfo(sInfo);
                GVShelf.BestFitColumns();
            }
        }

        /// <summary>
        /// 保存/更新标本储存信息
        /// </summary>
        private void saveshelfinfo()
        {
            if (conutNum > 0)
            {
                if (TEShelfNO.EditValue != null)
                {
                    if (TEInputBarcode.EditValue != null && TEInputBarcode.EditValue.ToString().Trim() != "")
                    {

                        if (TEkw.EditValue != null && TEkw.EditValue.ToString().Trim() != "")
                        {
                            if (Convert.ToInt32(TEkw.EditValue) <= conutNum)
                            {
                                ckw = Convert.ToInt32(TEkw.EditValue);
                                if (TEInputBarcode.EditValue != null && TEInputBarcode.EditValue.ToString().Trim().Length > 0)
                                {
                                    string entryBarocde = TEInputBarcode.EditValue.ToString().Trim();

                                    string[] entrybarcodes = entryBarocde.Split(',');

                                    Stopwatch stopwatch = Stopwatch.StartNew();
                                    stopwatch.Start();

                                    foreach (string sbarcode in entrybarcodes)
                                    {

                                        bool cfCode = false; //条码号是否在标本架中存在


                                        if(xtraTabStete)

                                        foreach (Control control in tablePanel.Controls)
                                        {
                                            if (control is SimpleButton)
                                            {
                                                SimpleButton simpleButton = control as SimpleButton;
                                                if (simpleButton.ToolTip.ToString() == sbarcode)
                                                {
                                                    cfCode = true;
                                                    if (simpleButton.AllowDrop == true)
                                                    {
                                                        simpleButton.BackColor = Color.White;
                                                        simpleButton.Text = simpleButton.Tag.ToString() ;
                                                        simpleButton.ToolTip = "";
                                                        simpleButton.Appearance.BackColor = Color.White;
                                                    }
                                                }
                                                if (control.Tag.ToString() == TEkw.EditValue.ToString())
                                                {
                                                    if (simpleButton.AllowDrop == true)
                                                    {
                                                        simpleButton.BackColor = Color.YellowGreen;
                                                        //simpleButton.Text = $"{TEsgj.EditValue.ToString() + "-" + String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n{info.barcode}\r\n{info.sampleLocation}";
                                                        simpleButton.Text = sbarcode;
                                                        simpleButton.ToolTip = sbarcode;
                                                        simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                                                    }
                                                    else
                                                    {
                                                        TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                                        //ckw++;
                                                    }
                                                }
                                            }
                                        }

                                        if (!cfCode)
                                        {

                                            //插入标本存储记录
                                            iInfo iInfo = new iInfo();
                                            iInfo.TableName = recordtablaname;
                                            Dictionary<string, object> pairs = new Dictionary<string, object>();
                                            pairs.Add("barcode", TEInputBarcode.EditValue);
                                            pairs.Add("createTime", DateTime.Now);
                                            pairs.Add("outTime", DESaveDay.EditValue);
                                            pairs.Add("saveDay", shelfsaveday);
                                            pairs.Add("storesNO", infostoresNO);
                                            pairs.Add("shelfNO", infoshelfNO);
                                            pairs.Add("saveNO", ckw);
                                            pairs.Add("state", 0);
                                            pairs.Add("remark", TEremark.EditValue);
                                            pairs.Add("recordTypeNO", GErecordType.EditValue);
                                            iInfo.values = pairs;
                                            iInfo.MessageShow = 1;
                                            ApiHelpers.postInfo(iInfo);

                                        }
                                        else
                                        {
                                            uInfo uInfo = new uInfo();
                                            uInfo.TableName = recordtablaname;
                                            Dictionary<string, object> pairs = new Dictionary<string, object>();
                                            pairs.Add("storesNO", infostoresNO);
                                            pairs.Add("shelfNO", infoshelfNO);
                                            pairs.Add("saveNO", ckw);
                                            uInfo.values = pairs;
                                            uInfo.wheres = $"barcode='{sbarcode}'";
                                            uInfo.MessageShow = 1;
                                            ApiHelpers.postInfo(uInfo);

                                        }
                                        TEkw.EditValue =ckw= Convert.ToInt32(TEkw.EditValue) + 1;
                                    }
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
                        MessageBox.Show("请输入样本条码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("请选择标本架！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("标本架孔数不能为0，请先确认架子信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            TEInputBarcode.SelectAll();
            //ckw = Convert.ToInt32(TEkw.EditValue);

        }

        /// <summary>
        /// 创建标本架试图
        /// </summary>
        private void CreateShelf()
        {

            conutNum = Convert.ToInt32(shelfcell) * Convert.ToInt32(shelfrow);
            layoutControl1.BeginUpdate();
            panelControl.Controls.Clear();
            tablePanel = new TablePanel();
            panelControl.Controls.Add(tablePanel);
            //tablePanel.Dock = DockStyle.Fill;
            tablePanel.Rows.Clear();
            tablePanel.Columns.Clear();
            tablePanel.Controls.Clear();
            tablePanel.Size = new Size(100 * Convert.ToInt32(shelfcell) + 20, 60 * Convert.ToInt32(shelfrow) + 20);
            tablePanel.MaximumSize = new Size(100 * Convert.ToInt32(shelfcell) + 20, 60 * Convert.ToInt32(shelfrow) + 20);
            tablePanel.MinimumSize = new Size(100 * Convert.ToInt32(shelfcell) + 20, 60 * Convert.ToInt32(shelfrow) + 20);
            tablePanel.Rows.Add(new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20.00f));
            tablePanel.Columns.Add(new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 20.00f));
            for (int r = 0; r < Convert.ToInt32(shelfrow); r++)
            {
                Label label = new Label();
                //label.Text = (r + 1).ToString();
                label.Text = Convert.ToChar('A' + r).ToString();
                label.Dock = DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tablePanel.SetColumn(label, 0);
                tablePanel.SetRow(label, r + 1);
                tablePanel.Rows.Add(new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, (tablePanel.Size.Height - 20) / Convert.ToInt32(shelfrow)));
                //tablePanel.Rows.Add(new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, (tablePanel.Size.Height - 20) / Convert.ToInt32(shelfrow)));
                //tablePanel.Rows.Add(new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80));
                tablePanel.Controls.Add(label);
            }
            for (int c = 0; c < Convert.ToInt32(shelfcell); c++)
            {
                Label label = new Label();
                label.Text = (c + 1).ToString();
                label.Dock = DockStyle.Fill;
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                tablePanel.SetColumn(label, c + 1);
                tablePanel.SetRow(label, 0);
                tablePanel.Columns.Add(new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, (tablePanel.Size.Width - 20) / Convert.ToInt32(shelfcell)));
                //tablePanel.Columns.Add(new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 80));
                tablePanel.Controls.Add(label);
            }

            ////LayoutControlItem layoutControlItem = new LayoutControlItem();
            //tablePanel.ShowGrid = DevExpress.Utils.DefaultBoolean.True;
            ////tablePanel.AutoSize = true;
            tablePanel.AutoScroll = true;

            int a = 0;


            //for (int c = 0; c < Convert.ToInt32(shelfcell); c++)
            for (int r = 0; r < Convert.ToInt32(shelfrow); r++)
            {
                //for (int r = 0; r < Convert.ToInt32(shelfrow); r++)
                for (int c = 0; c < Convert.ToInt32(shelfcell); c++)
                {
                    a++;
                    SimpleButton simpleButton = new SimpleButton();
                    simpleButton.Appearance.BackColor = System.Drawing.Color.White;
                    tablePanel.Controls.Add(simpleButton);


                    simpleButton.Name = "BT" + a.ToString();
                    tablePanel.SetColumn(simpleButton, c + 1);
                    tablePanel.SetRow(simpleButton, r + 1);

                    simpleButton.Dock = DockStyle.Fill;
                    //simpleButton.TabIndex =a;
                    simpleButton.Text = a.ToString();
                    simpleButton.Tag = a;
                    simpleButton.AllowDrop = true;//当前button是否可用
                    simpleButton.ToolTip = "";//当前button是否可用
                    //simpleButton.AllowDrop = true;
                    //simpleButton.ToolTipTitle = "0";
                    //simpleButton.Text = "BT" + a.ToString();
                    //simpleButton.all = "BT" + a.ToString();

                    simpleButton.Click += SimpleButton_Click; ;
                    simpleButton.DoubleClick += SimpleButton_DoubleClick;
                }

            }


            //layoutControl1.ShowPrintPreview();
            tablePanel.AutoScroll = true;
            panelControl.AutoScroll = true;
            layoutControl1.EndUpdate();
        }

        Color oldcolor;
        private void SimpleButton_Click(object sender, EventArgs e)
        {
            SimpleButton SelectSimpleButtons = sender as SimpleButton;
            if (SelectSimpleButtons!= SelectSimpleButton)
            {
                SelectSimpleButton.Appearance.BackColor = oldcolor;
            }
            SelectSimpleButton = SelectSimpleButtons;
            //SelectSimpleButton = sender as SimpleButton;
            TEkw.EditValue = SelectSimpleButton.Tag;
            oldcolor = SelectSimpleButton.Appearance.BackColor;
            SelectSimpleButton.Appearance.BackColor = Color.FromArgb(245, 250, 255);
            sbarcode = SelectSimpleButton.ToolTip;
            getsampleinfo(sbarcode);
        }


        private void SimpleButton_DoubleClick(object sender, EventArgs e)
        {
            SelectSimpleButton = sender as SimpleButton;
            if (SelectSimpleButton.AllowDrop == true)
            {
                SelectSimpleButton.AllowDrop = false;
                SelectSimpleButton.Appearance.BackColor = Color.GreenYellow;
            }
            else
            {
                SelectSimpleButton.AllowDrop = true;
                SelectSimpleButton.Appearance.BackColor = Color.White;
            }
        }

        /// <summary>
        /// 渲染标本架信息
        /// </summary>
        private void ShelfView()
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = recordtablaname;
            sInfo.wheres = $"shelfNO='{TEShelfNO.EditValue}'";
            DataTable dataTable = ApiHelpers.postInfo(sInfo);
            if (dataTable != null)
            {
                foreach (Control control in tablePanel.Controls)
                {
                    if (control is SimpleButton)
                    {
                        SimpleButton simpleButton = control as SimpleButton;


                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            if (Convert.ToInt32(simpleButton.Tag) == Convert.ToInt32(dataRow["saveNO"]))
                            {
                                if (simpleButton.AllowDrop == true)
                                {
                                    simpleButton.BackColor = Color.YellowGreen;
                                    //simpleButton.Text = $"{TEsgj.EditValue.ToString() + "-" + String.Format("{0:000}", Convert.ToInt32(TEkw.EditValue)).ToString()}\r\n{info.barcode}\r\n{info.sampleLocation}";
                                    simpleButton.Text = dataRow["barcode"].ToString();
                                    simpleButton.ToolTip = dataRow["barcode"].ToString();
                                    int samplestate = dataRow["state"] != DBNull.Value ? Convert.ToInt32(dataRow["state"]) : 1;// 1正常2已处理3已过期4其他
                                    if (samplestate == 2)
                                        simpleButton.Appearance.BackColor = Color.FromArgb(30, 30, 30);
                                    DateTime createTime = dataRow["createTime"] != DBNull.Value ? Convert.ToDateTime(dataRow["createTime"]) : DateTime.MinValue;
                                    DateTime outtime = dataRow["outTime"] != DBNull.Value ? Convert.ToDateTime(dataRow["outTime"]) : DateTime.MaxValue;
                                    //simpleButton.AllowDrop = false;
                                    int typeNO = dataRow["recordTypeNO"] != DBNull.Value ? Convert.ToInt32(dataRow["recordTypeNO"]) : 1;
                                    ///1正常2已处理3已过期4待处理5其他
                                    if (typeNO == 5)
                                    {
                                        simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(143, 58, 29);
                                    }
                                    else
                                    {

                                        if (typeNO == 4)
                                        {
                                            simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
                                        }
                                        else
                                        {

                                            if (typeNO == 3)
                                            {
                                                simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(250, 128, 114);
                                            }
                                            else
                                            {
                                                if (typeNO == 2)
                                                {
                                                    simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
                                                }
                                                else
                                                {

                                                    if (Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd")) > Convert.ToDateTime(outtime.ToString("yyyy-MM-dd")))
                                                    {
                                                        simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
                                                    }
                                                    else
                                                    {
                                                        if (DateTime.Now.ToString("yyyy-MM-dd") == outtime.ToString("yyyy-MM-dd"))
                                                        {
                                                            simpleButton.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 128);
                                                        }
                                                        else
                                                        {
                                                            simpleButton.Appearance.BackColor = System.Drawing.Color.LightGreen;
                                                        }

                                                    }
                                                }

                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    TEkw.EditValue = Convert.ToInt32(TEkw.EditValue) + 1;
                                }
                            }
                        }

                    }
                }
            }

        }


        /// <summary>
        /// 
        /// </summary>
        private void gccontorl()
        {
            sInfo sInfo = new sInfo();
            sInfo.TableName = recordtablaname;
            sInfo.wheres = $"shelfNO='{TEShelfNO.EditValue}'";
            DataTable dt = ApiHelpers.postInfo(sInfo);
            if(dt!=null)
                dt.Columns.Add("check", typeof(bool));
            GCRecord.DataSource = dt;
            GVRecord.BestFitColumns();
        }
        /// <summary>
        /// 获取样本信息
        /// </summary>
        /// <param name="sbarcode"></param>
        private bool getsampleinfo(string sbarcode)
        {
            if (sbarcode != "")
            {
                if (!sbarcode.Contains(","))
                {
                    //sInfo sInfo = new sInfo();
                    //sInfo.TableName = "Perwork.SampleInfo";
                    //sInfo.wheres = $"barcode='{sbarcode}' and TestStateNO='6'";
                    //DataTable testinfoDT = ApiHelpers.postInfo(sInfo);
                    sInfo sInfo = new sInfo();
                    sInfo.TableName = "WorkPer.SampleInfo";
                    sInfo.wheres = $"barcode='{sbarcode}' and perStateNO='4'";
                    DataTable testinfoDT = ApiHelpers.postInfo(sInfo);

                    if (testinfoDT != null)
                    {


                        ///对应样本信息表
                        DEsampleTime.EditValue = testinfoDT.Rows[0]["sampleTime"];
                        TEageDay.EditValue = testinfoDT.Rows[0]["ageDay"];
                        TEageMoth.EditValue = testinfoDT.Rows[0]["ageMoth"];
                        TEpatientName.EditValue = testinfoDT.Rows[0]["patientName"];
                        GEagentNO.EditValue = testinfoDT.Rows[0]["agentNames"];
                        TEageYear.EditValue = testinfoDT.Rows[0]["ageYear"];
                        //MEapplyItemNames.EditValue = testinfoDT.Rows[0]["groupNames"];
                        MEapplyItemNames.EditValue = testinfoDT.Rows[0]["applyItemNames"];
                        TEbarcode.EditValue = testinfoDT.Rows[0]["barcode"];
                        TEbedNo.EditValue = testinfoDT.Rows[0]["bedNo"];
                        MEclinicalDiagnosis.EditValue = testinfoDT.Rows[0]["clinicalDiagnosis"];
                        TEcutPart.EditValue = testinfoDT.Rows[0]["cutPart"];
                        TEdepartment.EditValue = testinfoDT.Rows[0]["department"];
                        TEdoctorPhone.EditValue = testinfoDT.Rows[0]["doctorPhone"];
                        GEhospitalNo.EditValue = testinfoDT.Rows[0]["hospitalNames"];
                        TEmedicalNo.EditValue = testinfoDT.Rows[0]["medicalNo"];
                        DEmenstrualTime.EditValue = testinfoDT.Rows[0]["menstrualTime"];
                        TEpathologyNo.EditValue = testinfoDT.Rows[0]["pathologyNo"];
                        DEreceiveTime.EditValue = testinfoDT.Rows[0]["receiveTime"];
                        //TEpatientAddress.EditValue = testinfoDT.Rows[0]["patientAddress"];
                        TEpatientCardNO.EditValue = testinfoDT.Rows[0]["patientCardNo"];
                        TEpatientPhone.EditValue = testinfoDT.Rows[0]["patientPhone"];
                        GEpatientSex.EditValue = testinfoDT.Rows[0]["patientSexNames"];
                        GEpatientType.EditValue = testinfoDT.Rows[0]["patientTypeNames"];
                        MEperRemark.EditValue = testinfoDT.Rows[0]["perRemark"];
                        TEsampleID.EditValue = testinfoDT.Rows[0]["id"];
                        GEsampleShape.EditValue = testinfoDT.Rows[0]["sampleShapeNames"];
                        GEsampleType.EditValue = testinfoDT.Rows[0]["sampleTypeNames"];
                        TEsendDoctor.EditValue = testinfoDT.Rows[0]["sendDoctor"];

                        CEurgent.Checked = testinfoDT.Rows[0]["urgent"] != DBNull.Value ? Convert.ToBoolean(testinfoDT.Rows[0]["urgent"]) : false;
                        //METestRemark.EditValue = testinfoDT.Rows[0]["testRemark"];
                        //TEatester.EditValue = testinfoDT.Rows[0]["tester"];
                        //DEatestTime.EditValue = testinfoDT.Rows[0]["testTime"] != DBNull.Value ? Convert.ToDateTime(testinfoDT.Rows[0]["testTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;
                        //TEachecker.EditValue = testinfoDT.Rows[0]["checker"];
                        //DEacheckTime.EditValue = testinfoDT.Rows[0]["checkTime"] != DBNull.Value ? Convert.ToDateTime(testinfoDT.Rows[0]["checkTime"]).ToString("yyyy-MM-dd HH:mm:ss") : null;

                        return true;
                    }
                    else
                    {

                        DEsampleTime.EditValue = null;
                        TEageDay.EditValue            = null;
                        TEageMoth.EditValue           = null;
                        TEpatientName.EditValue       = null;
                        GEagentNO.EditValue           = null;
                        TEageYear.EditValue           = null;
                        MEapplyItemNames.EditValue    = null;
                        TEbarcode.EditValue           = null;
                        TEbedNo.EditValue             = null;
                        MEclinicalDiagnosis.EditValue = null;
                        TEcutPart.EditValue           = null;
                        TEdepartment.EditValue        = null;
                        TEdoctorPhone.EditValue       = null;
                        GEhospitalNo.EditValue        = null;
                        TEmedicalNo.EditValue         = null;
                        DEmenstrualTime.EditValue     = null;
                        TEpathologyNo.EditValue       = null;
                        DEreceiveTime.EditValue       = null;
                        TEpatientCardNO.EditValue     = null;
                        TEpatientPhone.EditValue      = null;
                        GEpatientSex.EditValue        = null;
                        GEpatientType.EditValue       = null;
                        MEperRemark.EditValue         = null;
                        TEsampleID.EditValue          = null;
                        GEsampleShape.EditValue       = null;
                        GEsampleType.EditValue        = null;
                        TEsendDoctor.EditValue        = null;

                        CEurgent.Checked = false;


                    }
                }
            }
            return false;
        }

        #endregion

        /// <summary>
        /// 是否选择标本架试图模式false 表格模式 true 试图模式
        /// </summary>
        bool xtraTabStete = false;

        private void xtraTabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //通过不同的TabPage名称，加载对应方法

            if (e.Page.Name == "xtraTabInfo")
            {
                xtraTabStete = false;
                if (TEShelfNO.EditValue != null && TEShelfNO.EditValue.ToString().Trim() != "")
                    gccontorl();

            }

            if (e.Page.Name == "xtraTabView")
            {
                xtraTabStete = true;
                if (TEShelfNO.EditValue != null && TEShelfNO.EditValue.ToString().Trim() != "")
                {
                    CreateShelf();
                    ShelfView();
                }
            }
        }


    }
}
