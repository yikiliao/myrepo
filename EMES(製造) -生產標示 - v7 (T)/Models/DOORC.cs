using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace EMES.Models
{
    class DOORC
    {
        public static DataTable GetDataTable(string cnstr, string sql)
        {
            OracleConnection cn = new OracleConnection(cnstr);
            DataTable dt;
            try
            {
                cn.Open();
                //建立qlcomm
                OracleCommand cmd = new OracleCommand(sql, cn);
                //接受命令讀取資料                
                OracleDataReader dr = cmd.ExecuteReader();
                //建立新的DataTable
                dt = new DataTable();
                //載入SqlDataReader
                dt.Load(dr);
                //關閉SqlDataReader
                dr.Close();
                //釋放sqlcommand資源
                cmd.Dispose();
            }
            finally
            {
                cn.Close();
            }

            return dt;
        }

        public static int Excute(string cnstr, string sql)
        {
            int i = 0;
            using (OracleConnection conn = new OracleConnection(cnstr))
            {
                conn.Open();
                OracleTransaction tran = conn.BeginTransaction();
                OracleCommand comm = new OracleCommand(sql, conn);

                comm.Transaction = tran;
                i = comm.ExecuteNonQuery();
                if (i == 0)
                {
                    tran.Rollback();
                }
                else
                {
                    tran.Commit();
                }
                //Thread.Sleep(800);
                conn.Close();
                return i;
            }
        }

    }
}
