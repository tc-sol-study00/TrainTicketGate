using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketGate.DTO {
    internal class Train {
        public string TrainName { get; set; }
        public IList<Customer> Customers { get; set; }

    }
}
