using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTicketGate.DTO;

namespace TrainTicketGate.Services {


    internal class RailwayCompanyOperation {

        private static class ServicePeriod {
            public static readonly TimeOnly StartTimeOnly = new TimeOnly(8, 0);
            public static readonly TimeOnly EndTimeOnly = new TimeOnly(22, 0);
        }

        private  DateTime _startTime;
        private  DateTime _endTime;

        private TimeOperation _timeOperation;

        private TrainOperation _trainOperation;


        public RailwayCompanyOperation() {

            DateOnly todayDateOnly = DateOnly.FromDateTime(DateTime.Today);

            _startTime = todayDateOnly.ToDateTime(ServicePeriod.StartTimeOnly);
            _endTime= todayDateOnly.ToDateTime(ServicePeriod.EndTimeOnly);

            _timeOperation = new TimeOperation(_startTime, _endTime);

            _trainOperation = new TrainOperation(TimeOnly.FromDateTime(_startTime), TimeOnly.FromDateTime(_endTime));

            while (!_timeOperation.IsOverPeriod()) {

                Train? train = _trainOperation.CheckArrivalTime(_timeOperation);
                if (train != null) {

                }

                _timeOperation.IncrementSecond();

            }


        }
    }
}
