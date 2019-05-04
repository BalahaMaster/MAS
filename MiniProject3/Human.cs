using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Human : Race
    { 
        public Human(string name, string description) : base(name, description) { }
        public void NoProfessionRestriction()
        {
            Console.WriteLine("You have no profession restriction");
        }
    }
}
