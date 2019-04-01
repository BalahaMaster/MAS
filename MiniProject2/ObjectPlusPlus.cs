using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject2
{
    [Serializable]
    public enum Role { }
    public class ObjectPlusPlus : ObjectPlus
    {
        public Dictionary<Role, Dictionary<object, ObjectPlusPlus>> Constrains { get; set; }
        private static HashSet<ObjectPlusPlus> AllParts { get; set; }
        }

        private void AddConstrain()
        {

        }

        private void AddPart()
        {

        }
    }
}
