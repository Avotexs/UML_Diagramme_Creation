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
    public partial class Association : Form
    {
        public Association()
        {
            InitializeComponent();
        }

        private void associationexitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
