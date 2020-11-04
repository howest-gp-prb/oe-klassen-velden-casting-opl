using System;
using System.Collections.Generic;
using System.Linq;
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

            movies = movies.OrderBy(m => m.Name).ToList();
        }

        public List<Actor> GetActorsInMovie(Movie movie)
        {
            List<Actor> actorsInMovie = new List<Actor>();
            foreach (Cast cast in casts)
            {
                if (cast.Movie == movie)
                {
                    actorsInMovie.Add(cast.Actor);
                }
            }
            actorsInMovie = actorsInMovie.OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToList();
            return actorsInMovie;
        }
        public List<Actor> GetActorsNotInMovie(Movie movie)
        {
            List<Actor> actorsInMovie = GetActorsInMovie(movie);
            List<Actor> actorsNotInMovie = new List<Actor>();
            foreach (Actor actor in actors)
            {
                if(!actorsInMovie.Contains(actor))
                    actorsNotInMovie.Add(actor);
            }
            actorsNotInMovie = actorsNotInMovie.OrderBy(a => a.LastName).ThenBy(a => a.FirstName).ToList();
            return actorsNotInMovie;
        }
        public void AddActorToMovie(Movie movie, Actor actor)
        {
            casts.Add(new Cast(movie, actor));
        }
        public void RemoveActorFromMovie(Movie movie, Actor actor)
        {
            foreach (Cast cast in casts)
            {
                if (cast.Movie == movie && cast.Actor == actor)
                {
                    casts.Remove(cast);
                    break;
                }
            }
        }

    }
}
