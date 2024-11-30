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
    public partial class Home : Form
    {
        public List<Class> Classes{ get; set; }
        public Home()
        {
            InitializeComponent();
            Classes = new List<Class>();
            panelHome.Paint += DrawingPanel_Paint;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            /*
            using (Graphics g = panelHome.CreateGraphics())
            {
                // Créer un rectangle représentant la zone du panneau
                Rectangle rect = panelHome.ClientRectangle;

                // Créer un PaintEventArgs avec Graphics et le rectangle
                PaintEventArgs pe = new PaintEventArgs(g, rect);

                // Appeler la méthode DrawingPanel_Paint
                DrawingPanel_Paint(panelHome, pe);
            }
            */



        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Classbtn_Click(object sender, EventArgs e)
        {
            //Class clss=new Class();
           // clss.Show();
        }

        private void Associationbtn_Click(object sender, EventArgs e)
        {
            Association association=new Association();
            association.Show();
        }

        private void Generatebtn_Click(object sender, EventArgs e)
        {
            Generate generate=new Generate();
            generate.Show();    
        }

        private void Exportbtn_Click(object sender, EventArgs e)
        {

            Export export=new Export(); 
            export.Show();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            AddClass addClassForm = new AddClass(Classes);
            addClassForm.Owner = this;
            addClassForm.ShowDialog();
            
            using (Graphics g = panelHome.CreateGraphics())
            {
                // Créer un rectangle représentant la zone du panneau
                Rectangle rect = panelHome.ClientRectangle;

                // Créer un PaintEventArgs avec Graphics et le rectangle
                PaintEventArgs pe = new PaintEventArgs(g, rect);

                // Appeler la méthode DrawingPanel_Paint
                DrawingPanel_Paint(panelHome, pe);
            }
            

        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            //string chaine="ta";
            /*
            foreach (Class item in Classes)
            {
                MessageBox.Show(item.ClassName);
                if (Classes != null && item.Attributes != null)
                {
                    foreach (Attribut it in item.Attributes)
                    {

                        //MessageBox.Show(it.retournAttribut());
                        it.retournAttribut();
                        

                    }
                    foreach (Methode it in item.Methodes)
                    {

                        //MessageBox.Show(it.retournAttribut());
                        it.retournMethod();


                    }
                }
               
                
                   
            }
            */

            //MessageBox.Show(chaine);

        
           

        }
        public void UpdateClasses(List<Class> updatedClasses)
        {
            Classes = updatedClasses;
            Invalidate(); // Demander un rafraîchissement pour redessiner les classes
        }
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            foreach (var umlClass in Classes)
            {
                // Calculate heights dynamically
                int nameHeight = 30; // Fixed height for the class name section
                int attributeHeight = Math.Max(umlClass.Attributes.Count * 20, 30); // 20px per attribute, minimum 30px
                int methodHeight = Math.Max(umlClass.Methodes.Count * 20, 30); // 20px per method, minimum 30px

                int sectionHeight = nameHeight + attributeHeight + methodHeight;

                // connaitre la linge la plus long
                int maxLengthA = 0;
                int maxLengthM = 0;

                foreach (var chaineA in umlClass.Attributes)
                {
                    if (chaineA.retournAttribut().Length > maxLengthA)
                    {
                        maxLengthA = chaineA.retournAttribut().Length;
                    }
                }

                foreach (var chaineM in umlClass.Methodes)
                {
                    if (chaineM.retournMethod().Length > maxLengthM)
                    {
                        maxLengthA = chaineM.retournMethod().Length;
                    }
                }
                int rep;
                if (maxLengthA > maxLengthM) 
                {
                    rep = maxLengthA*7;
                }
                else
                {
                    rep = maxLengthM*7;
                }
                // Diviser en trois parties pour le nom, les attributs et les méthodes


                // Dessiner le nom de la classe
                Rectangle nameRect = new Rectangle(umlClass.Position.X, umlClass.Position.Y, rep, nameHeight);
                g.FillRectangle(Brushes.LightBlue, nameRect);
                g.DrawRectangle(Pens.Black, nameRect);
                g.DrawString(umlClass.ClassName, new Font("Arial", 10), Brushes.Black, nameRect);

                // Dessiner les attributs
                Rectangle attributesRect = new Rectangle(umlClass.Position.X, umlClass.Position.Y + nameHeight, rep, attributeHeight);
                g.FillRectangle(Brushes.LightYellow, attributesRect);
                g.DrawRectangle(Pens.Black, attributesRect);
                int yOffset = attributesRect.Y;
                foreach (Attribut attribut in umlClass.Attributes)
                {
                    g.DrawString(attribut.retournAttribut(), new Font("Arial", 8), Brushes.Black, attributesRect.X + 5, yOffset + 5);
                    yOffset += 15;
                    
                }

                // Dessiner les méthodes
                Rectangle methodsRect = new Rectangle(umlClass.Position.X, umlClass.Position.Y + nameHeight + attributeHeight, rep, methodHeight);
                g.FillRectangle(Brushes.LightGreen, methodsRect);
                g.DrawRectangle(Pens.Black, methodsRect);
                yOffset = methodsRect.Y;
                foreach (Methode method in umlClass.Methodes)
                {
                    g.DrawString(method.retournMethod(), new Font("Arial", 8), Brushes.Black, methodsRect.X + 5, yOffset + 5);
                    yOffset += 15;
                    


                }
            }
        }
    }
}


