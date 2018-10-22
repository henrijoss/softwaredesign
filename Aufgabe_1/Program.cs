using System;

namespace Aufgabe_1 {
    class Program {
        static void Main(string[] args) {

        Console.Write("Type in an Ingeger between 0-999: ");
        string input = Console.ReadLine();
        if ((Convert.ToInt32(input) > 0) || (Convert.ToInt32(input) < 999)) {
            if (input.Length == 1) {
            string[] number = new string[1];
                number[0] = input[0].ToString();
                Console.WriteLine("Converted into Roman: " + GetRomanNumberI(Convert.ToInt32(number[0])));
            }
            if (input.Length == 2) {
            string[] number = new string[2];
                number[0] = input[0] + "0";
                number[1] = input[1].ToString();
                Console.WriteLine("Converted into Roman: " + GetRomanNumberX(Convert.ToInt32(number[0])) + GetRomanNumberI(Convert.ToInt32(number[1])));
            }
            if (input.Length == 3) {
                string[] number = new string[3];
                number[0] = input[0] + "00";
                number[1] = input[1] + "0";
                number[2] = input[2].ToString();
                Console.WriteLine("Converted into Roman: " + GetRomanNumberC(Convert.ToInt32(number[0])) + GetRomanNumberX(Convert.ToInt32(number[1])) + GetRomanNumberI(Convert.ToInt32(number[2])));
            }
        } else {
            Console.WriteLine("Integer must be between 0-999");
        }

          string GetRomanNumberC(int number) {
                if ((number < 0) || (number > 999)) Console.WriteLine("index out of range");
                if (number < 1) return string.Empty;
                if (number >= 900) return "CM" + GetRomanNumberC(number - 900);
                if (number >= 500) return "D" + GetRomanNumberC(number - 500);
                if (number >= 400) return "CD" + GetRomanNumberC(number - 400);
                if (number >= 100) return "C" + GetRomanNumberC(number - 100);
                throw new ArgumentOutOfRangeException("something bad happened");
            }
                      string GetRomanNumberX(int number) {
                if ((number < 0) || (number > 999)) Console.WriteLine("index out of range");
                if (number < 1) return string.Empty;
                if (number >= 90) return "XC" + GetRomanNumberX(number - 90);
                if (number >= 50) return "L" + GetRomanNumberX(number - 50);
                if (number >= 40) return "XL" + GetRomanNumberX(number - 40);
                if (number >= 10) return "X" + GetRomanNumberX(number - 10);
                throw new ArgumentOutOfRangeException("something bad happened");
            }
                      string GetRomanNumberI(int number) {
                if ((number < 0) || (number > 999)) Console.WriteLine("index out of range");
                if (number < 1) return string.Empty;
                if (number >= 9) return "IX" + GetRomanNumberI(number - 9);
                if (number >= 5) return "V" + GetRomanNumberI(number - 5);
                if (number >= 4) return "IV" + GetRomanNumberI(number - 4);
                if (number >= 1) return "I" + GetRomanNumberI(number - 1);
                throw new ArgumentOutOfRangeException("something bad happened");
            }
        }
    }
}