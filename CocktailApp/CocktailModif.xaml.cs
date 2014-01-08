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
using Microsoft.Phone.Tasks;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;
using System.IO;
using System.Windows.Media;

namespace CocktailApp
{
    public partial class CocktailModif : PhoneApplicationPage
    {
        private Cocktail cocktail = null;
        private CocktailDataContext cocktailDB;
        BitmapImage bmp { get; set; }
        string sourceImageDuCocktail { get; set; }
        string sourceNouvelleImageDuCocktail { get; set; }
        public CocktailModif()
        {
            InitializeComponent();
            buildCocktailAddBar();
            cocktailDB = new CocktailDataContext("Data Source=isostore:/Cocktails.sdf"); 
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string parameter = this.NavigationContext.QueryString["parameter"];


            int cocktailId = -1;
            if (int.TryParse(parameter, out cocktailId))
            {
                cocktail = (from c in cocktailDB.cocktails
                            where c.CocktailID == cocktailId
                            select c).First();
            }

            this.DataContext = cocktail;
            if ( cocktail.CocktailDifficulte.ToString() == "Facile") rdb_facile.IsChecked = true;
            else if (cocktail.CocktailDifficulte.ToString() == "Moyen") rdb_moyen.IsChecked = true;
            else if (cocktail.CocktailDifficulte.ToString() == "Difficile") rdb_difficile.IsChecked = true;
            sourceImageDuCocktail = cocktail.CocktailImage;
        }

        private void buildCocktailAddBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            ApplicationBar.BackgroundColor = Color.FromArgb(255, 17, 21, 68);
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
                Cocktail nouveauCocktail;
                if (sourceImageDuCocktail == null)
                    nouveauCocktail = new Cocktail(txt_nom.Text, txt_description.Text, txt_comm.Text, "/Assets/img/no-image.png", rdb, null, txt_deco.Text, txt_real.Text, txt_serv.Text);
                else if (sourceNouvelleImageDuCocktail != null)
                    nouveauCocktail = new Cocktail(txt_nom.Text, txt_description.Text, txt_comm.Text, sourceNouvelleImageDuCocktail, rdb, null, txt_deco.Text, txt_real.Text, txt_serv.Text);
                else
                    nouveauCocktail = new Cocktail(txt_nom.Text, txt_description.Text, txt_comm.Text, sourceImageDuCocktail, rdb, null, txt_deco.Text, txt_real.Text, txt_serv.Text);
                nouveauCocktail.CocktailID = cocktail.CocktailID;
                App.ViewModel.UpdateCocktail(nouveauCocktail);
                while(NavigationService.CanGoBack)
                    NavigationService.RemoveBackEntry();
                //NavigationService.RemoveBackEntry();
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                //NavigationService.GoBack();
            }
        }
        private void btnCancel_Click(Object sender, EventArgs e)
        {
            NavigationService.GoBack();
        }


        private void txt_nom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text == "")
                txt_nom.Text = cocktail.CocktailNom;
        }

        private void txt_description_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_description.Text == "")
                txt_description.Text = cocktail.CocktailDescription;
        }

        /// <summary>
        /// Action lors de l'appui sur la photo du cocktail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel_Img_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhotoChooserTask choisirPhoto = new PhotoChooserTask();
            choisirPhoto.ShowCamera = true;
            choisirPhoto.PixelHeight = 150;
            choisirPhoto.PixelWidth = 150;
            choisirPhoto.Show();
            choisirPhoto.Completed += new EventHandler<PhotoResult>(photoChooserTask_Completed);
        }

        
        /// <summary>
        /// Évènement une fois que la photo est capturée ou choisie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void photoChooserTask_Completed(object sender, PhotoResult e)
        {
            if (null != e.ChosenPhoto && e.TaskResult == TaskResult.OK)
            {
                var image = new BitmapImage();
                image.SetSource(e.ChosenPhoto);
                SaveImageToIsolatedStorage(image, txt_nom.Text + ".jpg");
            }
        }

        /// <summary>
        /// Sauvegarder l'image localement et mettre à jour l'aperçu de la page ajout
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fileName"></param>
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
                    fileStream = isolatedStorage.OpenFile("/Img/" + fileName, FileMode.Open, FileAccess.Read);
                    BitmapImage bmp = new BitmapImage();
                    bmp.SetSource(fileStream);
                    imageCocktail.Source = bmp;
                    sourceNouvelleImageDuCocktail = fileStream.Name.ToString();
                }
            }
        }
     
    }
}