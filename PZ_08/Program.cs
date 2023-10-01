namespace PZ_08
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
            for (int i = 0; i < arr.Length; i++)
            {
                string b = arr[i][0];
                string c = arr[i].Max();
                int n = Array.IndexOf(arr[i], c);
                arr[i][0] = c;
                arr[i][n] = b;
            }
            for (int i = 0; i < arr.Length; i++)
            {
               for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(); 
             
            for (int i = 0; i < arr.Length; i++) // Реверс каждой строки массива 
            { 
                Array.Reverse(arr[i]);  
            } 
 
             
            for (int i = 0; i < arr.Length; i++) // Вывод массива после реверса 
            { 
                for (int j = 0; j < arr[i].Length; j++) 
                { 
                    Console.Write(arr[i][j] + " ");  
                } 
                Console.WriteLine(); 
            } 
 
            Console.WriteLine(); 
            Console.WriteLine("Задание 7"); 
 
            int[] symbolCount = new int[arr.Length]; // Создаем массив symbolCount длины arr.Length для хранения количества символов в каждом элементе arr 
 
            for (int i = 0; i < arr.Length; i++) 
            { 
                symbolCount[i] = 0; 
                for (int j = 0; j < arr[i].Length; j++) 
                { 
                    symbolCount[i] += arr[i][j].Length; 
                } 
            } 
 
            for (int i = 0; i < arr.Length; i++) // Выводим каждый элемент arr, его элементы и количество символов в нем 
            { 
                for (int j = 0; j < arr[i].Length; j++) // Выводим каждый элемент внутреннего массива arr[i] с пробелом после него 
                { 
                    Console.Write(arr[i][j] + " "); 
                } 
                Console.Write("Количество символов: " + symbolCount[i]); 
                Console.WriteLine;
            }
        
        }
    }
}
