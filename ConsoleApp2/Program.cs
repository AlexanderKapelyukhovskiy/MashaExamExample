using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter k = ");
            string s = Console.ReadLine();
            if (int.TryParse(s, out int k))
            {
                var values = GetRandomCalculations(k);
                foreach (var value in values)
                {
                    Console.WriteLine("P(" + k + ", " + value.Key + ")=" + value.Value);
                }
            }
            else
            {
                Console.WriteLine("Entered value '" + s + "' is not a integer");
            }
        }

        static int FibonacciSeries(int n)
        {
            int firstnumber = 0, secondnumber = 1, result = 0;

            if (n == 0) return 0;
            if (n == 1) return 1;


            for (int i = 2; i <= n; i++)
            {
                result = firstnumber + secondnumber;
                if (i != n)
                {
                    firstnumber = secondnumber;
                    secondnumber = result;
                }

            }

            return 2 * result - secondnumber;
        }

        static double F(int k, double x)
        {
            double s = 1 + x;
            for (int i = 1; i <= k; i++)
            {
                s += Math.Pow(x, i) / i;
            }

            return s / FibonacciSeries(k);
        }

        static double P(int k, double x)
        {
            double res = 1;
            for (int i = 1; i <= k; i++)
            {
                res *= F(i, x);
            }

            return res;
        }

        static Dictionary<double, double> GetRandomCalculations(int k, int numberCount = 17000)
        {
            var random = new Random();
            var values = new Dictionary<double, double>();
            for (int i = 0; i <= numberCount; i++)
            {
                double r = random.NextDouble() * 2;
                while (values.ContainsKey(r))
                {
                    r = random.NextDouble() * 2;
                }

                values[r] = P(k, r);
            }

            return values;
        }
    }
}
