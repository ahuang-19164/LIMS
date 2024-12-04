
using System;

namespace Common.SystemModel
{

    public partial class comm_client_group
    {
        public comm_client_group()
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
        public string clientid { get; set; }

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
        public string groupNO { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string chargeLevelNO { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string discount { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string creater { get; set; }

        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime createTime { get; set; }

        /// <summary>
        /// Desc:
        /// Default:1
        /// Nullable:True
        /// </summary>           
        public bool state { get; set; }

        /// <summary>
        /// Desc:
        /// Default:0
        /// Nullable:True
        /// </summary>           
        public bool dstate { get; set; } = false;

    }
}
