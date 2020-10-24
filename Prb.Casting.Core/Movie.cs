using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Casting.Core
{
    public class Movie
    {
        public string id;
        public string name;
        public int year;

        public Movie(string name, int year)
        {
            id = Guid.NewGuid().ToString();
            this.name = name;
            this.year = year;
        }
        public override string ToString()
        {
            return $"{name} ({year})";
        }
    }
}
