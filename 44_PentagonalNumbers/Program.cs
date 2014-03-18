using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _44_PentagonalNumbers
{
	class Program
	{
		static List<long> pentagonalNumbers = new List<long>();

		static public bool IsPentagonalNumber(long number)
		{
			double pentagonalNumberTest = (Math.Sqrt(24 * number + 1) + 1.0) / 6.0;

			return pentagonalNumberTest == ((long)pentagonalNumberTest);
		}

		static public long CalculatePentagonalNumber(int index)
		{
			long result = (3 * index * index - index) / 2;

			return result;
		}

		static void InitPentagonalNumbers(int max)
		{
			for(int i = 1; i <= max; i++)
			{
				long pentagonalNumber = CalculatePentagonalNumber(i);
				pentagonalNumbers.Add(pentagonalNumber);
			}
		}

		static void Main(string[] args)
		{
			const int max = 10000;
			InitPentagonalNumbers(max);

			for(int i = 1; i < max; i++)
			{
				for(int j = i; j < max; j++)
				{
					long sum = pentagonalNumbers[i] + pentagonalNumbers[j];

					if(!IsPentagonalNumber(sum))
					{
						continue;
					}

					long diff = Math.Abs(pentagonalNumbers[i] - pentagonalNumbers[j]);

					if(!IsPentagonalNumber(diff))
					{
						continue;
					}

					Console.WriteLine("{0} = |{1} - {2}|", diff, pentagonalNumbers[i], pentagonalNumbers[j]);
				}
			}
		}
	}
}
