namespace ULern_course_basic_1
{
    internal class Expr3
    {
        internal static int Deg(int time)
        {
            if (time == 00 || time == 0) return 0;
            if (time == 12) return 0;
            if (time == 24) return 0;
            if (time > 24) return -1;

            if (time > 12)
            {
                time -= 12;
            }
            

            if (time <= 6) return time * 30;
            else return 360 - (time * 30);

        }

    }
}
