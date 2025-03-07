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
    
    /// <summary>
    /// 列車単位の乗客数参照用
    /// </summary>
    public class TimeTableWithCustomerQty : TimeTable {
        /// <summary>
        /// 乗客数
        /// </summary>
        public int CustomerQty { get; set; }
    }
}
