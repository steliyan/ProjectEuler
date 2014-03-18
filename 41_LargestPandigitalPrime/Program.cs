using System;
using System.Collections.Generic;
using System.Collections;

namespace _41_LargestPandigitalPrime
{
	class Program
	{
		static readonly int MAX = 1000000000;
		static readonly int sqrtMAX = (int)Math.Sqrt(MAX);
		static bool[] isComposite = new bool[MAX];

		static void InitPrimes()
		{
			isComposite[0] = false;
			isComposite[1] = true;

			for(int i = 2; i <= sqrtMAX; i++)
			{
				if(isComposite[i] == false)
				{
					for(int j = i * i; j < MAX; j += i)
					{
						isComposite[j] = true;
					}
				}
			}

			Console.WriteLine("Prime numbers initialized!");
		}

		static readonly int digits = 9;

		static bool IsPandigital(int number)
		{
			bool isPandigital = true;
			BitArray bitSet = new BitArray(digits);

			while(number != 0)
			{
				int digitPosition = (number % 10) - 1;
				number /= 10;

				if(digitPosition < 0 || bitSet[digitPosition])
				{
					isPandigital = false;
					break;
				}
				else
				{
					bitSet[digitPosition] = true;
				}
			}


			bool nullBit = false;
			for(int i = 0; i < digits; i++)
			{
				if(nullBit && bitSet[i])
				{
					return false;
				}
				if(!bitSet[i])
				{
					nullBit = true;
				}

			}

			return isPandigital;
		}

		static void Main(string[] args)
		{
			InitPrimes();

			Console.WriteLine("Searching..");

			for(int i = MAX - 1; i > 0; i--)
			{
				if(!isComposite[i] && IsPandigital(i))
				{
					Console.WriteLine(i);
					break;
				}
			}
		}
	}
}
