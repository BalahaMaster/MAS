using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Warrior : ObjectPlusPlus
    {
        public string Speciality { get; set; }
        private Warrior(string speciality) 
        {
            Speciality = speciality ?? throw new ArgumentNullException(nameof(speciality));
        }
        public static Warrior Create(Profession p, string speciality)
        {
            if (p == null)
            {
                throw new Exception("Cannot create Warrior for not existing Profession");
            }
            Warrior w = new Warrior(speciality);
            try
            {
                // Dodanie obiektu Warrior jako częsci
                p.AddPart(GetAssociation(Role.Profession_Warrior), w);
            }
            catch (Exception e)
            {
                throw new Exception("Couldn't create a Warrior: " + e);
            }
            return w;
        }
    }
}
