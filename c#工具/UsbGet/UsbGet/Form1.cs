using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsbGet
{
    public partial class Form1 : Form
    {
        Pick pick;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pick = new Pick(panel1.Handle, 0, 0, panel1.Width, panel1.Height);
            pick.Start();
            pictureBox1.ImageLocation = null; //清空pictureBox1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                pick.Stop();
                MessageBox.Show("停止视频预览成功！", "提示");
            }
            catch (NullReferenceException ex) {
                MessageBox.Show("未启用视频预览功能，无需停止！","提示");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("退出本系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string path;
                SaveFileDialog sdf1 = new SaveFileDialog();
                sdf1.Filter = "图片*.bmp;*.jpg;.jpeg;*.gif|*.bmp|所有文件(*.*)|*.*";
                if (sdf1.ShowDialog() == DialogResult.OK)
                {
                    path = sdf1.FileName;
                    pick.GrabImage(path);
                    pictureBox1.ImageLocation = path; //并显示在pictureBox1方框中  
                    pictureBox1.Visible = true;
                    pick.Stop();
                }
            }
            catch {
                MessageBox.Show("未启用视频预览功能，请先启用！", "提示");
            }         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string videopath;
            SaveFileDialog sdf2 = new SaveFileDialog();
            sdf2.Filter = "视频*;*.mp4;.mkv;.avi;.rmvb|*.avi|所有文件(*.*)|*.*";
            if (sdf2.ShowDialog() == DialogResult.OK)
            {
                videopath = sdf2.FileName;
                pick.Kinescope(videopath);
                MessageBox.Show("开始录像！", "提示");
                //pictureBox1.ImageLocation = "正在录像"; //并显示在pictureBox1方框中  
                //pictureBox1.Visible = true;
                //pick.StopKinescope();
                }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                pick.StopKinescope();
                MessageBox.Show("停止录像成功！", "提示");
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("未进行录像操作，无需停止！", "提示");
            }
        }
    }
}




