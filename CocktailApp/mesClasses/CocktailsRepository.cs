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
        private CocktailDataContext cocktailDB;

        public CocktailsRepository()
        {
            if (CocktailsList == null) { 
                CocktailsList = new List<Cocktails>();
                Init();
            }
            cocktailDB = new CocktailDataContext("Data Source=isostore:/Cocktails.sdf");
        }

        public void Init()
        {
            Cocktails Mojito = new Cocktails("Mojito");
            Mojito.commentaire = "Extrêmement rafraichissant !";
            Mojito.description = "-6 cl de rhum cubain\n-3 cl de jus de citrons verts\n-7 feuilles de menthe\n-Eau gazeuse (Perrier…)\n-2 cuillères à café de sucre\n Placer les feuilles de menthe dans le verre, ajoutez le sucre et le jus de citrons. Piler consciencieusement afin d'exprimer l'essence de la menthe sans la broyer. Ajouter le rhum, 4 glaçons et mélangez. Remplir la moitié restante du verre d'eau gazeuse. Mélanger doucement avec une paille. Voilà, le Mojito est prêt.";
            Mojito.img = "/Assets/Img/cocktail_mojito.png";
            Mojito.servirDans = "un verre de type \"tumbler\".";
            Mojito.realisation = "directement dans le verre.";
            Mojito.deco = "Décorer de feuilles de menthe fraîches et d'une tranche de citron.";
            Mojito.difficulte = "Moyen";
            Mojito.favoris = "/Assets/Icons/Dark/favs.png";
            Mojito.id = 1;

            Cocktails PiñaColada = new Cocktails("Piña Colada");
            PiñaColada.commentaire = "A déguster allongé sur un transat !";
            PiñaColada.description = "-4 cl de rhum blanc\n-2cl de rhum ambré\n-12 cl de jus d’ananas\n-4cl de lait de coco;\nDans un mixer, versez tous les ingrédients, y compris les glaçons et mixez le tout. C'est prêt ! Versez dans le verre et dégustez.";
            PiñaColada.img = "/Assets/Img/cocktail_pina_colada.png";
            PiñaColada.servirDans = "un verre de type \"verre à vin\".";
            PiñaColada.realisation = "Réalisez la recette \"Piña Colada\" au mixer";
            PiñaColada.deco = "Décorer avec un morceau d'ananas et une cerise confite.";
            PiñaColada.difficulte = "Moyen";
            PiñaColada.favoris = "/Assets/Icons/Dark/nofavs.png";
            PiñaColada.id = 2;

            Cocktails Margarita = new Cocktails("Margarita");
            Margarita.commentaire = "Rien à voir avec la pizza !";
            Margarita.description = "-5 cl de tequila\n-3 cl de triple sec (grand marnier…)\n-2cl de jus de citrons verts\nFrapper les ingrédients au shaker avec des glaçons puis verser dans le verre givré au citron et au sel fin... Pour givrer facilement le verre, passer le citron sur le bord du verre et tremper les bords dans le sel.";
            Margarita.img = "/Assets/Img/cocktail_margarita.png";
            Margarita.servirDans = "un verre de type \"verre à margarita\".";
            Margarita.realisation = "Réalisez la recette au shaker";
            Margarita.deco = "Décorer d'une tranche de citron vert...";
            Margarita.difficulte = "Moyen";
            Margarita.favoris = "/Assets/Icons/Dark/nofavs.png";
            Margarita.id = 3;

            Cocktails SexOnTheBeach= new Cocktails("Sex on the Beach");
            SexOnTheBeach.commentaire = "Où comment jouer avec la température.";
            SexOnTheBeach.description = "-3cl de vodka\n-2cl de sirop de melon\n-2cl de chambord\n-5cl de jus d'ananas\n-6cl de jus de cranberry\n Verser les alcools sur des glaçons, mélanger et compléter avec les jus de fruits.";
            SexOnTheBeach.img = "/Assets/Img/cocktail_sex_on_the_beach.png";
            SexOnTheBeach.servirDans = "Servir dans un verre de type \"verre tulipe\".";
            SexOnTheBeach.realisation = "Réalisez la recette dans un verre à mélange";
            SexOnTheBeach.deco = "Un morceau d'ananas et une cerise confite.";
            SexOnTheBeach.difficulte = "Difficile";
            SexOnTheBeach.favoris = "/Assets/Icons/Dark/favs.png";
            SexOnTheBeach.id = 4;

            Cocktails BlueLagoon = new Cocktails("Blue Lagoon");
            BlueLagoon.commentaire = "La Mer des Caraïbes en bouteille.";
            BlueLagoon.description = "-4cl de vodka\n-3cl de sirop de curuçao bleu\n-2cl de jus de citron\n Pressez le jus d'un demi-citron, ajoutez dans le shaker avec les autres ingrédients et des glaçons. Frappez puis versez dans le verre en filtrant. Afin qu'il soit plus frais et léger, remplissez auparavant le verre de glace pilée.";
            BlueLagoon.img = "/Assets/Img/cocktail_blue_lagoon.png";
            BlueLagoon.servirDans = "Servir dans un verre de type \"verre à martini\".";
            BlueLagoon.realisation = "Réalisez la recette au shaker";
            BlueLagoon.deco = "Un long zeste de citron vert";
            BlueLagoon.difficulte = "Moyen";
            BlueLagoon.favoris = "/Assets/Icons/Dark/nofavs.png";
            BlueLagoon.id = 5;

            Cocktails TequilaSunrise = new Cocktails("Tequila Sunrise");
            TequilaSunrise.commentaire = "Avoir un coucher de soleil dans son verre.";
            TequilaSunrise.description = "-6cl de tequila\n-12cl de jus d'orange\n-2cl de sirop de grenadine.\n Verser la tequila sur des glaçons dans le verre. Compléter avec le jus d'orange et remuer. Versez doucement le sirop de grenadine dans le verre pour que celui-ci tombe au fond. Donnez alors un petit coup de cuillère pour affiner le dégradé si nécessaire.";
            TequilaSunrise.img = "/Assets/Img/cocktail_tequila_sunrise.png";
            TequilaSunrise.servirDans = "Servir dans un verre de type \"tumbler\".";
            TequilaSunrise.realisation = "Réalisez la recette directement dans le verre";
            TequilaSunrise.deco = "Une rondelle d'orange";
            TequilaSunrise.difficulte = "Facile";
            TequilaSunrise.favoris = "/Assets/Icons/Dark/nofavs.png";
            TequilaSunrise.id = 6;


            Cocktails Punch = new Cocktails("Punch");
            Punch.commentaire = "Bon comme un coup dans les dents !";
            Punch.description = "-100cl de rhum blanc\n-50cl de sirop de sucre de canne\n-100cl de jus d'oranges.\n-100cl de jus d'ananas.\n-100cl de jus pamplemousses.\n-1 bâton de cannelle.\n-3 sachets de thé.\n • Faire infuser 3 sachets de thé et un bâton de cannelle dans un verre d'eau bouillante pendant 5 minutes.(!)Si vous n'avez pas de bâtons de cannelle, utilisez du sirop de cannelle ou saupoudrez de cannelle en poudre.(!) Ensuite, mélanger le tout dans une grande bouteille à eau de 5 l, très pratique pour mettre au réfrigérateur. Ou dans un saladier, pour servir avec une louche. A servir frais.";
            Punch.img = "/Assets/Img/cocktail_punch.png";
            Punch.servirDans = "Servir dans un verre traditionnel";
            Punch.realisation = "Réalisez la recette directement en bouteille";
            Punch.deco = "Aucune décoration en particulier";
            Punch.difficulte = "Moyen";
            Punch.favoris = "/Assets/Icons/Dark/nofavs.png";
            Punch.id = 7;


            Cocktails BloodyMary = new Cocktails("Bloody Mary");
            BloodyMary.commentaire = "Un piquant... mortel !";
            BloodyMary.description = "-4cl de vodka\n-12cl de jus de tomates\n-0.5cl de jus de citrons.\n-0.5cl de saucse worcestershire.\n-2 gouttes de tabasco.\n-Sel de céleri.\n-Sel et Poivre.\n • Agiter les ingrédients dans un verre à mélange avec des glaçons (pour refroidir sans trop diluer). Verser dans le verre, puis ajouter à convenance sel de céleri, sel et poivre. Décorer avec une tige de céleri et optionellement, une rondelle de citron.";
            BloodyMary.img = "/Assets/Img/cocktail_bloody_mary.png";
            BloodyMary.servirDans = "Servir dans un verre de type \"tumbler\".";
            BloodyMary.realisation = "Réalisez la recette dans un verre à mélange.";
            BloodyMary.deco = "Décorez d'une branche de céleri";
            BloodyMary.difficulte = "Difficile";
            BloodyMary.favoris = "/Assets/Icons/Dark/nofavs.png";
            BloodyMary.id = 8;

            Cocktails Monaco = new Cocktails("Monaco");
            Monaco.commentaire = "Recommandé par la précipauté";
            Monaco.description = "-12cl de bière\n-1cl de sirop de grenadine\n-5cl de limonade (soda,sprite,7-up...).\n• Servir le sirop de grenadine et la limonade sur des Glaçons et allonger de Bière. Boire très frais.";
            Monaco.img = "/Assets/Img/cocktail_monaco.png";
            Monaco.servirDans = "Servir dans un verre de type \"verre tulipe\".";
            Monaco.realisation = "Réalisez la recette dans un verre à mélange.";
            Monaco.deco = "Aucune décoration en particulier";
            Monaco.difficulte = "Facile";
            Monaco.favoris = "/Assets/Icons/Dark/favs.png";
            Monaco.id = 9;

            Cocktails WhiteRussian= new Cocktails("White Russian");
            WhiteRussian.commentaire = "Bois un coup camarade !";
            WhiteRussian.description = "-6cl de Vodka\n-6cl de liqueur de café\n-6cl de lait entier ( de préférence).\n• Dans le verre, sur des glaçons, verser les ingrédients. Servir avec un batônnet mélangeur.";
            WhiteRussian.img = "/Assets/Img/cocktail_white_russian.png";
            WhiteRussian.servirDans = "Servir dans un verre de type \"old fashioned\".";
            WhiteRussian.realisation = "Réalisez la recette directement dans le verre.";
            WhiteRussian.deco = "Aucune décoration en particulier";
            WhiteRussian.difficulte = "Facile";
            WhiteRussian.favoris = "/Assets/Icons/Dark/nofavs.png";
            WhiteRussian.id = 10;

            Cocktails BoraBora = new Cocktails("Bora Bora");
            BoraBora.commentaire = "Souvenir des îles…";
            BoraBora.description = "-10cl de jus d'ananas\n-6cl de jus de fruit de la passion\n-2cl de sirop de grenadine.\n-1cl de jus de citrons.\n• Frapper au shaker. Servir dans le verre contenant des glaçons et une paille.";
            BoraBora.img = "/Assets/Img/cocktail_bora_bora.png";
            BoraBora.servirDans = "Servir dans un verre de type \"tumbler\".";
            BoraBora.realisation = "Réalisez la recette au shaker.";
            BoraBora.deco = "Une rondelle d'orange";
            BoraBora.difficulte = "Facile";
            BoraBora.favoris = "/Assets/Icons/Dark/nofavs.png";
            BoraBora.id = 11;

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
