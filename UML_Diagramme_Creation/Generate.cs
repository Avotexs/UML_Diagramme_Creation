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
    public partial class Generate : Form
    {
        public Generate()
        {
            InitializeComponent();
        }

        private void generateexitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
