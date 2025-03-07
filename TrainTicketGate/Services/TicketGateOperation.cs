using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {

    /// <summary>
    /// 改札口運行クラス
    /// </summary>
    public class TicketGateOperation {

        /// <summary>
        /// 改札口リスト
        /// </summary>
        public IReadOnlyList<TicketGate> TicketGates { get; init; }

        /// <summary>
        /// 改札前待ち行列
        /// </summary>
        public IList<Customer> Customers { get; private set; }

        /// <summary>
        /// 改札からデータ乗客
        /// </summary>
        public IList<Customer> PutOutCustomers { get; private set; }

        /// <summary>
        /// 時間ごとの待ち行列集計
        /// </summary>
        public IList<WaitQueueBySecondsTime> WaitQueueBySecondsTimes { get; private set; }

        /// <summary>
        /// 時間オペレーション
        /// </summary>
        private readonly TimeOperation _timeOperation;

        /// <summary>
        /// 初期化
        /// </summary>
        /// <param name="timeOperation"></param>
        public TicketGateOperation(TimeOperation timeOperation) {
            _timeOperation = timeOperation;         //時間オペレーション
            TicketGates = Config.TicketGates;       //改札口構成
            Customers = new List<Customer>();       //待ち行列初期化
            PutOutCustomers = new List<Customer>(); //改札から出た乗客処理科
            WaitQueueBySecondsTimes = new List<WaitQueueBySecondsTime>();    //待ち行列集計
        }

        /*
         * 待ち行列制御
         */

        /// <summary>
        /// コンコースからのお客たちを受け入れる
        /// </summary>
        /// <param name="customers">コンコースからの乗客</param>
        /// <returns>待ち行列リスト</returns>
        public IList<Customer> AcceptCustomers(IList<Customer> customers) {
            foreach (Customer aCustomer in customers) {
                aCustomer.DateTimeGetTicketGateArea = _timeOperation.CurrentDateTime;
                Customers.Add(aCustomer);
            }
            return Customers;
        }

        /// <summary>
        /// 改札から出てきた時間
        /// </summary>
        /// <param name="customer">一人のお客</param>
        /// <returns>出てきた時間がセットされたお客</returns>
        private IList<Customer> PutOutCustomer(Customer customer) {
            customer.DateTimeExitTicketGateArea = _timeOperation.CurrentDateTime;
            PutOutCustomers.Add(customer);
            return PutOutCustomers;
        }

        /// <summary>
        /// 待ち行列から一人取り出す（FIFO）
        /// </summary>
        /// <returns>待ち行列から抽出された一人</returns>
        public Customer? PullDownCustomer() {
            Customer? customer;
            if (Customers.Count > 0) {
                customer = Customers[0];
                Customers.RemoveAt(0);
            } else {
                customer = null;
            }
            return customer;
        }
        public TicketGateOperation AllocateCustomerToGate() {
            /*
             * 改札を抜けるお客を探して、対象であれば、改札口を空きにする
             */
            foreach (TicketGate aTicketGate in TicketGates.Where(x => x.BusyFlg == true && x.EstimateExitDateTime == _timeOperation.CurrentDateTime)) {
                //改札を抜けた時間
                if (aTicketGate.Customer != null) {
                    PutOutCustomers=PutOutCustomer(aTicketGate.Customer);
                }
                //改札クリア(ノービジー化）
                aTicketGate.SetExitDateTime();
            }

            /*
             * 改札口の空きを探し、空いていたら待ち行列から一人抜き出し、空きの改札口にセット
             */
            if (Customers.Count > 0) {
                foreach (TicketGate aTicketGate in TicketGates.Where(x => x.BusyFlg == false)) {
                    Customer? customer = PullDownCustomer();
                    if (customer != null) {
                        aTicketGate.SetEnterDateTime(_timeOperation.CurrentDateTime, customer);
                        if (Customers.Count <= 0) break;
                    } else {
                        break;
                    }
                }
            }
            //待ち行列集計（秒単位）
            WaitQueueBySecondsTimes=
                CreateWaitQueueBySecondsTime(Customers, WaitQueueBySecondsTimes);

            return this;
        }

        /// <summary>
        /// 待ち行列集計（秒単位）
        /// </summary>
        /// <param name="customers">改札前待ち行列</param>
        /// <param name="waitQueueBySecondsTimes">改札口前の待ち行列</param>
        /// <returns>改札口前の待ち行列</returns>
        private IList<WaitQueueBySecondsTime> CreateWaitQueueBySecondsTime(IList<Customer> customers, IList<WaitQueueBySecondsTime> waitQueueBySecondsTimes) {
            Dictionary<Config.EnumAdultChildClassification, int> summary 
                = customers.GroupBy(x => x.AdultChildClassification).ToDictionary(g => g.Key, g => g.Count());
            (int,int) result = (summary.GetValueOrDefault(Config.EnumAdultChildClassification.Adult, 0),
                                summary.GetValueOrDefault(Config.EnumAdultChildClassification.Child, 0));

            waitQueueBySecondsTimes.Add(
                new WaitQueueBySecondsTime() { 
                    ActualDatetime = _timeOperation.CurrentDateTime, CustomerNumberOfAdult = result.Item1, CustomerNumberOfChild = result.Item2 
                }
            );

            return waitQueueBySecondsTimes;
        }
    }
}
