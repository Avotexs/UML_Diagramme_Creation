using Guna.UI2.WinForms;
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
            int rowNumber = 0;
            foreach (Class c in Classes)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(guna2DataGridView1, c.ClassName);
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
