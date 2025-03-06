using System.Windows.Forms;
using TrainTicketGate.Services;

namespace TrainTicketGateForms {
    public partial class Form1 : Form {
        private readonly RailwayCompany _railCompany;

        public Form1() {
            InitializeComponent();
            _railCompany = new RailwayCompany();
        }

        private void Form1_Load(object sender, EventArgs e) {
            kaisatsuSu.Text = Config.TicketGates.Count.ToString();
            simStartTime.Text = Config.ServicePeriod.StartTimeOnly.ToString();
            serviceEndTime.Text = Config.ServicePeriod.ServiceEndTimeOnly.ToString();
            simEndTime.Text = Config.ServicePeriod.EndTimeOnly.ToString();
            concorseSpend.Text = Config.ConcourseDefine.ConcourseSpendSecond.ToString();
        }

        private void Start_Click(object sender, EventArgs e) {
            _railCompany.RailwayCompanyOperations();

            SetTrainOperationsData();
            SetCustomerWaitTimeData();
            SetQueueSummaryData();
        }

        /// <summary>
        /// 列車運行データをDataGridViewに設定
        /// </summary>
        private void SetTrainOperationsData() {
            InitializeDataGridView(dataGridView3);
            dataGridView3.DataSource = _railCompany._trainOperation.TimeTables
                .Select(x => new {
                    ArivalTime = x.ArivalTime.ToString(),
                    x.TrainName,
                    CustomerQty = _railCompany.CustomerQty[x.TrainName].ToString()
                })
                .ToList();
        }

        /// <summary>
        /// 改札通過待ち時間の集計データをDataGridViewに設定
        /// </summary>
        private void SetCustomerWaitTimeData() {
            InitializeDataGridView(dataGridView1);
            var summarizedList = _railCompany.SummarizeCustomerWaitTime().ToList();
            dataGridView1.DataSource = summarizedList;
        }

        /// <summary>
        /// 改札通過キューの集計データをDataGridViewに設定
        /// </summary>
        private void SetQueueSummaryData() {
            InitializeDataGridView(dataGridView2);
            var queueSummary = _railCompany.SummarizePutOutCustomer().ToList();
            dataGridView2.DataSource = queueSummary;
        }

        /// <summary>
        /// DataGridViewの初期設定
        /// </summary>
        /// <param name="gridView">対象のDataGridView</param>
        private void InitializeDataGridView(DataGridView gridView) {
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // 偶数行の背景色
            gridView.AutoGenerateColumns = false;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridView.DataSource = null;
            gridView.Rows.Clear();
        }
    }
}
