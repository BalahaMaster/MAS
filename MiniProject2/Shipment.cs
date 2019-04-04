using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    [Serializable]
    public class Shipment : ObjectPlusPlus
    {
        public string Name { get; set; }
        public Address PickupAddress 
        {
            get
            {
                return (Address) GetLinks(Role.ShipmentPickupAddress).FirstOrDefault();
            }
            set
            {
                AddLink(this.GetAssociation(Role.ShipmentPickupAddress), value);
            }
        }
        public Address SenderAddress
        {
            get
            {
                return (Address) GetLinks(Role.ShipmentSenderAddress).FirstOrDefault();
            }
            set
            {
                AddLink(this.GetAssociation(Role.ShipmentSenderAddress), value);
            }
        }
        public List<Execution> Executions
        {
            get
            {
                return (List<Execution>)GetLinks(Role.Shipment_Execution).ToList().ConvertAll(x => (Execution)x);
            }
            set
            {
                foreach (Execution e in GetLinks(Role.Shipment_Execution))
                {
                    RemoveLink(GetAssociation(Role.Shipment_Execution), e);
                }
                foreach (Execution e in value)
                {
                    AddLink(GetAssociation(Role.Shipment_Execution), e);
                }
            }
        }
        public Shipment(string name) : base()
        {
            Executions = new List<Execution>();
            Name = name;
        }

        public override string ToString()
        {
            return Name;       
        }
    }
}
