using System;

namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("введите первую строку:");
            string str1 = Console.ReadLine();
            Console.WriteLine("введите вторую строку:");
            string str2 = Console.ReadLine();
            bool comparison = false;

            Metod(str1, str2, comparison);

        }
        static bool Metod(string str1, string str2, bool comparison)
        {

            if (str1 == str2)
            {

                comparison = true;
            }
            if (str1 != str2)
            {
                comparison = false;
            }
            if (str1.Length > str2.Length)
            {
                if (str1.Length == str1.Length)
                {
                    for (int i = 0; i > str1.Length; i++)
                    {
                        if (str1[i] != str2[i])
                        {

                            comparison = false;
                        }
                        if (str1[i] == str2[i])
                        {

                            comparison = true;
                        }
                    }
                }
            }
            if (str1.Length < str2.Length)
            {
                if (str1.Length == str1.Length)
                {
                    for (int i = 0; i > str2.Length; i++)
                    {
                        if (str1[i] != str2[i])
                        {

                            comparison = false;
                        }
                        if (str1[i] == str2[i])
                        {

                            comparison = true;
                        }
                    }
                }
            }
            if (str1.Length != str2.Length)
            {
                comparison = false;
            }
            if (comparison == true)
            {
                Console.WriteLine("строки равны");

            }
            if (comparison == false)
                Console.WriteLine("строки не равны");
            return true;
        }



    }
}