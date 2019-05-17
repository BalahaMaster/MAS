using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniProject4
{
    public enum Role 
    {
        None,
        Player_Team, Team_Player,
        Leader_Team, Team_Leader,
        Player_Performance, Performance_Player,
        Team_Performance, Performance_Team
    }
    [Serializable]
    public class ObjectPlusPlus : ObjectPlus
    {
        public static List<Association> LegalAssociations { get; private set; } 
        private Dictionary<Role, Dictionary<object, ObjectPlusPlus>> Links { get; set; } = new Dictionary<Role, Dictionary<object, ObjectPlusPlus>>();
        private static HashSet<ObjectPlusPlus> AllParts { get; set; } = new HashSet<ObjectPlusPlus>();
        public bool IsLinked(Role role, ObjectPlusPlus linkedObject)
        {
            if(!Links.ContainsKey(role))
            {
                throw new Exception("Role undefined");
            }
            Dictionary<object, ObjectPlusPlus> roleLinks = Links[role];

            if(roleLinks.Values.Contains(linkedObject))
            {
                return true;
            }
            return false;
        }
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
            if (!LegalAssociations.Any(x => x.Role.Equals(association.Role)))
            {
                throw new Exception("Association is not legal");
            }
            if(this.GetType() != association.StartClassifier)
            {
                throw new Exception("This object type is not correct");
            }
            if(linkedObject.GetType() != association.EndClassifier)
            {
                throw new Exception("Linked object type is not correct");
            }
            Dictionary<object, ObjectPlusPlus> roleLinks;
            if (Links.ContainsKey(association.Role))
            {
                roleLinks = Links[association.Role];
            }
            else 
            {
                roleLinks = new Dictionary<object, ObjectPlusPlus>();
                Links.Add(association.Role, roleLinks);
            }
            if (!roleLinks.ContainsKey(linkedObject))
            {
                Association reverseAssociation = association.GetReversedAssociation();
                switch (association.EndMultiplicityLimit) 
                {
                    case -1:
                        roleLinks.Add(qualifier, linkedObject);
                        if(reverseAssociation != null)
                        {
                            linkedObject.AddLink(reverseAssociation, this, this, counter - 1);
                        }
                        break;
                    case 0:
                        if(roleLinks.Count != 0)
                        {
                            throw new Exception("Multiplicity limit has been reached");
                        }
                        roleLinks.Add(qualifier, linkedObject);
                        linkedObject.AddLink(reverseAssociation, this, this, counter - 1);
                        break;
                    default: 
                        if(roleLinks.Count >= association.EndMultiplicityLimit)
                        {
                            throw new Exception("Multiplicity limit has been reached");  
                        }
                        roleLinks.Add(qualifier, linkedObject);
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
            Association ass = LegalAssociations.First(x => x.Role.Equals(role));
            if (ass == null)
            {
                throw new Exception("No association for that role");
            }
            return ass;
        }
        public ObjectPlusPlus[] GetLinks(Role role)
        {
            List<ObjectPlusPlus> roleLinks = new List<ObjectPlusPlus>();
            if(Links.ContainsKey(role))
            {
                roleLinks = Links[role].Values.ToList();
            }
            return roleLinks.ToArray();
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
            Association s_sc = new Association(typeof(Player), 1, typeof(Team), -1, Role.Player_Team, Role.Team_Player);
            AddAssociation(s_sc);
            AddAssociation(s_sc.CreateReversedAssociation());

            Association c_sc = new Association(typeof(Player), 1, typeof(Team), 1, Role.Leader_Team, Role.Team_Leader);
            AddAssociation(c_sc);
            AddAssociation(c_sc.CreateReversedAssociation());

            Association pl_pr = new Association(typeof(Player), 1, typeof(Performance), 1, Role.Player_Performance, Role.Performance_Player);
            AddAssociation(pl_pr);
            AddAssociation(pl_pr.CreateReversedAssociation());

            Association t_pr = new Association(typeof(Team), 1, typeof(Performance), 1, Role.Team_Performance, Role.Performance_Team);
            AddAssociation(t_pr);
            AddAssociation(t_pr.CreateReversedAssociation());

        }
    }
}
