namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число a: ");
            double a = double.Parse(Console.ReadLine()); // вводим числа с клавиатуры 
            
            Console.WriteLine("Введите число b: ");
            double b = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Введите число c: ");
            double c = double.Parse(Console.ReadLine());

            double firstValue, secondValue, thirdValue, fourthValue, fifthValue; // создаем 5 переменных типа Double

            firstValue = a + 3 + Math.Abs(a-b) + Math.Pow(a, 2); // первое действие ( результат с числителя дроби )

            secondValue = Math.Abs(a - b) * c + Math.Pow(a, 2); // второе действие( результат со знаметеля со знаметеля дроби )

            thirdValue = firstValue / secondValue;// третье действие  ( результат деления числителя на знаменатель ) 

            fourthValue = 1.0 / 4.0 + Math.Cos(a) * thirdValue ; // четвертое действие ( умножаем дробь 1/4, перевожу в вещественый тип , на косинус переменной а и третье значение

            fifthValue = 5 * Math.Atan(a) - fourthValue;// пятое последнее действие 

            Console.WriteLine( " ответ:"  + fifthValue ); // вывод ответа на экран 
        }
    }
}