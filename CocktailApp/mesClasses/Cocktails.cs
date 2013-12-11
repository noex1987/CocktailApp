using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailApp.mesClasses
{
    class Cocktails
    {
        public int id { get; set; }
        public string nom {get;set;}
        public string commentaire { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public string difficulte { get; set; }
        public string favoris { get; set; }

        public string realisation { get; set; }
        public string servirDans { get; set; }
        public string deco { get; set; }

        private DateTime dateCreation;
        private DateTime dateMiseAJour;

        public Cocktails(string p_nom)
        {
            this.nom = p_nom;
            this.description = "Aucune description";
            this.commentaire = "Sans commentaire";
            this.img = "/Assets/img/no-image.png";
            this.difficulte = "Moyen";
            this.favoris = "/Assets/Icons/Dark/nofavs.png";
            this.deco = "Aucune décoration particulière";
            this.realisation = "Non indiqué";
            this.servirDans = "Non indiqué";
            this.dateCreation = this.dateMiseAJour = new DateTime();
        }
        public Cocktails(string p_nom, string p_description, string p_commentaire, string p_img,string p_difficulte, string p_deco, string p_real, string p_serv, DateTime p_date)
        {
            this.nom = p_nom;

            if (p_description != "Saisissez la totalité de la recette.")
                this.description = p_description;
            else
                this.description = "Aucune description";

            if (p_commentaire != "Saisissez un commentaire personnel")
                this.commentaire = p_commentaire;
            else
                this.commentaire = "Sans commentaire";
           
            this.img = p_img;
            this.difficulte = p_difficulte;
            this.favoris = "/Assets/Icons/Dark/nofavs.png";

            if (p_deco != "Décrivez la décoration à ajouter.")
                this.deco = p_deco;
            else
                this.deco = "Aucune décoration particulière";

            if (p_real != "Où faut-il préparer le cocktail ?")
                this.realisation = p_real;
            else
                this.realisation = "Non indiqué";

            if (p_serv != "Où faut-il servir le cocktail ?")
                this.servirDans = p_serv;
            else
                this.servirDans = "Non indiqué";

            this.dateCreation = this.dateMiseAJour = p_date;
        }

        public void ModDate()
        {
            this.dateMiseAJour = new DateTime();
        }

        public void ChangeFav()
        {
            if ( this.favoris == "/Assets/Icons/Dark/nofavs.png" )
            {
                this.favoris = "/Assets/Icons/Dark/favs.png";
            }
            else
            {
                this.favoris = "/Assets/Icons/Dark/nofavs.png";
            }
            
        }
    }
}
