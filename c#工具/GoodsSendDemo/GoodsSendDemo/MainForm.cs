using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Helper;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace GoodsSendDemo
{
    public partial class MainForm : Form
    {
        //YQH公共变量
        public decimal qyh_bl_cc_price = 0;//原价
        public decimal qyh_bl_cc_oprice = 0;//优惠价
        public string qyh_bl_cc_url = "";//爆料网页链接，用于获取爆料所属分类信息
        public string qyh_bl_cc_zhida = "";//直达连接
        public string qyh_bl_cc_title = "";//标题
        public string qyh_bl_cc_fenlei = "";//分类信息
        public string qyh_bl_cc_img = "";//分类信息
        public string qyh_bl_cc_true_url = "";//真实商城连接

        public string qyh_bl_lb_url = "";//爆料网页链接，用于获取爆料所属分类信息
        public string qyh_bl_lb_zhida = "";//直达连接
        public string qyh_bl_lb_info = "";//描述

        //ZDM公共变量
        public string zdm_url = "";
        public string zdm_title = "";
        public string zdm_image = "";
        public decimal zdm_price = 0;//价格
        public string zdm_price_str = "";
        public string zdm_descripe = "";
        public string zdm_zhida = "";
        public string zdm_zhida_shangcheng = "";
        public string img_save_path = "";
        public string zdm_fenlei = "";

        public string basepath = AppDomain.CurrentDomain.BaseDirectory;//进程地址
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// YQH登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            YQHLogin LoginForm = new YQHLogin();
            LoginForm.Show(this);
        }
        /// <summary>
        /// ZDM登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ZDMLogin LoginForm = new ZDMLogin();
            LoginForm.Show(this);
        }

        /// <summary>
        /// YQH商品列表获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            //连接mysql
            MySqlConnection mysqlConn = getMySqlCon();
            //获取页数
            int YQHNum = int.Parse(this.YQHNum.Text);
            if (YQHNum == 0) { MessageBox.Show("”获取页数“ 请输入大于0的数字！", "提示"); }
            else
            {
                for (int i = 1; i < YQHNum+1; i++)
                {
                    //获取到商品信息写入xml文件
                    string url = string.Format("http://www.178hui.com/zdm/list/0-0-0-0-{0}.html", i);
                    //string url2 = "http://www.178hui.com/zdm/view-684087.html";
                    string getContent = LoginHelper.HttpGet(url);
                    string yuanshiHtml = LogHelper.writeFile(getContent, "一起惠返利.html");
                    string[] good_bl_i_cc = HtmlHelper.GetElementsByTagAndClass(getContent, "div", "bl_i_cc");
                    string[] good_bl_i_lb = HtmlHelper.GetElementsByTagAndClass(getContent, "div", "bl_i_lb");
                    //轮询获取bl_i_cc标签信息
                    foreach (string x in good_bl_i_cc)
                    {
                        //LogHelper.writeFile(x, "所有bl_i_cc标签内容.txt");
                        string[] tag_id = HtmlHelper.GetElementsByTagName(x, "li");
                        foreach (string y in tag_id)
                        {
                            //LogHelper.writeFile(y, "所有li标签内容.txt");
                            string[] bl_cc_title = HtmlHelper.GetElementsByTagAndClass(y, "div", "bl_cc_title");//获取bl_cc_title列表
                            string[] bl_cc_zhida = HtmlHelper.GetElementsByTagAndClass(y, "div", "bl_cc_zhida");//获取bl_cc_zhida列表
                            string[] bl_cc_price = HtmlHelper.GetElementsByClass(y, "bl_cc_price");//获取bl_cc_price列表
                            string[] bl_cc_oprice = HtmlHelper.GetElementsByClass(y, "bl_cc_oprice");//获取bl_cc_oprice列表
                            //获取原始网址+标题
                            foreach (string a in bl_cc_title)
                            {
                                string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";//匹配原始网址
                                qyh_bl_cc_url = ReHelper.reMatch(a, pattern);
                                qyh_bl_cc_title = HtmlHelper.DelHTML(a);//删除标签，获取文本

                                //获取分类信息
                                string url2 = qyh_bl_cc_url;
                                string getContent2 = LoginHelper.HttpGet(url2);
                                string[] bl_v_lable = HtmlHelper.GetElementsByTagAndClass(getContent2, "div", "bl_v_lable");
                                foreach (string bl_v_x in bl_v_lable)
                                {
                                    string[] bl_v_y = HtmlHelper.GetElementsByTagName(bl_v_x, "dd");
                                    string bl_v_z = bl_v_y[1];
                                    qyh_bl_cc_fenlei = HtmlHelper.DelHTML(bl_v_z);
                                }

                                //获取真实商城连接
                                string trueUrlContent = LoginHelper.HttpGet(qyh_bl_cc_url);
                                string urlpatten= "(?<=<script\\s*type=\"text\\/javascript\">)[^<]*(?=<\\/script>)";
                                Match stcro = Regex.Match(trueUrlContent, urlpatten);
                                string result1 = stcro.Groups[0].Value.ToString();//获取第一个匹配字符串
                                //匹配bl_url
                                string urlpatten2 = @"bl_url : '\bhttp\S*\b'";
                                string  content3=ReHelper.reMatch(result1, urlpatten2);
                                //匹配真实网址
                                string urlpatten3 = @"\bhttp\S*\b";
                                qyh_bl_cc_true_url = ReHelper.reMatch(content3, urlpatten3);
                                //qyh_bl_cc_true_url

                            }
                            //获取直达连接
                            foreach (string b in bl_cc_zhida)
                            {
                                string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";//匹配直达网址
                                qyh_bl_cc_zhida = ReHelper.reMatch(b, pattern);
                            }
                            //获取优惠价格
                            foreach (string z in bl_cc_price)
                            {
                                string pattern = @"\b\d\S*\d\d\b"; ;//匹配price
                                string cc_price = ReHelper.reMatch(z, pattern);
                                qyh_bl_cc_price = decimal.Parse(cc_price);
                            }
                            //获取原始价格
                            foreach (string w in bl_cc_oprice)
                            {
                                string pattern = @"\b\d\S*\d\d\b"; ;//匹配oprice
                                string cc_oprice = ReHelper.reMatch(w, pattern);
                                qyh_bl_cc_oprice = decimal.Parse(cc_oprice);
                            }
                            
                            string mysqlStr = string.Format("insert into yqh_goods_yuanshi (cc_url,cc_price,cc_oprice,cc_zhida,cc_title,cc_fenlei,cc_true_url) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", qyh_bl_cc_url, qyh_bl_cc_price, qyh_bl_cc_oprice, qyh_bl_cc_zhida, qyh_bl_cc_title,qyh_bl_cc_fenlei.Replace("分类：", ""),qyh_bl_cc_true_url);
                            getInsert(mysqlStr, mysqlConn);

                        }
                    }

                    //获取描述信息
                    foreach (string x_lb in good_bl_i_lb)
                    {
                        //LogHelper.writeFile(x, "所有bl_i_cc标签内容.txt");
                        string[] tag_id = HtmlHelper.GetElementsByTagName(x_lb, "li");
                        foreach (string y_lb in tag_id)
                        {
                            //LogHelper.writeFile(y, "所有li标签内容.txt");
                            string[] bl_lb_title = HtmlHelper.GetElementsByTagAndClass(y_lb, "div", "bl_lb_title");//获取bl_cc_title列表
                            string[] bl_lb_zhida = HtmlHelper.GetElementsByTagAndClass(y_lb, "div", "bl_lb_zhida");//获取bl_cc_zhida列表
                            string[] bl_lb_info = HtmlHelper.GetElementsByTagAndClass(y_lb, "div", "bl_lb_info");//获取bl_lb_info列表
                            string[] bl_lb_img = HtmlHelper.GetElementsByTagAndClass(y_lb, "div", "bl_lb_img");//获取图片
                            foreach (string bl_a in bl_lb_title)
                            {
                                string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";//匹配原始网址
                                qyh_bl_lb_url = ReHelper.reMatch(bl_a, pattern);
                            }
                            foreach (string bl_b in bl_lb_zhida)
                            {
                                string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";//匹配直达网址
                                qyh_bl_lb_zhida = ReHelper.reMatch(bl_b, pattern);
                            }
                            foreach (string bl_z in bl_lb_info)
                            {
                                qyh_bl_lb_info = HtmlHelper.DelHTML(bl_z);//删除标签，获取文本
                                
                            }

                            //图片另存为
                            foreach (string lb_x in bl_lb_img)
                            {
                                string pattern = @"\bhttp\S*jpg\b";
                                string zdm_img = ReHelper.reMatch(lb_x, pattern);
                                string img_path = Guid.NewGuid().ToString();//生成随机的图片名
                                qyh_bl_cc_img = Path.Combine(basepath, "Picture", "一起惠", img_path + ".jpg");
                                try
                                {
                                    DownloadHelper.DownloadPicture(zdm_img, qyh_bl_cc_img, 2000);//图片另存为
                                }
                                catch { }
                                }
                            string mysqlStr = string.Format("update yqh_goods_yuanshi set cc_info='{0}',cc_img_path='{1}' where cc_url='{2}' and cc_zhida='{3}'", qyh_bl_lb_info,qyh_bl_cc_img.Replace("\\", "\\\\"), qyh_bl_lb_url, qyh_bl_lb_zhida);
                            getInsert(mysqlStr, mysqlConn);
                        }
                    }
                }
                mysqlConn.Close();
                MessageBox.Show("一起惠商品获取完成！", "提示");
            }
        }
        /// <summary>
        /// 值得买商品获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click_1(object sender, EventArgs e)
        {
            //连接mysql
            MySqlConnection mysqlConn = getMySqlCon();
            int ZMDNum = int.Parse(this.ZDMNum.Text);
            if (ZMDNum == 0) { MessageBox.Show("”获取页数“ 请输入大于0的数字！", "提示"); }
            else
            {
                //获取到商品信息写入xml文件
                for (int i = 1; i < ZMDNum + 1; i++)
                {
                    string url = string.Format("http://faxian.smzdm.com/p{0}/#filter-block", i);
                    string getContent = LoginHelper.HttpGet(url);
                    try
                    {
                        string yuanshiHtml = LogHelper.writeFile(getContent, "什么值得买.html");
                        string[] feed_block_ver = HtmlHelper.GetElementsByTagAndClass(getContent, "div", "feed-block-ver ");//获取值得买商品列表

                        //轮询获取feed_hot_card标签信息
                        foreach (string x in feed_block_ver)
                        {
                            //LogHelper.writeFile(x, "所有feed_block_ver标签内容.txt");
                            string[] feed_ver_title = HtmlHelper.GetElementsByTagAndClass(x, "h5", "feed-ver-title");//获取网址标题列表
                            string[] feed_ver_price = HtmlHelper.GetElementsByTagAndClass(x, "div", "z-highlight z-ellipsis");//获取价格列表
                            string[] zdm_ver_descripe = HtmlHelper.GetElementsByTagAndClass(x, "div", "feed-ver-descripe");//获取商品描述列表
                            string[] zdm_ver_zhida = HtmlHelper.GetElementsByTagAndClass(x, "div", "feed-link-btn-inner");//获取原始网址列表
                            string[] zdm_ver_image = HtmlHelper.GetElementsByTagAndClass(x, "div", "feed-ver-pic");//获取图片网址列表

                            //获取url+标题
                            foreach (string feed_a in feed_ver_title)
                            {
                                string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
                                zdm_url = ReHelper.reMatch(feed_a, pattern);
                                zdm_title = HtmlHelper.DelHTML(feed_a);

                                //获取分类
                                string url3 = zdm_url;
                                string getContent3 = LoginHelper.HttpGet(url3);
                                string[] fenlei = HtmlHelper.GetElementsByTagAndClass(getContent3, "div", "crumbs");
                                foreach (string zdm_v_x in fenlei)
                                {
                                    zdm_fenlei = HtmlHelper.DelHTML(zdm_v_x);
                                }




                            }
                            //获取价格
                            foreach (string feed_z in feed_ver_price)
                            {
                                zdm_price_str = HtmlHelper.DelHTML(feed_z);//去除html标签

                                string regex = @"[0-9][0-9,.]*";
                                Match mstr = Regex.Match(zdm_price_str, regex);//正则匹配数字
                                string result = mstr.Groups[0].Value.ToString();//获取第一个匹配字符串
                                zdm_price = decimal.Parse(result);
                            }
                            //获取描述
                            foreach (string feed_w in zdm_ver_descripe)
                            {
                                zdm_descripe = HtmlHelper.DelHTML(feed_w);//描述
                            }
                            //获取直达网址
                            foreach (string feed_b in zdm_ver_zhida)
                            {
                                string pattern = @"https://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";//匹配原始网址
                                string pattern2 = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";//匹配商城连接
                                zdm_zhida = ReHelper.reMatch(feed_b, pattern);
                                //zdm_zhida_shangcheng = ReHelper.reMatch(feed_b, pattern2);//商城直达网址
                            }
                            //图片地址
                            foreach (string feed_c in zdm_ver_image)
                            {
                                string pattern = @"\bhttp\S*jpg\b";
                                string zdm_img = ReHelper.reMatch(feed_c, pattern);
                                string img_path = Guid.NewGuid().ToString();//生成随机的图片名
                                img_save_path = Path.Combine(basepath, "Picture", "值得买", img_path + ".jpg");

                                DownloadHelper.DownloadPicture(zdm_img, img_save_path, 2000);//图片另存为
                            }

                            string mysqlStr = string.Format("insert into zdm_goods_yuanshi (zdm_url,zdm_title,zdm_price,zdm_descripe,zdm_zhida,zdm_price_str,zdm_image,zdm_fenlei) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", zdm_url, @zdm_title, zdm_price, zdm_descripe, zdm_zhida,  zdm_price_str, img_save_path.Replace("\\", "\\\\"), zdm_fenlei.Replace(">文章详情", "").Replace("当前位置：首页>", ""));//转义"\\"
                            getInsert(mysqlStr, mysqlConn);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                mysqlConn.Close();
                MessageBox.Show("值得买商品信息提取完成！", "信息");
            }
        }

        /// <summary>
        /// 建立mysql数据库连接
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection getMySqlCon()
        {
            String mysqlStr = "server=localhost;user id=root;database=goodstore;password=root;CharSet=utf8;pooling=true;Port=3306";
            //String mySqlCon = ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString;
            MySqlConnection mysql = new MySqlConnection(mysqlStr);
            try
            {
                mysql.Open();//连接数据库 
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败"+ex.Message);
            }
            return mysql;
        }
        /// <summary>
        /// 查询并获得结果集并遍历
        /// </summary>
        /// <param name="mySqlCommand"></param>
        /// <param name="mysqlResultTxt"></param>//示例："编号:" + reader.GetInt32(0) + "|姓名:" + reader.GetString(1) + "|年龄:" + reader.GetInt32(2) + "|学历:" + reader.GetString(3)
        public static void getResultset(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            try
            {
                mySqlCommand.ExecuteNonQuery();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine("编号:" + reader.GetInt32(0) + "|姓名:" + reader.GetString(1) + "|年龄:" + reader.GetInt32(2) + "|学历:" + reader.GetString(3));
                    }
                }
            }
            catch (Exception ex)
            {
                //string message = ex.Message;
                //Console.WriteLine("数据查询失败：" + message);
                //Console.ReadKey();
            }
            finally
            {
                reader.Close();
            }
        }
        /// <summary>
        /// 增删改数据
        /// </summary>
        /// <param name="mySqlCommand"></param>
        public static void getInsert(String sql, MySqlConnection mysql)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(DateTime.Now.ToString() + "  " + "数据写入失败：" + ex.Message);
                ////Console.ReadKey();
            }
        }
      
        /// <summary>
        /// 公共变量
        /// </summary>
        public class LoginStatus
        {
            //创建公共变量
            public static string Huiloginstatus { get; set; }
            public static string ZDMloginstatus { get; set; }
            //public static string loginPwd { get; set; }
            //public static string loginSqlIp { get; set; }
        }   

        /// <summary>
        /// YQH商品注入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //string postUrl = "http://www.178hui.com/index.php?mod=ajax&act=check_mall_url&callback=jQuery1830839117833761329_1497426647543";
            //string postRefer = "http://www.178hui.com/zdm/add.html";
            //string postdataurl = "https://detail.tmall.com/item.htm?id=540676930334";
            //string postData =string.Format("url={0}&type=bl", postdataurl);
            //string postContent = Helper.LoginHelper.VisitPage(postUrl, postRefer, postData);
            string url = "https://go.smzdm.com/5282d885491f1328/ca_aa_yh_37_7389540_830_35884_39";
            string getContent = LoginHelper.HttpGet(url);
            string[] cccccc = HtmlHelper.GetElementsByTagName(getContent, "script");
            foreach (string ccc in cccccc)
            {
                string bbbb = ccc;
                string jssss = LoginHelper.Eval(bbbb);
            }


            string yuanshiHtml = LogHelper.writeFile(getContent, "2222.html");
            //string jssss = LoginHelper.Eval("");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //连接mysql
            MySqlConnection mysqlConn = getMySqlCon();
            
            string LZNMax = "select MAX(id) from yqh_goods_yuanshi";
            string LZNSum = "select count(*) from yqh_goods_yuanshi";
            int sumSql =0;
            int maxSql = 0;


            //查询数据总数
            MySqlCommand mySqlCommand = new MySqlCommand(LZNSum, mysqlConn);
            MySqlDataReader reader = mySqlCommand.ExecuteReader();

            try
            {
                //mySqlCommand.ExecuteNonQuery();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        sumSql= reader.GetInt32(0);                       
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败:"+ex.Message);
            }

            //查询id最大
            MySqlCommand mySqlCommand2 = new MySqlCommand(LZNMax, mysqlConn);
            MySqlDataReader reader2 = mySqlCommand2.ExecuteReader();
            try
            {
                //mySqlCommand.ExecuteNonQuery();
                while (reader2.Read())
                {
                    if (reader2.HasRows)
                    {
                        maxSql = reader2.GetInt32(0);
                    }
                }
                reader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败:"+ex.Message);
            }


            //获取数据
            //查询id最大            
            for (int i = maxSql; i <= maxSql; i--)
            {
                string LZNMysql = string.Format("select id,cc_title,cc_price,cc_oprice,cc_info,cc_true_url,cc_fenlei  from yqh_goods_yuanshi where id={0} and cc_isdel !='-1'", i);
                MySqlCommand mySqlCommand3 = new MySqlCommand(LZNMysql, mysqlConn);
                MySqlDataReader reader3 = mySqlCommand3.ExecuteReader();
                try
                {
                    //mySqlCommand.ExecuteNonQuery();
                    while (reader3.Read())
                    {
                        if (reader3.HasRows)
                        {
                            int id = reader3.GetInt32(0);
                            string cc_title = reader3.GetString(1);
                            decimal cc_price = reader3.GetDecimal(2);
                            decimal cc_oprice = reader3.GetDecimal(3);
                            string cc_info = reader3.GetString(4);
                            string cc_true_url = reader3.GetString(5);
                            string cc_fenlei = reader3.GetString(6);



                            string LZNPostUrl = "http://www.huim.com/Ajax/IsDoubleVote_new ";
                        }
                    }
                    reader3.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询失败:{0}", ex.Message);
                }

            }

        }
    }
}
