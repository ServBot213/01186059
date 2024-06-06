using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocios;

namespace Proyecto
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private async void button4_ClickAsync(object sender, EventArgs e)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{textBox9.Text.ToLower()}";
            using (HttpClient client = new HttpClient())
            {
                try { 
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        PokemonData pokemon = JsonConvert.DeserializeObject<PokemonData>(jsonContent);

                        await SavePokemonToDatabase(pokemon);
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar solicitud. Código de estado: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task LoadItemDetails(string itemName)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/item/{itemName}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        ItemInfo itemInfo = JsonConvert.DeserializeObject<ItemInfo>(jsonContent);
                        MessageBox.Show($"Name: {itemInfo.Name}, Effect: {itemInfo.Effect_Entries.FirstOrDefault()?.Effect}", "Item Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar solicitud. Código de estado: " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task<string> LoadMoveDetails(string moveName)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/move/{moveName.ToLower()}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        MoveInfo moveInfo = JsonConvert.DeserializeObject<MoveInfo>(jsonContent);
                        return moveInfo.Flavor_Text_Entries.FirstOrDefault(entry => entry.Language.Name == "en")?.Flavor_Text ?? "Descripción no encontrada para este movimiento.";
                    }
                    else
                    {
                        return "Error al realizar solicitud. Código de estado: " + response.StatusCode;
                    }
                }
                catch (Exception ex)
                {
                    return "Error: " + ex.Message;
                }
            }
        }

        private async Task SavePokemonToDatabase(PokemonData pokemon)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" +"Integrated Security=True;"; // Cambia esto por tu cadena de conexión a la base de datos

            using (SqlConnection connection = new SqlConnection(connectionString))
    {
        await connection.OpenAsync();

        using (SqlCommand command = new SqlCommand())
        {
            command.Connection = connection;
            command.CommandText = @"
                INSERT INTO Pokemones (Id, NombreP, Descripcion, Objeto, Habilidad, Ataque1, Ataque2, Ataque3, Ataque4, HP, Ataque, Defensa, AtaqueE, DefensaE, Velocidad, Tipo, EquipoId)
                VALUES (@Id, @NombreP, @Descripcion, @Objeto, @Habilidad, @Ataque1, @Ataque2, @Ataque3, @Ataque4, @HP, @Ataque, @Defensa, @AtaqueE, @DefensaE, @Velocidad, @Tipo, @EquipoId)";

            // Aquí debes obtener el Id proporcionado por el usuario
            command.Parameters.AddWithValue("@Id", int.Parse(textBox11.Text)); 
            command.Parameters.AddWithValue("@NombreP", textBox9.Text);
            command.Parameters.AddWithValue("@Descripcion", richTextBox1.Text);
            command.Parameters.AddWithValue("@Objeto", comboBox2.SelectedItem?.ToString());
            command.Parameters.AddWithValue("@Habilidad", comboBox3.SelectedItem?.ToString());
            command.Parameters.AddWithValue("@Ataque1", comboBox4.SelectedItem?.ToString());
            command.Parameters.AddWithValue("@Ataque2", comboBox5.SelectedItem?.ToString());
            command.Parameters.AddWithValue("@Ataque3", comboBox6.SelectedItem?.ToString());
            command.Parameters.AddWithValue("@Ataque4", comboBox7.SelectedItem?.ToString());
            command.Parameters.AddWithValue("@HP", textBox1.Text);
            command.Parameters.AddWithValue("@Ataque", textBox2.Text);
            command.Parameters.AddWithValue("@Defensa", textBox3.Text);
            command.Parameters.AddWithValue("@AtaqueE", textBox5.Text);
            command.Parameters.AddWithValue("@DefensaE", textBox6.Text);
            command.Parameters.AddWithValue("@Velocidad", textBox4.Text);
            command.Parameters.AddWithValue("@Tipo", textBox10.Text);
            command.Parameters.AddWithValue("@EquipoId", string.IsNullOrWhiteSpace(textBox8.Text) ? DBNull.Value : (object)textBox8.Text);

            await command.ExecuteNonQueryAsync();
        } 
        
    }
}

        private async Task<string> GetPokemonDescription(string pokemonName)
        {
            string apiUrl = $"https://pokeapi.co/api/v2/pokemon-species/{pokemonName.ToLower()}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        dynamic pokemonSpecies = JsonConvert.DeserializeObject(jsonContent);

                        foreach (var entry in pokemonSpecies.flavor_text_entries)
                        {
                            if (entry.language.name == "en")
                            {
                                return entry.flavor_text;
                            }
                        }

                        return "Descripción no disponible en inglés.";
                    }
                    else
                    {
                        return "Error al obtener la descripción.";
                    }
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }
        }

        private async Task<DataTable> GetPokemonsByTeamId(int equipoId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto;" + "Integrated Security=True;";
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

        private void textBox9_TextChanged(object sender, EventArgs e)
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private async void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadMoveDetails(comboBox4.SelectedItem.ToString());
        }

        private async void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadMoveDetails(comboBox5.SelectedItem.ToString());
        }

        private async void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadMoveDetails(comboBox6.SelectedItem.ToString());
        }

        private async void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadMoveDetails(comboBox7.SelectedItem.ToString());
        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                await LoadItemDetails(comboBox2.SelectedItem.ToString());
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label17_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Contenido = new Form3();
            Contenido.Show();
            this.Hide();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] allowedDomains = { "@hotmail.com", "@gmail.com", "@outlook.com", "@outlook.es" };
            if (string.IsNullOrWhiteSpace(textBox9.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(comboBox3.Text) ||
                string.IsNullOrWhiteSpace(comboBox4.Text) ||
                string.IsNullOrWhiteSpace(comboBox5.Text) ||
                string.IsNullOrWhiteSpace(comboBox6.Text) ||
                string.IsNullOrWhiteSpace(comboBox7.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("No puede haber campos vacíos :(", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    CN_Usuario Pokemones = new CN_Usuario();
                    Pokemones.InsertarPokemon(textBox9.Text, comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text, int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox4.Text), textBox10.Text);

                    MessageBox.Show("El registro ha sido exitoso! :)", "Registro completo!", MessageBoxButtons.OK);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el Pokémon: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex);
                }
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click_1Async(object sender, EventArgs e)
        {

            string apiUrl = $"https://pokeapi.co/api/v2/pokemon/{textBox9.Text.ToLower()}";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonContent = await response.Content.ReadAsStringAsync();
                        PokemonData pokemon = JsonConvert.DeserializeObject<PokemonData>(jsonContent);

                        pictureBox1.ImageLocation = pokemon.Sprites.Front_Default;

                        if (pokemon.Stats != null && pokemon.Stats.Count >= 6)
                        {
                            textBox1.Text = pokemon.Stats[0].Base_Stat.ToString(); 
                            textBox2.Text = pokemon.Stats[1].Base_Stat.ToString();
                            textBox3.Text = pokemon.Stats[2].Base_Stat.ToString(); 
                            textBox4.Text = pokemon.Stats[5].Base_Stat.ToString(); 
                            textBox5.Text = pokemon.Stats[3].Base_Stat.ToString(); 
                            textBox6.Text = pokemon.Stats[4].Base_Stat.ToString();
                        }

                        if (pokemon.Moves != null && pokemon.Moves.Count >= 4)
                        {
                            comboBox4.Items.Clear();
                            comboBox5.Items.Clear();
                            comboBox6.Items.Clear();
                            comboBox7.Items.Clear();

                            foreach (var move in pokemon.Moves)
                            {
                                comboBox4.Items.Add(move.Move.Name);
                                comboBox5.Items.Add(move.Move.Name);
                                comboBox6.Items.Add(move.Move.Name);
                                comboBox7.Items.Add(move.Move.Name);
                            }

                            comboBox4.SelectedIndex = 0;
                            comboBox5.SelectedIndex = 0;
                            comboBox6.SelectedIndex = 0;
                            comboBox7.SelectedIndex = 0;
                        }

                        if (pokemon.Abilities != null && pokemon.Abilities.Count > 0)
                        {
                            comboBox3.Items.Clear();
                            foreach (var ability in pokemon.Abilities)
                            {
                                comboBox3.Items.Add(ability.Ability.Name);
                            }
                            comboBox3.SelectedIndex = 0;
                        }

                        if (pokemon.Held_Items != null && pokemon.Held_Items.Count > 0)
                        {
                            comboBox2.Items.Clear();
                            foreach (var item in pokemon.Held_Items)
                            {
                                comboBox2.Items.Add(item.Item.Name);
                            }
                            comboBox2.SelectedIndex = 0;
                        }

                        if (pokemon.Types != null && pokemon.Types.Count > 0)
                        {
                            var types = pokemon.Types.Select(t => t.Type.Name).ToArray();
                            textBox10.Text = string.Join(", ", types);
                        }

                        richTextBox1.Text = await GetPokemonDescription(pokemon.Name);

                    }
                    else
                    {
                        MessageBox.Show("Error al realizar alta " + response.StatusCode, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            
                if (int.TryParse(textBox8.Text, out int equipoId))
                {
                    try
                    {
                        DataSet dataSet = await GetEquipoAndPokemonesById(equipoId);

                        dataGridView1.DataSource = dataSet.Tables["Pokemones"];
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al obtener el equipo y sus pokemones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un valor válido para el Id del equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

