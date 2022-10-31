namespace ArrayShift
{
    internal static class ArrayExtentions
    {
        public static void ShiftLeft(this int[] shiftArray, int kPosition)
        {
            for (int p = 0; p < kPosition; p++)
            { 
                var firstElement = shiftArray[0];

                for (int i = 0; i < shiftArray.Length - 1; i++)
                    shiftArray[i] = shiftArray[i + 1];
                
                shiftArray[shiftArray.Length - 1] = firstElement;
            }
        }

        public static void ShiftRight(this int[] shiftArray, int kPosition)
        {
            for (int p = 0; p < kPosition; p++)
            {
                var lastElement = shiftArray[shiftArray.Length - 1];
                for (int i = shiftArray.Length - 1; i > 0; i--)
                    shiftArray[i] = shiftArray[i - 1];
                
                shiftArray[0] = lastElement;
            }
        }

        public static void Print(this Array arr)
        {
            foreach (var e in arr)
                Console.Write(e + " ");
            Console.WriteLine();
        }
    }
}
