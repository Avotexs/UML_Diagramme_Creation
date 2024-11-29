﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{

    public class Attribut
    {
        private string Visibilite { get; set; }
        private string Charater { get; set; }
        private string Typ { get; set; }

        public Attribut(string visibilite, string charater, string typ)
        {
            Visibilite = visibilite;
            Charater = charater;
            Typ = typ;
        }
    }
}