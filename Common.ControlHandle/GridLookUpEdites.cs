using Common.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace Common.ControlHandle
{
    public class GridLookUpEdites
    {
        public static GridLookUpEdit ProduceGridLookUpEdit(string TableNames)
        {


            GridLookUpEdit gridLookUpEdit = new GridLookUpEdit();

            if (WorkCommData.DTWorkType.Select($"classNO='{TableNames}' and state=1 and dstate=0").Count() > 0)
            {
                gridLookUpEdit.Properties.DataSource = WorkCommData.DTWorkType.Select($"classNO='{TableNames}' and state=1 and dstate=0").CopyToDataTable();
            }
            gridLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            gridLookUpEdit.Properties.View.BestFitColumns();
            gridLookUpEdit.Properties.AutoComplete = false;
            gridLookUpEdit.Properties.ImmediatePopup = true;
            gridLookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            gridLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            //gridLookUpEdit.Properties.NullText = "";
            //gridLookUpEdit.EditValue = "";



            gridLookUpEdit.Properties.View.Columns.AddRange(new GridColumn[] {
                new GridColumn {FieldName = "no",MaxWidth=100,Caption="编号",Visible=true },
                new GridColumn {FieldName = "names",MinWidth=150,Caption="名称",Visible=true  },
                new GridColumn {FieldName = "shortNames",MinWidth=50, Caption = "拼音简称",Visible=true  },
                new GridColumn {FieldName = "customCode",MinWidth=50, Caption = "自定编号",Visible=true  } });
            gridLookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            gridLookUpEdit.Properties.View.BestFitColumns();
            gridLookUpEdit.Properties.DisplayMember = "names";
            gridLookUpEdit.Properties.ValueMember = "no";
            gridLookUpEdit.Properties.NullText = "";
            gridLookUpEdit.Properties.SearchMode = GridLookUpSearchMode.AutoSuggest;
            //gridLookUpEdit.EditValueChanging += GridLookUpEdit_EditValueChanging;

            return gridLookUpEdit;

        }

        /// <summary>
        /// 创建一个GridlookUpEdit控件
        /// </summary>
        /// <param name="TableNames">DTWorkType</param>
        /// <returns></returns>
        public static RepositoryItemGridLookUpEdit ProduceRepositoryItemGridLookUpEdit(string TableNames)
        {


            RepositoryItemGridLookUpEdit repositoryItemGridLookUp = new RepositoryItemGridLookUpEdit();

            if (WorkCommData.DTWorkType.Select($"classNO='{TableNames}' and state=1 and dstate=0").Count() > 0)
            {
                repositoryItemGridLookUp.DataSource = WorkCommData.DTWorkType.Select($"classNO='{TableNames}' and state=1 and dstate=0").CopyToDataTable();
            }
            repositoryItemGridLookUp.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            repositoryItemGridLookUp.View.BestFitColumns();
            repositoryItemGridLookUp.AutoComplete = false;
            repositoryItemGridLookUp.ImmediatePopup = true;
            repositoryItemGridLookUp.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryItemGridLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            //gridLookUpEdit.EditValue = "";
            repositoryItemGridLookUp.View.Columns.AddRange(new GridColumn[] {
               new GridColumn {FieldName = "no",MaxWidth=100,Caption="编号",Visible=true },
               new GridColumn {FieldName = "names",MinWidth=150,Caption="名称",Visible=true  },
               new GridColumn {FieldName = "shortNames",MinWidth=50, Caption = "拼音简称",Visible=true  },
               new GridColumn {FieldName = "customCode",MinWidth=50, Caption = "自定编号",Visible=true  } });
            repositoryItemGridLookUp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repositoryItemGridLookUp.View.BestFitColumns();
            repositoryItemGridLookUp.DisplayMember = "names";
            repositoryItemGridLookUp.ValueMember = "no";
            //repositoryItemGridLookUp.Properties.NullText = "aa";
            repositoryItemGridLookUp.NullText = "";
            repositoryItemGridLookUp.SearchMode = GridLookUpSearchMode.AutoSuggest;
            //repositoryItemGridLookUp.EditValueChanging += GridLookUpEdit_EditValueChanging;

            return repositoryItemGridLookUp;

        }
        /// <summary>
        ///格式化gridlookupEdit gridview 绑定 no,names,shortNames,customCode 字段
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void Formats(GridLookUpEdit gridLookUpEdit, DataTable dataSource = null)
        {
            gridLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            gridLookUpEdit.Properties.View.BestFitColumns();
            gridLookUpEdit.Properties.AutoComplete = false;
            gridLookUpEdit.Properties.ImmediatePopup = true;
            gridLookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            gridLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            gridLookUpEdit.Properties.View.Columns.AddRange(new GridColumn[] {
                new GridColumn {FieldName = "no",MaxWidth=100,Caption="编号",Visible=true },
                new GridColumn {FieldName = "names",MinWidth=150,Caption="名称",Visible=true  },
                new GridColumn {FieldName = "shortNames", MinWidth=50,Caption = "拼音简称",Visible=true},
                new GridColumn {FieldName = "customCode",MinWidth=50, Caption = "自定编号",Visible=true  }});

            gridLookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            gridLookUpEdit.Properties.View.BestFitColumns();
            gridLookUpEdit.Properties.DisplayMember = "names";
            gridLookUpEdit.Properties.ValueMember = "no";
            //gridLookUpEdit.EditValue = "";
            gridLookUpEdit.Properties.NullText = "";
            gridLookUpEdit.Properties.SearchMode = GridLookUpSearchMode.AutoSuggest;

            if (dataSource != null)
            {
                gridLookUpEdit.Properties.DataSource = dataSource;
            }




            //gridLookUpEdit.EditValueChanging += GridLookUpEdit_EditValueChanging;

            //gridLookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
            //gridLookUpEdit.EnabledChanged += GridLookUpEdit_EnabledChanged;
        }


        ///// <summary>
        /////格式化gridlookupEdit gridview 绑定 no,names,shortNames,customCode 字段
        ///// </summary>
        ///// <param name="gridLookUpEdit"></param>
        //public static void Format(GridLookUpEdit gridLookUpEdit, DataTable dataSource = null)
        //{
        //    gridLookUpEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
        //    gridLookUpEdit.Properties.View.BestFitColumns();
        //    gridLookUpEdit.Properties.AutoComplete = false;
        //    gridLookUpEdit.Properties.ImmediatePopup = true;
        //    gridLookUpEdit.Properties.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
        //    gridLookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        //    gridLookUpEdit.Properties.View.Columns.AddRange(new GridColumn[] {
        //        //new GridColumn {FieldName = "no",MaxWidth=100,Caption="编号",Visible=true },
        //        new GridColumn {FieldName = "names",MinWidth=150,Caption="名称",Visible=true  },
        //        //new GridColumn {FieldName = "shortNames", MinWidth=50,Caption = "拼音简称",Visible=true},
        //        //new GridColumn {FieldName = "customCode",MinWidth=50, Caption = "自定编号",Visible=true  }
        //    });
        //    gridLookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
        //    gridLookUpEdit.Properties.View.BestFitColumns();
        //    gridLookUpEdit.Properties.DisplayMember = "names";
        //    gridLookUpEdit.Properties.ValueMember = "names";
        //    //gridLookUpEdit.EditValue = "";
        //    gridLookUpEdit.Properties.NullText = "";
        //    gridLookUpEdit.Properties.SearchMode = GridLookUpSearchMode.AutoSuggest;

        //    if (dataSource != null)
        //    {
        //        gridLookUpEdit.Properties.DataSource = dataSource;
        //    }




        //    //gridLookUpEdit.EditValueChanging += GridLookUpEdit_EditValueChanging;

        //    //gridLookUpEdit.Properties.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
        //    //gridLookUpEdit.EnabledChanged += GridLookUpEdit_EnabledChanged;
        //}
        /// <summary>
        /// 修改值更换背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void GridLookUpEdit_EnabledChanged(object sender, System.EventArgs e)
        {
            try
            {
                GridLookUpEdit gridLookUpEdit = sender as GridLookUpEdit;
                if (gridLookUpEdit.EditValue != null)
                {
                    DataRow dataRow = gridLookUpEdit.Properties.View.GetFocusedDataRow();
                    int colorback = dataRow["typeColor"] != DBNull.Value ? Convert.ToInt32(dataRow["typeColor"]) : 0;
                    gridLookUpEdit.BackColor = Color.FromArgb(colorback);
                }
            }
            catch
            {

            }
        }

        private static void GridLookUpEdit_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            GridLookUpEdit gridLookUp = sender as GridLookUpEdit;
            gridLookUp.BeginInvoke(new System.Windows.Forms.MethodInvoker(() =>
            {
                SetMoreColumnFilter(sender);
            }));
        }
        /// <summary>
        ///格式化gridlookupEdit gridview 绑定 no,names,shortNames,customCode 字段
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void Formats(RepositoryItemGridLookUpEdit repositoryItemGridLookUp, DataTable datasrouce = null)
        {
            repositoryItemGridLookUp.AutoComplete = false;
            repositoryItemGridLookUp.ImmediatePopup = true;
            repositoryItemGridLookUp.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryItemGridLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            repositoryItemGridLookUp.View.Columns.AddRange(new GridColumn[] {
                new GridColumn {FieldName = "no",MaxWidth=100,Caption="编号",Visible=true },
                new GridColumn {FieldName = "names",MinWidth=150,Caption="名称",Visible=true  },
                new GridColumn {FieldName = "shortNames",MinWidth=50,Caption = "拼音简称",Visible=true  },
                new GridColumn {FieldName = "customCode", MinWidth=50,Caption = "自定编号",Visible=true  } });
            repositoryItemGridLookUp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repositoryItemGridLookUp.View.BestFitColumns();
            repositoryItemGridLookUp.DisplayMember = "names";
            repositoryItemGridLookUp.ValueMember = "no";
            repositoryItemGridLookUp.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            repositoryItemGridLookUp.NullText = "";
            repositoryItemGridLookUp.SearchMode = GridLookUpSearchMode.AutoSuggest;
            if (datasrouce != null)
            {
                repositoryItemGridLookUp.DataSource = datasrouce;
            }
            //repositoryItemGridLookUp.EditValueChanging += RepositoryItemGridLookUp_EditValueChanging;
            //repositoryItemGridLookUp.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
        }

        /// <summary>
        ///格式化gridlookupEdit gridview 绑定 no,names,shortNames,customCode 字段
        /// </summary>
        /// <param name="gridLookUpEdit"></param>
        public static void Formatsbyid(RepositoryItemGridLookUpEdit repositoryItemGridLookUp, DataTable datasrouce = null)
        {
            repositoryItemGridLookUp.AutoComplete = false;
            repositoryItemGridLookUp.ImmediatePopup = true;
            repositoryItemGridLookUp.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            repositoryItemGridLookUp.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            repositoryItemGridLookUp.View.Columns.Add(new GridColumn { FieldName = "id", MaxWidth = 100, Caption = "编号", Visible = true });
            repositoryItemGridLookUp.View.Columns.Add(new GridColumn { FieldName = "names", MaxWidth = 100, Caption = "名称", Visible = true });
            if(datasrouce!=null&&datasrouce.Columns.Contains("shortNames"))
                repositoryItemGridLookUp.View.Columns.Add(new GridColumn { FieldName = "shortNames", MaxWidth = 100, Caption = "拼音简称", Visible = true });
            if (datasrouce != null && datasrouce.Columns.Contains("customCode"))
                repositoryItemGridLookUp.View.Columns.Add(new GridColumn { FieldName = "customCode", MaxWidth = 100, Caption = "自定编号", Visible = true });

            //repositoryItemGridLookUp.View.Columns.AddRange(new GridColumn[] {
            //    new GridColumn {FieldName = "id",MaxWidth=100,Caption="编号",Visible=true },
            //    new GridColumn {FieldName = "names",MinWidth=150,Caption="名称",Visible=true  },
            //    new GridColumn {FieldName = "shortNames",MinWidth=50,Caption = "拼音简称",Visible=true  },
            //    new GridColumn {FieldName = "customCode", MinWidth=50,Caption = "自定编号",Visible=true  } });
            repositoryItemGridLookUp.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            repositoryItemGridLookUp.View.BestFitColumns();
            repositoryItemGridLookUp.DisplayMember = "names";
            repositoryItemGridLookUp.ValueMember = "id";
            repositoryItemGridLookUp.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            repositoryItemGridLookUp.NullText = "";
            repositoryItemGridLookUp.SearchMode = GridLookUpSearchMode.AutoSuggest;
            if (datasrouce != null)
            {
                repositoryItemGridLookUp.DataSource = datasrouce;
            }
            //repositoryItemGridLookUp.EditValueChanging += RepositoryItemGridLookUp_EditValueChanging;
            //repositoryItemGridLookUp.View.OptionsView.ShowAutoFilterRow = true; //显示不显示grid上第一个空行,也是用于检索的应用
        }

        private static void RepositoryItemGridLookUp_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            GridLookUpEdit gridLookUp = sender as GridLookUpEdit;
            gridLookUp.BeginInvoke(new System.Windows.Forms.MethodInvoker(() =>
            {
                SetMoreColumnFilter(sender);
            }));
        }

        /// <summary>
        /// 设置GridLookUpEdit多列过滤
        /// </summary>
        /// <param name="repGLUEdit">GridLookUpEdit的知识库，eg:gridlookUpEdit.Properties</param>
        public static void SetMoreColumnFilter(object sender)
        {
            GridLookUpEdit gridLookUp = sender as GridLookUpEdit;
            DevExpress.XtraGrid.Views.Grid.GridView view = gridLookUp.Properties.View as DevExpress.XtraGrid.Views.Grid.GridView;
            //获取GriView私有变量
            System.Reflection.FieldInfo extraFilter = view.GetType().GetField("extraFilter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            List<DevExpress.Data.Filtering.CriteriaOperator> columnsOperators = new List<DevExpress.Data.Filtering.CriteriaOperator>();
            foreach (GridColumn col in view.VisibleColumns)
            {
                if (col.Visible && col.ColumnType == typeof(string))
                    columnsOperators.Add(new DevExpress.Data.Filtering.FunctionOperator(DevExpress.Data.Filtering.FunctionOperatorType.Contains,
                        new DevExpress.Data.Filtering.OperandProperty(col.FieldName),
                        new DevExpress.Data.Filtering.OperandValue(gridLookUp.Text)));
            }
            string filterCondition = new DevExpress.Data.Filtering.GroupOperator(DevExpress.Data.Filtering.GroupOperatorType.Or, columnsOperators).ToString();
            extraFilter.SetValue(view, filterCondition);
            //获取GriView中处理列过滤的私有方法
            System.Reflection.MethodInfo ApplyColumnsFilterEx = view.GetType().GetMethod("ApplyColumnsFilterEx", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            ApplyColumnsFilterEx.Invoke(view, null);
        }
    }
}
