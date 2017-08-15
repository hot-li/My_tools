using Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodsSendDemo
{
    public partial class YQHLogin : Form
    {
        public YQHLogin()
        {
            InitializeComponent();
            Load += Form2_Load;
        }
        public static CookieContainer container = null; //存储验证码cookie

        //密码读取xml
        private void Form2_Load(object sender, EventArgs e)
        {

            XmlHelper.GetInfos();
            this.username.Text = XmlHelper.User;
            this.pwd.Text = XmlHelper.PWD;
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            
            string postData = string.Format("username={0}&password={1}&remember=1&from=http%3A%2F%2Fwww.178hui.com%2F&sub=1", this.username.Text, this.pwd.Text);
            string postUrl = "http://www.178hui.com/login.html";
            //string urlPostData = System.Web.HttpUtility.UrlEncode(s);
            string content = LoginHelper.Login(postUrl, postData, postUrl);

            int index = content.IndexOf("错误");
            if (index > -1)
            {
                string failMess = string.Format("登录失败:{0}", content);
                MessageBox.Show(failMess, "提示");
            }
            else
            {
                string successMess = string.Format("登录成功:{0}", content);
                MessageBox.Show(successMess, "提示");
            }
            string content2 = LoginHelper.getPage("http://www.178hui.com/", "http://www.178hui.com/login.html");
            this.Close();           
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
