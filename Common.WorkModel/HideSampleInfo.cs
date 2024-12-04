using System.Collections.Generic;

namespace Common.WorkModel
{
    public class HideSampleInfo
    {
        public string userName { get; set; }
        public string token { get; set; }
        public List<string> barcode { get; set; }
        /// <summary>
        ///1.删除操作。2。退单操作。3.作废操作
        /// </summary>
        public string operationType { get; set; }
        /// <summary>
        /// 操作原因
        /// </summary>
        public string reason { get; set; }
    }
}
