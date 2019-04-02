using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public enum Role
    {
        ShipmentSenderAddress,
        ShipmentPickupAddress,
        ConnectionStartAddress,
        ConnectionEndAddress,
        Shipment_ShipmentConnection, ShipmentConnection_Shipment,
        Connection_ShipmentConnection, ShipmentConnection_Connection,
        ShipmentContainsConsignments, ConsignmentsContainedByShipment,
        ConnectionShedule, ScheduleConnection,

    }
    [Serializable]
    public class ObjectPlusPlus : ObjectPlus
    {
        private static List<Association> LegalAssociations { get; set; }
        private Dictionary<Role, Dictionary<object, ObjectPlusPlus>> Constrains { get; set; }
        private static HashSet<ObjectPlusPlus> AllParts { get; set; }        
        private void AddConstrain(Association association, ObjectPlusPlus constrainedObject, int counter)
        {
            if (counter < 1)
            {
                return;
            }
            // Check if association is legal
            if (!LegalAssociations.Any(x => x.Role.Equals(association.Role)))
            {
                throw new Exception("Association is not legal");
            }
            // Check if association exists
            if (association == null)
            {
                return;
            }
            // Get role constrains for this object
            Dictionary<object, ObjectPlusPlus> roleConstrains;
            if (Constrains.ContainsKey(association.Role))
            {
                roleConstrains = Constrains[association.Role];
            }
            else
            {
                roleConstrains = new Dictionary<object, ObjectPlusPlus>();
                Constrains.Add(association.Role, roleConstrains);
            }
            // Check if role constrains contains this object
            if (!roleConstrains.ContainsKey(constrainedObject))
            {
                // Get reverse association
                Association reverseAssociation = LegalAssociations.First(x => x.Role.Equals(association.ReverseRole));
                // Add the object if multiplicity allows it
                switch (association.EndMultiplicityLimit) 
                {
                    // For many multiplicity
                    case -1:
                        roleConstrains.Add(constrainedObject, constrainedObject);
                        if(reverseAssociation != null)
                        {
                            constrainedObject.AddConstrain(reverseAssociation, this, counter - 1);
                        }
                        break;
                    // For optional
                    case 0:
                        if(roleConstrains.Count == 0)
                        {
                            constrainedObject.AddConstrain(reverseAssociation, this, counter - 1);
                        }
                        break;
                    // For exact number limit
                    default: 
                        if(roleConstrains.Count < association.EndMultiplicityLimit)
                        {
                            constrainedObject.AddConstrain(reverseAssociation, this, counter - 1);
                        }
                        break;
                }
            }
        }

        public void AddConstrain(Association association, ObjectPlusPlus constrainedObject)
        {
            AddConstrain(association, constrainedObject, 2);
        }

        private void AddPart()
        {
            
        }

        public static void AddAssociation(Association association)
        {
            if (LegalAssociations.Any(x => x.Role.Equals(association.Role)))
            {
                throw new Exception("Association for this role already exists");
            }
            else
            {
                LegalAssociations.Add(association);
            }
        }

        public Association GetAssociation(Role role)
        {
            Association ass = LegalAssociations.First(x => x.Role.Equals(role));
            if (ass == null)
            {
                throw new Exception("No association for that role");
            }
            return ass;
        }
    }
}
