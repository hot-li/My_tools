using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.selectString.Clear();
        }
        public class baseDate
        {
            //创建公共变量
            //public static string loginUser { get; set; }
            //public static string loginPwd { get; set; }
            //public static string loginSqlIp { get; set; }

            //获取form2的oracle连接
            public static OracleConnection Form2Conn { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = "select";
            bool contains = this.selectString.Text.Trim().IndexOf(str1, StringComparison.OrdinalIgnoreCase) >= 0;
            //bool flag1 = this.selectString.Text.Trim().Contains(str1);
            if (contains==true)
            {
                this.label3.Text = "查询中，请稍候";
                writeFile(this.selectString.Text.Trim());//写入sql到文件
                OracleCommand cmd = baseDate.Form2Conn.CreateCommand();
                cmd.CommandText = this.selectString.Text.Trim();
                try
                { 
                    OracleDataAdapter AdapterSelect = new OracleDataAdapter(this.selectString.Text.Trim(), baseDate.Form2Conn);
                    DataTable dt = new DataTable();
                    AdapterSelect.Fill(dt);
                    dataGridView1.DataSource = dt.DefaultView;
                    this.label3.Text = "查询成功";
                }
                catch (Exception ex)
                {
                    this.label3.Text = "查询失败";
                    MessageBox.Show("查询失败：" + ex.Message, "信息提示！");                    
                }
                finally
                {
                    baseDate.Form2Conn.Close();
                }
            }
            else
            {
                MessageBox.Show("只支持select查询操作！","信息提示！");
            }   
        }

        public void writeFile(string content)
        {
            try
            {
                string str = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo d = Directory.CreateDirectory(str);
                //string newPath = Path.Combine(activeDir, "mySubDirOne");//表示再建一层mySubDirOne目录
                DateTime dt = DateTime.Now;
                string FILE_NAME = string.Format(str + "\\"  + "Input_sql.txt");

                string msg = DateTime.Now.ToString()+"----"+content + "\r\n";
                byte[] myByte = Encoding.UTF8.GetBytes(msg);
                using (FileStream fsWrite = new FileStream(FILE_NAME, FileMode.Append))
                {
                    fsWrite.Write(myByte, 0, myByte.Length);
                    //Console.WriteLine(content);
                    fsWrite.Close();
                    fsWrite.Dispose();
                };
            }
            catch (Exception e)
            {
                String message = e.Message;
                MessageBox.Show("写入SQL到文件失败" ,"信息提示！");
            }
        }
    }
}
