using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Common.ExcelHandle
{
    public class ExcelHelper
    {
        private IWorkbook workbook = null;
#pragma warning disable CS0169 // 从不使用字段“ExcelHelper.disposed”
        private bool disposed;
#pragma warning restore CS0169 // 从不使用字段“ExcelHelper.disposed”

        public List<string> GetFileSheet(string fileName, out string fileClass)
        {

            string FileClass = System.IO.Path.GetExtension(fileName); //文件扩展名
            fileClass = FileClass;
            if (FileClass == ".xls")
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    workbook = new HSSFWorkbook(stream);
                }
            }
            if (FileClass == ".xlsx")
            {
                using (FileStream stream = File.OpenRead(fileName))
                {
                    workbook = new XSSFWorkbook(stream);
                }
            }
            List<string> SheetName = new List<string>();
            if (workbook != null)
            {
                int SheetCount = workbook.NumberOfSheets;//获取表的数量
                //SheetName = new string[SheetCount];//保存表的名称
                for (int i = 0; i < SheetCount; i++)
                {
                    //string a = workbook.GetSheetName(i);
                    SheetName.Add(workbook.GetSheetName(i));
                }
                return SheetName;
            }
            else
            {
                return null;
            }

        }


        /// <summary>  
        /// 将excel中的数据导入到DataTable中  
        /// </summary>  
        /// <param name="sheetName">excel工作薄sheet的名称</param>  
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>  
        /// <returns>返回的DataTable</returns>  
        public DataTable ExcelToDataTable(string sheetName, bool isFirstRowColumn)
        {

            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            try
            {
                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet  
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }
                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; //一行最后一个cell的编号 即总的列数  

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号  
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　  

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null)
                            {
                                ICell cell = row.GetCell(j);
                                if (cell.CellType == CellType.Numeric)
                                {
                                    //NPOI中数字和日期都是NUMERIC类型的，这里对其进行判断是否是日期类型
                                    if (HSSFDateUtil.IsCellDateFormatted(cell))//日期类型
                                    {
                                        dataRow[j] = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                                    }
                                    else//其他数字类型
                                    {
                                        dataRow[j] = cell.NumericCellValue;
                                    }
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j);
                                }

                            }






                            //if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null  
                            //{
                            //    if(int.TryParse(row.GetCell(j).ToString(),out int a))
                            //    {
                            //        if (DateTime.TryParse(row.Cells[j].DateCellValue.ToString(), out DateTime result))
                            //        {
                            //            dataRow[j] = result.ToString("yyyy-MM-dd HH:mm:ss");
                            //        }
                            //        else
                            //        {
                            //            dataRow[j] = row.GetCell(j);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        dataRow[j] = row.GetCell(j);
                            //    }


                            //}

                            //dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
                workbook.Close();
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>  
        /// 将excel中的数据导入到DataTable中(包含Check)  
        /// </summary>  
        /// <param name="sheetName">excel工作薄sheet的名称</param>  
        /// <param name="isFirstRowColumn">第一行是否是DataTable的列名</param>  
        /// <returns>返回的DataTable</returns>  
        public DataTable ExcelToDataTableCheck(string sheetName, bool isFirstRowColumn)
        {

            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            //try
            //{
            if (sheetName != null)
            {
                sheet = workbook.GetSheet(sheetName);
                if (sheet == null) //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet  
                {
                    sheet = workbook.GetSheetAt(0);
                }
            }
            else
            {
                sheet = workbook.GetSheetAt(0);
            }
            if (sheet != null)
            {
                IRow firstRow = sheet.GetRow(0);
                if (firstRow != null)
                {
                    int cellCount = firstRow.LastCellNum + 1; //一行最后一个cell的编号 即总的列数  

                    if (isFirstRowColumn)
                    {
                        data.Columns.Add("选择", typeof(bool));
                        for (int i = firstRow.FirstCellNum; i < cellCount + 1; i++)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue.Trim().Replace(" ", "").Replace(" ", "");
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    //最后一列的标号  
                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; //没有数据的行默认是null　　　　　　　  

                        DataRow dataRow = data.NewRow();
                        dataRow[0] = false;
                        if (row.FirstCellNum >= 0)
                        {
                            for (int j = row.FirstCellNum; j <= cellCount; j++)
                            {
                                if (j + 1 <data.Columns.Count)
                                {
                                    //if (row.GetCell(j) != null)
                                    //{
                                    ICell cell = row.GetCell(j);
                                    if (cell != null)
                                    {
                                        if (cell.CellType == CellType.Numeric)
                                        {
                                            if (cell != null)
                                            {
                                                //过滤没有标题的列

                                                //NPOI中数字和日期都是NUMERIC类型的，这里对其进行判断是否是日期类型
                                                if (HSSFDateUtil.IsCellDateFormatted(cell))//日期类型
                                                {
                                                    dataRow[j + 1] = cell.DateCellValue.ToString("yyyy-MM-dd HH:mm:ss");
                                                }
                                                else//其他数字类型
                                                {
                                                    dataRow[j + 1] = cell.NumericCellValue;
                                                }


                                            }
                                        }
                                        else
                                        {

                                            dataRow[j + 1] = cell.StringCellValue; ;
                                        }
                                        //}
                                        //else
                                        //{
                                        //    dataRow[j + 1] = "";
                                        //}
                                    }

                                }
                                //else
                                //{
                                //    dataRow[j + 1] = "";
                                //}






                                //if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null  
                                //{
                                //    if(int.TryParse(row.GetCell(j).ToString(),out int a))
                                //    {
                                //        if (DateTime.TryParse(row.Cells[j].DateCellValue.ToString(), out DateTime result))
                                //        {
                                //            dataRow[j] = result.ToString("yyyy-MM-dd HH:mm:ss");
                                //        }
                                //        else
                                //        {
                                //            dataRow[j] = row.GetCell(j);
                                //        }
                                //    }
                                //    else
                                //    {
                                //        dataRow[j] = row.GetCell(j);
                                //    }


                                //}

                                //dataRow[j] = row.GetCell(j).ToString();
                            }
                            data.Rows.Add(dataRow);
                        }
                    }
                }

            }
            workbook.Close();
            return data;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }
        public DataTable CsvToDataTable(string filePath)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                DataTable dt = new DataTable();
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, System.Text.Encoding.Default);
                //记录每次读取的一行记录
                string strLine = "";
                //记录每行记录中的各字段内容
                string[] aryLine;
                //标示列数
                int columnCount = 0;
                int firstCount = 0;
                Boolean first = true;
                //逐行读取CSV中的数据
                while ((strLine = sr.ReadLine()) != null)
                {
                    aryLine = strLine.Split(',');

                    columnCount = aryLine.Length;
                    //columnCount = 32;
                    if (first)
                    {

                        for (int j = 0; j < columnCount; j++)
                        {
                            //dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                            dt.Columns.Add(aryLine[j].Split(' ')[0].Replace("\"", ""));
                        }
                        first = false;
                        firstCount = columnCount;
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        if (firstCount < columnCount)
                        {
                            throw new Exception("最大列数不能大于表格起始列数");
                        }
                        for (int j = 0; j < columnCount; j++)
                        {
                            string str = aryLine[j].Replace("\"", "");
                            dr[j] = str;
                        }
                        dt.Rows.Add(dr);
                    }


                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
        public DataTable CsvToDataTableCheck(string filePath)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                DataTable dt = new DataTable();
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs, System.Text.Encoding.Default);
                //记录每次读取的一行记录
                string strLine = "";
                //记录每行记录中的各字段内容
                string[] aryLine;
                //标示列数
                int columnCount = 0;
                int firstCount = 0;
                Boolean first = true;
                //逐行读取CSV中的数据
                while ((strLine = sr.ReadLine()) != null)
                {
                    aryLine = strLine.Split(',');

                    columnCount = aryLine.Length;
                    //columnCount = 32;
                    if (first)
                    {
                        dt.Columns.Add("选择", typeof(bool));
                        for (int j = 1; j < columnCount; j++)
                        {
                            //dt.Columns.Add(Convert.ToChar(((int)'A') + j).ToString());
                            dt.Columns.Add(aryLine[j].Split(' ')[0].Replace("\"", ""));
                        }
                        first = false;
                        firstCount = columnCount;
                    }
                    else
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = false;
                        if (firstCount < columnCount)
                        {
                            throw new Exception("最大列数不能大于表格起始列数");
                        }
                        for (int j = 1; j < columnCount; j++)
                        {

                            string str = aryLine[j].Replace("\"", "");
                            dr[j] = str;
                        }

                        dt.Rows.Add(dr);
                    }


                }
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
    }
}
