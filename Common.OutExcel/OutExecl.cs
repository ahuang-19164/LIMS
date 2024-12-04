using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.IO;
using System.Windows.Forms;

namespace Common.OutExcel
{
    public class OutExecl
    {
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        /// <summary>
        /// 到处Excel报表
        /// </summary>
        /// <param name="BomName">报表名称</param>
        /// <param name="gridControl1">打印gridcontrol名称</param>
        public void OutExeclmethod(string BomName, GridControl gridControl1)
        {
            filePath += string.Format("\\{0}.xls", BomName + DateTime.Now.ToString("yyyyMMddHHmmss"));
            if (File.Exists(filePath))
            {
                MessageBox.Show("文件存在");
            }
            else
            {
                gridControl1.ExportToXls(filePath);
                MessageBox.Show("保存成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
