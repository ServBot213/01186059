using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 Contenido = new Form4();
            Contenido.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 Contenido = new Form1();
            Contenido.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 Contenido = new Form5();
            Contenido.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola! este es un proyecto para la Universidad, todos los derechos pertecen a GameFreak y Nintendo como tal, por lo cual es un producto sin fines de lucro, y con posibles referencias para los interesados, es un software gratutito! disfrutalo :) -AlanJulian-","Informacion");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 Contenido = new Form6();
            Contenido.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 Contenido = new Form7();
            Contenido.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 Contenido = new Form8();
            Contenido.Show();
            this.Hide();
        }
    }
}
