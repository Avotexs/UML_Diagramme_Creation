using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string retournAttribut()
        {
            
            if (Visibilite == "Public") { Visibilite = "+"; }
            else if (Visibilite == "Privé"){Visibilite = "-"; }
            else { Visibilite = "#"; }
            
            return this.Visibilite+" "+this.Charater+" : "+this.Typ;
        }
    }
}
