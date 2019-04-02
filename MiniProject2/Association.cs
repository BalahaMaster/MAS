using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{   
    public enum Role 
    { 
        ShipmentSenderAddress, ShipmentPickupAddress,
        ConnectionStartAddress, ConnectionEndAddress,
        ShipmentExecutedByShipmentConnection, ShipmentConnectionExecuteShipment,
        ConnectionExecutedByShipmentConnection, ShipmentconnectionExecuteConnection,
        ShipmentContainsConsignments, ConsignmentsContainedByShipment,
        ConnectionShedule, ScheduleConnection,
                
    } 
    public class Association
    {
        public static Dictionary<Type, List<Association>> LegalAssociations { get; set; }
        public Type StartClassifier { get; set; }
        public int StartClassifierMultiplicity { get; set; }
        public Type EndClassifier { get; set; }
        public int EndClassifierMultiplicity { get; set; }
        public Role Role { get; set; }
        private Association(Type startClassifier, Role role, Type endClassifier, int startClassifierMultiplicity, int endClassifierMultiplicity)
        {
            StartClassifier = startClassifier;
            StartClassifierMultiplicity = startClassifierMultiplicity;
            EndClassifier = endClassifier;
            EndClassifierMultiplicity = endClassifierMultiplicity;
            Role = role;

            List<Association> associations;
            if(LegalAssociations.ContainsKey(startClassifier.GetType()))
            {
                associations = LegalAssociations[startClassifier.GetType()];
                if(associations.Where(x => x.Role.Equals(role) && x.StartClassifier.Equals(startClassifier) && x.EndClassifier.Equals(endClassifier)).Any())
                {
                    throw new Exception("Association already exists");
                }
            }
            else
            {
                associations = new List<Association>();
                LegalAssociations.Add(startClassifier.GetType(), associations);
            }
            associations.Add(this);
        }

    }
}
