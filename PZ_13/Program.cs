using System.Threading.Channels;

namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // номер 1
            Console.WriteLine("Задание для арифметической прогрессии"); 
            double a = 0.3;
            double d = 0.2;
            int n = 4;
            Arifmetic(a, d, n);        
            // Номер 2
            Console.WriteLine("Задание для геометрической прогрессии"); 
            int b = 13;
            double q = -0.01; 
            int n1 = 4;
            Geo(b, q, n1);        
            // Номер 3
            Console.WriteLine("задание 3"); 
            int value1 = 6;
            int value2 = -48; 
            third(value1, value2);
            // Номер 4
            Console.WriteLine("Задание 4");
            Console.WriteLine("Введите число до которого будет считаться сумма"); 
            int x = int.Parse(Console.ReadLine());
            int y = 0; 
            int result = Summ(x, ref y);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        static double Arifmetic(double a, double d, int n) // Функция для 1 задания    
        {
            if (n == 0)
            {
                return a;
            }
            else
            {
                Console.WriteLine(a);
                a += d; Arifmetic(a, d, n - 1);

            }
            return a;
        }
        static double Geo(double b, double q, int n1)// Функция для 2 задания    
        {
            if (n1 == 0)
                return b;
            else
            {
                Console.WriteLine(b); b *= q;
                Geo(b, q, n1 - 1);
            }
            return b;
        }
        static void third(int value1, int value2) // Функция для 3 задания
        {
            if (value1 == value2)
            {
                Console.WriteLine(value1);
                return;
            }
            Console.WriteLine(value2); 
            third(value1 , value2 + 1);
        }
        static int Summ(int x, ref int n) // Функция для 4 задания    
        {
            if (x == 0)
            {
                return n;
            }
            else
            {
                n += x;
            }
            Summ(x-1, ref n);        
            return n;

        }

        


    
}
}