using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{
    public class Class
    {
        public string ClassName { get; set; }
        public List<Attribut> Attributes { get; set; }
        public List<Methode> Methodes { get; set; }
        public Rectangle Position { get; set; }
        public Class() { }  
        public Class(string className, Rectangle position)
        {
            ClassName = className;
            Attributes = new List<Attribut>();
            Methodes = new List<Methode>();
            Position = position;
        }
    }
}
