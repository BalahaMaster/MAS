using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Blunt : WeaponKind
    {
        public string Head { get; set; }
        public double StunChance { get; set; }
        public Blunt(string head, double stunChance)
        {
            Head = head ?? throw new ArgumentNullException(nameof(head));
            StunChance = stunChance;
        }

        public override void ShowBonus()
        {
            Console.WriteLine($"Stun chanve: {StunChance}%");
        }
    }
}
