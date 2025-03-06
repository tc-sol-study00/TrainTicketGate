namespace TrainTicketGate.DTO {
    /// <summary>
    /// 時刻表
    /// </summary>
    public class TimeTable {
        /// <summary>
        /// 列車名称
        /// </summary>
        public required string TrainName { get; set; }

        /// <summary>
        /// 駅到着時刻
        /// </summary>
        public required TimeOnly ArivalTime { get; set; }
    }
}
