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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int equipoId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                try
                {
                    await EliminarEquipo(equipoId);
                    MessageBox.Show("El equipo ha sido eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await ActualizarDataGridViews();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el equipo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (dataGridView2.SelectedRows.Count > 0)
            {
                int pokemonId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id"].Value);

                try
                {
                    await EliminarPokemon(pokemonId);

                    MessageBox.Show("El pokemon ha sido eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    await ActualizarDataGridViews();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el pokemon: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipo o un pokemon para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private async Task EliminarEquipo(int equipoId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;"; 

            string query = "DELETE FROM Equipos WHERE Id = @EquipoId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EquipoId", equipoId);

                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el equipo : {ex.Message}", ex);
            }
        }

        private async Task EliminarPokemon(int pokemonId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;"; 

            string query = "DELETE FROM Pokemones WHERE Id = @PokemonId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PokemonId", pokemonId);

                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el pokemon de la base de datos: {ex.Message}", ex);
            }
        }

        private async Task ActualizarDataGridViews()
        {
            DataTable equiposTable = await GetEquipos();

            DataTable pokemonesTable = await GetPokemones();

            dataGridView1.DataSource = equiposTable;
            dataGridView2.DataSource = pokemonesTable;
        }

        private async Task<DataTable> GetEquipos()
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;"; 
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Equipos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }

        private async Task<DataTable> GetPokemones()
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Pokemones";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int equipoId))
            {
                try
                {
                    DataSet dataSet = await GetEquipoAndPokemonesById(equipoId);

                    dataGridView1.DataSource = dataSet.Tables["Equipo"];
                    dataGridView2.DataSource = dataSet.Tables["Pokemones"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el equipo y sus pokemones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor valido para el Id del equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task<DataSet> GetEquipoAndPokemonesById(int equipoId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;";
            DataSet dataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string equipoQuery = "SELECT * FROM Equipos WHERE Id = @EquipoId";
                string pokemonesQuery = "SELECT * FROM Pokemones WHERE EquipoId = @EquipoId";

                using (SqlCommand equipoCommand = new SqlCommand(equipoQuery, connection))
                using (SqlCommand pokemonesCommand = new SqlCommand(pokemonesQuery, connection))
                {
                    equipoCommand.Parameters.AddWithValue("@EquipoId", equipoId);
                    pokemonesCommand.Parameters.AddWithValue("@EquipoId", equipoId);

                    await connection.OpenAsync();

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = equipoCommand;
                        adapter.Fill(dataSet, "Equipo");

                        adapter.SelectCommand = pokemonesCommand;
                        adapter.Fill(dataSet, "Pokemones");
                    }
                }
            }

            return dataSet;
        }





        private void button4_Click_1(object sender, EventArgs e)
        {
            Form3 Contenido = new Form3();
            Contenido.Show();
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
