using Practica_16;
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
    public partial class Form1 : Form
    {

        DataTable tabla = new DataTable();
        CD_Usuarios objetoCD = new CD_Usuarios();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string contrasenia = textBox2.Text;
            string tUsuario;
            string tContrasenia;
            bool usuarioValido = false;
            tabla = objetoCD.Mostrar();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {

                tUsuario = Convert.ToString(tabla.Rows[i]["Nombre"]);
                tContrasenia = Convert.ToString(tabla.Rows[i]["contra"]);

                if (usuario == tUsuario && contrasenia == tContrasenia)
                {
                    usuarioValido = true;
                }

            }
            if (usuarioValido)
            {
                Form2 Contenido = new Form2();
                Contenido.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Acceso Denegado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
