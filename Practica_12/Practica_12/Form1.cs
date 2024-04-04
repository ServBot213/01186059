using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Drawing.Printing;
using System.Media;

namespace Practica_12
{
    public partial class Form1 : Form
    {
        string archivo;
        FontStyle negrita = new FontStyle();
        FontStyle subrayado = new FontStyle();
        FontStyle italica = new FontStyle();
        FontStyle tachado = new FontStyle();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void alineacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                archivo = openFile.FileName;
                using (StreamReader sr = new StreamReader(archivo))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "|.txt";
            if (archivo != null)
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
            else
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    archivo = saveFile.FileName;
                    using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                Clipboard.SetDataObject(richTextBox1.SelectedText);
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            richTextBox1.Text = (string)iData.GetData(DataFormats.Text);
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.Cut();
        }

        private void limpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                archivo = openFile.FileName;
                using (StreamReader sr = new StreamReader(archivo))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "|.txt";
            if (archivo != null)
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
            else
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    archivo = saveFile.FileName;
                    using (StreamWriter sw = new StreamWriter(saveFile.FileName))
                    {
                        sw.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                Clipboard.SetDataObject(richTextBox1.SelectedText);
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            richTextBox1.Text = (string)iData.GetData(DataFormats.Text);
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText != "")
                richTextBox1.Cut();
        }

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo == true)
            {
                richTextBox1.Redo();
            }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo == true)
            {
                richTextBox1.Redo();
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void negritasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (negrita == FontStyle.Bold)
            {
                negrita = FontStyle.Regular;
            } else {
                negrita = FontStyle.Bold;
            }
            richTextBox1.Font = new Font(richTextBox1.Font, negrita | subrayado | italica | tachado);

        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Font = new Font(this.richTextBox1.Font.FontFamily,
          this.richTextBox1.Font.Size, this.richTextBox1.Font.Style ^ FontStyle.Strikeout);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Font = new Font(this.richTextBox1.Font.FontFamily,
          this.richTextBox1.Font.Size, this.richTextBox1.Font.Style ^ FontStyle.Italic);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Font = new Font(this.richTextBox1.Font.FontFamily,
        this.richTextBox1.Font.Size, this.richTextBox1.Font.Style ^ FontStyle.Underline);
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = richTextBox1.ForeColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = MyDialog.Color;
        }

        private void longitudToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int cantidadLetras = richTextBox1.Text.Length;
            MessageBox.Show($"La cantidad de letras en el texto es: {cantidadLetras}", "Cantidad de Letras", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

        private void mayusculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                int start = richTextBox1.SelectionStart;
                int length = richTextBox1.SelectionLength;
                richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();
                richTextBox1.Select(start, length);
            }
        }

        private void minusculasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                int start = richTextBox1.SelectionStart;
                int length = richTextBox1.SelectionLength;
                richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();
                richTextBox1.Select(start, length);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (Font font = new Font("Arial", 8.0f))
            {
                richTextBox1.Font = font;
                richTextBox1.Font = font;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            using (Font font = new Font("Arial", 16.0f))
            {
                richTextBox1.Font = font;
                richTextBox1.Font = font;
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            using (Font font = new Font("Arial", 32.0f))
            {
                richTextBox1.Font = font;
                richTextBox1.Font = font;
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            using (Font font = new Font("Arial", 40.0f))
            {
                richTextBox1.Font = font;
                richTextBox1.Font = font;
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            using (Font font = new Font("Arial", 72.0f))
            {
                richTextBox1.Font = font;
                richTextBox1.Font = font;
            }
        }

        private void derechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void izquierdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void imprimir(object sender, PrintPageEventArgs e)
        {
            Font font = new Font(richTextBox1.Font, negrita | subrayado | italica | tachado);
            string texto = richTextBox1.Text;
            e.Graphics.DrawString(texto, font, Brushes.Black, new RectangleF(0, 10, 800, 400));
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrintPage += imprimir;
                printDocument1.Print();
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog MyDialog = new FontDialog();
            if (MyDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = MyDialog.Font;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\usuario\Downloads\Iconos\2-06 All-Star Rest Area.wav");
            simpleSound.Play();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrintPage += imprimir;
                printDocument1.Print();
            }
        }
    }
}
