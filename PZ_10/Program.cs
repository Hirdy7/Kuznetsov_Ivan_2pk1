namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string First_str = "Hello world";
            string Second_str = "Hi world";
            string[] new_First_str = First_str.Split(' ');
            string[] new_Second_str = Second_str.Split(' '); //новый массив, в котором слово это элемент массива
            string new_string = "";
            int count = 0;

            for (int i = 0; i < new_Second_str.Length - 1; i++) //пересчет первой строки

            {
                for (int j = 0; j < new_First_str.Length - 1; j++)//пересчет второй строки
                {
                    if (new_Second_str[i] == new_First_str[j]) //цикл для сравнения элементов массивов
                    {
                        count++;

                    }
                    if (count == 0)
                    {
                        new_string += new_Second_str[i];
                    }
                }

            }
            Console.WriteLine(First_str);
            Console.WriteLine(new_string);
        }
    }
}