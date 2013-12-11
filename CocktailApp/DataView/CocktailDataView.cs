using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.mesClasses
{
    public class CocktailDataView : INotifyPropertyChanged
    {
        // LINQ to SQL data context for the local database.
        private CocktailDataContext cocktailDB;

        // Class constructor, create the data context object.
        public CocktailDataView(string DBConnectionString)
        {
            cocktailDB = new CocktailDataContext(DBConnectionString);
        }

        // Define an observable collection property that controls can bind to.
        private ObservableCollection<Cocktail> _cocktails;
        public ObservableCollection<Cocktail> Cocktails
        {
            get
            {
                return _cocktails;
            }
            set
            {
                if (_cocktails != value)
                {
                    _cocktails = value;
                    NotifyPropertyChanged("Data");
                }
            }
        }

        public void SaveChangesToDB()
        {
            cocktailDB.SubmitChanges();
        }

        // Query database and load the collections and list used by the pivot pages.
        public void LoadCollectionsFromDatabase()
        {
            // Specify the query for all to-do items in the database.
            var CocktailsDansBase = from Cocktail cocktail in cocktailDB.cocktails
                                select cocktail;

            // Query the database and load all to-do items.
            Cocktails = new ObservableCollection<Cocktail>(CocktailsDansBase);
        }

        /// <summary>
        /// Ajouter un cocktail dans la base
        /// </summary>
        /// <param name="unCocktail"></param>
        public void AddCocktail(Cocktail unCocktail)
        {
            // ajouter un cocktail
            cocktailDB.cocktails.InsertOnSubmit(unCocktail);

            // sauvegarder dans la base
            cocktailDB.SubmitChanges();

            // ajouter un cocktail à la collection
            Cocktails.Add(unCocktail);
        }

        /// <summary>
        /// Supprimer un cocktail de la base
        /// </summary>
        /// <param name="unCocktail"></param>
        public void DeleteCocktail(Cocktail unCocktail)
        {

            // Supprimer le cocktail de la liste
            Cocktails.Remove(unCocktail);

            // Supprimer le cocktail de la abse
            cocktailDB.cocktails.DeleteOnSubmit(unCocktail);

            // Sauvegarder la base de données
            cocktailDB.SubmitChanges();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the app that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
