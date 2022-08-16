using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Collections;
using EMES.Forms;

namespace EMES.Models
{
    class sfb_file
    {
        #region 資料屬性
        public string Dept { get; set; }
        public string Wkno { get; set; } //工單號        
        public string Imno { get; set; } //料號

        public decimal Ta_sfb04 { get; set; }//上模厚
        public decimal Ta_sfb02 { get; set; }//上模長
        public decimal Ta_sfb03 { get; set; }//上模寬
        public decimal Ta_sfb08 { get; set; }//下模厚
        public decimal Ta_sfb06 { get; set; }//下模長
        public decimal Ta_sfb07 { get; set; }//下模寬
        public string Sfb223 { get; set; }//客戶編號
        public string Occ02 { get; set; }//客戶名稱
        public decimal Ta_sfb17 { get; set; }//原床厚
        public decimal Sfb08 { get; set; }//生產數量
        public string Sfb05 { get; set; }//料號
        public string Ima02 { get; set; }//品名
        public string Ima021 { get; set; }//規格
        public decimal Ta_sfb19 { get; set; }//預計生產桶數
        public string Sfb81 { get; set; }//開單日期
        public decimal Ta_sfb20 { get; set; }//每桶重量

        #endregion


        //public static sfb_file Get(string Wkno)
        //{
        //    // 查詢資料庫資料
        //    ArrayList parm = new ArrayList();
        //    parm.Add(Wkno.Trim());
        //    string sql = null;
        //    sql += string.Format("select * from {0}.sfb_file where 1= 1", Login.DEPT);
        //    sql += " and sfb01 = :Wkno";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrOracle(Login.DB), sql, parm);
        //    // 將查詢到的資料回傳
        //    if (DeptDS.Tables[0].Rows.Count == 0)
        //        return null;

        //    var p_ima_file = ima_file.Get(DeptDS.Tables[0].Rows[0].Field<string>("sfb05").Trim()); //料品主檔
        //    var p_occ_file = occ_file.Get(DeptDS.Tables[0].Rows[0].IsNull("sfb223") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("sfb223").Trim());//客戶主檔            
        //    return new sfb_file
        //    {
        //        Ta_sfb04 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb04") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb04"]),
        //        Ta_sfb02 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb02") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb02"]),
        //        Ta_sfb03 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb03") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb03"]),
        //        Ta_sfb08 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb08") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb08"]),
        //        Ta_sfb06 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb06") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb06"]),
        //        Ta_sfb07 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb07") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb07"]),

        //        Sfb05 = DeptDS.Tables[0].Rows[0].IsNull("sfb05") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("sfb05").Trim(),//料號
        //        Ima02 = p_ima_file == null ? "" : p_ima_file.Ima02,//品名
        //        Ima021 = p_ima_file == null ? "" : p_ima_file.Ima021,//規格                
        //        Sfb223 = p_occ_file == null ? "" : p_occ_file.Occ01,//客戶編號
        //        Occ02 = p_occ_file == null ? "" : p_occ_file.Occ02,//客戶簡稱
        //        Sfb81 = DeptDS.Tables[0].Rows[0].Field<DateTime>("Sfb81").ToString("yyyy/MM/dd"),

        //        Ta_sfb17 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb17") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb17"]),
        //        Sfb08 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("sfb08") ? 0 : DeptDS.Tables[0].Rows[0]["sfb08"]),
        //        Ta_sfb19 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb19") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb19"]),
        //        Ta_sfb20 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb20") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb20"]),
        //    };
        //}

        public static sfb_file Get(string Wkno)
        {
            // 查詢資料庫資料
            ArrayList parm = new ArrayList();
            parm.Add(Wkno.Trim());
            string sql = null;

            if (Login.DEPT == "ew")
            {
                sql += string.Format("select * from {0}.sfb_file where 1= 1", Login.DEPT);
            }

            if (Login.DEPT == "ej")
            {
                sql += string.Format("select * from {0}.sfb_file where 1= 1", "ew");
            }

            if (Login.DEPT == "el")
            {
                sql += string.Format("select * from {0}.sfb_file where 1= 1", Login.DEPT);
            }            
            sql += " and sfb01 = :Wkno";

            DataSet DeptDS = DBConnector.executeQuery(Login.TT, sql, parm);
            // 將查詢到的資料回傳
            if (DeptDS.Tables[0].Rows.Count == 0)
                return null;

            var p_ima_file = ima_file.Get(DeptDS.Tables[0].Rows[0].Field<string>("sfb05").Trim()); //料品主檔
            var p_occ_file = occ_file.Get(DeptDS.Tables[0].Rows[0].IsNull("sfb223") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("sfb223").Trim());//客戶主檔            
            return new sfb_file
            {
                Ta_sfb04 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb04") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb04"]),
                Ta_sfb02 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb02") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb02"]),
                Ta_sfb03 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb03") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb03"]),
                Ta_sfb08 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb08") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb08"]),
                Ta_sfb06 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb06") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb06"]),
                Ta_sfb07 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb07") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb07"]),

                Sfb05 = DeptDS.Tables[0].Rows[0].IsNull("sfb05") ? "" : DeptDS.Tables[0].Rows[0].Field<string>("sfb05").Trim(),//料號
                Ima02 = p_ima_file == null ? "" : p_ima_file.Ima02,//品名
                Ima021 = p_ima_file == null ? "" : p_ima_file.Ima021,//規格                
                Sfb223 = p_occ_file == null ? "" : p_occ_file.Occ01,//客戶編號
                Occ02 = p_occ_file == null ? "" : p_occ_file.Occ02,//客戶簡稱
                Sfb81 = DeptDS.Tables[0].Rows[0].Field<DateTime>("Sfb81").ToString("yyyy/MM/dd"),

                Ta_sfb17 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb17") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb17"]),
                Sfb08 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("sfb08") ? 0 : DeptDS.Tables[0].Rows[0]["sfb08"]),
                Ta_sfb19 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb19") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb19"]),
                Ta_sfb20 = System.Convert.ToDecimal(DeptDS.Tables[0].Rows[0].IsNull("ta_sfb20") ? 0 : DeptDS.Tables[0].Rows[0]["ta_sfb20"]),
            };
        }


        //public static IEnumerable<sfb_file> WkToDoList()
        //{
        //    string sql = null;
        //    ArrayList parm = new ArrayList();

        //    sql = null;
        //    sql += string.Format("select * from {0}.sfb_file where 1= 1", Login.DEPT);
        //    if (Login.DEPT == "ew")
        //    {
        //        sql += " and  SUBSTR(sfb01, 1, 5)  in ('WS011','WS013','WS018','WS019')";
        //    }
        //    if (Login.DEPT == "el")
        //    {
        //        sql += " and  SUBSTR(sfb01, 1, 5)  in ('LS011','LS012','LS015','LS016')";
        //    }
        //    //sql += " and sfb04 = '3'";
        //    //sql += " and sfb04 != '8'";
        //    sql += " and sfb04 in ('3','4','5','6','7')";            
        //    sql += " order by sfb01 ";

        //    DataSet DeptDS = DBConnector.executeQuery(Conn.GetStrOracle(Login.DB), sql, parm);
        //    return from p in DeptDS.Tables[0].AsEnumerable()
        //           select new sfb_file
        //           {
        //               Dept = Login.DEPT,
        //               Wkno = p.IsNull("sfb01") ? "" : p.Field<string>("sfb01").Trim(),
        //               Imno = p.IsNull("sfb05") ? "" : p.Field<string>("sfb05").Trim(),
        //           };
        //}


        public static IEnumerable<sfb_file> WkToDoList()
        {
            string sql = null;
            ArrayList parm = new ArrayList();

            sql = null;            
            if (Login.DEPT == "ew")
            {
                sql += string.Format("select * from {0}.sfb_file where 1= 1", Login.DEPT);
                sql += " and  SUBSTR(sfb01, 1, 5)  in ('WS011','WS013','WS018','WS019')";
            }
            if (Login.DEPT == "ej") //大埔美
            {
                sql += string.Format("select * from {0}.sfb_file where 1= 1", "ew");
                sql += " and  SUBSTR(sfb01, 1, 5)  in ('JS011','JS013','JS018','JS019')";
            }
            if (Login.DEPT == "el")
            {
                sql += string.Format("select * from {0}.sfb_file where 1= 1", Login.DEPT);
                sql += " and  SUBSTR(sfb01, 1, 5)  in ('LS011','LS012','LS015','LS016')";
            }            
            sql += " and sfb04 in ('3','4','5','6','7')";
            sql += " order by sfb01 ";

            DataSet DeptDS = DBConnector.executeQuery(Login.TT, sql, parm);
            return from p in DeptDS.Tables[0].AsEnumerable()
                   select new sfb_file
                   {
                       Dept = Login.DEPT,
                       Wkno = p.IsNull("sfb01") ? "" : p.Field<string>("sfb01").Trim(),
                       Imno = p.IsNull("sfb05") ? "" : p.Field<string>("sfb05").Trim(),
                   };
        }


    }
}
