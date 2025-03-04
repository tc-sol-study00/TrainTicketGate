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
            /*
             *　お客の人数on列車 
             */
            Random random = new Random();
            int numberOfCustomer = random.Next(CustomerDefine.CustomerNumberONaTrain.MinNumber, CustomerDefine.CustomerNumberONaTrain.MaxNumber+1);

            /*
             * お客一人一人の大人・小人区分を指示された比率でセット
             */
            for (int c = 0; c < numberOfCustomer; c++) {
                Config.EnumAdultChildClassification adultChileClassification 
                    = random.Next(1, 101) <= CustomerDefine.AdultRatio ? EnumAdultChildClassification.Adult : EnumAdultChildClassification.Child;
                Customers.Add(new Customer { AdultChildClassification=adultChileClassification });
            }
            return Customers;
        }
    }
}
