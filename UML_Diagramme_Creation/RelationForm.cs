using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UML_Diagramme_Creation
{
    public partial class RelationForm : Form
    {
        public RelationForm()
        {
            InitializeComponent();
        }
        public List<Class> classes;
        Class c = new Class();
        public Class SelectedSource { get;  set; }
        public Class SelectedTarget { get;  set; }
        public string SelectedType { get;  set; }
        public string SourceCardinality { get; set; }
        public string TargetCardinality { get; set; }

        private ComboBox cbSource;
        private ComboBox cbTarget;
        private ComboBox cbType;
        private TextBox tbSourceCardinality;
        private TextBox tbTargetCardinality;
        private Button btnOk;
        private Button btnCancel;

        public RelationForm(List<Class> Classes)
        {
            Text = "Add Relation";
            Size = new Size(300, 300);

            // ComboBox pour la classe source
            Label lblClassesource = new Label { Text = "Source classe", Location = new Point(10, 20) };
            Controls.Add(lblClassesource);

            cbSource = new ComboBox { Location = new Point(120, 20), Width = 150 };
            cbSource.DataSource = new List<Class>(Classes); // Nouvelle copie
            cbSource.DisplayMember = "ClassName";
            Controls.Add(cbSource);

            // ComboBox pour la classe cible
            Label lblClasseCible = new Label { Text = "Target classe", Location = new Point(10, 60) };
            Controls.Add(lblClasseCible);


            cbTarget = new ComboBox { Location = new Point(120, 60), Width = 150 };
            cbTarget.DataSource = new List<Class>(Classes); // Nouvelle copie
            cbTarget.DisplayMember = "ClassName";
            Controls.Add(cbTarget);

            // ComboBox pour le type de relation
            Label lblType = new Label { Text = "Relation Type", Location = new Point(10, 100) };
            Controls.Add(lblType);

            cbType = new ComboBox { Location = new Point(120, 100), Width = 150 };
            cbType.Items.AddRange(new string[] { "Association", "Aggregation", "Composition", "Inheritance" });
            Controls.Add(cbType);

            //input pour les cardinalité
            Label lblSourceCardinality = new Label { Text = "Source Cardinality", Location = new Point(10, 140) };
            Controls.Add(lblSourceCardinality);

            tbSourceCardinality = new TextBox { Location = new Point(120, 140), Width = 150 };
            Controls.Add(tbSourceCardinality);

            Label lblTargetCardinality = new Label { Text = "Target Cardinality", Location = new Point(10, 180) };
            Controls.Add(lblTargetCardinality);

            tbTargetCardinality = new TextBox { Location = new Point(120, 180), Width = 150 };
            Controls.Add(tbTargetCardinality);

            // Boutons OK et Annuler
            btnOk = new Button { Text = "OK", Location = new Point(50, 220), DialogResult = DialogResult.OK };
            btnOk.Click += BtnOk_Click;
            Controls.Add(btnOk);
           

            btnCancel = new Button { Text = "Cancel", Location = new Point(150, 220), DialogResult = DialogResult.Cancel };
            Controls.Add(btnCancel);
            classes = Classes;
        }

       Home h=new Home();

        private void BtnOk_Click(object sender, EventArgs e)
        {
            // Validation des choix
            SelectedSource = cbSource.SelectedItem as Class;
            SelectedTarget = cbTarget.SelectedItem as Class;
            SelectedType = cbType.SelectedItem as string;


            SourceCardinality = tbSourceCardinality.Text;
            TargetCardinality = tbTargetCardinality.Text;

            if (SelectedSource == null || SelectedTarget == null || SelectedType == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (SelectedSource == SelectedTarget)
            {
                MessageBox.Show("La source et la cible ne peuvent pas être identiques.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(SourceCardinality) || string.IsNullOrWhiteSpace(TargetCardinality))
            {
                MessageBox.Show("Veuillez spécifier les cardinalités.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
