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
    public partial class CocktailView : PhoneApplicationPage
    {
        private Cocktails cocktail = null;
        public CocktailView()
        {
            InitializeComponent();
            buildCocktailViewBar();
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
            
        }
        private void buildCocktailViewBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 1.0;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;
            
            //Bouton Modifier
            ApplicationBarIconButton btnEdit = new ApplicationBarIconButton();
            btnEdit.IconUri = new Uri("/Assets/Icons/Dark/edit.png", UriKind.Relative);
            btnEdit.Text = "Modifier";
            btnEdit.Click += new EventHandler(btnEdit_Click);
            ApplicationBar.Buttons.Add(btnEdit);

            //Bouton Supprimer
            ApplicationBarIconButton btnDelete = new ApplicationBarIconButton();
            btnDelete.IconUri = new Uri("/Assets/Icons/Dark/delete.png", UriKind.Relative);
            btnDelete.Text = "Supprimer";
            btnDelete.Click += new EventHandler(btnDelete_Click);
            ApplicationBar.Buttons.Add(btnDelete);
        }

        private void btnEdit_Click(Object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri(String.Format("/CocktailAdd.xaml?parameter={0}", this.cocktail.id), UriKind.Relative));
        }
        private void btnDelete_Click(Object sender, EventArgs e)
        {
            CocktailsRepository.Remove(cocktail);
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}