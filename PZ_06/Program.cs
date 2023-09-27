namespace PZ_06
{
    using System;

    class Program
    {
        static void Main()
        {
            int[] array = new int[10];
            Random rand = new Random();

            // Заполняем массив случайными числами в интервале [-10..10]
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-10, 11);
            }

            // Реверсируем все элементы, кроме последнего
            for (int i = 0; i < array.Length - 1; i++)
            {
                int temp = array[i];
                array[i] = array[array.Length - i - 2];
                array[array.Length - i - 2] = temp;
            }

            // Выводим массив на экран
            Console.WriteLine("Массив после реверса:");
            foreach (int element in array)
            {
                Console.Write(element + " ");
            }

            Console.ReadKey();
        }
    }
}