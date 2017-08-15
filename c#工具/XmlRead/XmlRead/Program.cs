using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace XmlRead
{
    class Program
    {
        public static void GetCalss()
        {
            string htmlstr = @"< div class="bl_cc_title"><a href = "http://www.178hui.com/zdm/view-682724.html" target="_blank">【京东超市】新西兰原装进口安佳Anchor全脂乳粉成人全脂奶粉1KG袋装</a></div>";
            // 定义正则表达式用来匹配 img 标签   
            Regex regImg = new Regex(htmlstr, RegexOptions.IgnoreCase);

            // 搜索匹配的字符串   
            MatchCollection matches = regImg.Matches();
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表   
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgUrl"].Value;
            Console.WriteLine( sUrlList);
        }
    }
}
