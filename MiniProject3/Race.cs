using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject3
{
    public abstract class Race
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Race(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
    }
}
