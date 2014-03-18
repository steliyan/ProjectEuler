using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _33_CuriousFractions
{
    class Fraction
    {
        private int numerator;
        private int denominator;

        public static int GCD(int a, int b)
        {
            while(b != 0)
            {
                int tmp = b;
                b = a % b;
                a = tmp;
            }

            return a;
        }

        public static int LCM(int a, int b)
        {
            return a * b / GCD(a, b);
        }

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }

        public static Fraction Normalize(Fraction fraction)
        {
            int gcd = GCD(fraction.numerator, fraction.denominator);

            if(gcd != 1)
            {
                fraction.numerator /= gcd;
                fraction.denominator /= gcd;
            }

            return fraction;
        }

        public double DecimalValue
        {
            get
            {
                if(denominator != 0) 
                    return (double)numerator / denominator;

                return -1;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(numerator.ToString() + '/' + denominator.ToString());

            return result.ToString();
        }

        public Fraction()
        { }

        public Fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int LOW = 11;
            const int HIGH = 100;

            for(int i = LOW; i < HIGH; i++)
            {
                for(int j = i + 1; j < HIGH; j++)
                {
                    double mainFraction = (double)i / j;

                    if(i % 10 == j % 10 && i % 10 != 0)
                        if((double)(i / 10) / (j / 10) == mainFraction)
                            Console.WriteLine(i + " " + j);

                    if(i / 10 == j % 10 && i % 10 != 0)
                        if((double)(i % 10) / (j / 10) == mainFraction)
                            Console.WriteLine(i + " " + j);

                    if(i % 10 == j / 10 && i % 10 != 0)
                        if((double)(i / 10) / (j % 10) == mainFraction)
                            Console.WriteLine(i + " " + j);

                    if(i / 10 == j / 10 && i % 10 != 0)
                        if((double)(i % 10) / (j % 10) == mainFraction)
                            Console.WriteLine(i + " " + j);
                }
            }

            // calc by hand ;)
        }
    }
}
