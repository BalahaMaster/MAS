using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public class Elf : Race, IElf
    {
        public Elf(string name, string description) : base(name, description) { }
        public void DarkVision()
        {
            Console.WriteLine("You can see in the dark");
        }
    }
}
