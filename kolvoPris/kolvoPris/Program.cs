using System;

namespace kolvoPris
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = new int[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                Array[i] = i + 1;
            }
            var rnd = new Random();
            for (int i = 999999; i >= 0; i--)
            {
                int z = Array[i];
                int j = rnd.Next(0, i);
                Array[i] = Array[j];
                Array[j] = z;
            }
            int max = Array[0];
            int k = 1;
            for (int i = 0; i < 1000000; i++)
            {
                if (max < Array[i])
                {
                    max = Array[i];
                    k++;
                }
            }
            Console.WriteLine("кол-во присваиваний = " + k + " макс значение= " + max);
        }
    }
}
