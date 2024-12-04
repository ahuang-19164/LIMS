using Common.BLL;
using Common.Conn;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace workOther.MicrobeInfo
{
    public partial class FrmAntibioticGroup : XtraForm
    {
        DataTable FrmDT;
        public FrmAntibioticGroup()
        {
            InitializeComponent();
            DataTable DTAntibioticInfo = WorkCommData.DTMicrobeAntibiotic.Copy();
            DTAntibioticInfo.Columns.Add("check", typeof(bool));
            GCInfos.DataSource = DTAntibioticInfo;
            GVInfos.BestFitColumns();
        }

        private void FrmAntibioticGroup_Load(object sender, EventArgs e)
        {


            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.MicrobeGroupList";
            //selectInfo.OrderColumns = "sort";
            FrmDT = WorkCommData.DTMicrobeGroupList = ApiHelpers.postInfo(selectInfo);

            GCGroupList.DataSource = DTHelper.DTVisible(WorkCommData.DTMicrobeGroupList);
            GVGroupList.BestFitColumns();
        }
        int infoNO = 0;
        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (FrmDT == null)
            {
                infoNO = 1;
            }
            else
            {
                infoNO = Convert.ToInt32(FrmDT.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }
            FrmGroupEdit frmGroupEdit = new FrmGroupEdit(infoNO, null);
            frmGroupEdit.ShowDialog();
            FrmAntibioticGroup_Load(null, null);


        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVGroupList.GetFocusedDataRow();

            if (dataRow != null)
            {
                FrmGroupEdit frmGroupEdit = new FrmGroupEdit(0, dataRow);
                frmGroupEdit.ShowDialog();
                FrmAntibioticGroup_Load(null, null);
            }
            else
            {
                MessageBox.Show("请选择需要编辑的抗生素组合信息！", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GVInfos.FocusedRowHandle = -1;
            DataRow dataRow = GVGroupList.GetFocusedDataRow();
            if (dataRow != null)
            {
                string listInfo = "";
                for (int a = 0; a < GVInfos.RowCount; a++)
                {
                    if (!Convert.IsDBNull(GVInfos.GetRowCellValue(a, "check")))
                    {
                        if (Convert.ToBoolean(GVInfos.GetRowCellValue(a, "check")) == true)
                        {
                            listInfo += GVInfos.GetRowCellValue(a, "no") + ",";
                        }
                    }
                }
                if (listInfo.Length > 1)
                {
                    listInfo = listInfo.Substring(0, listInfo.Length - 1);
                    uInfo uInfo = new uInfo();
                    uInfo.TableName = "WorkComm.MicrobeGroupList";
                    uInfo.value = $"listinfo='{listInfo}'";
                    uInfo.DataValueID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                    int a = ApiHelpers.postInfo(uInfo);
                    if (a == 1)
                    {
                        dataRow["listinfo"] = listInfo;
                    }
                }
            }

        }

        private void BTDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dataRow = GVGroupList.GetFocusedDataRow();
            if (dataRow != null)
            {
                DialogResult dialogResult = MessageBox.Show("确定删除选中信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    hideInfo hInfo = new hideInfo();
                    hInfo.TableName = "WorkComm.MicrobeGroupList";
                    hInfo.DataValueID = dataRow["id"] != DBNull.Value ? Convert.ToInt32(dataRow["id"]) : 0;
                    ApiHelpers.postInfo(hInfo);
                }
            }

        }

        private void GVGroupList_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ColumnView View = sender as ColumnView;
            View.SetRowCellValue(e.RowHandle, View.Columns["no"], infoNO);
            View.SetRowCellValue(e.RowHandle, View.Columns["state"], true);
            View.SetRowCellValue(e.RowHandle, View.Columns["sort"], 999);


            //View.SetRowCellValue(e.RowHandle, View.Columns["testNO"], string.Format("{0:000}", GVInfo.GetFocusedRowCellValue("no"))); //复制最后一行的数据到新行
            //View.SetRowCellValue(e.RowHandle, View.Columns["no"], GVInfo.GetFocusedRowCellValue("no")); //复制最后一行的数据到新行
            //View.SetRowCellValue(e.RowHandle, View.Columns["state"], GVGroupPower.GetRowCellValue(GVGroupPower.GetRowHandle(GVGroupPower.RowCount - 2), GVGroupPower.Columns[0])); //复制最后一行的数据到新行 


        }

        private void GVGroupList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DataRow dataRow = GVGroupList.GetFocusedDataRow();
            if (dataRow != null)
            {
                string listInfo = dataRow["listinfo"] != DBNull.Value ? dataRow["listinfo"].ToString() : "";
                if (listInfo != "")
                {
                    string[] listinfos = listInfo.Split(',');
                    for (int a = 0; a < GVInfos.RowCount; a++)
                    {
                        if (!Convert.IsDBNull(GVInfos.GetRowCellValue(a, "no")))
                        {
                            string infoNOa = GVInfos.GetRowCellValue(a, "no").ToString();
                            if (listinfos.Contains(infoNOa))
                            {
                                GVInfos.SetRowCellValue(a, "check", true);
                            }
                            else
                            {
                                GVInfos.SetRowCellValue(a, "check", false);
                            }
                        }
                    }
                }
                else
                {
                    for (int a = 0; a < GVInfos.RowCount; a++)
                    {
                        GVInfos.SetRowCellValue(a, "check", false);
                    }
                }
            }
        }
    }
}
