using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject1
{
    [Serializable]
    class Shipment : ObjectPlus
    {
        public Address SenderAddress { get; set; } //Atrybut złożony
        public Address PickupAddress { get; set; } //Atrybut złożony
        public List<Consignment> Consignments { get; set; } //Atrybut powtarzalny
        public double Cost
        {
            get
            {
                double cost = 0.0;
                foreach(Consignment c in Consignments)
                {
                    cost += c.Price;
                }
                return cost;
            }
        }

        public Shipment(Address senderAddress, Address pickupAddress, List<Consignment> consignments)
        {
            SenderAddress = senderAddress ?? throw new ArgumentNullException(nameof(senderAddress));
            PickupAddress = pickupAddress ?? throw new ArgumentNullException(nameof(pickupAddress));
            Consignments = consignments ?? throw new ArgumentNullException(nameof(consignments));
        }
    }
}
