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

            Console.WriteLine("*************************************");
            
            for (int i=0;i<25;i++)
            {
                Console.Write("*");
                for (int k=0;k<35;k++)
                {
                    Console.Write(Bild[i,k]);
                }
                Console.WriteLine("*");
            }
            Console.WriteLine("*************************************");
            Console.Write("Press ESC for exit");
        }
        static void SchlangeInsBild()
        {
            foreach(Schlange.Punkt a in Schlange.Position)
            {                
                Bild[a.Y, a.X] = 'o';
            }
            Bild[Schlange.Position[0].Y, Schlange.Position[0].X] = 'O';
        }
        static void BildFuellen()
        {
            for (int i = 0; i < 25; i++)
            {                
                for (int k = 0; k < 35; k++)
                {
                    Bild[i, k] = ' ';
                }
            }
        }

        static public char[,] Bild = new char[25, 35];

        static void Main(string[] args)
        {            
            ConsoleKeyInfo Eingabe;
            BildFuellen();
            Schlange.Position.Add(new Schlange.Punkt(10, 10));
            SchlangeInsBild();
            do
            {                
                BildAnzeigen();
                Eingabe = Console.ReadKey();
                switch (Eingabe.Key)
                {
                    case ConsoleKey.UpArrow: Schlange.Richtung=1; break;
                       
                    case ConsoleKey.DownArrow: Schlange.Richtung = 3; break;
                    case ConsoleKey.LeftArrow: Schlange.Richtung = 2; break;
                    case ConsoleKey.RightArrow: Schlange.Richtung = 4; break;
                }
                Schlange.KollisionsPruefung();
                SchlangeInsBild();
            }
            while (Eingabe.Key != ConsoleKey.Escape);
        }
    }

    class Schlange
    {
        public static int Laenge = 1;
        public static int Richtung = 0; //0= Ruhe, aufwärts=1, abwärts=3, links=2, rechts=4
        public struct Punkt
        {
            public int X, Y;
            //public char Symbol;

            public Punkt(int a, int b)
            {
                Y = a;
                X = b;              
            }
            //public Punkt(int a, int b, char c)
            //{
            //    Y=a;
            //    X = b;
            //    Symbol = c;
            //}
        }
        public static List<Punkt> Position = new List<Punkt>();
        public static void GameOver()
        {
            Console.WriteLine("Game Over");
        }

        public static void KollisionsPruefung()  // true= Kein Kontakt=Prüfung bestanden
        {
            bool Ergebnis = true;
            foreach (Punkt a in Position)
            {
                switch (Richtung)
                {
                    case 1: if ((Position[0].Y - 1) == a.Y) Ergebnis = false; break;
                    case 3: if ((Position[0].Y + 1) == a.Y) Ergebnis = false; break;
                    case 2: if ((Position[0].X - 1) == a.X) Ergebnis = false; break;
                    case 4: if ((Position[0].X + 1) == a.X) Ergebnis = false; break;
                }
            }
            if (!Ergebnis) GameOver();
            else
            {                
                switch (Richtung)
                {
                    case 1: Position.Add(new Punkt(Position[0].Y - 1, Position[0].X)); if (Program.Bild[Position[0].Y - 1, Position[0].X] == 'X') Position.RemoveAt(Position.Count - 1); break;
                    case 3: Position.Add(new Punkt(Position[0].Y + 1, Position[0].X)); if (Program.Bild[Position[0].Y + 1, Position[0].X] == 'X') Position.RemoveAt(Position.Count - 1); break;
                    case 2: Position.Add(new Punkt(Position[0].Y, Position[0].X - 1)); if (Program.Bild[Position[0].Y, Position[0].X-1] == 'X') Position.RemoveAt(Position.Count - 1); break;
                    case 4: Position.Add(new Punkt(Position[0].Y, Position[0].X + 1)); if (Program.Bild[Position[0].Y, Position[0].X+1] == 'X') Position.RemoveAt(Position.Count - 1); break; 
                }                
            }
        }

        //private static void Aenderung()
        //{
        //    switch (Richtung)
        //    {
        //        case 0: break;
        //        case 1: try 
        //            {
        //                for (int i=0; i) (Punkt a in Position)
        //                {
        //                    if (a.Y <0) || (a.Y-- == )
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine("Game Over");
        //            }
        //            break;
        //    }
        //}

    }
}
