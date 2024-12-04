using Common.BLL;
using Common.Conn;
using Common.Data;
using DevExpress.XtraNavBar;
using System;
using System.Data;
using System.Linq;

namespace WorkComm.Clients
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



        }
        private void NavBarItem_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string ClassNames = e.Link.Caption;
            string ClassNO = e.Link.ItemName;
            if (WorkCommData.DTWorkType.Select($"classNO='{ClassNO}' and dstate=0").Count() > 0)
            {            //gridControl1.DataSource = FrmDT;
                DataTable FrmDT = WorkCommData.DTWorkType.Select($"classNO='{ClassNO}' and dstate=0").CopyToDataTable();
                string TypeNO = FrmDT.Rows[0]["TypeNO"].ToString();
                string TypeNames = FrmDT.Rows[0]["TypeNames"].ToString();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAgentInfo frmWork = new FrmAgentInfo();
            frmWork.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmClientInfo frmWork = new FrmClientInfo();
            frmWork.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmClientUsers frmAgentPower = new FrmClientUsers();
            frmAgentPower.Show();



            // Stopwatch watch = new Stopwatch();
            // watch.Start();
            // if (FileHelper.CopyFile(@"F:\系统\cn_sql_server_2016_enterprise_x64_dvd_8699450.iso", @"C:\cn_sql_server_2016_enterprise_x64_dvd_8699450.iso", 1024 * 1024 * 5))
            // {
            //     watch.Stop();
            //     Console.WriteLine("拷贝完成,耗时：" + watch.Elapsed.Seconds + "秒");

            // }
            // Console.Read();
            ////testPower.Show();
        }
    }
}

