using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAgendaContactosBordon
{
    public partial class frmAgendaDeContactos : Form
    {
        public frmAgendaDeContactos()
        {
            InitializeComponent();
        }    

        private void frmAgendaDeContactos_Load(object sender, EventArgs e)
        {
           clsConBDContactos BD = new clsConBDContactos();
            BD.VerContactos(dgvContactos);
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
