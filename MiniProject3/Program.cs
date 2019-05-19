using System;
using System.Collections.Generic;

namespace MiniProject3
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectPlusPlus.DefineAssociations();
            Profession p1 = new Profession("Warrior", "Swords");
            Console.WriteLine(p1.GetSpeciality());
            Console.WriteLine(p1.GetSpells()); // Pojawi się komunikat, że ta profesja nie jest magiem
            List<string> spells = new List<string> { "Fireball", "Ilusion" };
            Profession p2 = new Profession("Mage", spells);
            Profession p3 = new Profession("Warrior-Mage", "Dagger", spells); // Overlaping z użyciem kompozycji p3 jest i Wojownikiem i Magiem
            Console.WriteLine(p3.GetSpells());
            Console.WriteLine(p3.GetSpeciality());


            Weapon w1;
            Weapon w2;
            Weapon w3;
            WeaponKind wk1 = new Edged("Standard blade", 10.0); // wykorzystanie klasy abstrakcyjnej WeaponKind i dziedziczenie Disjoint
            WeaponKind wk2 = new Pointed("Titan", 15.0);
            WeaponKind wk3 = new Blunt("Wood", 20.0);

            w1 = new Melee("Sword", 5, 2.5, wk1, 1.5, "Steel"); // DZiedziczenie wieloaspektowe - Wepon dzieli się według Sposobu walki (Melee, Ranged) i według Rodzaju (Pointed, Edge, Blunt)
            w2 = new Ranged("Short bow", 2, 0.75, wk2, 60.0, 68.0);
            w3 = new Melee("Hammer", 8, 7.0, wk3, 1.5, "Iron");

            w1.ShowBonus(); // Polimorficzne wywoałnie metody "ShowBonus" z klasy abstakcyjnej "WeaponKind"
            w2.ShowBonus();
            w3.ShowBonus();

            Human northener = new Human("Northeners", "Human living in the north.");
            Elf drow = new Elf("Drows", "Dark-skinned elves living in caves.");
            HalfElf he = new HalfElf("Halelves", "Half-human, half-elf"); // Wielodziedziczenie. Klasa 'HalfElf' dziedziczy w sposób prosty po klasie 'Human' i poprzez interfejs po klasie 'Elf'

            northener.NoProfessionRestriction();
            drow.DarkVision();

            he.NoProfessionRestriction();
            he.DarkVision();                       
        }
    }
}
