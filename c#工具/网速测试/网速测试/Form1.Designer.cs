namespace 网速测试
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.LableDownloadValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ListAdapters = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Chartfalse = new UI.StatusChart();
            this.Charttrue = new UI.StatusChart();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.statusChart1 = new UI.StatusChart();
            this.TimerCounter = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.butStop = new System.Windows.Forms.Button();
            this.statusChart2 = new UI.StatusChart();
            this.groupbox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupbox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Green;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(89, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 8);
            this.label4.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "需求网速：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "退  出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LableDownloadValue
            // 
            this.LableDownloadValue.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LableDownloadValue.ForeColor = System.Drawing.Color.Black;
            this.LableDownloadValue.Location = new System.Drawing.Point(151, 50);
            this.LableDownloadValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LableDownloadValue.Name = "LableDownloadValue";
            this.LableDownloadValue.Size = new System.Drawing.Size(140, 20);
            this.LableDownloadValue.TabIndex = 1;
            this.LableDownloadValue.Text = "实时网速：";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Blue;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(89, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 8);
            this.label2.TabIndex = 7;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ListAdapters
            // 
            this.ListAdapters.FormattingEnabled = true;
            this.ListAdapters.ItemHeight = 12;
            this.ListAdapters.Location = new System.Drawing.Point(15, 19);
            this.ListAdapters.Margin = new System.Windows.Forms.Padding(2);
            this.ListAdapters.Name = "ListAdapters";
            this.ListAdapters.Size = new System.Drawing.Size(199, 52);
            this.ListAdapters.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "当前网速：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.Chartfalse);
            this.groupBox1.Controls.Add(this.Charttrue);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.LableDownloadValue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.statusChart1);
            this.groupBox1.Location = new System.Drawing.Point(9, 112);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(443, 326);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "流量监控：";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(16, 309);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 13);
            this.panel1.TabIndex = 11;
            // 
            // Chartfalse
            // 
            this.Chartfalse.BackColor = System.Drawing.Color.AliceBlue;
            this.Chartfalse.Enabled = false;
            this.Chartfalse.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Chartfalse.ForeColor = System.Drawing.Color.Green;
            this.Chartfalse.GridColor = System.Drawing.Color.Silver;
            this.Chartfalse.GridHeight = 15;
            this.Chartfalse.GridWidth = 15;
            this.Chartfalse.Interval = 200;
            this.Chartfalse.Location = new System.Drawing.Point(16, 82);
            this.Chartfalse.Mode = UI.StatusChart.ChartMode.Waveform;
            this.Chartfalse.Name = "Chartfalse";
            this.Chartfalse.Range = 5000;
            this.Chartfalse.Size = new System.Drawing.Size(415, 61);
            this.Chartfalse.TabIndex = 9;
            this.Chartfalse.Load += new System.EventHandler(this.Chartfalse_Load);
            // 
            // Charttrue
            // 
            this.Charttrue.BackColor = System.Drawing.Color.AliceBlue;
            this.Charttrue.Enabled = false;
            this.Charttrue.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Charttrue.ForeColor = System.Drawing.Color.Blue;
            this.Charttrue.GridColor = System.Drawing.Color.Silver;
            this.Charttrue.GridHeight = 15;
            this.Charttrue.GridWidth = 15;
            this.Charttrue.Interval = 200;
            this.Charttrue.Location = new System.Drawing.Point(16, 131);
            this.Charttrue.Mode = UI.StatusChart.ChartMode.Waveform;
            this.Charttrue.Name = "Charttrue";
            this.Charttrue.Range = 5000;
            this.Charttrue.Size = new System.Drawing.Size(415, 95);
            this.Charttrue.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(291, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "GPS丢包率：43.2%";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(291, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "GPS终端数：300";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(151, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "网速峰值：";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // statusChart1
            // 
            this.statusChart1.BackColor = System.Drawing.Color.AliceBlue;
            this.statusChart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusChart1.Enabled = false;
            this.statusChart1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusChart1.ForeColor = System.Drawing.Color.Blue;
            this.statusChart1.GridColor = System.Drawing.Color.Silver;
            this.statusChart1.GridHeight = 15;
            this.statusChart1.GridWidth = 15;
            this.statusChart1.Interval = 200;
            this.statusChart1.Location = new System.Drawing.Point(16, 213);
            this.statusChart1.Mode = UI.StatusChart.ChartMode.Waveform;
            this.statusChart1.Name = "statusChart1";
            this.statusChart1.Range = 5000;
            this.statusChart1.Size = new System.Drawing.Size(415, 95);
            this.statusChart1.TabIndex = 11;
            // 
            // TimerCounter
            // 
            this.TimerCounter.Interval = 1000;
            this.TimerCounter.Tick += new System.EventHandler(this.TimerCounter_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(218, 27);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 30);
            this.button2.TabIndex = 9;
            this.button2.Text = "GPS通信测试";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.ListAdapters);
            this.groupBox2.Controls.Add(this.butStop);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(9, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(443, 80);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择网卡：";
            // 
            // butStop
            // 
            this.butStop.Location = new System.Drawing.Point(310, 27);
            this.butStop.Margin = new System.Windows.Forms.Padding(2);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(56, 30);
            this.butStop.TabIndex = 9;
            this.butStop.Text = "停  止";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // statusChart2
            // 
            this.statusChart2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statusChart2.Enabled = false;
            this.statusChart2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusChart2.ForeColor = System.Drawing.Color.Red;
            this.statusChart2.GridColor = System.Drawing.Color.Silver;
            this.statusChart2.GridHeight = 15;
            this.statusChart2.GridWidth = 15;
            this.statusChart2.Interval = 200;
            this.statusChart2.Location = new System.Drawing.Point(12, 31);
            this.statusChart2.Mode = UI.StatusChart.ChartMode.Waveform;
            this.statusChart2.Name = "statusChart2";
            this.statusChart2.Range = 5000;
            this.statusChart2.Size = new System.Drawing.Size(416, 122);
            this.statusChart2.TabIndex = 11;
            // 
            // groupbox3
            // 
            this.groupbox3.Controls.Add(this.statusChart2);
            this.groupbox3.Location = new System.Drawing.Point(9, 477);
            this.groupbox3.Name = "groupbox3";
            this.groupbox3.Size = new System.Drawing.Size(443, 178);
            this.groupbox3.TabIndex = 12;
            this.groupbox3.TabStop = false;
            this.groupbox3.Text = "其他监控：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 702);
            this.Controls.Add(this.groupbox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据传输测试";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupbox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LableDownloadValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ListAdapters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer TimerCounter;
        private UI.StatusChart Charttrue;
        private UI.StatusChart Chartfalse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button butStop;
        private UI.StatusChart statusChart1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private UI.StatusChart statusChart2;
        private System.Windows.Forms.GroupBox groupbox3;
    }
}

