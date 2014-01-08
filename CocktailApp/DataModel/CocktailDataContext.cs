using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.mesClasses
{
    public class CocktailDataContext : DataContext
    {
        // Specify the connection string as a static, used in main page and app.xaml.
        //public static string DBConnectionString = "Data Source=isostore:/Cocktails.sdf";
        public CocktailDataContext(string connectionString)
            : base(connectionString)
        { }

        public Table<Cocktail> cocktails;
    }

    [Table]
    public class Cocktail : INotifyPropertyChanged, INotifyPropertyChanging
    {
        // ID du cocktail
        private int _cocktailID;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int CocktailID
        {
            get
            {
                return _cocktailID;
            }
            set
            {
                if (_cocktailID != value)
                {
                    NotifyPropertyChanging("CocktailID");
                    _cocktailID = value;
                    NotifyPropertyChanged("CocktailID");
                }
            }
        }

        // Nom du cocktail 
        private string _cocktailNom;

        [Column(DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
        public string CocktailNom
        {
            get
            {
                return _cocktailNom;
            }
            set
            {
                if (_cocktailNom != value)
                {
                    NotifyPropertyChanging("CocktailNom");
                    _cocktailNom = value;
                    NotifyPropertyChanged("CocktailNom");
                }
            }
        }

        //Description du cocktail
        private string _cocktailDescription;

        [Column]
        public string CocktailDescription
        {
            get
            {
                return _cocktailDescription;
            }
            set
            {
                if (_cocktailDescription != value)
                {
                    NotifyPropertyChanging("CocktailDescription");
                    _cocktailDescription = value;
                    NotifyPropertyChanged("CocktailDescription");
                }
            }
        }

        // Commentaire du cocktail 
        private string _cocktailCommentaire;

        [Column]
        public string CocktailCommentaire
        {
            get
            {
                return _cocktailCommentaire;
            }
            set
            {
                if (_cocktailCommentaire != value)
                {
                    NotifyPropertyChanging("CocktailCommentaire");
                    _cocktailCommentaire = value;
                    NotifyPropertyChanged("CocktailCommentaire");
                }
            }
        }

        //Image du cocktail
        private string _cocktailImage;

        [Column]
        public string CocktailImage
        {
            get
            {
                return _cocktailImage;
            }
            set
            {
                if (_cocktailImage != value)
                {
                    NotifyPropertyChanging("CocktailImage");
                    _cocktailImage = value;
                    NotifyPropertyChanged("CocktailImage");
                }
            }
        }

        //Difficulté du cocktail
        private string _cocktailDifficulte;

        [Column]
        public string CocktailDifficulte
        {
            get
            {
                return _cocktailDifficulte;
            }
            set
            {
                if (_cocktailDifficulte != value)
                {
                    NotifyPropertyChanging("CocktailDifficulte");
                    _cocktailDifficulte = value;
                    NotifyPropertyChanged("CocktailDifficulte");
                }
            }
        }

        //Cocktail Favoris
        private string _cocktailFavori;

        [Column]
        public string CocktailFavori
        {
            get
            {
                return _cocktailFavori;
            }
            set
            {
                if (_cocktailFavori != value)
                {
                    NotifyPropertyChanging("CocktailFavori");
                    _cocktailFavori = value;
                    NotifyPropertyChanged("CocktailFavori");
                }
            }
        }


        //Description du Cocktail
        private string _cocktailDecoration;

        [Column]
        public string CocktailDecoration
        {
            get
            {
                return _cocktailDecoration;
            }
            set
            {
                if (_cocktailDecoration != value)
                {
                    NotifyPropertyChanging("CocktailDecoration");
                    _cocktailDecoration = value;
                    NotifyPropertyChanged("CocktailDecoration");
                }
            }
        }

        //Réalisation du Cocktail
        private string _cocktailRealisation;

        [Column]
        public string CocktailRealisation
        {
            get
            {
                return _cocktailRealisation;
            }
            set
            {
                if (_cocktailRealisation != value)
                {
                    NotifyPropertyChanging("CocktailRealisation");
                    _cocktailRealisation = value;
                    NotifyPropertyChanged("CocktailRealisation");
                }
            }
        }

        //"Servir dans" du Cocktail
        private string _cocktailServir;

        [Column]
        public string CocktailServir
        {
            get
            {
                return _cocktailServir;
            }
            set
            {
                if (_cocktailServir != value)
                {
                    NotifyPropertyChanging("CocktailServir");
                    _cocktailServir = value;
                    NotifyPropertyChanged("CocktailServir");
                }
            }
        }

        //Date de création du Cocktail
        private DateTime _cocktailDate;

        [Column(DbType="DateTime")]
        public DateTime CocktailDate
        {
            get
            {
                return _cocktailDate;
            }
            set
            {
                if (_cocktailDate != value)
                {
                    NotifyPropertyChanging("CocktailDate");
                    _cocktailDate = value;
                    NotifyPropertyChanged("CocktailDate");
                }
            }
        }
        public Cocktail(string nom)
        {
            this.CocktailNom = nom;
            CocktailDescription = "Aucune description";
            CocktailCommentaire = "Sans commentaire";
            CocktailImage = "/Assets/img/no-image.png";
            CocktailDifficulte = "Moyen";
            CocktailFavori = "/Assets/Icons/Dark/nofavs.png";
            CocktailDecoration = "Aucune décoration particulière";
            CocktailRealisation = "Non indiqué";
            CocktailServir = "Non indiqué";
            CocktailDate = DateTime.Now;
        }

        public Cocktail(string nom, string description, string commentaire, string image, string difficulte, string favori, string deco, string real, string servir)
        {
            CocktailNom = nom;

            if (description != "Saisissez la totalité de la recette.")
                CocktailDescription = description;
            else
                CocktailDescription = "Aucune description";

            if (commentaire != "Saisissez un commentaire personnel")
                CocktailCommentaire = commentaire;
            else
                CocktailCommentaire = "Sans commentaire";

            CocktailImage = image;
            CocktailDifficulte = difficulte;
            CocktailFavori = "/Assets/Icons/Dark/nofavs.png";

            if (deco != "Décrivez la décoration à ajouter.")
                CocktailDecoration = deco;
            else
                CocktailDecoration = "Aucune décoration particulière";

            if (real != "Où faut-il préparer le cocktail ?")
                CocktailRealisation = real;
            else
                CocktailRealisation = "Non indiqué";

            if (servir != "Où faut-il servir le cocktail ?")
                CocktailServir = servir;
            else
                CocktailServir = "Non indiqué";

            CocktailDate = DateTime.Now;
        }

        public void ChangeFav()
        {
            if (this._cocktailFavori == "/Assets/Icons/Dark/nofavs.png")
            {
                this._cocktailFavori = "/Assets/Icons/Dark/favs.png";
            }
            else
            {
                this._cocktailFavori = "/Assets/Icons/Dark/nofavs.png";
            }

        }

        public Cocktail()
        { }



        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the page that a data context property changed
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #endregion

        #region INotifyPropertyChanging Members

        public event PropertyChangingEventHandler PropertyChanging;

        // Used to notify the data context that a data context property is about to change
        private void NotifyPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
        #endregion
    }
}
