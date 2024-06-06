using Capa_Persistencias;
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


namespace Proyecto
{
    public partial class Form1 : Form
    {
        DataTable tabla = new DataTable();
        CD_Usuario objetoCD = new CD_Usuario();
        public Form1()
        {
            InitializeComponent();
        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\usuario\Downloads\Stickers\Bizcochito.wav");
            simpleSound.Play();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Contenido = new Form2();
            Contenido.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contrasena = textBox2.Text;
            string tUsuario;
            string tContrasena;
            bool usuarioValido = false;
            tabla = objetoCD.Mostrar();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {

                tUsuario = Convert.ToString(tabla.Rows[i]["usuario"]);
                tContrasena = Convert.ToString(tabla.Rows[i]["contrasena"]);

                if (usuario == tUsuario && contrasena == tContrasena)
                {
                    usuarioValido = true;
                    break;
                }
               

            }
            if (usuarioValido)
            {
                Form3 Contenido = new Form3();
                Contenido.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (usuario == "Admin" && contrasena == "Admin")
            {
                
                Form9 Contenido = new Form9();
                Contenido.Show();
                this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            playSimpleSound();
            Form10 Contenido = new Form10();
            Contenido.Show();
            this.Hide();
        }
    }
}
