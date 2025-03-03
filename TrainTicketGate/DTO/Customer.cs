using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.Services;

namespace TrainTicketGate.DTO {

    internal class Customer {
        public Config.EnumAdultChileClassification AdultChileClassification { get; set; }

        public DateTime DateTimeGetTicketGateArea { get; set; }

        public DateTime DateTimeExitTicketGateArea { get; set; }
        public int WaitSeconds {
            get {
                if (DateTimeGetTicketGateArea <= DateTimeExitTicketGateArea) {
                    return (int)(DateTimeExitTicketGateArea - DateTimeGetTicketGateArea).TotalSeconds;
                } else {
                    return 0;
                }
            }
        }
        public int SpendSeconds => Config.TimeByCustomerType[AdultChileClassification]; 

    }
}
