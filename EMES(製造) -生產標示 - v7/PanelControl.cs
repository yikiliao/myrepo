using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EMES.Forms;
using EMES.Models;

namespace EMES
{   
    class PanelControl
    {      
        
        //public string formshow(string formname)
        //{
        //    //in ('S','L')
        //    char[] sarray = new char[] { ',' };
        //    string DataRang = sst901.Get(Home.Id).Rang;
        //    string[] sarray2 = DataRang.Replace("in ('", "").Replace("')", "").Replace("'", "").Split(sarray);




        //    switch (formname)
        //    {
        //       //更改密碼
        //        case "ssi999":
        //            ssi999 fm = new ssi999();
        //            fm.Show();
        //            break;

        //        //製造課桶數維護
        //        case "mfd000":
        //            mfd000 mfd000 = new mfd000();                    
        //            mfd000.Show();
        //            break;

        //        //製造課生產排程(預計)
        //        case "mfd001":
        //            mfd001 mfd001 = new mfd001();
        //            mfd001.Show();
        //            break;

        //        //製造課生產排程(實際)
        //        case "mfd002":
        //            mfd002 mfd002 = new mfd002();
        //            mfd002.Show();
        //            break;

        //        case "mfd003":
        //            mfd003 mfd003 = new mfd003();
        //            mfd003.Show();
        //            break;


        //        //製造課生產排程表
        //        case "mfr001":
        //            mfr001 mfr001 = new mfr001();
        //            mfr001.Show();
        //            break;

        //        //製造課生產排程表
        //        case "mfr002":
        //            mfr002 mfr002 = new mfr002();
        //            mfr002.Show();
        //            break;

        //    }
        //    return null;
        //}

        public string formshow(string formname)
        {
            //in ('S','L')
            char[] sarray = new char[] { ',' };
            string DataRang = Account.Get(Home.Id).Rang;
            string[] sarray2 = DataRang.Replace("in ('", "").Replace("')", "").Replace("'", "").Split(sarray);




            switch (formname)
            {
                //更改密碼
                case "ssi999":
                    ssi999 fm = new ssi999();
                    fm.Show();
                    break;

                //製造課桶數維護
                case "mfd000":
                    mfd000 mfd000 = new mfd000();                    
                    mfd000.Show();
                    break;

                //製造課生產排程(預計)
                case "mfd001":
                    mfd001 mfd001 = new mfd001();
                    mfd001.Show();
                    break;

                //製造課生產排程(實際)
                case "mfd002":
                    mfd002 mfd002 = new mfd002();
                    mfd002.Show();
                    break;

                case "mfd003":
                    mfd003 mfd003 = new mfd003();
                    mfd003.Show();
                    break;


                //製造課生產排程表
                case "mfr001":
                    mfr001 mfr001 = new mfr001();
                    mfr001.Show();
                    break;

                //製造課生產排程表
                case "mfr002":
                    mfr002 mfr002 = new mfr002();
                    mfr002.Show();
                    break;

            }
            return null;
        }
    }
}
