namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {



            //первое задание
            Console.WriteLine("Первое задание:");
            for (int i = -25; i < 26; i += 25)
            {
                Console.WriteLine(i);
            }

            //ВТОРОЕ ЗАДАНИЕ           
            Console.WriteLine("Второе задание:");

            for (char i = 'P'; i < 'V'; i++)
            {
                Console.Write(i);
            }

            Console.WriteLine("Третье задание:");




            //третье задание
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("#");
                }
                Console.WriteLine();
            }


            //четвертое задание
            Console.WriteLine("Четвертое задание:");
            int count = 0;
            for (int i = 0; i < 200; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                    count++;
                }
            }

            Console.WriteLine();

            Console.WriteLine($"количество  чисел кратные двум: {count}");

            //пятое задание
            Console.WriteLine("пятое задание:");


            int x, c;


            for (x = 3, c = 50; c - x > 17; c--, x++)
            {
                Console.WriteLine(x + " " + c);

            }
            Console.WriteLine(x + " " + c);


        }





    }