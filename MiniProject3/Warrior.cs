using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Warrior : ObjectPlusPlus
    {
        public string Speciality { get; set; }
        public Warrior(string speciality) 
        {
            Speciality = speciality ?? throw new ArgumentNullException(nameof(speciality));
        }
    }
}
