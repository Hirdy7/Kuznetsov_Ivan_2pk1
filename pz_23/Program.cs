namespace pz_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureEmulator temp1 = new TemperatureEmulator(0);
            WeatherDispatcher weatherDispatcher = new WeatherDispatcher();
            temp1.CriticalTemperature += weatherDispatcher.WriteMessage;
            temp1.ChangeTemperature();




        }
    }
}
