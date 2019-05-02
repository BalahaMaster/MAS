﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Melee : Weapon
    {
        public double Lenght { get; set; }
        public string Material { get; set; }

        public Melee(string name, int damage, double weight, double lenght, string material) : base(name, damage, weight)
        {
            Lenght = lenght;
            Material = material;
        }

        public override double GetRange()
        {
            return Lenght;
        }
    }
}
