using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Edged : WeaponKind
    {
        public string Blade { get; set; }
        public double ExsanguinationChance { get; set; }
        public Edged(string blade, double exsanguinationChance)
        {
            Blade = blade ?? throw new ArgumentNullException(nameof(blade));
            ExsanguinationChance = exsanguinationChance;
        }

        public override void ShowBonus()
        {
            Console.WriteLine($"Exsanguination chance: {ExsanguinationChance}%");
        }
    }
}
