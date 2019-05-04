using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    class HalfElf : Human, IElf
    {
        public HalfElf(string name, string description) : base(name, description)
        {
        }

        public void DarkVision()
        {
            Console.WriteLine("You can see in the dark");
        }
    }
}
