using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberToText
{
    public class NumberToTextLibrary
    {

        private static string f1(string s)
        {
            string t = "";
            switch (s)
            {
                case "0":
                    { t = ""; break; }
                case "1":
                    {
                        t = "يكصد";
                        break;
                    }
                case "2":
                    {
                        t = "دويست";
                        break;
                    }
                case "3":
                    {
                        t = "سيصد";
                        break;
                    }
                case "4":
                    {
                        t = "چهارصد";
                        break;
                    }
                case "5":
                    {
                        t = "پانصد";
                        break;
                    }
                case "6":
                    {
                        t = "ششصد";
                        break;
                    }
                case "7":
                    {
                        t = "هفتصد";
                        break;
                    }
                case "8":
                    {
                        t = "هشتصد";
                        break;
                    }
                case "9":
                    {
                        t = "نهصد";
                        break;
                    }
            }

            return t;
        }
        private static string f2(string s,bool date)
        {
            string t = "";
            if (s.Length == 0) return ("");
            if (s.Length == 1) s = "0" + s;

            switch (s)
            {
                case "00":
                    { t = ""; break; }

                case "01":
                    {
                        t = "يك";
                        break;
                    }

                case "02":
                    {
                        t = "دو";
                        break;
                    }

                case "03":
                    {
                        if (date)
                            t = "سو";
                        else
                            t = "سه";
                        break;
                    }

                case "04":
                    {
                        t = "چهار";
                        break;
                    }

                case "05":
                    {
                        t = "پنج";
                        break;
                    }

                case "06":
                    {
                        t = "شش";
                        break;
                    }

                case "07":
                    {
                        t = "هفت";
                        break;
                    }

                case "08":
                    {
                        t = "هشت";
                        break;
                    }

                case "09":
                    {
                        t = "نه";
                        break;
                    }

                case "10":
                    {
                        t = "ده";
                        break;
                    }

                case "11":
                    {
                        t = "يازده";
                        break;
                    }

                case "12":
                    {
                        t = "دوازده";
                        break;
                    }

                case "13":
                    {
                        t = "سيزده";
                        break;
                    }

                case "14":
                    {
                        t = "چهارده";
                        break;
                    }

                case "15":
                    {
                        t = "پانزده";
                        break;
                    }

                case "16":
                    {
                        t = "شانزده";
                        break;
                    }

                case "17":
                    {
                        t = "هفده";
                        break;
                    }

                case "18":
                    {
                        t = "هجده";
                        break;
                    }

                case "19":
                    {
                        t = "نوزده";
                        break;
                    }


                case "20":
                    {
                        t = "بيست";
                        break;
                    }

                case "21":
                    {
                        t = "بيست و يك";
                        break;
                    }

                case "22":
                    {
                        t = "بيست و دو";
                        break;
                    }

                case "23":
                    {
                        t = "بيست و سه";
                        break;
                    }

                case "24":
                    {
                        t = "بيست و چهار";
                        break;
                    }

                case "25":
                    {
                        t = "بيست و پنج";
                        break;
                    }

                case "26":
                    {
                        t = "بيست و شش";
                        break;
                    }

                case "27":
                    {
                        t = "بيست و هفت";
                        break;
                    }

                case "28":
                    {
                        t = "بيست و هشت";
                        break;
                    }

                case "29":
                    {
                        t = "بيست و نه";
                        break;
                    }


                case "30":
                    {
                        t = "سي";
                        break;
                    }

                case "31":
                    {
                        t = "سي و يك";
                        break;
                    }

                case "32":
                    {
                        t = "سي و دو";
                        break;
                    }

                case "33":
                    {
                        t = "سي و سه";
                        break;
                    }

                case "34":
                    {
                        t = "سي و چهار";
                        break;
                    }

                case "35":
                    {
                        t = "سي و پنج";
                        break;
                    }

                case "36":
                    {
                        t = "سي و شش";
                        break;
                    }

                case "37":
                    {
                        t = "سي و هفت";
                        break;
                    }

                case "38":
                    {
                        t = "سي و هشت";
                        break;
                    }

                case "39":
                    {
                        t = "سي و نه";
                        break;
                    }


                case "40":
                    {
                        t = "چهل";
                        break;
                    }

                case "41":
                    {
                        t = "چهل و يك";
                        break;
                    }

                case "42":
                    {
                        t = "چهل و دو";
                        break;
                    }

                case "43":
                    {
                        t = "چهل و سه";
                        break;
                    }

                case "44":
                    {
                        t = "چهل و چهار";
                        break;
                    }

                case "45":
                    {
                        t = "چهل و پنج";
                        break;
                    }

                case "46":
                    {
                        t = "چهل و شش";
                        break;
                    }

                case "47":
                    {
                        t = "چهل و هفت";
                        break;
                    }

                case "48":
                    {
                        t = "چهل و هشت";
                        break;
                    }

                case "49":
                    {
                        t = "چهل و نه";
                        break;
                    }


                case "50":
                    {
                        t = "پنجاه";
                        break;
                    }

                case "51":
                    {
                        t = "پنجاه و يك";
                        break;
                    }

                case "52":
                    {
                        t = "پنجاه و دو";
                        break;
                    }

                case "53":
                    {
                        t = "پنجاه و سه";
                        break;
                    }

                case "54":
                    {
                        t = "پنجاه و چهار";
                        break;
                    }

                case "55":
                    {
                        t = "پنجاه و پنج";
                        break;
                    }

                case "56":
                    {
                        t = "پنجاه و شش";
                        break;
                    }

                case "57":
                    {
                        t = "پنجاه و هفت";
                        break;
                    }

                case "58":
                    {
                        t = "پنجاه و هشت";
                        break;
                    }

                case "59":
                    {
                        t = "پنجاه و نه";
                        break;
                    }


                case "60":
                    {
                        t = "شصت";
                        break;
                    }

                case "61":
                    {
                        t = "شصت و يك";
                        break;
                    }

                case "62":
                    {
                        t = "شصت و دو";
                        break;
                    }

                case "63":
                    {
                        t = "شصت و سه";
                        break;
                    }

                case "64":
                    {
                        t = "شصت و چهار";
                        break;
                    }

                case "65":
                    {
                        t = "شصت و پنج";
                        break;
                    }

                case "66":
                    {
                        t = "شصت و شش";
                        break;
                    }

                case "67":
                    {
                        t = "شصت و هفت";
                        break;
                    }

                case "68":
                    {
                        t = "شصت و هشت";
                        break;
                    }

                case "69":
                    {
                        t = "شصت و نه";
                        break;
                    }


                case "70":
                    {
                        t = "هفتاد";
                        break;
                    }

                case "71":
                    {
                        t = "هفتاد و يك";
                        break;
                    }

                case "72":
                    {
                        t = "هفتاد و دو";
                        break;
                    }

                case "73":
                    {
                        t = "هفتاد و سه";
                        break;
                    }

                case "74":
                    {
                        t = "هفتاد و چهار";
                        break;
                    }

                case "75":
                    {
                        t = "هفتاد و پنج";
                        break;
                    }

                case "76":
                    {
                        t = "هفتاد و شش";
                        break;
                    }

                case "77":
                    {
                        t = "هفتاد و هفت";
                        break;
                    }

                case "78":
                    {
                        t = "هفتاد و هشت";
                        break;
                    }

                case "79":
                    {
                        t = "هفتاد و نه";
                        break;
                    }


                case "80":
                    {
                        t = "هشتاد";
                        break;
                    }

                case "81":
                    {
                        t = "هشتاد و يك";
                        break;
                    }

                case "82":
                    {
                        t = "هشتاد و دو";
                        break;
                    }

                case "83":
                    {
                        t = "هشتاد و سه";
                        break;
                    }

                case "84":
                    {
                        t = "هشتاد و چهار";
                        break;
                    }

                case "85":
                    {
                        t = "هشتاد و پنج";
                        break;
                    }

                case "86":
                    {
                        t = "هشتاد و شش";
                        break;
                    }

                case "87":
                    {
                        t = "هشتاد و هفت";
                        break;
                    }

                case "88":
                    {
                        t = "هشتاد و هشت";
                        break;
                    }

                case "89":
                    {
                        t = "هشتاد و نه";
                        break;
                    }


                case "90":
                    {
                        t = "نود";
                        break;
                    }

                case "91":
                    {
                        t = "نود و يك";
                        break;
                    }

                case "92":
                    {
                        t = "نود و دو";
                        break;
                    }

                case "93":
                    {
                        t = "نود و سه";
                        break;
                    }

                case "94":
                    {
                        t = "نود و چهار";
                        break;
                    }

                case "95":
                    {
                        t = "نود و پنج";
                        break;
                    }

                case "96":
                    {
                        t = "نود و شش";
                        break;
                    }

                case "97":
                    {
                        t = "نود و هفت";
                        break;
                    }

                case "98":
                    {
                        t = "نود و هشت";
                        break;
                    }

                case "99":
                    {
                        t = "نود و نه";
                        break;
                    }

            } // switch (s)


            return t;
        }
        private static string c3d(string s,bool date)
        {
            string t = "";
            if (s.Length == 0) return ("");
            if (s.Length == 1) s = "00" + s;
            if (s.Length == 2) s = "0" + s;
            if (s == "000") return ("");

            string haveVa = "";
            if ((!(s.Substring(1, 2) == "00")) && (s.Substring(0, 1) != "0")) haveVa = " و ";
            t = f1(s.Substring(0, 1)) + haveVa + f2(s.Substring(1, 2),date);
            return t;
        }
        public static string NumberToText(string s,bool date)
        {
            string t = "";
            if (s.Length == 0) return ("نامشخص");
            if (s.Length == 1) s = "00000000000000" + s;
            if (s.Length == 2) s = "0000000000000" + s;
            if (s.Length == 3) s = "000000000000" + s;
            if (s.Length == 4) s = "00000000000" + s;
            if (s.Length == 5) s = "0000000000" + s;
            if (s.Length == 6) s = "000000000" + s;
            if (s.Length == 7) s = "00000000" + s;
            if (s.Length == 8) s = "0000000" + s;
            if (s.Length == 9) s = "000000" + s;
            if (s.Length == 10) s = "00000" + s;
            if (s.Length == 11) s = "0000" + s;
            if (s.Length == 12) s = "000" + s;
            if (s.Length == 13) s = "00" + s;
            if (s.Length == 14) s = "0" + s;
            if (s == "000000000000000") return ("صفر");



            if (!(s.Substring(0, 3) == "000"))
            {
                t = t + c3d((s.Substring(0, 3)), date) + " هزار";
                if (!(s.Substring(3, 12) == "000000000000"))
                {
                    if (!(s.Substring(3, 3) == "000"))
                        t = t + " و ";
                }
            }

            if (!(s.Substring(3, 3) == "000"))
            {
                t = t + c3d((s.Substring(3, 3)), date) + " ميليارد";
                if (!(s.Substring(6, 9) == "000000000")) t = t + " و ";
            }
            else
            {
                if (!(s.Substring(0, 3) == "000")) t = t + " ميليارد و";
            }

            if (!(s.Substring(6, 3) == "000"))
            {
                t = t + c3d((s.Substring(6, 3)), date) + " ميليون";
                if (!(s.Substring(9, 6) == "000000")) t = t + " و ";
            }

            if (!(s.Substring(9, 3) == "000"))
            {
                t = t + c3d((s.Substring(9, 3)), date) + " هزار";
                if (!(s.Substring(12, 3) == "000")) t = t + " و ";
            }

            if (!(s.Substring(12, 3) == "000"))
            {
                t = t + c3d((s.Substring(12, 3)), date);
            }


            return t;
        }

        private static string cMonth(string s)
        {
            switch (s)
            {
                case "01":
                    {
                        return "فروردين";
                        break;
                    }
                case "02":
                    {
                        return "ارديبهشت";
                        break;
                    }
                case "03":
                    {
                        return "خرداد";
                        break;
                    }
                case "04":
                    {
                        return "تير";
                        break;
                    }
                case "05":
                    {
                        return "مرداد";
                        break;
                    }
                case "06":
                    {
                        return "شهريور";
                        break;
                    }
                case "07":
                    {
                        return "مهر";
                        break;
                    }
                case "08":
                    {
                        return "آبان";
                        break;
                    }
                case "09":
                    {
                        return "آذر";
                        break;
                    }
                case "10":
                    {
                        return "دي";
                        break;
                    }
                case "11":
                    {
                        return "بهمن";
                        break;
                    }
                case "12":
                    {
                        return "اسفند";
                        break;
                    }
            }

            return ("Err");
        }
        public static string DateToText(string s)
        {
            if (s.Length != 10) return "";
            if ((s.Substring(8, 2)) == "30")
                return ("" + NumberToText(s.Substring(8, 2), true) + " ام " + cMonth(s.Substring(5, 2)) + " " + NumberToText(s.Substring(0, 4), false) + "");
            else if ((s.Substring(8, 2)) == "23")
            {
                string ss =  NumberToText(s.Substring(8, 2), true);
                return ("" + ss.Remove(ss.Length-1,1) + "وم " + cMonth(s.Substring(5, 2)) + " " + NumberToText(s.Substring(0, 4), false) + "");
            }
            else
                return ("" + NumberToText(s.Substring(8, 2), true) + "م " + cMonth(s.Substring(5, 2)) + " " + NumberToText(s.Substring(1, 4), false) + "");
        }
        public static string DateToText(string s,int yearnumber)
        {
            int start = 2;
            int end = 2;
            if (yearnumber == 2)
            {
                start = 2;
                end = 2;
            }
            if (yearnumber == 3)
            {
                start = 1;
                end = 3;
            }
            if (yearnumber == 4)
            {
                start = 0;
                end = 4;
            }


            if (s.Length != 10) return "";
            if ((s.Substring(8, 2)) == "30")
                return ("" + NumberToText(s.Substring(8, 2), true) + " ام " + cMonth(s.Substring(5, 2)) + " " + NumberToText(s.Substring(start, end), false) + "");
            else if ((s.Substring(8, 2)) == "23")
            {
                string ss = NumberToText(s.Substring(8, 2), true);
                return ("" + ss.Remove(ss.Length - 1, 1) + "وم " + cMonth(s.Substring(5, 2)) + " " + NumberToText(s.Substring(start, end), false) + "");
            }
            else
                return ("" + NumberToText(s.Substring(8, 2), true) + "م " + cMonth(s.Substring(5, 2)) + " " + NumberToText(s.Substring(start, end), false) + "");
        }
    }
}
