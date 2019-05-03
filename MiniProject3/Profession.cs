using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject3
{
    public class Profession : ObjectPlusPlus
    {
        public string Name { get; set; }
        public Profession(string name, string speciality) : base()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            AddWarrior(speciality);
        }
        public Profession(string name, List<string> spells)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            AddMage(spells);
        }
        public Profession(string name, string speciality, List<string> spells) : this(name, speciality)
        {
            AddMage(spells);
        }
        private void AddWarrior(string speciality)
        {
            Warrior w = Warrior.Create(this, speciality);
            if(w != null)
            {
                Console.WriteLine("Warrior was created");
            }
            else
            {
                Console.WriteLine("This profession is already a warrior");
            }
        }
        private void AddMage(List<string> spells)
        {
            Mage m = Mage.Create(this, spells);
            if(m != null)
            {
                Console.WriteLine("Mage was created");
            }
            else
            {
                Console.WriteLine("This profession is already a mage");
            }
        }
        public string GetSpells()
        {
            List<ObjectPlusPlus> list = GetLinks(Role.Profession_Mage);
            Mage m = (Mage)list.FirstOrDefault();
            if (list != null)
            {
                return String.Join("\n", m.Spells);
            }
            else
            {
                throw new Exception("This Profession is not a Mage");
            }
        }
        public string GetSpeciality()
        {
            List<ObjectPlusPlus> list = GetLinks(Role.Profession_Warrior);
            Warrior w = (Warrior)list.FirstOrDefault();
            if (list != null)
            {
                return w.Speciality;
            }
            else
            {
                throw new Exception("This Profession is not a Warrior");
            }
        }
    }
}
