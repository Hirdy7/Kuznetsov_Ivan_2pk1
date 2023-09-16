namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //просим пользователя выбрать фигуру 
            Console.WriteLine("выберите  фигуру(1. прямоугольник, 2. круг, 3. треугольник) " );
            int figure  = int.Parse(Console.ReadLine());

            switch (figure) //прописываем кейс для каждой из фигур, вводя нужные данные для поиска площади и ее вывода на консоль
            {
                case 1:
                    Console.WriteLine("введите длину и ширину:");
                    double length = double.Parse(Console.ReadLine());

                    double width = double.Parse(Console.ReadLine());
                    
                    double square1 = length * width;

                    Console.WriteLine($"площадь прямоугольника равна {square1}  ");
                    break;
                case 2:
                    Console.WriteLine("введите радиус круга: ");

                    double radius = double.Parse(Console.ReadLine());
                      double square2 = Math.PI * Math.Pow(radius, 2);
                    Console.WriteLine($"площадь круга равна {square2}  ");
                    break;
                case 3:
                    Console.WriteLine("введите высоту и длину основания");

                    double height = double.Parse(Console.ReadLine());

                    double base_of_triangle = double.Parse(Console.ReadLine());

                    double square3 = (height * base_of_triangle)/2;
                    Console.WriteLine($"площадь треугольника равна {square3}  ");
                    break;








            }





        }
    }
}