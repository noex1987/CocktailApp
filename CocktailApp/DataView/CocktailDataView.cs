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
        private List<Cocktail> CocktailsList;

        // Class constructor, create the data context object.
        public CocktailDataView(string DBConnectionString)
        {
            cocktailDB = new CocktailDataContext(DBConnectionString);
            CocktailsList = new List<Cocktail>();
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
        }

        public void Init()
        {
            Cocktail Mojito = new Cocktail("Mojito");
            Mojito.CocktailCommentaire = "Extrêmement rafraichissant !";
            Mojito.CocktailDescription = "-6 cl de rhum cubain\n-3 cl de jus de citrons verts\n-7 feuilles de menthe\n-Eau gazeuse (Perrier…)\n-2 cuillères à café de sucre\n Placer les feuilles de menthe dans le verre, ajoutez le sucre et le jus de citrons. Piler consciencieusement afin d'exprimer l'essence de la menthe sans la broyer. Ajouter le rhum, 4 glaçons et mélangez. Remplir la moitié restante du verre d'eau gazeuse. Mélanger doucement avec une paille. Voilà, le Mojito est prêt.";
            Mojito.CocktailImage = "/Assets/Img/cocktail_mojito.png";
            Mojito.CocktailServir = "un verre de type \"tumbler\".";
            Mojito.CocktailRealisation = "directement dans le verre.";
            Mojito.CocktailDecoration = "Décorer de feuilles de menthe fraîches et d'une tranche de citron.";
            Mojito.CocktailDifficulte = "Moyen";
            Mojito.CocktailFavori = "/Assets/Icons/Dark/favs.png";

            Cocktail PiñaColada = new Cocktail("Piña Colada");
            PiñaColada.CocktailCommentaire = "A déguster allongé sur un transat !";
            PiñaColada.CocktailDescription = "-4 cl de rhum blanc\n-2cl de rhum ambré\n-12 cl de jus d’ananas\n-4cl de lait de coco;\nDans un mixer, versez tous les ingrédients, y compris les glaçons et mixez le tout. C'est prêt ! Versez dans le verre et dégustez.";
            PiñaColada.CocktailImage = "/Assets/Img/cocktail_pina_colada.png";
            PiñaColada.CocktailServir = "un verre de type \"verre à vin\".";
            PiñaColada.CocktailRealisation = "Réalisez la recette \"Piña Colada\" au mixer";
            PiñaColada.CocktailDecoration = "Décorer avec un morceau d'ananas et une cerise confite.";
            PiñaColada.CocktailDifficulte = "Moyen";
            PiñaColada.CocktailFavori = "/Assets/Icons/Dark/nofavs.png";

            Cocktail Margarita = new Cocktail("Margarita");
            Margarita.CocktailCommentaire = "Rien à voir avec la pizza !";
            Margarita.CocktailDescription = "-5 cl de tequila\n-3 cl de triple sec (grand marnier…)\n-2cl de jus de citrons verts\nFrapper les ingrédients au shaker avec des glaçons puis verser dans le verre givré au citron et au sel fin... Pour givrer facilement le verre, passer le citron sur le bord du verre et tremper les bords dans le sel.";
            Margarita.CocktailImage = "/Assets/Img/cocktail_margarita.png";
            Margarita.CocktailServir = "un verre de type \"verre à margarita\".";
            Margarita.CocktailRealisation = "Réalisez la recette au shaker";
            Margarita.CocktailDecoration = "Décorer d'une tranche de citron vert...";
            Margarita.CocktailDifficulte = "Moyen";
            Margarita.CocktailFavori = "/Assets/Icons/Dark/nofavs.png";

            Cocktail SexOnTheBeach = new Cocktail("Sex on the Beach");
            SexOnTheBeach.CocktailCommentaire = "Où comment jouer avec la température.";
            SexOnTheBeach.CocktailDescription = "-3cl de vodka\n-2cl de sirop de melon\n-2cl de chambord\n-5cl de jus d'ananas\n-6cl de jus de cranberry\n Verser les alcools sur des glaçons, mélanger et compléter avec les jus de fruits.";
            SexOnTheBeach.CocktailImage = "/Assets/Img/cocktail_sex_on_the_beach.png";
            SexOnTheBeach.CocktailServir = "Servir dans un verre de type \"verre tulipe\".";
            SexOnTheBeach.CocktailRealisation = "Réalisez la recette dans un verre à mélange";
            SexOnTheBeach.CocktailDecoration = "Un morceau d'ananas et une cerise confite.";
            SexOnTheBeach.CocktailDifficulte = "Difficile";
            SexOnTheBeach.CocktailFavori = "/Assets/Icons/Dark/favs.png";

            Cocktail BlueLagoon = new Cocktail("Blue Lagoon");
            BlueLagoon.CocktailCommentaire = "La Mer des Caraïbes en bouteille.";
            BlueLagoon.CocktailDescription = "-4cl de vodka\n-3cl de sirop de curuçao bleu\n-2cl de jus de citron\n Pressez le jus d'un demi-citron, ajoutez dans le shaker avec les autres ingrédients et des glaçons. Frappez puis versez dans le verre en filtrant. Afin qu'il soit plus frais et léger, remplissez auparavant le verre de glace pilée.";
            BlueLagoon.CocktailImage = "/Assets/Img/cocktail_blue_lagoon.png";
            BlueLagoon.CocktailServir = "Servir dans un verre de type \"verre à martini\".";
            BlueLagoon.CocktailRealisation = "Réalisez la recette au shaker";
            BlueLagoon.CocktailDecoration = "Un long zeste de citron vert";
            BlueLagoon.CocktailDifficulte = "Moyen";
            BlueLagoon.CocktailFavori = "/Assets/Icons/Dark/nofavs.png";

            Cocktail TequilaSunrise = new Cocktail("Tequila Sunrise");
            TequilaSunrise.CocktailCommentaire = "Avoir un coucher de soleil dans son verre.";
            TequilaSunrise.CocktailDescription = "-6cl de tequila\n-12cl de jus d'orange\n-2cl de sirop de grenadine.\n Verser la tequila sur des glaçons dans le verre. Compléter avec le jus d'orange et remuer. Versez doucement le sirop de grenadine dans le verre pour que celui-ci tombe au fond. Donnez alors un petit coup de cuillère pour affiner le dégradé si nécessaire.";
            TequilaSunrise.CocktailImage = "/Assets/Img/cocktail_tequila_sunrise.png";
            TequilaSunrise.CocktailServir = "Servir dans un verre de type \"tumbler\".";
            TequilaSunrise.CocktailRealisation = "Réalisez la recette directement dans le verre";
            TequilaSunrise.CocktailDecoration = "Une rondelle d'orange";
            TequilaSunrise.CocktailDifficulte = "Facile";
            TequilaSunrise.CocktailFavori = "/Assets/Icons/Dark/nofavs.png";


            Cocktail Punch = new Cocktail("Punch");
            Punch.CocktailCommentaire = "Bon comme un coup dans les dents !";
            Punch.CocktailDescription = "-100cl de rhum blanc\n-50cl de sirop de sucre de canne\n-100cl de jus d'oranges.\n-100cl de jus d'ananas.\n-100cl de jus pamplemousses.\n-1 bâton de cannelle.\n-3 sachets de thé.\n • Faire infuser 3 sachets de thé et un bâton de cannelle dans un verre d'eau bouillante pendant 5 minutes.(!)Si vous n'avez pas de bâtons de cannelle, utilisez du sirop de cannelle ou saupoudrez de cannelle en poudre.(!) Ensuite, mélanger le tout dans une grande bouteille à eau de 5 l, très pratique pour mettre au réfrigérateur. Ou dans un saladier, pour servir avec une louche. A servir frais.";
            Punch.CocktailImage = "/Assets/Img/cocktail_punch.png";
            Punch.CocktailServir = "Servir dans un verre traditionnel";
            Punch.CocktailRealisation = "Réalisez la recette directement en bouteille";
            Punch.CocktailDecoration = "Aucune décoration en particulier";
            Punch.CocktailDifficulte = "Moyen";
            Punch.CocktailFavori = "/Assets/Icons/Dark/nofavs.png";


            Cocktail BloodyMary = new Cocktail("Bloody Mary");
            BloodyMary.CocktailCommentaire = "Un piquant... mortel !";
            BloodyMary.CocktailDescription = "-4cl de vodka\n-12cl de jus de tomates\n-0.5cl de jus de citrons.\n-0.5cl de saucse worcestershire.\n-2 gouttes de tabasco.\n-Sel de céleri.\n-Sel et Poivre.\n • Agiter les ingrédients dans un verre à mélange avec des glaçons (pour refroidir sans trop diluer). Verser dans le verre, puis ajouter à convenance sel de céleri, sel et poivre. Décorer avec une tige de céleri et optionellement, une rondelle de citron.";
            BloodyMary.CocktailImage = "/Assets/Img/cocktail_bloody_mary.png";
            BloodyMary.CocktailServir = "Servir dans un verre de type \"tumbler\".";
            BloodyMary.CocktailRealisation = "Réalisez la recette dans un verre à mélange.";
            BloodyMary.CocktailDecoration = "Décorez d'une branche de céleri";
            BloodyMary.CocktailDifficulte = "Difficile";
            BloodyMary.CocktailFavori = "/Assets/Icons/Dark/nofavs.png";

            Cocktail Monaco = new Cocktail("Monaco");
            Monaco.CocktailCommentaire = "Recommandé par la précipauté";
            Monaco.CocktailDescription = "-12cl de bière\n-1cl de sirop de grenadine\n-5cl de limonade (soda,sprite,7-up...).\n• Servir le sirop de grenadine et la limonade sur des Glaçons et allonger de Bière. Boire très frais.";
            Monaco.CocktailImage = "/Assets/Img/cocktail_monaco.png";
            Monaco.CocktailServir = "Servir dans un verre de type \"verre tulipe\".";
            Monaco.CocktailRealisation = "Réalisez la recette dans un verre à mélange.";
            Monaco.CocktailDecoration = "Aucune décoration en particulier";
            Monaco.CocktailDifficulte = "Facile";
            Monaco.CocktailFavori = "/Assets/Icons/Dark/favs.png";

            Cocktail WhiteRussian = new Cocktail("White Russian");
            WhiteRussian.CocktailCommentaire = "Bois un coup camarade !";
            WhiteRussian.CocktailDescription = "-6cl de Vodka\n-6cl de liqueur de café\n-6cl de lait entier ( de préférence).\n• Dans le verre, sur des glaçons, verser les ingrédients. Servir avec un batônnet mélangeur.";
            WhiteRussian.CocktailImage = "/Assets/Img/cocktail_white_russian.png";
            WhiteRussian.CocktailServir = "Servir dans un verre de type \"old fashioned\".";
            WhiteRussian.CocktailRealisation = "Réalisez la recette directement dans le verre.";
            WhiteRussian.CocktailDecoration = "Aucune décoration en particulier";
            WhiteRussian.CocktailDifficulte = "Facile";
            WhiteRussian.CocktailFavori = "/Assets/Icons/Dark/nofavs.png";

            Cocktail BoraBora = new Cocktail("Bora Bora");
            BoraBora.CocktailCommentaire = "Souvenir des îles…";
            BoraBora.CocktailDescription = "-10cl de jus d'ananas\n-6cl de jus de fruit de la passion\n-2cl de sirop de grenadine.\n-1cl de jus de citrons.\n• Frapper au shaker. Servir dans le verre contenant des glaçons et une paille.";
            BoraBora.CocktailImage = "/Assets/Img/cocktail_bora_bora.png";
            BoraBora.CocktailServir = "Servir dans un verre de type \"tumbler\".";
            BoraBora.CocktailRealisation = "Réalisez la recette au shaker.";
            BoraBora.CocktailDecoration = "Une rondelle d'orange";
            BoraBora.CocktailDifficulte = "Facile";
            BoraBora.CocktailFavori = "/Assets/Icons/Dark/nofavs.png";

            CocktailsList.Add(Mojito);
            CocktailsList.Add(PiñaColada);
            CocktailsList.Add(Margarita);
            CocktailsList.Add(SexOnTheBeach);
            CocktailsList.Add(BlueLagoon);
            CocktailsList.Add(TequilaSunrise);
            CocktailsList.Add(Punch);
            CocktailsList.Add(BloodyMary);
            CocktailsList.Add(Monaco);
            CocktailsList.Add(WhiteRussian);
            CocktailsList.Add(BoraBora);

            foreach(Cocktail cocktail in CocktailsList)
            {
                App.ViewModel.AddCocktail(cocktail);
            }
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
        }

        /// <summary>
        /// Supprimer un cocktail de la base
        /// </summary>
        /// <param name="unCocktail"></param>
        public void DeleteCocktail(Cocktail unCocktail)
        {
            // Supprimer le cocktail de la base
            Cocktail leCocktailASupprimer = cocktailDB.cocktails.Single(c => c.CocktailID == unCocktail.CocktailID);
            cocktailDB.cocktails.DeleteOnSubmit(leCocktailASupprimer);

            // Sauvegarder la base de données
            cocktailDB.SubmitChanges();
        }

        public void UpdateCocktail(Cocktail unCocktail)
        {
            Cocktail leCocktailAModifier = cocktailDB.cocktails.Single(c => c.CocktailID == unCocktail.CocktailID);
            leCocktailAModifier.CocktailNom = unCocktail.CocktailNom;
            leCocktailAModifier.CocktailCommentaire = unCocktail.CocktailCommentaire;
            leCocktailAModifier.CocktailDate = unCocktail.CocktailDate;
            leCocktailAModifier.CocktailDecoration = unCocktail.CocktailDecoration;
            leCocktailAModifier.CocktailDescription = unCocktail.CocktailDescription;
            leCocktailAModifier.CocktailDifficulte = unCocktail.CocktailDifficulte;
            leCocktailAModifier.CocktailImage = unCocktail.CocktailImage;
            leCocktailAModifier.CocktailRealisation = unCocktail.CocktailRealisation;
            leCocktailAModifier.CocktailServir = unCocktail.CocktailServir;
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
