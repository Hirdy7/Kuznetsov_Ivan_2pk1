
namespace PZ_09


{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "Введите любую строку:");
            string str = Console.ReadLine();
            str = str.Replace(" ", "");//удаляем пробелы
            for (int i = 0; i < str.Length - 1; i++)//пересчет строки
            {
            
                if (i != str.Length - 1)
                {
                     
                    if (str[i] != str[i + 1])//цикл для сравнения  символа с предыдущим
                        Console.Write(str[i]);//вывод символа
                        
                }
                
            }
            Console.Write(str[str.Length - 1]);//вывод последнего символа
           




        }

    }
}
