using System;

namespace ULern_course_basic_2
{
    internal class Program
    {

        public static void GetNumber(string text)
        {

            text.IndexOf(" ");

        }


        public static double Calculate(string text)
        {

            double result = 0;

            double money = double.Parse(text.Substring(0, text.IndexOf(" ")));
            text = text.Substring(text.IndexOf(" ") + 1);
            double procent = double.Parse(text.Substring(0, text.IndexOf(" ")));
            text = text.Substring(text.IndexOf(" ") + 1);
            int month = int.Parse(text.Substring(0));


            //for (int i = 0; i<month; i++)
            //{
            //    result += (money * (procent/100)) /12;
            //    money += result;
            //    result = 0;
            //}

            result = money * (Math.Pow((1 + (procent / (12 * 100))), month));



            return result;
        }

        public static int GetSum(int firstNumber, int lastNumber, int wall)
        {
            int sum = 0;
            int productNumber = firstNumber * lastNumber;

            for (int i = 1; i <= wall; i++)
            {
                //(i % firstNumber + i % lastNumber) == 0
                //i % firstNumber == 0 && i % lastNumber == 0
                if (i % productNumber == 0)
                {
                    Console.WriteLine(i);
                    sum += i;
                    
                }
            }

            return sum;
        }

        public static double GetSum2(int firstNumber, int lastNumber, int wall)
        {

            double result = 0;
            int productNumber = firstNumber * lastNumber;


            result = ((2*productNumber + productNumber*(66-1)) / 2)*66;

            return result;
        }

        static void Main()
        {


            Console.WriteLine("\n" + GetSum(3, 5, 1000));


            Console.WriteLine("\n" + GetSum2(3, 5, 1000));


            //var text = Console.ReadLine();

            //Console.WriteLine(Calculate(text));

        }


        public static bool IsIsogram(string str)
        {
            // Code on you crazy diamond!

            str = str.ToLower();

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; i++)
                {
                    if (str[i] == str[j])
                        return false;
                }
            }

            return true;
        }
    }
}
