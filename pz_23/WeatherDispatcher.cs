using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_23
{
    internal class WeatherDispatcher
    {
        public void WriteMessage(Object? sourceTemp, EventArgs e)
        {
            if (e is ChangeEventArgs)
            {
                var changeEventArgs = (ChangeEventArgs)e;
                Console.WriteLine(changeEventArgs.Advertisement);
            }

            if (sourceTemp is TemperatureEmulator)
            {
                var temp = (TemperatureEmulator)sourceTemp;
                temp.WeatherNews();
            }
        }

    }
}
