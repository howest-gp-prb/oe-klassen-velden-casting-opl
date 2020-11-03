using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Casting.Core
{
    public class Movie
    {
        private string id;
        private string name;
        private int year;

        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set 
            {
                value = value.Trim();
                name = value; 
            }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }



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
