using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    [Serializable]
    class Consignment 
    {
        public string Id { get; set; }
        public double Weight { get; set; }
        public static double PriceModifier 
        {
            get { return 0.5; }
            set { }
        }
        public Shipment Shipment { get; set; }
        public virtual double Price { get { return Weight * PriceModifier; } } 

        public Consignment(double weight)
        {
            Weight = weight;
            Id = this.GetHashCode() + DateTime.UtcNow.Millisecond.ToString();
        }
    }
}
