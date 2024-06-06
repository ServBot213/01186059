using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form9 : Form
    {
        private string connectionString = "Server=localhost; DataBase=Proyecto; Integrated Security=True;";

        public Form9()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Contenido = new Form1();
            Contenido.Show();
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
         
                int userId;
                if (int.TryParse(textBox1.Text, out userId))
                {
                    try
                    {
                        DataTable userData = await GetUserDataById(userId);

                        dataGridView1.DataSource = userData;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al buscar al usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un valor valido para el ID del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private async Task<DataTable> GetUserDataById(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM Usuario WHERE Id = @UserId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        DataTable userData = new DataTable();
                        userData.Load(reader);
                        return userData;
                    }
                }
            }
        }
        private async Task DeleteUserAndRelatedData(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteEquiposQuery = "DELETE FROM Equipos WHERE UsuarioId = @UserId";
                        using (SqlCommand command = new SqlCommand(deleteEquiposQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            await command.ExecuteNonQueryAsync();
                        }

                        string deleteHistorialQuery = "DELETE FROM HistorialCombates WHERE UsuarioId = @UserId";
                        using (SqlCommand command = new SqlCommand(deleteHistorialQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            await command.ExecuteNonQueryAsync();
                        }

                        string deleteUserQuery = "DELETE FROM Usuario WHERE Id = @UserId";
                        using (SqlCommand command = new SqlCommand(deleteUserQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            await command.ExecuteNonQueryAsync();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Error al eliminar usuario y datos relacionados: " + ex.Message);
                    }
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox2.Text) && int.TryParse(textBox2.Text, out int userId))
            {
                try
                {
                    await DeleteUserAndRelatedData(userId);

                    MessageBox.Show("Usuario y sus datos relacionados eliminados correctamente.", "Eliminacion Correcta",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar usuario y datos relacionados: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor valido para el ID del usuario.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
