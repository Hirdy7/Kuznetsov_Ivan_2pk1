namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = -2;
            double  y;
            double step = 0.5;
            
            while (x <= 2)
            {                
                y = -2.4*Math.Pow(x, 2)+ 5*x - 3;                
                Console.WriteLine($"значение X:{x}"  + " " + $"значение y:{Math.Round(y)}");                            
                x += step; 
                
            }
        }




    }
}