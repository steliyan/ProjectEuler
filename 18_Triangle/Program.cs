using System;
using System.IO;
using System.Collections.Generic;

namespace _18_Triangle
{
    class Program
    {
        static List<List<int>> ReadTriangle(StreamReader reader)
        {
            string line;
            List<List<int>> triangle = new List<List<int>>();

            while((line = reader.ReadLine()) != null)
            {
                string [] items = line.Split(new char [] {' '}, StringSplitOptions.RemoveEmptyEntries);

                List<int> list = new List<int>();

                for(int i = 0; i < items.Length; i++)
                    list.Add(int.Parse(items[i]));

                triangle.Add(list);
            }

            return triangle;
        }
        static void PrintTriangle(List<List<int>> triangle)
        {
            for(int i = 0; i < triangle.Count; i++)
            {
                for(int j = 0; j < triangle[i].Count; j++)
                    Console.Write("{0, 2} ", triangle[i][j]);

                Console.WriteLine();
            }
        }
        static int FindMaxSum(List<List<int>> triangle)
        {
            for(int i = triangle.Count - 1; i > 0; i--)
            {
                for(int j = 0; j < triangle[i].Count - 1; j++)
                {
                    int max = Math.Max(triangle[i][j], triangle[i][j + 1]);

                    triangle[i - 1][j] += max;
                }
            }

            return triangle[0][0];
        }

        static void Main(string[] args)
        {
            string filename = @"c:/ProjectEuler/67.txt";
            StreamReader reader = new StreamReader(filename);
            
            List<List<int>> triangle = ReadTriangle(reader);
            //PrintTriangle(triangle);

            int maxSum = FindMaxSum(triangle);

            Console.WriteLine(maxSum);
        }
    }
}
