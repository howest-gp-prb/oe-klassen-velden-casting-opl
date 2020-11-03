using System;
using System.Collections.Generic;
using System.Text;

namespace Prb.Casting.Core
{
    public class MovieService
    {
        private List<Movie> movies;
        private List<Actor> actors;
        private List<Cast> casts;

        public List<Movie> Movies
        {
            get { return movies; }
        }

        public List<Actor> Actors
        {
            get { return actors; }
        }

        public List<Cast> Casts
        {
            get { return casts; }
        }
        public MovieService()
        {
            movies = new List<Movie>();
            actors = new List<Actor>();
            casts = new List<Cast>();
            DoSeeding();
        }
        private void DoSeeding()
        {
            actors.Add(new Actor("Jackson", "Samuel"));
            actors.Add(new Actor("Willis", "Bruce"));
            actors.Add(new Actor("Pitt", "Brad"));
            actors.Add(new Actor("Neeson", "Liam"));
            actors.Add(new Actor("Lewis", "Damian"));
            actors.Add(new Actor("Cumberbatch", "Benedict"));
            actors.Add(new Actor("Jolie", "Angelina"));
            actors.Add(new Actor("Cafmeyer", "Maaike"));

            movies.Add(new Movie("Sherlock Holmes", 2004));
            movies.Add(new Movie("Another movie", 2001));
            movies.Add(new Movie("And another movie", 1980));
            movies.Add(new Movie("And again another movie", 1980));
            movies.Add(new Movie("Pigs in space", 1960));
            movies.Add(new Movie("Eddy in space", 1990));
        }

        public List<Actor> GetActorsInMovie(string movie_id)
        {
            List<Actor> actorsInMovie = new List<Actor>();
            foreach (Cast cast in casts)
            {
                if (cast.movie_id == movie_id)
                {
                    string actor_id = cast.actor_id;
                    foreach (Actor actor in actors)
                    {
                        if (actor.ID == actor_id)
                        {
                            actorsInMovie.Add(actor);
                            break;
                        }
                    }
                }
            }
            return actorsInMovie;
        }
        public List<Actor> GetActorsNotInMovie(string movie_id)
        {
            List<Actor> actorsNotInMovie = new List<Actor>();
            foreach (Actor actor in actors)
            {
                string actor_id = actor.ID;
                bool inMovie = false;
                foreach (Cast cast in casts)
                {
                    if (cast.actor_id == actor_id && cast.movie_id == movie_id)
                    {
                        inMovie = true;
                        break;
                    }
                }
                if (!inMovie)
                {
                    actorsNotInMovie.Add(actor);
                }
            }
            return actorsNotInMovie;
        }
        public void AddActorToMovie(Movie movie, Actor actor)
        {
            casts.Add(new Cast(movie.ID, actor.ID));
        }
        public void RemoveActorFromMovie(Movie movie, Actor actor)
        {
            foreach (Cast cast in casts)
            {
                if (cast.movie_id == movie.ID && cast.actor_id == actor.ID)
                {
                    casts.Remove(cast);
                    break;
                }
            }
        }

    }
}
