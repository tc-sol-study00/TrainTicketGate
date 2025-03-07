using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketGate.DTO
{
    /// <summary>
    /// 処理結果結果表示用
    /// </summary>
    public class SummarizedCustomerData
    {
        /// <summary>
        /// 時間帯
        /// </summary>
        public double Hour { get; set; }
        /// <summary>
        /// 最大値
        /// </summary>
        public double Min { get; set; }
        /// <summary>
        /// 平均値
        /// </summary>
        public double Average { get; set; }
        /// <summary>
        /// 最大値
        /// </summary>
        public double Max { get; set; }
    }
}
