using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{
    public class Relation
    {
        public Class Source { get; set; }
        public Class Target { get; set; }
        public string Type { get; set; } // Association, Aggregation, Composition, Inheritance

        public Relation(Class source, Class target, string type)
        {
            Source = source;
            Target = target;
            Type = type;
        }
    }
}
