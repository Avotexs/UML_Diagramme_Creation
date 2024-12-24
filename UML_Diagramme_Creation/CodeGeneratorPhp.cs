using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML_Diagramme_Creation
{
    internal class CodeGeneratorPhp
    {
        private List<Class> Classes;
        private List<Relation> Relations;
        public CodeGeneratorPhp(List<Class> classes, List<Relation> relations)
        {
            Classes = classes;
            Relations = relations;
        }
        public string GenerateCodePHP()
        {
           
        StringBuilder code = new StringBuilder();
            //
            code.AppendLine("<?php");
            foreach (var umlClass in Classes)
            {
                // Class declaration
                
                code.AppendLine($"class {umlClass.ClassName}");
                code.AppendLine("{");

                // Attributes
                foreach (var attribute in umlClass.Attributes)
                {
                    string visibility = attribute.Visibilite.ToLower() == "public" ? "public" :
                                        attribute.Visibilite.ToLower() == "private" ? "private" : "protected";
                    code.AppendLine($"    {visibility} ${attribute.Charater};");
                }
                code.AppendLine();

                // Constructor
                string paramsList = string.Join(", ", umlClass.Attributes.Select(a => $"${a.Charater}"));
                code.AppendLine($"    public function __construct({paramsList})");
                code.AppendLine("    {");
                foreach (var attribute in umlClass.Attributes)
                {
                    code.AppendLine($"        $this->{attribute.Charater} = ${attribute.Charater};");
                }
                code.AppendLine("    }");
                code.AppendLine();

                // Methods
                foreach (var method in umlClass.Methodes)
                {
                    string visibility = method.Visibilite.ToLower();
                    string paramsListe = string.Join(", ", method.Variables.Select(p => $"${p.Nom}"));
                    code.AppendLine($"    {visibility} function {method.Charater}({paramsListe})");
                    code.AppendLine("    {");
                    code.AppendLine("        // TODO: Implement method logic");
                    if (method.Typ != "Void")
                    {
                        code.AppendLine($"        return $result; // Example return value");
                    }
                    code.AppendLine("    }");
                    code.AppendLine();
                }

                code.AppendLine("}");
                code.AppendLine();
            }

            // Relations as comments
            code.AppendLine("// Class relationships:");
            foreach (var relation in Relations)
            {
                code.AppendLine($"// {relation.Source.ClassName} {relation.Type} {relation.Target.ClassName}");
            }

            return code.ToString();
        }
    }
}
