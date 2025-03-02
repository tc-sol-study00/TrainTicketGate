using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {
    internal class CustomerOperation {

        public IList<Customer> Customers { get; private set; } = new List<Customer>();

        public IList<Customer> CreateCustomers() {
            Random random = new Random();
            int numberOfCustomer = random.Next(80, 1200+1);

            for (int c = 0; c < numberOfCustomer; c++) {
                var adultChileClassification = random.Next(1, 101) <= 80 ? EnumAdultChileClassification.Adult : EnumAdultChileClassification.Child;
                Customers.Add(new Customer { AdultChileClassification=adultChileClassification });
            }

            return Customers;
        }
    }
}
