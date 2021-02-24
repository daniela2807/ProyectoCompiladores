using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCompiladores
{
    public partial class Form1 : Form
    {

        public string ruta = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string r;
            openFileDialog1.ShowDialog();
            System.IO.StreamReader archivo = new System.IO.StreamReader(openFileDialog1.FileName);
            ruta = openFileDialog1.FileName;
            r = archivo.ReadLine();
            richTextBox1.Text = r.ToString();

        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ruta != null)
            {
                //File.Delete(ruta);
                using (FileStream fs = File.Create(ruta))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(richTextBox1.Text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                saveFileDialog1.FileName = "Sintitulo.txt";
                saveFileDialog1.Filter = "Text Files | *.txt";
                saveFileDialog1.DefaultExt = "txt";
                var guardar = saveFileDialog1.ShowDialog();
                if (guardar == DialogResult.OK)
                {
                    using (var guardar_archivo = new System.IO.StreamWriter(saveFileDialog1.FileName))
                    {
                        guardar_archivo.WriteLine(richTextBox1.Text);
                    }
                }
            }
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void atrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void adelanteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void eliminarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void formatoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var font = fontDialog1.ShowDialog();
            if (font == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Sintitulo.txt";
            saveFileDialog1.Filter= "Text Files | *.txt";
            saveFileDialog1.DefaultExt = "txt";
            var guardar = saveFileDialog1.ShowDialog();
            if (guardar == DialogResult.OK)
            {
                using (var guardar_archivo = new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    guardar_archivo.WriteLine(richTextBox1.Text);
                }
            }
        }
    }
}
