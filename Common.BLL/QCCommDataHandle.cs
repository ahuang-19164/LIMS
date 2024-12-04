using Common.Data;
using Common.SqlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BLL
{
    public class QCCommDataHandle
    {

        public static void GetQCAll()
        {
            GetQCInfo();
        }


        private static void GetQCInfo()
        {
            sInfo sg = new sInfo();
            sg.TableName = "QC.RuleGroup";
            QCInfoData.DTRuleGroup = ApiHelpers.postInfo(sg);
            sInfo sqc = new sInfo();
            sqc.TableName = "QC.RuleQC";
            QCInfoData.DTRuleQC = ApiHelpers.postInfo(sqc);
            sInfo Plan = new sInfo();
            Plan.TableName = "QC.QCPlan";
            QCInfoData.DTQCPlan = ApiHelpers.postInfo(Plan);
            sInfo Grade = new sInfo();
            Grade.TableName = "QC.QCGrade";
            QCInfoData.DTQCGrade = ApiHelpers.postInfo(Grade);
            sInfo Batch = new sInfo();
            Batch.TableName = "QC.QCBatch";
            QCInfoData.DTQCBatch = ApiHelpers.postInfo(Batch);
            sInfo leC = new sInfo();
            leC.TableName = "QC.RuleClass";
            QCInfoData.DTRuleClass = ApiHelpers.postInfo(leC);
        }
    }
}
