using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace EMES.Models
{
    class DOSQL
    {
        public static DataTable GetDataTable(string cnstr, string sql)
        {
            SqlConnection cn = new SqlConnection(cnstr);
            DataTable dt;
            try
            {
                cn.Open();
                //建立qlcomm
                SqlCommand cmd = new SqlCommand(sql, cn);
                //接受命令讀取資料
                SqlDataReader dr = cmd.ExecuteReader();
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
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                SqlCommand comm = new SqlCommand(sql, conn);

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

        public static bool haveBarcode(string cnstr, string sql)
        {
            bool iCount = false;
            using (SqlConnection conn = new SqlConnection(cnstr))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(sql, conn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        iCount = true;
                    }
                    conn.Close();
                }
            }
            return iCount;
        }

    }
}
