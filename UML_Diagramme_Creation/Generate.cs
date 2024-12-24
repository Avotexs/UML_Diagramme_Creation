using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace UML_Diagramme_Creation
{
    public partial class Generate : Form
    {
        List<Class> Classes;
        public List<Relation> Relations { get; set; } = new List<Relation>();
        public Generate(List<Class> Classes,  List<Relation> Relation)
        {
            this.Classes = new List<Class>();
            this.Classes = Classes;
            Relations = Relation;
            InitializeComponent();
        }

        private void generateexitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCsharp_Click(object sender, EventArgs e)
        {
            var codeGenerator = new CodeGenerator(Classes, Relations);
            string generatedCode = codeGenerator.GenerateCode();

            // Afficher ou sauvegarder le code
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Fichiers C# (*.cs)|*.cs",
                Title = "Enregistrer le code généré"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, generatedCode);
                MessageBox.Show("Code généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPhp_Click(object sender, EventArgs e)
        {
            var CodeGeneratorPhp = new CodeGeneratorPhp(Classes, Relations);
            string generatedCode = CodeGeneratorPhp.GenerateCodePHP();

            // Afficher ou sauvegarder le code
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Fichiers PHP (*.php)|*.php",
                Title = "Enregistrer le code généré"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, generatedCode);
                MessageBox.Show("Code généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPython_Click(object sender, EventArgs e)
        {
            var CodeGeneratorPython = new CodeGeneratorPython(Classes, Relations);
            string generatedCode = CodeGeneratorPython.GenerateCodePython();

            // Afficher ou sauvegarder le code
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Fichiers Python (*.py)|*.py",
                Title = "Enregistrer le code généré"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(saveFileDialog.FileName, generatedCode);
                MessageBox.Show("Code généré avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
