
namespace TrainTicketGate.DTO {
    internal class WaitQueueBySecondsTime {
        public DateTime ActualDatetime { get; set; }
        public int CustomerNumberOfAdult { get; set; }

        public int CustomerNumberOfChild { get; set; }

        public int CustomerNumber => CustomerNumberOfChild + CustomerNumberOfAdult;

    }
}
