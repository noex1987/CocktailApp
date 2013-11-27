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
        public string description { get; set; }
        public string img { get; set; }
        public string difficulte { get; set; }
        public string favoris { get; set; }
        private DateTime dateCreation;
        private DateTime dateMiseAJour;

        public Cocktails(string p_nom)
        {
            this.nom = p_nom;
            this.description = "Aucune description";
            this.img = "/Assets/img/no-image.png";
            this.difficulte = "Moyen";
            this.favoris = "";
            this.dateCreation = this.dateMiseAJour = new DateTime();
        }
        public Cocktails(string p_nom, string p_description, string p_img,string p_difficulte, DateTime p_date)
        {
            this.nom = p_nom;
            this.description = p_description;
            this.img = p_img;
            this.difficulte = p_difficulte;
            this.favoris = "";
            this.dateCreation = this.dateMiseAJour = p_date;
        }

        public void ModDate()
        {
            this.dateMiseAJour = new DateTime();
        }
    }
}
