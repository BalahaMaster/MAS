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


            Weapon w1;
            Weapon w2;
            Weapon w3;
            WeaponKind wk1 = new Edged("Prosta głownia", 10.0); // wykorzystanie klasy abstrakcyjnej WeaponKind i dziedziczenie Disjoint
            WeaponKind wk2 = new Pointed("Tytanowy", 15.0);
            WeaponKind wk3 = new Blunt("Drewno", 20.0);

            w1 = new Melee("Miecz", 5, 2.5, wk1, 1.5, "Stal"); // DZiedziczenie wieloaspektowe - Wepon dzieli się według Sposobu walki (Melee, Ranged) i według Rodzaju (Pointed, Edge, Blunt)
            w2 = new Ranged("Łuk krótki", 2, 0.75, wk2, 60.0, 68.0);
            w3 = new Melee("Młot", 8, 7.0, wk3, 1.5, "Żelazo");

            w1.Kind.ShowBonus(); // Polimorficzne wywoałnie metody "ShowBonus" z klasy abstakcyjnej "WeaponKind"
            w2.Kind.ShowBonus();
            w3.Kind.ShowBonus();

            Human northener = new Human("Ludzie z północy", "Ludzie, mieszkający w zimnych krajach północy");
            Elf drow = new Elf("Drow", "Ciemnoskóra rasa elfów, żyjąca w jaskiniach");
            HalfElf he = new HalfElf("Półelf", "Człowiek, w którego jednym, z rodziców był elf."); // Wielodziedziczenie. Klasa 'HalfElf' dziedziczy w sposób prosty po klasie 'Human' i poprzez interfejs po klasie 'Elf'

            northener.NoProfessionRestriction();
            drow.DarkVision();

            he.NoProfessionRestriction();
            he.DarkVision();
            
        }
    }
}
