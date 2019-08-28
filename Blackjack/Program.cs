using System;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    class Program
    {
        private static List<int> Karten;

        static void Main(string[] args)
        {

            Karten = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
            // Ein Kartendeck, also von jeder Karte 4 Exemplare von jeder Karte
            Console.WriteLine("Willst du Blackjack spielen? Wenn ja tippe bitte das Wort Start ein.");

            var Start = Console.ReadLine();

            var RisikoReicherPeter = 0;
            var GierigerGunther = 0;
            var BaronBauer = 0;
            var CooleChristoph = 0;
            var DürreDonald = 0;
            var DeutscheDominik = 0;
            var PenetranterPaul = 0;


            var ErsteKarte = Kartenzuteilung();
            var ZweiteKarte = Kartenzuteilung();
            var Gesamtwert = ErsteKarte + ZweiteKarte;
            for (int i = 0; i < 2; i++)
            {
                var result = Mitspieler(RisikoReicherPeter, GierigerGunther, BaronBauer, CooleChristoph, DürreDonald, DeutscheDominik, PenetranterPaul);
                RisikoReicherPeter = result.Item1;
                GierigerGunther = result.Item2;
                BaronBauer = result.Item3;
                CooleChristoph = result.Item4;
                DürreDonald = result.Item5;
                DeutscheDominik = result.Item6;
                PenetranterPaul = result.Item7;
            }

            if (Start.ToLower() == "start")
            {
                Console.WriteLine($"Deine ersten zwei Karten haben die Werte {ErsteKarte} und {ZweiteKarte}. Der Gesamtwert ist demnach {Gesamtwert}. Möchtest du noch eine Karte?");
            }

            var Karte = Console.ReadLine();
            while (Karte.ToLower() == "ja" && Gesamtwert <= 21)

            {
                var currentCardValue = Kartenzuteilung();
                Gesamtwert += currentCardValue;
                var result = Mitspieler(RisikoReicherPeter, GierigerGunther, BaronBauer, CooleChristoph, DürreDonald, DeutscheDominik, PenetranterPaul);
                RisikoReicherPeter = result.Item1;
                GierigerGunther = result.Item2;
                BaronBauer = result.Item3;
                CooleChristoph = result.Item4;
                DürreDonald = result.Item5;
                DeutscheDominik = result.Item6;
                PenetranterPaul = result.Item7;
                Console.WriteLine($"Deine Karte hat den Wert {currentCardValue}. Der Gesamtwert deiner Karten ist {Gesamtwert}.");
                if (Gesamtwert > 21)
                {
                    DuBistEinLoser();
                }
                else
                {
                    Console.WriteLine("Möchtest du eine weitere Karte?");
                    Karte = Console.ReadLine();
                }
            }
            if (Karte.ToLower() == "nein")
            {
                if ((Gesamtwert > RisikoReicherPeter || RisikoReicherPeter > 21) && (Gesamtwert > GierigerGunther || GierigerGunther > 21) && (Gesamtwert > BaronBauer || BaronBauer > 21) && (Gesamtwert > CooleChristoph || CooleChristoph > 21) && (Gesamtwert > DürreDonald || DürreDonald > 21) && (Gesamtwert > DeutscheDominik || DeutscheDominik > 21) && (Gesamtwert > PenetranterPaul || PenetranterPaul > 21))
                {
                    Console.WriteLine($"Der Gesamtwert der Karten deiner Mitspieler beträgt {RisikoReicherPeter}, {GierigerGunther}, {BaronBauer}, {CooleChristoph}, {DürreDonald}, {DeutscheDominik} und {PenetranterPaul}. Der Gesamtwert deiner Karten beträgt {Gesamtwert} und ist damit der höchste beziehungsweise die Gesamtwerte von Mitspielern sind über 21. Glückwunsch, du hast gewonnen!");
                }
                else if ((Gesamtwert < RisikoReicherPeter && RisikoReicherPeter < 22) || (Gesamtwert < GierigerGunther && GierigerGunther < 22) || (Gesamtwert < BaronBauer && BaronBauer < 22) || (Gesamtwert < CooleChristoph && CooleChristoph < 22) || (Gesamtwert < DürreDonald && DürreDonald < 22) || (Gesamtwert < DeutscheDominik && DeutscheDominik < 22) || (Gesamtwert < PenetranterPaul && PenetranterPaul < 22))
                {
                    Console.WriteLine($"Der Gesamtwert der Karten deiner Mitspieler beträgt {RisikoReicherPeter}, {GierigerGunther}, {BaronBauer}, {CooleChristoph}, {DürreDonald}, {DeutscheDominik} und {PenetranterPaul}. Der Gesamtwert deiner Karten beträgt {Gesamtwert} und ist daher nicht der höchste. (Kartenwerte über 21 werden nicht mitgezählt) Du hast verloren, mein  Beileid.");
                }
                else
                {
                    Console.WriteLine($"Der Gesamtwert der Karten deiner Mitspieler beträgt {RisikoReicherPeter}, {GierigerGunther}, {BaronBauer}, {CooleChristoph}, {DürreDonald}, {DeutscheDominik} und {PenetranterPaul}. Der Gesamtwert deiner Karten beträgt {Gesamtwert}. Unentschieden !");
                }

            }



        }

        /// <summary>
        /// Wählt eine Karte aus den verfügbaren Karten aus und gibt den Wert der Karte zurück
        /// </summary>
        /// <param name="Karten">Alle verfügbaren Karten</param>
        /// <returns>Kartenwert der gezogenen Karte</returns>
        public static int? Kartenzuteilung()
        {
            if (Karten.Count() == 0)
            {
                Console.WriteLine("Keine Karten mehr übrig");
                return null;
            }
            else
            {
                Random cards = new Random();
                var random = cards.Next(Karten.Count() - 1);
                var currentCardValue = Karten[random];
                Karten.RemoveAt(random);
                return currentCardValue;
            }
        }

        public static (int, int, int, int, int, int, int) Mitspieler(int RisikoReicherPeter, int GierigerGunther, int BaronBauer, int CooleChristoph, int DürreDonald, int DeutscheDominik, int PenetranterPaul)

        {


            if (RisikoReicherPeter < 21)
            {
                RisikoReicherPeter += MitspielerKartenwert();
            }
            if (GierigerGunther < 20)
            {
                GierigerGunther += MitspielerKartenwert();
            }
            if (BaronBauer < 19)
            {
                BaronBauer += MitspielerKartenwert();
            }
            if (CooleChristoph < 18)
            {
                CooleChristoph += MitspielerKartenwert();
            }
            if (DürreDonald < 17)
            {
                DürreDonald += MitspielerKartenwert();
            }
            if (DeutscheDominik < 16)
            {
                DeutscheDominik += MitspielerKartenwert();
            }
            if (PenetranterPaul < 15)
            {
                PenetranterPaul += MitspielerKartenwert();
            }
            return (RisikoReicherPeter, GierigerGunther, BaronBauer, CooleChristoph, DürreDonald, DeutscheDominik, PenetranterPaul);
        }

        private static int MitspielerKartenwert()
        {
            var cardValue = Kartenzuteilung();
            if (cardValue.HasValue)
            {
                return cardValue.Value;
            }
            return 0;
        }

        static void DuBistEinLoser()
        {
            Console.WriteLine("Der Gesamtwert deiner Karten ist über 21, daher hast du verloren. Mein Beileid.");

        }


    }
}
