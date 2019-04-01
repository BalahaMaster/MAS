using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    [Serializable]
    public class ObjectPlusPlus : ObjectPlus
    {
        public Dictionary<string, Dictionary<object, ObjectPlusPlus>> Constrains { get; set; }
        private static HashSet<ObjectPlusPlus> AllParts { get; set; }
        
        private void AddConstrain(string role, string reverseRole, object classifier, ObjectPlusPlus constrainedObject, int counter)
        {
            Dictionary<object, ObjectPlusPlus> objectConstrains;
            if (counter < 1) 
                return;
            if (Constrains.ContainsKey(role))
                objectConstrains = Constrains[role];
            else
            {
                objectConstrains = new Dictionary<object, ObjectPlusPlus>();
                Constrains.Add(role, objectConstrains);
            }
            if (!objectConstrains.ContainsKey(classifier))
            {
                objectConstrains.Add(classifier, constrainedObject);
                constrainedObject.AddConstrain(reverseRole, role, this, this, counter - 1);
            }
        }

        private void AddPart()
        {

        }
    }
}
