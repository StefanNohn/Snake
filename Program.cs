using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void BildAnzeigen()
        {
            Console.Clear();

            Console.WriteLine("***************************");
            
            for (int i=0;i<15;i++)
            {
                Console.Write("*");
                for (int k=0;k<25;k++)
                {
                    Console.Write(Bild[i,k]);
                }
                Console.WriteLine("*");
            }
            Console.WriteLine("***************************");
        }
        static void BildFuellen()
        {
            for (int i = 0; i < 15; i++)
            {                
                for (int k = 0; k < 25; k++)
                {
                    Bild[i, k] = ' ';
                }
            }
        }

        static char[,] Bild = new char[15, 25];

        static void Main(string[] args)
        {
            BildFuellen();
            BildAnzeigen();
        }
    }
    class Schlange
    {
        public static int Laenge = 1;
        public static int Richtung = 0; //0= Ruhe, aufwärts=1, abwärts=3, links=2, rechts=4
        public static List<(int,int)> Position = new List<(int Y, int X)>
        { 
            (10,10)
        };
        private static void Aenderung()
        {
            switch (Richtung)
            {
                case 0: break;
                case 1: try 
                    {
                        var a = Position[0].Y;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Fehler: " + ex);
                    }
                    break;
            }
        }

    }
}
