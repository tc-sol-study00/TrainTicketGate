using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {
    /// <summary>
    /// 改札口クラス
    /// </summary>
    public class TicketGate : AEquipment {
        /// <summary>
        /// 改札口名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 改札にいるお客
        /// </summary>
        public Customer? Customer { get; private set; }

        /// <summary>
        /// 初期化で改札名を設定
        /// </summary>
        /// <param name="name"></param>
        public TicketGate(string name) : base() {
            Name = name;
        }

        /// <summary>
        /// 改札口にある客が差し掛かるときの処理
        /// </summary>
        /// <param name="timeOperation"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public TicketGate SetEnterDateTime(DateTime currentDateTime, Customer customer) {
            Customer = customer;
            SetEnterDateTime(currentDateTime, Customer.SpendSeconds);
            return this;
        }

        /// <summary>
        /// 改札から人が抜けたときの処理と初期化
        /// </summary>
        /// <returns></returns>
        public override void SetExitDateTime() {
            Customer = null;
            base.SetExitDateTime();
        }

    }
}
