using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _40_DecimalDigit
{
	class Program
	{
		static void Main(string[] args)
		{
			StringBuilder fraction = new StringBuilder();

			const int MAX_DIGIT_POSITION = 1000000;

			int number = 1;
			while(true)
			{
				fraction.Append(number.ToString());
				number++;

				if(fraction.Length >= MAX_DIGIT_POSITION)
				{
					break;
				}
			}

			int result = 1;
			for(int i = 1; i <= MAX_DIGIT_POSITION; i *= 10)
			{
				result *= (int)(fraction[i - 1] - '0');
			}

			Console.WriteLine("Result: {0}", result);
		}
	}
}
