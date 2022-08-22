using System;
namespace CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string utc = DateTime.UtcNow.ToString();
            string E = "10:21";
            string L = "13:51";
            string Price = Sol(E, L).ToString();
            Console.WriteLine(utc + " " + E + " " + L + " Cost: " + Price);
            try
            {
                int SE = Int32.Parse(Price);
                //int SL = Int32.Parse(L);
                //int Sol = SE - SL;
                Console.WriteLine(SE);

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            if (Int32.TryParse("1121", out int j)) 
            { 
                Console.WriteLine(j); 
            }
            else 
            { 
                Console.WriteLine("String not parsed."); 
            }
            try 
            { 
                int m = Int32.Parse("ABC"); 
            }
            catch (FormatException e) 
            { 
                Console.WriteLine(e.Message); 
            }
            const string inStr = "1233";
            if(Int32.TryParse(inStr, out int numVal)) 
            { 
                Console.WriteLine(numVal); 
            }
            else 
            { 
                Console.WriteLine($"Int32.TryParse couldn't parse {inStr}"); 
            }
            // Parsing mixed characters.
            var str = "  1415";
            string numStr = string.Empty;
            foreach(var c in str)
            {
                if((c>= '0' && c<= '9') || (char.ToUpperInvariant(c)>= 'A' && char.ToUpperInvariant(c) <= 'F') || c == ' ')
                {
                    numStr = String.Concat(numStr, c.ToString());
                }
                else { break; }
            }
            if (int.TryParse(numStr, System.Globalization.NumberStyles.HexNumber, null, out int i))
            {
                Console.WriteLine($"'{str}' --> '{numStr}' --> {i}");
            }
            str = "   1839";
            numStr = "";
            foreach(char c in str)
            {
                if((c>= '0' && c <= '9') || c == ' ' || c == '-')
                { 
                    numStr = String.Concat(numStr, c); 
                }
                else { break; }
            }
            if (int.TryParse(numStr, out int k))
            { 
                Console.WriteLine($"'{str}' --> '{numStr}' --> {k}"); 
            }
            // Enter numbers for incrementation with in range.
            int numVals = -1;
            bool rep = true;
            while (rep)
            {
                Console.Write("Enter a number between -2,147,483,648 and +2,147,483,647: ");
                string input = Console.ReadLine();
                try
                {
                    numVals = Convert.ToInt32(input);
                    if (numVals < Int32.MaxValue)
                    {
                        Console.WriteLine("The new value is {0}", ++numVals);
                    }
                    else { Console.WriteLine("Value can't be incremented past the Maximum."); }

                }
                catch (FormatException) 
                { 
                    Console.WriteLine("Input string is not a sequence of digits."); 
                }
                catch (OverflowException) 
                { 
                    Console.WriteLine("The number cannot fit into Int32."); 
                }
                Console.WriteLine("Try again? Y for Yes or N for No: ");
                string? go = Console.ReadLine();
                if (go != null && go.ToUpper() != "Y") 
                { 
                    rep = false; 
                }
            }
            DateTime dtNow = DateTime.Now;
            Console.WriteLine(dtNow.ToString());
            Console.WriteLine(dtNow.ToShortDateString());
            Console.WriteLine(dtNow.ToShortTimeString());
            Console.WriteLine(dtNow.ToLongDateString());
            Console.WriteLine(dtNow.ToLongTimeString());
            Console.WriteLine(dtNow.AddDays(3).ToLongDateString());
            Console.WriteLine(dtNow.AddHours(3).ToLongTimeString());
            Console.WriteLine(dtNow.AddDays(-3).ToLongDateString());
            Console.WriteLine(dtNow.Month);
            DateTime startDate = new DateTime(1969, 12, 7);
            Console.WriteLine(startDate.ToShortDateString());
            Console.WriteLine(startDate.ToShortTimeString());
            DateTime beginDate = DateTime.Parse("07:33");
            TimeSpan timeSpan = DateTime.Now.Subtract(beginDate);
            Console.WriteLine(timeSpan.TotalDays*24);
            Console.ReadLine();
        }
        public static int Sol(string E, string L)
        {
            /*int SE = Int32.Parse(E);
            int SL = Int32.Parse(L);
            int Sol = SE - SL;*/
            int Fee = 2;
            int Hour = 3;
            int Hours = 4;
            float Period = 1;
            /*double elipsed = 0;
            int EH = 10;
            int EM = 33;
            int LH = 13;
            int LM = 33;*/
            int Cost = 0;
            DateTime enterTime = DateTime.Parse(E);
            DateTime leftTime = DateTime.Parse(L);
            TimeSpan elipsedTime = (-1 * (enterTime.Subtract(leftTime)));
            Console.WriteLine(elipsedTime.TotalHours);
            //string duration = elipsedTime.ToString();
            //Hours = Convert.ToSingle((TimeSpan)elipsedTime);
            //Console.WriteLine(Hours);
            if (elipsedTime.TotalHours <= 1.0)
            {
                Cost = Fee + Hour;
            }
            if (elipsedTime.TotalHours > 1.0)
            {
                Period = (float)elipsedTime.TotalHours;
                int multiPeriod = ((int)Period - 1); 
                Cost = Fee + Hour + (Hours*multiPeriod);
                Console.WriteLine($"Cost: {Cost} --> " + Cost);
            }
            /*if (LH - EH <= 1) 
            {
                if (LM - EM > 0 && LM - EM <= 59)
                {
                }
            }
            if (LH - EH > 1) 
            { 
                if ( LM - EM > 0 && LM - EM <= 59)
                {
                    Hours = LH - EH - 1 + 1;  
                    //Cost = Fee + Hour + (Over * Hours); 
                }
                else
                {
                    Hours = LH - EH - 1;
                    //Cost = Fee + Hour + (Over * Hours);
                }
            }*/
            
            return Cost;
        }
    }
}