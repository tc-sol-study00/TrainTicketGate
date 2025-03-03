using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.Services;

namespace TrainTicketGate.DTO {
    /// <summary>
    /// 改札口クラス
    /// </summary>
    internal class TicketGate : AEquipment {
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
        public TicketGate SetEnterDateTime(TimeOperation timeOperation, Customer customer) {
            Customer = customer;
            SetEnterDateTime(timeOperation, Customer.SpendSeconds);
            return this;
        }

        /// <summary>
        /// 改札から人が抜けたときの処理と初期化
        /// </summary>
        /// <returns></returns>
        public override TicketGate SetExitDateTime() {
            Customer = null;
            base.SetExitDateTime();
            return this;
        }

    }
}
