using TrainTicketGate.Services;

namespace TrainTicketGate
{
    internal class Program {

        private static RailwayCompanyOperation _railwayCompanyOperation;
        static void Main(string[] args) {

            _railwayCompanyOperation = new RailwayCompanyOperation();
        }
    }
}
