using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace UML_Diagramme_Creation
{

    public class Attribut
    {
        public string Visibilite { get; set; }
        public string Charater { get; set; }
        public string Typ { get; set; }
        
        public Attribut(string charater,string visibilite,  string typ)
        {
            Visibilite = visibilite;
            Charater = charater;
            Typ = typ;
        }

 



        public string retournAttributSymbol()
        {
            string t = "a";
            if (this.Visibilite == "Public")
            {
                t = "+ " + Typ + " " + Charater ;
            }
            if (this.Visibilite == "Privé")
            {
                t = "- "+ Typ + " " + Charater ; 
            }
            if (this.Visibilite == "Protected")
            {
                t = "# " + Typ + " " + Charater ;

            }

            return t;
        }
        public string retournAttribut()
        {
            /*
            if (this.Visibilite == "Public") { Visibilite = "+"; }
             if (this.Visibilite == "Privé"){Visibilite = "-"; }
            if ( this.Visibilite == "Protected") {  Visibilite = "#"; }
            */
            return this.Visibilite+" "+this.Charater+" : "+this.Typ;
        }
        /*public string retournAttribut()
        {

            string chaine = "";
            if (this.Visibilite == "Public")
            { chaine = "+ " + this.Typ + " " + this.Charater + "()  "; }
            if (this.Visibilite == "Privé")
            { chaine = "- " + this.Typ + " " + this.Charater + "()  "; }
            if (this.Visibilite == "Protected")
            { chaine = "# " + this.Typ + " " + this.Charater + "()  "; }

            return chaine;
        }*/
       



    }
}
