using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleProject
{
    internal class Number: HalfOfNumber
    {
        public int a;
        public int b;
        private int v;

        public void PrintNumber()
        {
            Console.WriteLine($"нашм числа: {a} и {b}");
        }
        public void GetMultiplicationNumber()
        {
            Console.WriteLine("\nВведите любое натуральное число:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"умножение чисел на натуральное: {a} * {n} = {a * n} \n  {b} * {n} = {b * n} ");
        }

        public double Half (double a)
        {
            return a / 2; 
        }
        public Number(int a)
        {
            this.a = a;
            this.a = b;
        }

        public Number(int a, int v) : this(a)
        {
            this.v = v;
        }
    }
}
