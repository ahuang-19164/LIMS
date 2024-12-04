using System.Data;

namespace Common.ControlHandle
{
    public class ControlClass
    {
        public static DataTable ControlType()
        {
            DataTable dataTable = new DataTable();
            DataColumn column1 = new DataColumn("no", typeof(string));
            DataColumn column2 = new DataColumn("names", typeof(string));
            DataColumn column3 = new DataColumn("ShortNames", typeof(string));
            dataTable.Columns.AddRange(new DataColumn[] { column1, column2, column3 });
            dataTable.Rows.Add("1", "TextEdit", "TE");
            dataTable.Rows.Add("2", "ButtonEdit", "BE");
            dataTable.Rows.Add("3", "DateEdit", "DE");
            dataTable.Rows.Add("4", "CheckEdit", "CE");
            dataTable.Rows.Add("5", "GridLookUpEdit", "GE");
            return dataTable;

        }
        public static DataTable ValueType()
        {
            DataTable dataTable = new DataTable();
            DataColumn column1 = new DataColumn("no", typeof(string));
            DataColumn column2 = new DataColumn("names", typeof(string));
            DataColumn column3 = new DataColumn("ShortNames", typeof(string));
            dataTable.Columns.AddRange(new DataColumn[] { column1, column2, column3 });
            dataTable.Rows.Add("1", "string", "s");
            dataTable.Rows.Add("2", "int", "i");
            dataTable.Rows.Add("3", "datetime", "d");
            dataTable.Rows.Add("4", "bool", "b");
            return dataTable;

        }
    }
}
