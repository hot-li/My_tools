using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OracleClient;

namespace Oracle.OracleClient.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo[] files = new DirectoryInfo(@"D:\Image").GetFiles("*.jpg");

            if (files.Length == 0)
            {
                Console.WriteLine("无文件.....");
                Console.ReadKey();
                Environment.Exit(0);
            }
            foreach (var f in files)
            {
                FileStream fs = new FileStream(f.FullName, FileMode.Open);
                byte[] buff = new byte[fs.Length];
                int len = (int)fs.Length;
                fs.Read(buff, 0, len);


                OracleConnectionC.Add1(buff, "");
                Console.WriteLine(f.Name + "--->已入库");
            }
            Console.ReadKey();
        }
    }
}
