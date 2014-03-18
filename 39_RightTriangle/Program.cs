using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _39_RightTriangle
{
	class Program
	{
		static void BruteForce(int MAX)
		{
			int maxCount = 0;
			int maxPerimeter = 0;
			for(int p = 3; p <= MAX; p++)
			{
				int count = 0;
				int perimeter = 0;
				for(int a = 1; a <= p; a++)
				{
					for(int b = a + 1; b <= p; b++)
					{
						for(int c = b + 1; c <= p; c++)
						{

							if(a + b + c == p && (a * a + b * b) == c * c)
							{
								count++;
								perimeter = a + b + c;
							}
						}
					}
				}

				if(maxCount < count)
				{
					maxPerimeter = perimeter;
					maxCount = count;
				}
			}

			Console.WriteLine("Perimeter: {0}", maxPerimeter);
			Console.WriteLine("Count: {0}", maxCount);
		}

		static void BruteForce2(int MAX)
		{
			int maxCount = 0;
			int maxPerimeter = 0;
			for(int p = 3; p <= MAX; p++)
			{
				int count = 0;
				int perimeter = 0;
				for(int a = 1; a <= p/2; a++)
				{
					for(int b = a + 1; b <= p-a; b++)
					{
						if((a % 2 == 1 && b % 2 == 0) || (a % 2 == 0 && b % 2 == 1))
							continue;

						for(int c = 1; c <= p/2; c++)
						{

							if(a + b + c == p && (a * a + b * b) == c * c)
							{
								count++;
								perimeter = a + b + c;
							}
						}
					}
				}

				if(maxCount < count)
				{
					maxPerimeter = perimeter;
					maxCount = count;
				}
			}

			Console.WriteLine("Perimeter: {0}", maxPerimeter);
			Console.WriteLine("Count: {0}", maxCount);
		}

		static void Main(string[] args)
		{
			int MAX = 1000;


			BruteForce2(MAX);
			
		}
	}
}
