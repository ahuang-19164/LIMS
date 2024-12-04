using Common.BLL;
using Common.Conn;
using Common.ControlHandle;
using Common.Data;

using System;

namespace WorkComm.DictionaryInfos
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            sys_userinfo userInfo = new sys_userinfo();
            userInfo.names = "aaa";
            userInfo.id = 1;

            CommonData.UserInfo = userInfo;
            CommDataHandle.GetSystemInfo();
            WorkCommDataHandle.GetWorkAll();

            MemoEdits.AddDoubleMethod(memoEdit1);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDictionaryInfo frmDictionary = new FrmDictionaryInfo();
            frmDictionary.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }
    }
}
