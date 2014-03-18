using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _38_PandigitalMultiplier
{
	class Program
	{
		static bool IsPandigital(string number)
		{
			if(number.Length != 9)
				return false;

			const int N = 9;
			bool[] digits = new bool[N];

			for(int i = 0; i < N; i++)
			{
				int digit = number[i] - '0';

				if(digit == 0 || digits[digit-1] == true)
					return false;

				digits[digit-1] = true;
			}

			return true;
		}



		static void Main(string[] args)
		{
			for(int number = 9; number < 10000; number++)
			{
				StringBuilder result = new StringBuilder();

				for(int multiplier = 1; multiplier <= 10; multiplier++)
				{
					if(result.Length == 9 && IsPandigital(result.ToString()))
					{
						Console.WriteLine(number + " " + result + " " );
						break;
					}

					int tempResult = number * multiplier;

					result.Append(tempResult.ToString());
				}
			}
		}
	}
}
