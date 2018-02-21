using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abdulaziz.Date
{
    /// <summary>
    /// Get Hjri Date
    /// </summary>
    public class Hijri:Date
    {


        public MyDate Now { get { return HijriAsMyDate(); } }

       

        private string hjrisDate;

        public string Date
        {
            get { return hjrisDate=GetHijri(); }
          private  set { hjrisDate = value; }
        }

        public string ToGreg(string greg) {

            return HijriToGreg(greg);
        }

        public MyDate SetDate(string hijri) {

            return SetDateHijri(hijri);
        }


    }
}
