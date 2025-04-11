using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAgendaContactosBordon
{
    internal class clsConBDContactos
    {
        public string cadena;

        public clsConBDContactos()
        {
            cadena = "Server=localhost;Database=Contactos;Trusted_Connection=True;";
        }

        public void VerContactos(DataGridView dgvContactos)
        {
            try
            {               
                string consulta = @"
                SELECT 
                Nombre,
                Apellido,
                Telefono,
                Correo,
                Categoria
               FROM Contactos";

                using (SqlConnection conexion = new SqlConnection(cadena))
                using (SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion))
                {
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvContactos.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los contactos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
