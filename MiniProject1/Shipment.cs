using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MiniProject1
{
    [Serializable]
    class Shipment : ObjectPlus
    {
        public Address SenderAddress { get; set; } //Atrybut złożony
        public Address PickupAddress { get; set; } //Atrybut złożony
        public List<Consignment> Consignments { get; set; } //Atrybut powtarzalny
        public double Cost // Atrybut pochodny
        {
            get
            {
                return Consignments.Sum(x => x.Price);
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
