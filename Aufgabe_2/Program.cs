using System;

namespace Aufgabe_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // int i = 42;
            // double pi = 3.1415;
            // string salute = "Hello, World";
            

            // var variableFloat = 20f;
            // var variableDouble = 20d;
            // var variableShort = 20;
            // Bei Short auch möglich ?

            // **** Arrays ****

            // int[] ia = new int[10];
            // char[] ca = new char[30];
            // double[] da = new double[12];

            // int[] ia = {1, 0, 2, 9, 3, 8, 4, 7, 5, 6};
            // int ergebnis = ia[2] * ia[8] + ia[4];
            // ergebnis = 2 * 5 + 3 = 13
            //Console.WriteLine(ergebnis);
            //Console.WriteLine(ia.Length);

            // double[] math = {Math.PI, Math.E, 2.9E-19}; 

            // **** Strings ****

            // string a = "Dies ist ";
            // string b = "ein String";
            // string c = a + b;
            // string a = "eins";
            // string b = "zwei";
            // string c = "eins";
            // bool a_eq_b = (a == b);
            // bool a_eq_c = (a == c);
            
            // string meinString = "Dies ist ein String";
            // char zeichen = meinString[5];
            

            // Person jemand = new Person();
            // jemand.Name = "Horst";
            // jemand.Personalnummer = 42;

            //Kürzere Schreibweise
            //Person jemand = new Person {Name="Horst", Personalnummer=42};
            
            //**** Verzweigungen ****

            // Console.WriteLine("Wert für a eingeben");
            // int a = int.Parse(Console.ReadLine());
            // Console.WriteLine("Wert für b eingeben");
            // int b = int.Parse(Console.ReadLine());
            
            // if (a > 3 && b == 6) {
            //     Console.WriteLine("Du hast gewonnen");
            // } else {
            //     Console.WriteLine("Leider verloren");
            // }

            // string i = Console.ReadLine();
            // switch (i)
            // {
            //     case "Gelb":
            //         Console.WriteLine("Zitronen sind" + i);
            //         break;
            //     case "Grün":
            //         Console.WriteLine("Limetten sind" + i);
            //         break;
            //     case "Blau":
            //         Console.WriteLine("Heidelbeeren sind" + i);
            //         break;
            //     case "Rot":
            //         Console.WriteLine("Granatäpfel sind" + i);
            //         break;
            //     default:
            //         Console.WriteLine("Ich kenne den Audruck " + i + "nicht");
            //         break;
            // }
            // ohne "break" würde die Ausführung von einem switch-Abschnitt zum nächsten fortgesetzt werden
            // in welchen Fällen sinnvoll ?

            // if (i =="Gelb") {
            //     Console.WriteLine("Zitronen sind " + i);
            // } else if (i =="Grün") {
            //     Console.WriteLine("Limetten sind " + i);
            // } else if (i =="Blau") {
            //     Console.WriteLine("Heidelbeeren sind " + i);
            // } else if (i =="Rot") {
            //     Console.WriteLine("Granatäpfel sind " + i);
            // } else {
            //     Console.WriteLine("Ich kenne den Audruck " + i + " nicht");
            // }

            // **** Schleifen ****

            // int i = 1; //<INITIALISIERUNG>

            // while (i < 11) { //<BEDINGUNG>
            //     Console.WriteLine(i); // Schleifenrumpf
            //     i++; //<INKREMENT>
            // }

            // for (int i = 1; i < 11; i++) {
            //     Console.WriteLine(i);
            // }

            string[] someStrings = 
            {
                "Hier",
                "sehen",
                "wir",
                "einen",
                "Array",
                "von",
                "Strings"
            };
            
            // for (int i = 0; i < someStrings.Length; i++)
            // {
            //     Console.WriteLine(someStrings[i]);
            // }
            // Bei leerem Array passiert nichts

            // int i = 0;
            // while (i < someStrings.Length) {
            //     Console.WriteLine(someStrings[i]);
            //     i++;
            // }

            //Array wird mit Schleife durchlaufen sodass alle Indizes von 0-5 ausgegeben werden

            // int i = 0;
            // do {
            //     Console.WriteLine(someStrings[i]);
            //     i++;
            // }
            // while (i < someStrings.Length);
            // Bei leerem Array indexOutOfRange

            // int i = 0;
            // while (true)
            // {
            //     Console.WriteLine(someStrings[i]);
            //     if (i < someStrings.Length)
            //     break;
            //     i++;
            // }
            // Bei leerem Array indexOutOfRange

              foreach (string s in someStrings)
                {
                    Console.WriteLine(s);
                }
        }
    }
      public class Person {
        public string Name;
        public int Personalnummer;  
  }
}
