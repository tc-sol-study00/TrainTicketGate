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

        private void label1_Click(object sender, EventArgs e) {

        }

        private void Start_Click(object sender, EventArgs e) {
            _railCompany.RailwayCompanyOperations();

            dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // ãÙêîçsÇÃîwåiêF
            dataGridView1.AutoGenerateColumns = false;
            dataGridView3.DataSource = _railCompany._trainOperation.TimeTables
                .Select(x => new { ArivalTime = x.ArivalTime.ToString(),x.TrainName, CustomerQty=_railCompany.CustomerQty[x.TrainName].ToString() })
                .ToList();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            var summarizedList = _railCompany._stationOperation._ticketGateOperation.PutOutCustomers.GroupBy(x => x.DateTimeGetTicketGateArea.Hour)
               .Select(g => new { Hour = g.Key, Min = g.Min(x => x.WaitSeconds), Average = g.Average(x => x.WaitSeconds), Max = g.Max(x => x.WaitSeconds) })
               .ToList();

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // ãÙêîçsÇÃîwåiêF

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = summarizedList;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            var queueSummary = _railCompany._stationOperation._ticketGateOperation.WaitQueueBySecondsTimes.GroupBy(x => x.ActualDatetime.Hour)
                .Select(g => new { Hour = g.Key, Min = g.Min(x => x.CustomerNumber), Average = g.Average(x => x.CustomerNumber), Max = g.Max(x => x.CustomerNumber) })
                .ToList();

            dataGridView2.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // ãÙêîçsÇÃîwåiêF

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = queueSummary;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void label4_Click(object sender, EventArgs e) {

        }

        private void kaisatsuSu_TextChanged(object sender, EventArgs e) {

        }

        private void label6_Click(object sender, EventArgs e) {

        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }
    }
}
