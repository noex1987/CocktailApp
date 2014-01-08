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
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace CocktailApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private CocktailDataContext mesCocktails;
        // Constructeur
        public MainPage()
        {
            InitializeComponent();

            // Data context and observable collection are children of the main page.
            this.DataContext = App.ViewModel;
            mesCocktails = new CocktailDataContext("Data Source=isostore:/Cocktails.sdf");
            
            buildCocktailListedBar();
            initialisationDonnees();
        }


        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            // Save changes to the database.
            App.ViewModel.SaveChangesToDB();
        }

        private void initialisationDonnees()
        {
            this.listeDeCocktails.ItemsSource =  mesCocktails.cocktails;
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
            /*
            //Bouton Rechercher
            ApplicationBarIconButton btnSea = new ApplicationBarIconButton();
            btnSea.IconUri = new Uri("/Assets/Icons/Dark/feature.search.png", UriKind.Relative);
            btnSea.Text = "Rechercher";
            ApplicationBar.Buttons.Add(btnSea);*/
        }

        private void btnAdd_Click(Object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CocktailAdd.xaml", UriKind.Relative));
        }


        private void Fav_Img_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int id = (int)(sender as Image).Tag;
            Cocktail leCocktail = mesCocktails.cocktails.Single(ID => ID.CocktailID == id);
            leCocktail.ChangeFav();
            (sender as Image).Source = new BitmapImage(new Uri(leCocktail.CocktailFavori, UriKind.Relative));
            
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int id = (int)(sender as StackPanel).Tag;
            try
            {
                Cocktail leCocktail = mesCocktails.cocktails.Single(ID => ID.CocktailID == id);
                NavigationService.Navigate(new Uri(String.Format("/CocktailView.xaml?parameter={0}", leCocktail.CocktailID), UriKind.Relative));
            }
            catch(Exception)
            {}       
        }
    }
}