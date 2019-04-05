using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Schedule : ObjectPlusPlus
    {
        public Dictionary<DateTime, DateTime> Etd_Eta { get; set; } 
        private Schedule() : base()
        {
            Etd_Eta = new Dictionary<DateTime, DateTime>();
            AddPart(GetAssociation(Role.ScheduleConnection), this);
        }
        public override string ToString()
        {
            List<ObjectPlusPlus> allLinks = GetLinks(Role.ScheduleConnection).ToList();
            Connection connection = (Connection) allLinks.First();
            return "Schedule for " + connection;
        }
        public static Schedule CreateSchedule(Connection connection)
        {
            if(connection == null)
            {
                throw new Exception("Cannot create schedule for not existing Connection");
            }
            return new Schedule();
        }
    }
}
