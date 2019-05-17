using System;

namespace MiniProject4
{
    [Serializable]
    public class ObjectPlus4 : ObjectPlusPlus
    {
        public ObjectPlus4() : base()
        {
            
        }

        public void AddLink_Subset(Association parentAssociation, Association childAssociation, ObjectPlusPlus linkedObject)
        {
            if(IsLinked(parentAssociation.Role, linkedObject)){
                AddLink(childAssociation.Role, linkedObject);
            }
            else
            {
                throw new Exception("There is no parent associayion for that object");
            }
        }
        
    }
}