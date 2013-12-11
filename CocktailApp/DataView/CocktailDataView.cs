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
        public CocktailDataView(string toDoDBConnectionString)
        {
            cocktailDB = new CocktailDataContext(toDoDBConnectionString);
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

        // Add a to-do item to the database and collections.
        public void AddCocktail(Cocktail unCocktail)
        {
            // Add a to-do item to the data context.
            cocktailDB.cocktails.InsertOnSubmit(unCocktail);

            // Save changes to the database.
            cocktailDB.SubmitChanges();

            // Add a to-do item to the "all" observable collection.
            Cocktails.Add(unCocktail);
        }

        // Remove a to-do task item from the database and collections.
        public void DeleteCocktail(Cocktail unCocktail)
        {

            // Remove the to-do item from the "all" observable collection.
            Cocktails.Remove(unCocktail);

            // Remove the to-do item from the data context.
            cocktailDB.cocktails.DeleteOnSubmit(unCocktail);

            // Save changes to the database.
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
