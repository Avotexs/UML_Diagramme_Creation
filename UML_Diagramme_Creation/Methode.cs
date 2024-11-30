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
        private string Typ { get; set; }

        public Methode(string charater, string visibilite, string typ)
        {
            Visibilite = visibilite;
            Charater = charater;
            Typ = typ;
        }
        public string retournMethod()
        {
            if (Visibilite == "Public") { Visibilite = "+"; }
            else if (Visibilite == "Privé") { Visibilite = "-"; }
            else { Visibilite = "#"; }
            
            return this.Visibilite + " " + this.Charater + "() : " + this.Typ;
        }

    }
}
