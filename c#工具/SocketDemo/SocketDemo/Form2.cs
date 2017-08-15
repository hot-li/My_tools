using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketDemo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private Socket s;                              //定义Socket对象
        private Thread th;                             //客户端连接服务器的线程
        public Socket cSocket;                         //单个客户端连接的Socket对象
        public NetworkStream ns;                       //网络流
        public StreamReader sr;                        //流读取
        public StreamWriter sw;                        //流写入
        private delegate void SetTextCallback();       //用于操作主线程控件
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//创建Socket对象
            IPAddress serverIP = IPAddress.Parse("127.0.0.1");
            IPEndPoint server = new IPEndPoint(serverIP, 13);    //实例化服务器的IP和端口
            s.Bind(server);
            s.Listen(10);
            try
            {
                th = new Thread(new ThreadStart(Communication));     //创建线程
                th.Start();                                                //启动线程
                label1.Text = "服务器启动成功！";
                new Thread(() =>
                {
                    Application.Run(new Form1());
                }).Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务器启动失败！" + ex.Message);
            }

        }
        public void Communication()
        {
            while (true)
            {
                try
                {
                    cSocket = s.Accept();                   //用cSocket来代表该客户端连接
                    if (cSocket.Connected)                  //测试是否连接成功
                    {
                        ns = new NetworkStream(cSocket);  //建立网络流，便于数据的读取
                        sr = new StreamReader(ns);         //实例化流读取对象
                        sw = new StreamWriter(ns);         //实例化写入流对象
                        test();                               //从流中读取
                        sw.WriteLine("收到请求，允许连接"); //向流中写入数据
                        sw.Flush();                           //清理缓冲区
                    }
                    else
                    {
                        MessageBox.Show("连接失败");
                    }
                }
                catch (SocketException ex)
                {
                    MessageBox.Show(ex.Message);           //捕获Socket异常
                }
                catch (Exception es)
                {
                    MessageBox.Show("其他异常" + es.Message);      //捕获其他异常
                }
            }
        }
        public void send()
        {
            lbInfo.Items.Add(sr.ReadLine() + "\n");
        }
        public void test()
        {
            SetTextCallback stcb = new SetTextCallback(send);
            Invoke(stcb);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    try
        //    {
        //        if (disposing && (components != null))
        //        {
        //            components.Dispose();
        //            th.Abort();
        //            //禁用当前Socket连接中的数据收发
        //            s.Shutdown(System.Net.Sockets.SocketShutdown.Both);
        //            s.Close();
        //        }
        //        base.Dispose(disposing);
        //    }
        //    catch
        //    {
        //        return;
        //    }
        //}
        //接着为当前窗体的FormClosed事件添加如下代码。
        //this.Close();
    }
}
