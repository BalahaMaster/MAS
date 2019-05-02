using System;

namespace MiniProject3
{
    class Program
    {
        static void Main(string[] args)
        {
            Profession


            Weapon w1;
            Weapon w2;
            Weapon w3;
            w1 = new Melee("Miecz", 5, 2.5, 1.5, "Stal");
            w2 = new Ranged("Łuk krótki", 2, 0.75, 60.0, 68.0);
            w3 = new Melee("Włócznia", 8, 7.0, 3.0, "Drewno");
        }
    }
}
