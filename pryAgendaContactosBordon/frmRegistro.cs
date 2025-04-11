using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pryAgendaContactosBordon
{
    public partial class frmRegistro : Form
    {
        SqlConnection Conexion = new SqlConnection(@"Server=localhost;Database=Contactos;Trusted_Connection=True;");

        public frmRegistro()
        {
            InitializeComponent();
        }

        private void lblSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Form1 InicioDeSesion = new Form1();
            InicioDeSesion.Show();
        }

        private void chkMostrarCont_CheckedChanged(object sender, EventArgs e)
        {
            txtContraseñaReg.PasswordChar = chkMostrarCont.Checked ? '\0' : '*';
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtUsuarioReg.Text == "" && txtContraseñaReg.Text == "")
            {
                MessageBox.Show("Por favor llene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                clsConexionBDUsuarios BD = new clsConexionBDUsuarios();

                try
                {
                    BD.Abrir();

                    if (BD.UsuarioExiste(txtUsuarioReg.Text.Trim()))
                    {
                        MessageBox.Show(txtUsuarioReg.Text.Trim() + "Usuario existente","Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        BD.RegistrarUsuario(txtUsuarioReg.Text.Trim(), txtContraseñaReg.Text.Trim());

                        MessageBox.Show("Registro exitoso!","Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 InicioDeSesion = new Form1();
                        InicioDeSesion.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message,"EW", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    BD.Cerrar();
                }
            }
        }
    }
}
