using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainTicketGate.DTO {

    /// <summary>
    /// 列車
    /// </summary>
    internal class Train {
        /// <summary>
        /// 列車名称
        /// </summary>
        public string TrainName { get; set; }
        /// <summary>
        /// 乗客
        /// </summary>
        public IList<Customer> Customers { get; set; }

    }
}
