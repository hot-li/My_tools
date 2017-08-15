using System;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;

namespace 网速测试
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NetworkAdapter[] adapters;
        private NetworkMonitor monitor;
        Thread th = null;
        string str = "实时网速：";
        string var = "网速峰值：";
        int value = 1024, heightvalue = 1000;
        private void Form1_Load(object sender, EventArgs e)
        {
            File.Delete(@"D:\网速测试文件.rar");
            Chartfalse.GridShiftting = false;
            Charttrue.GridShiftting = false;
            statusChart1.GridShiftting = false;
            Chartfalse.Value = 0; Charttrue.Value = 0;
            monitor = new NetworkMonitor();
            this.adapters = monitor.Adapters;
            if (adapters.Length == 0)
            {
                this.ListAdapters.Enabled = false;
                MessageBox.Show("未检测到网卡！.");
                return;
            }
            this.ListAdapters.Items.AddRange(this.adapters);
            ListAdapters.SelectedIndex = 0;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (th != null)
            {
                th.Abort();
            }
            File.Delete(@"D:\网速测试文件.rar");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.ExitThread();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (ListAdapters.SelectedIndex < 0)
            {
                MessageBox.Show("请选择网卡！");
                return;
            }
            Chartfalse.GridShiftting = true;
            Charttrue.GridShiftting = true;
            statusChart1.GridShiftting = true;
            monitor.StopMonitoring();
            monitor.StartMonitoring(adapters[this.ListAdapters.SelectedIndex]);
            this.TimerCounter.Start();
            th = new Thread(new ThreadStart(Download));
            th.IsBackground = true;
            th.Start();
            Chartfalse.Value = 0;
        }
        private void TimerCounter_Tick(object sender, System.EventArgs e)
        {
            NetworkAdapter adapter = this.adapters[this.ListAdapters.SelectedIndex];
            double Down = Convert.ToDouble(String.Format("{0:n}", adapter.DownloadSpeedKbps));
            if (Down > heightvalue)
            {
                heightvalue = (Int32)Down;
                label5.Text = var + (Down / 1024).ToString(".##") + "MB";
            }
            if (Down > value)
            {
                value = (Int32)Down * 3;
                Charttrue.Range = value;
                Chartfalse.Range = (Int32)Down*2;
            }
            if (Down >= 1024.00)
            {
                Chartfalse.Value = Convert.ToInt32(Down);
                Charttrue.Value = Convert.ToInt32(Down);
                Down = Down / 1024;
                this.LableDownloadValue.Text = str + Down.ToString(".##") + "MB";
                return;
            }
            if (Down <= 1.00)
            {
                this.LableDownloadValue.Text = str + Down.ToString("0.##") + "KB";
                Chartfalse.Value = Convert.ToInt32(Down);
                Charttrue.Value = Convert.ToInt32(Down);
                return;
            }
            if (Down < 1024.00 && Down > 1.00)
            {
                this.LableDownloadValue.Text = str + Down.ToString(".##") + "KB";
                Charttrue.Value = Convert.ToInt32(Down);
                Chartfalse.Value = Convert.ToInt32(Down);
                return;
            }
        }
        private void Download()
        {
            string URL = @"http://download.microsoft.com/download/3/6/D/36D2717C-2C51-4FFF-897C-866F0C16D38F/CHS/SQLFULL_CHS.iso";
            WebClient client = new WebClient();
            WebRequest myre = WebRequest.Create(URL);
            try
            {
                client.DownloadFile(URL, @"D:\网速测试文件.rar");
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("中止"))
                {

                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Chartfalse_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void butStop_Click(object sender, EventArgs e)
        {
            Chartfalse.GridShiftting = false;
            Charttrue.GridShiftting = false;
            statusChart1.GridShiftting = false;
            try
            {
                th.Abort();
                MessageBox.Show("停止成功！", "信息提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show("未进行网速测试！","信息提示");
            }
            Chartfalse.Value = 0; Charttrue.Value = 0;
            TimerCounter.Stop();
            LableDownloadValue.Text = str;
            Charttrue.Clear();
            Chartfalse.Clear();
        }
    }
}
