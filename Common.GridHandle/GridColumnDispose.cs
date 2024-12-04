using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;


namespace Common.GridHandle
{
    public class GridColumnDispose
    {

        public static GridView SetGridView(DataTable DT)
        {
            GridView gridView = new GridView();

            gridView.CustomRowCellEdit += GridView_CustomRowCellEdit;





            return gridView;
        }

        private static void GridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            throw new NotImplementedException();
        }

        public GridView SetGridColumns(DataTable data)
        {

            GridView gridView = new GridView();
            if (data != null)
            {
                foreach (DataRow dataRow in data.Rows)
                {
                    GridColumn columns = new GridColumn();
                    columns.Name = dataRow["names"].ToString();
                    columns.FieldName = dataRow["fieldName"].ToString();
                    columns.Caption = dataRow["caption"].ToString();
                    columns.Visible = Convert.ToBoolean(dataRow["visible"]);
                    string EditName = dataRow["columnEdit"].ToString();
                    if (EditName.ToLower() == "textedit")
                    {
                        RepositoryItemTextEdit repositoryItem = new RepositoryItemTextEdit();

                        columns.ColumnEdit = repositoryItem;

                    }
                    else
                    {
                        if (EditName.ToLower() == "checkedit")
                        {
                            RepositoryItemCheckEdit repositoryItem = new RepositoryItemCheckEdit();
                            columns.ColumnEdit = repositoryItem;
                        }
                        else
                        {
                            if (EditName.ToLower() == "dateedit")
                            {
                                RepositoryItemDateEdit repositoryItem = new RepositoryItemDateEdit();
                                repositoryItem.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
                                columns.ColumnEdit = repositoryItem;
                            }
                            else
                            {
                                if (EditName.ToLower() == "lookupedit")
                                {
                                    RepositoryItemLookUpEdit repositoryItem = new RepositoryItemLookUpEdit();
                                    repositoryItem.DataSource = null;
                                    columns.ColumnEdit = repositoryItem;
                                }
                                else
                                {
                                    RepositoryItemTextEdit repositoryItem = new RepositoryItemTextEdit();
                                    columns.ColumnEdit = repositoryItem;
                                }
                            }
                        }
                    }
                    columns.OptionsColumn.AllowFocus = Convert.ToBoolean(dataRow["allowFocus"]);
                    columns.OptionsColumn.AllowEdit = Convert.ToBoolean(dataRow["allowEdit"]);
                    gridView.Columns.Add(columns);
                }
            }
            return gridView;
        }
    }
}
