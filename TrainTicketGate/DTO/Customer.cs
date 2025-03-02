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

        public int SpendSecond => Config.TimeByCustomerType[AdultChileClassification]; 

    }
}
