using CocktailApp.mesClasses;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace CocktailApp
{
    public partial class CocktailAdd : PhoneApplicationPage
    {
        BitmapImage bmp { get; set; }
        string sourceImageDuCocktail { get; set; }
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

                // ajout dans la base
                Cocktail unNouveauCocktail;
                if(sourceImageDuCocktail == null)
                    unNouveauCocktail = new Cocktail(txt_nom.Text, txt_description.Text, txt_comm.Text, "/Assets/img/no-image.png", rdb, null, txt_deco.Text, txt_real.Text, txt_serv.Text);
                else
                    unNouveauCocktail = new Cocktail(txt_nom.Text, txt_description.Text, txt_comm.Text, sourceImageDuCocktail, rdb, null, txt_deco.Text, txt_real.Text, txt_serv.Text); 
                App.ViewModel.AddCocktail(unNouveauCocktail);
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }
        private void btnCancel_Click(Object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void txt_comm_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_comm.Text == "Saisissez un commentaire personnel")
                txt_comm.Text = "";
        }
        private void txt_comm_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_comm.Text == "")
                txt_comm.Text = "Saisissez un commentaire personnel";
        }

        private void txt_real_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_real.Text == "Où faut-il préparer le cocktail ?")
                txt_real.Text = "";
        }
        private void txt_real_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_real.Text == "")
                txt_real.Text = "Où faut-il préparer le cocktail ?";
        }

        private void txt_serv_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_serv.Text == "Où faut-il servir le cocktail ?")
                txt_serv.Text = "";
        }
        private void txt_serv_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_serv.Text == "")
                txt_serv.Text = "Où faut-il servir le cocktail ?";
        }

        private void txt_deco_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_deco.Text == "Décrivez la décoration à ajouter.")
                txt_deco.Text = "";
        }
        private void txt_deco_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_deco.Text == "")
                txt_deco.Text = "Décrivez la décoration à ajouter.";
        }

        private void txt_nom_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text == "Saisissez le nom de la recette")
                txt_nom.Text = "";
        }
        private void txt_nom_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_nom.Text == "")
                txt_nom.Text = "Saisissez le nom de la recette";
        }

        private void txt_description_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_description.Text == "Saisissez la totalité de la recette.")
                txt_description.Text = "";
        }
        private void txt_description_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_description.Text == "")
                txt_description.Text = "Saisissez la totalité de la recette.";
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
                    sourceImageDuCocktail = fileStream.Name.ToString();
                }
            }
        }      

        

        
          

    }
}