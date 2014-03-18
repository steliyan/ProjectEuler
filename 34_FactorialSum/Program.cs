using System;

namespace _34_FactorialSum
{
    class Program
    {
        const int N = 10;
        static int[] factorial = new int[N];

        static void Precalculate()
        {
            for(int i = 0; i < factorial.Length; i++)
            {
                int result = 1;

                for(int j = 1; j <= i; j++)
                    result *= j;

                factorial[i] = result;
            }
        }

        static int SumDigits(int number)
        {
            int result = 0;

            while(number != 0)
            {
                int digit = number % 10;

                result += factorial[digit];

                number /= 10;
            }

            return result;
        }

        static void Main(string[] args)
        {
            const int MAX = 50000; // why?!
            int sum = 0;

            Precalculate();

            for(int i = 3; i < MAX; i++)
                if(i == SumDigits(i))
                {
                    sum += i;
                    Console.WriteLine(i);
                }

            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
