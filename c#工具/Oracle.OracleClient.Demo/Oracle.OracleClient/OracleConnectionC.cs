using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Oracle.OracleClient
{
    public class OracleConnectionC
    {
        private static string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.2.234)(METHOD=BASIC)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=system;Password=admin123";

        public static object Add1(byte[] imgByte,string filename)
        {
            OracleConnection conn = new OracleConnection(connectionString);
            conn.Open();
            string strSQL = "INSERT INTO \"SYSTEM\".\"REGISTERPERSON\" " +
                    "(OBJECTID,ZPBH,RYBH,GMSFHM,XM,ZP,RRQ,XPLX,GXKCJSJ,GXKGXSJ)" +
                    " VALUES " +
                    "('OBJECTID', '" + Guid.NewGuid().ToString() + "', 'RYBH', '362203199111226841', 'XM', :zp, 'RRQ', 'XPLX', 'GXKCJSJ', 'GXKGXSJ')";

            //创建Oracle参数

            OracleParameter coordsPara = new OracleParameter("zp", OracleDbType.Blob, imgByte.Length);
            coordsPara.Value = imgByte;

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL;

            cmd.Parameters.Add(coordsPara);
            int resut = -1;
            try
            {
                resut = cmd.ExecuteNonQuery();
            }
            catch(Exception ex) { }
            return resut;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns>执行行数</returns>
        public static object Add(byte[] imgByte)
        {
            StringBuilder strSql = new StringBuilder();
            string ZPBH = Guid.NewGuid().ToString("N");
            strSql.Append("INSERT INTO \"SYSTEM\".\"REGISTERPERSON\" ");
            strSql.Append("(OBJECTID,ZPBH,RYBH,GMSFHM,XM,ZP,RRQ,XPLX,GXKCJSJ,GXKGXSJ) ");
            strSql.Append("VALUES ");
            strSql.Append("('OBJECTID', "+ ZPBH + ",'RYBH',	'GMSFHM', 'XM', :zp, 'RRQ', 'XPLX', 'GXKCJSJ', 'GXKGXSJ') ");

            byte[] byts = new UnicodeEncoding().GetBytes("Image");
            OracleParameter[] param = {
                new OracleParameter(":zp", OracleDbType.Blob, imgByte.Length)
            };
            param[0].Value = imgByte;

            GetSingle(strSql.ToString(), param);
            return 0;
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params OracleParameter[] cmdParms)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (OracleException e)
                    {
                        throw e;
                    }
                }
            }
        }

        private static void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, OracleParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                //======================================================================================================================
                foreach (OracleParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }
    }
}
