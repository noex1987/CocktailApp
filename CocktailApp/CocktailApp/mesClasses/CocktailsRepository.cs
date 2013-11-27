﻿using System;
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
            Cocktails BananaColada = new Cocktails("Banana Colada");
            //BananaColada.img = "/Assets/Img/cocktail_banana_colada.png";
            BananaColada.difficulte = "Difficile";
            BananaColada.favoris = "/Assets/Icons/Dark/favs.png";
            BananaColada.id = 1;

            Cocktails MandaShot = new Cocktails("Manda Shot");
            MandaShot.img = "/Assets/Img/cocktail_a_manda_shot.png";
            MandaShot.difficulte = "Moyen";
            MandaShot.description = "Un délicieux cocktail dont je ne connais pas du tout la recette ! Pratique pour faire une description";
            MandaShot.id = 2;

            Cocktails DaiquiriGlace = new Cocktails("Daiquiri Glace");
            DaiquiriGlace.img = "/Assets/Img/cocktail_daiquiri_glace.png";
            DaiquiriGlace.difficulte = "Novice";
            DaiquiriGlace.id = 3;

            Cocktails DaiquiriGlaceMure = new Cocktails("Daiquiri Glace Mure");
            DaiquiriGlaceMure.img = "/Assets/Img/cocktail_daiquiri_glace_a_la_mure.png";
            DaiquiriGlaceMure.difficulte = "Moyen";
            DaiquiriGlaceMure.favoris = "/Assets/Icons/Dark/favs.png";
            DaiquiriGlaceMure.id = 4;

            Cocktails CranberryCollins = new Cocktails("Cranberry Collins");
            CranberryCollins.img = "/Assets/Img/cocktail_cranberry_collins.png";
            CranberryCollins.difficulte = "Difficile";
            CranberryCollins.id = 5;

            Cocktails FrenchMartini = new Cocktails("French Martini");
            FrenchMartini.img = "/Assets/Img/cocktail_french_martini.png";
            FrenchMartini.difficulte = "Novice";
            FrenchMartini.id = 6;

            Cocktails TequilaSlammer = new Cocktails("Tequila Slammer");
            TequilaSlammer.img = "/Assets/Img/cocktail_tequila_slammer.png";
            TequilaSlammer.difficulte = "Moyen";
            TequilaSlammer.id = 7;

            Cocktails PinkLady = new Cocktails("PinkLady");
            PinkLady.img = "/Assets/Img/cocktail_pink_lady.png";
            PinkLady.difficulte = "Difficile";
            PinkLady.id = 8;

            CocktailsList.Add(BananaColada);
            CocktailsList.Add(MandaShot);
            CocktailsList.Add(DaiquiriGlace);
            CocktailsList.Add(DaiquiriGlaceMure);
            CocktailsList.Add(CranberryCollins);
            CocktailsList.Add(FrenchMartini);
            CocktailsList.Add(TequilaSlammer);
            CocktailsList.Add(PinkLady);
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

        public List<Cocktails> List()
        {
            return CocktailsList;
        }
    }
}
