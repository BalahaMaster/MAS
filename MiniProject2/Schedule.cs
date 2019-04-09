using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Schedule : ObjectPlusPlus
    {
        public Dictionary<int, DatePair> Dates { get; set; } 
        private Schedule() : base()
        {
            Dates = new Dictionary<int, DatePair>();
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
            if(connection.GetLinks(Role.ConnectionShedule).Count() != 0)
            {
                throw new Exception("Connection already has a schedule");
            }
            Schedule result = new Schedule();
            connection.AddPart(GetAssociation(Role.ConnectionShedule), result);
            return result;
        }
    }
}