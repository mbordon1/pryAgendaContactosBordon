using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryAgendaContactosBordon
{
    internal class clsUsuario
    {
        private SqlConnection conexion;

        public clsUsuario(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        public bool UsuarioExiste(string usuario)
        {
            string consulta = "SELECT COUNT(ID) FROM Usuarios WHERE Usuario = @usuario";
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                int cantidad = (int)cmd.ExecuteScalar();
                return cantidad >= 1;
            }
        }

        public void RegistrarUsuario(string usuario, string contraseña)
        {
            string consulta = "INSERT INTO Usuarios (Usuario, Contraseña, FechaRegistro) VALUES(@usuario, @contraseña, @fecha)";
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                cmd.Parameters.AddWithValue("@fecha", DateTime.Today);
                cmd.ExecuteNonQuery();
            }
        }

        public bool IniciarSesion(string usuario, string contraseña)
        {
            string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario AND Contraseña = @contraseña";
            using (SqlCommand cmd = new SqlCommand(consulta, conexion))
            {
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", contraseña);
                int count = (int)cmd.ExecuteScalar();
                return count == 1;
            }
        }
    }
}
