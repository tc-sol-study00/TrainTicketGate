using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {
    /// <summary>
    /// コンコース用クラス
    /// </summary>
    public class Concourse : AEquipment {
        /// <summary>
        ///コンコース名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// コンコースにいるお客
        /// </summary>
        public IList<Customer> Customers { get; private set; }

        /// <summary>
        /// 初期化でコンコース名を設定
        /// </summary>
        /// <param name="name">コンコース名称</param>
        public Concourse(string name) : base() {
            Name = name;
            Customers = new List<Customer>();
        }

        /// <summary>
        /// コンコースにある客が差し掛かるときの処理
        /// </summary>
        /// <param name="currentDateTime">現在時間</param>
        /// <param name="argCustomers">コンコースを通るお客たち</param>
        /// <returns>コンコース</returns>
        public Concourse SetEnterDateTime(DateTime currentDateTime, IList<Customer> argCustomers) {
            foreach(Customer aCustomer in argCustomers) {
                Customers.Add(aCustomer);
            }
            SetEnterDateTime(currentDateTime, Config.ConcourseDefine.ConcourseSpendSecond);
            return this;
        }

        /// <summary>
        /// コンコースから人が抜けたときの処理と初期化
        /// </summary>
        public override void SetExitDateTime() {
            base.SetExitDateTime();
        }
    }
}
