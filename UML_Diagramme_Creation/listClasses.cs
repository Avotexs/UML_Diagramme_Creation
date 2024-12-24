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
        List<Relation> relation=new List<Relation>();
        public listClasses(List<Class> classes, List<Relation> relation)
        {
            InitializeComponent();
            Classes = new List<Class>();
            Classes = classes;
            this.relation = relation;
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void listClasses_Load_1(object sender, EventArgs e)
        {
            //Ajouter une colonne de boutons MODIFIER
            DataGridViewButtonColumn buttonColumnModifier = new DataGridViewButtonColumn();
            buttonColumnModifier.Name = "ButtonColumnModifier";
            buttonColumnModifier.HeaderText = "Modifier";
            buttonColumnModifier.Text = "Modifier"; // Texte du bouton
            buttonColumnModifier.UseColumnTextForButtonValue = true; // Permet d'utiliser le texte défini
            guna2DataGridView1.Columns.Add(buttonColumnModifier);

            // Ajouter une colonne de boutons SUPPRIMER
            DataGridViewButtonColumn buttonColumnSupprimer = new DataGridViewButtonColumn();
            buttonColumnSupprimer.Name = "ButtonColumnSupprimer";
            buttonColumnSupprimer.HeaderText = "Supprimer";
            buttonColumnSupprimer.Text = "Supprimer"; // Texte du bouton
            buttonColumnSupprimer.UseColumnTextForButtonValue = true; // Permet d'utiliser le texte défini
            guna2DataGridView1.Columns.Add(buttonColumnSupprimer);

            // Charger les données et ajouter des lignes
            foreach (Class c in Classes)
            {
                // Crée une nouvelle ligne
                DataGridViewRow row = new DataGridViewRow();

                // Ajoute les cellules pour la ligne
                row.CreateCells(guna2DataGridView1, c.ClassName); // Ajoute les données de classe

                // Ajout des cellules de bouton Modifier et Supprimer
                row.Cells[buttonColumnModifier.Index] = new DataGridViewButtonCell { Value = "Modifier" };
                row.Cells[buttonColumnSupprimer.Index] = new DataGridViewButtonCell { Value = "Supprimer" };

                // Ajoute la ligne à la DataGridView
                guna2DataGridView1.Rows.Add(row);
            }

            // Gérer les clics sur les boutons Modifier et Supprimer
            guna2DataGridView1.CellClick += Guna2DataGridView1_CellClick;
        }
        private void Guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifier que la ligne est valide
            if (e.RowIndex >= 0)
            {
                string className = guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                // Identifier la colonne cliquée
                if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "ButtonColumnModifier")
                {
                    // Action pour le bouton Modifier
                    ModifyClass(className, e.RowIndex);
                }
                else if (guna2DataGridView1.Columns[e.ColumnIndex].Name == "ButtonColumnSupprimer")
                {
                    // Action pour le bouton Supprimer
                    DeleteClass(className, e.RowIndex);
                }
            }
        }
        private void ModifyClass(string className, int rowIndex)
        {
            
        }
        private void DeleteClass(string className, int rowIndex)
        {
            // Confirmer la suppression
            DialogResult result = MessageBox.Show(
                $"Voulez-vous vraiment supprimer la classe '{className}' ?",
                "Confirmer la suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
               
                //relation
                // Supprimer toutes les relations associées à la classe
                relation.RemoveAll(r => r.Source.ClassName == className || r.Target.ClassName == className);

                // Supprimer la ligne correspondante dans la DataGridView
                guna2DataGridView1.Rows.RemoveAt(rowIndex);

                // Message de confirmation
                MessageBox.Show($"Classe '{className}' et ses relations supprimées avec succès.");


                // Supprimer la classe de la source de données
                Classes.RemoveAt(rowIndex);


                // Mettre à jour la DataGridView
                //guna2DataGridView1.Rows.RemoveAt(rowIndex);
                this.Close();
                MessageBox.Show($"Classe '{className}' supprimée avec succès.");
            }
        }
        /*
        private void DeleteClass(string className, int rowIndex)
        {
            // Confirmer la suppression
            DialogResult result = MessageBox.Show(
                $"Voulez-vous vraiment supprimer la classe '{className}' ?",
                "Confirmer la suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Supprimer toutes les relations associées à la classe
                relation.RemoveAll(r => r.Source.ClassName == className || r.Target.ClassName == className);

                // Supprimer la classe de la liste des classes
                Classes.RemoveAll(c => c.ClassName == className);

                // Supprimer la ligne correspondante dans la DataGridView
                guna2DataGridView1.Rows.RemoveAt(rowIndex);

                // Message de confirmation
                MessageBox.Show($"Classe '{className}' et ses relations supprimées avec succès.");

                
            }
        }
        */
        private void Exitbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
