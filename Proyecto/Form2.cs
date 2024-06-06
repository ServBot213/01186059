using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocios;
namespace Proyecto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string[] allowedDomains = { "@hotmail.com", "@gmail.com", "@outlook.com", "@outlook.es" };
            if (string.IsNullOrWhiteSpace(textBox1.Text) || 
                string.IsNullOrWhiteSpace(textBox2.Text) || 
                string.IsNullOrWhiteSpace(textBox3.Text) || 
                string.IsNullOrWhiteSpace(textBox4.Text))   
            {
                MessageBox.Show("No puede haber campos vacíos :(", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string email = textBox4.Text;
                bool isValidEmail = false;

                foreach (string domain in allowedDomains)
                {
                    if (email.EndsWith(domain))
                    {
                        isValidEmail = true;
                        break;
                    }
                }

                if (!isValidEmail)
                {
                    MessageBox.Show("Ingrese un correo electronico válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    CN_Usuario usuario = new CN_Usuario();
                    usuario.InsertarUsuario(textBox1.Text, textBox3.Text, textBox2.Text, textBox4.Text); // nombre, usuario, contrasena, correo

                    MessageBox.Show("El registro ha sido exitoso! :)", "Registro completo!", MessageBoxButtons.OK);
                    Form1 Contenido = new Form1();
                    Contenido.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Contenido = new Form1();
            Contenido.Show();
            this.Hide();
        }
    }
}
