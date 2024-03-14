using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practica9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String direccion = "";
        int Pedido = 0;
        String personaR = "";
        int telefono = 0;
        String color = "";
        String mensaje = "";
        int cantidad = 0;
        int montoA = 0;
        int resta = 0;
        String servicio = "";
        int costoT = 0;
        int fecha = 0;
        int Pedidod = 0;
        int operacion = 0;
        int operacion2 = 0;

        private async void button1_Click(object sender, EventArgs e)
        {
            string apiUrl = "https://jsonplaceholder.typicode.com/users";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string  jsonContent = await response.Content.ReadAsStringAsync();

                        Console.WriteLine("Datos JSON obtenidos:");
                        Console.WriteLine(jsonContent);
                    }
                    else {
                        Console.WriteLine("Error al realizar solicitud. Codigo de estado: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
            }
        }

            private void Form1_Load(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void groupBox2_Enter(object sender, EventArgs e)
            {

            }

            private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {

            }

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

            private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
            {

            }

        private void button2_Click(object sender, EventArgs e)
        {
            montoA = (int)numericUpDown3.Value;
            resta = (int)numericUpDown5.Value;
            costoT = (int)numericUpDown4.Value;
            operacion = costoT - montoA;
            operacion2 = operacion - resta;
            MessageBox.Show("\nCalculo a deber" + "\nEl precio total es: \n" + costoT + "\nUsted abono:\n" + montoA + "\nLe faltaban: \n" + resta + "\nLo que debe es:\n" + operacion2, "Operacion", MessageBoxButtons.OK);

            }

            private void button4_Click(object sender, EventArgs e)
            {
                DialogResult Respuesta = MessageBox.Show("Deseas salir?", "Salir..", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Respuesta == DialogResult.OK)
                {
                    Application.Exit();
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
       string.IsNullOrWhiteSpace(textBox2.Text) || 
       string.IsNullOrWhiteSpace(textBox5.Text) || 
       string.IsNullOrWhiteSpace(textBox6.Text) || 
       string.IsNullOrWhiteSpace(textBox9.Text))   
            {
                
                MessageBox.Show("Por favor, completa todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                DialogResult Respuesta2 = MessageBox.Show("Los datos son correctos?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
              if  (Respuesta2 == DialogResult.OK)
            {

                    Pedido = (int)numericUpDown1.Value;
                    direccion = textBox3.Text;
                    personaR = textBox2.Text;
                    color = textBox5.Text;
                    cantidad = (int)numericUpDown2.Value;
                    montoA = (int)numericUpDown3.Value;
                    resta = (int)numericUpDown5.Value;
                    costoT = (int)numericUpDown4.Value;
                    mensaje = textBox6.Text;

                    servicio = textBox9.Text;
                    MessageBox.Show("\nPedido:" + Pedido + "\nTipo de entrega:\n" + comboBox2.Text + "\nDia del pedido:\n" + dateTimePicker1.Text + "\nHora:\n" + dateTimePicker2.Text + "\nDireccion:\n" + direccion + "\nPersona que recibe:\n" + personaR + "\nTelefono:\n" + textBox1.Text + "\nTipo de arreglo: \n" + comboBox3.Text + "\nEnvoltorio: \n" + comboBox4.Text + "\nColor de envoltorio: \n" + comboBox5.Text + "\nColor de flor:\n" + textBox5.Text + "\nTipo de flor: \n" + comboBox6.Text + "\nMensaje:\n" + mensaje + "\nMonto apartado:\n" + montoA + "\nResta un total:\n" + resta + "\nVendedor:\n" + comboBox7.Text + "\nServicio por:\n" + servicio + "\nCosto total\n" + costoT, "PRUEBA", MessageBoxButtons.OK);

                }
            }
        }

            private void textBox3_TextChanged(object sender, EventArgs e)
            {

            }

            private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
            {

            }

            private void textBox2_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox9_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox5_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox6_TextChanged(object sender, EventArgs e)
            {

            }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
    }

