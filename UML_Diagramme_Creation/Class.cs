using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{
    internal class Class
    {
        public string ClassName { get; set; }
        public List<string> Attributes { get; set; }
        public List<string> Methods { get; set; }
        public Rectangle Position { get; set; }

        public Class(string className, Rectangle position)
        {
            ClassName = className;
            Attributes = new List<string>();
            Methods = new List<string>();
            Position = position;
        }
    }
}
