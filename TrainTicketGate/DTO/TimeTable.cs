using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketGate.DTO {
    /// <summary>
    /// 時刻表
    /// </summary>
    internal class TimeTable {

        /// <summary>
        /// 列車名称
        /// </summary>
        public string TrainName { get; set; }

        /// <summary>
        /// 駅到着時刻
        /// </summary>
        public TimeOnly ArivalTime { get; set; }
    }
}
