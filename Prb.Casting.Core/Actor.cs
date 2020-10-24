using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Casting.Core
{
    public class Actor
    {
        public string id;
        public string lastName;
        public string firstName;

        public Actor(string lastName, string firstName)
        {
            id = Guid.NewGuid().ToString();
            this.lastName = lastName;
            this.firstName = firstName;
        }
        public override string ToString()
        {
            return $"{lastName} ({firstName})";
        }
    }
}
