using System;
using System.Data;
using System.Data.SqlClient;

namespace Capa_Persistencias
{
    public class CD_Usuario
    {
        private SqlConnection connection = new SqlConnection("Server=localhost;Database=Proyecto;Integrated Security=true;");

        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario", connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw new Exception("Error al mostrar usuarios: " + ex.Message);
            }
            return tabla;
        }

        public void Insertar(string nombre, string usuario, string contrasena, string correo)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Usuario (Nombre, Usuario, Contrasena, Correo) VALUES (@nombre, @usuario, @contrasena, @correo)", connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@correo", correo);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw new Exception("Error al insertar usuario: " + ex.Message);
            }
        }

        public void InsertarPokemon(string nombreP, string descripcion, string objeto, string habilidad, string ataque1, string ataque2, string ataque3, string ataque4, int hP, int ataque, int defensa, int ataqueE, int defensaE, int velocidad, string tipo, int equipoId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Pokemon (NombreP, Descripcion, Objeto, Habilidad, Ataque1, Ataque2, Ataque3, Ataque4, HP, Ataque, Defensa, AtaqueE, DefensaE, Velocidad, Tipo, EquipoId) VALUES (@nombreP, @descripcion, @objeto, @habilidad, @ataque1, @ataque2, @ataque3, @ataque4, @hp, @ataque, @defensa, @ataqueE, @defensaE, @velocidad, @tipo, @equipoId)", connection))
                {
                    cmd.Parameters.AddWithValue("@nombreP", nombreP);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@objeto", objeto);
                    cmd.Parameters.AddWithValue("@habilidad", habilidad);
                    cmd.Parameters.AddWithValue("@ataque1", ataque1);
                    cmd.Parameters.AddWithValue("@ataque2", ataque2);
                    cmd.Parameters.AddWithValue("@ataque3", ataque3);
                    cmd.Parameters.AddWithValue("@ataque4", ataque4);
                    cmd.Parameters.AddWithValue("@hp", hP);
                    cmd.Parameters.AddWithValue("@ataque", ataque);
                    cmd.Parameters.AddWithValue("@defensa", defensa);
                    cmd.Parameters.AddWithValue("@ataqueE", ataqueE);
                    cmd.Parameters.AddWithValue("@defensaE", defensaE);
                    cmd.Parameters.AddWithValue("@velocidad", velocidad);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@equipoId", equipoId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw new Exception("Error al insertar Pokémon: " + ex.Message);
            }
        }

        public DataTable MostrarEquipos()
        {
            DataTable tabla = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipos", connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    tabla.Load(reader);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw new Exception("Error al mostrar equipos: " + ex.Message);
            }
            return tabla;
        }

        public void Editar(string nombre, string contrasena, string correo, int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Nombre = @nombre, Contrasena = @contrasena, Correo = @correo WHERE Id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw new Exception("Error al editar usuario: " + ex.Message);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Usuario WHERE Id = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                throw new Exception("Error al eliminar usuario: " + ex.Message);
            }
        }
    }
}
