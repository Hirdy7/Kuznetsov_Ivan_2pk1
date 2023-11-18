
namespace PZ_09


{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "Введите любую строку:");
            string str = Console.ReadLine();
            str = str.Replace(" ", "");
            for (int i = 0; i < str.Length - 1; i++)
            {
            
                if (i != str.Length - 1)
                {
                     
                    if (str[i] != str[i + 1])
                        Console.Write(str[i]);
                        
                }
                
            }
            Console.Write(str[str.Length - 1]);
           




        }

    }
}