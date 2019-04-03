using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject2
{
    public class Association
    {
        public Type StartClassifier { get; set; }
        public int StartMultiplicityLimit { get; set; }
        public Type EndClassifier { get; set; }
        public int EndMultiplicityLimit { get; set; }
        public Role Role { get; set; }
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
    }
}
