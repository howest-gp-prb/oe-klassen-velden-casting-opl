using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
        MovieService movieService;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            movieService = new MovieService();
            PopulateMovies();
        }

        private void PopulateMovies()
        {
            lstMovies.ItemsSource = null;
            lstMovies.ItemsSource = movieService.Movies;
        }
        private void PopulateActorsInCasting(string movie_id)
        {
            lstCasting.ItemsSource = null;
            lstCasting.ItemsSource = movieService.GetActorsInMovie(movie_id);
        }
        private void PopulateActorsNotInCasting(string movie_id)
        {
            cmbActors.ItemsSource = null;
            cmbActors.ItemsSource = movieService.GetActorsNotInMovie(movie_id);
        }



        private void lstMovies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstCasting.ItemsSource = null;
            cmbActors.ItemsSource = null;
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
            movieService.AddActorToMovie(movie, actor);
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
            movieService.RemoveActorFromMovie(movie, actor);
            PopulateActorsInCasting(movie.ID);
            PopulateActorsNotInCasting(movie.ID);

        }
    }
}
