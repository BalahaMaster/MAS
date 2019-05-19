using System;
using System.Collections.Generic;

namespace MiniProject4
{
    public class Team : ObjectPlus4
    {
        public string Name { get; set; }
        public SortedList<int, Player> Ranking { get; set; }
        
        public Team()
        {
            Ranking = new SortedList<int, Player>();
        }
    }
}