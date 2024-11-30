using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UML_Diagramme_Creation
{
    public partial class AddClass : Form
    {
        public List<Class> classes;
        Class c = new Class();
        public List<Methode> methodes=new List<Methode>();
        public List<Attribut> attributes = new List<Attribut>();

        public AddClass(List<Class> classe)
        {
            InitializeComponent();
            classes=new List<Class>();
            classes = classe;
        }

        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(guna2TextBox3.Text) && !(guna2ComboBox3.SelectedItem == null ||
               string.IsNullOrEmpty(guna2ComboBox3.SelectedItem.ToString())) && !(guna2ComboBox4.SelectedItem == null ||
               string.IsNullOrEmpty(guna2ComboBox4.SelectedItem.ToString())))
            {
                ListViewItem item = new ListViewItem(guna2TextBox3.Text);
                item.SubItems.Add(guna2ComboBox3.SelectedItem.ToString());
                item.SubItems.Add(guna2ComboBox4.SelectedItem.ToString());
                listView2.Items.Add(item);
            }
            else
            {
                MessageBox.Show("Il faut ramplir tous les champs de methode !!");
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addMethod(object sender, EventArgs e)
        {

        }

        private void AddClass_Load(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void addAttribute(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(guna2TextBox2.Text) && !(guna2ComboBox1.SelectedItem == null ||
            string.IsNullOrEmpty(guna2ComboBox1.SelectedItem.ToString())) && !(guna2ComboBox2.SelectedItem == null ||
            string.IsNullOrEmpty(guna2ComboBox2.SelectedItem.ToString())))
            {
                ListViewItem item = new ListViewItem(guna2TextBox2.Text);
                item.SubItems.Add(guna2ComboBox1.SelectedItem.ToString());
                item.SubItems.Add(guna2ComboBox2.SelectedItem.ToString());
                listView1.Items.Add(item);
            }
            else 
            {
                MessageBox.Show("Il faut ramplir tous les champs    de l'atribut !!");
            }
            

        }

        private MouseEventArgs MyMouseMethod(MouseEventArgs e2)
        {
            return e2;
        }

        private void SaveAddClassBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = (Home)this.Owner; // Assurez-vous que AddClass a été lancé avec ShowDialog ou Show
            homeForm.UpdateClasses(classes);
            this.Close();

            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                MessageBox.Show("Le ListView n'est pas rempli.");
            }
            else
            {
                int i;
                // Récupérer la position de la souris dans les coordonnées de l'écran
                Point mousePosition = Control.MousePosition;

                // Convertir en coordonnées locales du formulaire
                Point localPosition = this.PointToClient(mousePosition);
                MouseEventArgs e2 = new MouseEventArgs(MouseButtons.Left, 1, localPosition.X, localPosition.Y, 0);
                Rectangle rect = new Rectangle(e2.X - 50, e2.Y - 50, 120, 120);

                // cretion d'obet classe 
               
                c.ClassName = guna2TextBox1.Text;
                c.Position = rect;
                foreach (ListViewItem item in listView1.Items)
                {
                    attributes.Add(new Attribut(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text));
                }
                c.Attributes = attributes;
                foreach (ListViewItem itemm in listView2.Items)
                {
                    methodes.Add(new Methode(itemm.SubItems[0].Text, itemm.SubItems[1].Text, itemm.SubItems[2].Text));
                }
                c.Methodes = methodes;

         
                classes.Add(c);

                this.Close();




            }
            
        }
        public Class retourn()
        { return c; }
    }
}
