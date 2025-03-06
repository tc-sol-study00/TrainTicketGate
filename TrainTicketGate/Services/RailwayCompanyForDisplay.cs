using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {


    /// <summary>
    /// 鉄道会社クラス
    /// </summary>
    public class RailwayCompanyForDisplay : RailwayCompany {

        public RailwayCompanyForDisplay() : base() {
        }

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
            var summarizedList = SummarizeCustomerWaitTime();


            foreach (var aList in summarizedList) {
                Console.WriteLine($"{aList.Hour:00}:{aList.Min}:{(int)aList.Average}:{aList.Max}");
            }

            /*
             * 時間帯別待ち行列数集計
             */
            dh("時間帯別待ち行列数集計(時間帯:最小:平均:最大)");
            var queueSummary = SummarizePutOutCustomer();

            foreach (var aList in queueSummary) {
                Console.WriteLine($"{aList.Hour:00}:{aList.Min}:{(int)aList.Average}:{aList.Max}");
            }
            df();
        }
    }
}
