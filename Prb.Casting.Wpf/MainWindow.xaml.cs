using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Prb.Casting.Core;

namespace Prb.Casting.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Actor> actors;
        List<Movie> movies;
        List<Cast> casts;

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

        private void PopulateMovies()
        {
            lstMovies.ItemsSource = null;
            lstMovies.ItemsSource = movies;
        }
        private void PopulateActorsInCasting(string movie_id)
        {
            lstCasting.Items.Clear();
            foreach(Cast cast in casts)
            {
                if(cast.movie_id == movie_id)
                {
                    string actor_id = cast.actor_id;
                    foreach(Actor actor in actors)
                    {
                        if(actor.ID == actor_id)
                        {
                            lstCasting.Items.Add(actor);
                            break;
                        }
                    }
                }
            }
        }
        private void PopulateActorsNotInCasting(string movie_id)
        {
            cmbActors.Items.Clear();
            foreach(Actor actor in actors)
            {
                string actor_id = actor.ID;
                bool inMovie = false;
                foreach(Cast cast in casts)
                {
                    if(cast.actor_id == actor_id && cast.movie_id == movie_id)
                    {
                        inMovie = true;
                        break;
                    }
                }
                if(!inMovie)
                {
                    cmbActors.Items.Add(actor);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actors = new List<Actor>();
            movies = new List<Movie>();
            casts = new List<Cast>();

            DoSeeding();
            PopulateMovies();
            
        }

        private void lstMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstCasting.Items.Clear();
            cmbActors.Items.Clear();
            if (lstMovies.SelectedItem == null)
                return;

            Movie movie = (Movie)lstMovies.SelectedItem;
            PopulateActorsInCasting(movie.ID);
            PopulateActorsNotInCasting(movie.ID);
        }

        private void btnAddToCasting_Click(object sender, RoutedEventArgs e)
        {
            if (lstMovies.SelectedItem == null)
                return;
            if (cmbActors.SelectedItem == null)
                return;

            Movie movie = (Movie)lstMovies.SelectedItem;
            Actor actor = (Actor)cmbActors.SelectedItem;
            casts.Add(new Cast(movie.ID, actor.ID));
            PopulateActorsInCasting(movie.ID);
            PopulateActorsNotInCasting(movie.ID);


        }

        private void btnRemoveFromCasting_Click(object sender, RoutedEventArgs e)
        {
            if (lstCasting.SelectedItem == null)
                return;
            if (lstMovies.SelectedItem == null)
                return;

            Actor actor = (Actor)lstCasting.SelectedItem;
            Movie movie = (Movie)lstMovies.SelectedItem;
            foreach(Cast cast in casts)
            {
                if(cast.movie_id == movie.ID && cast.actor_id == actor.ID)
                {
                    casts.Remove(cast);
                    break;
                }
            }
            PopulateActorsInCasting(movie.ID);
            PopulateActorsNotInCasting(movie.ID);

        }
    }
}
