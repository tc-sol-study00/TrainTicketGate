
namespace TrainTicketGate.DTO {
    /// <summary>
    /// 改札口前の待ち行列
    /// </summary>
    internal class WaitQueueBySecondsTime {
        /// <summary>
        /// 時点データ（１秒ごと）
        /// </summary>
        public DateTime ActualDatetime { get; set; }

        /// <summary>
        /// 大人の人数
        /// </summary>
        public int CustomerNumberOfAdult { get; set; }

        /// <summary>
        /// 子供の人数
        /// </summary>
        public int CustomerNumberOfChild { get; set; }

        /// <summary>
        /// 合計の人数
        /// </summary>
        public int CustomerNumber => CustomerNumberOfChild + CustomerNumberOfAdult;

    }
}
