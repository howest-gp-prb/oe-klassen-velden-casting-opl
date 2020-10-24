using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Casting.Core
{
    public class Cast
    {
        public string movie_id;
        public string actor_id;
        public Cast(string movie_id, string actor_id)
        {
            this.movie_id = movie_id;
            this.actor_id = actor_id;
        }
    }
}
