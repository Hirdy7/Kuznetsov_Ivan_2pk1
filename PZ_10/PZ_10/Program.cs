namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string First_str = "Hello world";

            string Second_str = "Hi world";
            string[] new_First_str = First_str.Split(' ');
            string[] new_Second_str = Second_str.Split(' ');
            string new_string = "";
            int count = 0;
            for (int i = 0; i < new_Second_str.Length - 1; i++)

            {
                for (int j = 0; j < new_First_str.Length - 1; j++)
                {
                    if (new_Second_str[i] == new_First_str[j])
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