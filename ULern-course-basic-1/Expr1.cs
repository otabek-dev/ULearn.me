using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULern_course_basic_1
{
    internal class Expr1
    {
        public static void Swap(ref int a,ref int b)
        {
            int c;
            
            //c = a;
            //a = b;
            //b = c;

            (a,b)=(b,a);
        
        }

		
	}
}
