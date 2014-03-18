using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _32_PandigitalNumbers
{
    class Program
    {
        static bool IsPandigital(int multiplicand, int multiplier, int product)
        {
            const int N = 9; // digits count
            int digitCount = 0;
            bool[] digits = new bool[N];

            while(multiplicand != 0)
            {
                int digit = multiplicand % 10;
                multiplicand /= 10;

                if(digit == 0 || digits[digit-1] == true)
                    return false;

                digitCount++;
                digits[digit-1] = true;
            }

            while(multiplier != 0)
            {
                int digit = multiplier % 10;
                multiplier /= 10;

                if(digit == 0 || digits[digit-1] == true)
                    return false;

                digitCount++;
                digits[digit-1] = true;
            }

            while(product != 0)
            {
                int digit = product % 10;
                product /= 10;

                if(digit == 0 || digits[digit-1] == true)
                    return false;

                digitCount++;
                digits[digit-1] = true;
            }

            return (digitCount == 9);
        }

        static int DigitCount(int number)
        {
            int count = 0;

            while(number != 0)
            {
                count++;
                number /= 10;
            }

            return count;
        }

        static void Main(string[] args)
        {
            const int LOW = 1;
            const int HIGH = 10000;
            List<int> pandigital = new List<int>();

            for(int i = LOW; i <= HIGH; i++)
            {
                for(int j = LOW + i; j < HIGH; j++)
                {
                    int product = i * j;
                    int digitCount = DigitCount(i) + DigitCount(j) + DigitCount(product);

                    if(digitCount != 9)
                        continue;
                    
                    //Console.WriteLine("{0}*{1} = {2} - {3}", i, j, product, digitCount);

                    if(digitCount != 9)
                        continue;

                    if(IsPandigital(i, j, product))
                        pandigital.Add(product);
                }
            }

            pandigital = pandigital.Distinct().ToList();

            int sum = 0;
            for(int i = 0; i < pandigital.Count; i++)
            {
                sum += pandigital[i];
                Console.WriteLine(pandigital[i]);
            }

            Console.WriteLine("Sum: {0}", sum);

            
        }
    }
}
