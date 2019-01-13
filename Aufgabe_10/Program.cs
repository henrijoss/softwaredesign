using System;
using System.Collections.Generic;

namespace Aufgabe_10
{

    
    class Program
    {
        static void Main(string[] args)
        {
            Calculator test = new Calculator();
            test.CalculateSomething();
        }
    }

    public delegate void ReportProgressMethod(int progress);
    public class Calculator 
    {
    
        public event ReportProgressMethod ProgressMethod;

        public Calculator()
        {
            ProgressMethod += ReportProgress;
            ProgressMethod += ReportDevidedProgress;   
        }

        public static void ReportProgress(int progress)
        {
            Console.WriteLine(progress);
        }

        public static void ReportDevidedProgress(int progress)
        {
            Console.WriteLine(progress/100);
        }

        public void CalculateSomething()
        {
            for (int i = 0; i < 100; i++)
            {
                int number = 43223 * i;
                if (i == 25 || i == 50 || i == 75)
                {
                ProgressMethod(number);
                }
            }
        }
    }
}
