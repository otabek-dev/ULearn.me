namespace ULern_course_basic_1
{
    public class Program
    {

        static int i = 0;

        static void Print(double text)
        {
            Console.WriteLine(text);
        }


        static double GetSquare(double number)
        {
            return Math.Pow(number, 2);
        }


        static string GetLastHalf(string text)
        {
            text = text.Substring(text.Length - (text.Length / 2));
            return text.Replace(" ", "");
        }


        static string Decode(string text)
        {
            /*
            //Console.WriteLine("Hello World"+a);
            //int result=-1;
            string resText = "";

            if (int.TryParse(text, out var result))
            {
                return int.Parse(text).ToString();
            }
            else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (int.TryParse(text[i].ToString(), out var number))
                        resText += text[i].ToString();
                }
            }


            //Console.WriteLine(int.TryParse(text[1].ToString(), out var number));
            */
             double a = double.Parse(text.Replace(".", "")) % 1024;
            
            return a.ToString();
            
        }



        


        public static void Main()
        {


            Console.WriteLine(Decode("0"));
            Console.WriteLine(Decode("123"));
            Console.WriteLine(Decode("1.23"));
            Console.WriteLine(Decode("1...2..3"));
            Console.WriteLine(Decode("1010"));
            Console.WriteLine(Decode("1025"));
            Console.WriteLine(Decode("1..02.6"));

            /*
            Print(GetSquare(42));
            int first = 100;
            int second = 20;
            Console.WriteLine("First: {0}\nSecond: {1}", first, second);

            Expr1.Swap(ref first, ref second);

            Console.WriteLine("First: {0}\nSecond: {1}", first, second);

            Console.WriteLine(second);

            Expr2.Reverse(123);

            Console.WriteLine("gg" + Math.Pow(100, 100));

            var valueExpr3 = int.Parse(Console.ReadLine());


            Console.WriteLine(Expr3.Deg(valueExpr3));
            

            //Console.WriteLine(GetLastHalf("I love CSharp!"));
            //Console.WriteLine(GetLastHalf("1234567890"));
            //Console.WriteLine(GetLastHalf("до ре ми фа соль ля си"));

            */
        }




    }





    class Sample2
    {
        static string who = "class";

        static void F()
        {
            string who = "F";
        }

        static void G()
        {

            F();
            Console.WriteLine(who);
        }

        static void H()
        {
            string who = "H";
            F();
            Console.Write(who);
        }
    }
    class Sample3
    {
        static string who = "class";

        static void Mixed()
        {
            string who = "Mixed";
            Console.Write(who + " ");
            Console.Write(who);
        }
    }
}