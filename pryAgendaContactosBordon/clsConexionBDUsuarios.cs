using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryAgendaContactosBordon
{
    internal class clsConexionBDUsuarios
    {
        private SqlConnection conexion;

        public clsConexionBDUsuarios()
        {
            string cadenaConexion = "Server=localhost;Database=Usuarios;Trusted_Connection=True;";
            conexion = new SqlConnection(cadenaConexion);
        }

        public void Abrir()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
        }

        public void Cerrar()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
        }

        public bool UsuarioExiste(string username)
        {
            string query = "SELECT COUNT(id) FROM users WHERE username = @user";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@user", username);
                int count = (int)cmd.ExecuteScalar();
                return count >= 1;
            }
        }

        public void RegistrarUsuario(string username, string password)
        {
            string query = "INSERT INTO users (username, password, date_register) " +
                           "VALUES(@username, @password, @dateReg)";
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@dateReg", DateTime.Today);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
