using System;
using System.Linq;

namespace _29_IntegerCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 100;

            double[] arr = new double[N * N];

            int currItem = 0;
            for(int a = 2; a <= N; a++)
                for(int b = 2; b <= N; b++)
                    arr[currItem++] = Math.Pow(a, b);
            
            Console.WriteLine(arr.Distinct().Count() - 1); // remove the ZERO
        }
    }
}
