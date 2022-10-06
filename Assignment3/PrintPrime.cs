using System;
namespace Assignment3
{
    public class PrintPrime
    {
        public static void Main(string[] args)
        {
          Prime(0,100);
          Prime(101,200);
          Console.ReadKey();
        }
        static async Task Prime(int a, int b)
        {
            await Task.Run(() =>
            {
                for (int i = a; i <= b; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write(i + " ");
                    }
                }
            });
        }
          static bool IsPrime(int a)
        {
            bool isPrime = true;
            if (a < 2)
            {
                isPrime = false;
                return isPrime;
            }
            else
            {
                for (int i = 2; i < a; i++)
                {
                    if (a % i == 0)
                    {
                        isPrime = false;
                        return isPrime;
                    }
                }
                isPrime = true;
                return isPrime;
            }
        }
    }
}