using System;

namespace _27_QuadraticFormula
{
    class Program
    {
        static bool IsPrime(long number)
        {
            if(number % 2 == 0)
                return false;

            long sqrtNumber = (long)Math.Sqrt(Math.Abs(number));

            for(long i = 3; i <= sqrtNumber; i += 2)
                if(number % i == 0)
                    return false;

            return true;
        }

        static void Main(string[] args)
        {
            const int N = 1000;

            int aCoef = 0;
            int bCoef = 0;
            int totalCount = 0;

                for(int a = -N; a < N; a++)
                {
                    for(int b = -N; b < N; b++)
                    {
                        int count = 0;

                        for(int i = 0; i < 100; i++)
                        {
                            long result = i * i + a * i + b;

                            if(IsPrime(result))
                                count++;
                            else
                                break;
                        }

                        if(count > totalCount)
                        {
                            aCoef = a;
                            bCoef = b;
                            totalCount = count;
                        }
                    }

                }

            Console.WriteLine("{0}*{1} = {2}", aCoef, bCoef, aCoef*bCoef);
            Console.WriteLine(totalCount);
        }
    }
}
