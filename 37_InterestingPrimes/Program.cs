using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _37_InterestingPrimes
{
    class Program
    {
        static readonly int MAX = 100000000;
        static readonly int sqrtMAX = (int)Math.Sqrt(MAX);
        static bool[] isComposite = new bool[MAX];

        static void InitPrimes()
        {
            isComposite[0] = false;
            isComposite[1] = true;

            for(int i = 2; i <= sqrtMAX; i++)
            {
                if(isComposite[i] == false)
                {
                    for(int j = i * i; j < MAX; j += i)
                    {
                        isComposite[j] = true;
                    }
                }
            }
        }

        static int ReverseNumber(int number)
        {
            int result = 0;

            while(number != 0)
            {
                result = result * 10 + number % 10;
                number /= 10;
            }

            return result;
        }

        static bool IsInterestingPrime(int number)
        {
            if(isComposite[number])
            {
                return false;
            }

            int leftNumber = number;

            while(leftNumber != 0)
            {
                leftNumber /= 10;

                if(isComposite[leftNumber])
                {
                    return false;
                }
            }

            int rightNumber = number;
            int length = (int)Math.Log10(rightNumber) + 1;

            while(rightNumber != 0)
            {
                length--;

                rightNumber = rightNumber % (int)Math.Pow(10, length);

                if(isComposite[rightNumber])
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            InitPrimes();

            int sum = 0;
            for(int i = 10; i < MAX; i++)
            {
                if(IsInterestingPrime(i))
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }

            Console.WriteLine("Sum: {0}", sum);
        }
    }
}
