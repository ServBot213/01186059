using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_8
{
    public partial class Calculadora : Form
    {
        private Keys keyPressed;

        public Calculadora()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        double a;
        double b;
        string c;

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            playSimpleSound();
        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\usuario\Downloads\Stickers\Bizcochito.wav");
            simpleSound.Play();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(this.textBox1.Text);
            c = "+";

            this.textBox1.Clear();
            this.textBox1.Focus();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            b = Convert.ToDouble(this.textBox1.Text);
            double resultado = 0;

            switch (c)
            {
                case "+":
                    resultado = a + b;
                    break;
                case "-":
                    resultado = a - b;
                    break;
                case "*":
                    resultado = a * b;
                    break;
                case "/":
                    resultado = a / b;
                    break;
            }

            string operacionCompleta = $"{a} {c} {b} = {resultado}";
            this.textBox1.Text = resultado.ToString();
            this.richTextBox1.Text += operacionCompleta + Environment.NewLine;
            using (StreamWriter fichero = File.AppendText("Operaciones.txt"))
            {
                fichero.WriteLine(operacionCompleta);
            }
        }


        private void button15_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(this.textBox1.Text);
            c = "*";
            this.textBox1.Clear();
            this.textBox1.Focus();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(this.textBox1.Text);
            c = "/";
            this.textBox1.Clear();
            this.textBox1.Focus();
        }

        private void button14_Click(object sender, EventArgs e)
        {

            a = Convert.ToDouble(this.textBox1.Text);
            c = "-";
            textBox1.Text += "-";
            this.textBox1.Clear();
            this.textBox1.Focus();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            double angle = Convert.ToDouble(this.textBox1.Text);
            double result = Math.Sin(angle * Math.PI / 180);
            this.textBox1.Text = result.ToString();

            double angle1 = Convert.ToDouble(this.richTextBox1.Text);
            double result2 = Math.Sin(angle * Math.PI / 180);
            this.richTextBox1.Text = result.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            double angle = Convert.ToDouble(this.textBox1.Text);
            double result = Math.Cos(angle * Math.PI / 180); 
            this.textBox1.Text = result.ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            double angle = Convert.ToDouble(this.textBox1.Text);
            double result = Math.Tan(angle * Math.PI / 180); 
            this.textBox1.Text = result.ToString();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            double divisor = Convert.ToDouble(this.textBox1.Text);
            double result = a % divisor;
            this.textBox1.Text = result.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
          
            this.KeyDown -= Form1_KeyDown;
            Keys key = e.KeyCode | e.Modifiers;
            if (e.KeyCode == Keys.D1)
            {
                button1_Click(sender, e);
            }
            if (e.KeyCode == Keys.D2)
            {
                button2_Click(sender, e);
            }
            if (e.KeyCode == Keys.D3)
            {
                button3_Click(sender, e);
            }
            if (e.KeyCode == Keys.D4)
            {
                button4_Click(sender, e);
            }
            if (e.KeyCode == Keys.D5)
            {
                button5_Click(sender, e);
            }
            if (e.KeyCode == Keys.D6)
            {
                button6_Click(sender, e);
            }
            if (e.KeyCode == Keys.D7)
            {
                button7_Click(sender, e);
            }
            if (e.KeyCode == Keys.D8)
            {
                button8_Click(sender, e);
            }
            if (e.KeyCode == Keys.D9)
            {
                button9_Click(sender, e);
            }
            if (e.KeyCode == Keys.D0)
            {
                button10_Click(sender, e);
            }
            if (e.KeyCode == Keys.D1)
            {
                button13_Click(sender, e);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void verHistorialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            StreamReader fichero = null;
            string linea;

            try
            {
                fichero = File.OpenText("Operaciones.txt");

                richTextBox1.Clear();

                while ((linea = fichero.ReadLine()) != null)
                {
                    richTextBox1.AppendText(linea + "\n");
                }

           
                richTextBox1.Visible = true;
                label1.Visible = true;
                button12.Visible = true;
                button24.Visible = true;
            }
            catch (IOException ex)
            {
                
                MessageBox.Show("Error al leer el archivo: " + ex.Message);
            }
            finally
            {
  
                if (fichero != null)
                    fichero.Close();
            }
        }

        private void borrarHistorialToolStripMenuItem1_Click(object sender, EventArgs e)
        { 
            File.WriteAllText("Operaciones.txt",string.Empty);
        }

        private void cerrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            label1.Visible = false;
            button12.Visible = false;
            button24.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
