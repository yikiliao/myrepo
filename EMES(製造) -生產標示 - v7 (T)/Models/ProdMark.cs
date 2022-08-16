using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMES.Models
{
    class ProdMark
    {
        #region 資料屬性
        public string Mfdate { get; set; }
        public string Mfline { get; set; }
        public string Mftable { get; set; }
        public string Wkno { get; set; }
        public string Workqty { get; set; }
        public string Sfb05 { get; set; }
        public string Ta_sfb15 { get; set; }
        public string Ta_sfb16 { get; set; }
        public string Ta_sfb17 { get; set; }
        public string Ima02 { get; set; }
        public string Ima021 { get; set; }
        public string Imaud02 { get; set; }
        public string Occ02 { get; set; }
        public string Imsz { get; set; }
        public string Imaud07 { get; set; }

        public string Story { get; set; }
        public string Cold_long { get; set; }
        public string Cold_width { get; set; }

        #endregion
    }
}
