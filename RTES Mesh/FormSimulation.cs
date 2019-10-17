using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTES_Mesh
{
    public partial class FormSimulation : Form
    {

        public FormSimulation()
        {
            InitializeComponent();
        }

        private void FormSimulation_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            canvas1.Broadcast();
        }
    }
}
