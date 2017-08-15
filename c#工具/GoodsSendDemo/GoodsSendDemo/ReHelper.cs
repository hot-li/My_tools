using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoodsSendDemo
{
    public static class ReHelper
    {
        /// <summary>
        /// 正则表达式
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="pattern">正则表达式</param>
        /// <returns></returns>
        public static string reMatch(string str, string pattern)
        {
            Regex r1 = new Regex(pattern);
            if (r1.Matches(str).Count != null && r1.Matches(str).Count != 0)
            {
                return r1.Match(str).Value;
            }
            else { return null; }
        }
    }
}
