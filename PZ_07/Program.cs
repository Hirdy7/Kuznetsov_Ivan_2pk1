namespace PZ_07
{ 
using System;


class Program
{
    static void Main(string[] args)
    {
        // Ввод размеров матрицы
        Console.Write("Введите количество строк: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int m = int.Parse(Console.ReadLine());

        // Создание и заполнение матрицы
        int[,] matrix = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите элементы {i + 1}-й строки, разделенные пробелом:");
            string[] rowValues = Console.ReadLine().Split(' ');
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(rowValues[j]);
            }
        }

        // Поиск максимума среди наименьших элементов столбцов
        int maxOfMin = int.MinValue;
        for (int j = 0; j < m; j++)
        {
            int min = matrix[0, j];
            for (int i = 1; i < n; i++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
            if (min > maxOfMin)
            {
                maxOfMin = min;
            }
        }

        // Вывод результата
        Console.WriteLine($"Максимум из наименьших элементов столбцов: {maxOfMin}");
    }
}
   }

