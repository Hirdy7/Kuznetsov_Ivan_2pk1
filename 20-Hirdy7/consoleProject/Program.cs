using System.Reflection.Metadata;
using System;

namespace consoleProject
{
    /*
     * ФИО студента: Кузнецов Иван Юрьевич
     * номер варианта: 
     * условие задачи (скопировать из листа задания): 
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ComplexNumber complexNumber1 = new ComplexNumber(7, 8);
            complexNumber1.PrintComplexNumber();
            complexNumber1.GetMultiplicationByNumber();
           
            var complexNumber2 = (ComplexNumber)complexNumber1.Clone();
            complexNumber2.a = 2;
            complexNumber2.b = 3;
            complexNumber2.PrintComplexNumber();
            complexNumber2.GetMultiplicationByNumber();

            ComplexNumber complexNumber3 = new ComplexNumber(1, 3);
            

            ComplexNumber complexNumber4 = new ComplexNumber(2, 4);
            

            ComplexNumber complexNumber5 = new ComplexNumber(8, 1);
            

            ComplexNumber complexNumber6 = new ComplexNumber(5, 7);
            

            ComplexNumber complexNumber7 = new ComplexNumber(9, 2);
            
           

            ComplexNumber complexNumber8 = new ComplexNumber(6, 3);
           

            ComplexNumber complexNumber9 = new ComplexNumber(8, 8);
            

            ComplexNumber complexNumber10 = new ComplexNumber(1, 8);

            Number number1 = new Number(30, 22);
            
            
            Console.WriteLine("\n\n");
            
            
            
            ComplexNumber[] complexnumbers = { complexNumber1, complexNumber2, complexNumber3, complexNumber4, complexNumber5,
                complexNumber6, complexNumber7, complexNumber8, complexNumber9, complexNumber10};
            
            
            Array.Sort(complexnumbers);
            foreach (ComplexNumber cn in complexnumbers)
            {
             cn.PrintComplexNumber();
            }

            complexNumber9.Dispose();
        }
    }
}