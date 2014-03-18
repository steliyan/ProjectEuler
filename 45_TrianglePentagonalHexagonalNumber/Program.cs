using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _45_TrianglePentagonalHexagonalNumber
{
	class Program
	{
		static public bool IsPentagonalNumber(int number)
		{
			double pentagonalNumberTest = (Math.Sqrt((double)24 * number + 1) + 1) / 6;

			return pentagonalNumberTest == ((int)pentagonalNumberTest);
		}

		static public int CalculateHexagonalNumber(int index)
		{
			int result = 2 * index * index - index;

			return result;
		}

		static void Main(string[] args)
		{
			// we start after the initial condition (i == 143)
			// we base our solution that every hex number is a triangle
			int i = 144;

			while(true)
			{
				int hexagonalNumber = CalculateHexagonalNumber(i);

				if(IsPentagonalNumber(hexagonalNumber))
				{
					Console.WriteLine(hexagonalNumber);
					break;
				}

				i++;
			}
		}
	}
}
