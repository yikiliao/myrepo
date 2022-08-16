using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMES.Models
{
    class InEdf
    {
        #region 資料屬性
        public string Doc { get; set; }
        public string Edf03 { get; set; }
        public string Edf04 { get; set; }
        public string Edf06 { get; set; }
        public decimal Edf07 { get; set; }
        public decimal Edf08 { get; set; }
        public string Edf09 { get; set; }
        public decimal Edf11 { get; set; }
        public decimal Edf12 { get; set; }
        public decimal Edf14 { get; set; }
        public decimal Edf15 { get; set; }
        public string Edflegal { get; set; }
        public string Edfplant { get; set; }
        public string Add_date { get; set; }
        public string Mod_date { get; set; }
        public string Bdate { get; set; }
        public string Btime { get; set; }
        public string Edate { get; set; }
        public string Etime { get; set; }
        public string Empname { get; set; }
        public string Status { get; set; }
        #endregion

        public static string Set_Insert(InEdf rc)
        {
            string sql = string.Empty;
            sql += "insert into InEdf (doc,edf03,edf04,edf06,edf07,edf08,edf09,edf11,edf12,edf14,edf15,edflegal,edfplant,add_date,mod_date,bDate,bTime,eDate,eTime,empname,status)";
            sql += string.Format("values('{0}','{1}','{2}','{3}',{4},'{5}','{6}',{7},{8},{9},{10},'{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}');\r\n",
                rc.Doc,
                rc.Edf03,
                rc.Edf04,
                rc.Edf06,
                rc.Edf07,
                rc.Edf08,
                rc.Edf09,
                rc.Edf11,
                rc.Edf12,
                rc.Edf14,
                rc.Edf15,
                rc.Edflegal,
                rc.Edfplant,
                rc.Add_date,
                rc.Mod_date,
                rc.Bdate,
                rc.Btime,
                rc.Edate,
                rc.Etime,
                rc.Empname,
                rc.Status);
            return sql;
        }

    }
}
