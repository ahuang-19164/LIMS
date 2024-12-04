
using Common.SqlModel;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Common.BLL
{
    public class DeleteHelper
    {
        public static int deleteinfo(int infoID, string TableNames)
        {
            int a = 0;
            DialogResult dialogResult = MessageBox.Show("是否确定删除这条记录", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                dInfo deleteInfo = new dInfo();
                deleteInfo.DataValueID = infoID;
                deleteInfo.TableName = TableNames;
                a = ApiHelpers.postInfo(deleteInfo);
            }
            return a;
        }
        public static int hideinfo(int infoID, string TableNames)
        {
            int a = 0;
            DialogResult dialogResult = MessageBox.Show("是否确定删除这条记录", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                hideInfo hideInfo = new hideInfo();
                hideInfo.DataValueID = infoID;
                hideInfo.TableName = TableNames;
                a = ApiHelpers.postInfo(hideInfo);
            }
            return a;
        }
    }
}
