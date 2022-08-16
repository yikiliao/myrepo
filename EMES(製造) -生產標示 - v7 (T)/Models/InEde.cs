using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMES.Models
{
    class InEde
    {
        #region 資料屬性
        public string Doc { get; set; }
        public string Edegrup { get; set; }
        public string Edelegal { get; set; }
        public string Edemodu { get; set; }
        public string Edeorig { get; set; }
        public string Edeoriu { get; set; }
        public string Edeplant { get; set; }
        public string Edeuser { get; set; }
        public string Add_date { get; set; }
        public string Mod_date { get; set; }
        public string Status { get; set; }
        #endregion

        public static string Set_Insert(InEde rc)
        {
            string sql = string.Empty;
            sql += "insert into InEde (doc,edegrup,edelegal,edemodu,edeorig,edeoriu,edeplant,edeuser,add_date,mod_date,status)";
            sql += string.Format("values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');\r\n",
                rc.Doc,
                rc.Edegrup,
                rc.Edemodu,
                rc.Edelegal,
                rc.Edeorig,
                rc.Edeoriu,
                rc.Edeplant,
                rc.Edeuser,
                rc.Add_date,
                rc.Mod_date,
                rc.Status);
            return sql;
        }

    }
}
