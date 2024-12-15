using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{
    public class Parametres
    {
        private string Nom { get; set; }
        private string Type { get; set; }

        public Parametres( string nom,string type) 
        {
            Nom = nom;
            Type = type;
        }
        public string chaine()
        {
            return Type + " " + Nom + ".";
        }
        
    }
}
