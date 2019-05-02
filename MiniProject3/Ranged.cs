using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Ranged : Weapon
    {
        public double Range { get; set; }
        public double Accuracy { get; set; }
        public Ranged(string name, int damage, double weight, double range, double accuracy) : base(name, damage, weight)
        {
            Range = range;
            Accuracy = accuracy;
        }
        public override double GetRange()
        {
            return Range;
        }
    }
}
