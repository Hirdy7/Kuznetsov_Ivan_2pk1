using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace pz_23
{
    internal class TemperatureEmulator
    {
        public int CurrencyTemperature { get; set; }
        public int PreviousTemperature { get; set; } = 0;
        public int[] RangeTemperature { get; } = { -25, 35 };

        public TemperatureEmulator(int currencytemperature)
        {
            CurrencyTemperature = currencytemperature;
        }


        public void ChangeTemperature() 
        {
            Random currtemp = new Random();
            Random step = new Random();

            CurrencyTemperature = currtemp.Next(RangeTemperature[0], RangeTemperature[1]);
            

            for (int i = 0; i < 31;  i++)
            {
                PreviousTemperature = CurrencyTemperature;

                if (CurrencyTemperature >= RangeTemperature[1])               
                    Console.WriteLine(CurrencyTemperature -= 5);
                

                if (CurrencyTemperature <= RangeTemperature[0])               
                    Console.WriteLine(CurrencyTemperature += 5);
                else Console.WriteLine(CurrencyTemperature += step.Next(-5, 6));



                if (CurrencyTemperature < 0 && PreviousTemperature > 0)
                    CriticalTemperatureEvent();

                else if (CurrencyTemperature > 30 && PreviousTemperature < 29)
                    CriticalTemperatureEvent();
            }                     
        }

        public void WeatherNews()
        {
            Console.WriteLine("Новости о погоде");
        }

        public event EventHandler? CriticalTemperature;

        private void CriticalTemperatureEvent()
        {
            ChangeEventArgs e = new ChangeEventArgs($"Резкое изменение темепературы с {PreviousTemperature} до {CurrencyTemperature} ");

            CriticalTemperature?.Invoke(this, e);
        }

    }
}
