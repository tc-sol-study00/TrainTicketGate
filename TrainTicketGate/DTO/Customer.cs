using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketGate.DTO {

    public enum EnumAdultChileClassification {
        Adult,
        Child
    }
    internal class Customer {
        public EnumAdultChileClassification AdultChileClassification { get; set; }


    }
}
