﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMES.Models
{
    class Emptime
    {
        #region 資料屬性
        public string Doc { get; set; }
        public string Stid { get; set; }
        public string Stname { get; set; }
        public string Empid { get; set; }
        public string Empname { get; set; }
        public string Rdt { get; set; }
        public string Bdate { get; set; }
        public string Bhh { get; set; }
        public string Bmm { get; set; }
        public string Edate { get; set; }
        public string Ehh { get; set; }
        public string Emm { get; set; }
        public decimal Worktime { get; set; }
        #endregion

        public static string Set_Insert(Emptime rc)
        {
            string sql = string.Empty;
            sql += "insert into emptime (doc,stid,stname,empid,empname,rdt,bdate,bhh,bmm,edate,ehh,emm,worktime)";
            sql += string.Format("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12});\r\n",
                rc.Doc,
                rc.Stid,
                rc.Stname,
                rc.Empid,
                rc.Empname,
                rc.Rdt,
                rc.Bdate,
                rc.Bhh,
                rc.Bmm,
                rc.Edate,
                rc.Ehh,
                rc.Emm,
                rc.Worktime);
            return sql;
        }

    }
}
