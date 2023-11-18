using System.Globalization;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1 и 2");
            Random random = new Random(); // объект рандом
            string[][] arr = new string[9][]; // наш массив

            for (int i = 0; i < arr.Length; i++)  // генирируем наш массив
            {
                for (int j = 0; j < 9; j++)
                {
                    arr[j] = new string[random.Next(6, 16)];
                }

            }
            Console.WriteLine();
            string rndStr = "qwertyuiopasdfghjklzxcvbnm";

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    string a = Convert.ToString(rndStr[random.Next(rndStr.Length)]);
                    arr[i][j] = a + a + a + a;
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(" Задание 3");
            string[] lastSimvol = new string[9];



            for (int i = 0; i < lastSimvol.Length; i++)
            {

                lastSimvol[i] = arr[i][^1];
                Console.Write(lastSimvol[i] + " ");

            }

            Console.WriteLine();
            Console.WriteLine(" задание 4 ");
            for (int i = 0; i < lastSimvol.Length; i++)
            {
                lastSimvol[i] = arr[i].Max();
                Console.Write(lastSimvol[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(" задание 5 ");




        }
    }
}