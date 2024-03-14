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

namespace Practica9._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
       string.IsNullOrWhiteSpace(textBox2.Text) ||
       string.IsNullOrWhiteSpace(textBox5.Text) ||
       string.IsNullOrWhiteSpace(textBox6.Text) ||
       string.IsNullOrWhiteSpace(textBox1.Text) ||
        string.IsNullOrWhiteSpace(textBox3.Text)||
        string.IsNullOrWhiteSpace(textBox4.Text) ||
       (radioButton1.Checked == false &&
       radioButton2.Checked == false))
            {

                MessageBox.Show("Por favor, completa todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Los datos se ingresaron correctamente!", "Validacion");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta = MessageBox.Show("Deseas salir?", "Salir..", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Respuesta == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
