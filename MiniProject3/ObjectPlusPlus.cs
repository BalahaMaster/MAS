using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject3
{
    public enum Role 
    {
        Profession_Warrior, Warrior_Profession,
        Profession_Mage, Mage_Profession
    }
    [Serializable]
    public class ObjectPlusPlus
    {
        public static List<Association> LegalAssociations { get; private set; } 
        private Dictionary<Role, Dictionary<object, ObjectPlusPlus>> Links { get; set; } = new Dictionary<Role, Dictionary<object, ObjectPlusPlus>>();
        private static HashSet<ObjectPlusPlus> AllParts { get; set; } = new HashSet<ObjectPlusPlus>();
        private void AddLink(Association association, ObjectPlusPlus linkedObject, object qualifier, int counter)
        {
            if (counter < 1)
            {
                return;
            }
            if(linkedObject == null)
            {
                return;
            }
            if (association == null)
            {
                return;
            }
            // sprawdzenie czy ta asocjacja została zdefiniowana
            if (!LegalAssociations.Any(x => x.Role.Equals(association.Role)))
            {
                throw new Exception("Association is not legal");
            }
            // sprawdzenie czy typ obiektu do którego dodajesz powiązanie zgadza się ze wzroem asocjacji
            if(this.GetType() != association.StartClassifier)
            {
                throw new Exception("This object type is not correct");
            }
            // sprawdzenie czy typ obiektu który chcesz powiązać zgadza się ze wzorem asocjacji
            if (linkedObject.GetType() != association.EndClassifier)
            {
                throw new Exception("Linked object type is not correct");
            }
            Dictionary<object, ObjectPlusPlus> roleLinks;
            // sprawdzenie czy istnieją powiązania dla roli
            if (Links.ContainsKey(association.Role))
            {
                roleLinks = Links[association.Role];
            }
            else 
            {
                roleLinks = new Dictionary<object, ObjectPlusPlus>();
                Links.Add(association.Role, roleLinks);
            }
            // sprawdzenie czy powiązania dla roli zawierają obiekt, który chcemy powiązać
            if (!roleLinks.ContainsKey(linkedObject))
            {
                // stworzenie odwrotnej asocjacji do połączenie zwrotnego
                Association reverseAssociation = association.GetReversedAssociation();
                // sprawdzenie liczności asocjacji dla obiektu, który chcemy powiązać
                switch (association.EndMultiplicityLimit) 
                {
                    // jeżeli nie ma limitu liczności asocjacji
                    case -1:
                        roleLinks.Add(qualifier, linkedObject);
                        if(reverseAssociation != null)
                        {
                            // stworzenie połączenia zwrotnego
                            linkedObject.AddLink(reverseAssociation, this, this, counter - 1);
                        }
                        break;
                    // przypadek, w którym limit liczność to 1
                    case 0:
                        if(roleLinks.Count != 0)
                        {
                            throw new Exception("Multiplicity limit has been reached");
                        }
                        roleLinks.Add(qualifier, linkedObject);
                        // stworzenie połączenia zwrotnego
                        linkedObject.AddLink(reverseAssociation, this, this, counter - 1);
                        break;
                    // przypadek, w którym limit liczności to x
                    default: 
                        if(roleLinks.Count >= association.EndMultiplicityLimit)
                        {
                            throw new Exception("Multiplicity limit has been reached");  
                        }
                        roleLinks.Add(qualifier, linkedObject);
                        // stworzenie połączenia zwrotnego
                        linkedObject.AddLink(reverseAssociation, this, this, counter - 1);
                        break;
                }
            }
        }
        public void AddLink(Association association, ObjectPlusPlus linkedObject, object qualifier)
        {
            AddLink(association, linkedObject, qualifier, 2);
        }
        public void AddLink(Association association, ObjectPlusPlus linkedObject)
        {
            AddLink(association, linkedObject, linkedObject, 2);
        }
        public void AddPart(Association association, ObjectPlusPlus partObject)
        {
            /// sprawdzenie czy zbiór części zawiera podany obiekt
            if(AllParts.Contains(partObject))
            {
                throw new Exception("Given part object is already linked");
            }
            AddLink(association, partObject);
            AllParts.Add(partObject);
        }
        public static void AddAssociation(Association association)
        {
            if(LegalAssociations == null)
            {
                LegalAssociations = new List<Association>();
            }
            if (LegalAssociations.Any(x => x.Role.Equals(association.Role)))
            {
                throw new Exception("Association for this role already exists");
            }
            else
            {
                LegalAssociations.Add(association);
            }
        }
        public static Association GetAssociation(Role role)
        {
            // próba przypisania asocjacja z list zdefiniowanych asocjacji
            Association ass = LegalAssociations.FirstOrDefault(x => x.Role.Equals(role));
            if (ass == null)
            {
                throw new Exception("No association for that role");
            }
            return ass;
        }
        public List<ObjectPlusPlus> GetLinks(Role role)
        {
            List<ObjectPlusPlus> roleLinks = new List<ObjectPlusPlus>();
            if(Links.ContainsKey(role))
            {
                roleLinks = Links[role].Values.ToList();
            }
            return roleLinks;
        }
        public ObjectPlusPlus GetLinknedObject(Role role, Object qualifier)
        {
            if(!Links.ContainsKey(role))
            {
                throw new Exception("There are no links for this role");
            }
            if(!Links[role].ContainsKey(qualifier))
            {
                return null;
            }
            return Links[role][qualifier];
        }
        public void ShowLinks(Role role)
        {
            if(!Links.ContainsKey(role))
            {
                System.Console.WriteLine("There are no links for this role");
                return;
            }
            System.Console.WriteLine("{0} '{1}' links for role {2}", this.GetType(), this, role);
            Dictionary<object, ObjectPlusPlus> roleLinks = Links[role];
            foreach(KeyValuePair<object, ObjectPlusPlus> d in roleLinks)
            {
                System.Console.WriteLine(d.Value);        
            }
        }
        public static void DefineAssociations()
        {
            Association prof_war = new Association(typeof(Profession), 1, typeof(Warrior), 1, Role.Profession_Warrior, Role.Warrior_Profession);
            AddAssociation(prof_war);
            AddAssociation(prof_war.CreateReversedAssociation());

            Association prof_mag = new Association(typeof(Profession), 1, typeof(Mage), 1, Role.Profession_Mage, Role.Mage_Profession);
            AddAssociation(prof_mag);
            AddAssociation(prof_mag.CreateReversedAssociation());
        }
    }
}
