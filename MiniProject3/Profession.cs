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
            try
            {
                Warrior w = Warrior.Create(this, speciality);
                Console.WriteLine("Warrior was created");
            }
            catch(Exception e)
            {
                Console.WriteLine("Warrior was not created: " + e);
            }
            
        }
        private void AddMage(List<string> spells)
        {
            try
            {
                Mage m = Mage.Create(this, spells);
                Console.WriteLine("Mage was created");
            }
            catch(Exception e)
            {
                Console.WriteLine("Mage was not created: " + e);
            }
        }
        public string GetSpells()
        {
            List<ObjectPlusPlus> list = GetLinks(Role.Profession_Mage);
            Mage m = (Mage)list.FirstOrDefault();
            if (m != null)
            {
                return "Czary:\n" + String.Join("\n", m.Spells);
            }
            else
            {
                return ("Ta profesja nie posaida czarów ponieważ nie jest Magiem.");
            }
        }
        public string GetSpeciality()
        {
            List<ObjectPlusPlus> list = GetLinks(Role.Profession_Warrior);
            Warrior w = (Warrior)list.FirstOrDefault();
            if (list != null)
            {
                return "Specjalność:\n" + w.Speciality;
            }
            else
            {
                return ("Ta profesja nie posiada specjalności ponieważ nie jest wojownikiem");
            }
        }
    }
}
