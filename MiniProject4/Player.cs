using System;
using System.Collections.Generic;

namespace MiniProject4
{
    public class Player
    {
        private static int ageLimit = 18;
        private static HashSet<string> nicknames = new HashSet<string>();
        private string nickname;
        public string Nickname 
        {
            get { return nickname; }
            set {
                    if(!nicknames.Add(value))
                    {
                        throw new Exception($"Nickname {value} is taken");
                    }
                }
        }
        private int age;
        public int Age 
        {
            get {return age; }
            set 
            {
                if(value < ageLimit)
                { 
                    throw new Exception("Age is below limit");
                }
                age = value;
            }
        }
        private int experiencePoints;
        public int ExperiencePoints 
        {
            get {return experiencePoints; }
            set 
            {
                if(value < experiencePoints)
                { 
                    throw new Exception("Experience cannot dimminish");
                }
                experiencePoints = value;
            }
        }
    }
}