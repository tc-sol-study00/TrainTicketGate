using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketGate.DTO {
    internal class TimeTable {
        public string TrainName { get; set; }
        public TimeOnly ArivalTime { get; set; }
    }
}
