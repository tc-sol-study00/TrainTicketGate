using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.Services;

namespace TrainTicketGate.DTO {

    /// <summary>
    /// お客
    /// </summary>
    internal class Customer {
        /// <summary>
        /// 大人・小人区分
        /// </summary>
        public Config.EnumAdultChileClassification AdultChileClassification { get; set; }

        /// <summary>
        /// 改札口エリア到着時間
        /// </summary>
        public DateTime DateTimeGetTicketGateArea { get; set; }

        /// <summary>
        /// 改札口から出てきた時間
        /// </summary>
        public DateTime DateTimeExitTicketGateArea { get; set; }

        /// <summary>
        /// 改札待ち時間
        /// </summary>
        public int WaitSeconds {
            get {
                if (DateTimeGetTicketGateArea <= DateTimeExitTicketGateArea) {
                    return (int)(DateTimeExitTicketGateArea - DateTimeGetTicketGateArea).TotalSeconds;
                } else {
                    return 0;
                }
            }
        }

        /// <summary>
        /// このお客の改札口通過時間
        /// </summary>
        public int SpendSeconds => Config.TimeByCustomerType[AdultChileClassification]; 

    }
}
