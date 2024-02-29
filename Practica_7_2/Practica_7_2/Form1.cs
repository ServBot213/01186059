using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_7_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown); // Suscripción al evento KeyDown
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep(523, 200);
            button14.Text = "DO";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.Beep(587, 200);
            button14.Text = "RE";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Console.Beep(932, 200);
            button14.Text = "LA#";
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.Beep(659, 200);
            button14.Text = "MI";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Console.Beep(698, 200);
            button14.Text = "FA";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.Beep(783, 200);
            button14.Text = "SOL";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Console.Beep(880, 200);
            button14.Text = "LA";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Console.Beep(987, 200);
            button14.Text = "SI";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Console.Beep(1046, 200);
            button14.Text = "MI";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Console.Beep(554, 200);
            button14.Text = "DO#";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Console.Beep(622, 200);
            button14.Text = "RE#";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Console.Beep(739, 200);
            button14.Text = "FA#";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Console.Beep(830, 200);
            button14.Text = "SOL#";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = e.KeyCode | e.Modifiers;
            if (e.KeyCode == Keys.A)
            {
                button1_Click(sender, e);
            }
            if (e.KeyCode == Keys.S)
            {
                button2_Click(sender, e);
            }
            if (e.KeyCode == Keys.D)
            {
                button3_Click(sender, e);
            }
            if (e.KeyCode == Keys.F)
            {
                button4_Click(sender, e);
            }
            if (e.KeyCode == Keys.G)
            {
                button5_Click(sender, e);
            }
            if (e.KeyCode == Keys.H)
            {
                button6_Click(sender, e);
            }
            if (e.KeyCode == Keys.J)
            {
                button7_Click(sender, e);
            }
            if (e.KeyCode == Keys.K)
            {
                button8_Click(sender, e);
            }
            if (e.KeyCode == Keys.E)
            {
                button9_Click(sender, e);
            }
            if (e.KeyCode == Keys.R)
            {
                button10_Click(sender, e);
            }
            if (e.KeyCode == Keys.T)
            {
                button11_Click(sender, e);
            }
            if (e.KeyCode == Keys.Y)
            {
                button12_Click(sender, e);
            }
            if (e.KeyCode == Keys.U)
            {
                button13_Click(sender, e);
            }
        }


    }
}
