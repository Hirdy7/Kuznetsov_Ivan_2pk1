namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "i am learning c#";
            text = text.Remove(5, 8);
            Console.WriteLine(text);
        }
    }
}