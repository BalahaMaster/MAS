using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject3
{
    public class Profession : ObjectPlusPlus
    {
        public string Name { get; set; }
        public Profession(string name) : base()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public void AddWarrior(string speciality)
        {
            Warrior w = new Warrior(speciality);
            AddLink(GetAssociation(Role.Profession_Warrior), w);
        }
        public void AddMage(List<string> spells)
        {
            Mage m = new Mage(spells);
            AddLink(GetAssociation(Role.Profession_Mage), m);
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
