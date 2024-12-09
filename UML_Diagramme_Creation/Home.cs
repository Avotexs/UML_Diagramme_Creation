﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using static Guna.UI2.Native.WinApi;

namespace UML_Diagramme_Creation
{
    public partial class Home : Form
    {
        public List<Relation> Relations { get; set; } = new List<Relation>();
        public List<Class> Classes{ get; set; }
        private Class selectedClass=null;
        private Point mouseDownLocation;
        private bool isDragging = false; // Indique si le rectangle est en cours de déplacement

        public Home()
        {
            InitializeComponent();
            Classes = new List<Class>();

            panelHome.Paint += DrawingPanel_Paint;
           
            panelHome.MouseDown += home_MouseDown; // Détecte le clic initial
            panelHome.MouseMove += home_MouseMove; // Gère le déplacement
            panelHome.MouseUp += home_MouseUp; // Arrête le déplacement
        }

        // Dessiner tous les éléments dans la zone de dessin
        private void Redraw()
        {
            panelHome.Invalidate();  // Redessine le formulaire
        }
        private void home_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (var classElement in Classes)
            {
                if (classElement.Position.Contains(e.Location))
                {
                    isDragging = true; // Active le mode déplacement
                    selectedClass = classElement;
                    mouseDownLocation = e.Location; // Enregistre la position initiale du clic

                    break;
                }
            }
        }
        private void home_MouseMove(object sender, MouseEventArgs e)
        {
            if (selectedClass != null && isDragging == true)
            {
                // Calculer le déplacement
                int dx = e.X - mouseDownLocation.X;
                int dy = e.Y - mouseDownLocation.Y;

                // Mettre à jour la position de la classe
                selectedClass.Position = new Rectangle(
                    selectedClass.Position.X + dx,
                    selectedClass.Position.Y + dy,
                    selectedClass.Position.Width,
                    selectedClass.Position.Height
                );

                // Mettre à jour la position de la souris
                mouseDownLocation = e.Location;

                // Redessiner
                Redraw();
            }
        }
        private void home_MouseUp(object sender, MouseEventArgs e)
        {
            // Désactive le mode déplacement
            isDragging = false;
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
            base.OnPaint(e);
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

       

            // Dessiner les relations
            foreach (var relation in Relations)
            {
                // Get the source and target classes
                var sourceClass = relation.Source;
                var targetClass = relation.Target;

                // Calculate the source and target points on the borders
                Point sourceCenter = new Point(sourceClass.Position.X + sourceClass.Position.Width / 2, sourceClass.Position.Y + sourceClass.Position.Height / 2);
                Point targetCenter = new Point(targetClass.Position.X + targetClass.Position.Width / 2, targetClass.Position.Y + targetClass.Position.Height / 2);

                Point sourceBorderPoint = GetBorderPoint(sourceClass.Position, targetCenter);
                Point targetBorderPoint = GetBorderPoint(targetClass.Position, sourceCenter);
                // Dessiner une ligne ou une flèche entre les classes
                Pen pen;
                if (relation.Type == "Association")
                {
                    pen = Pens.Black;
                }
                else if (relation.Type == "Aggregation")
                {
                    pen = Pens.Blue;
                }
                else if (relation.Type == "Composition")
                {
                    pen = Pens.Green;
                }
                else if (relation.Type == "Inheritance")
                {
                    pen = Pens.Red;
                }
                else
                {
                    pen = Pens.Black; // Default
                }

                // Draw line representing the relation
                g.DrawLine(pen, sourceBorderPoint, targetBorderPoint);



            }
        }

        private void brnAddRelation_Click(object sender, EventArgs e)
        {
            using (var relationForm = new RelationForm(Classes)) // Passez la liste des classes existantes
            {
                if (relationForm.ShowDialog() == DialogResult.OK)
                {
                    // Récupérer les informations de la fenêtre popup
                    Class source = relationForm.SelectedSource;
                    Class target = relationForm.SelectedTarget;
                    string type = relationForm.SelectedType;

                    // Ajouter la relation
                    Relations.Add(new Relation(source, target, type));

                    // Redessiner le diagramme
                    Invalidate();
                }
            }
        }
        private Point GetBorderPoint(Rectangle rect, Point from)
        {
            float dx = from.X - (rect.X + rect.Width / 2);
            float dy = from.Y - (rect.Y + rect.Height / 2);
            float slope = dy / dx;

            Point borderPoint = new Point();

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                // Intersection with left or right border
                if (dx > 0)
                    borderPoint = new Point(rect.Right, (int)(rect.Y + rect.Height / 2 + slope * (rect.Width / 2)));
                else
                    borderPoint = new Point(rect.Left, (int)(rect.Y + rect.Height / 2 - slope * (rect.Width / 2)));
            }
            else
            {
                // Intersection with top or bottom border
                if (dy > 0)
                    borderPoint = new Point((int)(rect.X + rect.Width / 2 + (rect.Height / 2) / slope), rect.Bottom);
                else
                    borderPoint = new Point((int)(rect.X + rect.Width / 2 - (rect.Height / 2) / slope), rect.Top);
            }

            return borderPoint;
        }
    }
}


