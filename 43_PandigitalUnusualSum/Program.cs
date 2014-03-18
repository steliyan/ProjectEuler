using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _43_PandigitalUnusualSum
{
    class Program
    {
        static int[] digits;
        static int digitsCount;
        static Dictionary<int, int> tripletsDivisibility;

        static void Initialize()
        {
            digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            digitsCount = digits.Length;

            tripletsDivisibility = new Dictionary<int, int>();
            tripletsDivisibility.Add(1, 2);
            tripletsDivisibility.Add(2, 3);
            tripletsDivisibility.Add(3, 5);
            tripletsDivisibility.Add(4, 7);
            tripletsDivisibility.Add(5, 11);
            tripletsDivisibility.Add(6, 13);
            tripletsDivisibility.Add(7, 17);
        }

        static long GetNumberFromArray(int startIndex, int length)
        {
            long result = 0;

            for (int i = startIndex; i < startIndex + length; i++)
            {
                result = result * 10 + digits[i];
            }

            return result;
        }

        static bool IsSpecialNumber()
        {
            foreach (var item in tripletsDivisibility)
            {
                int startIndex = item.Key;
                int divisor = item.Value;

                long triplet = GetNumberFromArray(startIndex, 3);
                bool isDivisble = triplet % divisor == 0;

                if (!isDivisble)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Initialize();

            long sumOfUnusualPandigitals = 0;
            while (!Permutations.NextPermutation(digits))
            {
                if (IsSpecialNumber())
                {
                    long specialPandigital = GetNumberFromArray(0, digitsCount);
                    sumOfUnusualPandigitals += specialPandigital;
                }
            }

            Console.WriteLine("Sum of unusual number is: {0}", sumOfUnusualPandigitals);
        }
    }
}
