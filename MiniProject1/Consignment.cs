using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject1
{
    [Serializable]
    class Consignment : ObjectPlus
    {
        public double Weight { get; set; }
        public static double PriceModifier //Atrybut klasowy
        {
            get { return 0.5; }
            set { }
        }
        public virtual double Price { get { return Weight * PriceModifier; } } //Atrybut pochodny

        public Consignment(double weight)
        {
            Weight = weight;
        }
        public static double GetAllWeightsSum() //Metoda klasowa
        {
            double sum = 0.0;
            foreach (Object o in ObjectPlus.Extensions[typeof(Consignment)])
            {
                Consignment c = (Consignment) o;
                sum += c.Weight;
            }
            return sum;
        }
    }
}
