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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form3 Contenido = new Form3();
            Contenido.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && int.TryParse(textBox1.Text, out int usuarioId))
            {
                try
                {
                    await IncrementarVictorias(usuarioId);
                    await ActualizarDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el historial de combates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor valido para el Id del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && int.TryParse(textBox1.Text, out int usuarioId))
            {
                try
                {
                    await IncrementarEmpates(usuarioId);
                    await ActualizarDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el historial de combates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor valido para el Id del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && int.TryParse(textBox1.Text, out int usuarioId))
            {
                try
                {
                    await IncrementarDerrotas(usuarioId);
                    await ActualizarDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar el historial de combates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor valido para el Id del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task IncrementarVictoriasEnHistorial(int usuarioId)
            {
                string connectionString = "Server=localhost; DataBase=Proyecto; Integrated Security=True;"; 

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
            UPDATE HistorialCombates
            SET Victorias = Victorias + 1
            WHERE UsuarioId = @UsuarioId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            private async Task ActualizarHistorialCombates(int usuarioId, string tipoBatalla)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = $@"
            UPDATE HistorialCombates
            SET {tipoBatalla} = {tipoBatalla} + 1
            WHERE UsuarioId = @UsuarioId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task IncrementarVictorias(int usuarioId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE HistorialCombates SET Victorias = Victorias + 1 WHERE UsuarioId = @UsuarioId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task IncrementarEmpates(int usuarioId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE HistorialCombates SET Empates = Empates + 1 WHERE UsuarioId = @UsuarioId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task IncrementarDerrotas(int usuarioId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE HistorialCombates SET Derrotas = Derrotas + 1 WHERE UsuarioId = @UsuarioId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        private async Task ActualizarDataGridView()
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && int.TryParse(textBox1.Text, out int usuarioId))
            {
                try
                {
                    DataTable historialTable = await GetHistorialCombatesByUserId(usuarioId);
                    dataGridView1.DataSource = historialTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el historial de combates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

      
        public static async Task<string> GetNombreUsuarioById(int usuarioId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;"; 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT nombreUsuario FROM Usuario WHERE Id = @UsuarioId"; 

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                    await connection.OpenAsync();

                    object result = await command.ExecuteScalarAsync();

                    if (result != null)
                    {
                        return result.ToString();
                    }
                }
            }
            return string.Empty;
        }



        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && int.TryParse(textBox1.Text, out int usuarioId))
            {
                try
                {
                    DataTable historialTable = await GetHistorialCombatesByUserId(usuarioId);

                    dataGridView1.DataSource = historialTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el historial de combates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor valido para el Id del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<DataTable> GetHistorialCombatesByUserId(int usuarioId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;"; 
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT Victorias, Empates, Derrotas
            FROM HistorialCombates
            WHERE UsuarioId = @UsuarioId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioId", usuarioId);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }


        private async void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && int.TryParse(textBox1.Text, out int usuarioId))
            {
                try
                {
                    DataTable historialTable = await GetHistorialCombatesByUserId(usuarioId);

                    dataGridView1.DataSource = historialTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el historial de combates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor valido para el Id del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
