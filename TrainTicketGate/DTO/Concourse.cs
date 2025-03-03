using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.Services;

namespace TrainTicketGate.DTO {

    /// <summary>
    /// コンコース用クラス
    /// </summary>

    internal class Concourse : AEquipment {
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
        /// <param name="name"></param>
        public Concourse(string name) : base() {
            Name = name;
            Customers = new List<Customer>();
        }

        /// <summary>
        /// コンコースにある客が差し掛かるときの処理
        /// </summary>
        /// <param name="timeOperation"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Concourse SetEnterDateTime(TimeOperation timeOperation, IList<Customer> argCustomers) {


            foreach(Customer aCustomer in argCustomers) {
                Customers.Add(aCustomer);
            }
            base.SetEnterDateTime(timeOperation, Config.ConcourceDefine.ConcourceSpendSecond);
            return this;
        }

        /// <summary>
        /// コンコースから人が抜けたときの処理と初期化
        /// </summary>
        /// <returns></returns>
        public override Concourse SetExitDateTime() {
            base.SetExitDateTime();
            return this;
        }

        public void Reset() {
            Customers = new List<Customer>();
        }

    }
}
