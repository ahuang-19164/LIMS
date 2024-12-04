using Common.BLL;
using Common.ControlHandle;
using Common.Data;
using Common.SqlModel;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace WorkComm.TestInfo
{
    public partial class FrmFlowInfo : DevExpress.XtraEditors.XtraForm
    {


        string test = "";
        public FrmFlowInfo(string testid)
        {
            InitializeComponent();
            GridControls.formartGridView(GVItemFlow);
            GridControls.showEmbeddedNavigator(GCItemFlow);

            GridLookUpEdites.Formats(RGEflowNO);
            RGEflowNO.DataSource = WorkCommData.DTItemFlow;





            test = testid;
            sInfo sInfo = new sInfo();
            sInfo.TableName = "WorkTest.SampleInfoFlow";
            sInfo.wheres = $"testid='{test}' and state=1 and dstate=0";
            //string Sr = JsonHelper.SerializeObjct(sInfo);
            GCItemFlow.DataSource = ApiHelpers.postInfo(sInfo);
        }

        private void GVItemFlow_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {

        }

        private void BTReFlow_Click(object sender, EventArgs e)
        {
            try
            {


                DataRow dataRow = GVItemFlow.GetFocusedDataRow();
                if (dataRow != null)
                {
                    DialogResult dialogResult = MessageBox.Show("是否确定退回到该节点", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        selectFlow = dataRow["flowNO"] != DBNull.Value ? dataRow["flowNO"].ToString() : "";
                        string createTime = dataRow["createTime"] != DBNull.Value ? dataRow["createTime"].ToString() : DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        if (selectFlow != "")
                        {
                            uInfo uInfo = new uInfo();
                            uInfo.TableName = "WorkTest.SampleInfo";
                            uInfo.value = $"groupFlowNO='{selectFlow}'";
                            uInfo.wheres = $"id='{test}'";
                            int a = ApiHelpers.postInfo(uInfo);
                            if (a > 0)
                            {
                                uInfo uInfo2 = new uInfo();
                                uInfo2.TableName = "WorkTest.SampleInfoFlow";
                                uInfo2.value = $"state='0'";
                                uInfo2.wheres = $"id='{test}' and createTime>='{createTime}'";
                                uInfo.MessageShow = 1;
                                ApiHelpers.postInfo(uInfo);
                            }
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        string selectFlow = "";
        public string reFlowNO()
        {
            return selectFlow;
        }

        private void BTClear_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
