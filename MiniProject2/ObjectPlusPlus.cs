using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
        public enum Role 
    {
        None,
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
        private Dictionary<Role, Dictionary<object, ObjectPlusPlus>> Constrains { get; set; } = new Dictionary<Role, Dictionary<object, ObjectPlusPlus>>();
        private static HashSet<ObjectPlusPlus> AllParts { get; set; } = new HashSet<ObjectPlusPlus>();
        private void AddConstrain(Association association, ObjectPlusPlus constrainedObject, int counter)
        {
            if (counter < 1)
            {
                return;
            }
            // Check if association exists
            if (association == null)
            {
                return;
            }
            // Check if association is legal
            if (!LegalAssociations.Any(x => x.Role.Equals(association.Role)))
            {
                throw new Exception("Association is not legal");
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
                Association reverseAssociation = LegalAssociations.FirstOrDefault(x => x.Role.Equals(association.ReverseRole));
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
                        if(roleConstrains.Count != 0)
                        {
                            throw new Exception("Multiplicity limit has been reached");
                        }
                        roleConstrains.Add(constrainedObject, constrainedObject);
                        constrainedObject.AddConstrain(reverseAssociation, this, counter - 1);
                        break;
                    // For exact number limit
                    default: 
                        if(roleConstrains.Count >= association.EndMultiplicityLimit)
                        {
                            throw new Exception("Multiplicity limit has been reached");  
                        }
                        roleConstrains.Add(constrainedObject, constrainedObject);
                        constrainedObject.AddConstrain(reverseAssociation, this, counter - 1);
                        break;
                }
            }
        }

        public void AddConstrain(Association association, ObjectPlusPlus constrainedObject)
        {
            AddConstrain(association, constrainedObject, 2);
        }

        private void AddPart(Association association, ObjectPlusPlus partObject)
        {
            if(AllParts.Contains(partObject))
            {
                throw new Exception("Obiekt część już jest powiązany z całością");
            }
            AddConstrain(association, partObject);
            AllParts.Add(partObject);
        }
        public static void AddAssociation(Association association)
        {
            if(LegalAssociations == null)
            {
                LegalAssociations = new List<Association>();
            }
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

        public ObjectPlusPlus[] GetConsrtains(Role role)
        {
            if(!Constrains.ContainsKey(role))
            {
                throw new Exception("There are no constrains for this role");
            }
            return Constrains[role].Values.ToArray();
        }

        public ObjectPlusPlus GetConsrtainedObject(Role role, Object qualifier)
        {
            if(!Constrains.ContainsKey(role))
            {
                throw new Exception("There are no constrains for this role");
            }
            if(!Constrains[role].ContainsKey(qualifier))
            {
                throw new Exception("No constrain for this qualifier");
            }
            return Constrains[role][qualifier];
        }
        
        public void ShowConstrains(Role role)
        {
            if(!Constrains.ContainsKey(role))
            {
                throw new Exception("There are no constrains for this role");
            }
            System.Console.WriteLine("{0} constrains for role {1}", this, role);
            foreach(KeyValuePair<object, ObjectPlusPlus> d in Constrains[role])
            {
                System.Console.WriteLine("\t"+d.Value);        
            }
        }
        public static void DefineAssociations()
        {
            List<Association> definedAssociation = new List<Association>();

            Association s_a1 = new Association(typeof(Shipment), typeof(Address), 1, Role.ShipmentSenderAddress);
            Association s_a2 = new Association(typeof(Shipment), typeof(Address), 1, Role.ShipmentPickupAddress);
            Association c_a1 = new Association(typeof(Connection), typeof(Address), 1, Role.ConnectionStartAddress);
            Association c_a2 = new Association(typeof(Connection), typeof(Address), 1, Role.ConnectionEndAddress);
            definedAssociation.Add(s_a1);
            definedAssociation.Add(s_a2);
            definedAssociation.Add(c_a1);
            definedAssociation.Add(c_a2);

            Association s_sc = new Association(typeof(Shipment), 1, typeof(ShipmentConnection), -1, Role.Shipment_ShipmentConnection, Role.ShipmentConnection_Shipment);
            definedAssociation.Add(s_sc);
            definedAssociation.Add(s_sc.CreateReversedAssociation());

            Association c_sc = new Association(typeof(Connection), 1, typeof(ShipmentConnection), -1, Role.Connection_ShipmentConnection, Role.ShipmentConnection_Connection);
            definedAssociation.Add(c_sc);
            definedAssociation.Add(c_sc.CreateReversedAssociation());

            Association shi_cons = new Association(typeof(Shipment), 1, typeof(Consignment), -1, Role.ShipmentContainsConsignments, Role.ConsignmentsContainedByShipment);
            definedAssociation.Add(shi_cons);
            definedAssociation.Add(shi_cons.CreateReversedAssociation());

            Association con_sch = new Association(typeof(Connection), 1, typeof(Schedule), 1, Role.ConnectionShedule, Role.ScheduleConnection);
            definedAssociation.Add(con_sch);
            definedAssociation.Add(con_sch.CreateReversedAssociation());

            foreach(Association ass in definedAssociation)
            {
                AddAssociation(ass);
            }
        }
    }
}
