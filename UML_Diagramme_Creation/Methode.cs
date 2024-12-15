using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{
    public class Methode
    {
        private string Visibilite {  get; set; }
        private string Charater {  get; set; }
        public List<Parametres> Variables { get; set; } = new List<Parametres>();
        private string Typ { get; set; }
        public Methode() {
            
        }

        public Methode(string charater, string visibilite, string typ)
        {
            Visibilite = visibilite;
            Charater = charater;
            
            Typ = typ;
        }
        public string retournMethod()
        {
            string stringParametre = "";
            if (this.Variables != null)
            {

                foreach (Parametres m in this.Variables)
                {
                    stringParametre += m.chaine();

                }
            }

            /*if (this.Visibilite == "Public") { Visibilite = "+"; }
            if (this.Visibilite == "Privé") { Visibilite = "-"; }
            if (this.Visibilite == "Protected") { Visibilite = "#"; }*/
            string t = Visibilite + "   " + Typ + " " + Charater + "("+ stringParametre + ")";
            return t;
            //return Visibilite; 
        }
        /*public string retournMethod()
        {
            string chaine = "";
            if (this.Visibilite == "Public")
            { chaine = "+ " + this.Typ + " " + this.Charater + "()  "; }
            if (this.Visibilite == "Privé")
            { chaine = "- " + this.Typ + " " + this.Charater + "()  "; }
            if (this.Visibilite == "Protected")
            { chaine = "# " + this.Typ + " " + this.Charater + "()  "; }

            return chaine;
            //return Visibilite; 
        }*/



        public string retournMethodSymbol()
        {

            string stringParametre = "";
            if (this.Variables!=null)
            {
                
                foreach (Parametres m in this.Variables)
                {
                    stringParametre += m.chaine();

                }
            }
            string t = "";
            if (this.Visibilite == "Public") 
            {
                t = "+ " + Typ + " " + Charater + "("+ stringParametre + ")"; 
            }
            if (this.Visibilite == "Privé") 
            {
                t = "- " + Typ + " " + Charater + "("+ stringParametre + ")"; ; 
            }
            if (this.Visibilite == "Protected") 
            {
                t = "# " + Typ + " " + Charater + "("+ stringParametre + ")";

            }
           
            
            return t; 
        }
        
    }
}
