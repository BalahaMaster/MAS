using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Mage : ObjectPlusPlus
    {
        public List<string> Spells { get; set; }
        public Mage(List<string> spells)
        {
            Spells = spells ?? throw new ArgumentNullException(nameof(spells));
        }
    }
}
