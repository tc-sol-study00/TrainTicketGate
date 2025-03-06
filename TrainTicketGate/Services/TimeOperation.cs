namespace TrainTicketGate.Services {
    public class TimeOperation {
        /// <summary>
        /// 本日
        /// </summary>
        public DateOnly CurrentDate { get; private set; }
        /// <summary>
        /// シミュレーション現在時間
        /// </summary>
        public DateTime CurrentDateTime { get; private set; }
        /// <summary>
        /// シミュレーション開始時間
        /// </summary>
        public DateTime StartDateTime { get; private set; }
        /// <summary>
        /// シミュレーション終了時間
        /// </summary>
        public DateTime EndDateTime { get; private set; }

        public TimeOperation() { 
        
        }
        /// <summary>
        /// シミュレーション開始時間・終了時間セット
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        public TimeOperation(DateTime startDateTime, DateTime endDateTime) {
            SetPeriod(startDateTime, endDateTime);
        }
        /// <summary>
        /// シミュレーション期間をセットする
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        public void SetPeriod(DateTime startDateTime, DateTime endDateTime) {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            CurrentDateTime = StartDateTime;

            CurrentDate = DateOnly.FromDateTime(startDateTime);
        }

        /// <summary>
        /// 今の時間に秒を足す
        /// </summary>
        /// <returns></returns>
        public DateTime IncrementSecond() {
            return IncrementSecond(1);
        }
        public DateTime IncrementSecond(int second) {
            return CurrentDateTime = CurrentDateTime.AddSeconds(second);
        }

        /// <summary>
        /// 期間を越したか？
        /// </summary>
        public bool IsOverPeriod() {
            return CurrentDateTime > EndDateTime;
        }

        /// <summary>
        /// DateOnlyとTimeOnlyを合成してDateTimeにする
        /// </summary>
        /// <param name="dateOnly">日付</param>
        /// <param name="timeOnly">時間</param>
        /// <returns>日付＋時間→DateTime</returns>
        public DateTime GetDateTime(DateOnly dateOnly,TimeOnly timeOnly) {
            return dateOnly.ToDateTime(timeOnly);
        }
    }
}
