using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace consoleProject
{
    internal class ComplexNumber: ICloneable, IComparable, IDisposable, HalfOfNumber
    {
        public int a;
        private char complex_number = 'i';
        public int b;

        public void PrintComplexNumber()
        {
            Console.WriteLine($"{a} + {b}{complex_number}");
        }
        public void GetMultiplicationByNumber()
        {
            Console.WriteLine("\nВведите любое натуральное число:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"умножение комплексного числа на натуральное: {n * a} + {n * b}{complex_number}");
        }

        public double Half (double a)
        {
            return a / 2; 
        }
        public object Clone()
        {
            return new ComplexNumber(a, b);
        }
       
        public void Dispose() 
        {
            Console.WriteLine($"Комплексное число с действительной частью {a} удалено");
        }

        public int CompareTo(object? o) 
        {
            if (o is ComplexNumber cn) return a.CompareTo(cn.a);
            else return 0;
        }

        public ComplexNumber(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
    }
}
