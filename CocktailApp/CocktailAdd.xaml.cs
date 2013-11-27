﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CocktailApp.mesClasses;
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.IO;

namespace CocktailApp
{
    public partial class CocktailAdd : PhoneApplicationPage
    {
        BitmapImage bmp;
        public CocktailAdd()
        {
            InitializeComponent();
            buildCocktailAddBar();
            rdb_facile.IsChecked = true;
            bmp = new BitmapImage();
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
                CocktailsRepository.Add(new Cocktails(txt_nom.Text, txt_description.Text, "/Assets/img/no-image.png", rdb, new DateTime()));
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
        private void btnCancel_Click(Object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void txt_nom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text == "Saisissez le nom de la recette")
                txt_nom.Text = "";
        }

        private void txt_description_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_description.Text == "Saisir sa description")
                txt_description.Text = "";
        }

        private void txt_nom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text == "")
                txt_nom.Text = "Saisissez le nom de la recette";
        }

        private void txt_description_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_description.Text == "")
                txt_description.Text = "Saisir sa description";
        }

        private void rdb_moyen_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void rdb_facile_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdb_difficile_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void imageCocktail_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PhotoChooserTask choisirPhoto = new PhotoChooserTask();
            choisirPhoto.ShowCamera = true;
            choisirPhoto.PixelHeight = 150;
            choisirPhoto.PixelWidth = 150;
            choisirPhoto.Show();
            choisirPhoto.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
        }

        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (null != e.ChosenPhoto && e.TaskResult == TaskResult.OK)
            {
                var image = new BitmapImage();
                image.SetSource(e.ChosenPhoto);
                SaveImageToIsolatedStorage(image, txt_nom.Text + ".jpg");
            }
        }

        public void SaveImageToIsolatedStorage(BitmapImage image, string fileName)
        {
            if (image != null)
            {
                using (var isolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (!isolatedStorage.DirectoryExists("/Img"))
                        isolatedStorage.CreateDirectory("/Img");
                    if (isolatedStorage.FileExists("/Img/" + fileName))
                        isolatedStorage.DeleteFile("/Img/" + fileName);
                    var fileStream = isolatedStorage.CreateFile("/Img/" + fileName);
                    var wb = new WriteableBitmap(image);
                    wb.SaveJpeg(fileStream, 150, 150, 0, 100);
                    fileStream.Close();
                    fileStream = isolatedStorage.OpenFile("/Img/"+fileName, FileMode.Open, FileAccess.Read);
                    BitmapImage bmp = new BitmapImage();
                    bmp.SetSource(fileStream);
                    imageCocktail.Source = bmp;
                }
                
            }
        }      

    }
}