using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int contador = 0;
        private int contador2 = 0;

        private void label4_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
         Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.label7.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool contador3 = false;

            if (contador2 >= 7)
            {
                Form2 Contenido = new Form2();
                Contenido.Show();
                this.Hide();
            }

            if (textBox1.Text == "C")
            {
                this.label1.Visible = true;
                contador3 = true;
            }

            if (textBox1.Text == "H")
            {
                this.label2.Visible = true;
                contador3 = true;
            }
            if (textBox1.Text == "A")
            {
                this.label3.Visible = true;
                contador3 = true;
            }
            if (textBox1.Text == "N")
            {
                this.label4.Visible = true;
                contador3 = true;
            }
            if (textBox1.Text == "G")
            {
                this.label5.Visible = true;
                contador3 = true;
            }

            if (textBox1.Text == "O")
            {
                this.label6.Visible = true;
                contador3 = true;
            }

            if (textBox1.Text == "S")
            {
                this.label7.Visible = true;
                contador3 = true;
            }
            if (contador3 == true)
            {
                contador++;
            }
            else
            {
                contador2++;
            }
            if(contador2 == 1){
               pictureBox13.Visible = false;
            }
            if (contador2 == 2)
            {
                pictureBox8.Visible = false;
            }
            if (contador2 == 3)
            {
                pictureBox9.Visible = false;
            }
            if (contador2 == 4)
            {
                pictureBox10.Visible = false;
            }
            if (contador2 == 5)
            {
                pictureBox11.Visible = false;
            }
            if (contador2 == 6)
            {
                pictureBox12.Visible = false;
            }
            if (contador2 == 7)
            {
                pictureBox13.Visible = false;
            }
            richTextBox1.AppendText(textBox1.Text + ",");
            }

        private void button2_Click(object sender, EventArgs e)
        {
            contador++;

            if (contador2 > 7)
            {

                Form2 Contenido = new Form2();
                Contenido.Show();
                this.Hide();
            }


            if (textBox1.Text == "CHANGOS")
            {
                Form3 Contenido = new Form3();
                Contenido.Show();
                this.Hide();
            }
            else
            {
                Form2 Contenido = new Form2();
                Contenido.Show();
                this.Hide();

            }

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
           

        }

        private void label11_Click_1(object sender, EventArgs e)
        {
            if(contador == 1)
            {
                
            }
            else
            {

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
