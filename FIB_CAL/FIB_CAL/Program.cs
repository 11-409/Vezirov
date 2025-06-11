using System;

namespace FibonacciCalc
{
    class Program
    {
        static void Main()
        {
            Console.Write("Можете ли вы определить, какое число Фибоначчи? ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0)
            {
                long result = FibMatrix(index);
                Console.WriteLine($"Fibonacci({index}) = {result}");
            }
            else
            {
                Console.WriteLine("Не был введен действительный номер.");
            }
        }

        static long FibMatrix(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;

            long[,] baseMatrix = new long[2, 2] { { 1, 1 }, { 1, 0 } };
            long[,] finalMatrix = Identity();

            int power = n - 1;
            while (power > 0)
            {
                if ((power & 1) == 1)
                    finalMatrix = Multiply2x2(finalMatrix, baseMatrix);

                baseMatrix = Multiply2x2(baseMatrix, baseMatrix);
                power >>= 1;
            }

            return finalMatrix[0, 0];
        }

        static long[,] Multiply2x2(long[,] a, long[,] b)
        {
            return new long[2, 2]
            {
                { a[0,0]*b[0,0] + a[0,1]*b[1,0], a[0,0]*b[0,1] + a[0,1]*b[1,1] },
                { a[1,0]*b[0,0] + a[1,1]*b[1,0], a[1,0]*b[0,1] + a[1,1]*b[1,1] }
            };
        }

        static long[,] Identity()
        {
            return new long[2, 2] { { 1, 0 }, { 0, 1 } };
        }
    }
}
