using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Casting.Core
{
    public class Cast
    {
        public Movie Movie { get; set; }
        public Actor Actor { get; set; }

        public Cast(Movie movie, Actor actor)
        {
            Movie = movie;
            Actor = actor;
        }
    }
}
