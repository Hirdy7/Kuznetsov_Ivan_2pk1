using System.ComponentModel;
using System.Threading.Channels;

namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            First(ref a, ref b);
            Second(a, b, ref c);
            Third(c);

        }
        static void First(ref int a, ref int b)
        {
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());

        }
        static void Second(int a, int b, ref int c)
        {
            c = a + b;

        }
        static void Third(int c)
        {
            Console.WriteLine(c);
        }



    }
}
