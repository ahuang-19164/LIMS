using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;

namespace WorkComm.logisticsInfos
{
    public partial class FrmLogisticsManage : XtraForm
    {
        public FrmLogisticsManage()
        {
            InitializeComponent();
            GridLookUpEdites.Formats(RGEPersonNO);
            GridLookUpEdites.Formats(RGEcompanyNO);
            GridLookUpEdites.Formats(RGEagentNO);





            GridLookUpEdites.Formats(RGEdepartmentNO);
            GridLookUpEdites.Formats(RGEChargeLevelNO);
            GridControls.formartGridView(GVClientInfo);
            GridControls.formartGridView(GVUserInfo);







            RGEcompanyNO.DataSource =CommonData.DTCommonyInfoAll;
            RGEPersonNO.DataSource = CommonData.DTUserInfoAll;
            RGEdepartmentNO.DataSource = CommonData.DTDepertmentInfoAll;
            RGEChargeLevelNO.DataSource = WorkCommData.DTTypeLevel;
            RGEagentNO.DataSource = WorkCommData.DTClientAgent;


        }

        private void FrmLogisticsManage_Load(object sender, EventArgs e)
        {
            GCUserInfo.DataSource = DTHelper.DTEnable(CommonData.DTUserInfoAll); ;

            if (WorkCommData.DTClientInfo != null)
            {
                DataTable dataTable =DTHelper.DTEnable(WorkCommData.DTClientInfo).Copy();
                dataTable.Columns.Add("check", typeof(bool));
                GCClientnfo.DataSource = dataTable;
                GVClientInfo.BestFitColumns();
            }
            GVUserInfo.ExpandAllGroups();
            GVUserInfo.BestFitColumns();

        }

        private void CEcheckAll_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CEcheckAll.Checked)
            {
                for (int a = 0; a < GVClientInfo.RowCount; a++)
                {
                    GVClientInfo.SetRowCellValue(a, "check", true);
                }

            }
            else
            {
                for (int a = 0; a < GVClientInfo.RowCount; a++)
                {
                    GVClientInfo.SetRowCellValue(a, "check", false);
                }
            }
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            GVClientInfo.FocusedRowHandle = -1;
            DataRow dataRow = GVUserInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                string userID = dataRow["id"] != DBNull.Value ? dataRow["id"].ToString() : "0";
                string listInfo = "";
                for (int a = 0; a < GVClientInfo.RowCount; a++)
                {
                    if (!Convert.IsDBNull(GVClientInfo.GetRowCellValue(a, "check")))
                    {
                        if (Convert.ToBoolean(GVClientInfo.GetRowCellValue(a, "check")) == true)
                        {
                            listInfo += GVClientInfo.GetRowCellValue(a, "no") + ",";
                        }
                    }
                }
                uInfo uInfo = new uInfo();
                uInfo.value = $"clientList='{listInfo.Substring(0,listInfo.Length-1)}'";
                uInfo.TableName = "Common.UserInfo";
                uInfo.wheres = $"id='{userID}'";
                int b = ApiHelpers.postInfo(uInfo);
                if (b == 1)
                {
                    dataRow["clientList"] = listInfo;
                }
            }
        }

        private void GVUserInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dataRow = GVUserInfo.GetFocusedDataRow();
            if (dataRow != null)
            {
                string clientList = dataRow["clientList"] != DBNull.Value ? dataRow["clientList"].ToString() : "";
                if (clientList != "")
                {
                    string[] listinfos = clientList.Split(',');
                    for (int a = 0; a < GVClientInfo.RowCount; a++)
                    {
                        if (!Convert.IsDBNull(GVClientInfo.GetRowCellValue(a, "no")))
                        {
                            string infoNOa = GVClientInfo.GetRowCellValue(a, "no").ToString();
                            if (listinfos.Contains(infoNOa))
                            {
                                GVClientInfo.SetRowCellValue(a, "check", true);
                            }
                            else
                            {
                                GVClientInfo.SetRowCellValue(a, "check", false);
                            }
                        }
                    }
                }
                else
                {
                    for (int a = 0; a < GVClientInfo.RowCount; a++)
                    {
                        GVClientInfo.SetRowCellValue(a, "check", false);
                    }
                }
            }
        }
    }
}
