using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Association
    {
        // Typ obiektu 'tego' obiektu
        public Type StartClassifier { get; set; }
        // Liczność po stronie 'tego' obiektu
        public int StartMultiplicityLimit { get; set; }
        // Typ obietku, z którym chcemy połączyć 'ten' obiekt
        public Type EndClassifier { get; set; }
        // Licznośc obiektu, z którym chcemy połączyć 'ten' obiekt
        public int EndMultiplicityLimit { get; set; }
        // Rola tej asocjacji
        public Role Role { get; set; }
        // Rola asocjacji zwrotnej
        public Role ReverseRole { get; set; }
        public Association(Type startClassifier, Type endClassifier, int endMultiplicityLimit, Role role)
        {
            StartClassifier = startClassifier ?? throw new ArgumentNullException(nameof(startClassifier));
            EndClassifier = endClassifier ?? throw new ArgumentNullException(nameof(endClassifier));
            EndMultiplicityLimit = endMultiplicityLimit;
            Role = role;
        }
        public Association(Type startClassifier, int startMultiplicityLimit, Type endClassifier, int endMultiplicityLimit, Role role, Role reverseRole) : this(startClassifier, endClassifier, endMultiplicityLimit, role)
        {
            ReverseRole = reverseRole;
            StartMultiplicityLimit = startMultiplicityLimit;
        }
        public Association CreateReversedAssociation()
        {
            return new Association(EndClassifier, EndMultiplicityLimit, StartClassifier, StartMultiplicityLimit, ReverseRole, Role);
        }
        public Association GetReversedAssociation()
        {
            return ObjectPlusPlus.LegalAssociations.FirstOrDefault(x => x.Role.Equals(ReverseRole));
        }
    }
}
