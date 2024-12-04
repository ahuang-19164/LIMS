using Common.Data;
using Common.SqlModel;
using System.Data;
using System.Linq;


namespace Common.BLL
{
    public class WorkCommDataHandle
    {
        /// <summary>
        /// 刷新所有数据信息
        /// </summary>
        public static void GetWorkAll()
        {
            GetWorkType();
            GetWorkInfo();
            GetControlView();
            //GetReportInfo();
        }
        /// <summary>
        /// 查新业务工作信息
        /// </summary>
        public static void GetWorkInfo()
        {
            GetClientAgent();
            GetClientInfo();
            GetGroupWork();
            GetGroupApply();
            GetGroupTest();
            GetGroupPower();
            GetItemApply();
            GetItemGroup();
            GetItemTest();
            GetItemFlow();
            GetTestCorrelationAG();
            GetTestCorrelationGT();
            GetItemReference();
            GetItemOtherInfo();
            GetWorkDictionary();
            GetInstrumentInfo();
            GetDelegeteCompanyInfo();

            GetMicrobeAntibiotic();
            GetMicrobeCultivation();
            GetMicrobeGerm();
            GetMicrobeSmear();
            GetMicrobeTest();
            GetMicrobeGroupList();

        }
        public static void GetControlView()
        {
            GetGroupGridView();
            GetGroupLayView();
            GetOhterGridView();
            GetOtherLayView();
        }
        public static void GetReportInfo()
        {
            GetGroupGridView();
            GetReprotSrouceInfo();
            GetReprotBindInfo();
        }
        //public static void GetQcInfo()
        //{

        //}





        public static void GetWorkType()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.WorkTypeInfo";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTWorkType = ApiHelpers.postInfo(selectInfo);
            if (WorkCommData.DTWorkType != null)
            {
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeContainer'").Count() > 0)
                {
                    WorkCommData.DTTypeContainer = WorkCommData.DTWorkType.Select($"classNO ='TypeContainer'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeInstrument'").Count() > 0)
                {
                    WorkCommData.DTTypeInstrument = WorkCommData.DTWorkType.Select($"classNO ='TypeInstrument'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeItem'").Count() > 0)
                {
                    WorkCommData.DTTypeItem = WorkCommData.DTWorkType.Select($"classNO ='TypeItem'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeMethod'").Count() > 0)
                {
                    WorkCommData.DTTypeMethod = WorkCommData.DTWorkType.Select($"classNO ='TypeMethod'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypePatient'").Count() > 0)
                {
                    WorkCommData.DTTypePatient = WorkCommData.DTWorkType.Select($"classNO ='TypePatient'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeReport'").Count() > 0)
                {
                    WorkCommData.DTTypeReport = WorkCommData.DTWorkType.Select($"classNO ='TypeReport'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeResult'").Count() > 0)
                {
                    WorkCommData.DTTypeResult = WorkCommData.DTWorkType.Select($"classNO ='TypeResult'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeSample'").Count() > 0)
                {
                    WorkCommData.DTTypeSample = WorkCommData.DTWorkType.Select($"classNO ='TypeSample'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeShape'").Count() > 0)
                {
                    WorkCommData.DTTypeShape = WorkCommData.DTWorkType.Select($"classNO ='TypeShape'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeTest'").Count() > 0)
                {
                    WorkCommData.DTTypeTest = WorkCommData.DTWorkType.Select($"classNO ='TypeTest'").CopyToDataTable();
                }
                //if (WorkCommData.DTWorkType.Select($"classNO ='TypeTestFlow'").Count() > 0)
                //{
                //    WorkCommData.DTTypeTestFlow = WorkCommData.DTWorkType.Select($"classNO ='TypeTestFlow'").CopyToDataTable();
                //}
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeLevel'").Count() > 0)
                {
                    WorkCommData.DTTypeLevel = WorkCommData.DTWorkType.Select($"classNO ='TypeLevel'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeClient'").Count() > 0)
                {
                    WorkCommData.DTTypeClient = WorkCommData.DTWorkType.Select($"classNO ='TypeClient'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeDistribution'").Count() > 0)
                {
                    WorkCommData.DTTypeDistribution = WorkCommData.DTWorkType.Select($"classNO ='TypeDistribution'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeSex'").Count() > 0)
                {
                    WorkCommData.DTTypeSex = WorkCommData.DTWorkType.Select($"classNO ='TypeSex'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='StatePerWork'").Count() > 0)
                {
                    WorkCommData.DTStatePerWork = WorkCommData.DTWorkType.Select($"classNO ='StatePerWork'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='StateTake'").Count() > 0)
                {
                    WorkCommData.DTStateTake = WorkCommData.DTWorkType.Select($"classNO ='StateTake'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='StateTest'").Count() > 0)
                {
                    WorkCommData.DTStateTest = WorkCommData.DTWorkType.Select($"classNO ='StateTest'").CopyToDataTable();
                }



                //报告类型
                if (WorkCommData.DTWorkType.Select($"classNO ='ReportInfo'").Count() > 0)
                {
                    ReportCommData.DTReportType = WorkCommData.DTWorkType.Select($"classNO ='ReportInfo'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='ReportSet'").Count() > 0)
                {
                    ReportCommData.DTReportSet = WorkCommData.DTWorkType.Select($"classNO ='ReportSet'").CopyToDataTable();
                }






                //财务收费类型
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeCharge'").Count() > 0)
                {
                    FinanceInfoData.DTChargeType = WorkCommData.DTWorkType.Select($"classNO ='TypeCharge'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='TypeTab'").Count() > 0)
                {
                    FinanceInfoData.DTTabType = WorkCommData.DTWorkType.Select($"classNO ='TypeTab'").CopyToDataTable();
                }

                //质控类型
                if (WorkCommData.DTWorkType.Select($"classNO ='RangType'").Count() > 0)
                {
                    QCInfoData.DTRangType = WorkCommData.DTWorkType.Select($"classNO ='RangType'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='EerrorType'").Count() > 0)
                {
                    QCInfoData.DTEerrorType = WorkCommData.DTWorkType.Select($"classNO ='EerrorType'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='CriteriaType'").Count() > 0)
                {
                    QCInfoData.DTCriteriaType = WorkCommData.DTWorkType.Select($"classNO ='CriteriaType'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='LevelQC'").Count() > 0)
                {
                    QCInfoData.DTQCLevel = WorkCommData.DTWorkType.Select($"classNO ='LevelQC'").CopyToDataTable();
                }



                if (WorkCommData.DTWorkType.Select($"classNO ='StateDelegate'").Count() > 0)
                {
                    OtherInfoData.DTDelegateState = WorkCommData.DTWorkType.Select($"classNO ='StateDelegate'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='StateSubmit'").Count() > 0)
                {
                    OtherInfoData.DTSubmitState = WorkCommData.DTWorkType.Select($"classNO ='StateSubmit'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='StateHandle'").Count() > 0)
                {
                    OtherInfoData.DTHandleState = WorkCommData.DTWorkType.Select($"classNO ='StateHandle'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='StateServe'").Count() > 0)
                {
                    OtherInfoData.DTServeState = WorkCommData.DTWorkType.Select($"classNO ='StateServe'").CopyToDataTable();
                }

                //存储库类型
                if (WorkCommData.DTWorkType.Select($"classNO ='StoresType'").Count() > 0)
                {
                    SWCommData.DTStoresType = WorkCommData.DTWorkType.Select($"classNO ='StoresType'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='ShelfType'").Count() > 0)
                {
                    SWCommData.DTShelfType = WorkCommData.DTWorkType.Select($"classNO ='ShelfType'").CopyToDataTable();
                }
                if (WorkCommData.DTWorkType.Select($"classNO ='RecordType'").Count() > 0)
                {
                    SWCommData.DTRecordType = WorkCommData.DTWorkType.Select($"classNO ='RecordType'").CopyToDataTable();
                }


            }



        }
        #region 检验基础信息
        /// <summary>
        /// 代理商信息
        /// </summary>
        public static void GetClientAgent()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ClientAgent";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTClientAgent = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 客户信息
        /// </summary>
        public static void GetClientInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ClientInfo";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTClientInfo = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 工作组信息
        /// </summary>
        public static void GetGroupWork()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.GroupWork";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTGroupWork = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 项目组信息
        /// </summary>
        public static void GetGroupApply()
        {
            //sInfo selectInfo = new sInfo();
            //selectInfo.TableName = "WorkComm.GroupApply";
            //selectInfo.OrderColumns = "sort";
            //WorkCommData.DTGroupApply = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 专业组信息
        /// </summary>
        public static void GetGroupTest()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.GroupTest";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTGroupTest = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 专业组权限
        /// </summary>
        public static void GetGroupPower()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.GroupPower";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTGroupPower = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 组套项目
        /// </summary>
        public static void GetItemApply()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ItemApply";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTItemApply = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 组合项目
        /// </summary>
        public static void GetItemGroup()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ItemGroup";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTItemGroup = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 检测项目
        /// </summary>
        public static void GetItemTest()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ItemTest";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTItemTest = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 检测项目
        /// </summary>
        public static void GetItemFlow()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ItemFlow";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTItemFlow = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 组套项目和组合项目对应表
        /// </summary>
        public static void GetTestCorrelationAG()
        {
            //sInfo selectInfo = new sInfo();
            //selectInfo.TableName = "WorkComm.TestCorrelationAG";
            //selectInfo.OrderColumns = "sort";
            //WorkCommData.DTTestCorrelationAG = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 组合项目和项目对应表
        /// </summary>
        public static void GetTestCorrelationGT()
        {
            //sInfo selectInfo = new sInfo();
            //selectInfo.TableName = "WorkComm.TestCorrelationGT";
            //selectInfo.OrderColumns = "sort";
            //WorkCommData.DTTestCorrelationGT = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 项目参考值信息
        /// </summary>
        public static void GetItemReference()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ItemReference";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTItemReference = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 项目其他相关信息
        /// </summary>
        public static void GetItemOtherInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ItemTestOtherInfo";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTItemTestOtherInfo = ApiHelpers.postInfo(selectInfo);


            sInfo selectInfo2 = new sInfo();
            selectInfo2.TableName = "WorkComm.ItemGroupOtherInfo";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTItemGroupOtherInfo = ApiHelpers.postInfo(selectInfo2);
        }
        /// <summary>
        /// 微生物抗生素信息
        /// </summary>
        public static void GetMicrobeAntibiotic()
        {
            sInfo selectInfo2 = new sInfo();
            selectInfo2.TableName = "WorkComm.MicrobeAntibiotic";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTMicrobeAntibiotic = ApiHelpers.postInfo(selectInfo2);
        }
        /// <summary>
        /// 微生物培养信息
        /// </summary>
        public static void GetMicrobeCultivation()
        {

            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.MicrobeCultivation";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTMicrobeCultivation = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 微生物细菌信息
        /// </summary>
        public static void GetMicrobeGerm()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.MicrobeGerm";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTMicrobeGerm = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 微生物涂片信息
        /// </summary>
        public static void GetMicrobeSmear()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.MicrobeSmear";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTMicrobeSmear = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 微生物结果信息
        /// </summary>
        public static void GetMicrobeTest()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.MicrobeTest";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTMicrobeTest = ApiHelpers.postInfo(selectInfo);
        }

        /// <summary>
        /// 微生物结果信息
        /// </summary>
        public static void GetMicrobeGroupList()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.MicrobeGroupList";
            //selectInfo.OrderColumns = "sort";
            WorkCommData.DTMicrobeGroupList = ApiHelpers.postInfo(selectInfo);
        }

        #endregion

        #region 窗体视图
        /// <summary>
        /// 专业组信息视图表
        /// </summary>
        public static void GetGroupGridView()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.GroupGridView";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTGroupGridView = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 专业组控件信息表
        /// </summary>
        public static void GetGroupLayView()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.GroupLayView";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTGroupLayView = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 其他模块视图表
        /// </summary>
        public static void GetOhterGridView()
        {
            //sInfo selectInfo = new sInfo();
            //selectInfo.TableName = "WorkComm.OhterGridView";
            //selectInfo.OrderColumns = "sort";
            //WorkCommData.DTOtherGridView = ApiHelpers.postInfo(selectInfo);
        }
        /// <summary>
        /// 其他控件信息表
        /// </summary>
        public static void GetOtherLayView()
        {
            //sInfo selectInfo = new sInfo();
            //selectInfo.TableName = "WorkComm.OtherLayView";
            //selectInfo.OrderColumns = "sort";
            //WorkCommData.DTOtherLayView = ApiHelpers.postInfo(selectInfo);
        }


        #endregion


        #region
        /// <summary>
        /// 专业组信息视图表
        /// </summary>
        public static void GetWorkDictionary()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.WorkDictionary";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTWorkDictionary = ApiHelpers.postInfo(selectInfo);
        }
        #endregion


        #region 报表信息


        public static void GetReprotBindInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Report.BindInfo";
            selectInfo.OrderColumns = "id";
            ReportCommData.DTReportBindInfo = ApiHelpers.postInfo(selectInfo);
        }
        public static void GetReprotSrouceInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "Report.SrouceInfo";
            selectInfo.OrderColumns = "typeNO";
            ReportCommData.DTReportSrouceInfo = ApiHelpers.postInfo(selectInfo);
        }



        #endregion

        #region 仪器  委托医院信息
        public static void GetInstrumentInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.InstrumentInfo";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTInstrumentInfo = ApiHelpers.postInfo(selectInfo);
        }
        public static void GetDelegeteCompanyInfo()
        {
            sInfo selectInfo = new sInfo();
            selectInfo.TableName = "WorkComm.ClientDelegateInfo";
            selectInfo.OrderColumns = "sort";
            WorkCommData.DTClientDelegateInfo = ApiHelpers.postInfo(selectInfo);
        }


        #endregion



    }
}
