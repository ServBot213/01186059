﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }
        private int conteo;
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime inicio = monthCalendar1.SelectionStart;
            DateTime final = monthCalendar1.SelectionEnd;

            label1.Text = inicio.ToString();
            label2.Text = final.ToString();

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conteo = int.Parse(textBox1.Text);
            timer1.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                this.timer1.Enabled = false;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            conteo = conteo - 1;
            textBox1.Text = conteo.ToString();
            if (conteo == 0)
            {
                timer1.Enabled = false;
            }
        }
    }
}
