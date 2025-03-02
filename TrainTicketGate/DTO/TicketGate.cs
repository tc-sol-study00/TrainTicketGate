using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.Services;

namespace TrainTicketGate.DTO {
    internal class TicketGate {
        public string TicketrGateName { get; set; }

        public DateTime EnterDateTime { get; private set; }

        public DateTime EstimateExitDateTime { get; private set; }

        public TicketGate SetEnterDateTime(TimeOperation timeOperation, Customer customer) {
            EnterDateTime = timeOperation.CurrentDateTime;
            customer.AdultChileClassification 
        }

    }
}
