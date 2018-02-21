using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abdulaziz.Date
{
    /// <summary>
    /// Get Greg Date
    /// </summary>
   public class Greg:Date
    {


        public MyDate Now { get { return GregAsMyDate(); } }


        private string gresDate;

        public string Date
        {
            get { return gresDate = GetGreg() ; }
           private set { gresDate = value; }
        }

        public string ToHjri(string hijri) {

            return GregToHijri(hijri);
        }

        public MyDate SetDate(string date) {

            return SetDateGreg(date);

        }




    }
}
