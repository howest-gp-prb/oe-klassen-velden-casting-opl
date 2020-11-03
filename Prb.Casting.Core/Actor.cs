using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Casting.Core
{
    public class Actor
    {
        private string id;
        private string lastName;
        private string firstName;

        public string ID
        {
            get { return id; }
        }
        public string  LastName
        {
            get { return lastName; }
            set 
            {
                value = value.Trim();
                lastName = value; 
            }
        }
        public string  FirstName
        {
            get { return firstName; }
            set 
            {
                value = value.Trim();
                firstName = value; 
            }
        }


        public Actor(string lastName, string firstName)
        {
            id = Guid.NewGuid().ToString();
            LastName = lastName;
            FirstName = firstName;
        }
        public override string ToString()
        {
            return $"{lastName} ({firstName})";
        }
    }
}
