using System;
using System.Collections.Generic;
using System.IO;

namespace _42_TriangleNumbers
{
	class Program
	{
		private static string inputFile = "../../words.txt";
		private static string[] words;

		private static readonly int maxTriangleNumberIndex = 100;
		private static HashSet<int> triangleNumbers = new HashSet<int>();

		static void ReadDataToArray()
		{
			StreamReader reader = new StreamReader(inputFile);
			string wholeFile = reader.ReadToEnd();

			words = wholeFile.Split(new char[] { '\"', ',' }, StringSplitOptions.RemoveEmptyEntries);
		}

		static void CalculateTriangleNumbers()
		{
			for(int i = 1; i <= maxTriangleNumberIndex; i++)
			{
				int triangleNumber = (i + 1) * i / 2;

				triangleNumbers.Add(triangleNumber);
			}
		}

		static int WordWeight(string word)
		{
			int letterSum = 0;

			foreach(var ch in word)
			{
				letterSum += (ch - 'A' + 1);
			}

			return letterSum;
		}

		static int CountTriangleWords()
		{
			int triangleWords = 0;

			foreach(var word in words)
			{
				int wordWeight = WordWeight(word);

				if(triangleNumbers.Contains(wordWeight))
				{
					triangleWords++;
				}
			}

			return triangleWords;
		}

		static void Main(string[] args)
		{
			CalculateTriangleNumbers();
			ReadDataToArray();

			int triangleWordsCount = CountTriangleWords();

			Console.WriteLine(triangleWordsCount);
		}
	}
}
