using TrainTicketGate.Services;

namespace TrainTicketGate
{
    internal class Program {
        /// <summary>
        /// 改札シミュレーションメイン
        /// </summary>
        /// <param name="args">なし</param>
        static void Main(string[] args) {
            /*
             * 鉄道会社クラスを生成
             */
            RailwayCompany _railwayCompany = new RailwayCompany();

            /*
             * 鉄道会社オペレーション処理
             */
            _railwayCompany.RailwayCompanyOperations();
            _railwayCompany.Summarize();
        }
    }
}
