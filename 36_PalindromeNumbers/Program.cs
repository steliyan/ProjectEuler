using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _36_PalindromeNumbers
{
    class Program
    {
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

        static bool IsPalindrome(string str)
        {
            for(int i = 0, j = str.Length - 1; i < j; i++, j--)
                if(str[i] != str[j])
                    return false;

            return true;
        }

        static void Main(string[] args)
        {
            const int MAX = 1000000;
            long palindromeSum = 0;

            for(int i = 1; i <= MAX; i++)
            {
                if(i == ReverseNumber(i))
                {
                    string binary = Convert.ToString(i, 2);

                    if(IsPalindrome(binary))
                    {
                        Console.WriteLine(i + " " + binary);
                        palindromeSum += i;
                    }
                }
            }

            Console.WriteLine(palindromeSum);
            
        }
    }
}
