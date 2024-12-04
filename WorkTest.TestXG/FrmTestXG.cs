﻿using Common.BLL;
using Common.Data;
using Common.JsonHelper;
using Common.Model;
using Common.SqlModel;
using Common.TestModel.Result;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkTest.TestXG
{
    public partial class FrmTestXG : XtraForm
    {
        string tableName = "WorkTest.ResultXG";
        string SetResultTest = "";
        public FrmTestXG()
        {
            InitializeComponent();
        }
        private void FrmTestXG_Load(object sender, EventArgs e)
        {



            SetResultTest = ConfigInfos.ReadConfigInfo("SetResultCommXG");
            //TestSampleResultSelect = ConfigInfos.ReadConfigInfo("TestSampleResultSelect");
            //DataTable dataTable = new DataTable();
            //dataTable.Columns.Add("names");
            //dataTable.Rows.Add("阴性");
            //dataTable.Rows.Add("阳性");
            //dataTable.Rows.Add("未检出");
            CBEgeneA.Properties.Items.Add("阴性(-)");
            CBEgeneA.Properties.Items.Add("阳性(+)");
            CBEgeneA.Properties.Items.Add("未检出");
            CBEgeneA.Properties.Items.Add("待定");
            CBEgeneB.Properties.Items.Add("阴性(-)");
            CBEgeneB.Properties.Items.Add("阳性(+)");
            CBEgeneB.Properties.Items.Add("未检出");
            CBEgeneB.Properties.Items.Add("待定");

        }

        string itemCodes = "";
        /// <summary>
        /// 获取样本信息方法
        /// </summary>
        /// <param name="sampleID">样本ID</param>
        /// <param name="Barcode">样本条码号</param>
        public void setResultInfo(int testid, DataRow SampleInfo, int TestStateNO = 0)
        {

            Task<DataTable> ResultTask = new Task<DataTable>(() =>
            {
                sInfo selectInfo = new sInfo();
                selectInfo.TableName = tableName;
                selectInfo.wheres = $"testid='{testid}' and state=1";
                //selectInfo.OrderColumns = "createTime desc";
                //DataTable DTResult = ApiHelpers.postInfo(selectInfo);
                return ApiHelpers.postInfo(selectInfo);
            });
            ResultTask.Start();
            DataTable dataTable= ResultTask.Result;
            if(dataTable!=null&&dataTable.Rows.Count>0)
            {
                CBEgeneA.EditValue = dataTable.Rows[0]["geneA"] != DBNull.Value ? dataTable.Rows[0]["geneA"].ToString() : "阴性";
                CBEgeneB.EditValue = dataTable.Rows[0]["geneB"] != DBNull.Value ? dataTable.Rows[0]["geneB"].ToString() : "阴性";
                itemCodes = dataTable.Rows[0]["itemCodes"] != DBNull.Value ? dataTable.Rows[0]["itemCodes"].ToString() : "";
            }
        }
        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="ResultState">结果结果状态 1.检验者 2.复初审者 3.审核者</param>
        /// <returns></returns>
        public string postResultInfo(int ResultState,int perid, int testid,string sampleid, string barcode, string groupNO, string flowNO, AutographInfo info = null)
        {

            //GVTestInfo.FocusedRowHandle = -1;




            //Task<string> task = new Task<string>(() =>
            //{
            if (ResultState == 4)
            {
                CommResultModel<GeneInfoModel> testInfo = new CommResultModel<GeneInfoModel>();
                testInfo.UserName = CommonData.UserInfo.names;
                
                testInfo.ResultState = ResultState;
                GeneInfoModel resultTest = new GeneInfoModel();
                resultTest.barcode = barcode;
                resultTest.perid = perid;
                resultTest.testid = testid;
                resultTest.sampleID = sampleid;
                resultTest.groupNO = groupNO;
                resultTest.State = true;
                resultTest.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //resultTest.ListResult = itemResults;
                testInfo.AutographInfo = info;
                testInfo.Result = resultTest;
                string s =JsonHelper.SerializeObjct(testInfo);
                WebApiCallBack jm = ApiHelpers.postInfo(SetResultTest, s);
                return jm.data.ToString();
            }
            else
            {


                if (barcode != "" && testid != 0 && groupNO != "")
                {
                    CommResultModel<GeneInfoModel> testInfo = new CommResultModel<GeneInfoModel>();
                    testInfo.UserName = CommonData.UserInfo.names;
                    
                    testInfo.ResultState = ResultState;
                    //testInfo.re = tableName;





                    GeneInfoModel resultTest = new GeneInfoModel();
                    resultTest.barcode = barcode;
                    resultTest.perid = perid;
                    resultTest.testid = testid; 
                    resultTest.sampleID = sampleid;
                    resultTest.groupNO = groupNO;
                    resultTest.State = true;
                    resultTest.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    




                    List<GeneItemModel> itemResults = new List<GeneItemModel>();


                    GeneItemModel itemResult = new GeneItemModel();
                    itemResult.itemCode = itemCodes;

                    List<GeneResultModel> resultInfos = new List<GeneResultModel>();
                    GeneResultModel resultInfo1 = new GeneResultModel();
                    resultInfo1.key = "geneA";
                    resultInfo1.names = "ORF1ab基因";
                    resultInfo1.value = CBEgeneA.EditValue!=null? CBEgeneA.EditValue.ToString():"";
                    resultInfos.Add(resultInfo1);
                    GeneResultModel resultInfo2 = new GeneResultModel();
                    resultInfo2.key = "geneB";
                    resultInfo2.names = " N基因";
                    resultInfo2.value = CBEgeneB.EditValue != null ? CBEgeneB.EditValue.ToString() : "";
                    resultInfos.Add(resultInfo2);

                    itemResult.itemResults = resultInfos;


                    itemResults.Add(itemResult);

                    resultTest.ListResult = itemResults;



                    testInfo.AutographInfo = info;
                    testInfo.Result = resultTest;


                    if (itemResults != null)
                    {
                        string s = Common.JsonHelper.JsonHelper.SerializeObjct(testInfo);
                        WebApiCallBack jm = ApiHelpers.postInfo(SetResultTest, s);
                        return jm.data.ToString();
                    }
                    else
                    {
                        //MessageBox.Show("检验结果有空值。请检查样本结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //return "检验结果有空值。请检查样本结果！";
                        return "{\"code\":1,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"检验结果有空值。请检查样本结果！\"}";
                    }

                }
                else
                {
                    return "{\"code\":1,\"infos\":null,\"nextFlowNO\":\"0\",\"msg\":\"请选择需要保存信息的标本信息！\"}";
                }
            }
        }


    }
}
