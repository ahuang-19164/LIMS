

namespace Common.SystemModel
{
    ///<summary>
    ///项目参考值信息
    /// </summary>
    public partial class comm_item_reference
    {
        public comm_item_reference()
        {
            state = true;
            dstate = false;
        }
        /// <summary>
        /// id
        /// </summary>

        public int id { get; set; }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int testNO { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string clientNO { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string instrumentNO { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string sampeTypeNO { get; set; }

        /// <summary>
        /// Desc:性别编号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int sexNO { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int ageYearDown { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int ageYearUP { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int ageMothDown { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int ageMothUP { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int ageDayDown { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int ageDayUP { get; set; } = 0;

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double valueDown { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double valueUP { get; set; }

        /// <summary>
        /// Desc:参考值描述
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string valueDescribe { get; set; }

        /// <summary>
        /// Desc:危急值
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double crisisDown { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public double crisisUP { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public bool state { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string remark { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public bool dstate { get; set; } = false;
    }
}
