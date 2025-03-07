namespace TrainTicketGate.Services {

    /// <summary>
    /// 施設クラス
    /// </summary>
    /// <remarks>
    /// 改札口・コンコースの基底クラス
    /// </remarks>
    public abstract class AEquipment {
        /// <summary>
        /// 施設に入ってきた時間
        /// </summary>
        public DateTime EnterDateTime { get; private set; }

        /// <summary>
        /// 施設から出る予定時間
        /// </summary>
        public  DateTime EstimateExitDateTime { get; private set; }

        /// <summary>
        /// 施設に要する時間
        /// </summary>
        public int SpendSecond { get; private set; }

        /// <summary>
        /// その施設・設備がビジーか？
        /// </summary>
        public bool BusyFlg { get; private set; }

        public AEquipment()  {
            //初期化
            SetExitDateTime();
        }

        /// <summary>
        /// 設備利用開始時間・利用終了予定時間を求める
        /// また、設備をビジーにする
        /// </summary>
        /// <param name="currentDateTime">現在時間</param>
        /// <param name="spendTime">設備を利用するのに要する時間（秒）</param>
        /// <returns></returns>
        protected AEquipment SetEnterDateTime(DateTime currentDateTime, int spendTime) {
            SpendSecond = spendTime;
            EnterDateTime = currentDateTime;
            EstimateExitDateTime=EnterDateTime.AddSeconds(spendTime);
            BusyFlg = true;
            return this;
        }

        /// <summary>
        /// 施設から人が抜けたときの処理と初期化
        /// 設備はノービジーにする
        /// </summary>
        public virtual void  SetExitDateTime() {
            EnterDateTime = DateTime.MinValue;
            EstimateExitDateTime = DateTime.MinValue;
            SpendSecond = default;
            BusyFlg = false;
        }

        /// <summary>
        /// 施設の利用終了時間になったか
        /// </summary>
        /// <param name="timeOperation"></param>
        /// <returns>true/false</returns>
        public bool IsExitTime(DateTime currentDateTime) => EstimateExitDateTime == currentDateTime;
    }
}
