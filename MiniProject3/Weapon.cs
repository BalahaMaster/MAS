using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public abstract class Weapon 
    {
        public String Name { get; set; }
        public int Damage { get; set; }
        public double Weight { get; set; }
        public abstract double GetRange();
  
        protected Weapon(string name, int damage, double weight)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Damage = damage;
            Weight = weight;
        }
    }
}
