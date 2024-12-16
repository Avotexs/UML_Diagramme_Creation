using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{
    public class CodeGenerator
    {
        private List<Class> Classes;
        private List<Relation> Relations;

        public CodeGenerator(List<Class> classes, List<Relation> relations)
        {
            Classes = classes;
            Relations = relations;
        }

        public string GenerateCode()
        {
            StringBuilder code = new StringBuilder();

            // Parcourir chaque classe et générer le code correspondant
            foreach (var umlClass in Classes)
            {
                // Déclaration de la classe
                code.AppendLine($"public class {umlClass.ClassName}");
                code.AppendLine("{");

                // Générer les attributs
                foreach (var attribute in umlClass.Attributes)
                {
                    string visibility = attribute.Visibilite; 
                    code.AppendLine($"    {visibility} {attribute.Typ} {attribute.Charater} {{ get; set; }}");
                }

                code.AppendLine();

                // Générer les méthodes
                foreach (var method in umlClass.Methodes)
                {
                    string visibility = method.Visibilite; 
                    string parameters = string.Join(", ", method.Variables.Select(p => $"{p.Type} {p.Nom}"));
                    code.AppendLine($"    {visibility} {method.Typ} {method.Charater}({parameters})");
                    code.AppendLine("    {");
                    code.AppendLine("        // TODO: Ajouter la logique de la méthode");
                    code.AppendLine("    }");
                    code.AppendLine();
                }

                code.AppendLine("}");
                code.AppendLine();
            }

            // Ajouter les relations en tant que commentaires pour documentation
            code.AppendLine("// Relations entre les classes");
            foreach (var relation in Relations)
            {
                code.AppendLine($"// {relation.Source.ClassName} {relation.Type} {relation.Target.ClassName}");
            }

            return code.ToString();
        }
    }
}
