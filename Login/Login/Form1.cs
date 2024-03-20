using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "213" || textBox1.Text == "Alan" ) {
                Form2 Contenido = new Form2();
                Contenido.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Contraseña invalida, vuelva a internarlo..","Error");

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string Usuario;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string contra;
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            if (checkBox1.Checked == false)
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
