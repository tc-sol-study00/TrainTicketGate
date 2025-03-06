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
        /// ��ԉ^�s�f�[�^��DataGridView�ɐݒ�
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
        /// ���D�ʉߑ҂����Ԃ̏W�v�f�[�^��DataGridView�ɐݒ�
        /// </summary>
        private void SetCustomerWaitTimeData() {
            InitializeDataGridView(dataGridView1);
            var summarizedList = _railCompany.SummarizeCustomerWaitTime().ToList();
            dataGridView1.DataSource = summarizedList;
        }

        /// <summary>
        /// ���D�ʉ߃L���[�̏W�v�f�[�^��DataGridView�ɐݒ�
        /// </summary>
        private void SetQueueSummaryData() {
            InitializeDataGridView(dataGridView2);
            var queueSummary = _railCompany.SummarizePutOutCustomer().ToList();
            dataGridView2.DataSource = queueSummary;
        }

        /// <summary>
        /// DataGridView�̏����ݒ�
        /// </summary>
        /// <param name="gridView">�Ώۂ�DataGridView</param>
        private void InitializeDataGridView(DataGridView gridView) {
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // �����s�̔w�i�F
            gridView.AutoGenerateColumns = false;
            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridView.DataSource = null;
            gridView.Rows.Clear();
        }
    }
}
