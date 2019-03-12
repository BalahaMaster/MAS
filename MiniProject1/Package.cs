using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject1
{
    [Serializable]
    class Package : Consignment
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height{ get; set; }
        public double Dimension { get { return Width * Length * Height; } }
        public override double Price //Przesłonięcie atrybutu Price z klasy Consignment
        {
            get { return (Dimension/100) * base.Price; }
        }

        public Package(double width, double length, double height, double weight) : base(weight)
        {
            Width = width;
            Length = length;
            Height = height;
        }
    }
}
