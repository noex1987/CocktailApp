using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CocktailApp.mesClasses;

namespace CocktailApp
{
    public partial class CocktailModif : PhoneApplicationPage
    {
        private Cocktails cocktail = null;
        public CocktailModif()
        {
            InitializeComponent();
            buildCocktailAddBar();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string parameter = this.NavigationContext.QueryString["parameter"];


            int cocktailId = -1;
            if (int.TryParse(parameter, out cocktailId))
            {
                CocktailsRepository cocktailRepository = new CocktailsRepository();
                cocktail = cocktailRepository.Find(cocktailId);
            }

            this.DataContext = cocktail;
            if ( cocktail.difficulte.ToString() == "Facile") rdb_facile.IsChecked = true;
            else if (cocktail.difficulte.ToString() == "Moyen") rdb_moyen.IsChecked = true;
            else if (cocktail.difficulte.ToString() == "Difficile") rdb_difficile.IsChecked = true;

        }

        private void buildCocktailAddBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            //Bouton Sauvegarder
            ApplicationBarIconButton btnSave = new ApplicationBarIconButton();
            btnSave.IconUri = new Uri("/Assets/Icons/Dark/save.png", UriKind.Relative);
            btnSave.Text = "Sauvegarder";
            btnSave.Click += new EventHandler(btnSave_Click);
            ApplicationBar.Buttons.Add(btnSave);

            //Bouton Annuler
            ApplicationBarIconButton btnCancel = new ApplicationBarIconButton();
            btnCancel.IconUri = new Uri("/Assets/Icons/Dark/cancel.png", UriKind.Relative);
            btnCancel.Text = "Annuler";
            btnCancel.Click += new EventHandler(btnCancel_Click);
            ApplicationBar.Buttons.Add(btnCancel);
        }
        private void btnSave_Click(Object sender, EventArgs e)
        {
            if (txt_nom.Text == "Saisissez le nom de la recette" || txt_nom.Text=="")
            {
                txt_error_nom.Text = "Veuillez saisir le nom de la recette";
            }
            else
            {
                string rdb = "Facile";
                if (rdb_moyen.IsChecked == true) rdb = "Moyen";
                if (rdb_difficile.IsChecked == true) rdb = "Difficile";
                CocktailsRepository.Edit( cocktail, txt_nom.Text, txt_description.Text, cocktail.img, rdb, txt_comm.Text,txt_serv.Text, txt_deco.Text, txt_real.Text);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
        private void btnCancel_Click(Object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }


        private void txt_nom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text == "")
                txt_nom.Text = cocktail.nom;
        }

        private void txt_description_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_description.Text == "")
                txt_description.Text = cocktail.description;
        }
     
    }
}