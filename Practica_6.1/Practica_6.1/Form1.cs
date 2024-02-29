using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica_6._1
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

        private void label4_Click(object sender, EventArgs e)
        {
            this.label4.Font = new Font(this.label4.Font.FontFamily,
          this.label4.Font.Size, this.label4.Font.Style ^ FontStyle.Italic);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            FontFamily csl = new FontFamily("Consolas");
            this.label4.Font = new Font(csl, this.label4.Font.Size,
            this.label4.Font.Style);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FontFamily mss = new FontFamily("Microsoft Sans Serif"); this.label4.Font = new
            Font(mss, 8, FontStyle.Regular);
        }

        private void label4_ChangeUICues(object sender, UICuesEventArgs e)
        {
          
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.label4.Font = new Font(this.label4.Font.FontFamily,
          this.label4.Font.Size, this.label4.Font.Style ^ FontStyle.Strikeout);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            this.label4.Font = new Font(this.label4.Font.FontFamily, 8,
            this.label4.Font.Style);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            this.label4.Font = new Font(this.label4.Font.FontFamily, 16,
            this.label4.Font.Style);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            this.label4.Font = new Font(this.label4.Font.FontFamily, 12,
            this.label4.Font.Style);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            this.label4.Font = new Font(this.label4.Font.FontFamily, 20,
            this.label4.Font.Style);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            FontFamily csl = new FontFamily("colonna MT");
            this.label4.Font = new Font(csl, this.label4.Font.Size,
            this.label4.Font.Style);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            FontFamily csl = new FontFamily("Verdana");
            this.label4.Font = new Font(csl, this.label4.Font.Size,
            this.label4.Font.Style);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            FontFamily csl = new FontFamily("Broadway");
            this.label4.Font = new Font(csl, this.label4.Font.Size,
            this.label4.Font.Style);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            this.label4.Font = new Font(this.label4.Font.FontFamily,
          this.label4.Font.Size, this.label4.Font.Style ^ FontStyle.Underline);
        }

        private void Checkedbox1(object sender, EventArgs e)
        {
            this.label4.Font = new Font(this.label4.Font.FontFamily,
        this.label4.Font.Size, this.label4.Font.Style ^ FontStyle.Bold);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
