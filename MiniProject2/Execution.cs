using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Execution : ObjectPlusPlus
    {   
        public string Name { get; set; }
        public DatePair Estimated { get; set; }
        public DatePair Actual { get; set; }
        public Execution(string name, DatePair actual, DatePair estimated) : this(name, estimated)
        {
            Actual = actual;
        }
        public Execution(string name, DatePair estimated) : base()
        {
            Name = name;
            Estimated = estimated;
        }
        public override string ToString()
        {
            String result = Name + " execution Dates:\n";
            if(Estimated != null)
            {   
                result += String.Format("ETD: {0}\nETA: {1}\n",
                    Estimated.Departure.ToString().Equals(DateTime.MinValue.ToString()) ? "" : Estimated.Departure.ToString(), 
                    Estimated.Arrival.ToString().Equals(DateTime.MinValue.ToString()) ? "" : Estimated.Arrival.ToString());
            }
            if(Actual != null)
            {
                result += String.Format("ATD: {0}\nATA: {1}\n",
                    Actual.Departure.ToString().Equals(DateTime.MinValue.ToString()) || Actual == null ? "" : Actual.Departure.ToString(), 
                    Actual.Arrival.ToString().Equals(DateTime.MinValue.ToString()) || Actual == null ? "" : Actual.Arrival.ToString());
            }
            return result;
        }
        public void AddLinks(Shipment shipment, Connection connection)
        {
            if(shipment == null || connection == null)
            {
                throw new Exception("Shipment or Connection cannot be null");
            }
            AddLink(ObjectPlusPlus.GetAssociation(Role.Execution_Shipment), shipment);
            AddLink(ObjectPlusPlus.GetAssociation(Role.Execution_Connection), connection);
        }
    }
}
