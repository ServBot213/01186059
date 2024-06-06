using Capa_Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Capa_Presentacion
{
    public partial class Form2 : Form
    {
        DataTable tabla = new DataTable();
        public Form2()
        {
            CN_Productos objetoCD = new CN_Productos();
            InitializeComponent();
            tabla = objetoCD.MostrarProd();
            dataGridView1.DataSource = tabla;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            CN_Productos objetoCD = new CN_Productos();
            string id = dataGridView1.CurrentCell.Value.ToString();
            objetoCD.EliminarProd(id);

            tabla = objetoCD.MostrarProd();
            dataGridView1.DataSource = tabla;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            CN_Productos objetoCD = new CN_Productos();
            string id = dataGridView1.CurrentCell.Value.ToString();
            string nombre = textBox1.Text;
            string desc = textBox2.Text;
            string marca = textBox3.Text;
            string precio = textBox4.Text;
            string stock = textBox5.Text;
            objetoCD.EditarProd(nombre, desc, marca, precio, stock, id);

            tabla = objetoCD.MostrarProd();
            dataGridView1.DataSource = tabla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CN_Productos objetoCD = new CN_Productos();
            string nombre = textBox1.Text;
            string desc = textBox2.Text;
            string marca = textBox3.Text;
            string precio = textBox4.Text;
            string stock = textBox5.Text;
            if (nombre.Length == 0 || desc.Length == 0 || marca.Length == 0 ||
                precio == null || stock == null)
            {
                MessageBox.Show("Se detectaron campos vacios.", "Aviso",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                objetoCD.insertarProd(nombre, desc, marca, precio, stock);
            }

            tabla = objetoCD.MostrarProd();
            dataGridView1.DataSource = tabla;



        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
