using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GoodsSendDemo
{
    public static class XmlHelper
    {
        private static string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.xml");
        public static string User = "";
        public static string PWD = "";

        public static void SetConfirg()
        {
            return;
        }

        public static void GetInfos()
        {
            if (!File.Exists(xmlPath))
            {
                return;
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);

            XmlNode root = xmlDoc.SelectSingleNode("Configs");
            PWD = ReadValueOfNode(root, "Pwd");
            User = ReadValueOfNode(root, "User");
        }
        private static string ReadValueOfNode(XmlNode node, string name)
        {
            if (node != null && !string.IsNullOrEmpty(name))
            {
                XmlNode node1 = node.SelectSingleNode(name);
                if (node1 != null)
                {
                    return node1.InnerText;
                }
            }
            return "";
        }  
    }
}

