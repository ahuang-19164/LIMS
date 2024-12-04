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
    public partial class FrmClientUsers : DevExpress.XtraEditors.XtraForm
    {
        //
#pragma warning disable CS0414 // 字段“FrmClientUsers.tableName”已被赋值，但从未使用过它的值
        string tableName = "WorkComm.ClientAgent";
#pragma warning restore CS0414 // 字段“FrmClientUsers.tableName”已被赋值，但从未使用过它的值
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmClientUsers()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(RGEClientPersonNO);
            GridLookUpEdites.Formats(RGEcompanyNO);
            GridLookUpEdites.Formats(RGEdepartmentNO);
            GridLookUpEdites.Formats(RGEClientLevelNO);
            GridControls.formartGridView(GVClientInfo);
            GridControls.formartGridView(GVUserInfo);




        }

        private void Frminfo_Load(object sender, EventArgs e)
        {
            GVUserInfo.Click += gridView_Click;
            //if (CommonData.DTUserInfoAll != null)
            //    RGEClientPersonNO.DataSource = CommonData.DTUserInfoAll.Select("state=1 and dstate=0").CopyToDataTable();
            //if (WorkCommData.DTTypeLevel != null)
            //    RGEClientLevelNO.DataSource = WorkCommData.DTTypeLevel.Select("state=1 and dstate=0").CopyToDataTable();

            RGEcompanyNO.DataSource = CommonData.DTCommonyInfoAll;
            RGEdepartmentNO.DataSource = CommonData.DTDepertmentInfoAll;
            RGEClientLevelNO.DataSource = WorkCommData.DTTypeLevel;
            //GCUserInfo.DataSource= WorkCommData.DTClientAgent; 
            FrmDT = WorkCommData.DTClientInfo;
            GCUserInfo.DataSource = RGEClientPersonNO.DataSource = CommonData.DTUserInfoAll;
            GVUserInfo.BestFitColumns();

            GVUserInfo.ExpandAllGroups();







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




#pragma warning disable CS0414 // 字段“FrmClientUsers.AgentPowerList”已被赋值，但从未使用过它的值
        string AgentPowerList = "";
#pragma warning restore CS0414 // 字段“FrmClientUsers.AgentPowerList”已被赋值，但从未使用过它的值

        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                DataRow DR = GVUserInfo.GetFocusedDataRow();
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


        }
        #endregion

        private void GVUserInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {
                if (FrmDT != null)
                {
                    if (GVUserInfo.GetFocusedDataRow() != null)
                    {
                        DataRow userNO = GVUserInfo.GetFocusedDataRow();
                        if (userNO != null)
                        {
                            if (!Convert.IsDBNull(userNO["no"]))
                            {
                                if (FrmDT != null && FrmDT.Select($"personNO='{userNO["no"]}'").Length > 0)
                                {
                                    GCClientnfo.DataSource = FrmDT.Select($"personNO='{userNO["no"]}'").CopyToDataTable();
                                    GVClientInfo.BestFitColumns();
                                }
                                else
                                {
                                    GCClientnfo.DataSource = null;
                                }
                                //DataRow[] rows = FrmDT.Select($"personNO='{userNO["no"]}'");

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
        }
    }
}
