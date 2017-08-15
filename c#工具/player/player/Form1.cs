using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = file;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        string file;
        private void button2_Click(object sender, EventArgs e)
        {
            //int size = -1;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
                try
                {
                    //string text = File.ReadAllText(file);
                    this.label1.Text = file;
                    //size = text.Length;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
