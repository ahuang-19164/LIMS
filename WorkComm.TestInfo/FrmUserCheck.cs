using Common.ControlHandle;
using Common.Data;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.TestInfo
{
    public partial class FrmUserCheck : DevExpress.XtraEditors.XtraForm
    {
        string groupNOs = "";
        string testStates = "";

        /// <summary>
        /// 展示用户信息
        /// </summary>
        /// <param name="groupNO">专业组</param>
        /// <param name="testState">1.tester,2.checker</param>
        public FrmUserCheck(string groupNO, string testState)
        {
            InitializeComponent();
            groupNOs = groupNO;
            testStates = testState;
        }

        private void FrmUserCheck_Load(object sender, EventArgs e)
        {
            GridControls.formartGridView(GVInfo);

            if (testStates == "1")
            {
                if (WorkCommData.DTGroupPower.Select($"testNO='{groupNOs}' and saveResult=1 and  state=1").Count() > 0)
                {
                    DataTable dataTable = WorkCommData.DTGroupPower.Select($"testNO='{groupNOs}' and saveResult=1 and  state=1").CopyToDataTable();
                    string userList = "";
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        userList += dr["userNO"].ToString() + ",";
                    }
                    userList = userList.Substring(0, userList.Length - 1);
                    GCInfo.DataSource = CommonData.DTUserInfoAll.Select($"no in ({userList})").CopyToDataTable();
                    GVInfo.BestFitColumns();
                }
                else
                {
                    MessageBox.Show("专业组没有可替换检测人员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (testStates == "2")
                {
                    if (WorkCommData.DTGroupPower.Select($"testNO='{groupNOs}' and saveResult=1 and  state=1").Count() > 0)
                    {
                        DataTable dataTable = WorkCommData.DTGroupPower.Select($"testNO='{groupNOs}' and checked=1 and  state=1").CopyToDataTable();
                        string userList = "";
                        foreach (DataRow dr in dataTable.Rows)
                        {
                            userList += dr["userNO"].ToString() + ",";
                        }
                        userList = userList.Substring(0, userList.Length - 1);
                        GCInfo.DataSource = CommonData.DTUserInfoAll.Select($"no in ({userList})").CopyToDataTable();
                        GVInfo.BestFitColumns();
                    }
                    else
                    {
                        MessageBox.Show("专业组没有可用替换审核人员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("专业组没有可替换检测人员", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }





        }


        string username = "";
        private void GVInfo_DoubleClick(object sender, EventArgs e)
        {
            if (GVInfo.GetFocusedDataRow() != null)
            {
                FrmChengePWD frmChengePWD = new FrmChengePWD(GVInfo.GetFocusedDataRow());
                Func<string> func = frmChengePWD.returNname;
                frmChengePWD.ShowDialog();
                username = func();
                this.Close();
            }
        }
        public string ReturnUserName()
        {
            return username;
        }


    }
}
