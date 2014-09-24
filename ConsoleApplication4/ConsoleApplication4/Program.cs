using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {

        //Deklaration av variabler
        int antalLoner = 0;
        int loop = 0;
        bool restart = true;

        while (restart)
        {

            while (true)
            {
                try
                {
                    //Läs in hur många löner som ska matas in
                    Console.Write("Ange antal löner att mata in: ");
                    antalLoner = ReadInt();
                    Console.WriteLine(); //blank rad

                    if (antalLoner < 2 || antalLoner > 100)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    break;
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! Skriv in rimligt antal löner att beräkna.");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }

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
                        arrayLoner[loop] = ProcessSalaries();
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
    }
        

        //Metoder
        static int ReadInt() 
        {
            int input;
            input = int.Parse(Console.ReadLine());

            return input;
        }

        static int ProcessSalaries()
        {
            int salaries;
            salaries = Convert.ToInt32(Console.ReadLine());

            return salaries;
        }

        
     }        
}  