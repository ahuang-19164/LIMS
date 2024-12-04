using Common.BLL;
using Common.ControlHandle;
using Common.ConvertShort;
using Common.Data;
using Common.JsonHelper;
using Common.SqlModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WorkQC.ItemInfo
{
    public partial class FrmQCGrade : DevExpress.XtraEditors.XtraForm
    {
        //
        string tableName = "QC.QCGrade";
        int EditState = 0;//1.新增 2.编辑
        int SelectValueID = 0;//选择数据ID
        DataTable FrmDT;

        public FrmQCGrade()
        {
            InitializeComponent();
            if (CommonData.UserInfo.id != 1)
            {
                UserPower();
            }
            GridLookUpEdites.Formats(GElevelNO);
            GridLookUpEdites.Formats(RGElevelNO);
            TextEdits.TextFormat(TEsort);
            GridControls.formartGridView(GVInfos);
            GridControls.showEmbeddedNavigator(GCInfos);

            groupControl1.Enabled = false;
            TEno.ReadOnly = true;


        }

        private void Frminfo_Load(object sender, EventArgs e)
        {

            GElevelNO.Properties.DataSource = QCInfoData.DTQCLevel;
            RGElevelNO.DataSource = QCInfoData.DTQCLevel;


            sInfo sInfo = new sInfo();
            sInfo.TableName = tableName;
            string sr = JsonHelper.SerializeObjct(sInfo);
            FrmDT = ApiHelpers.postInfo(sInfo);


            GCInfos.DataSource = DTHelper.DTVisible(FrmDT);
            //GVInfos.ExpandAllGroups();
            GVInfos.BestFitColumns();

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
        private void BTAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            groupControl1.Enabled = true;
            EditState = 1;

            if (FrmDT == null)
            {
                TEno.EditValue = 1;
            }
            else
            {
                TEno.EditValue = Convert.ToInt32(FrmDT.Select("no is not NULL", "no DESC")[0]["no"]) + 1;
            }

            TEnames.EditValue = "";
            TEshortNames.EditValue = "";
            TEcustomCode.EditValue = "";
            TEnameEn.EditValue = "";
            TEproducer.EditValue = "";
            TEremark.EditValue = "";
            TEqcCode.EditValue = "";
            GElevelNO.EditValue = null;
            DEproduceTime.EditValue = null;
            DEvalidityTime.EditValue = null;
            CEstate.Checked = false;
            TEsort.EditValue = 999;


        }

        private void BTEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupControl1.Enabled = true;
            EditState = 2;
        }

        private void BTSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (EditState == 1)
            {
                Dictionary<string, object> pairs = new Dictionary<string, object>();
                pairs.Add("dstate", 0);
                pairs.Add("state", CEstate.EditValue);
                pairs.Add("produceTime", DEproduceTime.EditValue);
                pairs.Add("validityTime", DEvalidityTime.EditValue);
                pairs.Add("customCode", TEcustomCode.EditValue);
                pairs.Add("levelNO", GElevelNO.EditValue);
                pairs.Add("qcCode", TEqcCode.EditValue);
                pairs.Add("nameEn", TEnameEn.EditValue);
                pairs.Add("names", TEnames.EditValue);
                pairs.Add("no", TEno.EditValue);
                pairs.Add("producer", TEproducer.EditValue);
                pairs.Add("remark", TEremark.EditValue);
                pairs.Add("shortNames", TEshortNames.EditValue);
                pairs.Add("sort", TEsort.EditValue);
                pairs.Add("creater", CommonData.UserInfo.names);
                pairs.Add("createTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                iInfo insertInfo = new iInfo();
                insertInfo.TableName = tableName;
                insertInfo.values = pairs;
                int a = ApiHelpers.postInfo(insertInfo);
            }
            if (SelectValueID != 0)
            {
                if (EditState == 2)
                {
                    Dictionary<string, object> pairs = new Dictionary<string, object>();
                    pairs.Add("state", CEstate.EditValue);
                    pairs.Add("produceTime", DEproduceTime.EditValue);
                    pairs.Add("validityTime", DEvalidityTime.EditValue);
                    pairs.Add("customCode", TEcustomCode.EditValue);
                    pairs.Add("levelNO", GElevelNO.EditValue);
                    pairs.Add("qcCode", TEqcCode.EditValue);
                    pairs.Add("nameEn", TEnameEn.EditValue);
                    pairs.Add("names", TEnames.EditValue);
                    pairs.Add("no", TEno.EditValue);
                    pairs.Add("producer", TEproducer.EditValue);
                    pairs.Add("remark", TEremark.EditValue);
                    pairs.Add("shortNames", TEshortNames.EditValue);
                    pairs.Add("sort", TEsort.EditValue);
                    uInfo updateInfo = new uInfo();
                    updateInfo.TableName = tableName;
                    updateInfo.values = pairs;
                    updateInfo.DataValueID = SelectValueID;
                    int a = ApiHelpers.postInfo(updateInfo);
                }
            }


            EditState = 0;

            Frminfo_Load(null, null);
            groupControl1.Enabled = false;

        }

        private void BTDelect_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (SelectValueID != 0)
            {
                DialogResult dialogResult = MessageBox.Show("是否确定删除该信息", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialogResult == DialogResult.Yes)
                {
                    hideInfo hideInfo = new hideInfo();
                    hideInfo.TableName = tableName;
                    hideInfo.DataValueID = SelectValueID;
                    ApiHelpers.postInfo(hideInfo);

                    GVInfos.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("请选择需要删除的信息", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion




        #region gridcontrol 方法

        private void GVInfos_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (EditState != 1)
            {
                if (GVInfos.GetFocusedDataRow() != null)
                {
                    SelectValueID = Convert.ToInt32(GVInfos.GetFocusedRowCellValue("id"));

                    DataRow rows = GVInfos.GetFocusedDataRow();


                    TEnames.EditValue = rows["names"];
                    DEproduceTime.EditValue = rows["produceTime"];
                    DEvalidityTime.EditValue = rows["validityTime"];
                    TEcustomCode.EditValue = rows["customCode"];
                    GElevelNO.EditValue = rows["levelNO"];
                    TEnameEn.EditValue = rows["nameEn"];
                    TEno.EditValue = rows["no"];
                    TEproducer.EditValue = rows["producer"];
                    TEremark.EditValue = rows["remark"];
                    TEshortNames.EditValue = rows["shortNames"];
                    TEsort.EditValue = rows["sort"];
                    TEqcCode.EditValue = rows["qcCode"];

                    CEstate.EditValue = rows["state"] != DBNull.Value ? Convert.ToBoolean(rows["state"]) : false;
                }
            }
        }

        #endregion

        private void TENames_Leave(object sender, EventArgs e)
        {
            if (TEnames.EditValue != null)
            {
                TEcustomCode.EditValue = ConvertShortName.GetChineseSpell(TEnames.EditValue.ToString());
            }

        }


    }
}
