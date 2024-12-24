using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{
    internal class CodeGeneratorPython
    {
        private List<Class> Classes;
        private List<Relation> Relations;
        public CodeGeneratorPython(List<Class> classes, List<Relation> relations)
        {
            Classes = classes;
            Relations = relations;
        }
        public string GenerateCodePython()
        {
            StringBuilder code = new StringBuilder();

            foreach (var umlClass in Classes)
            {
                // Class declaration
                code.AppendLine($"class {umlClass.ClassName}:");
                if (umlClass.Attributes.Count == 0 && umlClass.Methodes.Count == 0)
                {
                    code.AppendLine("    pass");
                    continue;
                }

                // Constructor
                string paramsList = string.Join(", ", umlClass.Attributes.Select(a => $"{a.Charater}"));
                code.AppendLine($"    def __init__(self, {paramsList}):");
                foreach (var attribute in umlClass.Attributes)
                {
                    code.AppendLine($"        self.{attribute.Charater} = {attribute.Charater}");
                }
                code.AppendLine();

                // Methods
                foreach (var method in umlClass.Methodes)
                {
                    string paramsListe = string.Join(", ", method.Variables.Select(p => $"{p.Nom}"));
                    code.AppendLine($"    def {method.Charater}(self, {paramsListe}):");
                    code.AppendLine("        # TODO: Implement method logic");
                    if (method.Typ != "Void")
                    {
                        code.AppendLine($"        return result  # Example return value");
                    }
                    code.AppendLine();
                }
            }

            // Relations as comments
            code.AppendLine("# Class relationships:");
            foreach (var relation in Relations)
            {
                code.AppendLine($"# {relation.Source.ClassName} {relation.Type} {relation.Target.ClassName}");
            }

            return code.ToString();
        }
    }
}
