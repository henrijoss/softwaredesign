using System;

namespace Aufgabe_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("With this function you can convert a number from the decimal system to another system or vice versa");
                Console.WriteLine("From which system would you like to convert ? (Type in the number of the base)");
                int fromSystem = int.Parse(Console.ReadLine());
                Console.WriteLine("To which System do you want to convert ? (Remember one of them has to be 10)");
                int toSystem = int.Parse(Console.ReadLine());

                if (fromSystem == 10 || toSystem == 10) {
                    Console.WriteLine("Type in the number you would like to convert:");
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine(ConvertNumberFromSystemToSystem(number, fromSystem, toSystem));
                } else {
                        Console.WriteLine("One of the Systems must have Base 10!");
                }
            } catch {
                Console.WriteLine("Your inputs must be numbers!");
            }
        }
        static int ConvertNumberFromSystemToSystem(int number, int fromSystem, int toSystem)
            {
                int result = 0;
                result = OtherToDecimal(number, fromSystem);
                result = DecimalToOther(result, toSystem);
                return result;
            }

        static int DecimalToOther(int dec, int system)
            {
                int result = 0;
                int factor = 1;
                while (dec != 0)
                {
                    int digit = dec % system;
                    dec /= system;
                    result += factor * digit;
                    factor *= 10;
                }
                return result;
            }

            static int OtherToDecimal(int other, int system)
            {
                int result = 0;
                int factor = 1;
                while (other != 0)
                {
                    int digit = other % 10;
                    other /= 10;
                    result += factor * digit;
                    factor *= system;
                }
                return result;
            }    
    }
}
