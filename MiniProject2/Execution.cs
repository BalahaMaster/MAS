using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Execution : ObjectPlusPlus
    {   
        // Implementacja asocjacji z atrybutem - Atrybuty asocjacji.
        public DatePair Estimated { get; set; }
        public DatePair Actual { get; set; }
        public Execution(DatePair actual, DatePair estimated) : this(estimated)
        {
            Actual = actual;
        }
        public Execution(DatePair estimated) : base()
        {
            Estimated = estimated;
        }
        public override string ToString()
        {
            String result = "Execution Dates:\n";
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
        // Implementacja asocjacji z atrybutem - Metoda dodaje asocjację pomiędzy obiektami 'Shipment' i 'Connection'.
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
