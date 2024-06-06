using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 Contenido = new Form3();
            Contenido.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox15.Text, out int equipoId))
            {
                DataSet dataSet = await GetEquipoAndPokemonesById(equipoId);

                dataGridView1.DataSource = dataSet.Tables["Pokemones"];


                DataTable pokemones = await GetPokemonsByTeamId(equipoId);
                if (pokemones.Rows.Count > 0)
                {
                    DataRow pokemon = pokemones.Rows[0];

                    textBox9.Text = pokemon["NombreP"].ToString();
                    richTextBox1.Text = pokemon["Descripcion"].ToString();
                    textBox1.Text = pokemon["HP"].ToString();
                    textBox2.Text = pokemon["Ataque"].ToString();
                    textBox3.Text = pokemon["Defensa"].ToString();
                    textBox4.Text = pokemon["Velocidad"].ToString();
                    textBox5.Text = pokemon["AtaqueE"].ToString();
                    textBox6.Text = pokemon["DefensaE"].ToString();

                    textBox7.Text = pokemon["Objeto"].ToString();
                    textBox8.Text = pokemon["Habilidad"].ToString();
                    textBox10.Text = pokemon["Ataque1"].ToString();
                    textBox11.Text = pokemon["Ataque2"].ToString();
                    textBox12.Text = pokemon["Ataque3"].ToString();
                    textBox13.Text = pokemon["Ataque4"].ToString();

                    await LoadPokemonImage(textBox9.Text);
                }
                else
                {
                    MessageBox.Show("No se encontraron Pokemones con el Id proporcionado.");
                }
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
        }

        private async Task<DataTable> GetPokemonsByTeamId(int equipoId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" +"Integrated Security=True;"; 
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT NombreP, Descripcion, Objeto, Habilidad, Ataque1, Ataque2, Ataque3, Ataque4, HP, Ataque, Defensa, AtaqueE, DefensaE, Velocidad, Tipo
                FROM Pokemones
                WHERE EquipoId = @EquipoId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EquipoId", equipoId);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }

        private async Task LoadPokemonImage(string pokemonName)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{pokemonName.ToLower()}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        dynamic pokemon = JsonConvert.DeserializeObject(jsonContent);

                        pictureBox1.ImageLocation = pokemon.sprites.front_default;
                    }
                    else
                    {
                        MessageBox.Show("Error al obtener la imagen del Pokémon.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

    private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox23_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private async void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (int.TryParse(textBox15.Text, out int equipoId))
            {
                DataTable pokemones = await GetPokemonsByTeamId(equipoId);

                dataGridView1.DataSource = pokemones;
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para el Id del Equipo.");
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox16.Text, out int pokemonId))
            {
                DataTable pokemones = await GetPokemonByIdAndTeamId(pokemonId, int.Parse(textBox15.Text));
                if (pokemones.Rows.Count > 0)
                {
                    DataRow pokemon = pokemones.Rows[0];

                    textBox9.Text = pokemon["NombreP"].ToString();
                    richTextBox1.Text = pokemon["Descripcion"].ToString();
                    textBox1.Text = pokemon["HP"].ToString();
                    textBox2.Text = pokemon["Ataque"].ToString();
                    textBox3.Text = pokemon["Defensa"].ToString();
                    textBox4.Text = pokemon["Velocidad"].ToString();
                    textBox5.Text = pokemon["AtaqueE"].ToString();
                    textBox6.Text = pokemon["DefensaE"].ToString();

                    textBox7.Text = pokemon["Objeto"].ToString();
                    textBox8.Text = pokemon["Habilidad"].ToString();
                    textBox10.Text = pokemon["Ataque1"].ToString();
                    textBox11.Text = pokemon["Ataque2"].ToString();
                    textBox12.Text = pokemon["Ataque3"].ToString();
                    textBox13.Text = pokemon["Ataque4"].ToString();

                    
                    await LoadPokemonImage(textBox9.Text);
                }
                else
                {
                    MessageBox.Show("No se encontro un Pokémon con el Id proporcionado");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un valor válido para el Id del Pokémon.");
            }
        }
        private async Task<DataTable> GetPokemonByIdAndTeamId(int pokemonId, int equipoId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" +"Integrated Security=True;"; 
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT NombreP, Descripcion, Objeto, Habilidad, Ataque1, Ataque2, Ataque3, Ataque4, HP, Ataque, Defensa, AtaqueE, DefensaE, Velocidad, Tipo
            FROM Pokemones
            WHERE Id = @PokemonId AND EquipoId = @EquipoId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PokemonId", pokemonId);
                    command.Parameters.AddWithValue("@EquipoId", equipoId);

                    await connection.OpenAsync();
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        dataTable.Load(reader);
                    }
                }
            }

            return dataTable;
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox16.Text, out int idPokemon))
            {
                try
                {
                    await EliminarPokemon(idPokemon);

                    MessageBox.Show("El Pokemon ha sido eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimpiarControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el Pokemon: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Id de Pokemon ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarControles()
        {
            textBox16.Clear();
            pictureBox1.Image = null;
            textBox9.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private async Task EliminarPokemon(int idPokemon)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;";

            string query = "DELETE FROM Pokemones WHERE Id = @IdPokemon";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdPokemon", idPokemon);

                        await connection.OpenAsync();

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el Pokemon de la base de datos: {ex.Message}", ex);
            }
        }
        private async Task ActualizarPokemon(int idPokemon, string nuevaDescripcion, string nuevoAtaque1, string nuevoAtaque2, string nuevoAtaque3, string nuevoAtaque4, string nuevoObjeto)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;"; 

            string query = "UPDATE Pokemones SET Descripcion = @NuevaDescripcion, Ataque1 = @NuevoAtaque1, Ataque2 = @NuevoAtaque2, Ataque3 = @NuevoAtaque3, Ataque4 = @NuevoAtaque4, Objeto = @NuevoObjeto WHERE Id = @IdPokemon";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdPokemon", idPokemon);
                        command.Parameters.AddWithValue("@NuevaDescripcion", nuevaDescripcion);
                        command.Parameters.AddWithValue("@NuevoAtaque1", nuevoAtaque1);
                        command.Parameters.AddWithValue("@NuevoAtaque2", nuevoAtaque2);
                        command.Parameters.AddWithValue("@NuevoAtaque3", nuevoAtaque3);
                        command.Parameters.AddWithValue("@NuevoAtaque4", nuevoAtaque4);
                        command.Parameters.AddWithValue("@NuevoObjeto", nuevoObjeto);
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar la información del Pokémon en la base de datos: {ex.Message}", ex);
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

        private async void button3_Click_1(object sender, EventArgs e)
        {
            if(int.TryParse(textBox16.Text, out int idPokemon))
            {

                string nuevaDescripcion = richTextBox1.Text;
                string nuevoAtaque1 = textBox10.Text;
                string nuevoAtaque2 = textBox11.Text;
                string nuevoAtaque3 = textBox12.Text;
                string nuevoAtaque4 = textBox13.Text;
                string nuevoObjeto = textBox7.Text;

                try
                {
                    await ActualizarPokemon(idPokemon, nuevaDescripcion, nuevoAtaque1, nuevoAtaque2, nuevoAtaque3, nuevoAtaque4, nuevoObjeto);
                    MessageBox.Show("Los cambios se guardaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un Pokémon de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
