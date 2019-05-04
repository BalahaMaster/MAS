using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Pointed : WeaponKind
    {
        public string Tip { get; set; }
        public double PiercingChance { get; set; }

        public Pointed(string tip, double piercingChance)
        {
            Tip = tip ?? throw new ArgumentNullException(nameof(tip));
            PiercingChance = piercingChance;
        }

        public override void ShowBonus()
        {
            Console.WriteLine($"Piercing chance: {PiercingChance}%" );
        }
    }
}
