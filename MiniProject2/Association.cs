using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    public class Association
    {
        public static Dictionary<Type, Association> LegalAssociations { get; set; }
        public Type StartClassifier { get; set; }
        public Type EndClassifier { get; set; }
        public Role Role { get; set; }
        private Association(Type startClassifier, Role role, Type endClassifier)
        {
            StartClassifier = startClassifier;
            EndClassifier = endClassifier;
            Role = role;
        }

    }
}
