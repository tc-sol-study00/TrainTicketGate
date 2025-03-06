namespace TrainTicketGateForms {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            Button Start;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            Hour = new DataGridViewTextBoxColumn();
            Min = new DataGridViewTextBoxColumn();
            Average = new DataGridViewTextBoxColumn();
            Max = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            kaisatsuSu = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            simStartTime = new TextBox();
            serviceEndTime = new TextBox();
            simEndTime = new TextBox();
            label8 = new Label();
            concorseSpend = new TextBox();
            label9 = new Label();
            dataGridView3 = new DataGridView();
            到着時刻 = new DataGridViewTextBoxColumn();
            TrainName = new DataGridViewTextBoxColumn();
            CustomerQty = new DataGridViewTextBoxColumn();
            Start = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // Start
            // 
            Start.Location = new Point(12, 39);
            Start.Name = "Start";
            Start.Size = new Size(75, 23);
            Start.TabIndex = 2;
            Start.Text = "処理開始";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 0;
            label1.Text = "改札口シミュレーション";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Hour, Min, Average, Max });
            dataGridView1.Location = new Point(374, 121);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(409, 450);
            dataGridView1.TabIndex = 3;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // Hour
            // 
            Hour.DataPropertyName = "Hour";
            dataGridViewCellStyle1.Format = "00";
            Hour.DefaultCellStyle = dataGridViewCellStyle1;
            Hour.HeaderText = "時間帯";
            Hour.Name = "Hour";
            // 
            // Min
            // 
            Min.DataPropertyName = "Min";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "F2";
            Min.DefaultCellStyle = dataGridViewCellStyle2;
            Min.HeaderText = "最小";
            Min.Name = "Min";
            // 
            // Average
            // 
            Average.DataPropertyName = "Average";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "F2";
            Average.DefaultCellStyle = dataGridViewCellStyle3;
            Average.HeaderText = "平均";
            Average.Name = "Average";
            // 
            // Max
            // 
            Max.DataPropertyName = "Max";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "F2";
            Max.DefaultCellStyle = dataGridViewCellStyle4;
            Max.HeaderText = "最大";
            Max.Name = "Max";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            dataGridView2.Location = new Point(789, 121);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Size = new Size(412, 450);
            dataGridView2.TabIndex = 4;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Hour";
            dataGridViewCellStyle5.Format = "00";
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewTextBoxColumn1.HeaderText = "時間帯";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "Min";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "F2";
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn2.HeaderText = "最小";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "Average";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "F2";
            dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewTextBoxColumn3.HeaderText = "平均";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "Max";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "F2";
            dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewTextBoxColumn4.HeaderText = "最大";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(374, 103);
            label2.Name = "label2";
            label2.Size = new Size(144, 15);
            label2.TabIndex = 5;
            label2.Text = "時間帯別待ち時間集計(秒)";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(789, 103);
            label3.Name = "label3";
            label3.Size = new Size(168, 15);
            label3.TabIndex = 6;
            label3.Text = "時間帯別待ち行列数集計(人数)";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(627, 42);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 7;
            label4.Text = "改札数";
            label4.Click += label4_Click;
            // 
            // kaisatsuSu
            // 
            kaisatsuSu.Location = new Point(676, 37);
            kaisatsuSu.Name = "kaisatsuSu";
            kaisatsuSu.Size = new Size(32, 23);
            kaisatsuSu.TabIndex = 8;
            kaisatsuSu.TextAlign = HorizontalAlignment.Right;
            kaisatsuSu.TextChanged += kaisatsuSu_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(338, 42);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 9;
            label5.Text = "終電時間";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(338, 14);
            label6.Name = "label6";
            label6.Size = new Size(123, 15);
            label6.TabIndex = 10;
            label6.Text = "シミュレーション開始時間";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(338, 66);
            label7.Name = "label7";
            label7.Size = new Size(123, 15);
            label7.TabIndex = 11;
            label7.Text = "シミュレーション終了時間";
            // 
            // simStartTime
            // 
            simStartTime.Location = new Point(467, 12);
            simStartTime.Name = "simStartTime";
            simStartTime.Size = new Size(100, 23);
            simStartTime.TabIndex = 12;
            simStartTime.TextAlign = HorizontalAlignment.Right;
            // 
            // serviceEndTime
            // 
            serviceEndTime.Location = new Point(467, 37);
            serviceEndTime.Name = "serviceEndTime";
            serviceEndTime.Size = new Size(100, 23);
            serviceEndTime.TabIndex = 12;
            serviceEndTime.TextAlign = HorizontalAlignment.Right;
            // 
            // simEndTime
            // 
            simEndTime.Location = new Point(467, 61);
            simEndTime.Name = "simEndTime";
            simEndTime.Size = new Size(100, 23);
            simEndTime.TabIndex = 12;
            simEndTime.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(573, 15);
            label8.Name = "label8";
            label8.Size = new Size(97, 15);
            label8.TabIndex = 13;
            label8.Text = "コンコース所要時間";
            // 
            // concorseSpend
            // 
            concorseSpend.Location = new Point(676, 10);
            concorseSpend.Name = "concorseSpend";
            concorseSpend.Size = new Size(33, 23);
            concorseSpend.TabIndex = 14;
            concorseSpend.TextAlign = HorizontalAlignment.Right;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 103);
            label9.Name = "label9";
            label9.Size = new Size(85, 15);
            label9.TabIndex = 15;
            label9.Text = "列車スケジュール";
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { 到着時刻, TrainName, CustomerQty });
            dataGridView3.Location = new Point(12, 121);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.Size = new Size(288, 450);
            dataGridView3.TabIndex = 16;
            dataGridView3.CellContentClick += dataGridView3_CellContentClick;
            // 
            // 到着時刻
            // 
            到着時刻.DataPropertyName = "ArivalTime";
            到着時刻.HeaderText = "到着時刻";
            到着時刻.Name = "到着時刻";
            // 
            // TrainName
            // 
            TrainName.DataPropertyName = "TrainName";
            TrainName.HeaderText = "列車名";
            TrainName.Name = "TrainName";
            // 
            // CustomerQty
            // 
            CustomerQty.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            CustomerQty.DataPropertyName = "CustomerQty";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
            CustomerQty.DefaultCellStyle = dataGridViewCellStyle9;
            CustomerQty.HeaderText = "乗客数";
            CustomerQty.Name = "CustomerQty";
            CustomerQty.Width = 68;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 618);
            Controls.Add(dataGridView3);
            Controls.Add(label9);
            Controls.Add(concorseSpend);
            Controls.Add(label8);
            Controls.Add(simEndTime);
            Controls.Add(serviceEndTime);
            Controls.Add(simStartTime);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(kaisatsuSu);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(Start);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label2;
        private Label label3;
        private DataGridViewTextBoxColumn Hour;
        private DataGridViewTextBoxColumn Min;
        private DataGridViewTextBoxColumn Average;
        private DataGridViewTextBoxColumn Max;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private Label label4;
        private TextBox kaisatsuSu;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox simStartTime;
        private TextBox serviceEndTime;
        private TextBox simEndTime;
        private Label label8;
        private TextBox concorseSpend;
        private Label label9;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn 到着時刻;
        private DataGridViewTextBoxColumn TrainName;
        private DataGridViewTextBoxColumn CustomerQty;
    }
}
