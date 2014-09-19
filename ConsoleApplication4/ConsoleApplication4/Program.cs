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
            int antalLoner;
            int loop = 0;

            //Läs in hur många löner som ska matas in
            
            
            try 
            { 
            Console.Write("Ange antal löner att mata in: ");
            antalLoner = ReadInt();
            Console.WriteLine(); //blank rad
            
            }
            catch
            {
                Console.WriteLine("FEL! Skriv in ett heltal med antal löner du vill beräkna.");
            }
            
            int[] arrayLoner = new int[antalLoner];
            int[] arrayLonerCopy = new int[antalLoner];

            //Läs in lönerna och placera dem i array
            while (loop < antalLoner)
            {
                
            //Felhantering
                try
                {
                    Console.Write("Ange lön nummer " + (loop + 1) + ": ");
                    arrayLoner[loop] = ProcessSalaries();
                    loop++;
                    
                }
                catch
                {                    
                    Console.WriteLine("FEL! ");
                }
             }         
                



                //Grafik
                Console.WriteLine(); //blank rad
                Console.WriteLine("-------------------------------");

                //Kopiera array
                arrayLonerCopy = arrayLoner;
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
                Console.WriteLine(string.Format("Lönespridning: {0,12:c0}", spridning));

                //Grafik
                Console.WriteLine("-------------------------------");
                Console.WriteLine(); //blank rad

                //Lista lönerna
                int loop2 = 0;

                while (loop2 < antalLoner)
                {
                    Console.Write("{0} ", arrayLonerCopy[loop2]);
                    loop2++;
                    
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

