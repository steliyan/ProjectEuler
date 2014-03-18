using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _48_SelfPowers
{
    class Program
    {
        const int N = 1000;
        const long MAX = 10000000000;

        static void Main(string[] args)
        {
            BigInteger result = 0;
            for (int i = 1; i <= N; i++)
            {
                result += BigInteger.ModPow(i, i, MAX);
            }

            Console.WriteLine("Total result: {0}", result % MAX);
        }
    }
}
