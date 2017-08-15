using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class MysqlHelper
    {
        /// <summary>
        /// 建立mysql数据库连接
        /// </summary>
        /// <returns></returns>
        //public static MySqlConnection getMySqlCon()
        //{
        //    String mysqlStr = "server=localhost;user id=root;database=yqh_goods_yuanshi;password=root;CharSet=utf8;pooling=true;Port=3306";
        //    //String mySqlCon = ConfigurationManager.ConnectionStrings["MySqlCon"].ConnectionString;
        //    MySqlConnection mysql = new MySqlConnection(mysqlStr);
        //    try
        //    {
        //        mysql.Open();//连接数据库 
        //    }
        //    catch (Exception e)
        //    {
        //        string ExM = e.Message;
        //    }
        //    return mysql;
        //}
        ///// <summary>
        ///// 查询并获得结果集并遍历
        ///// </summary>
        ///// <param name="mySqlCommand"></param>
        ///// <param name="mysqlResultTxt"></param>//示例："编号:" + reader.GetInt32(0) + "|姓名:" + reader.GetString(1) + "|年龄:" + reader.GetInt32(2) + "|学历:" + reader.GetString(3)
        //public static void getResultset(String sql, MySqlConnection mysql)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
        //    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        //    try
        //    {
        //        mySqlCommand.ExecuteNonQuery();
        //        while (reader.Read())
        //        {
        //            if (reader.HasRows)
        //            {
        //                Console.WriteLine("编号:" + reader.GetInt32(0) + "|姓名:" + reader.GetString(1) + "|年龄:" + reader.GetInt32(2) + "|学历:" + reader.GetString(3));
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //string message = ex.Message;
        //        //Console.WriteLine("数据查询失败：" + message);
        //        //Console.ReadKey();
        //    }
        //    finally
        //    {
        //        reader.Close();
        //    }
        //}
        ///// <summary>
        ///// 增删改数据
        ///// </summary>
        ///// <param name="mySqlCommand"></param>
        //public static void getInsert(String sql, MySqlConnection mysql)
        //{
        //    MySqlCommand mySqlCommand = new MySqlCommand(sql, mysql);
        //    try
        //    {
        //        mySqlCommand.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        //string txt=DateTime.Now.ToString() + "  " + "数据写入失败：" + ex.Message;
        //        ////Console.ReadKey();
        //    }
        //}
    }
}

