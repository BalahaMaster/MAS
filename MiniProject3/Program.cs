using System;
using System.Collections.Generic;

namespace MiniProject3
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectPlusPlus.DefineAssociations();
            Profession p1 = new Profession("Wojownik", "Miecze");
            Console.WriteLine(p1.GetSpeciality());
            Console.WriteLine(p1.GetSpells()); // Pojawi się komunikat, że ta profesja nie jest magiem
            List<string> spells = new List<string> { "Kula ognia", "Magiczny pocisk" };
            Profession p2 = new Profession("Mag", spells);
            Profession p3 = new Profession("Wojownik-Mag", "Sztylet", spells); // Overlaping z użyciem kompozycji p3 jest i Wojownikiem i Magiem
            Console.WriteLine(p3.GetSpells());
            Console.WriteLine(p3.GetSpeciality());
            

            //Weapon w1;
            //Weapon w2;
            //Weapon w3;
            //w1 = new Melee("Miecz", 5, 2.5, 1.5, "Stal");
            //w2 = new Ranged("Łuk krótki", 2, 0.75, 60.0, 68.0);
            //w3 = new Melee("Włócznia", 8, 7.0, 3.0, "Drewno");
        }
    }
}
