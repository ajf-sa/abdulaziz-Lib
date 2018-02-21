using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Diagnostics;
using abdulaziz.Model;

namespace abdulaziz.Date
{
    public enum DateEnum {
        AR,EN
    }
    public class Date
    {
        private string[] allFormats ={"yyyy/MM/dd","yyyy/M/d",
            "dd/MM/yyyy","d/M/yyyy",
            "dd/M/yyyy","d/MM/yyyy","yyyy-MM-dd",
            "yyyy-M-d","dd-MM-yyyy","d-M-yyyy",
            "dd-M-yyyy","d-MM-yyyy","yyyy MM dd",
            "yyyy M d","dd MM yyyy","d M yyyy",
            "dd M yyyy","d MM yyyy"};

        public Date() { }

        public Hijri Hj { get { var h = new Hijri(); return h; } }
        public Greg Gr { get { var g = new Greg(); return g; } }




        private DateTimeFormatInfo SetDateTimeFormatInfo() {

            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
            dtfi.ShortDatePattern = "yyy/MM/dd";
            dtfi.DateSeparator = "/";
           
            return dtfi;

        }
      
        private CultureInfo SetCultureInfo(DateEnum dn) {

            CultureInfo cu =null;
            switch (dn)
            {
                case DateEnum.AR:
                    cu = new CultureInfo("ar-SA");
                    cu.DateTimeFormat.Calendar = new UmAlQuraCalendar();
                    cu.DateTimeFormat.DateSeparator = "/";
                    cu.DateTimeFormat.ShortDatePattern = "dd/MM/yyy";
                    cu.DateTimeFormat.ShortTimePattern = "HH:mm";
                   
                    break;
                case DateEnum.EN:
                    cu = new CultureInfo("en-US");
                    cu.DateTimeFormat.Calendar = new GregorianCalendar();
                    cu.DateTimeFormat.DateSeparator = "/";
                    cu.DateTimeFormat.ShortDatePattern = "dd/MM/yyy";
                    cu.DateTimeFormat.ShortTimePattern = "HH:mm";

                    break;
                default:
                    Debug.WriteLine("Error CultureInfo pls check SPEC.CULTURE Date.class");
                    break;
            }
          

            return cu;

        }
      
      




        protected string GetGreg() {

            string date = DateTime.Now.Date.ToString("dd/MM/yyy", SetCultureInfo(DateEnum.EN));
            return date;

        }

        protected string GetHijri() {
            string date = DateTime.Now.Date.ToString("dd/MM/yyy", SetCultureInfo(DateEnum.AR));
            return date;
        }



    

        protected MyDate HijriAsMyDate()
        {
            
            try
            {
                DateTime date = DateTime.ParseExact(GetHijri(), allFormats, SetCultureInfo(DateEnum.AR), DateTimeStyles.AllowWhiteSpaces);
                string[] d = date.ToString("dd/MM/yyy", SetCultureInfo(DateEnum.AR)).Split('/');
                MyDate myd = new MyDate() { Year = int.Parse(d[2]), Month = int.Parse(d[1]), Day = int.Parse(d[0]) };
                return myd;
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error When Get Hijri as myDate " + ex.Message);
                throw;
            }

        }

        protected MyDate GregAsMyDate() {

            try
            {
                DateTime date = DateTime.ParseExact(GetGreg(), allFormats, SetCultureInfo(DateEnum.EN), DateTimeStyles.AllowWhiteSpaces);
                string[] d=date.ToString("dd/MM/yyy", SetCultureInfo(DateEnum.EN)).Split('/');
                MyDate myd = new MyDate() { Year = int.Parse(d[2]), Month = int.Parse(d[1]), Day = int.Parse(d[0]) };
                return myd;
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error When Get Grego as myDate " + ex.Message);
                throw;
            }
        }


        protected MyDate SetDateGreg(string date)
        {

            try
            {
                DateTime dati = DateTime.ParseExact(date, allFormats, SetCultureInfo(DateEnum.EN), DateTimeStyles.AllowWhiteSpaces);
                
                MyDate myd = new MyDate() { Year = dati.Year, Month = dati.Month, Day = dati.Day };
                return myd;
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error When Get Hijri as myDate " + ex.Message);
                throw;
            }

        }

        protected MyDate SetDateHijri(string hijri)
        {

            try
            {
                DateTime date = DateTime.ParseExact(hijri, allFormats, SetCultureInfo(DateEnum.AR), DateTimeStyles.AllowWhiteSpaces);
                string[] d = date.ToString("dd/MM/yyy", SetCultureInfo(DateEnum.AR)).Split('/');
                MyDate myd = new MyDate() { Year = int.Parse(d[2]), Month = int.Parse(d[1]), Day = int.Parse(d[0]) };
                return myd;
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error When Get Hijri as myDate " + ex.Message);
                throw;
            }

        }


        protected string HijriToGreg(string arabic) {
            try
            {
                DateTime date = DateTime.ParseExact(arabic, allFormats, SetCultureInfo(DateEnum.AR), DateTimeStyles.AllowWhiteSpaces);
                Debug.WriteLine(date.Year);
                return date.ToString("dd/MM/yyy", SetCultureInfo(DateEnum.EN));
            }
            catch (Exception ex) {

                Debug.WriteLine("Error When Convert to english Date "+ex.Message);
                return "";
            }
        }
        protected string GregToHijri(string english) {

            try
            {
                DateTime date = DateTime.ParseExact(english, allFormats, SetCultureInfo(DateEnum.EN), DateTimeStyles.AllowWhiteSpaces);
                return date.ToString("dd/MM/yyy", SetCultureInfo(DateEnum.AR));
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error When Convert to english Date " + ex.Message);
                return "";
            }
        }
        public DateTime GetDateNow() {
            
            return DateTime.Now;

        }

        private DateTime ToDateTime(string date) {


            try
            {
                DateTime dateTime = DateTime.ParseExact(date, allFormats, SetCultureInfo(DateEnum.EN), DateTimeStyles.AllowWhiteSpaces);
                return dateTime;
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error When Convert to Datetime " + ex.Message);
                throw ;
            }
        }

        public int CompareTellNow(string datetiem) {

            DateTime d1 = this.ToDateTime(datetiem);
            DateTime d2 = DateTime.Now;
            int result = DateTime.Compare(d1,d2);
            return result;

        }
        private DateTime ToDateTime(MyDate md) {

            return new DateTime(md.Year,md.Month,md.Day);
        }
        public long GetNumberOfDayBTODate(string date1, string date2) {

            MyDate d1 = Gr.SetDate(date1);
            MyDate d2 = Gr.SetDate(date2);

            DateTime dt1 = ToDateTime(d1);
            DateTime dt2 = ToDateTime(d2);
            TimeSpan log = dt1 - dt2;

            return (long)log.TotalDays;
        }
        
      

    }

     

 
}
