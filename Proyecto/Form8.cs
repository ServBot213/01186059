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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 Contenido = new Form3();
            Contenido.Show();
            this.Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = string.IsNullOrWhiteSpace(textBox1.Text) ? 0 : int.Parse(textBox1.Text);
                string tipo = textBox2.Text;
                string habilidad = textBox3.Text;
                int equipoId = string.IsNullOrWhiteSpace(textBox4.Text) ? 0 : int.Parse(textBox4.Text);

                DataTable resultado = await BuscarPokemones(id, tipo, habilidad, equipoId);

                dataGridView1.DataSource = resultado;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar pokemones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private async Task<DataTable> BuscarPokemones(int id, string tipo, string habilidad, int equipoId)
        {
            string connectionString = "Server=localhost; DataBase=Proyecto; Integrated Security=True;";

            string query = "SELECT * FROM Pokemones WHERE 1=1";
            if (id != 0)
            {
                query += $" AND Id = {id}";
            }
            if (!string.IsNullOrWhiteSpace(tipo))
            {
                query += $" AND Tipo LIKE '%{tipo}%'";
            }
            if (!string.IsNullOrWhiteSpace(habilidad))
            {
                query += $" AND Habilidad LIKE '%{habilidad}%'";
            }
            if (equipoId != 0)
            {
                query += $" AND EquipoId = {equipoId}";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
