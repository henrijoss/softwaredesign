using System;
using static System.Console;


namespace Aufgabe_4._1
{
    public class Person
    {
        public string FirstName;
        public string LastName;
        public DateTime Age;

        public override string ToString() { 
            return FirstName + LastName + ", Alter: " + Age;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            Person[] personArray = new Person[5];
            personArray[0] = new Person{ FirstName = "Max ", LastName = "Mustermann", Age = new DateTime(1995, 06, 06) };
            personArray[1] = new Person{ FirstName = "Fred ", LastName = "Feuerstein", Age = new DateTime(1983, 03, 20) };
            personArray[2] = new Person{ FirstName = "Tom ", LastName = "Riddle", Age = new DateTime(1999, 02, 13) };
            personArray[3] = new Person{ FirstName = "Bart ", LastName = "Simpson", Age = new DateTime(2008, 08, 21) };
            personArray[4] = new Person{ FirstName = "Donald ", LastName = "Duck", Age = new DateTime(2010, 10, 05) };

            for (int i = 0; i < personArray.Length; i++) {
                int alter = DateTime.Now.Year - personArray[i].Age.Year;
                if(alter >= 20){
                    Console.WriteLine(personArray[i].ToString());
                }
            }
        }
    }
}
