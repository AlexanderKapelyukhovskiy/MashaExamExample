using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GetRandom(10);
        }
        static int FibonacciSeries(int n)
        {
            int firstnumber = 0, secondnumber = 1, result = 0;

            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   


            for (int i = 2; i <= n; i++)
            {
                result = firstnumber + secondnumber;
                if (i != n)
                {
                    firstnumber = secondnumber;
                    secondnumber = result;
                }

            }

            return 2*result - secondnumber;
        }

        static double F(int k, double x)
        {
            double s = 1 + x;
            for (int i = 1; i <= k; i++)
            {
                s += Math.Pow(x, i)/i;
            }
            return s/FibonacciSeries(k);
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

        static void GetRandom(int k)
        {
            var random = new Random();

            for (int i = 0; i <= 17000; i++)
            {
                double r = random.NextDouble()*2;
                try
                {
                    var value = P(k, r);
                    Console.WriteLine("P(" + r + ")=" + value);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception");
                }
            }
        }
    }

   
}
