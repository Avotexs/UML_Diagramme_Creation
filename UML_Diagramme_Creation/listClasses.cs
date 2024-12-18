using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Image = System.Drawing.Image;

namespace UML_Diagramme_Creation
{
    public partial class listClasses : Form
    {
        List<Class> Classes;
        public listClasses(List<Class> classes)
        {
            InitializeComponent();
            Classes = new List<Class>();
            Classes = classes;
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void listClasses_Load_1(object sender, EventArgs e)
        {
            // Ajouter une colonne de boutons MODIFIER
            DataGridViewButtonColumn buttonColumnModiffier = new DataGridViewButtonColumn();
            buttonColumnModiffier.Name = "ButtonColumnModiffier";
            buttonColumnModiffier.HeaderText = "Modiffier";
            buttonColumnModiffier.Text = "Click me";
            buttonColumnModiffier.UseColumnTextForButtonValue = true;
            guna2DataGridView1.Columns.Add(buttonColumnModiffier);

            // Ajouter une colonne de boutons Suprimer
            DataGridViewButtonColumn buttonColumnSuprimer = new DataGridViewButtonColumn();
            buttonColumnSuprimer.Name = "ButtonColumnSuprimer";
            buttonColumnSuprimer.HeaderText = "Suprimer";
            buttonColumnSuprimer.Text = "Click me";
            buttonColumnSuprimer.UseColumnTextForButtonValue = true;
            guna2DataGridView1.Columns.Add(buttonColumnSuprimer);
            // Charger l'image depuis un fichier
            Image buttonImageModifierr = Image.FromFile("C:\\Users\\TAHA\\Source\\Repos\\tahasa3ada\\UML_Diagramme_Creation\\UML_Diagramme_Creation\\icons8-modifier-94.png");
            int rowNumber = 0;
            foreach (Class c in Classes)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(guna2DataGridView1, c.ClassName);

                // Ajouter un bouton avec une image Modifier
                DataGridViewButtonCell buttonCellModifier = new DataGridViewButtonCell();
                buttonCellModifier.Value = buttonImageModifierr; // Remplacez par votre image
                row.Cells[buttonColumnModiffier.Index] = buttonCellModifier;

                // Ajouter un bouton avec une image Suprimer
                DataGridViewButtonCell buttonCellSuprimer = new DataGridViewButtonCell();
                buttonCellSuprimer.Value = buttonImageModifierr; // Remplacez par votre image
                row.Cells[buttonColumnSuprimer.Index] = buttonCellSuprimer;


                rowNumber++;
                guna2DataGridView1.Rows.Add(row);
            }
        }

        private void Exitbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
