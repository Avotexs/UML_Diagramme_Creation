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
        }

        private void Home_Load(object sender, EventArgs e)
        {
           
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
            
            AddClass addC = new AddClass(Classes);
            addC.Show();
            addC.retourn();
           
        }

        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            foreach (Class item in Classes)
            {
                MessageBox.Show(item.ClassName);
            }
        }
    }
}


