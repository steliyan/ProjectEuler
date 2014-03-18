using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _35_CircularPrimes
{
    class Program
    {
        const int MAX = 1000000;
        const int sqrtMAX = 1000;
        static bool[] isComposite = new bool[MAX];

        static void InitPrimes()
        {
            isComposite[0] = true;
            isComposite[1] = true;

            for(int i = 2; i <= sqrtMAX; i++)
                if(isComposite[i] == false)
                    for(int j = i * i; j < MAX; j += i)
                        isComposite[j] = true;
        }

        static int CountDigits(int number)
        {
            return (int)Math.Log10(number) + 1;
        }

        static int RotateLeft(int number)
        {
            int result = 0;
            int digitCount = CountDigits(number);
            int denominator = (int)Math.Pow(10, digitCount - 1);
            
            result = number % denominator;
            result = result*10 + number/denominator;

            return result;
        }

        static bool IsCircularPrime(int number)
        {
            int initDigits = CountDigits(number);

            for(int i = 0; i < initDigits - 1; i++)
            {
                number = RotateLeft(number);

                if(initDigits != CountDigits(number))
                    return false;

                if(isComposite[number] == true)
                    return false;
            }

            return true;
        }

        static void Main(string[] args)
        {
            InitPrimes();

            int count = 0;
            for(int i = 2; i < MAX; i++)
            {
                if(!isComposite[i] && IsCircularPrime(i))
                {
                    Console.WriteLine(i);
                    count++;
                }
            }

            Console.WriteLine("Circular primes count: {0}", count);
        }
    }
}
