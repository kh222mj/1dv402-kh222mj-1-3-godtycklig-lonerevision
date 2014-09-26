using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication4
{
    class Program
    {
        private static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            int input = int.Parse(Console.ReadLine());
            return input;                                
        }
        private static void ProcessSalaries(ref int antalLoner)
        {
            //Deklaration av variabel
            int loop = 0;
            
            //Deklarera arrayer
            int[] arrayLoner = new int[antalLoner];
            int[] arrayLonerClone = new int[antalLoner];

            while (true)
            {
                try
                {
                //Läs in lönerna och placera dem i array
                while (loop < antalLoner)
                {
                    Console.Write("Ange lön nummer " + (loop + 1) + ": ");
                    arrayLoner[loop] = Convert.ToInt32(Console.ReadLine());
                    loop++;
                }
                break;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Skriv in en lön du vill beräkna.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
            //Grafik
            Console.WriteLine(); //blank rad
            Console.WriteLine("-------------------------------");
            //Kopiera array
            arrayLonerClone = (int[])arrayLoner.Clone();
            Array.Sort(arrayLoner);
            //Medianlön
            if (antalLoner % 2 == 1)
            {
                int median = antalLoner / 2;
                Console.WriteLine(string.Format("Medianlön: {0,17:c0}", arrayLoner[Convert.ToInt32(median)]));
            }
            else
            {
                int median1 = antalLoner / 2;
                int median2 = (antalLoner / 2) + 1;
                int medianLon = arrayLoner[median1] + arrayLoner[median2];
                Console.WriteLine(string.Format("Medianlön: {0,17:c0}", medianLon));
            }
            //Medellön
            double average;
            average = arrayLoner.Average();
            Console.WriteLine(string.Format("Medellön: {0,18:c0}", average));
            //Lönespridning
            int spridning;
            spridning = arrayLoner.Max() - arrayLoner.Min();
            Console.WriteLine(string.Format("Lönespridning: {0,13:c0}", spridning));
            //Grafik
            Console.WriteLine("-------------------------------");
            //Lista lönerna
            int count = 0;
            for (int col = 1; col < antalLoner + 1; )
            {
                Console.Write(string.Format("{0,8}", arrayLonerClone[count]));
                count++;
                if (col % 3 == 0)
                {
                    Console.WriteLine();
                }
                col++;
            }
            Console.WriteLine();//Blank rad
        }
        private static void Restart() 
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Tryck tangent för ny beräkning - Esc avslutar");
            Console.BackgroundColor = ConsoleColor.Black;
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            //För omstart
            while (true)
            {
            while (true)
            {
                try
                {
                    //Läs in hur många löner som ska matas in
                    int antalLoner = ReadInt("Ange antal löner att mata in: ");
                    Console.WriteLine(); //blank rad

                    //Kolla om antalLoner ett rimligt tal      
                    if (antalLoner < 3)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("FEL! Du måste mata in minst två löner för att kunna göra en beräkning!");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                        Restart();
                    }
                    //Beräkna och presentera löner
                    else
                    {
                        ProcessSalaries(ref antalLoner);
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Det du angav kunde inte tolkas som ett heltal");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                    Restart();
                }
            }
                //Avsluta eller en ny beräkning
                Console.WriteLine();//Blank rad
                Restart();
            }
        }
    }
}