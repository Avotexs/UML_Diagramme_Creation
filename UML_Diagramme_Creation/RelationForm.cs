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

        private ComboBox cbSource;
        private ComboBox cbTarget;
        private ComboBox cbType;
        private Button btnOk;
        private Button btnCancel;

        public RelationForm(List<Class> Classes)
        {
            Text = "Ajouter Relation";
            Size = new Size(300, 250);

            // ComboBox pour la classe source
            cbSource = new ComboBox { Location = new Point(120, 20), Width = 150 };
            cbSource.DataSource = new List<Class>(Classes); // Nouvelle copie
            cbSource.DisplayMember = "ClassName";
            Controls.Add(cbSource);

            // ComboBox pour la classe cible
            cbTarget = new ComboBox { Location = new Point(120, 60), Width = 150 };
            cbTarget.DataSource = new List<Class>(Classes); // Nouvelle copie
            cbTarget.DisplayMember = "ClassName";
            Controls.Add(cbTarget);

            // ComboBox pour le type de relation
            Label lblType = new Label { Text = "Type de Relation", Location = new Point(10, 100) };
            Controls.Add(lblType);

            cbType = new ComboBox { Location = new Point(120, 100), Width = 150 };
            cbType.Items.AddRange(new string[] { "Association", "Aggregation", "Composition", "Inheritance" });
            Controls.Add(cbType);

            // Boutons OK et Annuler
            btnOk = new Button { Text = "OK", Location = new Point(50, 150), DialogResult = DialogResult.OK };
            btnOk.Click += BtnOk_Click;
            Controls.Add(btnOk);
           

            btnCancel = new Button { Text = "Annuler", Location = new Point(150, 150), DialogResult = DialogResult.Cancel };
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

            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
