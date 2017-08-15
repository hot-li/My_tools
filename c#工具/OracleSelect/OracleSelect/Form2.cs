using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Load += Form2_Load;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            XmlHelper.GetInfos();
            this.OcacleIP.Text = XmlHelper.ServerIP;
            this.UserID.Text = XmlHelper.User;
            this.Passwd.Text = XmlHelper.PWD;
            this.Port.Text = XmlHelper.Port;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //关闭当前窗口
            this.Close();
        }
        //string user;
        //string pwd;
        //string IP;
        //string port;
        //static string connString;
        //OracleConnection conn = new OracleConnection(connString);
        private void button1_Click(object sender, EventArgs e)
        {

            string user = this.UserID.Text.Trim();
            string IP = this.OcacleIP.Text.Trim();
            string pwd = this.Passwd.Text.Trim();
            string port = this.Port.Text.Trim();

            string connString = string.Format("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(METHOD=BASIC)(PORT={3}))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id={1};Password={2}", IP, user, pwd,port);
            OracleConnection conn = new OracleConnection(connString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    this.Close();
                    new System.Threading.Thread(() =>
                    {
                        Application.Run(new Form1());
                    }).Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败！:" + ex.Message.ToString(), "信息提示！");
                //this.UserID.Clear();
                //this.Passwd.Clear();
                //this.OcacleIP.Clear();
                //this.OcacleIP.Focus();//焦点定位到sqlIp
            }
            //Form1.baseDate.loginUser = user;
            //Form1.baseDate.loginPwd = pwd;
            //Form1.baseDate.loginSqlIp = IP;
            Form1.baseDate.Form2Conn = conn;
        }
    }
}
