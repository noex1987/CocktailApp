using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CocktailApp.Resources;
using CocktailApp.mesClasses;

namespace CocktailApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();

            buildCocktailListedBar();
            initialisationDonnees();
        }
        private void initialisationDonnees()
        {
            CocktailsRepository mesCocktails = new CocktailsRepository();
            this.listeDeCocktails.ItemsSource = mesCocktails.List();
        }

        private void buildCocktailListedBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
            //Bouton Nouveau
            ApplicationBarIconButton btnAdd = new ApplicationBarIconButton();
            btnAdd.IconUri = new Uri("/Assets/Icons/Dark/add.png", UriKind.Relative);
            btnAdd.Text = "Nouveau";
            btnAdd.Click += new EventHandler(btnAdd_Click);
            ApplicationBar.Buttons.Add(btnAdd);

            //Bouton Rechercher
            ApplicationBarIconButton btnSea = new ApplicationBarIconButton();
            btnSea.IconUri = new Uri("/Assets/Icons/Dark/feature.search.png", UriKind.Relative);
            btnSea.Text = "Rechercher";
            ApplicationBar.Buttons.Add(btnSea);
        }

        private void listeDeCocktails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Cocktails selectedItemData = (sender as ListBox).SelectedItem as Cocktails;
            if (selectedItemData != null)
                NavigationService.Navigate(new Uri(String.Format("/CocktailView.xaml?parameter={0}", selectedItemData.id), UriKind.Relative));
        }
        private void btnAdd_Click(Object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CocktailAdd.xaml", UriKind.Relative));
        }

        
    }
}