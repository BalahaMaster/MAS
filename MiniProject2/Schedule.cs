using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    class Schedule : ObjectPlusPlus
    {
        public Dictionary<DateTime, DateTime> Etd_Eta { get; set; } 

        public Schedule(Connection connection) : base()
        {
            AddConstrain(GetAssociation(Role.ScheduleConnection), connection);
            Etd_Eta = new Dictionary<DateTime, DateTime>();
        }

        public override string ToString()
        {
            List<ObjectPlusPlus> allConstrains = GetConsrtains(Role.ScheduleConnection).ToList();
            Connection connection = (Connection) allConstrains.First();
            return "Scheduler for " + connection;
        }
    }
}
