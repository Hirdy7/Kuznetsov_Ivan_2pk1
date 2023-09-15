namespace pz_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Введите число e:");

            int e = int.Parse(Console.ReadLine());

            Console.WriteLine(" Введите число a:");

            double a = double.Parse(Console.ReadLine());// создаем и вводим две переменных с консоли типа double и int по заданию


            double z, x, r;// создаем три переменных типа double
            if (e > 9)
            {
                x = e - (a / (11 * (e - Math.Pow(a, 2))));// если е больше 10 делаем это выражение
            }
            else
            {
                x = Math.Cos(e - 3);// если x меньше или равен 9 делаем это
            }
            Console.WriteLine($"выводим {x} ");//выводим x
            if (x <= 0)
            {
                z = Math.Sin(Math.Sqrt(e - 1.3 * a));// если х меньше или равен нулю, то делаем это
            }
            else
            {
                z = (Math.Pow(Math.Log10(x), 2)) / (Math.Sqrt(Math.Pow(x, 2) + 10));// иначе делаем это
            }
            Console.WriteLine($"выводим {z} ");//выводим z

            r = Math.Pow(z, 2) + x - a * e * x;//потом делаем последнее действие
            double result = Math.Round(r, 3);//делаем округление 
            Console.WriteLine(result);// выводим окончательный ответ
        }


    }
}
