using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Schedule : ObjectPlusPlus
    {
        public string Name { get; set; }
        private Schedule(string name) : base()
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
        public static Schedule CreateSchedule(Connection connection, string name)
        {
            if(connection == null)
            {
                throw new Exception("Cannot create schedule for not existing Connection");
            }
            if(connection.GetLinks(Role.ConnectionShedule).Count() != 0)
            {
                throw new Exception("Connection already has a schedule");
            }
            Schedule result = new Schedule(name);
            connection.AddPart(GetAssociation(Role.ConnectionShedule), result);
            return result;
        }
    }
}