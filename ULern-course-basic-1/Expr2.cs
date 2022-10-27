using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULern_course_basic_1
{
    internal class Expr2
    {
        public static void Reverse(int number)
        {
            
            string numString = number.ToString();
            
            
            char[] chars = numString.ToCharArray();

            Array.Reverse(chars);

            number = int.Parse(chars);

            Console.WriteLine(number);

        }
    }
}