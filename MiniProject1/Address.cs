using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject1
{
    [Serializable]
    class Address : ObjectPlus
    {
        public string StreetName { get; }
        public string FlatNumber { get; } //Atrybut opcjonalny
        public string StreetNumber { get; }
        public string City { get; }
        public string Country { get; }
        public string PostalCode { get; }

        public string FullAddress
        {
            get
            {
                string temp;
                if (FlatNumber == null)
                    temp = StreetNumber;
                else
                    temp = StreetNumber + "\\" + FlatNumber;
                return String.Format("{0} {1}\n{2} {3}\n{4}", StreetName, temp, City, PostalCode, Country);
            }
        }

        public Address(string streetName, string streetNumber, string city, string country, string postalCode)
        {
            StreetName = streetName ?? throw new ArgumentNullException(nameof(streetName));
            StreetNumber = streetNumber ?? throw new ArgumentNullException(nameof(streetNumber));
            City = city ?? throw new ArgumentNullException(nameof(city));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            PostalCode = postalCode ?? throw new ArgumentNullException(nameof(postalCode));
        }

        public Address(string streetName, string streetNumber, string flatNumber, string city, string country, string postalCode) : this(streetName, streetNumber, city, country, postalCode)
        {
            FlatNumber = flatNumber?? throw new ArgumentNullException(nameof(postalCode));
        }
    }
}
