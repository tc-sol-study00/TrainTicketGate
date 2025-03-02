using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {
    internal static  class Config {
        public enum EnumAdultChileClassification {
            Adult,
            Child
        }

        public static IDictionary<EnumAdultChileClassification, int> TimeByCustomerType { get; }
            = new Dictionary<EnumAdultChileClassification, int>
                {
                    { EnumAdultChileClassification.Adult, 2 },
                    { EnumAdultChileClassification.Child, 5 }
                };
    }
}
