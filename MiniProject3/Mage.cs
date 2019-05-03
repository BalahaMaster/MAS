using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Mage : ObjectPlusPlus
    {
        public List<string> Spells { get; set; }
        private Mage(List<string> spells)
        {
            Spells = spells ?? throw new ArgumentNullException(nameof(spells));
        }

        public static Mage Create(Profession p, List<string> spells)
        {            
            if (p == null)
            {
                throw new Exception("Cannot create Mage for not existing Profession");
            }
            Mage m = new Mage(spells);
            try
            {
                p.AddPart(GetAssociation(Role.Profession_Mage), m);
            }
            catch(Exception e)
            {
                return null;
            }
            return m;
        }
    }
}
