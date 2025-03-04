namespace TrainTicketGate.Services {
    internal static class Config {
        /// <summary>
        /// 期間定義データ
        /// </summary>
        public static class ServicePeriod {
            public static readonly TimeOnly StartTimeOnly = new TimeOnly(8, 0);         //シミュレーション開始・始電時間
            public static readonly TimeOnly ServiceEndTimeOnly = new TimeOnly(22, 0);   //終電時間
            public static readonly TimeOnly EndTimeOnly = new TimeOnly(23, 59);         //シミュレーション終了時間
        }

        /// <summary>
        /// 大人・子人区分
        /// </summary>
        public enum EnumAdultChildClassification {
            Adult,
            Child
        }

        /// <summary>
        /// 大人・子人毎の改札通過時間
        /// </summary>
        public static IDictionary<EnumAdultChildClassification, int> TimeByCustomerType { get; }
            = new Dictionary<EnumAdultChildClassification, int>
                {
                    { EnumAdultChildClassification.Adult, 2 },
                    { EnumAdultChildClassification.Child, 5 }
                };

        /// <summary>
        /// 乗客オペレーション関連定義
        /// </summary>
        public static class CustomerDefine {

            /// <summary>
            /// １列車で乗車する乗客人数（８００～１２００人）
            /// </summary>
            public static class CustomerNumberONaTrain {
                public const int MinNumber = 800;
                public const int MaxNumber = 1200;
            }
            /// <summary>
            /// /大人・小人構成比　大人８０％
            /// </summary>
            public const double AdultRatio = 80.0;
        }
        /// <summary>
        /// コンコース関連初期値
        /// </summary>
        public static class ConcourseDefine {
            public const string ConcourseName = "中央コンコース";
            public const int ConcourseSpendSecond = 300;            //コンコース所要時間（秒）
        }

        /// <summary>
        /// 改札口構成
        /// </summary>
        public static readonly IReadOnlyList<TicketGate> TicketGates = new List<TicketGate>() {
            new TicketGate("1番ゲート"),
            new TicketGate("2番ゲート"),
            new TicketGate("3番ゲート"),
            new TicketGate("4番ゲート"),
            new TicketGate("5番ゲート"),
            new TicketGate("6番ゲート"),
            new TicketGate("7番ゲート"),
            new TicketGate("8番ゲート"),
            new TicketGate("1番ゲート"),
            new TicketGate("2番ゲート"),
            new TicketGate("3番ゲート"),
            new TicketGate("4番ゲート"),
            new TicketGate("5番ゲート"),
            new TicketGate("6番ゲート"),
            new TicketGate("7番ゲート"),
            new TicketGate("8番ゲート"),
        }.AsReadOnly();
    }
}