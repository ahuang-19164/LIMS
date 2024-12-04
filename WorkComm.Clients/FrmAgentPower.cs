using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkComm.Clients
{
    public partial class FrmAgentPower : DevExpress.XtraEditors.XtraForm
    {
        //
#pragma warning disable CS0414 // 字段“FrmAgentPower.tableName”已被赋值，但从未使用过它的值
        string tableName = "WorkComm.ClientAgent";
#pragma warning restore CS0414 // 字段“FrmAgentPower.tableName”已被赋值，但从未使用过它的值
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmAgentPower()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(RGEClientPersonNO);
            GridLookUpEdites.Formats(RGEAgentPersonNO);
            GridLookUpEdites.Formats(RGEClientLevelNO);
            GridControls.formartGridView(GVClientInfo);
            GridControls.formartGridView(GVAgentInfo);


        }

        private void Frminfo_Load(object sender, EventArgs e)
        {
            GVAgentInfo.Click += gridView_Click;
            RGEAgentPersonNO.DataSource = RGEClientPersonNO.DataSource = DTHelper.DTEnable(CommonData.DTUserInfoAll);
            RGEClientLevelNO.DataSource = DTHelper.DTEnable(WorkCommData.DTTypeLevel);
            GCAgentInfo.DataSource = WorkCommData.DTClientAgent;
            FrmDT = WorkCommData.DTClientInfo;







        }

        /// <summary>
        /// 权限管理方法
        /// </summary>
        public void UserPower()
        {

            //string[] PowerList = CommonData.powerList;
            foreach (BarItem BT in barManager1.Items)
            {
                if (CommonData.UserInfo.id != 1)
                {
                    if (BT.Tag != null)
                    {
                        if (CommonData.powerList.Contains(BT.Tag.ToString()))
                        {
                            BT.Enabled = true;
                        }
                        else
                        {
                            BT.Enabled = false;
                        }
                    }
                    else
                    {
                        BT.Enabled = false;
                    }
                }
                else
                {
                    BT.Enabled = true;
                }

            }

        }

        #region barmassage方法




        string AgentPowerList = "";

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                DataRow DR = GVAgentInfo.GetFocusedDataRow();
                FrmClientShow frmClientShow = new FrmClientShow(Convert.ToInt32(DR["id"]), DR["powerList"].ToString());
                frmClientShow.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择代理商", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }


        #endregion




        #region gridcontrol 方法
        private void gridView_Click(object sender, EventArgs e)
        {
            AgentPowerList = "";
            if (EditState != 1)
            {
                if (FrmDT != null)
                {
                    SelectValueID = Convert.ToInt32(GVAgentInfo.GetFocusedRowCellValue("id"));
                    AgentPowerList = GVAgentInfo.GetFocusedRowCellValue("powerList").ToString();
                    if (AgentPowerList != null)
                    {
                        if (AgentPowerList != "")
                        {
                            DataRow[] rows = FrmDT.Select($"id in  ({AgentPowerList})");
                            GCClientnfo.DataSource = rows.CopyToDataTable();
                        }
                        else
                        {
                            GCClientnfo.DataSource = null;
                        }
                    }
                    else
                    {
                        GCClientnfo.DataSource = null;
                    }
                }
            }

        }
        #endregion

    }
}
