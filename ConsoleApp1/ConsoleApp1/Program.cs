namespace ConsoleApp1
{
    internal class Program
    {
        
    
        static void Main(string[] args)
        {
            Console.Write("Введите целое положительное число n: ");
            int n = int.Parse(Console.ReadLine());

            int m = n % 2 == 0 ? n + 1 : n; // установка флага нечетности

            int sum = 0;
            int i = m;
            while (i <= m * 2)
            {
                if (i % 2 != 0)
                {
                    sum += i; // суммирование всех нечетных чисел
                }
                i++;
            }

            Console.WriteLine($"Сумма всех нечетных чисел диапазона от {0} до {1}*2: {2}", m, m, sum);
        }
    }
}
