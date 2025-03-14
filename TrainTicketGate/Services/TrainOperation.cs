﻿using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {
    public class TrainOperation {

        /// <summary>
        /// 列車運行リスト固定値
        /// </summary>
        /// <remarks>
        /// 自動作成ではない場合は、これらをセットする
        /// </remarks>
        private static readonly IList<TimeTable> _initTimeTables =
            new List<TimeTable> {
                new TimeTable { TrainName = "08:00着列車", ArivalTime = new TimeOnly(8,0)  },
                new TimeTable { TrainName = "08:20着列車", ArivalTime = new TimeOnly(8,20) }
            };
        /// <summary>
        /// 列車運行リスト
        /// </summary>
        public IList<TimeTable>? TimeTables { get; set; }

        /// <summary>
        /// 始発時間
        /// </summary>
        public TimeOnly ServicesStartTime { get; private set; }

        /// <summary>
        /// 終電時間
        /// </summary>
        public TimeOnly ServicesEndTime { get; private set; }

        /// <summary>
        /// 列車運行リスト固定値セットの場合、引数なし
        /// </summary>
        public TrainOperation() {
            CreateTimeTables();
        }
        /// <summary>
        /// 列車運行リスト自動作成の場合、引数セット
        /// </summary>
        /// <param name="servicesStartTime">始発時間</param>
        /// <param name="servicesEndTime">終電時間</param>
        public TrainOperation(TimeOnly servicesStartTime, TimeOnly servicesEndTime) {
            ServicesStartTime = servicesStartTime;
            ServicesEndTime = servicesEndTime;
            CreateTimeTables();
        }

        /// <summary>
        /// 列車運行リスト作成
        /// </summary>
        /// <returns>列車運行リスト</returns>
        public IList<TimeTable> CreateTimeTables() {
            if (ServicesStartTime != TimeOnly.MinValue && ServicesEndTime != TimeOnly.MinValue) {
                /*
                 * 列車運行リスト自動作成
                 */
                TimeOnly setTime = ServicesStartTime;
                TimeTables = new List<TimeTable>();
                while (setTime <= ServicesEndTime) {
                    TimeTables.Add(new TimeTable { TrainName = setTime.ToString("HH:mm着列車"), ArivalTime = setTime });
                    setTime = setTime.AddMinutes(5);
                }

            } else {
                /*
                 *  列車運行リスト固定値セット
                 */
                TimeTables = _initTimeTables;
                ServicesStartTime = _initTimeTables.Min(x => x.ArivalTime);
                ServicesEndTime = _initTimeTables.Max(x => x.ArivalTime);
            }
            return TimeTables;
        }

        /// <summary>
        /// 列車一系統分の作成
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        public Train CreateTrain(string trainName,IList<Customer> customers) {
            return new Train() { TrainName = trainName, Customers = customers };
        }
        /// <summary>
        /// 時刻表の時間になったら、列車一系統とそれに乗るお客さんを作成
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Train? CheckArrivalTimeAndCreateTrainWithCustomer(TimeOperation time) {

            if (TimeTables == null) return null;

            TimeTable? timeTable = TimeTables.Where(x => time.GetDateTime(time.CurrentDate, x.ArivalTime) == time.CurrentDateTime).FirstOrDefault();

            if (timeTable != null) {
                /*
                 * お客さん作成
                 */
                CustomerOperation customerOperation = new CustomerOperation();
                IList<Customer> customers = customerOperation.CreateCustomers();

                /*
                 * 列車を作成し、お客を乗せる
                 */
                return CreateTrain(timeTable.TrainName, customers);
            } else {
                return null;
            }
        }

}
}
