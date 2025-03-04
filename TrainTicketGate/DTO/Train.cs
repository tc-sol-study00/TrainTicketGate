namespace TrainTicketGate.DTO {
    /// <summary>
    /// 列車
    /// </summary>
    internal class Train {
        /// <summary>
        /// 列車名称
        /// </summary>
        public required string TrainName { get; set; }
        /// <summary>
        /// 乗客
        /// </summary>
        public required IList<Customer> Customers { get; set; }
    }
}
