using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.mesClasses
{
    class CocktailsRepository
    {
        private static List<Cocktails> CocktailsList = null;

        public CocktailsRepository()
        {
            if (CocktailsList == null) { 
                CocktailsList = new List<Cocktails>();
                Init();
            }
        }

        private void Init()
        {
            Cocktails Mojito = new Cocktails("Mojito");
            Mojito.commentaire = "Extrêmement rafraichissant !";
            Mojito.description = "-6 cl de rhum cubain /n-3 cl de jus de citrons verts/n-7 feuilles de menthe /n-Eau gazeuse (Perrier…)/n-2 cuillères à café de sucre/n Placer les feuilles de menthe dans le verre, ajoutez le sucre et le jus de citrons. Piler consciencieusement afin d'exprimer l'essence de la menthe sans la broyer. Ajouter le rhum, 4 glaçons et mélangez. Remplir la moitié restante du verre d'eau gazeuse. Mélanger doucement avec une paille. Voilà, le Mojito est prêt.";
            Mojito.img = "/Assets/Img/cocktail_banana_colada.png";
            Mojito.servirDans = "un verre de type \"tumbler\".";
            Mojito.realisation = "directement dans le verre.";
            Mojito.deco = "Décorer de feuilles de menthe fraîches et d'une tranche de citron.";
            Mojito.difficulte = "Moyen";
            Mojito.favoris = "/Assets/Icons/Dark/favs.png";
            Mojito.id = 1;

            Cocktails PiñaColada = new Cocktails("Piña Colada");
            Mojito.commentaire = "A déguster allongé sur un transat !";
            Mojito.description = "-4 cl de rhum blanc\n-2cl de rhum ambré\n-12 cl de jus d’ananas\n-4cl de lait de coco;\nDans un mixer, versez tous les ingrédients, y compris les glaçons et mixez le tout. C'est prêt ! Versez dans le verre et dégustez.";
            Mojito.img = "/Assets/Img/cocktail_pina_colada.png";
            Mojito.servirDans = "un verre de type \"verre à vin\".";
            Mojito.realisation = "Réalisez la recette \"Piña Colada\" au mixer";
            Mojito.deco = "Décorer avec un morceau d'ananas et une cerise confite.";
            Mojito.difficulte = "Moyen";
            Mojito.favoris = "/Assets/Icons/Dark/nofavs.png";
            Mojito.id = 2;

            /*
            Cocktails BananaColada = new Cocktails("Banana Colada");
            //BananaColada.img = "/Assets/Img/cocktail_banana_colada.png";
            BananaColada.difficulte = "Difficile";
            BananaColada.favoris = "/Assets/Icons/Dark/favs.png";
            BananaColada.id = 1;

            Cocktails MandaShot = new Cocktails("Manda Shot");
            MandaShot.img = "/Assets/Img/cocktail_a_manda_shot.png";
            MandaShot.difficulte = "Moyen";
            MandaShot.favoris = "/Assets/Icons/Dark/nofavs.png";
            MandaShot.description = "Un délicieux cocktail dont je ne connais pas du tout la recette ! Pratique pour faire une description";
            MandaShot.id = 2;

            Cocktails DaiquiriGlace = new Cocktails("Daiquiri Glace");
            DaiquiriGlace.img = "/Assets/Img/cocktail_daiquiri_glace.png";
            DaiquiriGlace.favoris = "/Assets/Icons/Dark/nofavs.png";
            DaiquiriGlace.difficulte = "Novice";
            DaiquiriGlace.id = 3;

            Cocktails DaiquiriGlaceMure = new Cocktails("Daiquiri Glace Mure");
            DaiquiriGlaceMure.img = "/Assets/Img/cocktail_daiquiri_glace_a_la_mure.png";
            DaiquiriGlaceMure.difficulte = "Moyen";
            DaiquiriGlaceMure.favoris = "/Assets/Icons/Dark/favs.png";
            DaiquiriGlaceMure.id = 4;

            Cocktails CranberryCollins = new Cocktails("Cranberry Collins");
            CranberryCollins.img = "/Assets/Img/cocktail_cranberry_collins.png";
            CranberryCollins.favoris = "/Assets/Icons/Dark/nofavs.png";
            CranberryCollins.difficulte = "Difficile";
            CranberryCollins.id = 5;

            Cocktails FrenchMartini = new Cocktails("French Martini");
            FrenchMartini.img = "/Assets/Img/cocktail_french_martini.png";
            FrenchMartini.favoris = "/Assets/Icons/Dark/nofavs.png";
            FrenchMartini.difficulte = "Novice";
            FrenchMartini.id = 6;

            Cocktails TequilaSlammer = new Cocktails("Tequila Slammer");
            TequilaSlammer.img = "/Assets/Img/cocktail_tequila_slammer.png";
            TequilaSlammer.favoris = "/Assets/Icons/Dark/nofavs.png";
            TequilaSlammer.difficulte = "Moyen";
            TequilaSlammer.id = 7;

            Cocktails PinkLady = new Cocktails("PinkLady");
            PinkLady.img = "/Assets/Img/cocktail_pink_lady.png";
            PinkLady.favoris = "/Assets/Icons/Dark/nofavs.png";
            PinkLady.difficulte = "Difficile";
            PinkLady.id = 8;
            */
            CocktailsList.Add(Mojito);
            CocktailsList.Add(PiñaColada);
            /*
            CocktailsList.Add(DaiquiriGlace);
            CocktailsList.Add(DaiquiriGlaceMure);
            CocktailsList.Add(CranberryCollins);
            CocktailsList.Add(FrenchMartini);
            CocktailsList.Add(TequilaSlammer);
            CocktailsList.Add(PinkLady);*/
        }

        public Cocktails Find(int id)
        {
            return CocktailsList.FirstOrDefault(c => c.id == id);
        }

        public static void Add(Cocktails unCocktail)
        {
            if (!CocktailsList.Contains(unCocktail))
                CocktailsList.Add(unCocktail);
        }

        public static void Remove(Cocktails leCocktail) 
        {
            if(CocktailsList.Contains(leCocktail))
                CocktailsList.Remove(leCocktail);
        }

        public static void Edit(Cocktails unCocktail, string Nom, string Desc, string Img, string Difficulte, string Commentaire, string ServirDans, string Deco, string Realisation)
        {
            if (CocktailsList.Contains(unCocktail))
            {
                unCocktail.nom = Nom;
                unCocktail.commentaire = Commentaire;
                unCocktail.description = Desc;
                unCocktail.img = Img;
                unCocktail.servirDans = ServirDans;
                unCocktail.realisation = Realisation;
                unCocktail.deco = Deco;
                unCocktail.difficulte = Difficulte;
                unCocktail.ModDate();

            }
        }

        public List<Cocktails> List()
        {
            return CocktailsList;
        }
    }
}
