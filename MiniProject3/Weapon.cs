using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject3
{
    public abstract class Weapon 
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public double Weight { get; set; }
        public WeaponKind Kind{ get; set; }

        public Weapon(string name, int damage, double weight, WeaponKind weaponKind)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Damage = damage;
            Weight = weight;
            Kind = weaponKind;
        }
    }
}
