using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class LogHelper
    {
        /// <summary>
        /// 写txt
        /// </summary>
        /// <param name="content"></param>
        /// <param name="filename">"Input_sql.txt"形式</param>
        /// <returns></returns>
        public static string writeFile(string content, string filename)
        {
            try
            {
                DateTime dt = DateTime.Now;
                
                //string.Format("{0:d}", dt)
                //string filenames = string.Format("{0:d}---{1}", dt,filename);
                string str = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo d = Directory.CreateDirectory(str);
                //string newPath = Path.Combine(activeDir, "mySubDirOne");//表示再建一层mySubDirOne目录
                filename = string.Format(dt.GetDateTimeFormats('D')[0].ToString()+"----"+filename);
                string FILE_NAME = string.Format(str + "\\GetData\\" + filename);

                string msg = DateTime.Now.ToString() + "----" + content + "\r\n";
                byte[] myByte = Encoding.UTF8.GetBytes(msg);
                using (FileStream fsWrite = new FileStream(FILE_NAME, FileMode.Append))
                {
                    fsWrite.Write(myByte, 0, myByte.Length);
                    //Console.WriteLine(content);
                    fsWrite.Close();
                    fsWrite.Dispose();
                };
                return "成功";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
