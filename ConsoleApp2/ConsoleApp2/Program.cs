using System;
using System.Linq;

//Console.WriteLine(" первое и второе задание");
//Random random = new Random();
//string[][] array = new string[9][];
//for (int i = 0; i < array.Length; i++)
//{
//    for (int j = 0; j < 9; j++)
//    {
//        array[j] = new string[random.Next(6, 16)];
//    }
//}

//String rndstr = ("qwertyuiopasdfghjklzxcvbnm");
//for (int i = 0; i < array.Length; i++)
//{
//    for (int j = 0; j < array[i].Length; j++)

//    {
//        array[i][j] = Convert.ToString(rndstr[random.Next(rndstr.Length)]);
//        Console.Write(array[i][j] + " ");
//    }
//    Console.WriteLine();
//}

//Console.WriteLine("задание 3");

// string[] lastelement = new string[15];
//Array.Reverse(array);
//Console.WriteLine(array);

using System;

class Program
{
    static void Main()
    {
        // Создание случайного числа для второго измерения
        Random random = new Random();
        int secondDimension = random.Next(7, 16);

        // Создание двумерного массива строк
        string[,] twoDimensionalArray = new string[9, secondDimension];

        // Заполнение двумерного массива случайными строками
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < secondDimension; j++)
            {
                twoDimensionalArray[i, j] = GenerateRandomString();
            }
        }

        // Создание нового одномерного массива и запись в него последних элементов каждой строки
        string[] newArray = new string[9];
        for (int i = 0; i < 9; i++)
        {
            newArray[i] = twoDimensionalArray[i, secondDimension - 1];
        }

        // Вывод нового одномерного массива
        Console.WriteLine("Результат:");
        foreach (string element in newArray)
        {
            Console.WriteLine(element);
        }

        Console.ReadLine();
    }

    // Метод для генерации случайной строки
    static string GenerateRandomString()
    {
        const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        Random random = new Random();
        char[] stringArray = new char[10];
        for (int i = 0; i < 10; i++)
        {
            stringArray[i] = characters[random.Next(characters.Length)];
        }
        Console.WriteLine(characters);
        return new string(stringArray);
        
    }
    
}