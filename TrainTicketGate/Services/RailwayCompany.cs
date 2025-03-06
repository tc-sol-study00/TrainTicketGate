﻿using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {


    /// <summary>
    /// 鉄道会社クラス
    /// </summary>
    public class RailwayCompany {

        private readonly DateTime _startTime;
        private readonly DateTime _endTime;
        private readonly DateTime _serviceEndTime;

        private readonly TimeOperation _timeOperation;
        public readonly TrainOperation _trainOperation;
        public readonly StationOperations _stationOperation;


        public IDictionary<string, int> CustomerQty { get; private set; } = new Dictionary<string, int>();

        public RailwayCompany() {
            //今日の日付
            DateOnly todayDateOnly = DateOnly.FromDateTime(DateTime.Today);
            
            //時間のみを今日の時間に変換
            //シミュレーション開始日時
            _startTime = todayDateOnly.ToDateTime(Config.ServicePeriod.StartTimeOnly);
            //シミュレーション終了日時
            _endTime = todayDateOnly.ToDateTime(Config.ServicePeriod.EndTimeOnly);
            //終電時間
            _serviceEndTime = todayDateOnly.ToDateTime(Config.ServicePeriod.ServiceEndTimeOnly);

            //時間オペレーションオブジェクト
            _timeOperation = new TimeOperation(_startTime, _endTime);
            //列車運行オブジェクト
            _trainOperation = new TrainOperation(TimeOnly.FromDateTime(_startTime), TimeOnly.FromDateTime(_serviceEndTime));
            //駅運行オブジェクト
            _stationOperation = new StationOperations(_timeOperation);

        }

        /// <summary>
        /// 鉄道会社オペレーション
        /// </summary>
        public RailwayCompany RailwayCompanyOperations() {
            /*
             * シミュレーション終了時間まで実行
             */
            int preCount=0;
            while (!_timeOperation.IsOverPeriod()) {

                /*
                 * 列車が到着したか？
                 */
                IList<Concourse>? concourses = _stationOperation.Concourses;

                Train? train = _trainOperation.CheckArrivalTimeAndCreateTrainWithCustomer(_timeOperation);
                if (train != null) {
                    //到着したら、列車に乗っていたお客を駅のコンコースに登録
                    concourses = _stationOperation.TrainArrival(train);
                    CustomerQty[train.TrainName] = train.Customers.Count;
                }

                /*
                 * 駅オペレーション
                 * ①コンコースからお客が改札エリアに到着する時間か？
                 * ②到着時間だったら、改札口エリアにお客を並ばせる
                 * ③改札口が開いたかどうか確認
                 * ④空いていたら、お客を改札口にセット
                 */
                TicketGateOperation currentTicketGateOperation=_stationOperation.StationExecution(concourses);

                /*
                 *シミュレーション経緯を表示
                 */
                if (currentTicketGateOperation.Customers.Count > 0 || preCount>0 && currentTicketGateOperation.Customers.Count ==0) {
                    Console.WriteLine($"{_timeOperation.CurrentDateTime}:{new string('*', currentTicketGateOperation.Customers.Count / 100)}{currentTicketGateOperation.Customers.Count}");
                }
                preCount = currentTicketGateOperation.Customers.Count;

                /*
                 * 時間を１秒進ませる
                 */
                _timeOperation.IncrementSecond();

            }
            return this;
        }

        /// <summary>
        /// 集計・表示
        /// </summary>
        public void Summarize() {
            Action df = () => {
                Console.WriteLine(new string('-', 60));
            };
            Action<string> dh = x => {
                df();
                Console.WriteLine(x);
                df();
            };

            /*
             * 時間帯別待ち時間集計
             */
            dh("時間帯別待ち時間集計(時間帯:最小:平均:最大)");
            var summarizedList=_stationOperation._ticketGateOperation.PutOutCustomers.GroupBy(x => x.DateTimeGetTicketGateArea.Hour)
                .Select( g=>new { Hour=g.Key, Min = g.Min(x => x.WaitSeconds), Avg = g.Average(x => x.WaitSeconds),Max = g.Max(x => x.WaitSeconds) });


            foreach (var aList in summarizedList) {
                Console.WriteLine($"{aList.Hour:00}:{aList.Min}:{(int)aList.Avg}:{aList.Max}");
            }

            /*
             * 時間帯別待ち行列数集計
             */
            dh("時間帯別待ち行列数集計(時間帯:最小:平均:最大)");
            var queueSummary=_stationOperation._ticketGateOperation.WaitQueueBySecondsTimes.GroupBy(x => x.ActualDatetime.Hour)
                .Select(g => new { Hour = g.Key, Min = g.Min(x => x.CustomerNumber), Avg = g.Average(x => x.CustomerNumber), Max = g.Max(x => x.CustomerNumber) });

            foreach (var aList in queueSummary) {
                Console.WriteLine($"{aList.Hour:00}:{aList.Min}:{(int)aList.Avg}:{aList.Max}");
            }
            df();
        }
    }
}
