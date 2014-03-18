using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _31_Currency
{
    class Program
    {
        static int[] coins = { 1, 2, 5, 10, 20, 50, 100, 200 };
        static int coinsCount = coins.Length;
        
        static int sum = 200;
        static int maxCoins = 200;

        static int[,] table = new int[sum+1, sum+1];
        static bool[] exist = new bool[sum + 1];

        static void Init()
        {
            for(int i = 0; i < sum; i++)
                for(int j = 0; j < sum; j++)
                    table[i, j] = 0;

            for(int i = 0; i < sum; i++)
                exist[i] = false;

            for(int i = 0; i < coinsCount; i++)
                exist[coins[i]] = true;
        }

        static int Count(int sum, int max)
        {
            if(table[sum,max] > 0)
                return table[sum,max];
            else
            {
                if(sum < max)
                    max = sum;

                if(sum == max && exist[sum])
                    table[sum, max] = 1;

                for(int i = max; i > 0; i--)
                    if(exist[i])
                        table[sum, max] += Count(sum - i, i);
            }

            return table[sum,max];
            
        }

        static void Main(string[] args)
        {
            Init();

            Console.WriteLine(Count(sum, sum));
        }
    }
}
