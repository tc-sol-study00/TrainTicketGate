using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {
    public class StationOperations {

        /// <summary>
        /// コンコースリスト
        /// </summary>
        /// <remarks>
        /// コンコースは一つだが、各列車から降車した乗客が改札口に到着する前に、次の列車が到着するのでリスト化している
        /// </remarks>
        public IList<Concourse> Concourses { get; init; }

        /// <summary>
        /// 改札口運行クラス
        /// </summary>

        public readonly TicketGateOperation _ticketGateOperation;

        private readonly TimeOperation _timeOperation;
        public StationOperations(TimeOperation timeOperation) {
            _timeOperation = timeOperation;
            Concourses = new List<Concourse>();
            _ticketGateOperation = new TicketGateOperation(_timeOperation);
        }

        /// <summary>
        /// 列車到着し、コンコースにお客たちを設定
        /// </summary>
        /// <param name="train">到着列車</param>
        /// <returns></returns>
        public IList<Concourse> TrainArrival(Train train) {
            //コンコース名
            Concourse aConcourse = new Concourse(Config.ConcourseDefine.ConcourseName);
            
            //コンコース乗客設定
            aConcourse.SetEnterDateTime(_timeOperation.CurrentDateTime, train.Customers);
            Concourses.Add(aConcourse);
            
            return Concourses;
        }

        /// <summary>
        /// 駅オペレーション
        /// </summary>
        /// <param name="concourses">コンコースリスト</param>
        /// <returns></returns>
        public TicketGateOperation StationExecution(IList<Concourse> concourses) {

            /*
             * コンコースでの各列車到着にあわせリスト化している
             * お客が改札口到着後、改札口待ち行列に設定
             */
            for(int c=0; c < Concourses.Count; ){

                //コンコースの乗客が改札口エリアに到着したか？
                if (Concourses[c].IsExitTime(_timeOperation.CurrentDateTime)) {
                    //到着
                    Concourses[c].SetExitDateTime();
                    //改札口の待ち行列にコンコースの乗客を追加
                    IList<Customer> exitedCustomers = Concourses[c].Customers;
                    _ticketGateOperation.AcceptCustomers(exitedCustomers);
                    //追加後、コンコースリストから削除
                    Concourses.RemoveAt(c);
                } else {
                    c++;
                }
            }

            /*
             * 改札シミュレーション
             */
            TicketGateOperation ticketGateOperation =_ticketGateOperation.AllocateCustomerToGate();

            return ticketGateOperation;
        }
    }
}
