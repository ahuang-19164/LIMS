using Common.Data;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Common.ControlHandle
{
    public class GridControls
    {


        /// <summary>
        /// 创建一个Gridcontrol
        /// </summary>
        /// <param name="dt">根据表生成表样式</param>
        /// <param name="showEmbeddedNavigator">是否显示底部窗体</param>
        /// <returns></returns>
        public static GridControl ProduceGridControl(DataTable dt, bool showEmbeddedNavigator, bool showFind)
        {
            try
            {
                DataTable datas = dt.Select("state=1", "sort").CopyToDataTable();
                GridControl grid = new GridControl();
                if (showEmbeddedNavigator)
                {
                    grid.UseEmbeddedNavigator = true;
                    grid.EmbeddedNavigator.Buttons.Append.Visible = false;
                    grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
                    grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
                    grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
                    grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
                }

                GridView gridView = new GridView();
                gridView.OptionsView.ShowGroupPanel = false;
                if (showFind)
                {
                    gridView.OptionsFind.AlwaysVisible = true;
                }
                gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
                gridView.IndicatorWidth = 40;
                foreach (DataRow dataRow in datas.Rows)
                {

                    GridColumn gridColumn;

                    if (dataRow["controlType"].ToString() == "1")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = new RepositoryItemTextEdit(),

                        };
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "2")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = new RepositoryItemButtonEdit()
                        };
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "3")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = new RepositoryItemDateEdit() { EditMask = "g" }
                        };
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridColumn.ColumnEdit.DisplayFormat.FormatString = "g";
                        gridColumn.ColumnEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gridColumn.ColumnEdit.EditFormat.FormatString = "g";
                        gridColumn.ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "4")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = new RepositoryItemCheckEdit()
                        };
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "5")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = GridLookUpEdites.ProduceRepositoryItemGridLookUpEdit(dataRow["tableNames"].ToString())

                        };
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    //gridView.Columns.Add(new GridColumn() { Name = "noCHK", FieldName = "noCHK", Caption = "选择", VisibleIndex = 0, Visible = true, ColumnEdit = new RepositoryItemTextEdit() });              
                }
                grid.MainView = gridView;
                return grid;
            }
            catch
            {
                return null;
            }

        }
        /// <summary>
        /// 格式化Columns信息
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="dt"></param>
        /// <param name="showFind"></param>
        public static void ProduceGridView(GridView gridView, DataTable dt, bool showFind)
        {
            try
            {
                if (showFind)
                {
                    gridView.OptionsFind.AlwaysVisible = true;
                }
                gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
                gridView.IndicatorWidth = 40;
                DataTable datas = dt.Select("state=1", "sort").CopyToDataTable();
                gridView.OptionsView.ShowGroupPanel = false;
                //gridControl1.MinimumSize = 
                foreach (DataRow dataRow in datas.Rows)
                {

                    GridColumn gridColumn;

                    if (dataRow["controlType"].ToString() == "1")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = new RepositoryItemTextEdit(),
                            SortMode=ColumnSortMode.Value

                        };
                        //gridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "2")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = new RepositoryItemButtonEdit()
                        };
                        //gridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "3")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = new RepositoryItemDateEdit() { EditMask = "g" }
                        };
                        //gridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridColumn.ColumnEdit.DisplayFormat.FormatString = "g";
                        gridColumn.ColumnEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gridColumn.ColumnEdit.EditFormat.FormatString = "g";
                        gridColumn.ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "4")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = new RepositoryItemCheckEdit()
                        };
                        //gridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "5")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = LookUpEdits.ProduceRepositonLookUpEdit(dataRow["bandType"].ToString())


                        };
                        //gridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    if (dataRow["controlType"].ToString() == "6")
                    {
                        gridColumn = new GridColumn()
                        {
                            Name = dataRow["controlNames"].ToString(),
                            FieldName = dataRow["fieldNames"].ToString(),
                            Caption = dataRow["captions"].ToString(),
                            Visible = Convert.ToBoolean(dataRow["controlVisible"]),
                            ColumnEdit = GridLookUpEdites.ProduceRepositoryItemGridLookUpEdit(dataRow["bandType"].ToString()),


                        };
                        //gridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gridColumn.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allFocus"]);
                        gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                        gridColumn.OptionsColumn.ReadOnly = Convert.ToBoolean(dataRow["readOnly"]);
                        if (!Convert.IsDBNull(dataRow["width"]))
                        {
                            if (dataRow["width"].ToString().Length > 0)
                            {
                                if (Convert.ToInt32(dataRow["width"]) > 0)
                                {
                                    gridColumn.MaxWidth = Convert.ToInt32(dataRow["width"]);
                                    gridColumn.MinWidth = Convert.ToInt32(dataRow["width"]);
                                }
                            }
                        }
                        gridView.Columns.Add(gridColumn);
                    }
                    //gridView.Columns.Add(new GridColumn() { Name = "noCHK", FieldName = "noCHK", Caption = "选择", VisibleIndex = 0, Visible = true, ColumnEdit = new RepositoryItemTextEdit() });              
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return null;
            }

        }
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="gridView"></param>
        public static void formartGridView(GridView gridView, bool showFind = true)
        {
            gridView.CustomDrawRowIndicator += GridView_CustomDrawRowIndicator;
            gridView.IndicatorWidth = 40;
            gridView.OptionsView.ColumnAutoWidth = false;
            //gridView.OptionsCustomization.AllowSort = false;
            if (showFind == true)
            {
                showFindPanel(gridView);
            }
        }



        /// <summary>
        /// 显示Panel信息
        /// </summary>
        /// <param name="gridView"></param>
        private static void showFindPanel(GridView gridView)
        {
            gridView.OptionsFind.AlwaysVisible = true;
            gridView.OptionsFind.ShowCloseButton = false;
            gridView.OptionsView.ShowGroupPanel = false;
            gridView.OptionsFind.FindNullPrompt = "请输入需要查询的关键字";
        }
        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void GridView_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
            if (e.Info.IsRowIndicator && e.RowHandle >= -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        /// <summary>
        /// 格式化计数菜单，显示右键菜单
        /// </summary>
        /// <param name="gridControl"></param>
        /// <param name="showCommContextMenueStrip"></param>
        public static void showEmbeddedNavigator(GridControl gridControl, bool showCommContextMenueStrip = true)
        {

            gridControl.UseEmbeddedNavigator = true;
            gridControl.EmbeddedNavigator.Buttons.Append.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.Edit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            gridControl.EmbeddedNavigator.Buttons.Remove.Visible = false;
            
            if (showCommContextMenueStrip == true)
            {
                showCommContextMenuStrip(gridControl);
            }
        }
        /// <summary>
        /// 格式化右键菜单
        /// </summary>
        /// <param name="gridControl"></param>
        private static void showCommContextMenuStrip(GridControl gridControl)
        {
            gridControl.ContextMenuStrip = CreateCommonContext(gridControl);
        }
        /// <summary>
        /// 格式化计数菜单
        /// </summary>
        /// <param name="gridControl"></param>
        public static void showTestContextMenuStrip(GridControl gridControl)
        {
            gridControl.ContextMenuStrip = CreateCommonContext(gridControl);
        }

        private static ContextMenuStrip CreateCommonContext(GridControl gridControl)
        {
            System.ComponentModel.Container components = new System.ComponentModel.Container();
            ContextMenuStrip GCContextMexnustrip = new ContextMenuStrip(components);
            ToolStripMenuItem BTBestColumns = new ToolStripMenuItem();
            ToolStripMenuItem BToutExcel = new ToolStripMenuItem();
            // 
            // GCContextMexnustrip
            // 
            GCContextMexnustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            BTBestColumns,
            BToutExcel});
            GCContextMexnustrip.Name = "GCContextMexnustrip";
            GCContextMexnustrip.Size = new System.Drawing.Size(181, 70);

            // 
            // BTBestColumns
            // 
            BTBestColumns.Name = "BTBestColumns";
            BTBestColumns.Size = new System.Drawing.Size(180, 22);
            BTBestColumns.Text = "自动调整列宽";
            BTBestColumns.Click += BTBestColumns_Click;
            BTBestColumns.Tag = "1";
            // 
            // BToutExcel
            // 
            BToutExcel.Name = "BToutExcel";
            BToutExcel.Size = new System.Drawing.Size(180, 22);
            BToutExcel.Text = "导出Excel文件";
            BToutExcel.Click += BToutExcel_Click;
            BTBestColumns.Tag = "2";
            return GCContextMexnustrip;
        }
        private static ContextMenuStrip CreateTestContext(GridControl gridControl)
        {
            System.ComponentModel.Container components = new System.ComponentModel.Container();
            ContextMenuStrip GCContextMexnustrip = new ContextMenuStrip(components);
            ToolStripMenuItem BTBestColumns = new ToolStripMenuItem();//自适应列宽
            ToolStripMenuItem BToutExcel = new ToolStripMenuItem();//导出excel
            //ToolStripMenuItem addItem = new ToolStripMenuItem();//增项菜单
            //ToolStripMenuItem RemoveItem= new ToolStripMenuItem();//退项菜单
            //ToolStripMenuItem sampleEdit= new ToolStripMenuItem();//修改信息
            ToolStripMenuItem sampledelay = new ToolStripMenuItem();//延迟操作
            ToolStripMenuItem sampleback = new ToolStripMenuItem();//延迟退回
            ToolStripMenuItem sampleagain = new ToolStripMenuItem();//标本重采
            ToolStripMenuItem sampledelegate = new ToolStripMenuItem();//标本委托

            // 
            // GCContextMexnustrip
            // 
            GCContextMexnustrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            BTBestColumns,BToutExcel,sampledelay,sampleback,sampleagain,sampledelegate});
            //BTBestColumns,BToutExcel,addItem,RemoveItem,sampleEdit,sampledelay,sampleback,sampleagain,sampledelegate});
            GCContextMexnustrip.Name = "GCContextMexnustrip";
            GCContextMexnustrip.Size = new System.Drawing.Size(181, 70);

            // 
            // BTBestColumns
            // 
            BTBestColumns.Name = "BTBestColumns";
            BTBestColumns.Size = new System.Drawing.Size(180, 22);
            BTBestColumns.Text = "自动调整列宽";
            BTBestColumns.Click += BTBestColumns_Click;
            BTBestColumns.Tag = "1";
            // 
            // BToutExcel
            // 
            BToutExcel.Name = "BToutExcel";
            BToutExcel.Size = new System.Drawing.Size(180, 22);
            BToutExcel.Text = "导出Excel文件";
            BToutExcel.Click += BToutExcel_Click;
            BTBestColumns.Tag = "2";
            return GCContextMexnustrip;
        }

        private static void BToutExcel_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem delete = sender as ToolStripMenuItem;
            ContextMenuStrip menu = delete.Owner as ContextMenuStrip;
            GridControl gridControl = menu.SourceControl as GridControl;
            string localFilePath = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel表格（*.xls）|*.xls";
            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;
            if (gridControl.Tag == null)
            {
                sfd.FileName = gridControl.Name + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            }
            else
            {
                sfd.FileName = gridControl.Tag + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            }
            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                localFilePath = sfd.FileName.ToString(); //获得文件路径 
                //string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1); //获取文件名，不带路径

                //获取文件路径，不带文件名 
                //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                //在文件名里加字符 
                //saveFileDialog1.FileName.Insert(1,"dameng"); 

                //System.IO.FileStream fs = (System.IO.FileStream)sfd.OpenFile();//输出文件 

                ////fs输出带文字或图片的文件，就看需求了 

                gridControl.ExportToXls(localFilePath);



            }



        }

        private static void BTBestColumns_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem delete = sender as ToolStripMenuItem;
            ContextMenuStrip menu = delete.Owner as ContextMenuStrip;
            GridControl gridControl = menu.SourceControl as GridControl;
            GridView gridView = gridControl.MainView as GridView;
            gridView.BestFitColumns();
        }

        static string FileNames = string.Empty;
        /// <summary>
        /// 格式化列颜色信息
        /// </summary>
        /// <param name="gridControl"></param>
        public static void ShowViewColor(GridView gv)
        {
            gv.CustomDrawCell += Gv_CustomDrawCell;
        }

        private static void Gv_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.Column.FieldName.Contains("NO") && e.Column.FieldName != "hospitalNO")
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() != "")
                        {
                            if (WorkCommData.DTWorkType.Select($"valueCode='{e.Column.FieldName}' and no={e.CellValue}").Count() > 0)
                            {
                                int b = Convert.ToInt32(WorkCommData.DTWorkType.Select($"valueCode='{e.Column.FieldName}' and no='{e.CellValue}'").CopyToDataTable().Rows[0]["typeColor"]);
                                e.Appearance.BackColor = Color.FromArgb(b);
                            }
                        }
                    }
                }
            }
            catch //(Exception ex)
            {

                //throw ex;

            }
        }




        ///// <summary>
        ///// 行变色
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void GVSampleInfo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        //{

        //    if (GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent") != DBNull.Value)
        //    {
        //        if (Convert.ToBoolean(GVSampleInfo.GetRowCellValue(e.RowHandle, "urgent")))
        //        {
        //            e.Appearance.BackColor = Color.Red;//改变背景色
        //            //e.Appearance.ForeColor = Color.Red;//改变字体颜色
        //        }
        //    }
        //}
    }
}
