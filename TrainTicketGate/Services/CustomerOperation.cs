using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.DTO;
using static TrainTicketGate.Services.Config;

namespace TrainTicketGate.Services {

    /// <summary>
    /// 乗客運行クラス
    /// </summary>
    internal class CustomerOperation {

        /// <summary>
        /// 乗客たち
        /// </summary>
        public IList<Customer> Customers { get; private set; } = new List<Customer>();

        /// <summary>
        /// 乗客を乱数利用で大人・小人をそれぞれ配置する
        /// </summary>
        /// <returns>乗客リスト</returns>
        public IList<Customer> CreateCustomers() {
            Random random = new Random();
            /*
             *　お客の人数on列車 
             */
            int numberOfCustomer = random.Next(CustomerDefine.CustomerNumberONaTrain.MinNumber, CustomerDefine.CustomerNumberONaTrain.MaxNumber+1);

            /*
             * お客一人一人の大人・小人区分を指示された比率でセット
             */
            for (int c = 0; c < numberOfCustomer; c++) {
                var adultChileClassification = random.Next(1, 101) <= CustomerDefine.AdultRatio ? EnumAdultChileClassification.Adult : EnumAdultChileClassification.Child;
                Customers.Add(new Customer { AdultChileClassification=adultChileClassification });
            }

            return Customers;
        }
    }
}
